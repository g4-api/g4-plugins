using G4.Models;
using G4.IntegrationTests.Framework;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.InvokeClick
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Determine the expected value based on the 'negative' parameter
            var expected = IsNegativeTest ? "element click on" : "click on element";

            // Define a sequence of action rule models to return
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // InvokeClick action: Clicks on the element with id "ClickButton"
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "#ClickButton",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute 'value' of the element with id 'ClickButtonOutcome'
                // is equal to the expected value
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Equal --Expected:" + expected +"}}",
                    OnElement = "#ClickButtonOutcome",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
