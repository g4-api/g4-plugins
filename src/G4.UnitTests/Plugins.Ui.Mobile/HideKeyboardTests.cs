using G4.Plugins.Ui.Actions.Mobile;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui.Mobile
{
    [TestClass]
    [TestCategory("HideKeyboard")]
    [TestCategory("UnitTest")]
    [DoNotParallelize]
    public class HideKeyboardTests : TestBase
    {
        [TestMethod(displayName: "Verify that the HideSoftKeyboard plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<HideSoftKeyboard>();
        }

        [TestMethod(displayName: "Verify that the HideSoftKeyboard plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<HideSoftKeyboard>();
        }

        [TestMethod(displayName: "Verify that the HideSoftKeyboard plugin functions correctly " +
            "with various valid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --KeyName:Done --Strategy:pressKey}}""}")]
        [DataRow(@"{""argument"":""{{$ --KeyCode:Done --Strategy:pressKey}}""}")]
        [DataRow(@"{""argument"":""{{$ --Key:Done --Strategy:pressKey}}""}")]
        [DataRow(@"{""argument"":""{{$ --KeyName:Done --Strategy:swipeDown}}""}")]
        [DataRow(@"{""argument"":""{{$ --KeyName:Done --Strategy:tapOut}}""}")]
        [DataRow(@"{""argument"":""{{$ --KeyName:Done --Strategy:tapOutside}}""}")]
        [DataRow(@"{""argument"":null}")]
        #endregion
        public void HideKeyboardPositiveTest(string ruleJson)
        {
            // Invoke the action to get the plugin
            var plugin = Invoke<HideSoftKeyboard>(ruleJson).Plugin;

            // Assert that the plugin's exceptions are empty
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }
    }
}
