using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.UpdatePage
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // SendKeys action: Sends "Foo Bar" to the element with ID "SendKeys" using CSS selector.
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "Foo Bar",
                    OnElement = "#SendKeys",
                    Locator = "CssSelector"
                },
                // Assert action: Asserts that the value attribute of the element
                // with ID "SendKeys" matches "(?i)foo bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo bar}}",
                    OnElement = "#SendKeys",
                    Locator = "CssSelector",
                    OnAttribute = "value"
                },
                // UpdatePage action: Updates the page 4 times with a delay of 1 second between updates.
                new ActionRuleModel
                {
                    PluginName = "UpdatePage",
                    Argument = "{{$ --Repeat:4 --Delay:00:00:01}}"
                },
                // Assert action: Asserts that the value attribute of the element
                // with ID "SendKeys" is equal to an empty string.
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:}}",
                    OnElement = "#SendKeys",
                    Locator = "CssSelector",
                    OnAttribute = "value"
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
