using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.GetParameter
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Define expected value, scope, and plugin name based on environment test parameters
            const string expected = "Rm9vIEJhcg=="; // Base64 encoded string "Foo Bar"
            var scope = environment.TestParameters["scope"];
            var pluginName = environment.TestParameters["pluginName"];

            // Return a collection of action rule models
            return
            [
                // RegisterParameter action: Registers a parameter with the decoded expected
                // value and specified scope
                new ActionRuleModel()
                {
                    PluginName = "RegisterParameter",
                    Argument = "{{$ --Name:ParameterName --Value:" + expected.ConvertFromBase64() +  " --Scope:" + scope + "}}",
                },
                // SendKeys action: Sends the value of the registered parameter to an element
                // with ID "MacroResult" without decoding
                new ActionRuleModel()
                {
                    PluginName = "SendKeys",
                    Argument = "{{$" + pluginName + " --Name:ParameterName --NoDecode --Scope:" + scope + "}}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assertion action: Asserts that the value attribute of the element with
                // ID "MacroResult" matches the base64 encoded expected value
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:ElementAttribute --Operator:Eq --Expected:" + expected + "}}",
                    OnElement = "#MacroResult",
                    OnAttribute = "value",
                    Locator = Locators.CssSelector
                }
            ];
        }
    }
}
