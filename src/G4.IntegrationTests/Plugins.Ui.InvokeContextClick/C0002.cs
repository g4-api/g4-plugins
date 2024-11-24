using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.InvokeContextClick
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
                // MoveMouseCursor action: Moves the mouse cursor to coordinates (750, 350)
                new ActionRuleModel
                {
                    PluginName = "MoveMouseCursor",
                    Argument = "{{$ --X:750 --Y: 350}}"
                },
                // InvokeContextClick action: Context-clicks at the current mouse cursor position
                new ActionRuleModel
                {
                    PluginName = "InvokeContextClick"
                },
                // Assert action: Asserts the equality of an element attribute to "context on body"
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:context on body}}",
                    OnAttribute = "value",
                    OnElement = "#EventOutcome",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
