using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SwitchParentFrame
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // SwitchFrame action: Switches to the frame at index 0.
                new ActionRuleModel
                {
                    PluginName = "SwitchFrame",
                    Argument = "0"
                },
                // SwitchFrame action: Switches to the frame at index 0 (repeated).
                new ActionRuleModel
                {
                    PluginName = "SwitchFrame",
                    Argument = "0"
                },
                // SendKeys action: Sends the keys "Foo Bar" to the element with ID "TextInput".
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "Foo Bar",
                    OnElement = "#TextInput",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the element
                // with ID "TextInput" matches "(?i)Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)Foo Bar}}",
                    OnElement = "#TextInput",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // SwitchParentFrame action: Switches to the parent frame.
                new ActionRuleModel
                {
                    PluginName = "SwitchParentFrame"
                },
                // SendKeys action: Sends the keys "Foo Bar" to the element with ID "Input1".
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "Foo Bar",
                    OnElement = "#Input1",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the attribute value of the element
                // with ID "Input1" matches "(?i)Foo Bar".
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
