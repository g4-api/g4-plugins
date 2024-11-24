using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.UpdatePage
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // SendKeys action: Sends "Foo Bar" to the element with ID "SendKeys" using CSS selector.
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "Foo Bar",
                    OnElement = "#SendKeys",
                    Locator = "CssSelector"
                },
                // Assert action: Asserts that the value attribute of the element
                // with ID "SendKeys" using CSS selector matches "(?i)foo bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)foo bar}}",
                    OnElement = "#SendKeys",
                    Locator = "CssSelector",
                    OnAttribute = "value"
                },
                // UpdatePage action: Updates the page.
                new ActionRuleModel
                {
                    PluginName = "UpdatePage"
                },
                // Assert action: Asserts that the value attribute of the element
                // with ID "SendKeys" using CSS selector is empty.
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Equal --Expected:}}",
                    OnElement = "#SendKeys",
                    Locator = "CssSelector",
                    OnAttribute = "value"
                }
            ];
        }
    }
}
