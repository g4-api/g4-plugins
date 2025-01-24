using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0006(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // InvokeClick action: Invokes a click on the element with id "ElementActive"
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementActive"
                },
                // Assert action: Asserts that the element with id "ElementActive" is active
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementActive}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementActive"
                },
                // InvokeScript action: Invokes a JavaScript function to switch the state of the element with id "ElementActive"
                new ActionRuleModel
                {
                    PluginName = "InvokeScript",
                    Argument = "switchElementState('ElementActive');"
                },
                // WaitFlow action: Waits until the element with id "ElementActive" is not active for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:ElementNotActive --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementActive"
                },
                // Assert action: Asserts that the element with id "ElementActive" is not active
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementNotActive}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementActive"
                }
            ];
        }
    }
}
