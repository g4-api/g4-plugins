using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.RedoNavigation
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Defines a sequence of action rule models to return
            return
            [
                // OpenUrl action: Opens the URL with an appended query parameter (Page=1)
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    Argument = "{{$Get-PageUrl}}?Page=1"
                },
                // Assert action: Asserts that the page URL matches the expected pattern with page=1
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i).*page=1$}}"
                },
                // UndoNavigation action: Undoes the last navigation action
                new ActionRuleModel
                {
                    PluginName = "UndoNavigation"
                },
                // Assert action: Asserts that the page URL does not contain page=1 after undoing navigation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i)^(?!.*page=1).*$}}"
                },
                // RedoNavigation action: Redoes the last undone navigation action
                new ActionRuleModel
                {
                    PluginName = "RedoNavigation"
                },
                // Assert action: Asserts that the page URL matches the expected pattern
                // with page=1 after redoing navigation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i).*page=1$}}"
                }
            ];
        }
    }
}
