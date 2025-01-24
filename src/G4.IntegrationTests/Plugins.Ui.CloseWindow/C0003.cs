using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.CloseWindow
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Gets the plugin name value from the environment parameters, defaulting to "CloseWindow"
            var pluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "CloseWindow");

            // Define a sequence of action rule models to return
            return
            [
                // NewBrowserWindow action: Opens a new browser window, with an amount of 3 windows
                new ActionRuleModel
                {
                    PluginName = "NewBrowserWindow",
                    Argument = "{{$ --Amount:3}}"
                },
                // Assert action: Asserts that the count of windows is equal to 4
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:WindowsCount --Operator:Equal --Expected:4}}"
                },
                // CloseWindow action: Close the window by getting the window handle at index 2
                new ActionRuleModel
                {
                    PluginName = pluginName,
                    Argument = "{{$Get-WindowHandle --Index:2}}"
                },
                // Assert action: Asserts that the count of windows is equal to 3
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:WindowsCount --Operator:Equal --Expected:3}}"
                }
            ];
        }
    }
}
