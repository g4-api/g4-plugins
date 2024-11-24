using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetCondition
{
    internal class C0020(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // NewBrowserWindow action: Opens a new browser window.
                new ActionRuleModel
                {
                    PluginName = "NewBrowserWindow",
                    Argument = "{{$ --Amount:3}}"
                },
                // SetCondition action: Sets a condition based on whether the number of browser
                // windows is less than 555.
                new ActionRuleModel
                {
                    PluginName = "SetCondition",
                    Argument = "{{$ --Condition:WindowCount --Operator:Lt --Expected:555}}",
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
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:Foo Bar}}",
                    OnElement = "{{$Get-Parameter --Name:TestParameter}}"
                }
            ];
        }
    }
}
