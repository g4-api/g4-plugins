using G4.Models;
using G4.Plugins.Ui.Assertions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("Assert")]
    [TestCategory("UnitTest")]
    public class AssertElementAttributeTests : TestBase
    {
        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> DataSet =>
        [
            // Element Attribute: Equal
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "Eq"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "Equal"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "eq"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "equal"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "Eq"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "Equal"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "eq"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "equal"],
            // Element Attribute: NotEqual
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "1", "Ne"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "1", "NotEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "1", "ne"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "1", "notEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "1", "Ne"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "1", "NotEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "1", "ne"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "1", "notEqual"],
            // Element Attribute: Greater
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "-1", "Gt"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "-1", "Greater"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "-1", "gt"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "-1", "greater"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "-1", "Gt"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "-1", "Greater"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "-1", "gt"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "-1", "greater"],
            // Element Attribute: Lower
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "1", "Lt"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "1", "lt"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "1", "Lower"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "1", "lower"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "1", "Lt"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "1", "lt"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "1", "Lower"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "1", "lower"],
            // Element Attribute: GreaterEqual
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "Ge"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "ge"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "GreaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "greaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "Ge"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "ge"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "GreaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "greaterEqual"],
            // Element Attribute: LowerEqual
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "Le"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "LowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "le"],
            [Stubs.RuleJsonAttributeOperator, "index", "ElementAttribute", "0", "lowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "Le"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "LowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "le"],
            [Stubs.RuleJsonAttributeOperator, "index", "elementAttribute", "0", "lowerEqual"],
            // Element Attribute: Match
            [Stubs.RuleJsonAttributeOperator, "random", "ElementAttribute", @"^mock attribute value \\d+$", "Match"],
            [Stubs.RuleJsonAttributeOperator, "random", "ElementAttribute", @"^mock attribute value \\d+$", "match"],
            [Stubs.RuleJsonAttributeOperator, "random", "elementAttribute", @"^mock attribute value \\d+$", "Match"],
            [Stubs.RuleJsonAttributeOperator, "random", "elementAttribute", @"^mock attribute value \\d+$", "match"],
            // Element Attribute: NotMatch
            [Stubs.RuleJsonAttributeOperator, "random", "ElementAttribute", @"^\\d+ mock attribute value$", "NotMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", "ElementAttribute", @"^\\d+ mock attribute value$", "notMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", "elementAttribute", @"^\\d+ mock attribute value$", "NotMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", "elementAttribute", @"^\\d+ mock attribute value$", "notMatch"],
            // Attribute: Equal
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "Eq"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "Equal"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "eq"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "equal"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "Eq"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "Equal"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "eq"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "equal"],
            // Attribute: NotEqual
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "1", "Ne"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "1", "NotEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "1", "ne"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "1", "notEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "1", "Ne"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "1", "NotEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "1", "ne"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "1", "notEqual"],
            // Attribute: Greater
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "-1", "Gt"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "-1", "Greater"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "-1", "gt"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "-1", "greater"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "-1", "Gt"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "-1", "Greater"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "-1", "gt"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "-1", "greater"],
            // Attribute: Lower
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "1", "Lt"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "1", "lt"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "1", "Lower"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "1", "lower"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "1", "Lt"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "1", "lt"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "1", "Lower"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "1", "lower"],
            // Attribute: GreaterEqual
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "Ge"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "ge"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "GreaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "greaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "Ge"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "ge"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "GreaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "greaterEqual"],
            // Attribute: LowerEqual
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "Le"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "LowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "le"],
            [Stubs.RuleJsonAttributeOperator, "index", "Attribute", "0", "lowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "Le"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "LowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "le"],
            [Stubs.RuleJsonAttributeOperator, "index", "attribute", "0", "lowerEqual"],
            // Attribute: Match
            [Stubs.RuleJsonAttributeOperator, "random", "Attribute", @"^mock attribute value \\d+$", "Match"],
            [Stubs.RuleJsonAttributeOperator, "random", "Attribute", @"^mock attribute value \\d+$", "match"],
            [Stubs.RuleJsonAttributeOperator, "random", "attribute", @"^mock attribute value \\d+$", "Match"],
            [Stubs.RuleJsonAttributeOperator, "random", "attribute", @"^mock attribute value \\d+$", "match"],
            // Attribute: NotMatch
            [Stubs.RuleJsonAttributeOperator, "random", "Attribute", @"^\\d+ mock attribute value$", "NotMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", "Attribute", @"^\\d+ mock attribute value$", "notMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", "attribute", @"^\\d+ mock attribute value$", "NotMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", "attribute", @"^\\d+ mock attribute value$", "notMatch"]
        ];

        [TestMethod(displayName: "Verify that the plugin is correctly instantiated and operates as expected")]
        public override void NewPluginTest()
        {
            AssertPlugin<ElementAttribute>();
        }

        [TestMethod(displayName: "Verify that the plugin's manifest complies with expected " +
            "standards and specifications")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ElementAttribute>();
        }

        [TestMethod(displayName: "Verify that attribute value assertions handle " +
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
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Initalize the evaluation variable based on the operator used in the
            // test case and the plugin's evaluation result
            var evaluation = @operator.StartsWith("N", StringComparison.OrdinalIgnoreCase)
                ? !session.ResponseData.Extractions.GetEvaluation() // The evaluation should be inverted for NotEqual and NotMatch operators
                : session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(evaluation);

            // Assert that the plugin's exceptions contain a StaleElementReferenceException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is StaleElementReferenceException));
        }

        [TestMethod(displayName: "Verify that attribute value assertions handle NoSuchElementException correctly")]
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
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Initalize the evaluation variable based on the operator used in the
            // test case and the plugin's evaluation result
            var evaluation = @operator.StartsWith("N", StringComparison.OrdinalIgnoreCase)
                ? !session.ResponseData.Extractions.GetEvaluation() // The evaluationis inverted for NotEqual and NotMatch operators
                : session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(evaluation);

            // Assert that the plugin's exceptions contain a NoSuchElementException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is NoSuchElementException));
        }

        [TestMethod(displayName: "Verify that attribute value assertions handle WebDriverException correctly")]
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
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Initalize the evaluation variable based on the operator used in the
            // test case and the plugin's evaluation result
            var evaluation = @operator.StartsWith("N", StringComparison.OrdinalIgnoreCase)
                ? !session.ResponseData.Extractions.GetEvaluation() // The evaluation should be inverted for NotEqual and NotMatch operators
                : session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(evaluation);

            // Assert that the plugin's exceptions contain a WebDriverException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is WebDriverException));
        }

        [TestMethod(displayName: "Verify that attribute value assertions handle NullReferenceException correctly")]
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
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Initalize the evaluation variable based on the operator used in the
            // test case and the plugin's evaluation result
            var evaluation = @operator.StartsWith("N", StringComparison.OrdinalIgnoreCase)
                ? !session.ResponseData.Extractions.GetEvaluation() // The evaluation should be inverted for NotEqual and NotMatch operators
                : session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(evaluation);

            // Assert that the plugin's exceptions contain a NullReferenceException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is NullReferenceException));
        }

        [TestMethod(displayName: "Verify that element attribute assertions are evaluated correctly")]
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
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Initalize the evaluation variable based on the operator used in the
            // test case and the plugin's evaluation result
            var evaluation = session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(evaluation);

            // Assert that the plugin's exceptions are empty
            Assert.IsNotNull(value: session.ResponseData.Exceptions);
            Assert.AreEqual(expected: 0, actual: session.ResponseData.Exceptions.Count());
        }
    }
}
