using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.RedoNavigation
{
    internal class C0004(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
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
                // OpenUrl action: Opens the URL with an appended query parameter (Page=2)
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    Argument = "{{$Get-PageUrl}}?Page=2"
                },
                // Assert action: Asserts that the page URL matches the expected pattern with page=2
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i).*page=2$}}"
                },
                // OpenUrl action: Opens the URL with an appended query parameter (Page=3)
                new ActionRuleModel
                {
                    PluginName = "OpenUrl",
                    Argument = "{{$Get-PageUrl}}?Page=3"
                },
                // Assert action: Asserts that the page URL matches the expected pattern with page=3
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i).*page=3$}}"
                },
                // UndoNavigation action: Undoes the last 3 navigation actions with a delay of 1000 milliseconds between each action
                new ActionRuleModel
                {
                    PluginName = "UndoNavigation",
                    Argument = "{{$ --Repeat:3 --Delay:1000}}"
                },
                // Assert action: Asserts that the page URL does not contain any page number after undoing navigation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i)^(?!.*page=\\d+).*$}}"
                },
                // RedoNavigation action: Redoes the last 3 undone navigation actions with a delay of 1000 milliseconds between each action
                new ActionRuleModel
                {
                    PluginName = "RedoNavigation",
                    Argument = "{{$ --Repeat:3 --Delay:1000}}"
                },
                // Assert action: Asserts that the page URL matches the expected pattern with page=3 after redoing navigation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:PageUrl --Operator:Match --Expected:(?i).*page=3$}}"
                }
            ];
        }

        protected override void OnAutomation(G4AutomationModel automation, AutomationEnvironment environment)
        {
            // Enables returning performance points in the automation settings
            automation.Settings.PerformancePointsSettings.ReturnPerformancePoints = true;
        }
    }
}
