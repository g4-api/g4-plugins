using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.FormatNumber
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieve macro format number and expected pattern from environment test parameters
            var formatNumber = environment.TestParameters["macro"];
            var expectedPattern = environment.TestParameters["expectedPattern"];

            // Return a collection of action rule models
            return
            [
                // Send keys action: Sends the macro format number to an element
                // with ID "MacroResult"
                new ActionRuleModel()
                {
                    PluginName = "SendKeys",
                    Argument = $"{formatNumber}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assertion action: Asserts that the value attribute of the element
                // with ID "MacroResult" matches the expected pattern
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Attribute " +
                        "--Operator:Match " +
                        "--Expected:" + expectedPattern + "}}",
                    OnAttribute = "value",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
