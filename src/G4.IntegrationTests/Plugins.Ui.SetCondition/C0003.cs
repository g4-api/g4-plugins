using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.SetCondition
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the driver type name from the test parameters
            var driverTypeName = environment.TestParameters["driverTypeName"];

            // Return a collection of action rule models
            return
            [
                // SetCondition action: Sets a condition based on the matching of the driver type name.
                new SwitchRuleModel
                {
                    PluginName = "SetCondition",
                    Argument = "{{$ --Condition:DriverTypeName --Operator:Match --Expected:(?i)" + driverTypeName + "}}",
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
