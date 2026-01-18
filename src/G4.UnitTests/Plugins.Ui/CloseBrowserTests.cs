using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("CloseBrowser")]
    [TestCategory("UnitTest")]
    public class CloseBrowserTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the CloseBrowser plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert that the CloseBrowser plugin can be created successfully
            AssertPlugin<CloseBrowser>();
        }

        [TestMethod(DisplayName = "Verify that the CloseBrowser plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the CloseBrowser plugin is correct
            AssertManifest<CloseBrowser>();
        }

        [TestMethod(DisplayName = "Verify that the CloseBrowser plugin correctly closes " +
            "the browser window.")]
        #region *** Data Set ***
        [DataRow("{\"pluginName\":\".//CloseBrowser\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"pluginName\":\".//CloseBrowser\"}")]
        #endregion
        public void CloseBrowserTest(string rulesJson)
        {
            // Invoke the CloseBrowser plugin with or without nested elements based on the rulesJson
            var response = !rulesJson.Contains("onElement")
                ? Invoke<CloseBrowser>(rulesJson)
                : Invoke<CloseBrowser>(rulesJson, By.Custom.Positive());

            // Assert that the final window count is 0
            Assert.IsEmpty(response.Plugin.WebDriver.WindowHandles);
        }

        [TestMethod(DisplayName = "Verify that the CloseBrowser plugin throws an exception " +
            "when an error occurs during browser closure.")]
        public void CloseBrowserExceptionTest()
        {
            // Initialize the rule configuration for the CloseBrowser plugin
            var ruleJson = "{\"pluginName\":\".//CloseBrowser\"}";

            // Set up capabilities to simulate an exception during browser closure
            var capabilities = new Dictionary<string, object>
            {
                [SimulatorCapabilities.ThrowOnClose] = true
            };

            // Invoke the CloseBrowser plugin with a configuration that causes an exception
            Assert.Throws<WebDriverException>(() => Invoke<CloseBrowser>(rulesJson: ruleJson, capabilities: capabilities));
        }
    }
}
