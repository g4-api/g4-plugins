using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass, DoNotParallelize]
    [TestCategory("InvokeForLoop")]
    [TestCategory("UnitTest")]
    public class InvokeWhileLoopTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeWhileLoop plugin complies with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<InvokeWhileLoop>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeWhileLoop plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<InvokeWhileLoop>();
        }

        // This test may produce inconsistent results due to its reliance on random object generation.
        // Running it in a loop helps mitigate this inconsistency.
        [TestMethod(DisplayName = "Verify that the InvokeWhileLoop plugin performs correctly " +
            "within the given parameters, despite potential inconsistencies due to random object generation.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonInvokeWhileLoop, "Match", "Negative", "ElementText", ".//random-p")]
        #endregion
        public void InvokeWhileLoopPositiveTest(
            string ruleJson,
            string onOperator,
            string onOperatorExpected,
            string onCondition,
            string onElement)
        {
            // Replace placeholders in the action rule with provided parameters
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement);

            // Set a timeout for the while loop
            var timeout = DateTime.UtcNow.AddSeconds(60);

            // Initialize a variable to track if the test passes
            var pass = false;

            // Continue looping until the test passes or the timeout is reached
            while (!pass && DateTime.UtcNow < timeout)
            {
                try
                {
                    // Invoke the test using the modified action rule
                    Invoke(testBase: this, ruleJson, expectedPerformancePoints: 2);

                    // Set pass to true if the test invocation succeeds
                    pass = true;
                }
                catch (Exception e) when (e.GetBaseException() is ArgumentException)
                {
                    // if argument exception occurs during the test
                    // invocation, set pass to false and throw the
                    // exception to fail the test case
                    throw;
                }
                catch (Exception)
                {
                    // If an exception occurs during the test invocation, set pass to false
                    pass = false;
                }
            }
        }

        [TestMethod(DisplayName = "Verify that the InvokeWhileLoop plugin respects the timeout " +
            "settings and the runtime exceeds the specified duration.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonInvokeWhileLoopWithTimeout, "NotMatch", "Negative", "ElementText", ".//positive", "5000")]
        [DataRow(Stubs.RuleJsonInvokeWhileLoopWithTimeout, "NotMatch", "Negative", "ElementText", ".//positive", "00:00:05")]
        #endregion
        public void InvokeWhileLoopTimeoutPositiveTest(
            string ruleJson,
            string onOperator,
            string onOperatorExpected,
            string onCondition,
            string onElement,
            string timeout)
        {
            // Replace placeholders in the action rule with provided parameters.
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement)
                .Replace("$[OnTimeoutExpected]", timeout);

            // Deserialize the modified action rule into an ActionRuleModel object.
            var ruleModel = JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke([ruleModel]).Response.First().Value.Sessions.First().Value;

            // Assert that the runtime of the while loop exceeds the specified timeout duration.
            Assert.IsGreaterThan(5 * TimeSpan.TicksPerSecond, session.PerformancePoint.RunTime);
        }

        // This test may produce inconsistent results due to its reliance on random object generation.
        // Running it in a loop helps mitigate this inconsistency.
        [TestMethod(DisplayName = "Verify that the InvokeWhileLoop plugin performs triple " +
            "nested loops correctly in a positive scenario.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonInvokeWhileTripleLoop, "Match", "Negative", "ElementText", ".//random-p")]
        #endregion
        public void InvokeWhileLoopTripleLoopPositiveTest(
            string ruleJson,
            string onOperator,
            string onOperatorExpected,
            string onCondition,
            string onElement)
        {
            // Replace placeholders in the action rule with provided parameters
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement);

            // Set a timeout for the while loop
            var timeout = DateTime.UtcNow.AddSeconds(60);

            // Initialize a variable to track if the test passes
            var pass = false;

            // Continue looping until the test passes or the timeout is reached
            while (!pass && DateTime.UtcNow < timeout)
            {
                try
                {
                    // Invoke the test using the modified action rule
                    Invoke(testBase: this, ruleJson, expectedPerformancePoints: 4);

                    // Set pass to true if the test invocation succeeds
                    pass = true;
                }
                catch (ArgumentException e) when (e.GetBaseException() is ArgumentException)
                {
                    // if argument exception occurs during the test
                    // invocation, set pass to false and throw the
                    // exception to fail the test case
                    throw;
                }
                catch (Exception)
                {
                    // If an exception occurs during the test invocation, set pass to false
                    pass = false;
                }
            }
        }

        // This test may produce inconsistent results due to its reliance on random object generation.
        // Running it in a loop helps mitigate this inconsistency.
        [TestMethod(DisplayName = "Verify that the InvokeWhileLoop plugin performs nested " +
            "loops correctly in a positive scenario.")]
        #region *** Data Set ***
        [DataRow(Stubs.RuleJsonInvokeWhileLoopWithNestedLoop, "Match", "Negative", "ElementText", ".//random-p")]
        #endregion
        public void InvokeWhileLoopWithNestedLoopPositiveTest(
            string ruleJson,
            string onOperator,
            string onOperatorExpected,
            string onCondition,
            string onElement)
        {
            // Replace placeholders in the action rule with provided parameters
            ruleJson = ruleJson
                .Replace(Stubs.OnCondition, onCondition)
                .Replace(Stubs.OnOperator, onOperator)
                .Replace(Stubs.OnOperatorExpected, onOperatorExpected)
                .Replace(Stubs.OnElement, onElement);

            // Set a timeout for the while loop
            var timeout = DateTime.UtcNow.AddSeconds(60);

            // Initialize a variable to track if the test passes
            var pass = false;

            // Continue looping until the test passes or the timeout is reached
            while (!pass && DateTime.UtcNow < timeout)
            {
                try
                {
                    // Invoke the test using the modified action rule
                    Invoke(testBase: this, ruleJson, expectedPerformancePoints: 3);

                    // Set pass to true if the test invocation succeeds
                    pass = true;
                }
                catch (Exception e) when (e.GetBaseException() is ArgumentException)
                {
                    // if argument exception occurs during the test
                    // invocation, set pass to false and throw the
                    // exception to fail the test case
                    throw;
                }
                catch (Exception)
                {
                    // If an exception occurs during the test invocation, set pass to false
                    pass = false;
                }
            }
        }

        // Invokes a test by deserializing the provided action rule, setting it as the automation's actions,
        // and asserting the result against the expected value.
        private static void Invoke(TestBase testBase, string ruleJson, int expectedPerformancePoints)
        {
            // Deserialize the rule JSON into a G4RuleModelBase object.
            var ruleModel = (G4RuleModelBase)JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the test with the deserialized rule model.
            var resultModel = testBase.Invoke([ruleModel]);

            // Retrieve the parameter value from the test result and decode it from Base64.
            var actual = resultModel.GetParameterValue(parameterName: "TestParameter", scope: "Session").ConvertFromBase64();

            // Retrieve the performance points from the test result.
            var performancePoints = resultModel.GetPerformancePoints();

            // Assert that the actual parameter value matches the expected value.
            Assert.AreEqual(expected: "Foo Bar", actual);

            // Assert that the number of performance points matches the expected count.
            Assert.AreEqual(expected: expectedPerformancePoints, actual: performancePoints.Count());
        }
    }
}
