using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SetSwitchCase
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            return
            [
                new SwitchRuleModel
                {
                    PluginName = "SetSwitchCase",
                    OnElement = "//input[@id='SetStaleElement']",
                    OnAttribute = "onclick",
                    Branches = new Dictionary<string, IEnumerable<G4RuleModelBase>>()
                    {
                        ["1"] =
                            [
                                new ActionRuleModel
                                {
                                    PluginName = "RegisterParameter",
                                    Argument = "{{$ --Name:TestResult --Value:1 --Scope:Session}}"
                                }
                            ],
                        ["2"] =
                            [
                                new ActionRuleModel
                                {
                                    PluginName = "RegisterParameter",
                                    Argument = "{{$ --Name:TestResult --Value:2 --Scope:Session}}"
                                }
                            ],
                        ["setStaleElement()"] =
                            [
                                new ActionRuleModel
                                {
                                    PluginName = "RegisterParameter",
                                    Argument = "{{$ --Name:TestResult --Value:3 --Scope:Session}}"
                                }
                            ],
                        ["4"] =
                            [
                                new ActionRuleModel
                                {
                                    PluginName = "RegisterParameter",
                                    Argument = "{{$ --Name:TestResult --Value:4 --Scope:Session}}"
                                }
                            ]
                    }
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:3}}",
                    OnElement = "{{$Get-Parameter --Name:TestResult --Scope:Session}}"
                }
            ];
        }
    }
}
