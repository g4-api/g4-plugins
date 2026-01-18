using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("NewWindow")]
    [TestCategory("UnitTest")]
    public class NewWindowTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the NewWindow plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<NewWindow>();
        }

        [TestMethod(DisplayName = "Verify that the NewWindow plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<NewWindow>();
        }

        [TestMethod(DisplayName = "Verify that the NewWindow method opens a new window or tab.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""tab""}")]
        [DataRow(@"{""argument"":""window""}")]
        #endregion
        public void NewWindowTest(string ruleJson)
        {
            // Invoke the NewWindow plugin with the specified rule JSON
            var plugin = Invoke<NewWindow>(ruleJson).Plugin;

            // Store the original window handle
            var notExpected = plugin.WebDriver.WindowHandles[0];

            // Store the new window handle after invocation
            var actual = plugin.WebDriver.WindowHandle;

            // Verify that the new window handle is different from the original one
            Assert.AreNotEqual(notExpected, actual);
        }
    }
}
