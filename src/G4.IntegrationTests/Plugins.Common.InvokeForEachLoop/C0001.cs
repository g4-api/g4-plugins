using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.InvokeForEachLoop
{
    internal class C0001(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // InvokeForLoop action: Clicks the "Next" button 5 times
                new ActionRuleModel()
                {
                    PluginName = "InvokeForEachLoop",
                    OnElement = "//div[@id='linksContainer']//a",
                    // Rules for the InvokeForLoop action
                    Rules =
                    [
                        // Click action: Clicks the "Next" button
                        new ActionRuleModel()
                        {
                            PluginName = "NewBrowserWindow",
                            Argument = "{{$ --Target:_blank}}",
                            OnAttribute = "href",
                            OnElement = "."
                        },
                        // Wait action: Waits for the wndow count to be equal to 2
                        new ActionRuleModel()
                        {
                            PluginName = "WaitFlow",
                            Argument = "{{$ --Condition:WindowCount --Operator:Equal --Expected:2 --Timeout:1500}}"
                        },
                        // SwitchWindow action: Switches to the new window
                        new ActionRuleModel()
                        {
                            PluginName = "SwitchWindow",
                            Argument = "1"
                        },
                        // RegisterParameter action: Registers the link name and value as a session parameter
                        new ActionRuleModel()
                        {
                            PluginName = "RegisterParameter",
                            Argument = "{{$ --Name:{{$Get-PageUrl --Pattern:(?=)[Ll]ink[0-9]+$}} --Scope:Session}}",
                            OnElement = "//input[@id='inputBox']",
                            OnAttribute = "value"
                        },
                        // CloseChildWindows action: Closes the child windows
                        new ActionRuleModel()
                        {
                            PluginName = "CloseChildWindows"
                        }
                    ]
                },
                // Assert action: Asserts that the link names are equal to the expected values
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Link1}}",
                    OnElement = "{{$Get-Parameter --Name:Link1 --Scope:Session}}"
                },
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Link2}}",
                    OnElement = "{{$Get-Parameter --Name:Link2 --Scope:Session}}"
                },
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Link3}}",
                    OnElement = "{{$Get-Parameter --Name:Link3 --Scope:Session}}"
                },
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Link4}}",
                    OnElement = "{{$Get-Parameter --Name:Link4 --Scope:Session}}"
                },
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Link5}}",
                    OnElement = "{{$Get-Parameter --Name:Link5 --Scope:Session}}"
                }
            ];
        }
    }
}
