﻿using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetCondition
{
    internal class C0014(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // SetCondition action: Sets a condition based on whether the element
                // with id "ElementSelected" is selected.
                new SwitchRuleModel
                {
                    PluginName = "SetCondition",
                    Argument = "{{$ --Condition:ElementSelected}}",
                    OnElement = "#ElementSelected",
                    Locator = "CssSelector",
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
