/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.GetPageUrl
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Gets the plugin name from the environment parameters, defaulting to "Get-PageUrl"
            var pluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "Get-PageUrl");

            // Define a sequence of action rule models to return
            return
            [
                // OpenUrl action: Opens the URL obtained from the Get-PageUrl plugin
                // with a parameter of 10
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    Argument = "{{$Get-PageUrl}}?param=10"
                },
                // SendKeys action: Sends the numeric value obtained from the specified plugin
                // to the element with id "MacroResult"
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$" + pluginName + " --Pattern:\\d+$}}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the value attribute of the element with id "MacroResult" is equal to 10
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:10}}",
                    OnAttribute = "value",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
