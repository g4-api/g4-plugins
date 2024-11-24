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
    public class AssertPageUrlTests : TestBase
    {
        [TestMethod(displayName: "Verify that the PageUrl plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<PageUrl>();
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<PageUrl>();
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin correctly evaluates page URL equality.")]
        #region *** Data Set ***
        // Page URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "equal")]
        // URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "equal")]
        // Window URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "equal")]
        #endregion
        public void PageUrlEqualTest(string ruleJson, string condition, string @operator)
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

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin correctly evaluates page URL inequality.")]
        #region *** Data Set ***
        // Page URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "notEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "notEqual")]
        // URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "notEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "notEqual")]
        // Window URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "notEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "notEqual")]
        #endregion
        public void PageUrlNotEqualTest(string ruleJson, string condition, string @operator)
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
            Assert.IsTrue(session.ResponseData.Extractions .GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin correctly evaluates page URL greater than.")]
        #region *** Data Set ***
        // Page URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "greater")]
        // URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "greater")]
        // Window URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "greater")]
        #endregion
        public void PageUrlGreaterTest(string ruleJson, string condition, string @operator)
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

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin correctly evaluates page URL greater or equal.")]
        #region *** Data Set ***
        // Page URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "greaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "greaterEqual")]
        // URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "greaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "greaterEqual")]
        // Window URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "greaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "greaterEqual")]
        #endregion
        public void PageUrlGreaterEqualTest(string ruleJson, string condition, string @operator)
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

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin correctly evaluates page URL less or equal.")]
        #region *** Data Set ***
        // Page URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "lowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "lowerEqual")]
        // URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "lowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "lowerEqual")]
        // Window URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "lowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "lowerEqual")]
        #endregion
        public void PageUrlLowerEqualTest(string ruleJson, string condition, string @operator)
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

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin correctly evaluates page URL less than.")]
        #region *** Data Set ***
        // Page URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "lower")]
        // URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "lower")]
        // Window URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "lower")]
        #endregion
        public void PageUrlLowerTest(string ruleJson, string condition, string @operator)
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

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin correctly evaluates page URL match.")]
        #region *** Data Set ***
        // Page URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "Match")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "Match")]
        // URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "Match")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "Match")]
        // Window URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "Match")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "Match")]
        #endregion
        public void PageUrlMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "http://positive.io/20")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the PageUrl plugin correctly evaluates page URL not match.")]
        #region *** Data Set ***
        // Page URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageUrl", "NotMatch")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageUrl", "NotMatch")]
        // URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Url", "NotMatch")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "url", "NotMatch")]
        // Window URL
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Address", "NotMatch")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "address", "NotMatch")]
        #endregion
        public void PageUrlNotMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "http://someother.io")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
