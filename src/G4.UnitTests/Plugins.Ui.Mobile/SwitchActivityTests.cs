using G4.Plugins.Ui.Actions.Mobile;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui.Mobile
{
    [TestClass]
    [TestCategory("SwitchActivity")]
    [TestCategory("UnitTest")]
    public class SwitchActivityTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the SwitchActivity plugin starts an activity from a " +
            "package and activity, or from a full intent, without exceptions.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Package:com.example.app --Activity:com.example.app.MainActivity}}""}")]
        [DataRow(@"{""argument"":""{{$ --Activity:com.example.app/.MainActivity}}""}")]
        [DataRow(@"{""argument"":""{{$ --Package:com.example.app --Activity:com.example.app/.MainActivity}}""}")]
        #endregion
        public void SwitchActivityTest(string ruleJson)
        {
            // Act: invoke the plugin, which sends the mobile: startActivity command to the driver.
            var plugin = Invoke<SwitchActivity>(ruleJson).Plugin;

            // Assert: the command completes without plugin or WebDriver exceptions.
            Assert.IsTrue(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the SwitchActivity plugin reports a rule without an " +
            "activity.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Package:com.example.app}}""}")]
        [DataRow(@"{""pluginName"":""SwitchActivity""}")]
        #endregion
        public void SwitchActivityNoActivityTest(string ruleJson)
        {
            // Act: invoke the plugin without the mandatory activity.
            var plugin = Invoke<SwitchActivity>(ruleJson).Plugin;

            // Assert: the step is rejected and reported, because Android cannot start an empty intent.
            Assert.IsFalse(plugin.Exceptions.IsEmpty);
        }

        [TestMethod(DisplayName = "Verify that the SwitchActivity plugin surfaces the driver error for an " +
            "activity that is not a package/activity intent and has no package.")]
        public void SwitchActivityNoPackageTest()
        {
            // Act and Assert: a bare activity name cannot form a package/activity intent, so the driver rejects it
            // and the step fails instead of starting a wrong screen.
            Assert.Throws<WebDriverException>(()
                => Invoke<SwitchActivity>(ruleJson: @"{""argument"":""{{$ --Activity:MainActivity}}""}"));
        }

        [TestMethod(DisplayName = "Verify that the SwitchActivity plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert: plugin discovery can instantiate the action from its setup-model constructor.
            AssertPlugin<SwitchActivity>();
        }

        [TestMethod(DisplayName = "Verify that the SwitchActivity plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest resolves through the Actions.Mobile resource namespace and passes G4 validation.
            AssertManifest<SwitchActivity>();
        }
    }
}
