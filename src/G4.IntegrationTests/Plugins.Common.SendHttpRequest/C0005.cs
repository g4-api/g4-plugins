using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SendHttpRequest
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the value of "assertionOperation" from the test parameters
            // The default value is "Match" if the key is not found
            var assertionOperation = environment.TestParameters.Get(key: "assertionOperation", defaultValue: "Match");

            // Define a sequence of action rule models
            return
            [
                // SendHttpRequest action: Sends an HTTP request to the specified URL with custom headers
                new ActionRuleModel
                {
                    PluginName = "SendHttpRequest",
                    Argument = "{{$ " +
                        "--Url: http://localhost:9002/api/hotels/headers " +
                        "--Header:Authorization=Bearer YourAccessToken " +
                        "--Header:ContentType=application/json " +
                        "--Header:UserAgent=MyCustomUserAgent " +
                        "}}"
                },
                // Assert action: Asserts that the HTTP status code is equal to 200
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:200}}",
                    OnElement = "{{$Get-Parameter --Name:HttpStatusCode --Scope:Session}}"
                },
                // Assert action: Asserts that the HTTP response contains the "Authorization"
                // header based on the assertion operation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Text " +
                        "--Operator:" + assertionOperation + " " +
                        "--Expected:(?si)Authorization}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                },
                // Assert action: Asserts that the HTTP response contains the "Bearer YourAccessToken"
                // string based on the assertion operation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Text " +
                        "--Operator:" + assertionOperation + " " +
                        "--Expected:(?si)Bearer YourAccessToken}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                },
                // Assert action: Asserts that the HTTP response contains the "ContentType"
                // header based on the assertion operation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Text " +
                        "--Operator:" + assertionOperation + " " +
                        "--Expected:(?si)ContentType}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                },
                // Assert action: Asserts that the HTTP response contains the "application/json"
                // string based on the assertion operation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Text " +
                        "--Operator:" + assertionOperation + " " +
                        "--Expected:(?si)application/json}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                },
                // Assert action: Asserts that the HTTP response contains the "UserAgent" header
                // based on the assertion operation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Text " +
                        "--Operator:" + assertionOperation + " " +
                        "--Expected:(?si)UserAgent}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                },
                // Assert action: Asserts that the HTTP response contains the "MyCustomUserAgent"
                // string based on the assertion operation
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ " +
                        "--Condition:Text " +
                        "--Operator:" + assertionOperation + " " +
                        "--Expected:(?si)MyCustomUserAgent}}",
                    OnElement = "{{$Get-Parameter --Name:HttpResponse --Scope:Session}}"
                }
            ];
        }
    }
}
