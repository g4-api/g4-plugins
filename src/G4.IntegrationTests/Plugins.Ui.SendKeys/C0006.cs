using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SendKeys
{
    internal class C0006(TestContext context) : TestCaseBase(context)
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
                // Assert action: Asserts that the text of the specified element "#UrlDivText"
                // equals "Lorem ipsum dolor".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementText --Operator:Eq --Expected:Lorem ipsum dolor}}",
                    OnElement = "#UrlDivText",
                    Locator = Locators.CssSelector
                },
                // SendKeys action: Sends keys "Foo Bar" and performs native clear to the
                // specified element "#UrlDivText".
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$ --Keys:Foo Bar --NativeClear}}",
                    OnElement = "#UrlDivText",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
