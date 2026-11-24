using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;

using System;
using System.Globalization;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeDragAndDrop)}.json")]
    public class InvokeDragAndDrop(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The total time, in milliseconds, of the moves between the press and the release when the rule sets none.
        private const int DefaultDurationMilliseconds = 300;

        // The number of moves between the source and the target when the rule sets none. ChromeDriver sends one
        // mouse move per move action, and a page that waits for the pointer to cross a drag threshold ignores one
        // long jump, so the path is built from several short moves.
        private const int DefaultSteps = 10;

        // The time, in milliseconds, the button stays down before the first move, so the page can start its drag.
        private const int HoldMilliseconds = 100;

        // The largest number of moves a rule may ask for; it keeps the one request to the driver small.
        private const int MaximumSteps = 100;

        // The distance, in pixels, of the short move right after the press. It crosses the drag threshold of most
        // pages before the longer moves begin.
        private const int NudgePixels = 5;

        // The time, in milliseconds, the pointer rests over the target before the release, so the page can mark
        // the drop zone before the drop arrives.
        private const int ReleaseDelayMilliseconds = 50;

        // Lists the time-span forms a duration may use: hh:mm:ss, or d.hh:mm:ss with whole days first.
        private static readonly string[] TimeSpanFormats = [@"hh\:mm\:ss", @"d\.hh\:mm\:ss"];

        /// <summary>
        /// Gets the distance, in pixels, from the center of the source element to the center of the target element.
        /// </summary>
        /// <param name="sourceRect">The rectangle of the element being dragged, as the driver reports it.</param>
        /// <param name="targetRect">The rectangle of the element to drop on, as the driver reports it.</param>
        /// <returns>The horizontal and vertical distance between the two centers, rounded to whole pixels.</returns>
        /// <remarks>
        /// Both rectangles come from the same page coordinates, so the distance holds whatever the scroll position.
        /// A missing rectangle value counts as zero.
        /// </remarks>
        internal static (int DeltaX, int DeltaY) GetDistance(RectModel sourceRect, RectModel targetRect)
        {
            // Subtract the centers on each axis; a pointer move takes whole pixels, so the difference is rounded.
            var distanceX = GetCenter(start: targetRect.X, size: targetRect.Width)
                - GetCenter(start: sourceRect.X, size: sourceRect.Width);
            var distanceY = GetCenter(start: targetRect.Y, size: targetRect.Height)
                - GetCenter(start: sourceRect.Y, size: sourceRect.Height);

            var deltaX = (int)Math.Round(distanceX, MidpointRounding.AwayFromZero);
            var deltaY = (int)Math.Round(distanceY, MidpointRounding.AwayFromZero);

            return (deltaX, deltaY);

            // Gets the center of a span on one axis; a missing value counts as zero, although a driver that reports
            // a rectangle always sets all four values.
            static double GetCenter(double? start, double? size)
            {
                return (start ?? 0) + ((size ?? 0) / 2);
            }
        }

        /// <summary>
        /// Builds the whole drag as one sequence: move to the source center, press, hold, nudge, move in steps,
        /// rest over the end point, and release.
        /// </summary>
        /// <param name="driver">The driver the sequence is sent to; nothing is sent here.</param>
        /// <param name="drag">The elements, the path, and the pace of the drag, as read from the rule.</param>
        /// <returns>The sequence, ready to be sent in one request.</returns>
        /// <remarks>
        /// The moves between the press and the release are relative, so the path holds whatever the scroll position.
        /// A drag with a target ends with a move to the target itself, which lands on its center even if the layout
        /// shifted while the page dragged.
        /// </remarks>
        internal static ActionSequence NewDragSequence(IWebDriver driver, DragModel drag)
        {
            // Start an empty sequence bound to the driver; the actions are only collected here, not sent.
            var sequence = new ActionSequence(driver);

            // Press the left button on the center of the source, and hold it so the page can start its drag.
            AddMove(sequence, element: drag.Source);
            sequence.AddPointerDown(button: MouseActionModel.MouseButtons.Left);
            sequence.AddPauseAction(duration: HoldMilliseconds);

            // Nudge toward the end point, so the pointer crosses the drag threshold of the page at once. A path
            // shorter than the nudge moves only as far as the path itself.
            var nudgeX = Math.Sign(drag.DeltaX) * Math.Min(NudgePixels, Math.Abs(drag.DeltaX));
            var nudgeY = Math.Sign(drag.DeltaY) * Math.Min(NudgePixels, Math.Abs(drag.DeltaY));
            AddMove(sequence, x: nudgeX, y: nudgeY);

            // Cover the rest of the path in equal steps, each followed by its share of the duration.
            var remainingX = drag.DeltaX - nudgeX;
            var remainingY = drag.DeltaY - nudgeY;

            for (var step = 1; step <= drag.Steps; step++)
            {
                // Move by this step's share; the shares add up to the whole path, so no pixel is lost to rounding.
                var x = GetStepShare(total: remainingX, step, steps: drag.Steps);
                var y = GetStepShare(total: remainingY, step, steps: drag.Steps);
                AddMove(sequence, x, y);

                // Wait for this step's share of the duration; a zero share adds no pause.
                var pause = GetStepShare(total: drag.Duration, step, steps: drag.Steps);

                if (pause > 0)
                {
                    sequence.AddPauseAction(duration: pause);
                }
            }

            // Land on the target center itself, which also corrects a target that moved while the page dragged.
            if (drag.Target != null)
            {
                AddMove(sequence, element: drag.Target);
            }

            // Rest over the end point so the page can mark the drop zone, then drop.
            sequence.AddPauseAction(duration: ReleaseDelayMilliseconds);
            sequence.AddPointerUp(button: MouseActionModel.MouseButtons.Left);

            return sequence;
        }

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read where the drag ends: a target element found by its locator, or an offset from the source.
            var target = pluginData.Parameters.Get(key: "Target", defaultValue: string.Empty);
            var isTarget = !string.IsNullOrEmpty(target);
            var isOffset = TestOffset(pluginData);

            // Reject a rule that names both ends or neither, before any element is searched.
            AssertEnd(isTarget, isOffset);

            // Read the movement settings, so a bad value fails before the driver is asked for anything.
            var steps = GetSteps(pluginData);
            var durationValue = pluginData.Parameters.Get(key: "Duration", defaultValue: string.Empty);
            var duration = GetDuration(value: durationValue, defaultValue: DefaultDurationMilliseconds);

            // Find the element to drag; a missing element throws the driver exception and fails the rule.
            var source = GetSource(plugin: this, pluginData);

            // Find the target element when the rule names one; a drag by offset has none.
            var targetElement = isTarget
                ? GetTarget(plugin: this, pluginData, target)
                : null;

            // Measure the path: the distance between the two element centers, or the offset the rule sets.
            var (deltaX, deltaY) = targetElement != null
                ? GetDistance(sourceRect: source.Rect, targetRect: targetElement.Rect)
                : (GetInteger(pluginData, name: "DeltaX"), GetInteger(pluginData, name: "DeltaY"));

            // Build the whole drag as one sequence: press on the source, move in steps, release over the end.
            var drag = new DragModel
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                Duration = duration,
                Source = source,
                Steps = steps,
                Target = targetElement
            };
            var sequence = NewDragSequence(driver: WebDriver, drag);

            // Send the drag in one request, so the press, the moves, and the release reach the page in order.
            SendSequence(sequence);

            // Return a new plugin response indicating successful execution.
            return this.NewPluginResponse();
        }

        // Adds one pointer move, measured from the current pointer position, as the next tick of the sequence.
        // The move takes no time; the pause that follows it sets the pace of the drag.
        private static void AddMove(ActionSequence sequence, int x, int y)
        {
            // Describe a relative move, which stays correct when the page is scrolled.
            var action = new MouseActionModel
            {
                Duration = 0,
                Origin = ActionOrigins.Pointer,
                Type = MouseActionModel.ActionTypes.PointerMove,
                X = x,
                Y = y
            };

            // Append the move as the next tick; nothing reaches the driver yet.
            sequence.AddAction(action);
        }

        // Adds one pointer move to the center of an element, as the next tick of the sequence. The driver measures
        // the element when the tick runs, so the move lands on the element even if the layout shifted.
        private static void AddMove(ActionSequence sequence, IWebElement element)
        {
            // Describe a move with the element as its origin and no offset, which is the element center.
            var action = new MouseActionModel
            {
                Duration = 0,
                Origin = element.ConvertToDictionary(),
                Type = MouseActionModel.ActionTypes.PointerMove,
                X = 0,
                Y = 0
            };

            // Append the move as the next tick; nothing reaches the driver yet.
            sequence.AddAction(action);
        }

        // Asserts that the rule names exactly one end for the drag: a target element or an offset.
        private static void AssertEnd(bool isTarget, bool isOffset)
        {
            // A rule with both ends is ambiguous, so neither is guessed.
            if (isTarget && isOffset)
            {
                var message = "Set either 'Target' or 'DeltaX' and 'DeltaY', not both.";
                throw new InvalidOperationException(message);
            }

            // A rule with no end has nowhere to drop the element.
            if (!isTarget && !isOffset)
            {
                var message = "Set where the drag ends: 'Target' for an element, " +
                    "or 'DeltaX' and 'DeltaY' for an offset.";
                throw new InvalidOperationException(message);
            }
        }

        // Clears the input state of the driver after a failed send. A failure of the clearing itself is ignored,
        // because the rule already fails with the error of the send, which is the one the flow author needs.
        private static void ClearInputState(ActionSequence sequence)
        {
            try
            {
                // Clearing the sequence asks the driver to release the button the drag pressed.
                sequence.ClearActions();
            }
            catch (Exception)
            {
                // Nothing to do: the driver that rejected the sequence may also reject the release.
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

        // Gets the element to drag: the element the rule names through OnElement, or the element it inherited,
        // for example the current element of a for-each loop.
        private static IWebElement GetSource(PluginBase plugin, PluginDataModel pluginData)
        {
            // Find the named element or keep the inherited one; a named element that is missing throws here.
            var element = plugin.GetElement(rule: pluginData.Rule, element: pluginData.Element);

            if (element != null)
            {
                return element;
            }

            // A rule without an element has nothing to drag.
            var message = "Set the element to drag in 'OnElement'.";
            throw new InvalidOperationException(message);
        }

        // Gets the share of a total that falls on one step, rounded to whole units. Each step takes the part up to
        // itself minus the part up to the step before, so the shares of all steps add up to the total exactly.
        private static int GetStepShare(int total, int step, int steps)
        {
            // Take the rounded part of the total up to this step and up to the step before it.
            var upToStep = GetPart(total, step, steps);
            var upToPreviousStep = GetPart(total, step: step - 1, steps);

            return upToStep - upToPreviousStep;

            // Gets the rounded part of a total that falls on the steps up to the given one. The product is computed
            // in double precision, because a long duration times the step count can exceed an int.
            static int GetPart(int total, int step, int steps)
            {
                var part = (double)total * step / steps;

                return (int)Math.Round(part, MidpointRounding.AwayFromZero);
            }
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

        // Gets the element where the drag ends. The target is searched in the whole page with its own locator,
        // and the search waits for it like any other element of a rule.
        private static IWebElement GetTarget(PluginBase plugin, PluginDataModel pluginData, string target)
        {
            // Describe the target as a rule of its own, so the normal element search, with its timeout, finds it.
            var targetRule = new ActionRuleModel
            {
                Locator = pluginData.Parameters.Get(key: "TargetLocator", defaultValue: Locators.Xpath),
                OnElement = target
            };

            // Search from the page, not from the source; a missing target throws the driver exception here.
            return plugin.GetElement(rule: targetRule, element: null);
        }

        // Sends the drag to the driver in one request. When the driver rejects it, the input state is cleared so
        // the button does not stay pressed, and the original failure is what the rule reports.
        private static void SendSequence(ActionSequence sequence)
        {
            try
            {
                // Perform the press, the moves, and the release as one request.
                sequence.Invoke();
            }
            catch (Exception)
            {
                // Release the button the driver may hold after a drag that stopped half way.
                ClearInputState(sequence);
                throw;
            }
        }

        // Tests whether the rule drags by an offset, which it does when it sets DeltaX, DeltaY, or both.
        private static bool TestOffset(PluginDataModel pluginData)
        {
            // Read both offset parameters; either one alone marks a drag by offset.
            var deltaX = pluginData.Parameters.Get(key: "DeltaX", defaultValue: string.Empty);
            var deltaY = pluginData.Parameters.Get(key: "DeltaY", defaultValue: string.Empty);

            return !string.IsNullOrEmpty(deltaX) || !string.IsNullOrEmpty(deltaY);
        }

        /// <summary>
        /// Holds what one drag needs once the rule is read: the elements, the path, and its pace.
        /// </summary>
        /// <remarks>
        /// It exists so the sequence builder takes one argument instead of six; it lives only while the plugin runs.
        /// </remarks>
        internal sealed class DragModel
        {
            /// <summary>
            /// Gets the distance, in pixels, from the source center to the end point on the horizontal axis.
            /// </summary>
            public int DeltaX { get; init; }

            /// <summary>
            /// Gets the distance, in pixels, from the source center to the end point on the vertical axis.
            /// </summary>
            public int DeltaY { get; init; }

            /// <summary>
            /// Gets the total time, in milliseconds, of the moves between the press and the release.
            /// </summary>
            public int Duration { get; init; }

            /// <summary>
            /// Gets the element the drag starts on.
            /// </summary>
            public IWebElement Source { get; init; }

            /// <summary>
            /// Gets the number of moves between the press and the release.
            /// </summary>
            public int Steps { get; init; }

            /// <summary>
            /// Gets the element the drag ends on.
            /// </summary>
            /// <remarks>
            /// It is <see langword="null"/> for a drag by offset, which ends where the path ends.
            /// </remarks>
            public IWebElement Target { get; init; }
        }
    }
}
