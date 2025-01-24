using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetWindowRectangle
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Get the argument from the test parameters
            var argument = environment.TestParameters.Get(key: "argument", defaultValue: string.Empty);

            // Get the expected value from the test parameters
            var expected = environment.TestParameters.Get(key: "expected", defaultValue: string.Empty);

            // Return a collection of action rule models
            return
            [
                // Assert action: Asserts that the attribute 'value' of the element with
                // ID '#Rectangle' does not match the expected value.
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:NotMatch --Expected:" + expected + "}}",
                    OnElement = "#Rectangle",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // SetWindowRectangle action: Sets the window to a specified rectangle.
                new ActionRuleModel
                {
                    PluginName = "SetWindowRectangle",
                    Argument = argument
                },
                // Wait action: Waits for 1000 milliseconds.
                new ActionRuleModel
                {
                    PluginName = "Wait",
                    Argument = "1000"
                },
                // Assert action: Asserts that the attribute 'value' of the element with
                // ID '#Rectangle' matches the expected value.
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Attribute --Operator:Match --Expected:" + expected + "}}",
                    OnElement = "#Rectangle",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
