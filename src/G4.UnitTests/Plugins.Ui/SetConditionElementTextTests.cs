using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Attributes;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetCondition")]
    [TestCategory("UnitTest")]
    public class SetConditionElementTextTests : TestBase
    {
        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> DataSet =>
        [
            // Element Text: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "Mock: Positive Element 20", "Eq", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "Mock: Positive Element 20", "Equal", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "Mock: Positive Element 20", "eq", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "Mock: Positive Element 20", "equal", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "Mock: Positive Element 20", "Eq", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "Mock: Positive Element 20", "Equal", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "Mock: Positive Element 20", "eq", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "Mock: Positive Element 20", "equal", ".*"],
            // Element Text: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "Mock: Positive Element 21", "Ne", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "Mock: Positive Element 21", "NotEqual", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "Mock: Positive Element 21", "ne", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "Mock: Positive Element 21", "notEqual", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "Mock: Positive Element 21", "Ne", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "Mock: Positive Element 21", "NotEqual", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "Mock: Positive Element 21", "ne", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "Mock: Positive Element 21", "notEqual", ".*"],
            // Element Text: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", @"^Mock: Positive Element \\d+$", "Match", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", @"^Mock: Positive Element \\d+$", "match", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", @"^Mock: Positive Element \\d+$", "Match", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", @"^Mock: Positive Element \\d+$", "match", ".*"],
            // Element Text: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", @"^\\d+ Mock: Positive Element$", "NotMatch", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", @"^\\d+ Mock: Positive Element$", "notMatch", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", @"^\\d+ Mock: Positive Element$", "NotMatch", ".*"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", @"^\\d+ Mock: Positive Element$", "notMatch", ".*"],
            // Element Text: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "21", "Lt", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "21", "lt", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "21", "Lt", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "21", "lt", @"\\d+"],
            // Element Text: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "19", "Gt", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "19", "gt", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "19", "Gt", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "19", "gt", @"\\d+"],
            // Element Text: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "20", "Le", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "20", "le", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "20", "Le", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "20", "le", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "21", "Le", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "21", "le", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "21", "Le", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "21", "le", @"\\d+"],
            // Element Text: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "20", "Ge", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "20", "ge", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "20", "Ge", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "20", "ge", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "19", "Ge", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementText", "19", "ge", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "19", "Ge", @"\\d+"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementText", "19", "ge", @"\\d+"]
        ];

        [TestMethod(displayName: "Verify that element text assertions handle NoSuchElementException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementTextNoSuchElementExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string @operator,
           string regex)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a NoSuchElementException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NoSuchElementException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(displayName: "Verify that element text assertions handle NullReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementTextNullReferenceExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string @operator,
           string regex)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a NullReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NullReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(displayName: "Verify that element text assertions handle " +
            "StaleElementReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementTextStaleTest(
            string ruleJson,
            string condition,
            string expected,
            string @operator,
            string regex)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//stale")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a StaleElementReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is StaleElementReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(displayName: "Verify that element text assertions are evaluated correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementTextTest(
           string ruleJson,
           string condition,
           string expected,
           string @operator,
           string regex)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that no exceptions were thrown
            Assert.IsTrue(!responseModel.GetExceptions().Any());

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly
            Assert.AreEqual("Foo Bar", actual, ignoreCase: true);
        }

        [RetryableTestMethod(
            numberOfAttempts:5,
            displayName: "Verify that element text assertions handle WebDriverException correctly",
            DelayBetweenAttempts = 3000)]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementTextWebDriverExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string @operator,
           string regex)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//exception")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is WebDriverException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(displayName: "Verify that the plugin is correctly instantiated and operates as expected")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetCondition>();
        }

        [TestMethod(displayName: "Verify that the plugin's manifest complies with expected " +
            "standards and specifications")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetCondition>();
        }
    }
}
