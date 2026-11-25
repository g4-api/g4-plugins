using G4.Plugins.Ui.Actions.Mobile;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui.Mobile
{
    [TestClass]
    [TestCategory("InvokeLongClick")]
    [TestCategory("UnitTest")]
    public class InvokeLongClickTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeLongClick plugin can long-press the " +
            "current touch position with any duration argument without exceptions.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""InvokeLongClick""}")]
        [DataRow(@"{""argument"":""{{$ --Duration:1500}}""}")]
        [DataRow(@"{""argument"":""{{$ --Duration:0}}""}")]
        [DataRow(@"{""argument"":""{{$ --Duration:-5}}""}")]
        [DataRow(@"{""argument"":""{{$ --Duration:soon}}""}")]
        #endregion
        public void LongClickTest(string ruleJson)
        {
            // Act: invoke the plugin without an element, so the press happens at the current touch position.
            var plugin = Invoke<InvokeLongClick>(ruleJson).Plugin;

            // Assert: a valid, missing or invalid duration all complete, because invalid values use the default.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeLongClick plugin can long-press " +
            "specified elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --Duration:800}}""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void LongClickOnElementTest(string ruleJson)
        {
            // Act: invoke the plugin with an element locator so the touch pointer moves to the element first.
            var plugin = Invoke<InvokeLongClick>(ruleJson).Plugin;

            // Assert: the element long press completes without plugin or WebDriver exceptions.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeLongClick plugin can long-press " +
            "elements inside other elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        #endregion
        public void LongClickOnElementInsideElementTest(string ruleJson)
        {
            // Act: invoke the plugin inside a parent element resolved by the custom positive locator.
            var plugin = Invoke<InvokeLongClick>(ruleJson, by: By.Custom.Positive()).Plugin;

            // Assert: the nested element long press completes without plugin or WebDriver exceptions.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeLongClick plugin throws a " +
            "NoSuchElementException for non-existing elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//none""}")]
        #endregion
        public void LongClickOnElementInsideElementNoElementExceptionTest(string ruleJson)
        {
            // Act and Assert: a missing child element surfaces the driver lookup failure before any touch is sent.
            Assert.Throws<NoSuchElementException>(()
                => Invoke<InvokeLongClick>(ruleJson, by: By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the InvokeLongClick plugin throws a " +
            "WebDriverTimeoutException for timeout scenarios.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//null""}")]
        [DataRow(@"{""onElement"":""//none""}")]
        #endregion
        public void LongClickOnElementTimeoutExceptionTest(string ruleJson)
        {
            // Act and Assert: an element that never becomes available ends the wait with a timeout failure.
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<InvokeLongClick>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the InvokeLongClick plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert: plugin discovery can instantiate the action from its setup-model constructor.
            AssertPlugin<InvokeLongClick>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeLongClick plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest resolves through the Actions.Mobile resource namespace and passes G4 validation.
            AssertManifest<InvokeLongClick>();
        }
    }
}
