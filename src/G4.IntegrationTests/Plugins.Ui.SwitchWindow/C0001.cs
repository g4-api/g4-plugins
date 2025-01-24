using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SwitchWindow
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // NewBrowserWindow action: Opens a new browser window.
                new ActionRuleModel
                {
                    PluginName = "NewBrowserWindow"
                },
                // SwitchWindow action: Switches to the window at index 1.
                new ActionRuleModel
                {
                    PluginName = "SwitchWindow",
                    Argument = "1"
                },
                // Assert action: Asserts that the page URL matches "about:blank".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:about:blank}}"
                }
            ];
        }
    }
}
