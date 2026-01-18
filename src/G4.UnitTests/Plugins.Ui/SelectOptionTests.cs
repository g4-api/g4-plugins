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
    [TestCategory("SelectOption")]
    [TestCategory("UnitTest")]
    public class SelectOptionTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the SelectOption plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SelectOption>();
        }

        [TestMethod(DisplayName = "Verify that the SelectOption plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SelectOption>();
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action works with valid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""1"", ""onElement"":""select-element"", ""onAttribute"":""index""}")]
        [DataRow(@"{""argument"":""SimulatorValue"", ""onElement"":""select-element"", ""onAttribute"":""value""}")]
        [DataRow(@"{""argument"":""Mock"", ""onElement"":""select-element"", ""onAttribute"":""partialText""}")]
        [DataRow(@"{""argument"":""MockText"", ""onElement"":""select-element"", ""onAttribute"":""""}")]
        [DataRow(@"{""argument"":""MockText"", ""onElement"":""select-element""}")]
        #endregion
        public void SelectOptionTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            var plugin = Invoke<SelectOption>(ruleJson).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action works with valid element and arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""1"", ""onElement"":""select-element"", ""onAttribute"":""index""}")]
        [DataRow(@"{""argument"":""SimulatorValue"", ""onElement"":""select-element"", ""onAttribute"":""value""}")]
        [DataRow(@"{""argument"":""Mock"", ""onElement"":""select-element"", ""onAttribute"":""partialText""}")]
        [DataRow(@"{""argument"":""MockText"", ""onElement"":""select-element"", ""onAttribute"":""""}")]
        [DataRow(@"{""argument"":""MockText"", ""onElement"":""select-element""}")]
        #endregion
        public void SelectOptionElementTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            var plugin = Invoke<SelectOption>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action throws " +
            "InvalidOperationException for invalid elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""input"", ""argument"":""1""}")]
        #endregion
        public void SelectOptionInvalidTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            Assert.Throws<InvalidOperationException>(() =>
                Invoke<SelectOption>(ruleJson, By.Custom.Positive()).Plugin);
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action throws NoSuchElementException " +
            "for none elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""none"", ""argument"":""1""}")]
        #endregion
        public void SelectOptionNoneElementTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            Assert.Throws<NoSuchElementException>(() =>
                Invoke<SelectOption>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action throws NullReferenceException " +
            "for null elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""null"", ""argument"":""1""}")]
        #endregion
        public void SelectOptionNullElementTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            Assert.Throws<NullReferenceException>(() =>
                Invoke<SelectOption>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action throws " +
            "StaleElementReferenceException for stale elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""stale"", ""argument"":""1""}")]
        #endregion
        public void SelectOptionStaleElementTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            Assert.Throws<StaleElementReferenceException>(() =>
                Invoke<SelectOption>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action throws WebDriverException " +
            "for exception elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""exception"", ""argument"":""1""}")]
        #endregion
        public void SelectOptionExceptionElementTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            Assert.Throws<WebDriverException>(() =>
                Invoke<SelectOption>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action throws " +
            "WebDriverTimeoutException for invalid elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""stale"", ""argument"":""1""}")]
        [DataRow(@"{""onElement"":""null"", ""argument"":""1""}")]
        [DataRow(@"{""onElement"":""none"", ""argument"":""1""}")]
        [DataRow(@"{""onElement"":""exception"", ""argument"":""1""}")]
        #endregion
        public void SelectOptionExceptionTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<SelectOption>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the SelectOption action throws exceptions " +
            "for invalid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""Foo"", ""onElement"":""select-element"", ""onAttribute"":""index""}")]
        #endregion
        public void SelectOptionElementNegativeTest(string ruleJson)
        {
            // Invoke the SelectOption action with the specified action rule
            var plugin = Invoke<SelectOption>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that exceptions were thrown during the plugin invocation
            Assert.IsFalse(plugin.Exceptions?.IsEmpty);
        }
    }
}
