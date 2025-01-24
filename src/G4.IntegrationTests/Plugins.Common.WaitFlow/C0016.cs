using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0016(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Gets the operator from the environment parameters, with a default value
            // of "Eq" if not provided.
            var @operator = environment.TestParameters.Get(key: "operator", defaultValue: "Eq");

            // Gets the expected value from the environment parameters, with a default value
            // of an empty string if not provided.
            var expected = environment.TestParameters.Get(key: "expected", defaultValue: string.Empty);

            // Define a sequence of action rule models to return
            return
            [
                // Assert action: Asserts that the element count is equal to 3
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementCount --Operator:Eq --Expected:3 --Timeout:00:00:15}}",
                    OnElement = "//div[@id='ElementCountDecrease']/span[@automation-data='ElementCount']"
                },
                // InvokeClick action: Invokes a click on the element with
                // id "ElementCountDecreaseSwitch"
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementCountDecreaseSwitch"
                },
                // WaitFlow action: Waits until the condition ElementCount with the specified
                // operator and expected value is met for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:ElementCount --Operator:" + @operator + " --Expected:" + expected + " --Timeout:00:00:15}}",
                    OnElement = "//div[@id='ElementCountDecrease']/span[@automation-data='ElementCount']"
                },
                // Assert action: Asserts that the condition ElementCount with the specified
                // operator and expected value is met
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementCount --Operator:" + @operator + " --Expected:" + expected + " --Timeout:00:00:15}}",
                    OnElement = "//div[@id='ElementCountDecrease']/span[@automation-data='ElementCount']"
                }
            ];
        }

        protected override void OnAutomation(G4AutomationModel automation, AutomationEnvironment environment)
        {
            // Set the search timeout to 1 millisecond
            automation.Settings.AutomationSettings.SearchTimeout = 1;

            // Set the load timeout to 1 millisecond
            automation.Settings.AutomationSettings.LoadTimeout = 60000;
        }
    }
}
