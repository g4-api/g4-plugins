using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetCondition
{
    internal class C0040(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // NewBrowserWindow action: Opens three new browser windows.
                new ActionRuleModel
                {
                    PluginName = "NewBrowserWindow",
                    Argument = "{{$ --Amount:3}}"
                },
                // SetCondition action: Sets a condition based on the window count being greater than 555.
                new SwitchRuleModel
                {
                    PluginName = "SetCondition",
                    Argument = "{{$ --Condition:WindowCount --Operator:Gt --Expected:555}}",
                    Branches = new Dictionary<string, IEnumerable<G4RuleModelBase>>()
                    {
                        ["true"] =
                            [
                                // RegisterParameter action: Registers a test parameter named "TestParameter"
                                // with the value "Foo Bar".
                                new ActionRuleModel
                                {
                                    PluginName = "RegisterParameter",
                                    Argument = "{{$ --Name:TestParameter --Value:Foo Bar}}"
                                }
                            ]
                    }
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
