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
    [TestCategory("OperatorLower")]
    [TestCategory("UnitTest")]
    public class OperatorLowerTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the LowerOperator plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<LowerOperator>();
        }

        [TestMethod(DisplayName = "Verify that the LowerOperator plugin named 'Lower' complies " +
            "with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<LowerOperator>(pluginName: "Lower");
        }

        [TestMethod(DisplayName = "Verify that the LowerOperator plugin evaluates correctly " +
            "in negative scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "0", "Lt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "0", "lt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "0", "Lower")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "0", "lower")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "-1", "Lt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "-1", "lt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "-1", "Lower")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "-1", "lower")]
        #endregion
        public void OperatorLowerNegativeTest(
            string ruleJson,
            string onAttribute,
            string onCondition,
            string onElement,
            string onOperatorExpected,
            string onOperator)
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

            // Ensure the evaluation is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the LowerOperator plugin evaluates correctly " +
            "in positive scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "Lt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "lt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "Lower")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "lower")]
        #endregion
        public void OperatorLowerTest(
            string ruleJson,
            string onAttribute,
            string onOperatorExpected,
            string onCondition,
            string onElement,
            string onOperator)
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
