using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
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
        [TestMethod(DisplayName = "Verify that the SetSwitchCase plugin is correctly registered " +
            "and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetSwitchCase>();
        }

        [TestMethod(DisplayName = "Verify that the SetSwitchCase plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetSwitchCase>();
        }

        [TestMethod(DisplayName = "Verify that the SetSwitchCase plugin runs the Default branch, without an " +
            "exception, when the attribute it reads does not exist on the element.")]
        public void SetSwitchCaseMissingAttributeTest()
        {
            // Arrange: the simulator answers null for an attribute named "value" that the element does not hold,
            // as a W3C driver does for an attribute that is not written in the markup.
            const string ruleJson =
                "{" +
                "    \"$type\": \"Switch\"," +
                "    \"pluginName\": \"SetSwitchCase\"," +
                "    \"argument\": \"\"," +
                "    \"locator\": \"Id\"," +
                "    \"onElement\": \"//positive\"," +
                "    \"onAttribute\": \"value\"," +
                "    \"regularExpression\": \".*\"," +
                "    \"branches\": {" +
                "        \"Other\": [" +
                "             {" +
                "                 \"$type\": \"Action\"," +
                "                 \"pluginName\": \"RegisterParameter\"," +
                "                 \"argument\": \"{{$ --Name:TestParameter --Value:Other}}\"" +
                "             }" +
                "         ]," +
                "        \"Default\": [" +
                "             {" +
                "                 \"$type\": \"Action\"," +
                "                 \"pluginName\": \"RegisterParameter\"," +
                "                 \"argument\": \"{{$ --Name:TestParameter --Value:Default}}\"" +
                "             }" +
                "         ]" +
                "    }" +
                "}";
            var ruleModel = JsonSerializer.Deserialize<G4RuleModelBase>(ruleJson, JsonOptions);

            // Act: invoke the rule and read the parameter the branch that ran has registered.
            var responseModel = Invoke([ruleModel]);
            var actual = responseModel
                .GetParameterValue(parameterName: "TestParameter", scope: "Session")
                .ConvertFromBase64();
            var exceptionTypes = responseModel.GetExceptions().Select(i => i.Type).ToArray();

            // Assert: the missing attribute is read as an empty key, which selects the Default branch.
            Assert.AreEqual(expected: "Default", actual);
            Assert.IsEmpty(exceptionTypes);
        }

        [TestMethod(DisplayName = "Verify that the SetSwitchCase plugin evaluates conditions " +
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
