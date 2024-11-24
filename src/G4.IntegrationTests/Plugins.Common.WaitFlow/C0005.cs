using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            return
            [
                // Assert action: Asserts that the element with automation-data "ElementCount" does not exist
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementNotExists}}",
                    OnElement = "//div[@id='ElementCount']/span[@automation-data='ElementCount']"
                },
                // InvokeClick action: Invokes a click on the button containing "ElementCount" in its onclick attribute
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "//button[contains(@onclick,'ElementCount')]"
                },
                // WaitFlow action: Waits until the element with automation-data "ElementCount" exists for a maximum of 15 seconds
                new ActionRuleModel
                {
                    PluginName = "WaitFlow",
                    Argument = "{{$ --Condition:ElementExists --Timeout:00:00:15}}",
                    OnElement = "//div[@id='ElementCount']/span[@automation-data='ElementCount']"
                },
                // Assert action: Asserts that the element with automation-data "ElementCount" exists
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementExists}}",
                    OnElement = "//div[@id='ElementCount']/span[@automation-data='ElementCount']"
                }
            ];
        }
    }
}
