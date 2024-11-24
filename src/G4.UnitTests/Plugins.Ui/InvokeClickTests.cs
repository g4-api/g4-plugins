﻿using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeClick")]
    [TestCategory("UnitTest")]
    public class InvokeClickTests : TestBase
    {
        [TestMethod(displayName: "Verify that the InvokeClick plugin can perform a click " +
            "action on specified elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        #endregion
        public void ClickOnElementTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON
            var plugin = Invoke<InvokeClick>(ruleJson).Plugin;

            // Assert that no exceptions occurred during the click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin can perform a click " +
            "action on elements inside other elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        #endregion
        public void ClickOnElementInsideElementTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            var plugin = Invoke<InvokeClick>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions occurred during the click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin throws an " +
            "ElementNotInteractableException for elements that are not interactable.")]
        [ExpectedException(typeof(ElementNotInteractableException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void ClickOnElementNotInteractableExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Invoke<InvokeClick>(ruleJson);
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin throws an " +
            "ElementNotInteractableException for elements that are not interactable inside other elements.")]
        [ExpectedException(typeof(ElementNotInteractableException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//negative""}")]
        #endregion
        public void ClickOnElementInsideElementNotInteractableExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Invoke<InvokeClick>(ruleJson, By.Custom.Positive());
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin throws a " +
            "NoSuchElementException for non-existing elements.")]
        [ExpectedException(typeof(NoSuchElementException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//none""}")]
        #endregion
        public void ClickOnElementInsideElementNoElementExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Invoke<InvokeClick>(ruleJson, By.Custom.Positive());
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin throws a " +
            "StaleElementReferenceException for stale elements inside other elements.")]
        [ExpectedException(typeof(StaleElementReferenceException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//stale""}")]
        #endregion
        public void ClickOnElementInsideElementStaleExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Invoke<InvokeClick>(ruleJson, By.Custom.Positive());
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin throws a WebDriverException " +
            "for elements that cause exceptions inside other elements.")]
        [ExpectedException(typeof(WebDriverException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//exception""}")]
        #endregion
        public void ClickOnElementInsideElementExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON and a custom locator
            Invoke<InvokeClick>(ruleJson, By.Custom.Positive());
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin throws a WebDriverTimeoutException " +
            "for timeout scenarios.")]
        [ExpectedException(typeof(WebDriverTimeoutException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//null""}")]
        [DataRow(@"{""onElement"":""//none""}")]
        [DataRow(@"{""onElement"":""//stale""}")]
        [DataRow(@"{""onElement"":""//exception""}")]
        #endregion
        public void ClickOnElementTimeoutExceptionTest(string ruleJson)
        {
            // Invoke the plugin with the specified rule JSON
            Invoke<InvokeClick>(ruleJson);
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin can perform a click " +
            "action without exceptions.")]
        public void ClickTest()
        {
            // Invoke the plugin with a basic rule JSON
            var plugin = Invoke<InvokeClick>(ruleJson: "{\"pluginName\":\"InvokeClick\"}").Plugin;

            // Assert that no exceptions occurred during the click action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the InvokeClick plugin is correct
            AssertManifest<InvokeClick>();
        }

        [TestMethod(displayName: "Verify that the InvokeClick plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert that the InvokeClick plugin can be created successfully
            AssertPlugin<InvokeClick>();
        }
    }
}
