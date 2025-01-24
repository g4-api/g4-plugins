using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SwitchAlert
{
    internal class C0004(TestContext context) : TestCaseBase(context)
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
                // "Foo Bar" to it, and accepts the alert.
                new ActionRuleModel
                {
                    PluginName = "SwitchAlert",
                    Argument = "{{$ --Keys:Foo Bar --AlertAction:Accept}}",
                },
                // Assert action: Asserts that the attribute of the element
                // with ID "PromptResult" matches "(?i)Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)Foo Bar}}",
                    OnElement = "#PromptResult",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
