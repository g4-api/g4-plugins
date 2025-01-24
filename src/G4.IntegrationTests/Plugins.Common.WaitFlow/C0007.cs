using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0007(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // Assert action: Asserts that the element with id "ElementExists" exists
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:ElementExists}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementExists",
                    PluginName = "Assert"
                },
                // InvokeClick action: Invokes a click on the button containing "ElementExists" in its onclick attribute
                new ActionRuleModel
                {
                    OnElement = "//button[contains(@onclick,'ElementExists')]",
                    PluginName = "InvokeClick"
                },
                // WaitFlow action: Waits until the element with id "ElementExists" does not exist for a maximum of 15 seconds
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:ElementNotExists --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementExists",
                    PluginName = "WaitFlow"
                },
                // Assert action: Asserts that the element with id "ElementExists" does not exist
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:ElementNotExists}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementExists",
                    PluginName = "Assert"
                }
            ];
        }

        protected override void OnAutomation(G4AutomationModel automation, AutomationEnvironment environment)
        {
            // Set the search timeout to 1 millisecond
            automation.Settings.AutomationSettings.SearchTimeout = 1;

            // Set the load timeout to 1 millisecond
            automation.Settings.AutomationSettings.LoadTimeout = 60000;
        }
    }
}
