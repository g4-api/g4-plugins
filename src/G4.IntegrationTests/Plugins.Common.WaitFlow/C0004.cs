using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0004(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // Assert action: Asserts that the element with id "ElementDisabled" is disabled
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementDisabled}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementDisabled"
                },
                // InvokeClick action: Invokes a click on the button containing "ElementDisabled" in its onclick attribute
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "//button[contains(@onclick,'ElementDisabled')]"
                },
                // WaitFlow action: Waits until the element with id "ElementDisabled" becomes enabled for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:ElementEnabled --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementDisabled"
                },
                // Assert action: Asserts that the element with id "ElementDisabled" is enabled
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementEnabled}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementDisabled"
                }
            ];
        }
    }
}
