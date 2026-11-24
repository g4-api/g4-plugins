using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;
using G4.WebDriver.Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;
using System.Text.Json;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeDragAndDrop")]
    [TestCategory("UnitTest")]
    public class InvokeDragAndDropTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeDragAndDrop plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest matches the plugin key and carries a summary, a description and examples.
            AssertManifest<InvokeDragAndDrop>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeDragAndDrop plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin is registered and the factory creates it with a driver.
            AssertPlugin<InvokeDragAndDrop>();
        }

        [TestMethod(DisplayName = "Verify that InvokeDragAndDrop drags an element onto a target element or by an " +
            "offset and reports no error.")]
        #region *** Data Set ***
        [DataRow("{{$ --Target://positive}}")]
        [DataRow("{{$ --Target://positive --TargetLocator:Xpath --Steps:3 --Duration:90}}")]
        [DataRow("{{$ --DeltaX:120 --DeltaY:0}}")]
        [DataRow("{{$ --DeltaY:-40 --Steps:1 --Duration:00:00:01}}")]
        #endregion
        public void InvokeDragAndDropTest(string argument)
        {
            // Arrange: the rule drags the '//positive' element, which the simulator driver always finds.
            var ruleJson = JsonSerializer.Serialize(new { argument, onElement = "//positive" });

            // Act: run the plugin; the simulator driver accepts the sequence without acting on it.
            var response = Invoke<InvokeDragAndDrop>(ruleJson).Response;

            // Assert: a valid drag completes without plugin or driver exceptions.
            Assert.IsEmpty(response.Exceptions);
        }

        [TestMethod(DisplayName = "Verify that InvokeDragAndDrop rejects a rule with both ends or no end, a bad step " +
            "count, a bad duration, or an offset that is not a whole number, before anything is sent.")]
        #region *** Data Set ***
        [DataRow("{{$ --Target://positive --DeltaX:10}}", "not both")]
        [DataRow("{{$ --Steps:5}}", "Set where the drag ends")]
        [DataRow("{{$ --DeltaX:10 --Steps:0}}", "from 1 to 100")]
        [DataRow("{{$ --DeltaX:10 --Steps:101}}", "from 1 to 100")]
        [DataRow("{{$ --DeltaX:10 --Steps:many}}", "from 1 to 100")]
        [DataRow("{{$ --DeltaX:10 --Duration:-1}}", "is not valid")]
        [DataRow("{{$ --DeltaX:10 --Duration:soon}}", "is not valid")]
        [DataRow("{{$ --DeltaX:1.5}}", "is not a whole number")]
        #endregion
        public void InvokeDragAndDropInvalidArgumentTest(string argument, string expected)
        {
            // Arrange: a rule on a found element with one value the plugin cannot accept.
            var ruleJson = JsonSerializer.Serialize(new { argument, onElement = "//positive" });

            // Act: run the plugin and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<InvokeDragAndDrop>(ruleJson));

            // Assert: the message names the problem, so the flow author can fix the rule.
            Assert.Contains(expected, exception.Message);
        }

        [TestMethod(DisplayName = "Verify that InvokeDragAndDrop fails with a clear message when the rule names no " +
            "element to drag.")]
        public void InvokeDragAndDropMissingSourceTest()
        {
            // Arrange: a rule with a target but without OnElement, outside any loop.
            var ruleJson = JsonSerializer.Serialize(new { argument = "{{$ --Target://positive}}" });

            // Act: run the plugin and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<InvokeDragAndDrop>(ruleJson));

            // Assert: the message tells the flow author which property is missing.
            Assert.Contains("OnElement", exception.Message);
        }

        [TestMethod(DisplayName = "Verify that InvokeDragAndDrop fails with the driver error when the target " +
            "element is not found.")]
        public void InvokeDragAndDropMissingTargetTest()
        {
            // Arrange: the target names an element the simulator driver never finds.
            const string Argument = "{{$ --Target://none}}";
            var ruleJson = JsonSerializer.Serialize(new { argument = Argument, onElement = "//positive" });

            // Act and Assert: the target search waits like any element search and ends with the driver timeout.
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<InvokeDragAndDrop>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that InvokeDragAndDrop measures the distance between the centers of the " +
            "source and the target rectangles, rounded to whole pixels.")]
        #region *** Data Set ***
        [DataRow(0.0, 0.0, 10.0, 10.0, 100.0, 0.0, 10.0, 10.0, 100, 0)]
        [DataRow(10.0, 20.0, 40.0, 20.0, 10.0, 220.0, 40.0, 60.0, 0, 220)]
        [DataRow(300.0, 300.0, 50.0, 50.0, 20.5, 40.0, 30.0, 30.0, -290, -270)]
        [DataRow(0.0, 0.0, 11.0, 11.0, 0.0, 0.0, 10.0, 10.0, -1, -1)]
        #endregion
        public void GetDistanceTest(
            double sourceX,
            double sourceY,
            double sourceWidth,
            double sourceHeight,
            double targetX,
            double targetY,
            double targetWidth,
            double targetHeight,
            int expectedX,
            int expectedY)
        {
            // Arrange: two rectangles as a driver reports them, in page coordinates.
            var sourceRect = new RectModel { Height = sourceHeight, Width = sourceWidth, X = sourceX, Y = sourceY };
            var targetRect = new RectModel { Height = targetHeight, Width = targetWidth, X = targetX, Y = targetY };

            // Act: measure the path from center to center.
            var (deltaX, deltaY) = InvokeDragAndDrop.GetDistance(sourceRect, targetRect);

            // Assert: the distance is the difference of the centers, rounded away from zero at the half pixel.
            Assert.AreEqual(expectedX, deltaX);
            Assert.AreEqual(expectedY, deltaY);
        }

        [TestMethod(DisplayName = "Verify that the drag sequence presses on the source, nudges, moves the whole " +
            "offset in the given steps over the given duration, and releases without a final element move.")]
        #region *** Data Set ***
        [DataRow(120, 0, 10, 300)]
        [DataRow(-250, 80, 7, 1000)]
        [DataRow(3, -2, 5, 0)]
        [DataRow(0, 0, 1, 0)]
        [DataRow(1001, 1, 100, 7)]
        #endregion
        public void NewDragSequenceOffsetTest(int deltaX, int deltaY, int steps, int duration)
        {
            // Arrange: a drag by offset from a simulator element.
            using var driver = new SimulatorDriver();
            var source = driver.FindElement(By.Xpath("//positive"));
            var drag = new InvokeDragAndDrop.DragModel
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                Duration = duration,
                Source = source,
                Steps = steps
            };

            // Act: build the sequence; nothing is sent.
            var actions = GetPointerActions(sequence: InvokeDragAndDrop.NewDragSequence(driver, drag));

            // Assert: the drag starts with a move to the source center, a left press, and a hold of 100 ms.
            AssertElementMove(action: actions[0], element: source);
            AssertButton(action: actions[1], type: MouseActionModel.ActionTypes.PointerDown);
            Assert.AreEqual(100, ((NullActionModel)actions[2]).Duration);

            // Assert: the nudge and the steps are relative moves that add up to the whole offset.
            var moves = GetRelativeMoves(actions);
            Assert.HasCount(steps + 1, moves);
            Assert.AreEqual(deltaX, moves.Sum(move => move.X));
            Assert.AreEqual(deltaY, moves.Sum(move => move.Y));

            // Assert: the pauses between the moves add up to the duration, and a zero share adds no pause.
            Assert.AreEqual(duration, GetStepPauses(actions).Sum());
            Assert.IsTrue(GetStepPauses(actions).All(pause => pause > 0));

            // Assert: a drag by offset has no final element move; it rests 50 ms and releases the left button.
            var elementMoves = actions.OfType<MouseActionModel>().Count(TestElementMove);
            Assert.AreEqual(1, elementMoves);
            Assert.AreEqual(50, ((NullActionModel)actions[^2]).Duration);
            AssertButton(action: actions[^1], type: MouseActionModel.ActionTypes.PointerUp);
        }

        [TestMethod(DisplayName = "Verify that the drag sequence nudges at most five pixels toward the end point " +
            "on each axis, and only as far as the path when it is shorter.")]
        #region *** Data Set ***
        [DataRow(120, -60, 5, -5)]
        [DataRow(3, 0, 3, 0)]
        [DataRow(-2, 40, -2, 5)]
        [DataRow(0, 0, 0, 0)]
        #endregion
        public void NewDragSequenceNudgeTest(int deltaX, int deltaY, int nudgeX, int nudgeY)
        {
            // Arrange: a drag by offset over the default step count.
            using var driver = new SimulatorDriver();
            var drag = new InvokeDragAndDrop.DragModel
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                Duration = 300,
                Source = driver.FindElement(By.Xpath("//positive")),
                Steps = 10
            };

            // Act: build the sequence and read its first relative move, which is the nudge.
            var sequence = InvokeDragAndDrop.NewDragSequence(driver, drag);
            var nudge = GetRelativeMoves(actions: GetPointerActions(sequence))[0];

            // Assert: the nudge points toward the end point and never overshoots a short path.
            Assert.AreEqual(nudgeX, nudge.X);
            Assert.AreEqual(nudgeY, nudge.Y);
        }

        [TestMethod(DisplayName = "Verify that a drag to a target ends with a move to the target element itself " +
            "before the release.")]
        public void NewDragSequenceTargetTest()
        {
            // Arrange: a drag between two simulator elements, with a measured path.
            using var driver = new SimulatorDriver();
            var source = driver.FindElement(By.Xpath("//positive"));
            var target = driver.FindElement(By.Xpath("//positive"));
            var drag = new InvokeDragAndDrop.DragModel
            {
                DeltaX = 140,
                DeltaY = 35,
                Duration = 300,
                Source = source,
                Steps = 10,
                Target = target
            };

            // Act: build the sequence; nothing is sent.
            var actions = GetPointerActions(sequence: InvokeDragAndDrop.NewDragSequence(driver, drag));

            // Assert: the relative moves still cover the measured path.
            var moves = GetRelativeMoves(actions);
            Assert.AreEqual(140, moves.Sum(move => move.X));
            Assert.AreEqual(35, moves.Sum(move => move.Y));

            // Assert: the last move lands on the target element, then the pointer rests and releases.
            AssertElementMove(action: actions[^3], element: target);
            Assert.AreEqual(50, ((NullActionModel)actions[^2]).Duration);
            AssertButton(action: actions[^1], type: MouseActionModel.ActionTypes.PointerUp);
        }

        // Asserts that an action presses or releases the left button.
        private static void AssertButton(ActionModelBase action, string type)
        {
            // Assert: the action is a pointer action of the expected type on the left button.
            var pointerAction = (MouseActionModel)action;
            Assert.AreEqual(type, pointerAction.Type);
            Assert.AreEqual(MouseActionModel.MouseButtons.Left, pointerAction.Button);
        }

        // Asserts that an action moves the pointer to the center of the given element, with no offset and no time.
        private static void AssertElementMove(ActionModelBase action, IWebElement element)
        {
            // Assert: the move is measured from the element, which the protocol writes as an element reference.
            var move = (MouseActionModel)action;
            Assert.AreEqual(MouseActionModel.ActionTypes.PointerMove, move.Type);
            Assert.AreEqual(
                JsonSerializer.Serialize(element.ConvertToDictionary()),
                JsonSerializer.Serialize(move.Origin));

            // Assert: a zero offset is the element center, and the move takes no time.
            Assert.AreEqual(0, move.X);
            Assert.AreEqual(0, move.Y);
            Assert.AreEqual(0, move.Duration);
        }

        // Gets the actions of the pointer source, which the sequence always sends first.
        private static ActionModelBase[] GetPointerActions(ActionSequence sequence)
        {
            return [.. sequence.GetInputSources().First().Actions];
        }

        // Gets the relative moves of a drag, in order: the nudge first, then one move per step.
        private static MouseActionModel[] GetRelativeMoves(ActionModelBase[] actions)
        {
            return [.. actions
                .OfType<MouseActionModel>()
                .Where(action => action.Type == MouseActionModel.ActionTypes.PointerMove && action.Origin is string)];
        }

        // Gets the pauses placed between the step moves, without the hold after the press and the rest before the
        // release.
        private static int[] GetStepPauses(ActionModelBase[] actions)
        {
            return [.. actions[3..^2].OfType<NullActionModel>().Select(pause => pause.Duration ?? 0)];
        }

        // Tests whether an action is a pointer move measured from an element, which the protocol writes as an
        // element reference instead of an origin name.
        private static bool TestElementMove(MouseActionModel action)
        {
            return action.Type == MouseActionModel.ActionTypes.PointerMove && action.Origin is not string;
        }
    }
}
