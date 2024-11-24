using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.InvokeClick
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Gets the condition, operator, expected value, and number of clicks from
            // the environment parameters
            var condition = environment.TestParameters["condition"];
            var @operator = environment.TestParameters["operator"];
            var expected = environment.TestParameters["expected"];
            var clicks = environment.TestParameters["clicks"];

            // Defines a sequence of action rule models to return
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // InvokeClick action: Clicks on the element until the condition is met with
                // the specified operator and number of clicks
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    Argument = "{{$ " +
                        "--Polling:1.0 " +
                        "--Condition:" + condition + " " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + clicks + "}}",
                    OnElement = "#UntilAttribute",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the condition with the specified operator and
                // expected value is met on the element
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:" + condition + " " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + "}}",
                    OnElement = "#UntilAttribute",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
