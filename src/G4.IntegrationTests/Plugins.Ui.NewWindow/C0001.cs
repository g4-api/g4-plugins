using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.NewWindow
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieves the type of window from test parameters
            var type = environment.TestParameters["type"];

            // Defines a sequence of action rule models to return
            return
            [
                // NewWindow action: Opens a new window of the specified type
                new ActionRuleModel
                {
                    PluginName = "NewWindow",
                    Argument = $"{type}"
                },
                // SwitchWindow action: Switches to the newly opened window
                new ActionRuleModel
                {
                    PluginName = "SwitchWindow",
                    Argument = "1"
                },
                // Assert action: Asserts that the page URL matches the expected value (about:blank)
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:about:blank}}"
                }
            ];
        }
    }
}
