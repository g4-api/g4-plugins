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
    [TestCategory("OperatorGreaterEqual")]
    [TestCategory("UnitTest")]
    public class OperatorGreaterEqualTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the GreaterEqualOperator plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<GreaterEqualOperator>();
        }

        [TestMethod(DisplayName = "Verify that the GreaterEqualOperator plugin named 'GreaterEqual' " +
            "complies with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<GreaterEqualOperator>(pluginName: "GreaterEqual");
        }

        [TestMethod(DisplayName = "Verify that the GreaterEqualOperator plugin evaluates " +
            "correctly in negative scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "Ge")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "ge")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "greaterEqual")]
        #endregion
        public void OperatorGreaterEqualNegativeTest(
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

            // Ensure the evaluation is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the GreaterEqualOperator plugin evaluates " +
            "correctly in positive scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "0", "Ge")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "0", "ge")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "0", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "0", "greaterEqual")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "-1", "Ge")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "-1", "ge")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "-1", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", ".//positive", "-1", "greaterEqual")]
        #endregion
        public void OperatorGreaterEqualTest(
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

            // Check if the evaluation returns true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
