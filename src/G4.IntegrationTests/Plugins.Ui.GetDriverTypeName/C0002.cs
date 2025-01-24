using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Ui.GetDriverTypeName
{
    internal class C0002(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Gets the expected value from the environment parameters
            var expected = environment.TestParameters["expected"];

            // Gets the plugin name from the environment parameters, defaulting to "Get-DriverTypeName"
            var pluginName = environment.TestParameters.Get(key: "pluginName", defaultValue: "Get-DriverTypeName");

            // Define a sequence of action rule models to return
            return
            [
                // SendKeys action: Sends the value of the specified plugin to the element
                // with id "MacroResult", extracting only the file name
                new ActionRuleModel
                {
                    PluginName = "SendKeys",
                    Argument = "{{$" + pluginName + " --Pattern:[^.]+$}}",
                    OnElement = "#MacroResult",
                    Locator = Locators.CssSelector
                },
                // Assert action: Asserts that the value attribute of the element
                // with id "MacroResult" is equal to the expected value
                new ActionRuleModel
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
