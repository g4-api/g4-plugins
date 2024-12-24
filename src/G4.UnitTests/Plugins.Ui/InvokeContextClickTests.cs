using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeContextClick")]
    [TestCategory("UnitTest")]
    public class InvokeContextClickTests : TestBase
    {
        [TestMethod(displayName: "Verify that the InvokeContextClick plugin can perform a " +
            "context click action without exceptions.")]
        public void ContextClickTest()
        {
            // Invoke the plugin with a basic rule JSON
            var plugin = Invoke<InvokeContextClick>(ruleJson: "{\"pluginName\":\"InvokeContextClick\"}").Plugin;

            // Assert that no exceptions occurred during the context click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the InvokeContextClick plugin can perform a " +
            "context click action on specified elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void ContextClickOnElementTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON
            var plugin = Invoke<InvokeContextClick>(ruleJson).Plugin;

            // Assert that no exceptions occurred during the context click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the InvokeContextClick plugin can perform a " +
            "context click action on elements inside other elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void ContextClickOnElementInsideElementTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            var plugin = Invoke<InvokeContextClick>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions occurred during the context click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the InvokeContextClick plugin throws a " +
            "NoSuchElementException for non-existing elements.")]
        [ExpectedException(typeof(NoSuchElementException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//none""}")]
        #endregion
        public void ContextClickOnElementInsideElementNoElementExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Invoke<InvokeContextClick>(ruleJson, By.Custom.Positive());
        }

        [TestMethod(displayName: "Verify that the InvokeContextClick plugin throws a " +
            "StaleElementReferenceException for stale elements.")]
        [ExpectedException(typeof(StaleElementReferenceException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//stale""}")]
        #endregion
        public void ContextClickOnElementInsideElementStaleExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Invoke<InvokeContextClick>(ruleJson, By.Custom.Positive());
        }

        [TestMethod(displayName: "Verify that the InvokeContextClick plugin throws a " +
            "WebDriverException for elements that cause exceptions.")]
        [ExpectedException(typeof(WebDriverException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//exception""}")]
        #endregion
        public void ContextClickOnElementInsideElementExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Invoke<InvokeContextClick>(ruleJson, By.Custom.Positive());
        }

        [TestMethod(displayName: "Verify that the InvokeContextClick plugin throws a " +
            "WebDriverTimeoutException for timeout scenarios.")]
        [ExpectedException(typeof(WebDriverTimeoutException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//null""}")]
        [DataRow(@"{""onElement"":""//none""}")]
        [DataRow(@"{""onElement"":""//stale""}")]
        [DataRow(@"{""onElement"":""//exception""}")]
        #endregion
        public void ContextClickOnElementTimeoutExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON
            Invoke<InvokeContextClick>(ruleJson);
        }

        [TestMethod(displayName: "Verify that the InvokeContextClick plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert that the InvokeContextClick plugin can be created successfully
            AssertPlugin<InvokeContextClick>();
        }

        [TestMethod(displayName: "Verify that the InvokeContextClick plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the InvokeContextClick plugin is correct
            AssertManifest<InvokeContextClick>();
        }
    }
}
