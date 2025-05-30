using G4.IntegrationTests.Framework;
using G4.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4.IntegrationTests.Plugins.Ui.ResolveOnlineFile
{
    internal class C0004(TestContext context) : TestCaseBase(context)
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
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Match --Expected:^(?!\\s*$).+}}",
                    OnElement = "{{$Get-Parameter --Name:ResolvedFileData --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:txt}}",
                    OnElement = "{{$Get-Parameter --Name:ResolvedFileExtension --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Example.txt}}",
                    OnElement = "{{$Get-Parameter --Name:ResolvedFileFullName --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:Example}}",
                    OnElement = "{{$Get-Parameter --Name:ResolvedFileName --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Greater --Expected:0}}",
                    OnElement = "{{$Get-Parameter --Name:ResolvedFileSize --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:200}}",
                    OnElement = "{{$Get-Parameter --Name:ResolvedFileStatusCode --Scope:Session}}"
                },
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Match --Expected:localhost}}",
                    OnElement = "{{$Get-Parameter --Name:ResolvedFileUri --Scope:Session}}"
                }
            ];
        }
    }
}
