using G4.Api;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.Actions;
using G4.Plugins.Ui.Actions.User32;
using G4.UnitTests.Framework;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;
using G4.WebDriver.Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeUser32DragAndDrop")]
    [TestCategory("UnitTest")]
    public class InvokeUser32DragAndDropTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeUser32DragAndDrop plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest resolves through the User32 resource namespace and satisfies G4 validation.
            AssertManifest<InvokeUser32DragAndDrop>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeUser32DragAndDrop plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin is registered and the factory creates it with a driver.
            AssertPlugin<InvokeUser32DragAndDrop>();
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32DragAndDrop fails with a message that points to " +
            "InvokeDragAndDrop when the session has no UIA driver.")]
        public void InvokeUser32DragAndDropWithoutUiaDriverTest()
        {
            // Arrange: request the test framework's null-driver mode to represent a session without the UIA driver.
            var capabilities = new Dictionary<string, object>
            {
                ["NullDriver"] = true
            };
            var ruleJson = JsonSerializer.Serialize(new { argument = "{{$ --DeltaX:10}}", onElement = "//positive" });

            // Act: run the plugin and capture the failure; the driver is checked before anything else.
            var exception = Assert.Throws<InvalidOperationException>(
                () => Invoke<InvokeUser32DragAndDrop>(ruleJson, capabilities));

            // Assert: the message names the driver the plugin needs and the plugin to use on web pages.
            Assert.Contains("runs only on the UIA driver", exception.Message);
            Assert.Contains("InvokeDragAndDrop", exception.Message);
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32DragAndDrop rejects a rule with two ends or no end, a " +
            "bad step count, a bad duration, or an offset that is not a whole number, before the cursor moves.")]
        #region *** Data Set ***
        [DataRow("{{$ --Target://positive --DeltaX:10}}", "Set only one end")]
        [DataRow("{{$ --Target://positive --TargetX:10}}", "Set only one end")]
        [DataRow("{{$ --TargetX:10 --TargetY:20 --DeltaY:5}}", "Set only one end")]
        [DataRow("{{$ --Steps:5}}", "Set where the drag ends")]
        [DataRow("{{$ --X:10 --Y:20 --DeltaX:10}}", "not both")]
        [DataRow("{{$ --TargetX:left}}", "is not a whole number")]
        [DataRow("{{$ --DeltaX:10 --Steps:0}}", "from 1 to 100")]
        [DataRow("{{$ --DeltaX:10 --Steps:101}}", "from 1 to 100")]
        [DataRow("{{$ --DeltaX:10 --Duration:-1}}", "is not valid")]
        [DataRow("{{$ --DeltaX:10 --Duration:soon}}", "is not valid")]
        [DataRow("{{$ --DeltaX:10 --OffsetX:left}}", "is not a whole number")]
        [DataRow("{{$ --Target://positive --TargetOffsetY:1.5}}", "is not a whole number")]
        #endregion
        public void InvokeUser32DragAndDropInvalidArgumentTest(string argument, string expected)
        {
            // Arrange: a rule on an element with one value the plugin cannot accept; the simulator acts as a UIA
            // driver, so the driver check passes and the argument checks run.
            var ruleJson = JsonSerializer.Serialize(new { argument, onElement = "//positive" });

            // Act: run the plugin and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<InvokeUser32DragAndDrop>(ruleJson));

            // Assert: the message names the problem, so the flow author can fix the rule.
            Assert.Contains(expected, exception.Message);
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32DragAndDrop fails with a clear message when the rule " +
            "names neither an element nor a screen point to start from.")]
        public void InvokeUser32DragAndDropMissingSourceTest()
        {
            // Arrange: a rule with an offset but without OnElement and without X and Y.
            var ruleJson = JsonSerializer.Serialize(new { argument = "{{$ --DeltaX:10 --DeltaY:0}}" });

            // Act: run the plugin and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<InvokeUser32DragAndDrop>(ruleJson));

            // Assert: the message names both ways to set the start.
            Assert.Contains("Set where the drag starts", exception.Message);
            Assert.Contains("OnElement", exception.Message);
            Assert.Contains("'X' and 'Y'", exception.Message);
        }

        [TestMethod(DisplayName = "Verify that InvokeUser32DragAndDrop drags from a screen point without an element, " +
            "to a screen point or by an offset.")]
        #region *** Data Set ***
        [DataRow("{{$ --X:300 --Y:200 --TargetX:640 --TargetY:420}}")]
        [DataRow("{{$ --X:300 --Y:200 --DeltaX:150 --DeltaY:-20}}")]
        [DataRow("{{$ --X:0 --TargetX:40}}")]
        #endregion
        public void InvokeUser32DragAndDropScreenPointTest(string argument)
        {
            // Arrange: a rule without OnElement, so no element is searched and no driver point is requested.
            var ruleJson = JsonSerializer.Serialize(new { argument });

            // Act: run the plugin on the simulator, which accepts the pointer sequence without acting on it.
            var response = Invoke<InvokeUser32DragAndDrop>(ruleJson).Response;

            // Assert: a drag between screen points completes without plugin or driver exceptions.
            Assert.IsEmpty(response.Exceptions);
        }

        [TestMethod(DisplayName = "Verify that the UIA drag sequence moves through absolute screen points from the " +
            "grab point to the drop point, over the given duration, with every pause on the pointer source.")]
        #region *** Data Set ***
        [DataRow(100, 200, 400, 260, 10, 300)]
        [DataRow(500, 500, 380, 520, 7, 1000)]
        [DataRow(10, 10, 12, 10, 5, 0)]
        [DataRow(0, 0, 0, 0, 1, 0)]
        #endregion
        public void NewDragSequenceTest(int startX, int startY, int endX, int endY, int steps, int duration)
        {
            // Arrange: a simulator driver stands in for the UIA driver; the sequence is built, not sent.
            using var driver = new SimulatorDriver();
            var drag = new InvokeUser32DragAndDrop.DragModel
            {
                Duration = duration,
                End = (endX, endY),
                Start = (startX, startY),
                Steps = steps
            };

            // Act: build the drag between the two screen points.
            var sequence = InvokeUser32DragAndDrop.NewDragSequence(driver, drag);
            var sources = sequence.GetInputSources().ToArray();
            var actions = sources[0].Actions.Cast<MouseActionModel>().ToArray();

            // Assert: the drag starts with an absolute move to the grab point, a left press, and a 100 ms hold.
            AssertMove(action: actions[0], x: startX, y: startY);
            AssertButton(action: actions[1], type: MouseActionModel.ActionTypes.PointerDown);
            AssertPause(action: actions[2], expected: 100);

            // Assert: the nudge and the steps are absolute moves, and the last one is the drop point itself.
            var stepActions = actions[3..^2];
            var moves = stepActions.Where(action => action.Type == MouseActionModel.ActionTypes.PointerMove).ToArray();
            Assert.HasCount(steps + 1, moves);
            AssertMove(action: moves[^1], x: endX, y: endY);

            // Assert: the pauses between the moves add up to the duration.
            var stepPauses = stepActions.Where(action => action.Type == NullActionModel.ActionTypes.Pause);
            Assert.AreEqual(duration, stepPauses.Sum(pause => pause.Duration ?? 0));

            // Assert: the drag rests 50 ms over the drop point and releases the left button.
            AssertPause(action: actions[^2], expected: 50);
            AssertButton(action: actions[^1], type: MouseActionModel.ActionTypes.PointerUp);

            // Assert: the keyboard source holds only zero-length pauses, so the UIA driver, which runs the
            // keyboard source after the pointer source, adds no wait after the drop.
            Assert.IsTrue(sources[1].Actions.All(action => (action.Duration ?? 0) == 0));
        }

        [TestMethod(DisplayName = "Verify on a live UIA driver that InvokeUser32DragAndDrop moves a list item into " +
            "another list through Windows drag and drop.")]
        [TestCategory("UiaDriver")]
        [DoNotParallelize]
        [TestCategory("LocalOnly")]
        public void InvokeUser32DragAndDropLiveListTest()
        {
            // Arrange: drag the Beta item onto the target list, then focus Beta inside the target list. The focus
            // rule waits for the item there and fails the flow when the drop did not happen.
            var rules = new[]
            {
                NewLiveRule(
                    pluginName: nameof(InvokeUser32DragAndDrop),
                    argument: "{{$ --Target://List[@AutomationId='TargetList']}}",
                    onElement: "//List[@AutomationId='SourceList']//ListItem[@Name='Beta']"),
                NewLiveRule(
                    pluginName: "SetUser32Focus",
                    argument: string.Empty,
                    onElement: "//List[@AutomationId='TargetList']//ListItem[@Name='Beta']")
            };

            // Act and Assert: the flow runs on the live application without an error.
            AssertLiveFlow(rules);
        }

        [TestMethod(DisplayName = "Verify on a live UIA driver that InvokeUser32DragAndDrop moves a thumb that " +
            "follows the captured mouse by an offset.")]
        [TestCategory("UiaDriver")]
        [DoNotParallelize]
        [TestCategory("LocalOnly")]
        public void InvokeUser32DragAndDropLiveOffsetTest()
        {
            // Arrange: drag the thumb 200 screen pixels to the right; the application names its status text
            // 'Thumb moved' once the thumb has moved more than 150 pixels.
            var rules = new[]
            {
                NewLiveRule(
                    pluginName: nameof(InvokeUser32DragAndDrop),
                    argument: "{{$ --DeltaX:200 --DeltaY:0 --Steps:20 --Duration:600}}",
                    onElement: "//Thumb[@AutomationId='DragThumb']"),
                NewLiveRule(
                    pluginName: "SetUser32Focus",
                    argument: string.Empty,
                    onElement: "//Text[@Name='Thumb moved']")
            };

            // Act and Assert: the flow runs on the live application without an error.
            AssertLiveFlow(rules);
        }

        // Asserts that an action presses or releases the left button.
        private static void AssertButton(MouseActionModel action, string type)
        {
            // Assert: the action is a pointer action of the expected type on the left button.
            Assert.AreEqual(type, action.Type);
            Assert.AreEqual(MouseActionModel.MouseButtons.Left, action.Button);
        }

        // Asserts that an action moves the cursor to an absolute screen point at once.
        private static void AssertMove(MouseActionModel action, int x, int y)
        {
            // Assert: the move is measured from the viewport, which the UIA driver reads as screen pixels.
            Assert.AreEqual(MouseActionModel.ActionTypes.PointerMove, action.Type);
            Assert.AreEqual(ActionOrigins.Viewport, action.Origin);

            // Assert: the move lands on the point and takes no time.
            Assert.AreEqual(x, action.X);
            Assert.AreEqual(y, action.Y);
            Assert.AreEqual(0, action.Duration);
        }

        // Asserts that an action is a pause of the pointer source with the expected length.
        private static void AssertPause(MouseActionModel action, int expected)
        {
            // Assert: the pause is a pointer action, so the UIA driver waits while the pointer source runs.
            Assert.AreEqual(NullActionModel.ActionTypes.Pause, action.Type);
            Assert.AreEqual(expected, action.Duration);
        }

        // Runs rules on the live UIA driver against the drag-and-drop test application and asserts that no rule
        // failed. The driver server address and the application path come from the run settings, so the test
        // states what it needs instead of guessing a machine layout. The test starts the application itself and
        // waits for its window, then lets the driver mount the running process: the driver looks for the window
        // once, right after it starts a process, which is too early for a WPF window.
        private void AssertLiveFlow(G4RuleModelBase[] rules)
        {
            // Arrange: read the live environment; without it the test cannot run and says so.
            var server = $"{TestContext.Properties["Uia.DriverServer"]}";
            var application = $"{TestContext.Properties["Uia.DragAndDropApplication"]}";

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(application))
            {
                Assert.Inconclusive("Set Uia.DriverServer and Uia.DragAndDropApplication in the run settings.");
            }

            // Arrange: start the application and wait until its main window exists.
            using var process = Process.Start(fileName: application);

            try
            {
                WaitForMainWindow(process);

                // Arrange: mount the running process by its name. The driver matches a process whose name the
                // value contains, so the bare name is passed and not the full path.
                var capabilities = new Dictionary<string, object>
                {
                    ["browserName"] = "Uia",
                    ["uia:options"] = new Dictionary<string, object>
                    {
                        ["app"] = process.ProcessName,
                        ["mount"] = true
                    }
                };

                // Arrange: end the flow with CloseBrowser so the engine deletes the driver session; the engine runs
                // every rule even after one fails, so a failed flow does not leave a session on the driver either.
                var closeRule = new ActionRuleModel
                {
                    PluginName = nameof(CloseBrowser)
                };

                // Arrange: wrap the rules in a one-stage, one-job automation that targets the live UIA driver server.
                var automation = new G4AutomationModel
                {
                    Authentication = new AuthenticationModel
                    {
                        Username = $"{TestContext.Properties["G4.Username"]}"
                    },
                    DriverParameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["Capabilities"] = new CapabilitiesModel
                        {
                            AlwaysMatch = capabilities
                        },
                        ["Driver"] = "UiaDriver",
                        ["DriverBinaries"] = server
                    },
                    Stages = [new G4StageModel { Jobs = [new G4JobModel { Rules = [.. rules, closeRule] }] }]
                }.Initialize();

                // Act: run the flow on the live desktop.
                var response = new G4Client().Automation.Invoke(automation);
                var exceptions = response
                    .SelectMany(automationResponse => automationResponse.Value.Sessions.Values)
                    .SelectMany(session => session.ResponseData.Exceptions ?? [])
                    .Select(exception => $"{exception.PluginName}: {exception.Exception?.Message}")
                    .ToArray();

                // Assert: no rule failed; the messages name the rule that did.
                Assert.IsEmpty(exceptions, string.Join(Environment.NewLine, exceptions));
            }
            finally
            {
                // Cleanup: close the application, so the next live test starts it with its initial state.
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
        }

        // Creates one rule of a live flow.
        private static ActionRuleModel NewLiveRule(string pluginName, string argument, string onElement)
        {
            return new ActionRuleModel
            {
                Argument = argument,
                OnElement = onElement,
                PluginName = pluginName
            };
        }

        // Waits up to thirty seconds for the main window of a started process. A WPF application shows its window a
        // moment after the process starts, and its first start after a build takes longer.
        private static void WaitForMainWindow(Process process)
        {
            // Poll the process; the window handle stays zero until the window is created.
            var deadline = DateTime.UtcNow.AddSeconds(30);

            while (process.MainWindowHandle == IntPtr.Zero && DateTime.UtcNow < deadline)
            {
                Thread.Sleep(millisecondsTimeout: 100);
                process.Refresh();
            }

            // Fail with a clear message rather than letting the driver report a missing root element.
            if (process.MainWindowHandle == IntPtr.Zero)
            {
                Assert.Fail("The drag-and-drop test application did not show its main window within thirty seconds.");
            }
        }
    }
}
