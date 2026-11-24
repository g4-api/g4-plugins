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
    [TestCategory("AddPause")]
    [TestCategory("InputActions")]
    [TestCategory("UnitTest")]
    public class AddPauseTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the AddPause plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest matches the plugin key and carries a summary, a description and examples.
            AssertManifest<AddPause>();
        }

        [TestMethod(DisplayName = "Verify that the AddPause plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin is registered and the factory creates it with a driver.
            AssertPlugin<AddPause>();
        }

        [TestMethod(DisplayName = "Verify that AddPause adds one pause with the duration in milliseconds, from a " +
            "number or a time span, and zero when no duration is set.")]
        #region *** Data Set ***
        [DataRow("", 0)]
        [DataRow("500", 500)]
        [DataRow("{{$ --Duration:250}}", 250)]
        [DataRow("00:00:02", 2000)]
        [DataRow("{{$ --Duration:00:01:00}}", 60000)]
        [DataRow("1.00:00:00", 86400000)]
        #endregion
        public void AddPauseDurationTest(string argument, int expected)
        {
            // Arrange: a simulator driver backs the sequence, and the rule carries it as the container does.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly; it adds to the sequence and sends nothing.
            var plugin = Invoke<AddPause>(driver, ruleModel: rule).Plugin;

            // Assert: the keyboard source holds exactly one pause with the expected duration.
            var keyAction = (NullActionModel)sequence._keySource.Actions.Single();
            Assert.AreEqual(NullActionModel.ActionTypes.Pause, keyAction.Type);
            Assert.AreEqual(expected, keyAction.Duration);

            // Assert: the pointer source holds the same pause, so both devices wait for the same tick.
            var pointerAction = (NullActionModel)sequence._mouseSource.Actions.Single();
            Assert.AreEqual(expected, pointerAction.Duration);

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddPause fails with a message that names the container when it " +
            "runs outside InvokeInputActions.")]
        public void AddPauseOutsideContainerTest()
        {
            // Arrange: a rule without the handoff entry, as a rule placed outside the container has.
            var rule = new ActionRuleModel { Argument = "500" };

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<AddPause>(ruleModel: rule));

            // Assert: the message tells the flow author where the rule belongs.
            Assert.Contains("InvokeInputActions", exception.Message);
        }

        [TestMethod(DisplayName = "Verify that AddPause fails on text that is not a whole number of milliseconds " +
            "or a time span, on a negative duration, and on one too long to send, adds nothing, and keeps the handoff.")]
        #region *** Data Set ***
        [DataRow("soon")]
        [DataRow("{{$ --Duration:1.5 seconds}}")]
        [DataRow("-200")]
        [DataRow("1.5")]
        [DataRow("1,000")]
        [DataRow("3000000000")]
        [DataRow("{{$ --Duration:25:00:00}}")]
        #endregion
        public void AddPauseInvalidDurationTest(string argument)
        {
            // Arrange: a rule inside the container with a duration the plugin cannot read.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(
                () => Invoke<AddPause>(driver, ruleModel: rule));

            // Assert: the error names the problem, and the sequence stays empty.
            Assert.Contains("is not valid", exception.Message);
            Assert.IsEmpty(sequence._keySource.Actions);
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
