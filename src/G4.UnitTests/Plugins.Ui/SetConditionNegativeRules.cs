using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetConditionAlertExists")]
    [TestCategory("UnitTest")]
    public class SetConditionNegativeRules : TestBase
    {
        // Define a data set for the AlertExists plugin
        private static IEnumerable<object[]> DataSet =>
        [
            [Stubs.RuleJsonConditionDynamicNegativeRules, "AlertExists"],
            [Stubs.RuleJsonConditionDynamicNegativeRules, "alertExists"],
            [Stubs.RuleJsonConditionDynamicNegativeRules, "AlertVisible"],
            [Stubs.RuleJsonConditionDynamicNegativeRules, "alertVisible"],
            [Stubs.RuleJsonConditionDynamicNegativeRules, "HasAlert"],
            [Stubs.RuleJsonConditionDynamicNegativeRules, "hasAlert"]
        ];

        [TestMethod(DisplayName = "Verify that the SetCondition plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the SetCondition plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the AlertExists condition fails when no alert is present.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void AlertExistsNegativeTest(string ruleJson, string condition)
        {
            // Replace the condition in the rule JSON
            ruleJson = ruleJson.Replace(Stubs.OnCondition, condition);

            // Invoke the SetCondition action with the specified action rule
            var responseModel = Invoke(ruleJson, capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.HasAlert] = true
            });

            // Extract the environment from the response model
            var environment = responseModel.GetEnvironment();

            // Assert that no session parameters were set
            Assert.IsFalse(environment.SessionParameters.Any());
        }

        [TestMethod(DisplayName = "Verify that the AlertExists condition succeeds when an alert is present.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void AlertExistsTest(string ruleJson, string condition)
        {
            // Replace the condition in the rule JSON
            ruleJson = ruleJson.Replace(Stubs.OnCondition, condition);

            // Invoke the SetCondition action with the specified action rule
            var responseModel = Invoke(ruleJson, capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.HasAlert] = false
            });

            // Extract the session parameter value from the response model and
            // decode it from Base64 encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set
            Assert.AreEqual(expected: "Foo Bar", actual, ignoreCase: true);
        }
    }
}
