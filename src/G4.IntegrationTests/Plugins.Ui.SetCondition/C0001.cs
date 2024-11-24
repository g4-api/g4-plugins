using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetCondition
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Returns a collection of action rule models
            return
            [
                // InvokeClick action: Clicks the element with the CSS selector "#NewAlertButton".
                new ActionRuleModel
                {
                    PluginName = "InvokeClick",
                    OnElement = "#NewAlertButton",
                    Locator = "CssSelector"
                },
                // SetCondition action: Sets a condition based on the existence of an alert.
                new ActionRuleModel
                {
                    PluginName = "SetCondition",
                    Argument = "{{$ --Condition:AlertExists}}",
                    Rules =
                    [
                        // RegisterParameter action: Registers a test parameter named "TestParameter"
                        // with the value "Foo Bar".
                        new ActionRuleModel
                        {
                            PluginName = "RegisterParameter",
                            Argument = "{{$ --Name:TestParameter --Value:Foo Bar}}"
                        }
                    ]
                },
                // Assert action: Asserts that the text retrieved using the "TestParameter" equals "Foo Bar".
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Foo Bar}}",
                    OnElement = "{{$Get-Parameter --Name:TestParameter}}"
                }
            ];
        }
    }
}
