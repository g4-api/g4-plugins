using G4.Plugins.Ui.Assertions.Mobile;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui.Mobile
{
    [TestClass]
    public class AssertKeyboardNotVisibleTests : TestBase
    {
        [TestMethod]
        public override void NewPluginTest()
        {
            AssertPlugin<KeyboardVisible>();
        }

        [TestMethod]
        public override void ManifestComplianceTest()
        {
            AssertManifest<KeyboardVisible>();
        }

        [DataTestMethod]
        [DataRow(Stubs.RuleJsonBoolean, null, "KeyboardNotVisible", "(Fail | KeyboardVisible)")]
        [DataRow(Stubs.RuleJsonBoolean, null, "keyboardNotVisible", "(Fail | KeyboardVisible)")]
        [DataRow(Stubs.RuleJsonBoolean, null, "OnScreenKeyboardNotVisible", "(Fail | KeyboardVisible)")]
        [DataRow(Stubs.RuleJsonBoolean, null, "onScreenKeyboardNotVisible", "(Fail | KeyboardVisible)")]
        public void KeyboardNotVisibleNestedTest(string ruleJson, string onElement, string assertion, string message)
        {
            // Replace placeholders in the action rule with specific values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, onElement)
                .Replace(Stubs.OnCondition, assertion)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Get actual and expected messages from the plugin.
            var (actualMessage, expectedMessage) = session.ResponseData.Extractions.GetAssertMessages();

            // Assert that the plugin evaluation is true.
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the actual message does not contain the specified message.
            Assert.IsFalse(actualMessage.Contains(message));

            // Assert that the actual message contains the expected message.
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        [DataTestMethod]
        [DataRow(Stubs.RuleJsonBoolean, null, "KeyboardNotVisible", "(Fail | KeyboardVisible)")]
        [DataRow(Stubs.RuleJsonBoolean, null, "keyboardNotVisible", "(Fail | KeyboardVisible)")]
        [DataRow(Stubs.RuleJsonBoolean, null, "OnScreenKeyboardNotVisible", "(Fail | KeyboardVisible)")]
        [DataRow(Stubs.RuleJsonBoolean, null, "onScreenKeyboardNotVisible", "(Fail | KeyboardVisible)")]
        public void KeyboardNotVisibleTest(string ruleJson, string onElement, string assertion, string message)
        {
            // Replace placeholders in the action rule with specific values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, onElement)
                .Replace(Stubs.OnCondition, assertion)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Get actual and expected messages from the plugin.
            var (actualMessage, expectedMessage) = session.ResponseData.Extractions.GetAssertMessages();

            // Assert that the plugin evaluation is true.
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the actual message does not contain the specified message.
            Assert.IsFalse(actualMessage.Contains(message));

            // Assert that the actual message contains the expected message.
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }
    }
}
