using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SendHttpRequest
{
    internal class C0004(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the value of "assertionOperation" from the test parameters
            // The default value is "Match" if the key is not found
            var assertionOperation = environment.TestParameters.Get(key: "assertionOperation", defaultValue: "Match");

            // Define a sequence of action rule models
            return
            [
                // SendHttpRequest action: Sends an HTTP request to the specified URL with basic authentication
                new ActionRuleModel
                {
                    PluginName = "SendHttpRequest",
                    Argument = "{{$ " +
                        "--Url:http://localhost:9002/api/hotels/connect " +
                        "--Header:Authorization=Basic username:password}}"
                },
                // Assert action: Asserts that the HTTP status code is not equal to 200
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Ne --Expected:200}}",
                    OnElement = "{{$Get-Parameter --Name:HttpStatusCode --Scope:Session}}"
                },
                // Assert action: Asserts that the HTTP response matches a specific pattern based on the assertion operation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ ----Condition:Text --Operator:" + assertionOperation + @" --Expected:(?<=Basic\s+)([A-Za-z0-9+/=]+)}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                }
            ];
        }
    }
}
