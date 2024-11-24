using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.UndoNavigation
{
    internal class C0005(TestContext context) : TestCaseBase(context)
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
                // NavigateBack action: Navigates back 3 steps with a delay of 1 second between each step.
                new ActionRuleModel
                {
                    PluginName = "NavigateBack",
                    Argument = "{{$ --Repeat:3 --Delay:00:00:01}}"
                },
                // Assert action: Asserts that the page URL does not contain "page=1", "page=2", or "page=3".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i)^(?!.*page=\\d+).*$}}"
                }
            ];
        }

        protected override void OnAutomation(G4AutomationModel automation, AutomationEnvironment environment)
        {
            // Enable the flag to return performance points in the automation settings.
            automation.Settings.PerformancePointsSettings.ReturnPerformancePoints = true;
        }
    }
}
