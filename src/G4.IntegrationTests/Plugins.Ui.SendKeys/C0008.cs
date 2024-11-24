using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SendKeys
{
    internal class C0008(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Returns a collection of action rule models
            return
            [
                // SetWindowState action: Maximizes the browser window
                new()
                {
                    PluginName = "SetWindowState",
                    Argument = "Maximized"
                },
                // Assert action: Asserts that the specified element "#InputText" has an empty value.
                new()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:}}",
                    OnElement = "#InputText",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                },
                // SendKeys action: Sends keys "s" to the specified element "#InputText"
                // with Control and Alt modifiers.
                new()
                {
                    PluginName = "SendKeys",
                    Argument = "{{$ --Keys:s --Modifier:Control --Modifier:Alt}}",
                    OnElement = "#InputText",
                    Locator = Locators.CssSelector
                },
                // WaitFlow action: Waits for 1500 milliseconds
                new()
                {
                    PluginName = "WaitFlow",
                    Argument = "1500"
                },
                // Assert action: Asserts that the specified element "#InputText"
                // has the value "Ctrl+Alt+S detected" after sending keys.
                new()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:Ctrl+Alt+S detected}}",
                    OnElement = "#InputText",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
