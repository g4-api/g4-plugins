using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("SetCondition")]
    [TestCategory("UnitTest")]
    public class SetConditionExternalTests : TestBase
    {
        [TestMethod(displayName: "Verify that the SetCondition plugin is correctly registered " +
            "and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetCondition>();
        }

        [TestMethod(displayName: "Verify that the SetCondition plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetCondition>();
        }

        [TestMethod(displayName: "Verify that the SetCondition plugin evaluates conditions " +
            "correctly in positive scenarios.")]
        #region *** Data Set ***
        // Equal
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "Eq")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "Equal")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "eq")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "equal")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "Eq")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "Equal")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "eq")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "equal")]
        // Not Equal
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "ExternalAssertion", ".//positive", "Ne")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "ExternalAssertion", ".//positive", "NotEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "ExternalAssertion", ".//positive", "ne")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "ExternalAssertion", ".//positive", "notEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "externalAssertion", ".//positive", "Ne")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "externalAssertion", ".//positive", "NotEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "externalAssertion", ".//positive", "ne")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "externalAssertion", ".//positive", "notEqual")]
        // Greate Than
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "-1", "ExternalAssertion", ".//positive", "Gt")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "-1", "ExternalAssertion", ".//positive", "Greater")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "-1", "ExternalAssertion", ".//positive", "gt")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "-1", "ExternalAssertion", ".//positive", "greater")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "-1", "externalAssertion", ".//positive", "Gt")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "-1", "externalAssertion", ".//positive", "Greater")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "-1", "externalAssertion", ".//positive", "gt")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "-1", "externalAssertion", ".//positive", "greater")]
        // Lower Than
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "ExternalAssertion", ".//positive", "Lt")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "ExternalAssertion", ".//positive", "lt")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "ExternalAssertion", ".//positive", "Lower")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "ExternalAssertion", ".//positive", "lower")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "externalAssertion", ".//positive", "Lt")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "externalAssertion", ".//positive", "lt")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "externalAssertion", ".//positive", "Lower")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "1", "externalAssertion", ".//positive", "lower")]
        // Greater or Equal
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "Ge")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "ge")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "greaterEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "Ge")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "ge")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "GreaterEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "greaterEqual")]
        // Lower or Equal
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "Le")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "LowerEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "le")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "ExternalAssertion", ".//positive", "lowerEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "Le")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "LowerEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "le")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "index", "0", "externalAssertion", ".//positive", "lowerEqual")]
        // Match
        [DataRow(Stubs.RuleJsonConditionDynamic, "random", "Foo Bar", "ExternalAssertion", ".//positive", "Match")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "random", "Foo Bar", "ExternalAssertion", ".//positive", "match")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "random", "Foo Bar", "externalAssertion", ".//positive", "Match")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "random", "Foo Bar", "externalAssertion", ".//positive", "match")]
        // Not Match
        [DataRow(Stubs.RuleJsonConditionDynamic, "random", "Bar Foo", "ExternalAssertion", ".//positive", "NotMatch")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "random", "Bar Foo", "ExternalAssertion", ".//positive", "notMatch")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "random", "Bar Foo", "externalAssertion", ".//positive", "NotMatch")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "random", "Bar Foo", "externalAssertion", ".//positive", "notMatch")]
        #endregion
        public void SetConditionPositiveTest(
            string ruleJson,
            string onAttribute,
            string onOperatorExpected,
            string onCondition,
            string onElement,
            string onOperator)
        {
            // Replace placeholders in the rule JSON with the provided parameters.
            ruleJson = ruleJson
                .Replace(Stubs.OnAttribute, onAttribute)
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement);

            // Set external parameters for the automation.
            Automation.SetExternal(new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["exceptions"] = "true"
            });

            // Deserialize the modified rule JSON into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<G4RuleModelBase>(ruleJson, JsonOptions);

            // Invoke the action rule and get the response.
            var responseModel = Invoke([ruleModel]);

            // Retrieve the parameter value from the response and decode it from Base64.
            var actual = responseModel
                .GetParameterValue(parameterName: "TestParameter", scope: "Session")
                .ConvertFromBase64();

            // Assert that the actual parameter value matches the expected value.
            Assert.AreEqual(expected: "Foo Bar", actual);
        }
    }
}
