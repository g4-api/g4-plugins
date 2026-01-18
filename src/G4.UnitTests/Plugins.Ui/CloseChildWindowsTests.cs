using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("CloseChildWindows")]
    [TestCategory("UnitTest")]
    public class CloseChildWindowsTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the CloseChildWindows plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert that the CloseChildWindows plugin can be created successfully
            AssertPlugin<CloseChildWindows>();
        }

        [TestMethod(DisplayName = "Verify that the CloseChildWindows plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the CloseChildWindows plugin is correct
            AssertManifest<CloseChildWindows>();
        }

        [TestMethod(DisplayName = "Verify that the CloseChildWindows plugin correctly closes child windows.")]
        #region *** Data Set ***
        [DataRow("{\"pluginName\":\".//CloseChildWindows\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"pluginName\":\".//CloseChildWindows\"}")]
        #endregion
        public void CloseWindowsPositiveTest(string rulesJson)
        {
            // Define capabilities with 5 child windows
            var capabilities = new Dictionary<string, object>
            {
                [SimulatorCapabilities.ChildWindows] = 5
            };

            // Invoke the CloseChildWindows plugin with or without nested elements based on the rulesJson
            var response = !rulesJson.Contains("onElement")
                ? Invoke<CloseChildWindows>(rulesJson, capabilities)
                : Invoke<CloseChildWindows>(rulesJson, By.Custom.Positive(), capabilities);

            // Assert that the final window count is 1 (only the main window remains open)
            Assert.HasCount(expected: 1, collection: response.Plugin.WebDriver.WindowHandles);
        }
    }
}
