using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.MoveMouseCursor
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
                // Assert action: Asserts the equality of the ScrollOutcomeY attribute to 0
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:0}}",
                    OnElement = "#ScrollOutcomeY",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // MoveMouseCursor action: Moves the mouse cursor to the MoveOutcome element
                new ActionRuleModel
                {
                    PluginName = "MoveMouseCursor",
                    OnElement = "#MoveOutcome",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the ScrollOutcomeY attribute is greater than 0
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Greater --Expected:0}}",
                    OnElement = "#ScrollOutcomeY",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
