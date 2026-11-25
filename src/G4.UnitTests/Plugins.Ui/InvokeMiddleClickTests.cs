using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeMiddleClick")]
    [TestCategory("UnitTest")]
    public class InvokeMiddleClickTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin can perform a " +
            "middle click at the current pointer position without exceptions.")]
        public void MiddleClickTest()
        {
            // Act: invoke the plugin without an element so the middle button is pressed at the current pointer position.
            var plugin = Invoke<InvokeMiddleClick>(ruleJson: "{\"pluginName\":\"InvokeMiddleClick\"}").Plugin;

            // Assert: the positional middle click completes without plugin or WebDriver exceptions.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin can perform a " +
            "middle click on specified elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void MiddleClickOnElementTest(string ruleJson)
        {
            // Act: invoke the plugin with an element locator so the pointer moves to the element center before clicking.
            var plugin = Invoke<InvokeMiddleClick>(ruleJson).Plugin;

            // Assert: the element middle click completes without plugin or WebDriver exceptions.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin can perform a " +
            "middle click on elements inside other elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void MiddleClickOnElementInsideElementTest(string ruleJson)
        {
            // Act: invoke the plugin inside a parent element resolved by the custom positive locator.
            var plugin = Invoke<InvokeMiddleClick>(ruleJson, by: By.Custom.Positive()).Plugin;

            // Assert: the nested element middle click completes without plugin or WebDriver exceptions.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin throws a " +
            "NoSuchElementException for non-existing elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//none""}")]
        #endregion
        public void MiddleClickOnElementInsideElementNoElementExceptionTest(string ruleJson)
        {
            // Act and Assert: a missing child element surfaces the driver lookup failure before any click is sent.
            Assert.Throws<NoSuchElementException>(()
                => Invoke<InvokeMiddleClick>(ruleJson, by: By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin throws a " +
            "StaleElementReferenceException for stale elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//stale""}")]
        #endregion
        public void MiddleClickOnElementInsideElementStaleExceptionTest(string ruleJson)
        {
            // Act and Assert: a stale child element surfaces the driver stale-reference failure.
            Assert.Throws<StaleElementReferenceException>(()
                => Invoke<InvokeMiddleClick>(ruleJson, by: By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin throws a " +
            "WebDriverException for elements that cause exceptions.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//exception""}")]
        #endregion
        public void MiddleClickOnElementInsideElementExceptionTest(string ruleJson)
        {
            // Act and Assert: a child element that fails in the driver surfaces the WebDriver failure.
            Assert.Throws<WebDriverException>(()
                => Invoke<InvokeMiddleClick>(ruleJson, by: By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin throws a " +
            "WebDriverTimeoutException for timeout scenarios.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//null""}")]
        [DataRow(@"{""onElement"":""//none""}")]
        [DataRow(@"{""onElement"":""//stale""}")]
        [DataRow(@"{""onElement"":""//exception""}")]
        #endregion
        public void MiddleClickOnElementTimeoutExceptionTest(string ruleJson)
        {
            // Act and Assert: an element that never becomes available ends the wait with a timeout failure.
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<InvokeMiddleClick>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert: plugin discovery can instantiate the action from its setup-model constructor.
            AssertPlugin<InvokeMiddleClick>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeMiddleClick plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest resolves through the Actions resource namespace and satisfies G4 validation.
            AssertManifest<InvokeMiddleClick>();
        }
    }
}
