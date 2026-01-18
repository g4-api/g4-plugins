using G4.Plugins.Ui.Assertions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("Assert")]
    [TestCategory("UnitTest")]
    public class AssertElementTextTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the ElementText plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ElementText>();
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ElementText>();
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin correctly evaluates " +
            "element text equality.")]
        #region *** Data Set ***
        // Element Text
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "equal")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "equal")]
        #endregion
        public void ElementTextEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "20")
                .Replace(Stubs.OnRegularExpression, @"\\d+$")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin correctly evaluates " +
            "element text inequality.")]
        #region *** Data Set ***
        // Element Text
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "notEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "notEqual")]
        #endregion
        public void ElementTextNotEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "Mock: Positive Element 20")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin correctly evaluates " +
            "element text greater than.")]
        #region *** Data Set ***
        // Element Text
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "greater")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "greater")]
        #endregion
        public void ElementTextGreaterTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "9")
                .Replace(Stubs.OnRegularExpression, @"\\d+$")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin correctly evaluates " +
            "element text greater or equal.")]
        #region *** Data Set ***
        // Element Text
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "greaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "greaterEqual")]
        #endregion
        public void ElementTextGreaterEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "10")
                .Replace(Stubs.OnRegularExpression, @"\\d+$")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin correctly evaluates " +
            "element text less than.")]
        #region *** Data Set ***
        // Element Text
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "lower")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "lower")]
        #endregion
        public void ElementTextLowerTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "21")
                .Replace(Stubs.OnRegularExpression, @"\\d+$")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin correctly evaluates " +
            "element text less or equal.")]
        #region *** Data Set ***
        // Element Text
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "lowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "lowerEqual")]
        #endregion
        public void ElementTextLowerEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "20")
                .Replace(Stubs.OnRegularExpression, @"\\d+$")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin correctly evaluates " +
            "element text match.")]
        #region *** Data Set ***
        // Element Text
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "Match")]
        #endregion
        public void ElementTextMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "^Mock: Positive Element 20$")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the ElementText plugin correctly evaluates " +
            "element text not match.")]
        #region *** Data Set ***
        // Element Text
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "ElementText", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeRegexOperator, "elementText", "NotMatch")]
        #endregion
        public void ElementTextNotMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "Some Other Text")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
