using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetWindowState
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // SetWindowState action: Sets the window to full screen.
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "FullScreen"
                },
                // Assert action: Asserts that the attribute of the element with ID "EventOutcome"
                // is equal to "window resized".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:window resized}}",
                    OnElement = "#EventOutcome",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
