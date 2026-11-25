using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;
using G4.WebDriver.Remote.Uia;

using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace G4.Plugins.Ui.Actions.User32
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.User32.Manifests.{nameof(InvokeUser32DragAndDrop)}.json")]
    public class InvokeUser32DragAndDrop(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The point of an element the pointer goes to when the rule sets no alignment: the element center.
        private const string DefaultAlignment = "MiddleCenter";

        // The total time, in milliseconds, of the moves between the press and the release when the rule sets none.
        private const int DefaultDurationMilliseconds = 300;

        // The number of moves between the source and the end point when the rule sets none. The UIA driver jumps the
        // cursor to each point, so a drag that an application follows is built from several short jumps.
        private const int DefaultSteps = 10;

        // The time, in milliseconds, the button stays down before the first move, so the application can start its
        // drag.
        private const int HoldMilliseconds = 100;

        // The largest number of moves a rule may ask for; it keeps the one request to the driver small.
        private const int MaximumSteps = 100;

        // The route name, in the command table of the UIA driver client, of the call that moves the cursor to a
        // point of an element and returns that point in screen pixels.
        private const string MoveToElementCommand = "MoveUser32MouseToElement";

        // The distance, in pixels, of the short move right after the press. It crosses the drag threshold Windows
        // applies before an application starts a drag.
        private const int NudgePixels = 5;

        // The time, in milliseconds, the pointer rests over the end point before the release, so the application can
        // mark the drop zone before the drop arrives.
        private const int ReleaseDelayMilliseconds = 50;

        // Lists the time-span forms a duration may use: hh:mm:ss, or d.hh:mm:ss with whole days first.
        private static readonly string[] TimeSpanFormats = [@"hh\:mm\:ss", @"d\.hh\:mm\:ss"];

        /// <summary>
        /// Builds the whole drag as one sequence of screen points: move to the grab point, press, hold, nudge, move
        /// in steps, rest over the end point, and release.
        /// </summary>
        /// <param name="driver">The driver the sequence is sent to; nothing is sent here.</param>
        /// <param name="drag">The grab point, the drop point, and the pace of the drag, as read from the rule.</param>
        /// <returns>The sequence, ready to be sent in one request.</returns>
        /// <remarks>
        /// Every move is absolute, and every pause is a pointer action, because the UIA driver runs the whole pointer
        /// source before the keyboard source.
        /// </remarks>
        internal static ActionSequence NewDragSequence(IWebDriver driver, DragModel drag)
        {
            // Start an empty sequence bound to the driver; the actions are only collected here, not sent.
            var sequence = new ActionSequence(driver);

            // Press the left button on the grab point, and hold it so the application can start its drag.
            AddMove(sequence, x: drag.Start.X, y: drag.Start.Y);
            sequence.AddPointerDown(button: MouseActionModel.MouseButtons.Left);
            AddPause(sequence, duration: HoldMilliseconds);

            // Nudge toward the end point, so the cursor crosses the drag threshold at once. A path shorter than the
            // nudge moves only as far as the path itself.
            var deltaX = drag.End.X - drag.Start.X;
            var deltaY = drag.End.Y - drag.Start.Y;
            var nudgeX = Math.Sign(deltaX) * Math.Min(NudgePixels, Math.Abs(deltaX));
            var nudgeY = Math.Sign(deltaY) * Math.Min(NudgePixels, Math.Abs(deltaY));
            AddMove(sequence, x: drag.Start.X + nudgeX, y: drag.Start.Y + nudgeY);

            // Cover the rest of the path in equal steps, each followed by its share of the duration. Each point is
            // absolute, and the last one is the end point itself.
            var remainingX = deltaX - nudgeX;
            var remainingY = deltaY - nudgeY;

            for (var step = 1; step <= drag.Steps; step++)
            {
                // Move to this step's point on the line from the nudge to the end point.
                var x = drag.Start.X + nudgeX + GetPart(total: remainingX, step, steps: drag.Steps);
                var y = drag.Start.Y + nudgeY + GetPart(total: remainingY, step, steps: drag.Steps);
                AddMove(sequence, x, y);

                // Wait for this step's share of the duration; a zero share adds no pause.
                var upToStep = GetPart(total: drag.Duration, step, steps: drag.Steps);
                var upToPreviousStep = GetPart(total: drag.Duration, step: step - 1, steps: drag.Steps);
                var pause = upToStep - upToPreviousStep;

                if (pause > 0)
                {
                    AddPause(sequence, duration: pause);
                }
            }

            // Rest over the end point so the application can mark the drop zone, then drop.
            AddPause(sequence, duration: ReleaseDelayMilliseconds);
            sequence.AddPointerUp(button: MouseActionModel.MouseButtons.Left);

            return sequence;
        }

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Refuse any driver other than the UIA driver, because only it moves the Windows cursor to an element.
            AssertDriver(driver: WebDriver);

            // Read where the drag starts: the element the rule names, or a screen point.
            var isSourceElement = !string.IsNullOrEmpty(pluginData.Rule.OnElement);
            var isStartPoint = TestPoint(pluginData, xName: "X", yName: "Y");

            // Read where the drag ends: a target element, a screen point, or an offset from the start.
            var target = pluginData.Parameters.Get(key: "Target", defaultValue: string.Empty);
            var isTarget = !string.IsNullOrEmpty(target);
            var isEndPoint = TestPoint(pluginData, xName: "TargetX", yName: "TargetY");
            var isOffset = TestPoint(pluginData, xName: "DeltaX", yName: "DeltaY");

            // Reject a rule that names no start or no end, or one end twice, before any element is searched.
            AssertStart(isSourceElement, isStartPoint);
            AssertEnd(isTarget, isEndPoint, isOffset);

            // Read the movement settings and both positions, so a bad value fails before the cursor moves.
            var steps = GetSteps(pluginData);
            var durationValue = pluginData.Parameters.Get(key: "Duration", defaultValue: string.Empty);
            var duration = GetDuration(value: durationValue, defaultValue: DefaultDurationMilliseconds);
            var sourcePosition = NewPosition(pluginData, alignmentName: "Alignment", prefix: string.Empty);
            var targetPosition = NewPosition(pluginData, alignmentName: "TargetAlignment", prefix: "Target");

            // Read every coordinate pair now, so a value that is not a whole number fails before the cursor moves;
            // a pair the rule does not set reads as zero and is not used.
            var startPoint = GetPoint(pluginData, xName: "X", yName: "Y");
            var endPoint = GetPoint(pluginData, xName: "TargetX", yName: "TargetY");
            var offset = GetPoint(pluginData, xName: "DeltaX", yName: "DeltaY");

            // Find the element to drag when the rule names one; a missing element throws the driver exception and
            // fails the rule. A drag from a screen point needs no element.
            var source = isSourceElement
                ? GetSource(plugin: this, pluginData)
                : null;

            // Ask the driver for the end point first. The call moves the cursor, which is harmless while no button
            // is down; a drag to a screen point or by offset needs no call.
            var end = isTarget
                ? GetTargetPoint(plugin: this, target, position: targetPosition)
                : default;

            // Ask the driver for the grab point last, which leaves the cursor on the source, where the drag starts.
            // A drag from a screen point starts there as written.
            var start = source != null
                ? MoveToElement(driver: WebDriver, elementId: source.Id, position: sourcePosition)
                : startPoint;

            // Place an end that is not an element: a screen point as written, or an offset from the grab point.
            if (isEndPoint)
            {
                end = endPoint;
            }
            else if (isOffset)
            {
                end = (start.X + offset.X, start.Y + offset.Y);
            }

            // Build the whole drag as one sequence of screen points and send it in one request.
            var drag = new DragModel
            {
                Duration = duration,
                End = end,
                Start = start,
                Steps = steps
            };
            var sequence = NewDragSequence(driver: WebDriver, drag);
            SendSequence(driver: WebDriver, sequence);

            // Return a new plugin response indicating successful execution.
            return this.NewPluginResponse();
        }

        // Adds one pointer move to a screen point, as the next tick of the sequence. The UIA driver places the
        // cursor on the point at once, so the move carries no duration.
        private static void AddMove(ActionSequence sequence, int x, int y)
        {
            // Describe an absolute move; the UIA driver reads viewport coordinates as screen pixels.
            var action = new MouseActionModel
            {
                Duration = 0,
                Origin = ActionOrigins.Viewport,
                Type = MouseActionModel.ActionTypes.PointerMove,
                X = x,
                Y = y
            };

            // Append the move as the next tick; nothing reaches the driver yet.
            sequence.AddAction(action);
        }

        // Adds a pause to the pointer source only. The UIA driver runs the whole pointer source before the keyboard
        // source, so a pause placed in both sources waits a second time after the drop.
        private static void AddPause(ActionSequence sequence, int duration)
        {
            // A pause written as a pointer action keeps the keyboard source at zero-length pauses, which the driver
            // skips.
            var action = new MouseActionModel
            {
                Duration = duration,
                Type = NullActionModel.ActionTypes.Pause
            };

            // Append the pause as the next tick; nothing reaches the driver yet.
            sequence.AddAction(action);
        }

        // Asserts that the plugin runs on the UIA driver, which is the only driver that answers the cursor calls
        // the drag depends on.
        private static void AssertDriver(IWebDriver driver)
        {
            // Accept the UIA driver and return before the rejection message is built.
            if (driver is IUser32Driver)
            {
                return;
            }

            // Point the flow author to the plugin that drags on web pages.
            var message = $"'{nameof(InvokeUser32DragAndDrop)}' runs only on the UIA driver. " +
                "Use 'InvokeDragAndDrop' to drag on a web page.";
            throw new InvalidOperationException(message);
        }

        // Asserts that the rule names exactly one end for the drag: a target element, a screen point, or an offset.
        private static void AssertEnd(bool isTarget, bool isEndPoint, bool isOffset)
        {
            // Count the ways the rule names the end; more than one is ambiguous, so none is guessed.
            var endCount = new[] { isTarget, isEndPoint, isOffset }.Count(isSet => isSet);

            if (endCount > 1)
            {
                var message = "Set only one end for the drag: 'Target', 'TargetX' and 'TargetY', " +
                    "or 'DeltaX' and 'DeltaY'.";
                throw new InvalidOperationException(message);
            }

            // A rule with no end has nowhere to drop the element.
            if (endCount == 0)
            {
                var message = "Set where the drag ends: 'Target' for an element, 'TargetX' and 'TargetY' for a " +
                    "screen point, or 'DeltaX' and 'DeltaY' for an offset.";
                throw new InvalidOperationException(message);
            }
        }

        // Asserts that the rule names exactly one start for the drag: the element in OnElement or a screen point.
        private static void AssertStart(bool isSourceElement, bool isStartPoint)
        {
            // A rule with both starts is ambiguous, so neither is guessed.
            if (isSourceElement && isStartPoint)
            {
                var message = "Set either 'OnElement' or 'X' and 'Y' for the start of the drag, not both.";
                throw new InvalidOperationException(message);
            }

            // A rule with no start has nothing to press on.
            if (!isSourceElement && !isStartPoint)
            {
                var message = "Set where the drag starts: 'OnElement' for an element, " +
                    "or 'X' and 'Y' for a screen point.";
                throw new InvalidOperationException(message);
            }
        }

        // Clears the input state after a failed send by releasing the left button. The UIA driver has no command
        // that releases all input, so a button release is sent on its own; a failure of the release itself is
        // ignored, because the rule already fails with the error of the send, which is the one the flow author needs.
        private static void ClearInputState(IWebDriver driver)
        {
            try
            {
                // Release the button the drag pressed, at the current cursor position.
                new ActionSequence(driver)
                    .AddPointerUp(button: MouseActionModel.MouseButtons.Left)
                    .Invoke();
            }
            catch (Exception)
            {
                // Nothing to do: the driver that rejected the drag may also reject the release.
            }
        }

        // Converts the duration text of a rule to whole milliseconds: a whole number of milliseconds, or a time span
        // written as hh:mm:ss or d.hh:mm:ss. A rule without a duration gets the default; anything else fails the
        // rule, because a silent zero hides a typing error in the flow.
        private static int GetDuration(string value, int defaultValue)
        {
            // Keep the default for a rule that sets no duration.
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            // Read whole milliseconds with the invariant culture, so a flow gives the same duration on every machine.
            var isNumber = int.TryParse(
                s: value,
                style: NumberStyles.Integer,
                provider: CultureInfo.InvariantCulture,
                result: out var milliseconds);
            var isMilliseconds = isNumber && milliseconds >= 0;

            if (isMilliseconds)
            {
                return milliseconds;
            }

            // Read a time span when the text is not a number; a span too long for the driver field is refused.
            var isTimeSpan = TimeSpan.TryParseExact(
                input: value,
                formats: TimeSpanFormats,
                formatProvider: CultureInfo.InvariantCulture,
                result: out var duration);
            var isInRange = isTimeSpan && duration >= TimeSpan.Zero && duration.TotalMilliseconds <= int.MaxValue;

            if (isInRange)
            {
                return (int)duration.TotalMilliseconds;
            }

            // Report the text as written, with the forms the rule may use.
            var message = $"Duration '{value}' is not valid. " +
                "Use a non-negative whole number of milliseconds or an hh:mm:ss or d.hh:mm:ss time span.";
            throw new InvalidOperationException(message);
        }

        // Gets a whole-number parameter of the rule, such as an offset; zero when the rule does not set it.
        private static int GetInteger(PluginDataModel pluginData, string name)
        {
            // Read the parameter text; a rule without it leaves the value at zero.
            var value = pluginData.Parameters.Get(key: name, defaultValue: string.Empty);

            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            // Parse with the invariant culture, so a flow gives the same number on every machine.
            var isInteger = int.TryParse(
                s: value,
                style: NumberStyles.Integer,
                provider: CultureInfo.InvariantCulture,
                result: out var number);

            if (isInteger)
            {
                return number;
            }

            // Report the parameter by name, because a rule sets several numbers.
            var message = $"Parameter '{name}' with value '{value}' is not a whole number.";
            throw new InvalidOperationException(message);
        }

        // Gets a pair of whole-number parameters, such as X and Y, as one point; a parameter the rule does not set
        // reads as zero, and text that is not a whole number fails the rule with the parameter's name.
        private static (int X, int Y) GetPoint(PluginDataModel pluginData, string xName, string yName)
        {
            return (GetInteger(pluginData, name: xName), GetInteger(pluginData, name: yName));
        }

        // Gets the rounded part of a total that falls on the steps up to the given one. The part of the last step is
        // the total itself, so the path ends exactly on the end point. The product is computed in double precision,
        // because a long duration times the step count can exceed an int.
        private static int GetPart(int total, int step, int steps)
        {
            var part = (double)total * step / steps;

            return (int)Math.Round(part, MidpointRounding.AwayFromZero);
        }

        // Gets the element to drag, which the rule names through OnElement and its locator. Called only when the rule
        // names one; a drag from a screen point has no element.
        private static IWebElement GetSource(PluginBase plugin, PluginDataModel pluginData)
        {
            // Find the element through the UIA driver; a named element that is missing throws here.
            var element = plugin.GetUser32Element(pluginData) as IWebElement;

            if (element != null)
            {
                return element;
            }

            // A rule without an element has nothing to drag.
            var message = "Set the element to drag in 'OnElement'.";
            throw new InvalidOperationException(message);
        }

        // Gets the number of moves between the press and the release, from 1 to MaximumSteps.
        private static int GetSteps(PluginDataModel pluginData)
        {
            // Read the step count; a rule without one gets the default.
            var value = pluginData.Parameters.Get(key: "Steps", defaultValue: string.Empty);

            if (string.IsNullOrEmpty(value))
            {
                return DefaultSteps;
            }

            // Accept a whole number in range only; zero steps release the element where it was pressed.
            var isNumber = int.TryParse(
                s: value,
                style: NumberStyles.Integer,
                provider: CultureInfo.InvariantCulture,
                result: out var steps);
            var isInRange = isNumber && steps >= 1 && steps <= MaximumSteps;

            if (isInRange)
            {
                return steps;
            }

            // Report the text as written, with the range the rule may use.
            var message = $"Steps '{value}' is not valid. Use a whole number from 1 to {MaximumSteps}.";
            throw new InvalidOperationException(message);
        }

        // Gets the screen point where the drag ends: the point of the target element that the target alignment and
        // offsets select. The target is an XPath, the one locator the User32 elements support; it is searched from
        // the root of the session, and the search waits for it like any other element of a rule. Getting the point
        // moves the cursor onto the target.
        private static (int X, int Y) GetTargetPoint(PluginBase plugin, string target, MousePositionInputModel position)
        {
            // Describe the target as a rule of its own, so the normal element search, with its timeout, finds it.
            var targetRule = new ActionRuleModel
            {
                Locator = Locators.Xpath,
                OnElement = target
            };

            // Search from the root, not from the source; a missing target throws the driver exception here.
            var element = plugin.GetElement(rule: targetRule, element: null);

            // Ask the driver for the point of the target, as it computes the point of the source.
            return MoveToElement(driver: plugin.WebDriver, elementId: element.Id, position);
        }

        // Moves the cursor to a point of an element through the UIA driver and returns that point in screen pixels.
        // The driver computes the point from the alignment and the offsets, in the same pixels its pointer actions
        // use, so the returned point can be used as a move target as is.
        private static (int X, int Y) MoveToElement(
            IWebDriver driver,
            string elementId,
            MousePositionInputModel position)
        {
            // Read the route of the driver call from the command table of the UIA driver client.
            var command = driver.Invoker.Commands[MoveToElementCommand];
            var session = driver.GetSession().OpaqueKey;
            var route = command.Route
                .Replace("$[session]", session)
                .Replace("$[element]", elementId);
            var requestUri = driver.Invoker.ServerAddress.AbsoluteUri.TrimEnd('/') + route;

            // Send the alignment and the offsets as the body of the request.
            var json = JsonSerializer.Serialize(position);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri)
            {
                Content = content
            };

            // Run the call synchronously, as the other User32 plugins do; the response body holds the point.
            using var response = HttpClient
                .SendAsync(request)
                .GetAwaiter()
                .GetResult();
            var body = response.Content
                .ReadAsStringAsync()
                .GetAwaiter()
                .GetResult();

            // Fail the rule with the response of the driver, which names what it rejected.
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(body);
            }

            // Read the point the driver moved the cursor to.
            using var document = JsonDocument.Parse(body);
            var x = document.RootElement.GetProperty("x").GetInt32();
            var y = document.RootElement.GetProperty("y").GetInt32();

            return (x, y);
        }

        // Creates the position the UIA driver computes a point from: an alignment inside the element and two pixel
        // offsets. The source reads Alignment, OffsetX, and OffsetY; the target reads the same names with the
        // Target prefix.
        private static MousePositionInputModel NewPosition(
            PluginDataModel pluginData,
            string alignmentName,
            string prefix)
        {
            return new MousePositionInputModel
            {
                Alignment = pluginData.Parameters.Get(key: alignmentName, defaultValue: DefaultAlignment),
                OffsetX = GetInteger(pluginData, name: prefix + "OffsetX"),
                OffsetY = GetInteger(pluginData, name: prefix + "OffsetY")
            };
        }

        // Sends the drag to the driver in one request. When the driver rejects it, the left button is released so
        // it does not stay pressed on the desktop, and the original failure is what the rule reports.
        private static void SendSequence(IWebDriver driver, ActionSequence sequence)
        {
            try
            {
                // Perform the press, the moves, and the release as one request.
                sequence.Invoke();
            }
            catch (Exception)
            {
                // Release the button the driver may hold after a drag that stopped half way.
                ClearInputState(driver);
                throw;
            }
        }

        // Tests whether the rule sets a pair of coordinates, such as X and Y or DeltaX and DeltaY. Either value
        // alone marks the pair as set; the missing one counts as zero.
        private static bool TestPoint(PluginDataModel pluginData, string xName, string yName)
        {
            // Read both parameters of the pair as text, so a value of zero still counts as set.
            var x = pluginData.Parameters.Get(key: xName, defaultValue: string.Empty);
            var y = pluginData.Parameters.Get(key: yName, defaultValue: string.Empty);

            return !string.IsNullOrEmpty(x) || !string.IsNullOrEmpty(y);
        }

        /// <summary>
        /// Holds what one drag needs once the rule is read: the grab point, the drop point, and the pace.
        /// </summary>
        /// <remarks>
        /// Both points are screen pixels as the UIA driver reports them; the model lives only while the plugin runs.
        /// </remarks>
        internal sealed class DragModel
        {
            /// <summary>
            /// Gets the total time, in milliseconds, of the moves between the press and the release.
            /// </summary>
            public int Duration { get; init; }

            /// <summary>
            /// Gets the screen point where the drag ends and the button is released.
            /// </summary>
            public (int X, int Y) End { get; init; }

            /// <summary>
            /// Gets the screen point where the button is pressed.
            /// </summary>
            public (int X, int Y) Start { get; init; }

            /// <summary>
            /// Gets the number of moves after the nudge; the last one lands on the end point.
            /// </summary>
            public int Steps { get; init; }
        }
    }
}
