using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SwitchWindow")]
    [TestCategory("UnitTest")]
    public class SwitchWindowTests : TestBase
    {
        private static Dictionary<string, object> Capabilities => new()
        {
            [SimulatorCapabilities.ChildWindows] = 3
        };

        [TestMethod(DisplayName = "Verify that the SwitchWindow plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SwitchWindow>();
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SwitchWindow>();
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow action works correctly by index.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""SwitchWindow"",""argument"":""1""}")]
        #endregion
        public void SwitchWindowByIndexPositiveTest(string ruleJson)
        {
            // Invoke the SwitchWindow action with the specified action rule
            var plugin = Invoke<SwitchWindow>(ruleJson, capabilities: Capabilities).Plugin;

            // Get the expected and actual window handles
            var expected = plugin.WebDriver.WindowHandles[1];
            var actual = plugin.WebDriver.WindowHandle;

            // Assert that the actual window handle matches the expected handle
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow action works correctly by handle.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""SwitchWindow"",""argument"":""WindowHandleName""}")]
        #endregion
        public void SwitchWindowByHandlePositiveTest(string ruleJson)
        {
            // Invoke the SwitchWindow action with the specified action rule
            var plugin = Invoke<SwitchWindow>(ruleJson, capabilities: Capabilities).Plugin;

            // Get the actual window handle
            var actual = plugin.WebDriver.WindowHandle;

            // Assert that the actual window handle matches the specified handle
            Assert.AreEqual("WindowHandleName", actual);
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow action throws ArgumentOutOfRangeException " +
            "for invalid index.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""SwitchWindow"",""argument"":""-1""}")]
        #endregion
        public void SwitchWindowByIndexNegativeTest(string ruleJson)
        {
            // Invoke the SwitchWindow action with the specified action rule and capabilities
            Assert.Throws<ArgumentOutOfRangeException>(()
                => Invoke<SwitchWindow>(ruleJson, Capabilities));
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow action throws NoSuchWindowException " +
            "for invalid handle.")]
        #region *** Data Set ***
        [DataRow(@"{""pluginName"":""SwitchWindow"",""argument"":""NoSuchWindow""}")]
        #endregion
        public void SwitchWindowByHandleNegativeTest(string ruleJson)
        {
            // Invoke the SwitchWindow action with the specified action rule and capabilities
            Assert.Throws<NoSuchWindowException>(()
                => Invoke<SwitchWindow>(ruleJson, Capabilities));
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow action works correctly by " +
            "index within an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//positive"",""argument"":""1""}")]
        [DataRow(@"{""onElement"":"".//none"",""argument"":""1""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""1""}")]
        [DataRow(@"{""onElement"":"".//stale"",""argument"":""1""}")]
        [DataRow(@"{""onElement"":"".//negative"",""argument"":""1""}")]
        #endregion
        public void SwitchWindowByIndexNestedPositiveTest(string ruleJson)
        {
            // Invoke the SwitchWindow action with the specified action rule and capabilities within an element
            var plugin = Invoke<SwitchWindow>(ruleJson, By.Custom.Positive(), Capabilities).Plugin;

            // Get the expected and actual window handles
            var expected = plugin.WebDriver.WindowHandles[1];
            var actual = plugin.WebDriver.WindowHandle;

            // Assert that the actual window handle matches the expected handle
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow action works correctly by " +
            "handle within an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//positive"",""argument"":""WindowHandleName""}")]
        [DataRow(@"{""onElement"":"".//none"",""argument"":""WindowHandleName""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""WindowHandleName""}")]
        [DataRow(@"{""onElement"":"".//stale"",""argument"":""WindowHandleName""}")]
        [DataRow(@"{""onElement"":"".//negative"",""argument"":""WindowHandleName""}")]
        #endregion
        public void SwitchWindowByHandleNestedPositiveTest(string ruleJson)
        {
            // Invoke the SwitchWindow action with the specified action rule and capabilities within an element
            var plugin = Invoke<SwitchWindow>(ruleJson, By.Custom.Positive(), Capabilities).Plugin;

            // Get the actual window handle
            var actual = plugin.WebDriver.WindowHandle;

            // Assert that the actual window handle matches the specified handle
            Assert.AreEqual("WindowHandleName", actual);
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow action throws ArgumentOutOfRangeException " +
            "for invalid index within an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//positive"",""argument"":""-1""}")]
        [DataRow(@"{""onElement"":"".//none"",""argument"":""-1""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""-1""}")]
        [DataRow(@"{""onElement"":"".//stale"",""argument"":""-1""}")]
        [DataRow(@"{""onElement"":"".//negative"",""argument"":""-1""}")]
        #endregion
        public void SwitchWindowByIndexNestedNegativeTest(string ruleJson)
        {
            // Invoke the SwitchWindow action with the specified action rule and capabilities within an element
            Assert.Throws<ArgumentOutOfRangeException>(()
                => Invoke<SwitchWindow>(ruleJson, By.Custom.Positive(), Capabilities));
        }

        [TestMethod(DisplayName = "Verify that the SwitchWindow action throws NoSuchWindowException " +
            "for invalid handle within an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//positive"",""argument"":""NoSuchWindow""}")]
        [DataRow(@"{""onElement"":"".//none"",""argument"":""NoSuchWindow""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""NoSuchWindow""}")]
        [DataRow(@"{""onElement"":"".//stale"",""argument"":""NoSuchWindow""}")]
        [DataRow(@"{""onElement"":"".//negative"",""argument"":""NoSuchWindow""}")]
        #endregion
        public void SwitchWindowByHandleNestedNegativeTest(string ruleJson)
        {
            // Invoke the SwitchWindow action with the specified action rule and capabilities within an element
            Assert.Throws<NoSuchWindowException>(()
                => Invoke<SwitchWindow>(ruleJson, By.Custom.Positive(), Capabilities));
        }
    }
}
