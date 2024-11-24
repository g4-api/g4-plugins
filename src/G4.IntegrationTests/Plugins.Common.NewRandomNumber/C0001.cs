using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.NewRandomNumber
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieve test parameters
            var newRandomNumberMacro = environment.TestParameters["macro"];
            var minValue = environment.TestParameters["minValue"];
            var maxValue = environment.TestParameters["maxValue"];

            // Return a collection of action rule models
            return
            [
                // SendKeys action: Sends the new random number macro to the element
                // with ID "MacroResult"
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = $"{newRandomNumberMacro}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assertion action: Asserts that the value attribute of the element
                // with ID "MacroResult" is greater than or equal to the min value
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Attribute " +
                        "--Operator:Ge " +
                        "--Expected:" + minValue + "}}",
                    OnAttribute = "value",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assertion action: Asserts that the value attribute of the element
                // with ID "MacroResult" is less than or equal to the max value
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Attribute " +
                        "--Operator:Le " +
                        "--Expected:" + maxValue + "}}",
                    OnAttribute = "value",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
