using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.UndoNavigation
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // OpenUrl action: Opens the URL obtained from Get-PageUrl with "?Page=1" appended.
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    Argument = "{{$Get-PageUrl}}?Page=1"
                },
                // Assert action: Asserts that the page URL matches the regular expression "(?i).*page=1$".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i).*page=1$}}"
                },
                // NavigateBack action: Navigates back to the previous page.
                new ActionRuleModel
                {
                    PluginName = "NavigateBack"
                },
                // Assert action: Asserts that the page URL does not contain "page=1".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i)^(?!.*page=1).*$}}"
                }
            ];
        }
    }
}
