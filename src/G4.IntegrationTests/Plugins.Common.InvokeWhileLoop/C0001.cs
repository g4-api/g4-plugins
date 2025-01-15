using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.InvokeWhileLoop
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // InvokeWhileLoop action: Clicks the "Next" button until the button with
                // text "6" has the class "active"
                new ActionRuleModel()
                {
                    PluginName = "InvokeWhileLoop",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:(?i)active}}",
                    OnElement = "//ul[@id='Pagination1']/li/button[.='6']",
                    OnAttribute = "class",
                    // Rules for the InvokeWhileLoop action
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
                // Assertion action: Asserts that the button with text "6" has the class "active"
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
