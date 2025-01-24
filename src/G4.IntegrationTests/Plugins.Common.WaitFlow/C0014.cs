using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0014(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Gets the operator from the environment parameters, with a default value
            // of "Eq" if not provided.
            var @operator = environment.TestParameters.Get(key: "operator", defaultValue: "Eq");

            // Gets the expected value from the environment parameters, with a default value
            // of an empty string if not provided.
            var expected = environment.TestParameters.Get(key: "expected", defaultValue: string.Empty);

            // Define a sequence of action rule models to return
            return
            [
                // Assert action: Asserts that the attribute value of the element with
                // id "ElementAttribute" satisfies the condition with the specified operator
                // for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Eq --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementAttribute",
                    OnAttribute = "value"
                },
                // InvokeClick action: Invokes a click on the element with
                // id "ElementAttributeSwitch"
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementAttributeSwitch"
                },
                // WaitFlow action: Waits until the attribute value of the element with
                // id "ElementAttribute" satisfies the condition with the specified operator
                // and expected value for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ " +
                        "--Condition:ElementAttribute " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementAttribute",
                    OnAttribute = "value"
                },
                // Assert action: Asserts that the attribute value of the element with
                // id "ElementAttribute" satisfies the condition with the specified operator
                // and expected value
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:ElementAttribute " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementAttribute",
                    OnAttribute = "value"
                }
            ];
        }
    }
}
