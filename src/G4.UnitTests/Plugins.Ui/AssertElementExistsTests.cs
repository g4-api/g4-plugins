using G4.Plugins.Ui.Assertions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("Assert")]
    [TestCategory("UnitTest")]
    public class AssertElementExistsTests : TestBase
    {
        // Define a data set for the ElementExists plugin
        private static IEnumerable<object[]> DataSet =>
        [
            [Stubs.RuleJsonBoolean, "ElementExists"],
            [Stubs.RuleJsonBoolean, "elementExists"],
            [Stubs.RuleJsonBoolean, "Exists"],
            [Stubs.RuleJsonBoolean, "exists"]
        ];

        [TestMethod(DisplayName = "Verify that the ElementExists plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ElementExists>();
        }

        [TestMethod(DisplayName = "Verify that the ElementExists plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ElementExists>();
        }

        [TestMethod(DisplayName = "Verify that the ElementExists plugin correctly evaluates " +
            "elements in negative scenarios.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementExistsNegativeTest(string ruleJson, string assertion)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//none")
                .Replace(Stubs.OnCondition, assertion)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(DisplayName = "Verify that the ElementExists plugin handles StaleElementReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementExistsStaleTest(string ruleJson, string condition)
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

        [TestMethod(DisplayName = "Verify that the ElementExists plugin correctly evaluates " +
            "elements in positive scenarios.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementExistsTest(string ruleJson, string assertion)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, assertion)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
