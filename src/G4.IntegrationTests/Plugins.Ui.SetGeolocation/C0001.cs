using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetGeoLocation
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // SetGeolocation action: Sets the geolocation to latitude 121.21, longitude 11.56, and altitude 94.23.
                new ActionRuleModel
                {
                    PluginName = "SetGeolocation",
                    Argument = "{{$ --Latitude:121.21 --Longitude:11.56 --Altitude:94.23}}"
                }
            ];
        }

        protected override IDictionary<string, object> OnDriver(AutomationEnvironment environment, IDictionary<string, object> driverParams)
        {
            // Retrieve necessary parameters from the environment and driver parameters
            var app = environment.TestParameters["app"];
            var appiumVersion = environment.TestParameters["appiumVersion"];
            var capabilities = driverParams.Get("capabilities", new CapabilitiesModel());
            var bstackOptions = capabilities.AlwaysMatch.Get("bstack:options", new Dictionary<string, object>());
            var device = environment.TestParameters["device"];
            var platformVersion = environment.TestParameters["platformVersion"];

            // Set the remote driver binaries path
            driverParams["driverBinaries"] = $"{TestContext.Properties["Grid.Endpoint"]}";

            // Update Appium capabilities and BrowserStack options
            capabilities.AlwaysMatch["app"] = app;
            capabilities.AlwaysMatch["device"] = device;
            capabilities.AlwaysMatch["deviceName"] = device;
            capabilities.AlwaysMatch["platformVersion"] = platformVersion;

            bstackOptions["appiumVersion"] = appiumVersion;

            // Call the base method to continue with driver configurations
            return base.OnDriver(environment, driverParams);
        }
    }
}
