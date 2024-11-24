using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.InvokeForLoop
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // Outer InvokeForLoop action: Clicks the "Next" button twice for the second pagination
                new ActionRuleModel()
                {
                    PluginName = "InvokeForLoop",
                    Argument = "2",
                    // Rules for the outer InvokeForLoop action
                    Rules =
                    [
                        // Inner InvokeForLoop action: Clicks the "Next" button twice for the second pagination
                        new ActionRuleModel()
                        {
                            PluginName = "InvokeForLoop",
                            Argument = "2",
                            // Rules for the inner InvokeForLoop action
                            Rules =
                            [
                                // Click action: Clicks the "Next" button for the second pagination
                                new ActionRuleModel()
                                {
                                    PluginName = "Click",
                                    OnElement = "#NextBtn2",
                                    Locator = Locators.CssSelector
                                }
                            ]
                        },
                        // Assertion action: Asserts that the button with the text "3" has the
                        // class "active" for the second pagination
                        new ActionRuleModel()
                        {
                            PluginName = "Assert",
                            Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
                            OnElement = "//ul[@id='Pagination2']/li/button[.='3']",
                            OnAttribute = "class"
                        },
                        // Click action: Clicks the "First" button for the second pagination
                        new ActionRuleModel()
                        {
                            PluginName = "Click",
                            OnElement = "#FirstBtn2",
                            Locator = Locators.CssSelector
                        },
                        // Click action: Clicks the "Next" button for the first pagination
                        new ActionRuleModel()
                        {
                            PluginName = "Click",
                            OnElement = "#NextBtn1",
                            Locator = Locators.CssSelector
                        }
                    ]
                },
                // Assertion action: Asserts that the button with the text "3" has the
                // class "active" for the first pagination
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)active}}",
                    OnElement = "//ul[@id='Pagination1']/li/button[.='3']",
                    OnAttribute = "class"
                }
            ];
        }
    }
}
