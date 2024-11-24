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
    [TestCategory("OperatorGreater")]
    [TestCategory("UnitTest")]
    public class OperatorGreaterTests : TestBase
    {
        [TestMethod(displayName: "Verify that the GreaterOperator plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<GreaterOperator>();
        }

        [TestMethod(displayName: "Verify that the GreaterOperator plugin named 'Greater' complies " +
            "with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<GreaterOperator>(pluginName: "Greater");
        }

        [TestMethod(displayName: "Verify that the GreaterOperator plugin evaluates correctly " +
            "in negative scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "Gt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "gt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "Greater")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "greater")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "Gt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "gt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "Greater")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "greater")]
        #endregion
        public void OperatorGreaterNegativeTest(
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

            // Check if the evaluation returns false
            Assert.IsTrue(!session.ResponseData.Extractions.GetEvaluation());

            // Ensure the evaluation is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the GreaterOperator plugin evaluates correctly " +
            "in positive scenarios.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "-1", "ElementAttribute", ".//positive", "Gt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "-1", "ElementAttribute", ".//positive", "gt")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "-1", "ElementAttribute", ".//positive", "Greater")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "-1", "ElementAttribute", ".//positive", "greater")]
        #endregion
        public void OperatorGreaterTest(
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

            // Ensure the evaluation is not false
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
