using G4.Models;
using G4.Plugins.Common.Operators;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.Json;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("OperatorNotMatch")]
    [TestCategory("UnitTest")]
    public class OperatorNotMatchTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the NotMatchOperator plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<NotMatchOperator>();
        }

        [TestMethod(DisplayName = "Verify that the NotMatchOperator plugin named 'NotMatch' " +
            "complies with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<NotMatchOperator>(pluginName: "NotMatch");
        }

        [TestMethod(DisplayName = "Verify that the NotMatchOperator plugin evaluates correctly " +
            "in negative scenarios.")]
        #region *** Test Data ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "random", "NotMatch", @"^mock attribute value \\d+$", "ElementAttribute", ".//positive")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "random", "notMatch", @"^mock attribute value \\d+$", "ElementAttribute", ".//positive")]
        #endregion
        public void OperatorNotMatchNegativeTest(
            string ruleJson,
            string onAttribute,
            string onOperator,
            string onOperatorExpected,
            string onCondition,
            string onElement)
        {
            // Replace placeholders in the action rule with provided parameters
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, onAttribute)
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Check if the evaluation returns false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the NotMatchOperator plugin evaluates correctly " +
            "in positive scenarios.")]
        #region *** Test Data ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "random", "NotMatch", @"^attribute value \\d+ mock$", "ElementAttribute", ".//positive")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "random", "notMatch", @"^attribute value \\d+ mock$", "ElementAttribute", ".//positive")]
        #endregion
        public void OperatorNotMatchTest(
            string ruleJson,
            string onAttribute,
            string onOperator,
            string onOperatorExpected,
            string onCondition,
            string onElement)
        {
            // Replace placeholders in the action rule with provided parameters
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, onAttribute)
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Check if the evaluation returns true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
