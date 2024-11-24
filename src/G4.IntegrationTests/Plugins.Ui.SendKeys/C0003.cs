using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SendKeys
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Returns a collection of action rule models
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // Assert action: Asserts that the attribute value of the specified element
                // "#InputEnabledWithText" is not equal to "Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:NotEqual --Expected:Foo Bar}}",
                    OnElement = "#InputEnabledWithText",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // SendKeys action: Sends keys "Foo Bar" to the specified element
                // "#InputEnabledWithText" after clearing it.
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$ --Keys:Foo Bar --Clear}}",
                    OnElement = "#InputEnabledWithText",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the specified element
                // "#InputEnabledWithText" is equal to "Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:Foo Bar}}",
                    OnElement = "#InputEnabledWithText",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
