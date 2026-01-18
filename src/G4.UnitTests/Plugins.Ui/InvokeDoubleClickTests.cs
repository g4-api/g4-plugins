using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeDoubleClick")]
    [TestCategory("UnitTest")]
    public class InvokeDoubleClickTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin can perform a " +
            "double-click action without exceptions.")]
        public void DoubleClickTest()
        {
            // Invoke the plugin with a basic rule JSON
            var plugin = Invoke<InvokeDoubleClick>(ruleJson: "{\"pluginName\":\"InvokeDoubleClick\"}").Plugin;

            // Assert that no exceptions occurred during the double-click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin can perform a " +
            "double-click action on specified elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void DoubleClickOnElementTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON
            var plugin = Invoke<InvokeDoubleClick>(ruleJson).Plugin;

            // Assert that no exceptions occurred during the double-click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin can perform a " +
            "double-click action on elements inside other elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void DoubleClickOnElementInsideElementTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            var plugin = Invoke<InvokeDoubleClick>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions occurred during the double-click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin throws a " +
            "NoSuchElementException for non-existing elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//none""}")]
        #endregion
        public void DoubleClickOnElementInsideElementNoElementExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Assert.Throws<NoSuchElementException>(() 
                => Invoke<InvokeDoubleClick>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin throws a " +
            "StaleElementReferenceException for stale elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//stale""}")]
        #endregion
        public void DoubleClickOnElementInsideElementStaleExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Assert.Throws<StaleElementReferenceException>(()
                => Invoke<InvokeDoubleClick>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin throws a " +
            "WebDriverException for elements that cause exceptions.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//exception""}")]
        #endregion
        public void DoubleClickOnElementInsideElementExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Assert.Throws<WebDriverException>(()
                => Invoke<InvokeDoubleClick>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin throws a " +
            "WebDriverTimeoutException for timeout scenarios.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//null""}")]
        [DataRow(@"{""onElement"":""//none""}")]
        [DataRow(@"{""onElement"":""//stale""}")]
        [DataRow(@"{""onElement"":""//exception""}")]
        #endregion
        public void DoubleClickOnElementTimeoutExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<InvokeDoubleClick>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert that the InvokeDoubleClick plugin can be created successfully
            AssertPlugin<InvokeDoubleClick>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeDoubleClick plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the InvokeDoubleClick plugin is correct
            AssertManifest<InvokeDoubleClick>();
        }
    }
}
