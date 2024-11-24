using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.NewBrowserWindow
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieves the URL from test parameters
            var url = environment.TestParameters["url"];

            // Defines a sequence of action rule models to return
            return
            [
                // NewBrowserWindow action: Opens a new browser window with the specified URL
                new ActionRuleModel
                {
                    PluginName = "NewBrowserWindow",
                    Argument = "{{$ --Url:" + url + "}}",
                },
                // Assert action: Asserts that the number of windows equals 2
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:WindowsCount --Operator:Equal --Expected:2}}"
                },
                // SwitchWindow action: Switches to the second window
                new ActionRuleModel
                {
                    PluginName = "SwitchWindow",
                    Argument = "1"
                },
                // Assert action: Asserts that the page URL of the second window matches the expected URL
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:" + url + "}}"
                }
            ];
        }
    }
}
