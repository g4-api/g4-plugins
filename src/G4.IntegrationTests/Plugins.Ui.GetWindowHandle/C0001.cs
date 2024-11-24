using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.GetWindowHandle
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Gets the plugin name from the environment parameters, defaulting to "Get-WindowHandle"
            var pluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "Get-WindowHandle");

            // Define a sequence of action rule models to return
            return
            [
                // RegisterParameter action: Registers the window handle obtained from the
                // Get-WindowHandle plugin with session scope
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:WindowHandle --Value:{{$Get-WindowHandle}} --Scope:Session}}"
                },
                // SendKeys action: Sends the window handle obtained from the specified plugin
                // to the element with id "MacroResult"
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$" + pluginName + "}}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the value attribute of the element
                // with id "MacroResult" is equal to the window handle
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Attribute " +
                        "--Operator:Equal " +
                        "--Expected:{{$Get-Parameter --Name:WindowHandle --Scope:Session}}}}",
                    OnAttribute = "value",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
