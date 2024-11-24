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
    public class AssertElementStaleTests : TestBase
    {
        // Define a data set for the ElementStale plugin
        private static IEnumerable<object[]> DataSet =>
        [
            [Stubs.RuleJsonBoolean, "ElementStale"],
            [Stubs.RuleJsonBoolean, "elementStale"],
            [Stubs.RuleJsonBoolean, "Stale"],
            [Stubs.RuleJsonBoolean, "stale"]
        ];

        [TestMethod(displayName: "Verify that the ElementStale plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ElementStale>();
        }

        [TestMethod(displayName: "Verify that the ElementStale plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ElementStale>();
        }

        [TestMethod(displayName: "Verify that the ElementStale plugin correctly evaluates " +
            "elements in negative scenarios.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementStaleNegativeTest(string ruleJson, string assertion)
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

            // Assert that the evaluation of the plugin is true (redundant check for emphasis)
            Assert.IsTrue(!session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementStale plugin handles NoSuchElementException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementStaleNoneTest(string ruleJson, string condition)
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

            // Assert that the evaluation of the plugin is false
            Assert.IsTrue(!session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementStale plugin handles NullReferenceException correctly.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementStaleNullTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is false
            Assert.IsTrue(!session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is false (redundant check for emphasis)
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the ElementStale plugin correctly evaluates " +
            "elements in positive scenarios.")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void ElementStaleTest(string ruleJson, string assertion)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//stale")
                .Replace(Stubs.OnCondition, assertion)
                .Replace(Stubs.OnPluginName, "Assert");

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation of the plugin is true
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());

            // Assert that the evaluation of the plugin is true (redundant check for emphasis)
            Assert.IsFalse(!session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
