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
    [TestCategory("SendKeyboardKey")]
    [TestCategory("UnitTest")]
    public class SendKeyboardKeyTests : TestBase
    {
        [TestMethod(displayName: "Verify that the SendKeyboardKey plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SendKeyboardKey>();
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SendKeyboardKey>();
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with valid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeyboardKeyTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with multiple keys.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Key:Backspace}}"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Key:Backspace}}"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeyboardMultipleKeysTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with delay.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Delay:00:00:04}}"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Delay:4000}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeyboardKeyDelayTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var responseModel = Invoke<SendKeyboardKey>(ruleJson);

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(responseModel.Plugin.Exceptions?.IsEmpty);

            // Assert that the total runtime is greater than 4 seconds
            Assert.IsTrue(responseModel.Stopwatch.ElapsedTicks > 4 * TimeSpan.TicksPerSecond);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with clear argument.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Clear}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeyboardKeyClearTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with native clear argument.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --NativeClear}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeyboardKeyNativeClearTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws exceptions " +
            "with native clear argument.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --NativeClear}}"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeyboardKeyNativeClearError505Test(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws WebDriverTimeoutException.")]
        [ExpectedException(typeof(WebDriverTimeoutException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""stale""}")]
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""null""}")]
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""none""}")]
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""exception""}")]
        #endregion
        public void SendKeyboardKeyExceptionTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws ElementNotInteractableException.")]
        [ExpectedException(typeof(ElementNotInteractableException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""negative""}")]
        #endregion
        public void SendKeyboardKeyNegativeTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with valid " +
            "element and arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeyboardKeyElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with " +
            "multiple keys and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Key:Backspace}}"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Key:Backspace}}"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeyboardMultipleKeysElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with delay and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Delay:00:00:04}}"", ""onElement"":""input""}")]
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Delay:4000}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeyboardKeyDelayElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var responseModel = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive());

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(responseModel.Plugin.Exceptions?.IsEmpty);

            // Assert that the total runtime is greater than 4 seconds
            Assert.IsTrue(responseModel.Stopwatch.ElapsedTicks > 4 * TimeSpan.TicksPerSecond);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with clear " +
            "argument and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --Clear}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeyboardKeyClearElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action works with native " +
            "clear argument and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --NativeClear}}"", ""onElement"":""input""}")]
        #endregion
        public void SendKeyboardKeyNativeClearElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws exceptions " +
            "with native clear argument and element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Key:Enter --NativeClear}}"", ""onElement"":""positive""}")]
        #endregion
        public void SendKeyboardKeyNativeClearError505ElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws " +
            "WebDriverException with exception element.")]
        [ExpectedException(typeof(WebDriverException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""exception""}")]
        #endregion
        public void SendKeyboardKeyExceptionElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws " +
            "NoSuchElementException with none element.")]
        [ExpectedException(typeof(NoSuchElementException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""none""}")]
        #endregion
        public void SendKeyboardKeyNoneElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws exceptions " +
            "with null element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""null""}")]
        #endregion
        public void SendKeyboardKeyNullElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws " +
            "StaleElementReferenceException with stale element.")]
        [ExpectedException(typeof(StaleElementReferenceException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""stale""}")]
        #endregion
        public void SendKeyboardKeyStaleElementTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the SendKeyboardKey action throws " +
            "ElementNotInteractableException with negative element.")]
        [ExpectedException(typeof(ElementNotInteractableException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Enter"", ""onElement"":""negative""}")]
        #endregion
        public void SendKeyboardKeyElementNegativeTest(string ruleJson)
        {
            // Invoke the SendKeyboardKey action with the specified action rule
            var plugin = Invoke<SendKeyboardKey>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }
    }
}
