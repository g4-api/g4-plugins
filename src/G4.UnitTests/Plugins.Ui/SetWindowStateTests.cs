using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetWindowState")]
    [TestCategory("UnitTest")]
    public class SetWindowStateTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the SetWindowFullScreen plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SetWindowState>();
        }

        [TestMethod(DisplayName = "Verify that the SetWindowFullScreen plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SetWindowState>();
        }

        [TestMethod(DisplayName = "Verify that the SetWindowFullScreen action works correctly.")]
        public void SetWindowFullScreenTest()
        {
            // Define the rule JSON
            const string ruleJson = @"{""pluginName"":""SetWindowState"",""Argument"":""FullScreen""}";

            // Invoke the SetWindowFullScreen action with the specified action rule
            var responseModel = Invoke<SetWindowState>(ruleJson).Response;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsFalse(responseModel.Exceptions.Any());
        }

        [TestMethod(DisplayName = "Verify that the SetWindowFullScreen action works correctly with an element.")]
        public void SetWindowFullScreenElementTest()
        {
            // Invoke the SetWindowFullScreen action with the specified action rule
            var responseModel = Invoke<SetWindowState>(
                ruleJson: @"{""pluginName"":""SetWindowState"",""Argument"":""FullScreen""}",
                by: By.Custom.Positive()).Response;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsFalse(responseModel.Exceptions.Any());
        }

        [TestMethod(DisplayName = "Verify that the InvokeMaximizeWindow plugin can maximize " +
            "a window without exceptions.")]
        public void MaximizeWindowTest()
        {
            // Define the rule JSON
            const string ruleJson = @"{""pluginName"":""SetWindowState"",""Argument"":""Maximized""}";

            // Invoke the plugin
            var plugin = Invoke<SetWindowState>(ruleJson).Plugin;

            // Assert that no exceptions occurred during the maximize window action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeMaximizeWindow plugin can maximize " +
            "a window with an element without exceptions.")]
        public void MaximizeWindowWithElementTest()
        {
            // Define the rule JSON
            const string ruleJson = @"{""pluginName"":""SetWindowState"",""Argument"":""Maximized""}";

            // Invoke the plugin with a custom locator
            var plugin = Invoke<SetWindowState>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions occurred during the maximize window action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeMinimizeWindow plugin can minimize " +
            "a window without exceptions.")]
        public void MinimizeWindowTest()
        {
            // Define the rule JSON
            const string ruleJson = @"{""pluginName"":""SetWindowState"",""Argument"":""Minimized""}";

            // Invoke the plugin
            var plugin = Invoke<SetWindowState>(ruleJson).Plugin;

            // Assert that no exceptions occurred during the minimize window action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the InvokeMinimizeWindow plugin can minimize " +
            "a window with an element without exceptions.")]
        public void MinimizeWindowWithElementTest()
        {
            // Define the rule JSON
            const string ruleJson = @"{""pluginName"":""SetWindowState"",""Argument"":""Minimized""}";

            // Invoke the plugin with a custom locator
            var plugin = Invoke<SetWindowState>(ruleJson, By.Custom.Positive()).Plugin;

            // Assert that no exceptions occurred during the minimize window action
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }
    }
}
