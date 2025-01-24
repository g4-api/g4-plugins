using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.AssertKeyboardNotVisible
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Define a sequence of action rule models to return
            return
            [
                // InvokeClick action: Invokes a click on the element with id "SendKeys"
                new ActionRuleModel
                {
                    Locator = "CssSelector",
                    OnElement = "#SendKeys",
                    PluginName = "InvokeClick"
                },
                // Assert action: Asserts that the keyboard is not visible
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:KeyboardNotVisible}}",
                    PluginName = "Assert"
                }
            ];
        }

        protected override IDictionary<string, object> OnDriver(AutomationEnvironment environment, IDictionary<string, object> driverParams)
        {
            // Retrieve necessary parameters from the environment and driver parameters
            var appiumVersion = environment.TestParameters["appiumVersion"];
            var capabilities = driverParams.Get("capabilities", new CapabilitiesModel());
            var bstackOptions = capabilities.AlwaysMatch.Get("bstack:options", new Dictionary<string, object>());
            var device = environment.TestParameters["device"];
            var platformVersion = environment.TestParameters["platformVersion"];

            // Set the remote driver binaries path
            driverParams["driverBinaries"] = $"{TestContext.Properties["Grid.Endpoint"]}";

            // Update Appium capabilities and BrowserStack options
            capabilities.AlwaysMatch["device"] = device;
            capabilities.AlwaysMatch["deviceName"] = device;
            capabilities.AlwaysMatch["platformVersion"] = platformVersion;
            capabilities.AlwaysMatch["browserName"] = "chrome";

            bstackOptions["appiumVersion"] = appiumVersion;

            // Call the base method to continue with driver configurations
            return base.OnDriver(environment, driverParams);
        }
    }
}
