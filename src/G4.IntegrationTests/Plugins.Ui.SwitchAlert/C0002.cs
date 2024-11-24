using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SwitchAlert
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // InvokeClick action: Invokes a click on the element with ID "Confirm".
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "#Confirm",
                    Locator = Locators.CssSelector
                },
                // SwitchAlert action: Switches to the alert dialog and accepts it.
                new ActionRuleModel
                {
                    PluginName = "SwitchAlert",
                    Argument = "{{$ --AlertAction:Accept}}",
                },
                // Assert action: Asserts that the attribute of the element
                // with ID "ConfirmResult" matches "(?i)OK clicked".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Match --Expected:(?i)OK clicked}}",
                    OnElement = "#ConfirmResult",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
