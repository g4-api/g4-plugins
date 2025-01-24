using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.InvokeScroll
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Retrieves necessary parameters from the environment
            var argument = environment.TestParameters["argument"];
            var left = environment.TestParameters["left"];
            var top = environment.TestParameters["top"];

            // Defines a sequence of action rule models to return
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // InvokeScroll action: Scrolls the textarea enabled element according to the specified argument
                new ActionRuleModel
                {
                    PluginName = "InvokeScroll",
                    Argument = $"{argument}",
                    OnElement = "#TextAreaEnabled",
                    Locator = Locators.CssSelector
                },
                // Wait action: Waits for 1000 milliseconds
                new ActionRuleModel
                {
                    PluginName = "Wait",
                    Argument = "1000"
                },
                // Assert action: Asserts the equality of the left attribute to the specified value
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:" + left +"}}",
                    OnElement = "#ElementScrollLeftOutcome",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts the equality of the top attribute to the specified value
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:" + top +"}}",
                    OnElement = "#ElementScrollTopOutcome",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
