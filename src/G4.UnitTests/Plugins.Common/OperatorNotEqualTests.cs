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
    [TestCategory("OperatorNotEqual")]
    [TestCategory("UnitTest")]
    public class OperatorNotEqualTests : TestBase
    {
        [TestMethod(displayName: "Verify that the NotEqualOperator plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<NotEqualOperator>();
        }

        [TestMethod(displayName: "Verify that the NotEqualOperator plugin named 'NotEqual' complies " +
            "with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<NotEqualOperator>(pluginName: "NotEqual");
        }

        [TestMethod(displayName: "Verify that the NotEqualOperator plugin evaluates correctly " +
            "in negative scenarios.")]
        #region *** Test Data ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "Ne"     )]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "NotEqual")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "ne"     )]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "0", "ElementAttribute", ".//positive", "notEqual")]
        #endregion
        public void OperatorNotEqualNegativeTest(
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

        [TestMethod(displayName: "Verify that the NotEqualOperator plugin evaluates correctly " +
            "in positive scenarios.")]
        #region *** Test Data ***
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "a", "ElementAttribute", ".//positive", "Ne"     )]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "a", "ElementAttribute", ".//positive", "NotEqual")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "a", "ElementAttribute", ".//positive", "ne"     )]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "a", "ElementAttribute", ".//positive", "notEqual")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "Ne"     )]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "NotEqual")]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "ne"     )]
        [DataRow(Stubs.RuleJsonAttributeOperator, "index", "1", "ElementAttribute", ".//positive", "notEqual")]
        #endregion
        public void OperatorNotEqualTest(
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
