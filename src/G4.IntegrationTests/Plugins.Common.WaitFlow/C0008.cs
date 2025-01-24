using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0008(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // Assert action: Asserts that the element with id "ElementSelected" is selected
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementSelected}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementSelected"
                },
                // InvokeClick action: Invokes a click on the button element that contains the onclick attribute with 'ElementSelected'
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "//button[contains(@onclick,'ElementSelected')]"
                },
                // WaitFlow action: Waits until the element with id "ElementSelected" is not selected for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:ElementNotSelected --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementSelected"
                },
                // Assert action: Asserts that the element with id "ElementSelected" is not selected
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementNotSelected}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementSelected"
                }
            ];
        }
    }
}
