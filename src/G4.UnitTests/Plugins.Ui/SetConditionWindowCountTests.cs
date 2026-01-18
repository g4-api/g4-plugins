using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Attributes;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetCondition")]
    [TestCategory("UnitTest")]
    public class SetConditionWindowCountTests : TestBase
    {
        // Initialize the data set for the test cases in this test class
        private static IEnumerable<object[]> DataSet =>
        [
            // Window Count: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", ".*", "equal"],
            // Window Count: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", ".*", "notEqual"],
            // Window Count: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "3", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "3", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "3", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "3", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "3", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "3", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "3", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "3", @"\\d+", "greater"],
            // Window Count: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", @"\\d+", "lower"],
            // Window Count: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "3", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "3", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "3", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "3", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "3", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "3", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "3", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "3", @"\\d+", "greaterEqual"],
            // Window Count: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "4", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "5", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "4", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "5", @"\\d+", "lowerEqual"],
            // Window Count: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "^4$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "^4$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "^4$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "^4$", ".*", "match"],
            // Window Count: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "^5$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowCount", "^5$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "^5$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowCount", "^5$", ".*", "notMatch"],
            // Windows Count: Equal
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", ".*", "equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", ".*", "Eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", ".*", "Equal"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", ".*", "eq"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", ".*", "equal"],
            // Windows Count: NotEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", ".*", "notEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", ".*", "Ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", ".*", "NotEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", ".*", "ne"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", ".*", "notEqual"],
            // Windows Count: Greater
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "3", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "3", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "3", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "3", @"\\d+", "greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "3", @"\\d+", "Gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "3", @"\\d+", "Greater"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "3", @"\\d+", "gt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "3", @"\\d+", "greater"],
            // Windows Count: Lower
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", @"\\d+", "lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", @"\\d+", "Lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", @"\\d+", "Lower"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", @"\\d+", "lt"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", @"\\d+", "lower"],
            // Windows Count: GreaterEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "3", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "3", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "3", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "3", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", @"\\d+", "greaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "3", @"\\d+", "Ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "3", @"\\d+", "GreaterEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "3", @"\\d+", "ge"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "3", @"\\d+", "greaterEqual"],
            // Windows Count: LowerEqual
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "4", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "5", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "4", @"\\d+", "lowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", @"\\d+", "Le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", @"\\d+", "LowerEqual"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", @"\\d+", "le"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "5", @"\\d+", "lowerEqual"],
            // Windows Count: Match
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "^4$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "^4$", ".*", "match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "^4$", ".*", "Match"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "^4$", ".*", "match"],
            // Windows Count: NotMatch
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "^5$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "WindowsCount", "^5$", ".*", "notMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "^5$", ".*", "NotMatch"],
            [Stubs.RuleJsonConditionDynamicFailOnException, "windowsCount", "^5$", ".*", "notMatch"]
        ];

        [TestMethod(DisplayName = "Verify that the plugin is correctly instantiated and " +
            "operates as expected")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the plugin's manifest complies with expected " +
            "standards and specifications")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetCondition>();
        }

        [RetryableTestMethod(
            numberOfAttempts: 5,
            DisplayName = "Verify that window count assertions are evaluated correctly",
            DelayBetweenAttempts = 2000)]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void WindowCountTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, string.Empty)
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson, capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.ChildWindows] = 3
            });

            // Assert that no exceptions were thrown
            Assert.IsFalse(responseModel.GetExceptions().Any());

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly
            Assert.AreEqual("Foo Bar", actual, ignoreCase: true);
        }

        [TestMethod(DisplayName = "Verify that window count assertions handle WebDriverException correctly")]
        #region *** Data Set ***
        [DynamicData(dynamicDataSourceName: nameof(DataSet))]
        #endregion
        public void WindowCountWebDriverExceptionTest(
           string ruleJson,
           string condition,
           string expected,
           string regex,
           string @operator)
        {
            // Replace placeholders in the rule JSON with specific test values
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, condition)
                .Replace(Stubs.OnOperator, @operator)
                .Replace(Stubs.OnOperatorExpected, expected)
                .Replace(Stubs.OnElement, string.Empty)
                .Replace(Stubs.OnRegularExpression, regex);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson, capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.ChildWindows] = 3,
                ["ExceptionOnHandles"] = true
            });

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is WebDriverException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }
    }
}
