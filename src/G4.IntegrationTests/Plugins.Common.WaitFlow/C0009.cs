using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0009(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // Assert action: Asserts that the element with id "ElementVisible" is visible
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementVisible}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementVisible"
                },
                // InvokeClick action: Invokes a click on the button element that contains the onclick attribute with 'ElementVisible'
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "//button[contains(@onclick,'ElementVisible')]"
                },
                // WaitFlow action: Waits until the element with id "ElementVisible" is not visible for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:ElementNotVisible --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementVisible"
                },
                // Assert action: Asserts that the element with id "ElementVisible" is not visible
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementNotVisible}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementVisible"
                }
            ];
        }
    }
}
