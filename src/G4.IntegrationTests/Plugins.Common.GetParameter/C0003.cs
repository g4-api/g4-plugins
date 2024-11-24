using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.GetParameter
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Define expected value and plugin name based on environment test parameters
            const string expected = "Foo Bar";
            var pluginName = environment.TestParameters["pluginName"];

            // Return a collection of action rule models
            return
            [
                // RegisterParameter action: Registers a parameter with the expected value,
                // application scope, and test environment
                new ActionRuleModel()
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ " +
                        "--Name:ParameterName " +
                        "--Value:" + expected + " " +
                        "--Scope:Application " +
                        "--Environment:TestEnvironment}}",
                },
                // SendKeys action: Sends the value of the registered parameter to an element
                // with ID "MacroResult"
                new ActionRuleModel()
                {
                    PluginName = "SendKeys",
                    Argument = "{{$" + pluginName + " " +
                        "--Name:ParameterName " +
                        "--Scope:Application " +
                        "--Environment:TestEnvironment}}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assertion action: Asserts that the value attribute of the element
                // with ID "MacroResult" matches the expected value
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Eq --Expected:" + expected + "}}",
                    OnElement = "#MacroResult",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
