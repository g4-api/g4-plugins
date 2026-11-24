using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.InputActions;
using G4.UnitTests.Framework;
using G4.WebDriver.Attributes;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;
using G4.WebDriver.Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("AddKeyUp")]
    [TestCategory("InputActions")]
    [TestCategory("UnitTest")]
    public class AddKeyUpTests : TestBase
    {
        // Every key constant of the WebDriver client, written as a plain argument and as the Key parameter, with
        // the value the constant holds. The list is read from the client, so a key added there is tested at once.
        private static IEnumerable<object[]> KeyNames => GetKeyConstants()
            .SelectMany(key => new[]
            {
                new object[] { key.Name, key.Value },
                new object[] { "{{$ --Key:" + key.Name + "}}", key.Value }
            });

        [TestMethod(DisplayName = "Verify that the AddKeyUp plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest matches the plugin key and carries a summary, a description and examples.
            AssertManifest<AddKeyUp>();
        }

        [TestMethod(DisplayName = "Verify that the AddKeyUp plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin is registered and the factory creates it with a driver.
            AssertPlugin<AddKeyUp>();
        }

        [TestMethod(DisplayName = "Verify that AddKeyUp adds one key-up action that carries the code of a " +
            "named key or the character itself.")]
        #region *** Data Set ***
        [DataRow("Control", "\uE009")]
        [DataRow("control", "\uE009")]
        [DataRow("{{$ --Key:Shift}}", "\uE008")]
        [DataRow("Enter", "\uE007")]
        [DataRow("a", "a")]
        [DataRow("{{$ --Key:5}}", "5")]
        #endregion
        public void AddKeyUpKeyTest(string argument, string expected)
        {
            // Arrange: a simulator driver backs the sequence, and the rule carries it as the container does.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly; it adds to the sequence and sends nothing.
            var plugin = Invoke<AddKeyUp>(driver, ruleModel: rule).Plugin;

            // Assert: the keyboard source holds exactly one key-up action with the expected key value.
            var action = (KeyboardActionModel)sequence._keySource.Actions.Single();
            Assert.AreEqual(KeyboardActionModel.ActionTypes.KeyUp, action.Type);
            Assert.AreEqual(expected, action.Value);

            // Assert: the pointer source waits on the same tick, which keeps later actions in order.
            Assert.IsInstanceOfType<NullActionModel>(sequence._mouseSource.Actions.Single());

            // Assert: the plugin reported no error and gave the handoff back to the container.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
            Assert.IsFalse(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddKeyUp resolves every key name of the WebDriver client, as a " +
            "plain argument and as the Key parameter, to the value of that key constant.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(KeyNames))]
        #endregion
        public void AddKeyUpEveryKeyNameTest(string argument, string expected)
        {
            // Arrange: a simulator driver backs the sequence, and the rule carries it as the container does.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly; it resolves the name and adds the action to the sequence.
            var plugin = Invoke<AddKeyUp>(driver, ruleModel: rule).Plugin;

            // Assert: the keyboard source holds one action with the value of the client constant.
            var action = (KeyboardActionModel)sequence._keySource.Actions.Single();
            Assert.AreEqual(KeyboardActionModel.ActionTypes.KeyUp, action.Type);
            Assert.AreEqual(expected, action.Value);

            // Assert: the plugin reported no error for a published name.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the Key values the AddKeyUp manifest publishes are exactly the key " +
            "names of the WebDriver client.")]
        public void AddKeyUpManifestKeyValuesTest()
        {
            // Arrange: read the names the manifest of the plugin publishes for the Key parameter.
            var manifest = NewPlugin<AddKeyUp>().GetManifest();
            var published = manifest
                .Parameters
                .Single(parameter => parameter.Name == "Key")
                .Values
                .Select(value => value.Name)
                .ToArray();

            // Arrange: read the names the client defines as key constants.
            var expected = GetKeyConstants()
                .Select(key => key.Name)
                .ToArray();

            // Assert: the manifest lists every client name once, and no other name; order is not compared,
            // because reflection does not promise the declaration order of the fields.
            Assert.AreSequenceEqual(expected, actual: published, order: SequenceOrder.InAnyOrder);
        }

        [TestMethod(DisplayName = "Verify that AddKeyUp fails with a message that names the container when it " +
            "runs outside InvokeInputActions.")]
        public void AddKeyUpOutsideContainerTest()
        {
            // Arrange: a rule without the handoff entry, as a rule placed outside the container has.
            var rule = new ActionRuleModel { Argument = "Control" };

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(() => Invoke<AddKeyUp>(ruleModel: rule));

            // Assert: the message tells the flow author where the rule belongs.
            Assert.Contains("InvokeInputActions", exception.Message);
        }

        [TestMethod(DisplayName = "Verify that AddKeyUp fails on text that is neither a key name nor a single " +
            "character, adds nothing, and keeps the handoff.")]
        #region *** Data Set ***
        [DataRow("NoSuchKey")]
        [DataRow("{{$ --Key:ab}}")]
        #endregion
        public void AddKeyUpUnknownKeyTest(string argument)
        {
            // Arrange: a rule inside the container with a key the driver has no value for.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument);

            // Act: run the plugin directly and capture the failure.
            var exception = Assert.Throws<InvalidOperationException>(
                () => Invoke<AddKeyUp>(driver, ruleModel: rule));

            // Assert: the error names the problem, and the sequence stays empty.
            Assert.Contains("is not valid", exception.Message);
            Assert.IsEmpty(sequence._keySource.Actions);

            // Assert: the handoff is still in the rule context, which tells the container to send nothing.
            Assert.IsTrue(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        [TestMethod(DisplayName = "Verify that AddKeyUp without an argument is rejected as a missing mandatory " +
            "property, adds nothing, and keeps the handoff.")]
        public void AddKeyUpMissingKeyTest()
        {
            // Arrange: a rule inside the container that names no key.
            using var driver = new SimulatorDriver();
            var sequence = new ActionSequence(driver);
            var rule = NewRule(sequence, argument: string.Empty);

            // Act: run the plugin directly; the engine rejects the rule before the plugin code runs.
            var plugin = Invoke<AddKeyUp>(driver, ruleModel: rule).Plugin;

            // Assert: the rejection is reported, and nothing was added to the sequence.
            Assert.IsFalse(plugin.Exceptions.IsEmpty);
            Assert.IsEmpty(sequence._keySource.Actions);

            // Assert: the handoff is still in the rule context, which tells the container to send nothing.
            Assert.IsTrue(rule.Context.ContainsKey(InputActionBase.SequenceKey));
        }

        // Reads the key constants of the WebDriver client: each public static field of Keys that carries a KeyCode
        // attribute, with the name the attribute gives and the value the field holds. The client builds its own
        // name table the same way, so these are exactly the names a rule may use.
        private static IEnumerable<(string Name, string Value)> GetKeyConstants()
        {
            // Read the public static fields of the client key table.
            var fields = typeof(Keys).GetFields(BindingFlags.Public | BindingFlags.Static);

            // Keep the attributed fields and pair each name with the key value the field holds.
            return fields
                .Where(field => field.GetCustomAttribute<KeyCodeAttribute>() != null)
                .Select(field => (
                    Name: field.GetCustomAttribute<KeyCodeAttribute>().KeyName,
                    Value: (string)field.GetValue(obj: null)));
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
