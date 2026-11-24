using G4.Models;
using G4.Plugins.Ui.InputActions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;
using G4.WebDriver.Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("AddScroll")]
    [TestCategory("InputActions")]
    [TestCategory("UnitTest")]
    public class AddScrollTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the AddScroll plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest matches the plugin key and carries a summary, a description and examples.
            AssertManifest<AddScroll>();
        }

        [TestMethod(DisplayName = "Verify that the AddScroll plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin is registered and the factory creates it with a driver.
            AssertPlugin<AddScroll>();
        }

        [TestMethod(DisplayName = "Verify that AddScroll adds one wheel action measured from the viewport, with " +
            "the scroll amounts and the position of the rule.")]
        #region *** Data Set ***
        [DataRow("", 0, 0, 0, 0)]
        [DataRow("{{$ --DeltaY:600}}", 0, 600, 0, 0)]
        [DataRow("{{$ --DeltaY:-250}}", 0, -250, 0, 0)]
        [DataRow("{{$ --DeltaX:300 --X:400 --Y:300}}", 300, 0, 400, 300)]
        [DataRow("{{$ --DeltaX:-50 --DeltaY:75 --X:10 --Y:20}}", -50, 75, 10, 20)]
        #endregion
        public void AddScrollViewportTest(string argument, int deltaX, int deltaY, int x, int y)
        {
            // Arrange: a simulator driver backs the sequence, and the rule names no element.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly; it adds to the sequence and sends nothing.
            var plugin = Invoke<AddScroll>(driver, ruleModel: rule).Plugin;

            // Assert: the wheel source holds exactly one scroll that starts from the viewport.
            var action = GetWheelAction(sequence);
            Assert.AreEqual(WheelActionModel.ActionTypes.Scroll, action.Type);
            Assert.AreEqual(ActionOrigins.Viewport, action.Origin);

            // Assert: the scroll carries the amounts and the position of the rule.
            Assert.AreEqual(deltaX, action.DeltaX);
            Assert.AreEqual(deltaY, action.DeltaY);
            Assert.AreEqual(x, action.X);
            Assert.AreEqual(y, action.Y);

            // Assert: the pointer and keyboard sources wait on the same tick, which keeps later actions in order.
            Assert.IsInstanceOfType<NullActionModel>(sequence._mouseSource.Actions.Single());
            Assert.IsInstanceOfType<NullActionModel>(sequence._keySource.Actions.Single());

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddScroll measures a scroll from the element named by OnElement, " +
            "with X and Y as offsets.")]
        #region *** Data Set ***
        [DataRow("{{$ --DeltaY:400}}", 400, 0, 0)]
        [DataRow("{{$ --DeltaY:120 --X:15 --Y:-5}}", 120, 15, -5)]
        #endregion
        public void AddScrollOnElementTest(string argument, int deltaY, int x, int y)
        {
            // Arrange: the rule names an element the simulator driver finds.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument, onElement: "//positive");

            // Act: run the plugin directly; it finds the element and adds the scroll.
            var plugin = Invoke<AddScroll>(driver, ruleModel: rule).Plugin;

            // Assert: the origin of the scroll is an element reference, not the viewport.
            var action = GetWheelAction(sequence);
            Assert.IsInstanceOfType<IDictionary<string, object>>(action.Origin);

            // Assert: the amount and the offsets of the rule travel with the scroll.
            Assert.AreEqual(deltaY, action.DeltaY);
            Assert.AreEqual(x, action.X);
            Assert.AreEqual(y, action.Y);

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddScroll measures a scroll from the element it inherited when the " +
            "rule names none.")]
        public void AddScrollInheritedElementTest()
        {
            // Arrange: the rule names no element; the test passes one in, as a for-each loop does.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument: "{{$ --DeltaY:200}}");
            var by = By.Custom.Positive();

            // Act: run the plugin directly on the inherited element.
            var plugin = Invoke<AddScroll>(driver, ruleModel: rule, by).Plugin;

            // Assert: the origin of the scroll is the reference of the inherited element.
            var action = GetWheelAction(sequence);
            Assert.IsInstanceOfType<IDictionary<string, object>>(action.Origin);

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddScroll fails with a message that names the container when it " +
            "runs outside InvokeInputActions.")]
        public void AddScrollOutsideContainerTest()
        {
            // Arrange: a rule without the handoff entry, as a rule placed outside the container has.
            var rule = new ActionRuleModel { Argument = "{{$ --DeltaY:600}}" };

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<AddScroll>(ruleModel: rule));

            // Assert: the message tells the flow author where the rule belongs.
            Assert.Contains("InvokeInputActions", exception.Message);
        }

        [TestMethod(DisplayName = "Verify that AddScroll fails on an amount or a position that is not a whole " +
            "number, names the parameter, and adds nothing.")]
        #region *** Data Set ***
        [DataRow("{{$ --DeltaY:far}}", "DeltaY")]
        [DataRow("{{$ --DeltaX:1.5}}", "DeltaX")]
        [DataRow("{{$ --DeltaY:100 --X:left}}", "X")]
        [DataRow("{{$ --DeltaY:100 --Y:top}}", "Y")]
        #endregion
        public void AddScrollInvalidNumberTest(string argument, string parameter)
        {
            // Arrange: a rule inside the container with one number the plugin cannot read.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(
                () => Invoke<AddScroll>(driver, ruleModel: rule));

            // Assert: the error names the parameter, and no wheel source joined the sequence.
            Assert.Contains($"Parameter '{parameter}'", exception.Message);
            Assert.DoesNotContain(source => source.Type == InputSourceTypes.Wheel, sequence.GetInputSources());

            // Assert: the handoff is still in the rule context, which tells the container to send nothing.
            Assert.IsTrue(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddScroll fails with the driver error when the element named by " +
            "OnElement is not found, and adds nothing.")]
        public void AddScrollMissingElementTest()
        {
            // Arrange: the rule names an element the simulator driver never finds.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument: "{{$ --DeltaY:600}}", onElement: "//none");

            // Act: run the plugin directly; the element search ends with the driver timeout.
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<AddScroll>(driver, ruleModel: rule));

            // Assert: nothing was added, and the handoff stays so the container sends nothing.
            Assert.DoesNotContain(source => source.Type == InputSourceTypes.Wheel, sequence.GetInputSources());
            Assert.IsTrue(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        // Reads the single wheel action of a sequence. The wheel source joins the input sources only after a
        // scroll was added, so a sequence without one fails the test here.
        private static WheelActionModel GetWheelAction(ActionSequence sequence)
        {
            // Arrange: find the wheel source among the sources the sequence sends.
            var wheelSource = sequence.GetInputSources().Single(source => source.Type == InputSourceTypes.Wheel);

            return (WheelActionModel)wheelSource.Actions.Single();
        }

        // Creates a rule without an element that carries the shared sequence, as a child rule of the container.
        private static ActionRuleModel NewRule(ActionSequence sequence, string argument)
        {
            // Arrange: route the short call shape through the complete one with no element.
            return NewRule(sequence, argument, onElement: string.Empty);
        }

        // Creates a rule that carries the shared sequence the way the container hands it to a child rule.
        // The rule is not sent anywhere; the test passes it to the plugin and then reads the sequence.
        private static ActionRuleModel NewRule(ActionSequence sequence, string argument, string onElement)
        {
            // Arrange: the rule holds the argument and the element locator under test.
            var rule = new ActionRuleModel { Argument = argument, OnElement = onElement };

            // Arrange: the handoff entry is what marks the rule as running inside the container.
            rule.Context[InputActionBase.SequenceKey] = sequence;

            return rule;
        }
    }
}
