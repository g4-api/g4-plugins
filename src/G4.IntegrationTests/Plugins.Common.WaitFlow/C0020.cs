using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0020(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Gets the operator from the environment parameters, with a default value
            // of "Eq" if not provided.
            var @operator = environment.TestParameters.Get(key: "operator", defaultValue: "Eq");

            // Gets the expected value from the environment parameters, with a default value
            // of an empty string if not provided.
            var expected = environment.TestParameters.Get(key: "expected", defaultValue: string.Empty);

            // Define a sequence of action rule models to return
            return
            [
                // Assert action: Asserts that the page URL matches the pattern "DynamicState\\.html$"
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:PageUrl " +
                        "--Operator:Match " +
                        "--Expected:DynamicState\\.html$ " +
                        "--Timeout:00:00:15}}",
                    PluginName = "Assert"
                },
                // InvokeClick action: Invokes a click on a button that contains the onclick
                // attribute 'editUrl'
                new ActionRuleModel
                {
                    OnElement = "//button[contains(@onclick,'editUrl')]",
                    PluginName = "InvokeClick"
                },
                // WaitFlow action: Waits until the condition PageUrl with the specified
                // operator and expected value is met for a maximum of 15 seconds
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:PageUrl " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    PluginName = "WaitFlow"
                },
                // Assert action: Asserts that the condition PageUrl with the specified
                // operator and expected value is met
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--Condition:PageUrl " +
                        "--Operator:" + @operator + " " +
                        "--Expected:" + expected + " " +
                        "--Timeout:00:00:15}}",
                    PluginName = "Assert"
                }
            ];
        }
    }
}
