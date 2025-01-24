using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0015(TestContext context) : TestCaseBase(context)
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
                // Assert action: Asserts that the element count is 0
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:ElementCount --Operator:Eq --Expected:0 --Timeout:00:00:15}}",
                    OnElement = "//div[@id='ElementCount']/span[@automation-data='ElementCount']",
                    PluginName = "Assert"
                },
                // InvokeClick action: Invokes a click on the element with id "ElementCountSwitch"
                new ActionRuleModel
                {
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementCountSwitch",
                    PluginName = "InvokeClick"
                },
                // WaitFlow action: Waits until the element count meets the specified condition
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:ElementCount " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    OnElement = "//div[@id='ElementCount']/span[@automation-data='ElementCount']",
                    PluginName = "WaitFlow"
                },
                // Assert action: Asserts that the element count meets the specified condition
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:ElementCount " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    OnElement = "//div[@id='ElementCount']/span[@automation-data='ElementCount']",
                    PluginName = "Assert"
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
