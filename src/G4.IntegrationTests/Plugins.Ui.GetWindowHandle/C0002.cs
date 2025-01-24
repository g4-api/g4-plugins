using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.GetWindowHandle
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Gets the plugin name from the environment parameters, defaulting to "Get-WindowHandle"
            var pluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "Get-WindowHandle");

            // Define a sequence of action rule models to return
            return
            [
                // InvokeClick action: Clicks on the element with id "OpenNewTab"
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "#OpenNewTab",
                    Locator = Locators.CssSelector
                },
                // RegisterParameter action: Registers the window handle of the second tab obtained from
                // the Get-WindowHandle plugin with session scope
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:WindowHandle --Value:{{$Get-WindowHandle --Index:1}} --Scope:Session}}"
                },
                // SendKeys action: Sends the window handle of the second tab obtained from the specified
                // plugin to the element with id "MacroResult"
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$" + pluginName + " --Index:1}}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the value attribute of the element with id "MacroResult"
                // is equal to the window handle of the second tab
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
