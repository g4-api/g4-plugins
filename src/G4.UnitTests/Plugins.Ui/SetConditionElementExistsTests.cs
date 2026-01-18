using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Attributes;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

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
    public class SetConditionElementExistsTests : TestBase
    {
        // Define a data set for the ElementExists plugin
        private static IEnumerable<object[]> DataSet =>
        [
            [Stubs.RuleJsonConditionDynamic, "ElementExists"],
            [Stubs.RuleJsonConditionDynamic, "elementExists"],
            [Stubs.RuleJsonConditionDynamic, "Exists"],
            [Stubs.RuleJsonConditionDynamic, "exists"]
        ];

        [TestMethod(DisplayName = "Verify that element exists with various positive conditions")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementExistsTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with test-specific values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//positive")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly
            Assert.AreEqual("Foo Bar", actual, ignoreCase: true);
        }

        [RetryableTestMethod(
            numberOfAttempts: 5,
            DisplayName = "Verify that the ElementExists condition fails for various conditions with first-layer elements.",
            DelayBetweenAttempts = 3000)]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementExistsNoSuchElementExceptionTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, ".//none")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a NoSuchElementException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NoSuchElementException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that the ElementExists condition fails for various " +
            "negative cases.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementExistsNegativeTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, ".//none")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that the ElementExists condition handles " +
            "StaleElementReferenceException for first-layer elements.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementExistsStaleElementTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//stale")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a StaleElementReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is StaleElementReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that the ElementExists condition handles " +
            "WebDriverException for first-layer elements.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementExistsWebDriverExceptionTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//exception")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is WebDriverException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that element does not exist when null with various assertions")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementExistsNullTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with test-specific values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(DisplayName = "Verify that the SetCondition plugin can be successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SetCondition>();
        }

        [TestMethod(DisplayName = "Verify that the SetCondition plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SetCondition>();
        }
    }
}
