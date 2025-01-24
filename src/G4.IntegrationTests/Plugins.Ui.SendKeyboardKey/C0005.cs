using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SendKeyboardKey
{
    internal class C0005(TestContext context) : TestCaseBase(context)
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
                // Assert action: Asserts that the attribute value of the specified element
                // is equal to "KeyboardKeyOutcome".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:KeyboardKeyOutcome}}",
                    OnElement = "#KeyboardKeyOutcome",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // SendKeyboardKey action: Clears any existing text in the element
                // and sends keyboard key "Enter".
                new ActionRuleModel
                {
                    PluginName = "SendKeyboardKey",
                    Argument = "{{$ --Key:Enter --Clear}}",
                    OnElement = "#KeyboardKeyOutcome",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the first specified
                // element is equal to "Enter".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:Enter}}",
                    OnElement = "//div[@id='KeyboardKeysList']/div",
                    OnAttribute = "name"
                }
            ];
        }

        protected override void OnAutomation(G4AutomationModel automation, AutomationEnvironment environment)
        {
            // Set the flag to return performance points in the automation settings.
            automation.Settings.PerformancePointsSettings.ReturnPerformancePoints = true;
        }
    }
}
