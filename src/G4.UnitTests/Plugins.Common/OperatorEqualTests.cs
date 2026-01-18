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
    [TestCategory("OperatorEqual")]
    [TestCategory("UnitTest")]
    public class OperatorEqualTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the EqualOperator plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<EqualOperator>();
        }

        [TestMethod(DisplayName = "Verify that the EqualOperator plugin named 'Equal' complies " +
            "with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<EqualOperator>(pluginName: "Equal");
        }

        [TestMethod(DisplayName = "Verify that the EqualOperator plugin evaluates correctly " +
            "in a negative scenario.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "a", "ElementAttribute", ".//positive", "Eq")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "a", "ElementAttribute", ".//positive", "Equal")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "a", "ElementAttribute", ".//positive", "eq")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "a", "ElementAttribute", ".//positive", "equal")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "Eq")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "Equal")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "eq")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "equal")]
        #endregion
        public void OperatorEqualNegativeTest(
            string ruleJson,
            string onAttribute,
            string onOperatorExpected,
            string onCondition,
            string onElement,
            string onOperator)
        {
            // Replace placeholders in the action rule with provided parameters
            ruleJson = ruleJson
                .Replace(Stubs.OnPluginName, "Assert")
                .Replace(Stubs.OnAttribute, onAttribute)
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement);

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assertion: Verify that the plugin evaluation is not true
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the EqualOperator plugin evaluates correctly " +
            "in a positive scenario.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "Eq")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "Equal")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "eq")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "equal")]
        #endregion
        public void OperatorEqualTest(
            string ruleJson,
            string onAttribute,
            string onOperatorExpected,
            string onCondition,
            string onElement,
            string onOperator)
        {
            // Replace placeholders in the action rule with provided parameters
            ruleJson = ruleJson
                .Replace(Stubs.OnPluginName, "Assert")
                .Replace(Stubs.OnAttribute, onAttribute)
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement);

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Check if the evaluation returns true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
