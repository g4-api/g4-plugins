using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.MoveMouseCursor
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
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
                // MoveMouseCursor action: Moves the mouse cursor to the specified coordinates
                new ActionRuleModel
                {
                    PluginName = "MoveMouseCursor",
                    Argument = "{{$ --X:100 --Y:150}}"
                },
                // Assert action: Asserts that the text of the MouseXPosition element equals 100
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:100}}",
                    OnElement = "#MouseXPosition",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the text of the MouseYPosition element equals 150
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementText --Operator:Equal --Expected:150}}",
                    OnElement = "#MouseYPosition",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
