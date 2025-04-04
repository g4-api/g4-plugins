﻿using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SendKeys
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Get the delay from test parameters
            var delay = environment.TestParameters["delay"];

            // Returns a collection of action rule models
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // SendKeys action: Sends keys "Foo Bar" to the specified element "#InputText"
                // with the specified delay.
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$ --Keys:Foo Bar --Delay:" + delay + "}}",
                    OnElement = "#InputText",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the specified element
                // "#InputText" is equal to "Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:Foo Bar}}",
                    OnElement = "#InputText",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
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
