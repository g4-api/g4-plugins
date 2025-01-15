using G4.Models;
using G4.Plugins.Ui.Assertions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.Json;

using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("Assert")]
    [TestCategory("UnitTest")]
    public class AssertDriverTypeNameTests : TestBase
    {
        // The expected driver type for the simulator driver for the positive test
        private const string Positive = "G4.WebDriver.Simulator.SimulatorDriver";

        // The driver type that is not the simulator driver for the negative test
        private const string Negative = "G4.WebDriver.Simulator.ChromeDriver";

        [TestMethod(displayName: "Verify that the DriverTypeName plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<DriverTypeName>();
        }

        [TestMethod(displayName: "Verify that the DriverTypeName plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<DriverTypeName>();
        }

        [TestMethod(displayName: "Verify that the DriverTypeName plugin correctly evaluates " +
            "various conditions.")]
        #region *** Data Set ***
        // Equal
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Positive, "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Positive, "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Positive, "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Positive, "equal")]
        // NotEqual
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Negative, "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Negative, "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Negative, "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Negative, "notEqual")]
        // Match
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "SimulatorDriver", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "SimulatorDriver", "match")]
        // NotMatch
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "ChromeDriver", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "ChromeDriver", "notMatch")]
        #endregion
        public void DriverTypeNameTest(string ruleJson, string expected, string @operator)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, "DriverTypeName")
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation result is true.
            Assert.IsTrue(session.ResponseData.Extractions.GetEvaluation());
        }

        [TestMethod(displayName: "Verify that the DriverTypeName plugin correctly evaluates " +
            "negative conditions.")]
        #region *** Data Set ***
        // Equal
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Negative, "Eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Negative, "Equal")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Negative, "eq")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Negative, "equal")]
        // NotEqual
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Positive, "Ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Positive, "NotEqual")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Positive, "ne")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, Positive, "notEqual")]
        // Match
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "SimulatorDriver", "NotMatch")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "SimulatorDriver", "notMatch")]
        // NotMatch
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "ChromeDriver", "Match")]
        [DataRow(Stubs.RuleJsonNoAttributeOperator, "ChromeDriver", "match")]
        #endregion
        public void DriverTypeNameNegativeTest(string ruleJson, string expected, string @operator)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, "DriverTypeName")
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnPluginName, "Assert");

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the evaluation result is false.
            Assert.IsFalse(session.ResponseData.Extractions.GetEvaluation());
        }
    }
}
