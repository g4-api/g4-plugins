using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.NewBrowserWindow
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Retrieves test parameters
            var amount = environment.TestParameters["amount"];
            var url = environment.TestParameters["url"];
            var target = environment.TestParameters["target"];
            var expected = environment.TestParameters["expected"];

            // Defines a sequence of action rule models to return
            return
            [
                // NewBrowserWindow action: Opens a new browser window with the specified URL, amount, and target
                new ActionRuleModel
                {
                    PluginName = "NewBrowserWindow",
                    Argument = "{{$ " +
                    "--Url:" + url + " " +
                    "--Amount:" + amount + " " +
                    "--Target:" + target + "}}",
                },
                // Assert action: Asserts that the number of windows equals the expected value
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:WindowsCount --Operator:Equal --Expected:" + expected + "}}"
                }
            ];
        }
    }
}
