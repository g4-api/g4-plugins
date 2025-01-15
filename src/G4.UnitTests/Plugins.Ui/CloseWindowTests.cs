using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("CloseWindow")]
    [TestCategory("UnitTest")]
    public class CloseWindowTests : TestBase
    {
        private const int NumberOfWindows = 5;

        // Define capabilities with 5 child windows
        private static Dictionary<string, object> Capabilities => new()
        {
            [SimulatorCapabilities.ChildWindows] = 5
        };

        [TestMethod(displayName: "Verify that the CloseWindow plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert that the CloseWindow plugin can be created successfully
            AssertPlugin<CloseWindow>();
        }

        [TestMethod(displayName: "Verify that the CloseWindow plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the CloseWindow plugin is correct
            AssertManifest<CloseWindow>();
        }

        [TestMethod(displayName: "Verify that the CloseWindow plugin correctly closes the current window.")]
        #region *** Data Set ***
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"pluginName\":\".//CloseWindow\"}")]
        #endregion
        public void CloseWindowCurrentTest(string rulesJson)
        {
            // Create a simulator driver with the defined capabilities
            var driver = new SimulatorDriver().AddCapabilities(Capabilities);

            // Assert that there are more windows than the predefined number of windows
            Assert.IsTrue(driver.WindowHandles.Count > NumberOfWindows);

            // Store the handle of the first window
            var windowHandle = driver.WindowHandles[0];

            // Invoke the CloseWindow plugin with or without nested elements based on the rulesJson
            var plugin = !rulesJson.Contains("onElement")
                ? Invoke<CloseWindow>(driver, rulesJson).Plugin
                : Invoke<CloseWindow>(driver, rulesJson, By.Custom.Positive()).Plugin;

            // Assert that the first window handle is no longer present
            Assert.IsFalse(plugin.WebDriver.WindowHandles.Any(i => i == windowHandle));
        }

        [TestMethod(displayName: "Verify that the CloseWindow plugin correctly closes a window by index.")]
        #region *** Data Set ***
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"argument\":\"2\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"argument\":\"2\"}")]
        #endregion
        public void CloseWindowByIndexTest(string rulesJson)
        {
            // Create a simulator driver with the defined capabilities
            var driver = new SimulatorDriver().AddCapabilities(Capabilities);

            // Assert that there are more windows than the predefined number of windows
            Assert.IsTrue(driver.WindowHandles.Count > NumberOfWindows);

            // Store the handle of the window at index 2
            var windowHandle = driver.WindowHandles[2];

            // Invoke the CloseWindow plugin with or without nested elements based on the rulesJson
            var plugin = !rulesJson.Contains("onElement")
                ? Invoke<CloseWindow>(driver, rulesJson).Plugin
                : Invoke<CloseWindow>(driver, rulesJson, By.Custom.Positive()).Plugin;

            // Assert that the window handle at index 2 is no longer present
            Assert.IsFalse(plugin.WebDriver.WindowHandles.Any(i => i == windowHandle));
        }

        [TestMethod(displayName: "Verify that the CloseWindow plugin throws an exception when " +
            "trying to close a window by a non-existing index.")]
        [ExpectedException(typeof(NoSuchWindowException))]
        #region *** Data Set ***
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"argument\":\"200\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"argument\":\"200\"}")]
        #endregion
        public void CloseWindowByIndexExceptionTest(string rulesJson)
        {
            // Create a simulator driver with the defined capabilities
            var driver = new SimulatorDriver().AddCapabilities(Capabilities);

            // Assert that there are more windows than the predefined number of windows
            Assert.IsTrue(driver.WindowHandles.Count > NumberOfWindows);

            // Store the handle of the window at index 2
            var windowHandle = driver.WindowHandles[2];

            // Invoke the CloseWindow plugin with or without nested elements based on the rulesJson
            var plugin = !rulesJson.Contains("onElement")
                ? Invoke<CloseWindow>(driver, rulesJson).Plugin
                : Invoke<CloseWindow>(driver, rulesJson, By.Custom.Positive()).Plugin;

            // This will throw an exception as the index 200 does not exist
            Assert.IsTrue(plugin.WebDriver.WindowHandles.Any(i => i == windowHandle));
        }

        [TestMethod(displayName: "Verify that the CloseWindow plugin throws an exception when " +
            "trying to close a window by a non-existing handle.")]
        [ExpectedException(typeof(NoSuchWindowException))]
        #region *** Data Set ***
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"argument\":\"NO-SUCH-HANDLE\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"argument\":\"NO-SUCH-HANDLE\"}")]
        #endregion
        public void CloseWindowByHandleExceptionTest(string rulesJson)
        {
            // Create a simulator driver with the defined capabilities
            var driver = new SimulatorDriver().AddCapabilities(Capabilities);

            // Assert that there are more windows than the predefined number of windows
            Assert.IsTrue(driver.WindowHandles.Count > NumberOfWindows);

            // Store the handle of the first window
            var windowHandle = driver.WindowHandles[0];

            // Invoke the CloseWindow plugin with or without nested elements based on the rulesJson
            var plugin = !rulesJson.Contains("onElement")
                ? Invoke<CloseWindow>(driver, rulesJson).Plugin
                : Invoke<CloseWindow>(driver, rulesJson, By.Custom.Positive()).Plugin;

            // This will throw an exception as the handle NO-SUCH-HANDLE does not exist
            Assert.IsTrue(plugin.WebDriver.WindowHandles.Any(i => i == windowHandle));
        }

        [TestMethod(displayName: "Verify that the CloseWindow plugin correctly closes a window by handle.")]
        #region *** Data Set ***
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"argument\":\"windowHandle\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"pluginName\":\".//CloseWindow\",\"argument\":\"windowHandle\"}")]
        #endregion
        public void CloseWindowByHandleTest(string rulesJson)
        {
            // Create a simulator driver with the defined capabilities
            var driver = new SimulatorDriver().AddCapabilities(Capabilities);

            // Assert that there are more windows than the predefined number of windows
            Assert.IsTrue(driver.WindowHandles.Count > NumberOfWindows);

            // Store the handle of the window at index 2
            var windowHandle = driver.WindowHandles[2];

            // Replace placeholder in rulesJson with actual window handle
            rulesJson = rulesJson.Replace("windowHandle", windowHandle);

            // Invoke the CloseWindow plugin with or without nested elements based on the updated rulesJson
            var plugin = !rulesJson.Contains("onElement")
                ? Invoke<CloseWindow>(driver, rulesJson).Plugin
                : Invoke<CloseWindow>(driver, rulesJson, By.Custom.Positive()).Plugin;

            // Assert that the window handle at index 2 is no longer present
            Assert.IsFalse(plugin.WebDriver.WindowHandles.Any(i => i == windowHandle));
        }
    }
}
