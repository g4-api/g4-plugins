using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.NewScriptResult
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieves the format number and expected pattern from test parameters
            var formatNumber = environment.TestParameters["macro"];
            var expectedPattern = environment.TestParameters["expectedPattern"];

            // Defines a sequence of action rule models to return
            return
            [
                // SendKeys action: Sends the formatted number to the specified element
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = $"{formatNumber}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the value attribute of the element matches the expected pattern
                new ActionRuleModel
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
