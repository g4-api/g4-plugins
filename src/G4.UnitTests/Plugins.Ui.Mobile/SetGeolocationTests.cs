using G4.Api;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.Actions.Mobile;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui.Mobile
{
    [TestClass]
    [TestCategory("SetGeolocation")]
    [TestCategory("UnitTest")]
    [DoNotParallelize]
    public class SetGeolocationTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the SetGeolocation plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<SetGeolocation>();
        }

        [TestMethod(DisplayName = "Verify that the SetGeolocation plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<SetGeolocation>();
        }

        [TestMethod(DisplayName = "Verify that invalid geolocation arguments trigger " +
            "exceptions in the plugin.")]
        #region *** Data Set ***
        [DataRow("")]
        [DataRow(null)]
        [DataRow("{{$ --Altitude:100}}")]
        [DataRow("{{$ --Latitude:200}}")]
        [DataRow("{{$ --Longitude:300}}")]
        [DataRow("{{$ --Altitude:100 --Latitude:200}}")]
        [DataRow("{{$ --Altitude:100 --Longitude:300}}")]
        [DataRow("{{$ --Latitude:200 --Longitude:300}}")]
        #endregion
        public void SetGeolocationNegativeTest(string argument)
        {
            // Set up the actions with the SetGeolocation plugin and the specified argument
            var actions = new[]
            {
                new ActionRuleModel
                {
                    PluginName = "SetGeolocation",
                    Argument = argument,
                }
            };
            Automation.NewStage(actions);

            // Invoke the automation and get the response
            var client = new G4Client().Automation;
            var response = client.Invoke(Automation).Values.First().Sessions.First().Value;

            // Ensure that there are exceptions in the G4Request
            Assert.IsTrue(response.ResponseData.Exceptions.Any());
        }

        [TestMethod(DisplayName = "Verify that valid geolocation arguments do not trigger " +
            "exceptions in the plugin.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Altitude:100 --Latitude:200 --Longitude:300}}""}")]
        #endregion
        public void SetGeolocationPositiveTest(string ruleJson)
        {
            // Invoke the action to get the plugin
            var plugin = Invoke<SetGeolocation>(ruleJson).Plugin;

            // Assert that the plugin's exceptions are empty
            Assert.IsTrue(plugin.Exceptions?.IsEmpty);
        }
    }
}
