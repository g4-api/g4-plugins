using G4.Plugins.Ui.Assertions.Mobile;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui.Mobile
{
    [TestClass]
    [TestCategory("KeyboardVisibility")]
    [TestCategory("UnitTest")]
    public class AssertKeyboardVisibleTests : TestBase
    {
        [TestMethod(displayName: "Verify that the KeyboardVisible plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<KeyboardVisible>();
        }

        [TestMethod(displayName: "Verify that the KeyboardVisible plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<KeyboardVisible>();
        }

        [TestMethod(displayName: "Verify the behavior of the KeyboardVisible plugin with " +
            "various nested assertions.")]
        #region *** Data Set ***
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "KeyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "keyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "OnScreenKeyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "onScreenKeyboardVisible")]
        #endregion
        public void KeyboardVisibleNestedTest(string ruleJson, string onElement, string condition)
        {
            // Modify the action rule by replacing placeholders with actual values
            ruleJson = ruleJson
                .Replace(ActionRuleStubs.OnElement, onElement)
                .Replace(ActionRuleStubs.OnCondition, condition);

            // Invoke the action and get the plugin for assertion
            var plugin = Invoke<G4.Plugins.Common.Actions.Assert>(ruleJson, By.Custom.Positive()).Plugin;

            // Perform assertions
            Assert.IsTrue(!plugin.GetEvaluation());
        }

        [TestMethod(displayName: "Verify the behavior of the KeyboardVisible plugin with " +
            "various assertions.")]
        #region *** Data Set ***
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "KeyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "keyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "OnScreenKeyboardVisible")]
        [DataRow(ActionRuleStubs.RuleJsonBoolean, null, "onScreenKeyboardVisible")]
        #endregion
        public void KeyboardVisibleTest(string ruleJson, string onElement, string condition)
        {
            // Modify the action rule by replacing placeholders with actual values
            ruleJson = ruleJson
                .Replace(ActionRuleStubs.OnElement, onElement)
                .Replace(ActionRuleStubs.OnCondition, condition);

            // Invoke the action and get the plugin for assertion
            var plugin = Invoke<G4.Plugins.Common.Actions.Assert>(ruleJson).Plugin;

            // Perform assertions
            Assert.IsTrue(!plugin.GetEvaluation());
        }
    }
}
