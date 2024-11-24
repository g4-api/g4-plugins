using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.CloseBrowser
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Define a sequence of action rule models to return
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // CloseBrowser action: Closes the browser window
                new ActionRuleModel
                {
                    PluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "CloseBrowser")
                },
                // Assert action: Asserts that the element with ID "ClickButtonOutcome"
                // does not exist using CSS selector.
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementNotExists}}",
                    OnElement = "#ClickButtonOutcome",
                    Locator = Locators.CssSelector
                }
            ];
        }

        protected override void OnAutomation(G4AutomationModel automation, AutomationEnvironment environment)
        {
            // Set the search timeout to 1 millisecond
            automation.Settings.AutomationSettings.SearchTimeout = 1;
        }
    }
}
