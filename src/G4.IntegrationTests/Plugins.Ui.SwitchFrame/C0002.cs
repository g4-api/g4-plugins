using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SwitchFrame
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // SwitchFrame action: Switches to the frame with ID "FrameOne".
                new ActionRuleModel
                {
                    PluginName = "SwitchFrame",
                    OnElement = "#FrameOne",
                    Locator = Locators.CssSelector
                },
                // SendKeys action: Sends the keys "Foo Bar" to the element with ID "Input1".
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "Foo Bar",
                    OnElement = "#Input1",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the element with ID "Input1" matches "(?i)Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)Foo Bar}}",
                    OnElement = "#Input1",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
