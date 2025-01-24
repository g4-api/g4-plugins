using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0011(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // InvokeClick action: Invokes a click on the element with id "SetStaleElement"
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    Locator = Locators.CssSelector,
                    OnElement = "#SetStaleElement"
                },
                // WaitFlow action: Waits until the element with id "StaleElement" becomes stale for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:ElementStale --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#StaleElement"
                },
                // Assert action: Asserts that the element with id "StaleElement" is stale
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementStale}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#StaleElement"
                }
            ];
        }
    }
}
