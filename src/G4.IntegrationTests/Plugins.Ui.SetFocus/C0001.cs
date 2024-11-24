using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetFocus
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // Assert action: Asserts that the attribute value of the element with ID "FocusOutcome" is equal to "not focused".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:not focused}}",
                    OnElement = "#FocusOutcome",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // SetFocus action: Sets focus on the element with ID "FocusOutcome".
                new ActionRuleModel
                {
                    PluginName = "SetFocus",
                    OnElement = "#FocusOutcome",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the element with ID "FocusOutcome" is equal to "focused".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:focused}}",
                    OnElement = "#FocusOutcome",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
