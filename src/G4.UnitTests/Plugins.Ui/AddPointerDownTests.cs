using G4.Models;
using G4.Plugins.Ui.InputActions;
using G4.UnitTests.Framework;
using G4.WebDriver.Models;
using G4.WebDriver.Remote.Interactions;
using G4.WebDriver.Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("AddPointerDown")]
    [TestCategory("InputActions")]
    [TestCategory("UnitTest")]
    public class AddPointerDownTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the AddPointerDown plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest matches the plugin key and carries a summary, a description and examples.
            AssertManifest<AddPointerDown>();
        }

        [TestMethod(DisplayName = "Verify that the AddPointerDown plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin is registered and the factory creates it with a driver.
            AssertPlugin<AddPointerDown>();
        }

        [TestMethod(DisplayName = "Verify that AddPointerDown adds one pointer-down action for the named button " +
            "and uses the left button when none is named.")]
        #region *** Data Set ***
        [DataRow("", 0)]
        [DataRow("Left", 0)]
        [DataRow("{{$ --Button:Middle}}", 1)]
        [DataRow("Right", 2)]
        [DataRow("back", 3)]
        [DataRow("{{$ --Button:Forward}}", 4)]
        #endregion
        public void AddPointerDownButtonTest(string argument, int expected)
        {
            // Arrange: a simulator driver backs the sequence, and the rule carries it as the container does.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly; it adds to the sequence and sends nothing.
            var plugin = Invoke<AddPointerDown>(driver, ruleModel: rule).Plugin;

            // Assert: the pointer source holds exactly one pointer-down action with the expected button.
            var action = (MouseActionModel)sequence._mouseSource.Actions.Single();
            Assert.AreEqual(MouseActionModel.ActionTypes.PointerDown, action.Type);
            Assert.AreEqual(expected, action.Button);

            // Assert: the keyboard source waits on the same tick, which keeps later actions in order.
            Assert.IsInstanceOfType<NullActionModel>(sequence._keySource.Actions.Single());

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddPointerDown fails with a message that names the container when " +
            "it runs outside InvokeInputActions.")]
        public void AddPointerDownOutsideContainerTest()
        {
            // Arrange: a rule without the handoff entry, as a rule placed outside the container has.
            var rule = new ActionRuleModel();

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<AddPointerDown>(ruleModel: rule));

            // Assert: the message tells the flow author where the rule belongs.
            Assert.Contains("InvokeInputActions", exception.Message);
        }

        [TestMethod(DisplayName = "Verify that AddPointerDown fails on an unknown button name, adds nothing, and " +
            "keeps the handoff.")]
        #region *** Data Set ***
        [DataRow("Side")]
        [DataRow("{{$ --Button:7}}")]
        #endregion
        public void AddPointerDownUnknownButtonTest(string argument)
        {
            // Arrange: a rule inside the container with a button name that does not exist.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(
                () => Invoke<AddPointerDown>(driver, ruleModel: rule));

            // Assert: the error lists the supported buttons, and the sequence stays empty.
            Assert.Contains("is not supported", exception.Message);
            Assert.Contains("Left, Middle, Right, Back, Forward", exception.Message);
            Assert.IsEmpty(sequence._mouseSource.Actions);

            // Assert: the handoff is still in the rule context, which tells the container to send nothing.
            Assert.IsTrue(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        // Creates a rule that carries the shared sequence the way the container hands it to a child rule.
        // The rule is not sent anywhere; the test passes it to the plugin and then reads the sequence.
        private static ActionRuleModel NewRule(ActionSequence sequence, string argument)
        {
            // Arrange: the rule holds the argument under test.
            var rule = new ActionRuleModel { Argument = argument };

            // Arrange: the handoff entry is what marks the rule as running inside the container.
            rule.Context[InputActionBase.SequenceKey] = sequence;

            return rule;
        }
    }
}
