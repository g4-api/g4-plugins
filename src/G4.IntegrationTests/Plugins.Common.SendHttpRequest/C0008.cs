using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SendHttpRequest
{
    internal class C0008(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the value of "assertionOperation" from the test parameters
            // The default value is "Eq" if the key is not found
            var assertionOperation = environment.TestParameters.Get(key: "assertionOperation", defaultValue: "Eq");

            // Define a sequence of action rule models
            return
            [
                // SendHttpRequest action: Sends an HTTP request to the specified URL
                // Regular expression is applied to extract the pricePerNight value of the Luxury
                // Hotel entry in the JSON response
                new ActionRuleModel
                {
                    PluginName = "SendHttpRequest",
                    Argument = "{{$ --Url:http://localhost:9002/api/hotels/find}}",
                    RegularExpression = "(?si)(?<=Luxury Hotel.*?\"pricePerNight\":\\s+)250"
                },
                // Assert action: Asserts that the HTTP status code is equal to 200
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:200}}",
                    OnElement = "{{$Get-Parameter --Name:HttpStatusCode --Scope:Session}}"
                },
                // Assert action: Asserts that the extracted pricePerNight value matches
                // the specified value based on the assertion operation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:" + assertionOperation + " --Expected:250}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                }
            ];
        }
    }
}
