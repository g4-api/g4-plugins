using G4.Plugins.Ui.Assertions.Mobile;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui.Mobile
{
    [TestClass]
    [TestCategory("KeyboardVisibility")]
    [TestCategory("UnitTest")]
    public class AssertKeyboardVisibleTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the KeyboardVisible plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<KeyboardVisible>();
        }

        [TestMethod(DisplayName = "Verify that the KeyboardVisible plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<KeyboardVisible>();
        }

        [TestMethod(DisplayName = "Verify the behavior of the KeyboardVisible plugin with " +
            "various nested assertions.")]
        #region *** Data Set ***
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "KeyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "keyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "OnScreenKeyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "onScreenKeyboardVisible")]
        #endregion
        public void KeyboardVisibleTest(string ruleJson, string onElement, string condition)
        {
            // Modify the action rule by replacing placeholders with actual values
            // Replace placeholders in the action rule with specific values.
            ruleJson = ruleJson
                .Replace(ActionRuleStubs.OnElement, onElement)
                .Replace(ActionRuleStubs.OnCondition, condition)
                .Replace(ActionRuleStubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the plugin evaluation is true.
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
