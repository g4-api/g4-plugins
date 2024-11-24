using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SwitchAlert")]
    [TestCategory("UnitTest")]
    public class SwitchAlertTests : TestBase
    {
        [TestMethod(displayName: "Verify that the SwitchAlert plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SwitchAlert>();
        }

        [TestMethod(displayName: "Verify that the SwitchAlert plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SwitchAlert>();
        }

        [TestMethod(displayName: "Verify that the SwitchAlert action works correctly.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""""}")]
        [DataRow(@"{""argument"":""{{$ --AlertAction:Dismiss}}""}")]
        [DataRow(@"{""argument"":""{{$ --AlertAction:DISMISS}}""}")]
        [DataRow(@"{""argument"":""{{$ --AlertAction:Accept}}""}")]
        [DataRow(@"{""argument"":""{{$ --AlertAction:ACCEPT}}""}")]
        [DataRow(@"{""argument"":""{{$ --Keys:Foo Bar}}""}")]
        [DataRow(@"{""argument"":""{{$ --Keys:Foo Bar --AlertAction:Dismiss}}""}")]
        [DataRow(@"{""argument"":""{{$ --Keys:Foo Bar --AlertAction:Accept}}""}")]
        #endregion
        public void SwitchAlertTest(string ruleJson)
        {
            // Invoke the SwitchAlert action with the specified action rule
            var responseModel = Invoke<SwitchAlert>(ruleJson, capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.HasAlert] = true
            });

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(!responseModel.Response.Exceptions.Any());
        }

        [TestMethod(displayName: "Verify that the SwitchAlert action throws NoSuchAlertException " +
            "when no alert is present.")]
        [ExpectedException(typeof(NoSuchAlertException))]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""""}")]
        #endregion
        public void SwitchAlertNoAlertTest(string ruleJson)
        {
            // Invoke the SwitchAlert action with the specified action rule
            var responseModel = Invoke<SwitchAlert>(ruleJson, capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.HasAlert] = false
            });

            // Assert that NoSuchAlertException was thrown
            Assert.IsFalse(!responseModel.Response.Exceptions.Any());
        }
    }
}
