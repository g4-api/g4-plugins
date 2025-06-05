using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("SetSwitchCase")]
    [TestCategory("UnitTest")]
    public class SetSwitchCaseTests : TestBase
    {
        [TestMethod(displayName: "Verify that the SetSwitchCase plugin is correctly registered " +
            "and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetSwitchCase>();
        }

        [TestMethod(displayName: "Verify that the SetSwitchCase plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetSwitchCase>();
        }

        [TestMethod(displayName: "Verify that the SetSwitchCase plugin evaluates conditions " +
            "correctly in positive scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonSwitchCaseNoElement, "SwitchRule", "SwitchRule")]
        [DataRow(Stubs.RuleJsonSwitchCaseWithElement, "SwitchRule", "http://m.from-href.io/")]
        #endregion
        public void SetSwitchCasePositiveTest(string ruleJson, string onArgument, string expected)
        {
            // Replace placeholders in the rule JSON with the provided parameters.
            ruleJson = ruleJson
                .Replace(Stubs.OnArgument, onArgument)
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "href")
                .Replace(Stubs.OnRegularExpression, ".*");

            // mock attribute value 520
            // Deserialize the modified rule JSON into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<G4RuleModelBase>(ruleJson, JsonOptions);

            // Invoke the action rule and get the response.
            var responseModel = Invoke([ruleModel]);

            // Retrieve the parameter value from the response and decode it from Base64.
            var actual = responseModel
                .GetParameterValue(parameterName: "TestParameter", scope: "Session")
                .ConvertFromBase64();

            // Assert that the actual parameter value matches the expected value.
            Assert.AreEqual(expected, actual);
        }
    }
}
