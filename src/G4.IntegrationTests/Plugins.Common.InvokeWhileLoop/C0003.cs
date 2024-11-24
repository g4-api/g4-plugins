using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.InvokeWhileLoop
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the timeout value from the test parameters
            var timeout = environment.TestParameters["timeout"];

            // Return a collection of action rule models
            return
            [
                // InvokeWhileLoop action: Clicks the "Next" button until the button with
                // text "6" has the class "foo" within the specified timeout
                new ActionRuleModel()
                {
                    PluginName = "InvokeWhileLoop",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo --Timeout:" + timeout + "}}",
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
                }
            ];
        }

        protected override void OnAutomation(G4AutomationModel automation, AutomationEnvironment environment)
        {
            // Enable returning performance points in settings
            automation.Settings.PerformancePointsSettings.ReturnPerformancePoints = true;

            // Call the base implementation of OnAutomation method
            base.OnAutomation(automation, environment);
        }
    }
}
