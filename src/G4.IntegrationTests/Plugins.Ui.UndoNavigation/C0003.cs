using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.UndoNavigation
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
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
                // OpenUrl action: Opens the URL obtained from Get-PageUrl with "?Page=2" appended.
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    Argument = "{{$Get-PageUrl}}?Page=2"
                },
                // Assert action: Asserts that the page URL matches the regular expression "(?i).*page=2$".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i).*page=2$}}"
                },
                // OpenUrl action: Opens the URL obtained from Get-PageUrl with "?Page=3" appended.
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    Argument = "{{$Get-PageUrl}}?Page=3"
                },
                // Assert action: Asserts that the page URL matches the regular expression "(?i).*page=3$".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i).*page=3$}}"
                },
                // NavigateBack action: Navigates back 3 steps.
                new ActionRuleModel
                {
                    PluginName = "NavigateBack",
                    Argument = "{{$ --Repeat:3}}"
                },
                // Assert action: Asserts that the page URL does not contain "page=1", "page=2", or "page=3".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i)^(?!.*page=\\d+).*$}}"
                }
            ];
        }
    }
}
