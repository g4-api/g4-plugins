using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("MoveMouseCursor")]
    [TestCategory("UnitTest")]
    public class MoveMouseCursorTests : TestBase
    {
        [TestMethod(displayName: "Verify that the MoveMouseCursor plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<MoveMouseCursor>();
        }

        [TestMethod(displayName: "Verify that the MoveMouseCursor plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<MoveMouseCursor>();
        }

        [DataTestMethod(displayName: "Verify that the MoveMouseCursor method works with valid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        [DataRow(@"{""argument"":""{{$ --X:100 --Y:150}}""}")]
        #endregion
        public void MoveMouseCursorPositiveTest(string ruleJson)
        {
            // Invoke the MoveMouseCursor plugin with the specified rule JSON
            var plugin = Invoke<MoveMouseCursor>(ruleJson).Plugin;

            // Verify that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [DataTestMethod(displayName: "Verify that the MoveMouseCursor method works with nested valid elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//positive""}")]
        [DataRow(@"{""onElement"":"".//negative""}")]
        [DataRow(@"{""onElement"":"".//null""}")]
        [DataRow(@"{""argument"":""{{$ --X:100 --Y:150}}""}")]
        #endregion
        public void MoveMouseCursorPositiveNestedTest(string ruleJson)
        {
            // Invoke the MoveMouseCursor plugin with the specified rule JSON on nested elements
            var plugin = Invoke<MoveMouseCursor>(ruleJson, By.Custom.Positive()).Plugin;

            // Verify that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(displayName: "Verify that the MoveMouseCursor method can be invoked " +
            "without any arguments.")]
        public void MoveMouseCursorFlat()
        {
            // Invoke the MoveMouseCursor plugin without any arguments
            var plugin = Invoke<MoveMouseCursor>(ruleJson: @"{""pluginName"":""MoveMouseCursor""}").Plugin;

            // Verify that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [DataTestMethod(displayName: "Verify that the MoveMouseCursor method with no elements " +
            "throws a NoSuchElementException.")]
        [ExpectedException(typeof(NoSuchElementException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//none""}")]
        #endregion
        public void MoveMouseCursorNoElementNestedTest(string ruleJson)
        {
            // Invoke the MoveMouseCursor plugin with the specified rule JSON on non-existing elements
            var plugin = Invoke<MoveMouseCursor>(ruleJson, By.Custom.Positive()).Plugin;

            // Verify that a NoSuchElementException is thrown, indicating no such element exists
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [DataTestMethod(displayName: "Verify that the MoveMouseCursor method with stale elements " +
            "throws a StaleElementReferenceException.")]
        [ExpectedException(typeof(StaleElementReferenceException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//stale""}")]
        #endregion
        public void MoveMouseCursorStaleNestedTest(string ruleJson)
        {
            // Invoke the MoveMouseCursor plugin with the specified rule JSON on stale elements
            var plugin = Invoke<MoveMouseCursor>(ruleJson, By.Custom.Positive()).Plugin;

            // Verify that a StaleElementReferenceException is thrown, indicating the element is no longer in the DOM
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [DataTestMethod(displayName: "Verify that the MoveMouseCursor method with invalid elements " +
            "throws a WebDriverTimeoutException.")]
        [ExpectedException(typeof(WebDriverTimeoutException))]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//none""}")]
        [DataRow(@"{""onElement"":""//null""}")]
        [DataRow(@"{""onElement"":""//stale""}")]
        #endregion
        public void MoveMouseCursorTimeoutTest(string ruleJson)
        {
            // Invoke the MoveMouseCursor plugin with the specified rule JSON on invalid elements
            var plugin = Invoke<MoveMouseCursor>(ruleJson).Plugin;

            // Verify that a WebDriverTimeoutException is thrown, indicating the operation timed out
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }
    }
}
