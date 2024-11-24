using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.CloseWindow
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Gets the pluginName value from the environment parameters
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
                // CloseWindow action: Closes the browser window
                new ActionRuleModel
                {
                    PluginName = pluginName,
                    Argument = "2"
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
