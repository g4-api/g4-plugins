using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetCondition")]
    [TestCategory("UnitTest")]
    public class SetConditionElementNotSelectedTests : TestBase
    {
        // Define a data set for the ElementNotSelected plugin
        private static IEnumerable<object[]> DataSet =>
        [
            [Stubs.RuleJsonConditionDynamic, "ElementNotSelected"],
            [Stubs.RuleJsonConditionDynamic, "elementNotSelected"],
            [Stubs.RuleJsonConditionDynamic, "NotSelected"],
            [Stubs.RuleJsonConditionDynamic, "notSelected"]
        ];

        [TestMethod(displayName: "Verify that element is not selected with various positive conditions")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementNotSelectedTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with test-specific values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//negative")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that session parameters were set correctly
            Assert.AreEqual("Foo Bar", actual, ignoreCase: true);
        }

        [TestMethod(displayName: "Verify that the ElementNotSelected condition fails for various " +
            "conditions with first-layer elements.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementNotSelectedNoSuchElementExceptionTest(string ruleJson, string condition)
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

        [TestMethod(displayName: "Verify that the ElementNotSelected condition fails for various " +
            "negative cases.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementNotSelectedNegativeTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with the specified values.
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, ".//positive")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(displayName: "Verify that the ElementNotSelected condition handles " +
            "StaleElementReferenceException for first-layer elements.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementNotSelectedStaleElementTest(string ruleJson, string condition)
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

        [TestMethod(displayName: "Verify that the ElementNotSelected condition handles " +
            "WebDriverException for first-layer elements.")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementNotSelectedWebDriverExceptionTest(string ruleJson, string condition)
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

        [TestMethod(displayName: "Verify that element is not selected when null with various assertions")]
        #region *** Data Set ***
        [DynamicData(nameof(DataSet))]
        #endregion
        public void ElementNotSelectedNullTest(string ruleJson, string condition)
        {
            // Replace placeholders in the rule JSON with test-specific values
            ruleJson = ruleJson
                .Replace(Stubs.OnElement, "//null")
                .Replace(Stubs.OnCondition, condition);

            // Invoke the plugin with the modified rule JSON
            var responseModel = Invoke(ruleJson);

            // Assert that a NullReferenceException was thrown
            Assert.IsTrue(responseModel.GetExceptions().Any(e => e.Exception is NullReferenceException));

            // Extract the session parameter value from the response model and decode it from Base64
            // encoding to a string value for comparison purposes
            var actual = responseModel.GetParameterValue("TestParameter", "Session").ConvertFromBase64();

            // Assert that no session parameters were set
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [TestMethod(displayName: "Verify that the SetCondition plugin can be successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SetCondition>();
        }

        [TestMethod(displayName: "Verify that the SetCondition plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SetCondition>();
        }
    }
}
