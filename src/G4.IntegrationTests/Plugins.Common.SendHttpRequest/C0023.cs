﻿using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SendHttpRequest
{
    internal class C0023(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the value of "assertionOperation" from the test parameters
            // The default value is "Match" if the key is not found
            var assertionOperation = environment.TestParameters.Get(key: "assertionOperation", defaultValue: "Match");

            // Define a sequence of action rule models
            return
            [
                // SendHttpRequest action: Sends an HTTP PUT request to update hotel information in XML format
                new ActionRuleModel
                {
                    PluginName = "SendHttpRequest",
                    Argument = "{{$ " +
                        "--Body:<HotelUpdateRequest><HotelName>Luxury Hotel</HotelName><NewInfo>Foo Bar</NewInfo></HotelUpdateRequest> " +
                        "--Url:http://localhost:9002/api/hotels/edit/xml " +
                        "--Method:Put}}"
                },
                // Assert action: Asserts that the HTTP status code is equal to 200
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:200}}",
                    OnElement = "{{$Get-Parameter --Name:HttpStatusCode --Scope:Session}}"
                },
                // Assert action: Asserts that the response contains the expected message
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Text " +
                        "--Operator:" + assertionOperation + " " +
                        "--Expected:(?s)Hotel information updated for Luxury Hotel}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                }
            ];
        }
    }
}