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
    public class AssertWindowCountTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the WindowCount plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<WindowCount>();
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<WindowCount>();
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count equality (negative scenario).")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "equal")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "equal")]
        #endregion
        public void WindowCountEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count equality.")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "equal")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "equal")]
        #endregion
        public void WindowCountEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "1")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count greater or equal (negative scenario).")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "greaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "greaterEqual")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "greaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "greaterEqual")]
        #endregion
        public void WindowCountGreaterEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count inequality.")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "notEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "notEqual")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "notEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "notEqual")]
        #endregion
        public void WindowCountNotEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count not match (negative scenario).")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "notMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "notMatch")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "notMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "notMatch")]
        #endregion
        public void WindowCountNotMatchNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "1")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count greater than.")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "greater")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "greater")]
        #endregion
        public void WindowCountGreaterTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "0")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count less or equal (negative scenario).")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "lowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "lowerEqual")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "lowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "lowerEqual")]
        #endregion
        public void WindowCountLowerEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "0")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count greater or equal.")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "greaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "greaterEqual")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "greaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "ge")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "greaterEqual")]
        #endregion
        public void WindowCountGreaterEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "1")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count greater than (negative scenario).")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "greater")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "gt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Greater")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "greater")]
        #endregion
        public void WindowCountGreaterNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "1")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count less or equal.")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "lowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "lowerEqual")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "lowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "le")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "LowerEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "lowerEqual")]
        #endregion
        public void WindowCountLowerEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "1")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count less than (negative scenario).")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "lower")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "lower")]
        #endregion
        public void WindowCountLowerNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "0")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count less than.")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "lower")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "lt")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Lower")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "lower")]
        #endregion
        public void WindowCountLowerTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count match (negative scenario).")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "match")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "match")]
        #endregion
        public void WindowCountMatchNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count match.")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "match")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "match")]
        #endregion
        public void WindowCountMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "1")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count inequality (negative scenario).")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "notEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "notEqual")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "notEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "notEqual")]
        #endregion
        public void WindowCountNotEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "1")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the WindowCount plugin correctly evaluates " +
            "window count not match.")]
        #region *** Data Set ***
        // Window Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowCount", "notMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowCount", "notMatch")]
        // Windows Count
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "WindowsCount", "notMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "windowsCount", "notMatch")]
        #endregion
        public void WindowCountNotMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
