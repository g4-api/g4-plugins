using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.InvokeContextClick
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Defines a sequence of action rule models to return
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // Assert action: Asserts the equality of an element attribute
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal}}",
                    OnAttribute = "value",
                    OnElement = "#ClickButtonOutcome",
                    Locator = Locators.CssSelector
                },
                // InvokeContextClick action: Context-clicks on the element
                new ActionRuleModel
                {
                    PluginName = "InvokeContextClick",
                    OnElement = "#ClickButton",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts the equality of an element attribute to "context on element"
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:context on element}}",
                    OnAttribute = "value",
                    OnElement = "#ClickButtonOutcome",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
