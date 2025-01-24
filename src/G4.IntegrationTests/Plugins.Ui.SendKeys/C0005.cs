using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SendKeys
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Returns a collection of action rule models
            return
            [
                // SetWindowState action: Maximizes the browser window
                new ActionRuleModel
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // Assert action: Asserts that the specified element "#TextAreaSelected" is not selected.
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementNotSelected}}",
                    OnElement = "#TextAreaSelected",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // SendKeys action: Sends keys "A" to the specified element "#TextAreaEnabled"
                // with Control modifier.
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$ --Keys:A --Modifier:Control}}",
                    OnElement = "#TextAreaEnabled",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the specified element "#TextAreaSelected" is
                // selected after sending keys.
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementSelected}}",
                    OnElement = "#TextAreaSelected",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
