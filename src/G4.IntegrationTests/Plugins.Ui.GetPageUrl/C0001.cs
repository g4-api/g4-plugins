using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.GetPageUrl
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Gets the plugin name from the environment parameters, defaulting to "Get-PageUrl"
            var pluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "Get-PageUrl");

            // Define a sequence of action rule models to return
            return
            [
                // RegisterParameter action: Registers the PageUrl parameter
                // with the current page URL, scoped to the session
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:PageUrl --Value:{{$Get-PageUrl}} --Scope:Session}}"
                },
                // SendKeys action: Sends the value of the specified plugin to the element with id "MacroResult"
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$" + pluginName + "}}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the value attribute of the element with id "MacroResult"
                // is equal to the value of the PageUrl parameter
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Attribute " +
                        "--Operator:Equal " +
                        "--Expected:{{$Get-Parameter --Name:PageUrl --Scope:Session}}}}",
                    OnAttribute = "value",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
