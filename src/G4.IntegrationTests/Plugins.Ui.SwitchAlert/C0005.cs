using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SwitchAlert
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // InvokeClick action: Invokes a click on the element with ID "Prompt".
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "#Prompt",
                    Locator = Locators.CssSelector
                },
                // SwitchAlert action: Switches to the alert dialog, sends keys
                // "Foo Bar" to it, and dismisses the alert.
                new ActionRuleModel
                {
                    PluginName = "SwitchAlert",
                    Argument = "{{$ --Keys:Foo Bar --AlertAction:Dismiss}}",
                },
                // Assert action: Asserts that the attribute of the element
                // with ID "PromptResult" does not match "(?i)Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)Foo Bar}}",
                    OnElement = "#PromptResult",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
