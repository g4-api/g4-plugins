using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("OpenUrl")]
    [TestCategory("UnitTest")]
    public class OpenUrlTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the OpenUrl plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<OpenUrl>();
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl plugin can be successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<OpenUrl>();
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl method opens a URL from the attribute.")]
        public void OpenUrlFromAttributeTest()
        {
            // Define the rule JSON to open a URL from an attribute
            const string ruleJson = @"{""pluginName"":""OpenUrl"", ""onElement"":""//positive"",""onAttribute"":""href""}";

            // Invoke the OpenUrl plugin with the specified rule JSON
            var plugin = Invoke<OpenUrl>(ruleJson).Plugin;

            // Verify that the browser navigates to the expected URL
            Assert.AreEqual(
                expected: "http://m.from-href.io",
                actual: plugin.WebDriver.Navigate().Url.TrimEnd('/'));
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl method opens a URL from the argument.")]
        public void OpenUrlFromArgumentTest()
        {
            // Define the rule JSON to open a URL from an argument
            const string ruleJson = @"{""pluginName"":""OpenUrl"", ""argument"":""http://positive.io""}";

            // Invoke the OpenUrl plugin with the specified rule JSON
            var plugin = Invoke<OpenUrl>(ruleJson).Plugin;

            // Verify that the browser navigates to the expected URL
            Assert.AreEqual(expected: "http://positive.io", actual: plugin.WebDriver.Navigate().Url);
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl method opens a URL from the element.")]
        public void OpenUrlFromElementTest()
        {
            // Define the rule JSON to open a URL from an element
            const string ruleJson = @"{""pluginName"":""OpenUrl"", ""onElement"":"".//url"", ""regularExpression"":""https?://.*""}";

            // Invoke the OpenUrl plugin with the specified rule JSON
            var plugin = Invoke<OpenUrl>(ruleJson, By.Custom.Positive()).Plugin;

            // Verify that the browser navigates to the expected URL
            Assert.AreEqual(expected: "http://positive.io/20", actual: plugin.WebDriver.Navigate().Url);
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl method throws a NoSuchElementException " +
            "when the element does not exist.")]
        public void OpenUrlNoSuchElementExceptionTest()
        {
            // Invoke the OpenUrl plugin with a non-existing element, expecting a NoSuchElementException
            Assert.Throws<NoSuchElementException>(() =>
                Invoke<OpenUrl>(
                    ruleJson: @"{""pluginName"":""OpenUrl"", ""onElement"":"".//none""}",
                    by: By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl method throws a StaleElementReferenceException " +
            "when the element is stale.")]
        public void OpenUrlStaleElementReferenceExceptionTest()
        {
            // Invoke the OpenUrl plugin with a stale element, expecting a StaleElementReferenceException
            Assert.Throws<StaleElementReferenceException>(() =>
                Invoke<OpenUrl>(
                    ruleJson: @"{""pluginName"":""OpenUrl"", ""onElement"":"".//stale""}",
                    by: By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl method throws a WebDriverTimeoutException " +
            "when the element is invalid.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""OpenUrl"", ""onElement"":""//none""}")]
        [DataRow(@"{""pluginName"":""OpenUrl"", ""onElement"":""//null""}")]
        [DataRow(@"{""pluginName"":""OpenUrl"", ""onElement"":""//stale""}")]
        #endregion
        public void OpenUrlTimeoutExceptionTest(string ruleJson)
        {
            // Invoke the OpenUrl plugin with invalid elements, expecting a WebDriverTimeoutException
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<OpenUrl>(ruleJson));
        }
    }
}
