/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.InvokeWhileLoop;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    /// <summary>
    /// Test class for testing the behavior of InvokeWhileLoop plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("InvokeWhileLoop")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables invoking a while loop based on specified conditions, " +
        "So that I can implement iterative automation workflows with flexible control over loop execution.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The InvokeWhileLoop plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Loop Condition Evaluation: The plugin evaluates loop conditions based on provided rules and timeout settings, supporting dynamic loop termination.")]
    [AcceptanceCriteria(criteria: "Loop Iteration Execution: The plugin executes loop iterations according to specified rules and conditions, allowing for flexible automation logic.")]
    [AcceptanceCriteria(criteria: "Timeout Handling: The plugin gracefully handles timeout scenarios, ensuring that the loop terminates appropriately if a timeout is reached.")]
    [AcceptanceCriteria(criteria: "Iteration Counter: The plugin accurately tracks and provides the iteration count for each loop execution, supporting debugging and analysis of automation workflows.")]
    [AcceptanceCriteria(criteria: "Support for Rules: The plugin supports the specification of rules for loop conditions and iteration logic, enabling complex automation scenarios.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during loop execution, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class InvokeWhileLoopTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeWhileLoop plugin correctly clicks the 'Next' button " +
            "until the button with text '6' has the class 'active', and ensures that the " +
            "button with text '6' eventually becomes active.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeWhileLoop plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Loop Invocation: The plugin accurately clicks the 'Next' button until the button with text '6' has the class 'active'.")]
        [AcceptanceCriteria(criteria: "Button Activation Assertion: The plugin asserts that the button with text '6' eventually becomes active.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        public void T0001P()
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Loops.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeWhileLoop plugin correctly clicks the 'Next' button " +
            "for the first pagination until the button with text '3' has the class 'active', " +
            "then clicks the 'Next' button for the second pagination until the button with " +
            "text '3' has the class 'active', and ensures that the button with text '3' " +
            "eventually becomes active for both paginations.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeWhileLoop plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Outer Loop Invocation: The plugin accurately clicks the 'Next' button for the first pagination until the button with text '3' has the class 'active'.")]
        [AcceptanceCriteria(criteria: "Inner Loop Invocation: The plugin accurately clicks the 'Next' button for the second pagination until the button with text '3' has the class 'active'.")]
        [AcceptanceCriteria(criteria: "Button Activation Assertion: The plugin asserts that the button with text '3' eventually becomes active for both paginations.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        public void T0002P()
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Loops.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeWhileLoop plugin correctly clicks the 'Next' button " +
            "until the button with text '6' has the class 'foo' within the specified timeout.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeWhileLoop plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Loop Invocation: The plugin accurately clicks the 'Next' button until the button with text '6' has the class 'foo' within the specified timeout.")]
        [AcceptanceCriteria(criteria: "Timeout Handling: The plugin handles timeouts gracefully and provides informative error messages.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("5000")]
        #endregion
        public void T0003P(string timeout)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "timeout", value: timeout);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Loops.html");

            // Invoking the test with the constructed test options
            var response = Invoke<C0003>(testOptions);

            // Retrieve performance point related to the "InvokeWhileLoop" plugin.
            var performancePoint = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>(pluginName: "InvokeWhileLoop")
                .First();

            // Assert that the run time of the performance point is within the expected range.
            Assert.IsTrue(performancePoint.RunTime > 5 * TimeSpan.TicksPerSecond);
            Assert.IsTrue(performancePoint.RunTime < 9 * TimeSpan.TicksPerSecond);
        }
    }
}
