using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.GetAlertText
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Gets the plugin name from the environment parameters, defaulting to "Get-AlertText"
            var pluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "Get-AlertText");

            // Define a sequence of action rule models to return
            return
            [
                // InvokeClick action: Clicks on the element with id "OpenNewAlert"
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "#OpenNewAlert",
                    Locator = Locators.CssSelector
                },
                // RegisterParameter action: Registers the alert text as a session parameter with a pattern matching condition
                new ActionRuleModel
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:AlertText --Value:{{$" + pluginName + " --Pattern:^Welcome}} --Scope:Session}}"
                },
                // SwitchToAlert action: Switches to the alert dialog and dismisses it
                new ActionRuleModel
                {
                    PluginName = "SwitchToAlert",
                    Argument = "{{$ --AlertAction:Dismiss}}"
                },
                // SendKeys action: Sends the registered alert text to the element with id "MacroResult"
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$Get-Parameter --Name:AlertText --Scope:Session}}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the value attribute of the element
                // with id "MacroResult" is equal to "Welcome"
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Attribute " +
                        "--Operator:Equal " +
                        "--Expected:Welcome}}",
                    OnAttribute = "value",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
