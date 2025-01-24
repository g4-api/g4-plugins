using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SendKeyboardKey
{
    internal class C0002(TestContext context) : TestCaseBase(context)
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
                // SendKeyboardKey action: Sends a keyboard key (Enter) and captures the outcome.
                new ActionRuleModel
                {
                    PluginName = "SendKeyboardKey",
                    Argument = "{{$ --Key:Enter}}",
                    OnElement = "#KeyboardKeyOutcome",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the specified element
                // is equal to "Enter".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:Enter}}",
                    OnElement = "//div[@id='KeyboardKeysList']/div",
                    OnAttribute = "name"
                }
            ];
        }
    }
}
