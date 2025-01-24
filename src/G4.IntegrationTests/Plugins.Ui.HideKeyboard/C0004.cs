using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.HideKeyboard
{
    internal class C0004(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Define a sequence of action rule models to return
            return
            [
                // Assert action: Asserts that the keyboard is not visible
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:KeyboardNotVisible}}",
                    PluginName = "Assert"
                },
                // InvokeClick action: Clicks on the mobile element with resource id "org.wikipedia.alpha:id/search_container"
                new ActionRuleModel
                {
                    Locator = "MobileElementResourceId",
                    OnElement = "org.wikipedia.alpha:id/search_container",
                    PluginName = "InvokeClick"
                },
                // Assert action: Asserts that the keyboard is visible
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:KeyboardVisible}}",
                    PluginName = "Assert"
                },
                // HideSoftKeyboard action: Hides the soft keyboard by pressing the specified key name
                new ActionRuleModel
                {
                    Argument = "{{$ --Strategy:pressKey --KeyName:" + environment.TestParameters.Get("keyName", string.Empty) + "}}",
                    PluginName = "HideSoftKeyboard"
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
            capabilities.AlwaysMatch["app"] = environment.TestParameters.Get("app", default(string));

            bstackOptions["appiumVersion"] = appiumVersion;

            // Call the base method to continue with driver configurations
            return base.OnDriver(environment, driverParams);
        }
    }
}
