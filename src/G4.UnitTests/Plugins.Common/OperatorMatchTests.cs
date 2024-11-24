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
    [TestCategory("OperatorMatch")]
    [TestCategory("UnitTest")]
    public class OperatorMatchTests : TestBase
    {
        [TestMethod(displayName: "Verify that the MatchOperator plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<MatchOperator>();
        }

        [TestMethod(displayName: "Verify that the MatchOperator plugin named 'Match' complies " +
            "with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<MatchOperator>(pluginName: "Match");
        }

        [TestMethod(displayName: "Verify that the MatchOperator plugin evaluates correctly " +
            "in negative scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "random", "Match", @"^attribute value \\d+ mock$", "ElementAttribute", ".//positive")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "random", "match", @"^attribute value \\d+ mock$", "ElementAttribute", ".//positive")]
        #endregion
        public void OperatorMatchNegativeTest(
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

            // Ensure the evaluation is false
            Assert.IsTrue(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the MatchOperator plugin evaluates correctly " +
            "in positive scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "random", "Match", @"^mock attribute value \\d+$", "ElementAttribute", ".//positive")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "random", "match", @"^mock attribute value \\d+$", "ElementAttribute", ".//positive")]
        #endregion
        public void OperatorMatchTest(
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

            // Ensure the evaluation is not false
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
