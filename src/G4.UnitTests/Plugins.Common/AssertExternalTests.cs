using G4.Models;
using G4.UnitTests.Attributes;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    public class AssertExternalTests : TestBase
    {
        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> DataSet =>
        [
            // Equal
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "Eq"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "eq"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "Equal"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "equal"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "Eq"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "eq"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "Equal"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "equal"],
            // Not Equal
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "1", "Ne"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "1", "ne"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "1", "NotEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "1", "notEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "1", "Ne"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "1", "ne"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "1", "NotEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "1", "notEqual"],
            // Greater Than
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "-1", "Gt"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "-1", "gt"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "-1", "Greater"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "-1", "greater"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "-1", "Gt"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "-1", "gt"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "-1", "Greater"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "-1", "greater"],
            // Lower Than
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "1", "Lt"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "1", "lt"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "1", "Lower"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "1", "lower"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "1", "Lt"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "1", "lt"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "1", "Lower"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "1", "lower"],
            // Greater or Equal
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "Ge"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "ge"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "GreaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "greaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "Ge"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "ge"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "GreaterEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "greaterEqual"],
            // Lower or Equal
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "Le"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "LowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "le"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "ExternalAssertion", "0", "lowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "Le"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "LowerEqual"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "le"],
            [Stubs.RuleJsonAttributeOperator, "index", ".//positive", "externalAssertion", "0", "lowerEqual"],
            // Match
            [Stubs.RuleJsonAttributeOperator, "random", ".//positive", "ExternalAssertion", "Foo Bar", "Match"],
            [Stubs.RuleJsonAttributeOperator, "random", ".//positive", "ExternalAssertion", "Foo Bar", "match"],
            [Stubs.RuleJsonAttributeOperator, "random", ".//positive", "externalAssertion", "Foo Bar", "Match"],
            [Stubs.RuleJsonAttributeOperator, "random", ".//positive", "externalAssertion", "Foo Bar", "match"],
            // Not Match
            [Stubs.RuleJsonAttributeOperator, "random", ".//positive", "ExternalAssertion", "Bar Foo", "NotMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", ".//positive", "ExternalAssertion", "Bar Foo", "notMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", ".//positive", "externalAssertion", "Bar Foo", "NotMatch"],
            [Stubs.RuleJsonAttributeOperator, "random", ".//positive", "externalAssertion", "Bar Foo", "notMatch"]
        ];

        [RetryableTestMethod(
            displayName: "Verify that the ExternalAssertion plugin correctly evaluates nested conditions in a positive scenario.",
            numberOfAttempts: 5,
            DelayBetweenAttempts = 3000)]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ExternalAssertionTest(
            string ruleJson,
            string onAttribute,
            string onElement,
            string onCondition,
            string onOperatorExpected,
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

            // Define the capabilities for the WebDriver session.
            var capabilities = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["exceptions"] = "true"
            };

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel], capabilities).Response.First().Value.Sessions.First().Value;

            // Assert that the plugin evaluation is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
