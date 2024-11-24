using G4.Plugins.Ui.Assertions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("Assert")]
    [TestCategory("UnitTest")]
    public class AssertElementTextLengthTests : TestBase
    {
        #region *** Fields ***
        // Data set for equality tests
        public static IEnumerable<object[]> EqualDataSet =>
        [
            // Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Eq"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "eq"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Equal"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "equal"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Eq"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "eq"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Equal"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "equal"],
            // Element Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Eq"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "eq"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Equal"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "equal"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Eq"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "eq"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Equal"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "equal"]
        ];

        // Data set for inequality tests
        public static IEnumerable<object[]> NotEqualDataSet =>
        [
            // Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Ne"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "ne"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "NotEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "notEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Ne"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "ne"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "NotEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "notEqual"],
            // Element Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Ne"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "ne"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "NotEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "notEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Ne"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "ne"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "NotEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "notEqual"]
        ];

        // Data set for greater tests
        public static IEnumerable<object[]> GreaterDataSet =>
        [
            // Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Gt"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "gt"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Greater"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "greater"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Gt"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "gt"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Greater"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "greater"],
            // Element Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Gt"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "gt"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Greater"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "greater"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Gt"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "gt"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Greater"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "greater"]
        ];

        // Data set for greater or equal tests
        public static IEnumerable<object[]> GreaterEqualDataSet =>
        [
            // Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Ge"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "ge"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "GreaterEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "greaterEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Ge"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "ge"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "GreaterEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "greaterEqual"],
            // Element Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Ge"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "ge"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "GreaterEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "greaterEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Ge"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "ge"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "GreaterEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "greaterEqual"]
        ];

        // Data set for less tests
        public static IEnumerable<object[]> LowerEqualDataSet =>
        [
            // Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Le"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "le"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "LowerEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "lowerEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Le"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "le"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "LowerEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "lowerEqual"],
            // Element Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Le"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "le"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "LowerEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "lowerEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Le"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "le"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "LowerEqual"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "lowerEqual"]
        ];

        // Data set for less or equal tests
        public static IEnumerable<object[]> LowerDataSet =>
        [
            // Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Lt"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "lt"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Lower"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "lower"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Lt"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "lt"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Lower"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "lower"],
            // Element Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Lt"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "lt"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Lower"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "lower"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Lt"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "lt"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Lower"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "lower"]
        ];

        // Data set for match tests
        public static IEnumerable<object[]> MatchDataSet =>
        [
            // Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "Match"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "match"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "Match"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "match"],
            // Element Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "Match"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "match"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "Match"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "match"]
        ];

        // Data set for not match tests
        public static IEnumerable<object[]> NotMatchDataSet =>
        [
            // Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "NotMatch"],
            [Stubs.RuleJsonAttributeRegexOperator, "TextLength", "notMatch"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "NotMatch"],
            [Stubs.RuleJsonAttributeRegexOperator, "textLength", "notMatch"],
            // Element Text Length
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "NotMatch"],
            [Stubs.RuleJsonAttributeRegexOperator, "ElementTextLength", "notMatch"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "NotMatch"],
            [Stubs.RuleJsonAttributeRegexOperator, "elementTextLength", "notMatch"]
        ];
        #endregion

        [TestMethod(displayName: "Verify that the ElementTextLength plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ElementTextLength>();
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ElementTextLength>();
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length equality (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void AttributeTextLengthEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "10")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length equality.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void AttributeTextLengthEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "12")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length greater or equal (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(GreaterEqualDataSet))]
        #endregion
        public void AttributeTextLengthGreaterEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "13")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length greater or equal.")]
        #region *** Data Set ***
        // Text Length
        [DynamicData(dynamicDataSourceName: nameof(GreaterEqualDataSet))]
        #endregion
        public void AttributeTextLengthGreaterEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "11")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length greater than (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(GreaterDataSet))]
        #endregion
        public void AttributeTextLengthGreaterNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "12")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length greater than.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(GreaterDataSet))]
        #endregion
        public void AttributeTextLengthGreaterTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "10")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length less or equal (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(LowerEqualDataSet))]
        #endregion
        public void AttributeTextLengthLowerEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "10")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length less or equal.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(LowerEqualDataSet))]
        #endregion
        public void AttributeTextLengthLowerEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "12")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length less than (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(LowerDataSet))]
        #endregion
        public void AttributeTextLengthLowerNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "11")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length less than.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(LowerDataSet))]
        #endregion
        public void AttributeTextLengthLowerTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "13")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length match (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(MatchDataSet))]
        #endregion
        public void AttributeTextLengthMatchNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "11")
                .Replace(Stubs.OnRegularExpression, @"\\d+")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length match.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(MatchDataSet))]
        #endregion
        public void AttributeTextLengthMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnRegularExpression, @"\\d+")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length inequality (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NotEqualDataSet))]
        #endregion
        public void AttributeTextLengthNotEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "12")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length inequality.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NotEqualDataSet))]
        #endregion
        public void AttributeTextLengthNotEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "10")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length not match (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NotMatchDataSet))]
        #endregion
        public void AttributeTextLengthNotMatchNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnRegularExpression, @"\\d+")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "attribute text length not match.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NotMatchDataSet))]
        #endregion
        public void AttributeTextLengthNotMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, "text")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "11")
                .Replace(Stubs.OnRegularExpression, @"\\d+")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin handles " +
            "NoSuchElementException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void NoSuchElementExceptionTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (exception scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the plugin has thrown NoSuchElementException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is NoSuchElementException));
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin handles NullReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void NullReferenceExceptionTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (exception scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the plugin has thrown NullReferenceException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is NullReferenceException));
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin handles " +
            "StaleElementReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void StaleElementReferenceExceptionTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//stale")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (exception scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the plugin has thrown StaleElementReferenceException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is StaleElementReferenceException));
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
                "element text length equality (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void TextLengthEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "24")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length equality.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void TextLengthEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length greater or equal (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(GreaterEqualDataSet))]
        #endregion
        public void TextLengthGreaterEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "26")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length inequality.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NotEqualDataSet))]
        #endregion
        public void TextLengthNotEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "24")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length not match (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NotMatchDataSet))]
        #endregion
        public void TextLengthNotMatchNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnRegularExpression, @"\\d+")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length greater than.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(GreaterDataSet))]
        #endregion
        public void TextLengthGreaterTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "24")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length less or equal (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(LowerEqualDataSet))]
        #endregion
        public void TextLengthLowerEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "24")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length greater or equal.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(GreaterEqualDataSet))]
        #endregion
        public void TextLengthGreaterEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length greater than (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(GreaterDataSet))]
        #endregion
        public void TextLengthGreaterNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length less or equal.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(LowerEqualDataSet))]
        #endregion
        public void TextLengthLowerEqualTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length less than (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(LowerDataSet))]
        #endregion
        public void TextLengthLowerNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length less than.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(LowerDataSet))]
        #endregion
        public void TextLengthLowerTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "26")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length match (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(MatchDataSet))]
        #endregion
        public void TextLengthMatchNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, @"\\d+")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length match.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(MatchDataSet))]
        #endregion
        public void TextLengthMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "2")
                .Replace(Stubs.OnRegularExpression, @"\\d+")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length inequality (negative scenario).")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NotEqualDataSet))]
        #endregion
        public void TextLengthNotEqualNegativeTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (negative scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin correctly evaluates " +
            "element text length not match.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(NotMatchDataSet))]
        #endregion
        public void TextLengthNotMatchTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, @"\\d+")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true (positive scenario)
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin handles WebDriverException inside element correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void WebDriverExceptionInsideElementTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, ".//exception")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (exception scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the plugin has thrown WebDriverException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is WebDriverException));
        }

        [TestMethod(displayName: "Verify that the ElementTextLength plugin handles WebDriverException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(EqualDataSet))]
        #endregion
        public void WebDriverExceptionTest(string ruleJson, string condition, string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//exception")
                .Replace(Stubs.OnAttribute, string.Empty)
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, "25")
                .Replace(Stubs.OnRegularExpression, ".*")
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false (exception scenario)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the plugin has thrown WebDriverException
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is WebDriverException));
        }
    }
}
