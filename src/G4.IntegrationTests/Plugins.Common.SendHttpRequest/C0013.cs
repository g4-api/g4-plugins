using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SendHttpRequest
{
    internal class C0013(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the value of "assertionOperation" from the test parameters
            // The default value is "Match" if the key is not found
            var assertionOperation = environment.TestParameters.Get(key: "assertionOperation", defaultValue: "Match");

            // Define a sequence of action rule models
            return
            [
                // SendHttpRequest action: Sends an HTTP POST request to book a hotel room
                // using text/plain content type and ASCII encoding
                new ActionRuleModel
                {
                    PluginName = "SendHttpRequest",
                    Argument = "{{$ " +
                        "--Url:http://localhost:9002/api/hotels/book/text " +
                        "--Body:HotelName=Luxury Hotel;RoomType=Suite " +
                        "--ContentType:text/plain " +
                        "--Encoding:ASCII " +
                        "--Method:Post}}"
                },
                // Assert action: Asserts that the HTTP status code is equal to 200
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:200}}",
                    OnElement = "{{$Get-Parameter --Name:HttpStatusCode --Scope:Session}}"
                },
                // Assert action: Asserts that the response confirms the booking for the
                // specified hotel and room type
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Text " +
                        "--Operator:" + assertionOperation + " " +
                        "--Expected:(?s)Booking confirmed for Luxury Hotel, Suite}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                }
            ];
        }
    }
}
