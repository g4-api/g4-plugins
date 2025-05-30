﻿using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.WaitFlow
{
    internal class C0017(TestContext context) : TestCaseBase(context)
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
                // Assert action: Asserts that the element text is equal to "Element Text"
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:ElementText --Operator:Eq --Expected:Element Text --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementText",
                    PluginName = "Assert"
                },
                // InvokeClick action: Invokes a click on the button containing
                // "ElementText" in its onclick attribute
                new ActionRuleModel
                {
                    OnElement = "//button[contains(@onclick,'ElementText')]",
                    PluginName = "InvokeClick"
                },
                // WaitFlow action: Waits until the condition ElementText with the specified
                // operator and expected value is met for a maximum of 15 seconds
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:ElementText --Operator:" + @operator + " --Expected:" + expected + " --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementText",
                    PluginName = "WaitFlow"
                },
                // Assert action: Asserts that the condition ElementText with the specified operator
                // and expected value is met
                new ActionRuleModel
                {
                    Argument = "{{$ --Condition:ElementText --Operator:" + @operator + " --Expected:" + expected + " --Timeout:00:00:15}}",
                    Locator = Locators.CssSelector,
                    OnElement = "#ElementText",
                    PluginName = "Assert"
                }
            ];
        }
    }
}
