using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SelectOption
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Retrieve test parameters
            var argument = environment.TestParameters["argument"];
            var attribute = environment.TestParameters["attribute"];
            var expected = environment.TestParameters["expected"];

            // Returns a collection of action rule models
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // SelectOption action: Selects an option from a dropdown list.
                new ActionRuleModel
                {
                    PluginName = "SelectOption",
                    Argument = $"{argument}",
                    OnAttribute = $"{attribute}",
                    OnElement = "#SelectElement",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the specified element
                // is equal to the expected value.
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:" + expected + "}}",
                    OnElement = "#SelectElement",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
