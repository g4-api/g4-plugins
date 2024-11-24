using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SwitchFrame")]
    [TestCategory("UnitTest")]
    public class SwitchFrameTests : TestBase
    {
        [TestMethod(displayName: "Verify that the SwitchFrame plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SwitchFrame>();
        }

        [TestMethod(displayName: "Verify that the SwitchFrame plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SwitchFrame>();
        }

        [TestMethod(displayName: "Verify that the SwitchFrame action works correctly by frame ID.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""0""}")]
        #endregion
        public void SwitchFrameByIdTest(string ruleJson)
        {
            const string expected = "0";

            // Invoke the SwitchFrame action with the specified action rule
            var plugin = Invoke<SwitchFrame>(ruleJson).Plugin;

            // Get the current window handle
            var actual = plugin.WebDriver.WindowHandle;

            // Assert that the current window handle matches the expected value
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(displayName: "Verify that the SwitchFrame action works correctly by frame element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        #endregion
        public void SwitchFrameByElementTest(string ruleJson)
        {
            // Invoke the SwitchFrame action with the specified action rule
            var plugin = Invoke<SwitchFrame>(ruleJson).Plugin;

            // Get the original window handle
            var originalHandle = plugin.WebDriver.WindowHandles[0];

            // Get the current window handle
            var actual = plugin.WebDriver.WindowHandle;

            // Assert that the current window handle does not match the original handle
            Assert.AreNotEqual(originalHandle, actual);
        }

        [TestMethod(displayName: "Verify that the SwitchFrame action throws NoSuchFrameException " +
            "when the frame does not exist.")]
        [ExpectedException(typeof(NoSuchFrameException))]
        public void SwitchFrameNoSuchFrameExceptionTest()
        {
            // Invoke the SwitchFrame action with the specified action rule
            Invoke<SwitchFrame>(ruleJson: @"{""pluginName"":""SwitchFrame""}");
        }

        [TestMethod(displayName: "Verify that the SwitchFrame action works correctly by " +
            "frame ID with an element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""0""}")]
        #endregion
        public void SwitchFrameByIdElementTest(string ruleJson)
        {
            const string expected = "0";

            // Invoke the SwitchFrame action with the specified action rule
            var plugin = Invoke<SwitchFrame>(ruleJson, By.Custom.Positive()).Plugin;

            // Get the current window handle
            var actual = plugin.WebDriver.WindowHandle;

            // Assert that the current window handle matches the expected value
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(displayName: "Verify that the SwitchFrame action works correctly by " +
            "frame element with an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        #endregion
        public void SwitchFrameByElementElementTest(string ruleJson)
        {
            // Invoke the SwitchFrame action with the specified action rule
            var plugin = Invoke<SwitchFrame>(ruleJson, By.Custom.Positive()).Plugin;

            // Get the original window handle
            var originalHandle = plugin.WebDriver.WindowHandles[0];

            // Get the current window handle
            var actual = plugin.WebDriver.WindowHandle;

            // Assert that the current window handle does not match the original handle
            Assert.AreNotEqual(originalHandle, actual);
        }

        [TestMethod(displayName: "Verify that the SwitchFrame action throws NoSuchFrameException " +
            "when the frame does not exist with an element.")]
        [ExpectedException(typeof(NoSuchFrameException))]
        public void SwitchFrameNoSuchFrameExceptionElementTest()
        {
            // Invoke the SwitchFrame action with the specified action rule
            Invoke<SwitchFrame>(ruleJson: @"{""pluginName"":""SwitchFrame""}", By.Custom.Null());
        }
    }
}
