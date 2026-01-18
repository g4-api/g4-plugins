using G4.Extensions;
using G4.Plugins.Common.Actions;
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
    public class SetConditionElementAttributeTests : TestBase
    {
        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> DataSet =>
        [
            // Element Attribute: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "equal"],
            // Element Attribute: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "1", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "1", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "1", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "1", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "1", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "1", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "1", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "1", "notEqual"],
            // Element Attribute: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "-1", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "-1", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "-1", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "-1", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "-1", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "-1", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "-1", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "-1", "greater"],
            // Element Attribute: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "1", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "1", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "1", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "1", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "1", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "1", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "1", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "1", "lower"],
            // Element Attribute: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "greaterEqual"],
            // Element Attribute: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "ElementAttribute", "0", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "elementAttribute", "0", "lowerEqual"],
            // Element Attribute: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "ElementAttribute", @"^mock attribute value \\d+$", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "ElementAttribute", @"^mock attribute value \\d+$", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "elementAttribute", @"^mock attribute value \\d+$", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "elementAttribute", @"^mock attribute value \\d+$", "match"],
            // Element Attribute: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "ElementAttribute", @"^\\d+ mock attribute value$", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "ElementAttribute", @"^\\d+ mock attribute value$", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "elementAttribute", @"^\\d+ mock attribute value$", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "elementAttribute", @"^\\d+ mock attribute value$", "notMatch"],
            // Attribute: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "equal"],
            // Attribute: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "1", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "1", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "1", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "1", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "1", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "1", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "1", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "1", "notEqual"],
            // Attribute: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "-1", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "-1", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "-1", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "-1", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "-1", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "-1", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "-1", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "-1", "greater"],
            // Attribute: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "1", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "1", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "1", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "1", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "1", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "1", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "1", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "1", "lower"],
            // Attribute: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "greaterEqual"],
            // Attribute: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "Attribute", "0", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "index", "attribute", "0", "lowerEqual"],
            // Attribute: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "Attribute", @"^mock attribute value \\d+$", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "Attribute", @"^mock attribute value \\d+$", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "attribute", @"^mock attribute value \\d+$", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "attribute", @"^mock attribute value \\d+$", "match"],
            // Attribute: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "Attribute", @"^\\d+ mock attribute value$", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "Attribute", @"^\\d+ mock attribute value$", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "attribute", @"^\\d+ mock attribute value$", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "random", "attribute", @"^\\d+ mock attribute value$", "notMatch"]
        ];

        [TestMethod(DisplayName = "Verify that attribute value assertions handle NoSuchElementException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementAttributeNoSuchElementExceptionTest(
           string ruleJson,
           string attribute,
           string condition,
           string expected,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, attribute)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnRegularExpression, ".*");

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a StaleElementReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NoSuchElementException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that attribute value assertions handle NullReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementAttributeNullReferenceExceptionTest(
           string ruleJson,
           string attribute,
           string condition,
           string expected,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, attribute)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnRegularExpression, ".*");

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a StaleElementReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NullReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that attribute value assertions handle " +
            "StaleElementReferenceException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementAttributeStaleTest(
            string ruleJson,
            string attribute,
            string condition,
            string expected,
            string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, attribute)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//stale")
                .Replace(Stubs.OnRegularExpression, ".*");

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

        [TestMethod(DisplayName = "Verify that element attribute assertions are evaluated correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementAttributeTest(
           string ruleJson,
           string attribute,
           string condition,
           string expected,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, attribute)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnRegularExpression, ".*");

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

        [TestMethod(DisplayName = "Verify that attribute value assertions handle WebDriverException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementAttributeWebDriverExceptionTest(
           string ruleJson,
           string attribute,
           string condition,
           string expected,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, attribute)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, "//exception")
                .Replace(Stubs.OnRegularExpression, ".*");

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

        [TestMethod(DisplayName = "Verify that the plugin is correctly instantiated and operates as expected")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the plugin's manifest complies with expected " +
            "standards and specifications")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetCondition>();
        }
    }
}
