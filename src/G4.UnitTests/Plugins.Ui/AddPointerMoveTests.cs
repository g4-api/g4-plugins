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
    [TestCategory("AddPointerMove")]
    [TestCategory("InputActions")]
    [TestCategory("UnitTest")]
    public class AddPointerMoveTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the AddPointerMove plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest matches the plugin key and carries a summary, a description and examples.
            AssertManifest<AddPointerMove>();
        }

        [TestMethod(DisplayName = "Verify that the AddPointerMove plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin is registered and the factory creates it with a driver.
            AssertPlugin<AddPointerMove>();
        }

        [TestMethod(DisplayName = "Verify that AddPointerMove measures a move without an element from the pointer " +
            "by default or from the viewport on request, with the given coordinates and duration.")]
        #region *** Data Set ***
        [DataRow("", ActionOrigins.Pointer, 0, 0, 250)]
        [DataRow("{{$ --X:120 --Y:30}}", ActionOrigins.Pointer, 120, 30, 250)]
        [DataRow("{{$ --X:200 --Y:150 --Origin:Viewport}}", ActionOrigins.Viewport, 200, 150, 250)]
        [DataRow("{{$ --X:5 --Y:7 --Origin:viewport --Duration:600}}", ActionOrigins.Viewport, 5, 7, 600)]
        [DataRow("{{$ --X:-40 --Y:-10 --Origin:Pointer --Duration:00:00:01}}", ActionOrigins.Pointer, -40, -10, 1000)]
        [DataRow("{{$ --Duration:0}}", ActionOrigins.Pointer, 0, 0, 0)]
        #endregion
        public void AddPointerMoveCoordinatesTest(string argument, string origin, int x, int y, int duration)
        {
            // Arrange: a simulator driver backs the sequence, and the rule names no element.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly; it adds to the sequence and sends nothing.
            var plugin = Invoke<AddPointerMove>(driver, ruleModel: rule).Plugin;

            // Assert: the pointer source holds exactly one move measured from the expected origin.
            var action = (MouseActionModel)sequence._mouseSource.Actions.Single();
            Assert.AreEqual(MouseActionModel.ActionTypes.PointerMove, action.Type);
            Assert.AreEqual(origin, action.Origin);

            // Assert: the move carries the coordinates and the duration of the rule.
            Assert.AreEqual(x, action.X);
            Assert.AreEqual(y, action.Y);
            Assert.AreEqual(duration, action.Duration);

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddPointerMove measures a move from the element named by OnElement, " +
            "with X and Y as offsets, and ignores the Origin parameter.")]
        #region *** Data Set ***
        [DataRow("", 0, 0, 250)]
        [DataRow("{{$ --X:40 --Y:-10 --Duration:400}}", 40, -10, 400)]
        [DataRow("{{$ --X:3 --Origin:Viewport}}", 3, 0, 250)]
        #endregion
        public void AddPointerMoveOnElementTest(string argument, int x, int y, int duration)
        {
            // Arrange: the rule names an element the simulator driver finds.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument, onElement: "//positive");

            // Act: run the plugin directly; it finds the element and adds the move.
            var plugin = Invoke<AddPointerMove>(driver, ruleModel: rule).Plugin;

            // Assert: the origin of the move is an element reference, not an origin name.
            var action = (MouseActionModel)sequence._mouseSource.Actions.Single();
            Assert.AreEqual(MouseActionModel.ActionTypes.PointerMove, action.Type);
            Assert.IsInstanceOfType<IDictionary<string, object>>(action.Origin);

            // Assert: X and Y travel as offsets from the element, with the duration of the rule.
            Assert.AreEqual(x, action.X);
            Assert.AreEqual(y, action.Y);
            Assert.AreEqual(duration, action.Duration);

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddPointerMove measures a move from the element it inherited when " +
            "the rule names none.")]
        public void AddPointerMoveInheritedElementTest()
        {
            // Arrange: the rule names no element; the test passes one in, as a for-each loop does.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument: string.Empty);
            var by = By.Custom.Positive();

            // Act: run the plugin directly on the inherited element.
            var plugin = Invoke<AddPointerMove>(driver, ruleModel: rule, by).Plugin;

            // Assert: the origin of the move is the reference of the inherited element.
            var action = (MouseActionModel)sequence._mouseSource.Actions.Single();
            Assert.IsInstanceOfType<IDictionary<string, object>>(action.Origin);

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddPointerMove fails with a message that names the container when " +
            "it runs outside InvokeInputActions.")]
        public void AddPointerMoveOutsideContainerTest()
        {
            // Arrange: a rule without the handoff entry, as a rule placed outside the container has.
            var rule = new ActionRuleModel { Argument = "{{$ --X:10 --Y:10}}" };

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<AddPointerMove>(ruleModel: rule));

            // Assert: the message tells the flow author where the rule belongs.
            Assert.Contains("InvokeInputActions", exception.Message);
        }

        [TestMethod(DisplayName = "Verify that AddPointerMove fails on an unknown origin, on a coordinate that is " +
            "not a whole number, and on text that is not a duration, and adds nothing.")]
        #region *** Data Set ***
        [DataRow("{{$ --X:10 --Y:10 --Origin:Screen}}", "is not supported")]
        [DataRow("{{$ --X:ten --Y:10}}", "is not a whole number")]
        [DataRow("{{$ --X:10 --Y:1.5}}", "is not a whole number")]
        [DataRow("{{$ --X:10 --Y:10 --Duration:soon}}", "is not valid")]
        #endregion
        public void AddPointerMoveInvalidArgumentTest(string argument, string expected)
        {
            // Arrange: a rule inside the container with one value the plugin cannot read.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(
                () => Invoke<AddPointerMove>(driver, ruleModel: rule));

            // Assert: the error names the problem, and the sequence stays empty.
            Assert.Contains(expected, exception.Message);
            Assert.IsEmpty(sequence._mouseSource.Actions);

            // Assert: the handoff is still in the rule context, which tells the container to send nothing.
            Assert.IsTrue(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddPointerMove fails with the driver error when the element named " +
            "by OnElement is not found, and adds nothing.")]
        public void AddPointerMoveMissingElementTest()
        {
            // Arrange: the rule names an element the simulator driver never finds.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument: string.Empty, onElement: "//none");

            // Act: run the plugin directly; the element search ends with the driver timeout.
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<AddPointerMove>(driver, ruleModel: rule));

            // Assert: nothing was added, and the handoff stays so the container sends nothing.
            Assert.IsEmpty(sequence._mouseSource.Actions);
            Assert.IsTrue(rule.Context.ContainsKey(InputActionBase.SequenceKey));
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
