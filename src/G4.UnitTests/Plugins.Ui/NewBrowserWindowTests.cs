using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("NewBrowserWindow")]
    [TestCategory("UnitTest")]
    public class NewBrowserWindowTests : TestBase
    {
        [TestMethod(displayName: "Verify that the NewBrowserWindow plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<NewBrowserWindow>();
        }

        [TestMethod(displayName: "Verify that the NewBrowserWindow plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<NewBrowserWindow>();
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method opens multiple " +
            "new browser windows with the Amount parameter from attribute.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""NewBrowserWindow"", ""argument"":""{{$ --Amount:5}}"",""onElement"":""//positive"",""onAttribute"":""href""}")]
        #endregion
        public void NewBrowserWindowAmountParameterFromAttributeTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON, Amount parameter, and attribute
            var plugin = Invoke<NewBrowserWindow>(ruleJson).Plugin;

            // Verify that six window handles are present after invocation (original + 5 new windows)
            Assert.IsTrue(plugin.WebDriver.WindowHandles.Count == 6);
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method opens multiple " +
            "new browser windows with the Amount parameter from attribute (negative test).")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""NewBrowserWindow"", ""argument"":""{{$ --Amount:5}}"",""onAttribute"":""href""}")]
        #endregion
        public void NewBrowserWindowAmountParameterFromAttributeNegativeTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON and Amount parameter from attribute
            var plugin = Invoke<NewBrowserWindow>(ruleJson).Plugin;

            // Verify that six window handles are present after invocation (original + 5 new windows)
            Assert.IsTrue(plugin.WebDriver.WindowHandles.Count == 6);
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method opens multiple " +
            "new browser windows with the Amount parameter from element.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""NewBrowserWindow"", ""argument"":""{{$ --Amount:5}}"",""onElement"":""//positive""}")]
        #endregion
        public void NewBrowserWindowAmountParameterFromElementTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON and Amount parameter from element
            var plugin = Invoke<NewBrowserWindow>(ruleJson).Plugin;

            // Verify that six window handles are present after invocation (original + 5 new windows)
            Assert.IsTrue(plugin.WebDriver.WindowHandles.Count == 6);
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method opens multiple " +
            "new browser windows with the Amount parameter.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""NewBrowserWindow"", ""argument"":""{{$ --Amount:5}}""}")]
        #endregion
        public void NewBrowserWindowAmountParameterTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON and Amount parameter
            var plugin = Invoke<NewBrowserWindow>(ruleJson).Plugin;

            // Verify that six window handles are present after invocation (original + 5 new windows)
            Assert.IsTrue(plugin.WebDriver.WindowHandles.Count == 6);
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method with no elements " +
            "throws a NoSuchElementException.")]
        [ExpectedException(typeof(NoSuchElementException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//none""}")]
        #endregion
        public void NewBrowserWindowNoSuchElementExceptionTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON on non-existing elements
            var plugin = Invoke<NewBrowserWindow>(ruleJson, By.Custom.Positive()).Plugin;

            // Verify that a NoSuchElementException is thrown, indicating no such element exists
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method opens a new " +
            "browser window with specified elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//positive""}")]
        [DataRow(@"{""onElement"":"".//null""}")]
        [DataRow(@"{""onElement"":"".//negative""}")]
        #endregion
        public void NewBrowserWindowWithElementTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON on elements
            var plugin = Invoke<NewBrowserWindow>(ruleJson, By.Custom.Positive()).Plugin;

            // Verify that two window handles are present after invocation
            Assert.IsTrue(plugin.WebDriver.WindowHandles.Count == 2);
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method opens a new " +
            "browser window with valid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void NewBrowserWindowTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON
            var plugin = Invoke<NewBrowserWindow>(ruleJson).Plugin;

            // Verify that two window handles are present after invocation
            Assert.IsTrue(plugin.WebDriver.WindowHandles.Count == 2);
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method with invalid elements " +
            "throws a WebDriverTimeoutException.")]
        [ExpectedException(typeof(WebDriverTimeoutException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//none""}")]
        [DataRow(@"{""onElement"":""//null""}")]
        [DataRow(@"{""onElement"":""//stale""}")]
        #endregion
        public void NewBrowserWindowTimeoutExceptionTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON on invalid elements
            var plugin = Invoke<NewBrowserWindow>(ruleJson).Plugin;

            // Verify that a WebDriverTimeoutException is thrown, indicating the operation timed out
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [DataTestMethod(displayName: "Verify that the NewBrowserWindow method with stale elements " +
            "throws a StaleElementReferenceException.")]
        [ExpectedException(typeof(StaleElementReferenceException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//stale""}")]
        #endregion
        public void NewBrowserWindowStaleElementReferenceExceptionTest(string ruleJson)
        {
            // Invoke the NewBrowserWindow plugin with the specified rule JSON on stale elements
            var plugin = Invoke<NewBrowserWindow>(ruleJson, By.Custom.Positive()).Plugin;

            // Verify that a StaleElementReferenceException is thrown, indicating the element is no longer in the DOM
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }
    }
}
