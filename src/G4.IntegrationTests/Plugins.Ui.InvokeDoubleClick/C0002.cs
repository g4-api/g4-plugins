using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.InvokeDoubleClick
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Defines a sequence of action rule models to return
            return
            [
                // Assert action: Asserts the equality of an element attribute
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal}}",
                    OnAttribute = "value",
                    OnElement = "#EventOutcome",
                    Locator = Locators.CssSelector
                },
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // MoveMouseCursor action: Moves the mouse cursor to the specified position
                new ActionRuleModel
                {
                    PluginName = "MoveMouseCursor",
                    Argument = "{{$ --X:750 --Y: 350}}"
                },
                // InvokeDoubleClick action: Double-clicks the currently focused element
                new ActionRuleModel
                {
                    PluginName = "InvokeDoubleClick"
                },
                // Assert action: Asserts the equality of an element attribute to "double on body"
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:double on body}}",
                    OnAttribute = "value",
                    OnElement = "#EventOutcome",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
