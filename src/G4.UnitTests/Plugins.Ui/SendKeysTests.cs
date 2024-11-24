using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SendKeys")]
    [TestCategory("UnitTest")]
    public class SendKeysTests : TestBase
    {
        [TestMethod(displayName: "Verify that the SendKeys plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SendKeys>();
        }

        [TestMethod(displayName: "Verify that the SendKeys plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SendKeys>();
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with valid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""keys"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeysTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with delay.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:keys --Delay:00:00:01}}"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""{{$ --Keys:keys --Delay:1000}}"", ""onElement"":""input""}")]
        #endregion
        public void SendDelayedKeysTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var responseModel = Invoke<SendKeys>(ruleJson);

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(responseModel.Plugin.Exceptions?.IsEmpty);

            // Assert that the total runtime is greater than 4 seconds
            Assert.IsTrue(responseModel.Stopwatch.ElapsedTicks > 4 * TimeSpan.TicksPerSecond);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with clear argument.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:keys --Clear}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeysClearTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with native clear argument.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:keys --NativeClear}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeysNativeClearTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with modifier keys.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:A --Modifier:Control}}"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""{{$ --Keys:A --Modifier:Control --Modifier:Shift}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeysModifiersTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws exceptions with " +
            "native clear argument.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:keys --NativeClear}}"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeysNativeClearError505Test(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws WebDriverTimeoutException.")]
        [ExpectedException(typeof(WebDriverTimeoutException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""stale""}")]
        [DataRow(@"{""argument"":""keys"", ""onElement"":""null""}")]
        [DataRow(@"{""argument"":""keys"", ""onElement"":""none""}")]
        [DataRow(@"{""argument"":""keys"", ""onElement"":""exception""}")]
        #endregion
        public void SendKeysExceptionTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws ElementNotInteractableException.")]
        [ExpectedException(typeof(ElementNotInteractableException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""negative""}")]
        #endregion
        public void SendKeysNegativeTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with valid element and arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""keys"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeysElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with delay and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:keys --Delay:00:00:01}}"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""{{$ --Keys:keys --Delay:1000}}"", ""onElement"":""input""}")]
        #endregion
        public void SendDelayedKeysElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var responseModel = Invoke<SendKeys>(ruleJson, By.Custom.Positive());

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(responseModel.Plugin.Exceptions?.IsEmpty);

            // Assert that the total runtime is greater than 4 seconds
            Assert.IsTrue(responseModel.Stopwatch.ElapsedTicks > 4 * TimeSpan.TicksPerSecond);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with clear argument and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:keys --Clear}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeysClearElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with native clear " +
            "argument and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:keys --NativeClear}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeysNativeClearElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action works with modifier keys and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:A --Modifier:Control}}"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""{{$ --Keys:A --Modifier:Control --Modifier:Shift}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeysModifiersElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws exceptions with " +
            "native clear argument and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Keys:keys --NativeClear}}"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeysNativeClearError505ElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws WebDriverException " +
            "with exception element.")]
        [ExpectedException(typeof(WebDriverException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""exception""}")]
        #endregion
        public void SendKeysExceptionElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws NoSuchElementException " +
            "with none element.")]
        [ExpectedException(typeof(NoSuchElementException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""none""}")]
        #endregion
        public void SendKeysNoneElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws exceptions with null element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""null""}")]
        #endregion
        public void SendKeysNullElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws StaleElementReferenceException " +
            "with stale element.")]
        [ExpectedException(typeof(StaleElementReferenceException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""stale""}")]
        #endregion
        public void SendKeysStaleElementTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeys action throws ElementNotInteractableException " +
            "with negative element.")]
        [ExpectedException(typeof(ElementNotInteractableException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""keys"", ""onElement"":""negative""}")]
        #endregion
        public void SendKeysElementNegativeTest(string ruleJson)
        {
            // Invoke the SendKeys action with the specified action rule
            var plugin = Invoke<SendKeys>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }
    }
}
