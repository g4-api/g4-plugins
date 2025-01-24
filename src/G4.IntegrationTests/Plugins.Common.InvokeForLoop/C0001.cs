using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.InvokeForLoop
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // InvokeForLoop action: Clicks the "Next" button 5 times
                new ActionRuleModel()
                {
                    PluginName = "InvokeForLoop",
                    Argument = "5",
                    // Rules for the InvokeForLoop action
                    Rules =
                    [
                        // Click action: Clicks the "Next" button
                        new ActionRuleModel()
                        {
                            PluginName = "Click",
                            OnElement = "#NextBtn1",
                            Locator = Locators.CssSelector
                        }
                    ]
                },
                // Assertion action: Asserts that the button with the text "6" has the class "active"
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
                    OnElement = "//ul[@id='Pagination1']/li/button[.='6']",
                    OnAttribute = "class"
                }
            ];
        }
    }
}
