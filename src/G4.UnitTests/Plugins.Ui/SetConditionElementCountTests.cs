using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetCondition")]
    [TestCategory("UnitTest")]
    public class SetConditionElementCountTests : TestBase
    {
        // Initialize the positive data set for the test cases in this test class
        private static IEnumerable<object[]> PositiveDataSet =>
        [
            // Element Count: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", ".*", "equal"],
            // Element Count: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", ".*", "notEqual"],
            // Element Count: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "1", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "1", @"\\d+", "greater"],
            // Element Count: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "lower"],
            // Element Count: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "1", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "1", @"\\d+", "greaterEqual"],
            // Element Count: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "2", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "lowerEqual"],
            // Element Count: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "^2$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "^2$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "^2$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "^2$", ".*", "match"],
            // Element Count: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "^3$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "^3$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "^3$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "^3$", ".*", "notMatch"]
        ];

        // Initialize the negative data set for the test cases in this test class
        private static IEnumerable<object[]> NegativeDataSet =>
        [
            // Element Count: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", ".*", "equal"],
            // Element Count: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", ".*", "notEqual"],
            // Element Count: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "-1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "-1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "-1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "-1", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "-1", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "-1", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "-1", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "-1", @"\\d+", "greater"],
            // Element Count: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "lower"],
            // Element Count: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "-1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "-1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "-1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "-1", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "-1", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "-1", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "-1", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "-1", @"\\d+", "greaterEqual"],
            // Element Count: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "0", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "3", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "0", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "3", @"\\d+", "lowerEqual"],
            // Element Count: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "^0$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "^0$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "^0$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "^0$", ".*", "match"],
            // Element Count: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "^3$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "ElementCount", "^3$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "^3$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "elementCount", "^3$", ".*", "notMatch"]
        ];

        [TestMethod(DisplayName = "Verify that element count assertions handle NoSuchElementException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NegativeDataSet))]
        #endregion
        public void ElementCountNoSuchElementExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that no exceptions were thrown
            Assert.IsFalse(responseModel.GetExceptions().Any());

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly
            Assert.AreEqual("Foo Bar", actual, ignoreCase: true);
        }

        [TestMethod(DisplayName = "Verify that element count assertions handle NullReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NegativeDataSet))]
        #endregion
        public void ElementCountNullReferenceExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that no exceptions were thrown
            Assert.IsFalse(responseModel.GetExceptions().Any());

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly
            Assert.AreEqual("Foo Bar", actual, ignoreCase: true);
        }

        [TestMethod(DisplayName = "Verify that element count assertions handle StaleElementReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(PositiveDataSet))]
        #endregion
        public void ElementCountStaleElementReferenceExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
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

        [TestMethod(DisplayName = "Verify that element count assertions are evaluated correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(PositiveDataSet))]
        #endregion
        public void ElementCountTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that no exceptions were thrown
            Assert.IsFalse(responseModel.GetExceptions().Any());

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly
            Assert.AreEqual("Foo Bar", actual, ignoreCase: true);
        }

        [TestMethod(DisplayName = "Verify that element count assertions handle WebDriverException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(PositiveDataSet))]
        #endregion
        public void ElementCountWebDriverExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
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

        [TestMethod(DisplayName = "Verify that the plugin's manifest complies with expected " +
            "standards and specifications")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the plugin is correctly instantiated and " +
            "operates as expected")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetCondition>();
        }
    }
}
