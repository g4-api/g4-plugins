using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.ResolveOnlineFile
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            return
            [
                new ActionRuleModel
                {
                    PluginName = "ResolveOnlineFile",
                    OnElement = "//a[@data-automation-id='direct-url-link']",
                    OnAttribute = "href",
                    RegularExpression = "http:\\/\\/.*\\/Example\\.txt",
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Match --Expected:^(?!\\s*$).+}}",
                    OnElement = "{{$Get-Parameter --Name:ResolveOnlineFile:Data --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:txt}}",
                    OnElement = "{{$Get-Parameter --Name:ResolveOnlineFile:Extension --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Example.txt}}",
                    OnElement = "{{$Get-Parameter --Name:ResolveOnlineFile:FullName --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Example}}",
                    OnElement = "{{$Get-Parameter --Name:ResolveOnlineFile:Name --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Greater --Expected:0}}",
                    OnElement = "{{$Get-Parameter --Name:ResolveOnlineFile:Size --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:200}}",
                    OnElement = "{{$Get-Parameter --Name:ResolveOnlineFile:StatusCode --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Match --Expected:localhost}}",
                    OnElement = "{{$Get-Parameter --Name:ResolveOnlineFile:Uri --Scope:Session}}"
                }
            ];
        }
    }
}
