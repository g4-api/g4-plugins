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
    public class AssertElementNotVisibleTests : TestBase
    {
        // Define a data set for the ElementNotVisible plugin
        private static IEnumerable<object[]> DataSet =>
        [
            [Stubs.RuleJsonBoolean, "ElementNotVisible"],
            [Stubs.RuleJsonBoolean, "elementNotVisible"],
            [Stubs.RuleJsonBoolean, "NotVisible"],
            [Stubs.RuleJsonBoolean, "notVisible"],
            [Stubs.RuleJsonBoolean, "Hidden"],
            [Stubs.RuleJsonBoolean, "hidden"],
            [Stubs.RuleJsonBoolean, "NotDisplayed"],
            [Stubs.RuleJsonBoolean, "notDisplayed"]
        ];

        [TestMethod(displayName: "Verify that the ElementNotVisible plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ElementNotVisible>();
        }

        [TestMethod(displayName: "Verify that the ElementNotVisible plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ElementNotVisible>();
        }

        [TestMethod(displayName: "Verify that the ElementNotVisible plugin correctly evaluates " +
            "elements in negative scenarios.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementNotVisibleNegativeTest(string ruleJson, string assertion)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, ".//positive")
                .Replace(Stubs.OnCondition, assertion)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementNotVisible plugin handles NoSuchElementException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementNotVisibleNoneTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that a NoSuchElementException was thrown
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is NoSuchElementException));

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementNotVisible plugin handles NullReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementNotVisibleNullTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that a NullReferenceException was thrown
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is NullReferenceException));

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementNotVisible plugin handles StaleElementReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementNotVisibleStaleTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, ".//stale")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that a StaleElementReferenceException was thrown
            Assert.IsTrue(session.ResponseData.Exceptions.Any(i => i.Exception is StaleElementReferenceException));

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementNotVisible plugin correctly evaluates " +
            "elements in positive scenarios.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementNotVisibleTest(string ruleJson, string assertion)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//negative")
                .Replace(Stubs.OnCondition, assertion)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
