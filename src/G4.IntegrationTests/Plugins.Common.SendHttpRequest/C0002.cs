using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SendHttpRequest
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Define a sequence of action rule models
            return
            [
                // SendHttpRequest action: Sends an HTTP request to the specified URL
                new ActionRuleModel
                {
                    PluginName = "SendHttpRequest",
                    Argument = "{{$ --Url:http://localhost:9002/api/hotels/find}}"
                },
                // Assert action: Asserts that the HTTP status code is equal to 200
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:200}}",
                    OnElement = "{{$Get-Parameter --Name:HttpStatusCode --Scope:Session}}"
                },
                // Assert action: Asserts that the HTTP response matches a specific pattern
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = @"{{$ --Condition:Text --Operator:Match --Expected:(?s)^(?:\{.*\}|\[.*\])$}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                }
            ];
        }
    }
}
