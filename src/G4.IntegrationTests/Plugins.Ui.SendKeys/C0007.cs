using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SendKeys
{
    internal class C0007(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
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
                // SendKeys action: Sends keys "Foo Bar" to the specified element "#InputDisabled".
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "Foo Bar",
                    OnElement = "#InputDisabled",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the value attribute of the specified element
                // "#SendKeys" equals "Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:Foo Bar}}",
                    OnElement = "#InputText",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
