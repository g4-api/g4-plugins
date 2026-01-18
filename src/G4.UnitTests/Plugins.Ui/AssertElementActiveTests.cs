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

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("Assert")]
    [TestCategory("UnitTest")]
    public class AssertElementActiveTests : TestBase
    {
        // Define a data set for the ElementActive plugin
        private static IEnumerable<object[]> DataSet =>
        [
            [Stubs.RuleJsonBoolean, "ElementActive"],
            [Stubs.RuleJsonBoolean, "elementActive"],
            [Stubs.RuleJsonBoolean, "Active"],
            [Stubs.RuleJsonBoolean, "active"],
            [Stubs.RuleJsonBoolean, "HasFocus"],
            [Stubs.RuleJsonBoolean, "hasFocus"]
        ];

        [TestMethod(DisplayName = "Verify that ElementActive plugin correctly evaluates " +
            "elements in positive scenarios.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementActiveTest(string ruleJson, string assertion)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, assertion)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that ElementActive plugin handles NoSuchElementException correctly.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementActiveNoSuchElementExceptionTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that a NoSuchElementException was thrown
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is NoSuchElementException));

            // Assert that the evaluation result is false.
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that ElementActive plugin handles NullReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementActiveNullReferenceExceptionTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that a NullReferenceException was thrown
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is NullReferenceException));

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that ElementActive plugin handles negative cases correctly.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementActiveNegativeTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//negative")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation result is false.
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that ElementActive plugin handles StaleElementReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementActiveStaleElementReferenceExceptionTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, ".//stale")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that a StaleElementReferenceException was thrown
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is StaleElementReferenceException));

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that ElementActive plugin handles WebDriverException correctly.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementActiveWebDriverExceptionTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//exception")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is WebDriverException));

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that ElementActive plugin can be successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<ElementActive>();
        }

        [TestMethod(DisplayName = "Verify that ElementActive plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<ElementActive>();
        }
    }
}
