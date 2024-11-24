using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SendHttpRequest
{
    internal class C0016(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the expected message from the test parameters, defaulting to an empty string if not found
            var expectedMessage = environment.TestParameters.Get(key: "expectedMessage", defaultValue: string.Empty);

            // Retrieve the expected status code from the test parameters, defaulting to an empty string if not found
            var expectedStatusCode = environment.TestParameters.Get(key: "expectedStatusCode", defaultValue: 0);

            // Retrieve the ID from the test parameters, defaulting to an empty string if not found
            var id = environment.TestParameters.Get(key: "id", defaultValue: string.Empty);

            // Define a sequence of action rule models
            return
            [
                // SendHttpRequest action: Sends an HTTP DELETE request to delete a hotel with
                // the specified ID
                new ActionRuleModel
                {
                    PluginName = "SendHttpRequest",
                    Argument = "{{$ " +
                        $"--Url:http://localhost:9002/api/hotels/delete/{id}" +
                        " --Body:{}" +
                        " --Method:Delete}}"
                },
                // Assert action: Asserts that the HTTP status code is equal to the expected status code
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:" + expectedStatusCode + "}}",
                    OnElement = "{{$Get-Parameter --Name:HttpStatusCode --Scope:Session}}"
                },
                // Assert action: Asserts that the response contains the expected message
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Match --Expected:(?s)" + expectedMessage + "}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                }
            ];
        }
    }
}
