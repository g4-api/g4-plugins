using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.InvokeClick
{
    internal class C0004(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Gets the condition from the environment parameters
            var condition = environment
                .TestParameters
                .Get(key: "condition", defaultValue: "HasNoAlert");

            var assertionCondition = IsNegativeTest ? "HasAlert" : condition;

            // Defines a sequence of action rule models to return
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // InvokeClick action: Clicks on the text input element until the condition is met
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    Argument = "{{$ --Polling:1.0 --Condition:" + condition + "}}",
                    OnElement = "#PopAlert",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts the presence of an alert based on the 'negative' parameter
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:" + assertionCondition + "}}"
                }
            ];
        }
    }
}
