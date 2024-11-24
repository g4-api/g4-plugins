using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0010(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // Assert action: Asserts that the element with id "ElementNotSelected" is not selected
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementNotSelected}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementNotSelected"
                },
                // InvokeClick action: Invokes a click on the button element that contains the onclick attribute with 'ElementNotSelected'
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "//button[contains(@onclick,'ElementNotSelected')]"
                },
                // WaitFlow action: Waits until the element with id "ElementNotSelected" is selected for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:ElementSelected --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementNotSelected"
                },
                // Assert action: Asserts that the element with id "ElementNotSelected" is selected
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementSelected}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementNotSelected"
                }
            ];
        }
    }
}
