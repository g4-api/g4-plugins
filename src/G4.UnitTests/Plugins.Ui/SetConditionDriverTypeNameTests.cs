using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetCondition")]
    [TestCategory("UnitTest")]
    public class SetConditionDriverTypeNameTests : TestBase
    {
        // The expected driver type for the simulator driver for the positive test
        private const string Positive = "G4.WebDriver.Simulator.SimulatorDriver";

        // The driver type that is not the simulator driver for the negative test
        private const string Negative = "G4.WebDriver.Simulator.ChromeDriver";

        [TestMethod(DisplayName = "Verify that the DriverTypeName condition in SetCondition plugin correctly evaluates " +
            "negative conditions.")]
        #region *** Data Set ***
        // Equal
        [DataRow(Stubs.RuleJsonConditionDynamic, Negative, "Eq")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Negative, "Equal")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Negative, "eq")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Negative, "equal")]
        // NotEqual
        [DataRow(Stubs.RuleJsonConditionDynamic, Positive, "Ne")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Positive, "NotEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Positive, "ne")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Positive, "notEqual")]
        // Match
        [DataRow(Stubs.RuleJsonConditionDynamic, "SimulatorDriver", "NotMatch")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "SimulatorDriver", "notMatch")]
        // NotMatch
        [DataRow(Stubs.RuleJsonConditionDynamic, "ChromeDriver", "Match")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "ChromeDriver", "match")]
        #endregion
        public void DriverTypeNameNegativeTest(string ruleJson, string expected, string @operator)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, "DriverTypeName")
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnRegularExpression, ".*");

            // Invoke the SetCondition action with the specified action rule.
            var responseModel = Invoke(ruleJson);

            // Extract the environment from the response model.
            var environment = responseModel.GetEnvironment();

            // Assert that no session parameters were set.
            Assert.IsFalse(environment.SessionParameters.Any());
        }

        [TestMethod(DisplayName = "Verify that the DriverTypeName condition in SetCondition plugin correctly evaluates " +
            "various conditions.")]
        #region *** Data Set ***
        // Equal
        [DataRow(Stubs.RuleJsonConditionDynamic, Positive, "Eq")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Positive, "Equal")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Positive, "eq")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Positive, "equal")]
        // NotEqual
        [DataRow(Stubs.RuleJsonConditionDynamic, Negative, "Ne")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Negative, "NotEqual")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Negative, "ne")]
        [DataRow(Stubs.RuleJsonConditionDynamic, Negative, "notEqual")]
        // Match
        [DataRow(Stubs.RuleJsonConditionDynamic, "SimulatorDriver", "Match")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "SimulatorDriver", "match")]
        // NotMatch
        [DataRow(Stubs.RuleJsonConditionDynamic, "ChromeDriver", "NotMatch")]
        [DataRow(Stubs.RuleJsonConditionDynamic, "ChromeDriver", "notMatch")]
        #endregion
        public void DriverTypeNameTest(string ruleJson, string expected, string @operator)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, "DriverTypeName")
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnRegularExpression, ".*");

            // Invoke the SetCondition action with the specified action rule.
            var responseModel = Invoke(ruleJson);

            // Extract the session parameter value from the response model and
            // decode it from Base64 encoding to a string value for comparison purposes.
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly.
            Assert.AreEqual(expected: "Foo Bar", actual, ignoreCase: true);
        }

        [TestMethod(DisplayName = "Verify that the SetCondition plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the SetCondition plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetCondition>();
        }
    }
}
