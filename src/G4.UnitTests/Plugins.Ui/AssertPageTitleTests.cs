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
    public class AssertPageTitleTests : TestBase
    {
        [TestMethod(displayName: "Verify that the PageTitle plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<PageTitle>();
        }

        [TestMethod(displayName: "Verify that the PageTitle plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<PageTitle>();
        }

        [TestMethod(displayName: "Verify that the PageTitle plugin correctly evaluates " +
            "page title equality.")]
        #region *** Data Set ***
        // Page Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "equal")]
        // Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "equal")]
        // Window Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "eq")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Equal")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "equal")]
        #endregion
        public void PageTitleEqualTest(string ruleJson, string condition, string @operator)
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

        [TestMethod(displayName: "Verify that the PageTitle plugin correctly evaluates " +
            "page title inequality.")]
        #region *** Data Set ***
        // Page Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "notEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "notEqual")]
        // Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "notEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "notEqual")]
        // Window Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "notEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "ne")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "NotEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "notEqual")]
        #endregion
        public void PageTitleNotEqualTest(string ruleJson, string condition, string @operator)
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

        [TestMethod(displayName: "Verify that the PageTitle plugin correctly evaluates " +
            "page title greater than.")]
        #region *** Data Set ***
        // Page Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "greater")]
        // Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "greater")]
        // Window Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "gt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Greater")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "greater")]
        #endregion
        public void PageTitleGreaterTest(string ruleJson, string condition, string @operator)
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

        [TestMethod(displayName: "Verify that the PageTitle plugin correctly evaluates " +
            "page title greater or equal.")]
        #region *** Data Set ***
        // Page Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "greaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "greaterEqual")]
        // Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "greaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "greaterEqual")]
        // Window Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "greaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "ge")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "greaterEqual")]
        #endregion
        public void PageTitleGreaterEqualTest(string ruleJson, string condition, string @operator)
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

        [TestMethod(displayName: "Verify that the PageTitle plugin correctly evaluates " +
            "page title less or equal.")]
        #region *** Data Set ***
        // Page Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "lowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "lowerEqual")]
        // Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "lowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "lowerEqual")]
        // Window Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "lowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "le")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "LowerEqual")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "lowerEqual")]
        #endregion
        public void PageTitleLowerEqualTest(string ruleJson, string condition, string @operator)
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

        [TestMethod(displayName: "Verify that the PageTitle plugin correctly evaluates " +
            "page title less than.")]
        #region *** Data Set ***
        // Page Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "lower")]
        // Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "lower")]
        // Window Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "lt")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Lower")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "lower")]
        #endregion
        public void PageTitleLowerTest(string ruleJson, string condition, string @operator)
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

        [TestMethod(displayName: "Verify that the PageTitle plugin correctly evaluates " +
            "page title match.")]
        #region *** Data Set ***
        // Page Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "Match")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "Match")]
        // Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "Match")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "Match")]
        // Window Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "Match")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "Match")]
        #endregion
        public void PageTitleMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "^Mock G4™ API Page Title 20$")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the PageTitle plugin correctly evaluates " +
            "page title not match.")]
        #region *** Data Set ***
        // Page Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "PageTitle", "NotMatch")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "pageTitle", "NotMatch")]
        // Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "Title", "NotMatch")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "title", "NotMatch")]
        // Window Title
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "WindowTitle", "NotMatch")]
        [DataRow(Stubs.RuleJsonArgumentRegularExpressionOperator, "windowTitle", "NotMatch")]
        #endregion
        public void PageTitleNotMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "Some Other Title")
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
