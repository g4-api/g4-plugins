using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0018(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Gets the operator from the environment parameters, with a default value
            // of "Eq" if not provided.
            var @operator = environment.TestParameters.Get(key: "operator", defaultValue: "Eq");

            // Gets the expected value from the environment parameters, with a default value
            // of an empty string if not provided.
            var expected = environment.TestParameters.Get(key: "expected", defaultValue: string.Empty);

            // Gets the input value from the environment parameters, with a default value
            // of an empty string if not provided.
            var input = environment.TestParameters.Get(key: "input", defaultValue: string.Empty);

            // Define a sequence of action rule models to return
            return
            [
                // Assert action: Asserts that the length of the element text is equal to 12 characters
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:ElementTextLength " +
                        "--Operator:Eq --Expected:12 " +
                        "--Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementText",
                    PluginName = "Assert"
                },
                // InvokeScript action: Invokes a JavaScript function to set the text
                // of the element with id "ElementText" to the provided input value
                new ActionRuleModel
                {
                    Argument = "setElementText('ElementText', '" + input + "');",
                    PluginName = "InvokeScript"
                },
                // WaitFlow action: Waits until the condition ElementTextLength with
                // the specified operator and expected value is met for a maximum of 15 seconds
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:ElementTextLength " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementText",
                    PluginName = "WaitFlow"
                },
                // Assert action: Asserts that the condition ElementTextLength with
                // the specified operator and expected value is met
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:ElementTextLength " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementText",
                    PluginName = "Assert"
                }
            ];
        }
    }
}
