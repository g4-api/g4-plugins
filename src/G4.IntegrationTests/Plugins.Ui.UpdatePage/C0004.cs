using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.UpdatePage
{
    internal class C0004(TestContext context) : TestCaseBase(context)
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
                // with ID "SendKeys" using CSS selector matches "(?i)foo bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo bar}}",
                    OnElement = "#SendKeys",
                    Locator = "CssSelector",
                    OnAttribute = "value"
                },
                // RefreshPage action: Refreshes the page with a delay of 4 times, each
                // with a delay of 1000 milliseconds.
                new ActionRuleModel
                {
                    PluginName = "RefreshPage",
                    Argument = "{{$ --Repeat:4 --Delay:1000}}"
                },
                // Assert action: Asserts that the value attribute of the element
                // with ID "SendKeys" using CSS selector is empty.
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
