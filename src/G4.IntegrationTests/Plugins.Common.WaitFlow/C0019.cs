using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0019(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
        {
            // Gets the operator from the environment parameters, with a default value
            // of "Eq" if not provided.
            var @operator = environment.TestParameters.Get(key: "operator", defaultValue: "Eq");

            // Gets the expected value from the environment parameters, with a default
            // value of an empty string if not provided.
            var expected = environment.TestParameters.Get(key: "expected", defaultValue: string.Empty);

            // Define a sequence of action rule models to return
            return
            [
                // Assert action: Asserts that the page title is "Element Conditions"
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:PageTitle " +
                        "--Operator:Eq " +
                        "--Expected:Element Conditions " +
                        "--Timeout:00:00:15}}",
                    PluginName = "Assert"
                },
                // InvokeClick action: Invokes a click on a button that contains the onclick
                // attribute 'setPageTitle'
                new ActionRuleModel
                {
                    OnElement = "//button[contains(@onclick,'setPageTitle')]",
                    PluginName = "InvokeClick"
                },
                // WaitFlow action: Waits until the condition PageTitle with the specified
                // operator and expected value is met for a maximum of 15 seconds
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:PageTitle " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    PluginName = "WaitFlow"
                },
                // Assert action: Asserts that the condition PageTitle with the specified
                // operator and expected value is met
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:PageTitle " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    PluginName = "Assert"
                }
            ];
        }
    }
}
