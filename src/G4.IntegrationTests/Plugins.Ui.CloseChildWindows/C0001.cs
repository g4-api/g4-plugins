using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.CloseChildWindows
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Gets the argument and expected values from the environment parameters
            var argument = $"{environment.TestParameters["argument"]}";
            var expected = environment.TestParameters["expected"];

            // Define a sequence of action rule models to return
            return
            [
                // NewBrowserWindow action: Opens a new browser window, with an amount of 3 windows
                new ActionRuleModel
                {
                    PluginName = "NewBrowserWindow",
                    Argument = "{{$ --Amount:3}}",
                },
                // Assert action: Asserts that the count of windows is equal to 4
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:WindowsCount --Operator:Equal --Expected:4}}"
                },
                // CloseAllChildWindows action: Closes all child windows if the 'argument' parameter is provided
                new ActionRuleModel
                {
                    PluginName = "CloseAllChildWindows",
                    Argument = string.IsNullOrEmpty(argument) ? null : argument
                },
                // Assert action: Asserts that the count of windows is equal to the expected value
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:WindowsCount --Operator:Equal --Expected:" + expected + "}}"
                }
            ];
        }
    }
}
