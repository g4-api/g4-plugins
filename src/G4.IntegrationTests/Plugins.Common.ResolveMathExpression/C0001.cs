using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.ResolveMathExpression
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Retrieve test parameters
            var resolveMathExpressionMacro = environment.TestParameters["macro"];
            var expectedPattern = environment.TestParameters["expectedPattern"];

            // Return a collection of action rule models
            return
            [
                // SendKeys action: Sends the resolveMathExpressionMacro to the element
                // with ID "MacroResult"
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = $"{resolveMathExpressionMacro}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assertion action: Asserts that the value attribute of the element
                // with ID "MacroResult" matches the expected pattern
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
