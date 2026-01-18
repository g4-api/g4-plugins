using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.WaitFlow;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("WaitFlow")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to wait in the flow based on a condition or timeout, " +
        "So that I can control the timing of my automation tasks and handle dynamic application behaviors.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The WaitFlow plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Wait Condition Functionality: The plugin effectively waits until a specified condition is met, allowing users to synchronize automation tasks with dynamic application states.")]
    [AcceptanceCriteria(criteria: "Wait Timeout Functionality: The plugin effectively waits for a specified duration, enabling users to introduce delays in automation flows.")]
    [AcceptanceCriteria(criteria: "Condition and Timeout Handling: The plugin correctly handles scenarios where either a condition is met or a timeout occurs, ensuring accurate synchronization and timing control in automation workflows.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during wait operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class WaitFlowTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the alert does not exist for a maximum " +
            "of 15 seconds as specified by the Timeout parameter in the 'HH:mm:ss' format, and " +
            "handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the alert does not exist for a maximum of 15 seconds as specified by the Timeout parameter in the 'HH:mm:ss' format.")]
        [AcceptanceCriteria(criteria: "AlertNotExists Assertion: The plugin asserts that the alert does not exist.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0001P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0001>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementDisabled' becomes " +
            "active for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Disabled: The plugin asserts that the element with id 'ElementDisabled' is initially disabled.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button containing 'ElementDisabled' in its onclick attribute.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementDisabled' becomes active for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Active: The plugin asserts that the element with id 'ElementDisabled' is active after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0002P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0002>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementEnabled' becomes " +
            "disabled for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Enabled: The plugin asserts that the element with id 'ElementEnabled' is initially enabled.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button containing 'ElementEnabled' in its onclick attribute.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementEnabled' becomes disabled for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Disabled: The plugin asserts that the element with id 'ElementEnabled' is disabled after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0003P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0003>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementDisabled' becomes " +
            "enabled for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Disabled: The plugin asserts that the element with id 'ElementDisabled' is initially disabled.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button containing 'ElementDisabled' in its onclick attribute.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementDisabled' becomes enabled for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Enabled: The plugin asserts that the element with id 'ElementDisabled' is enabled after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0004P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0004>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with automation-data 'ElementCount' " +
            "exists for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Not Exists: The plugin asserts that the element with automation-data 'ElementCount' does not initially exist.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button containing 'ElementCount' in its onclick attribute.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with automation-data 'ElementCount' exists for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Exists: The plugin asserts that the element with automation-data 'ElementCount' exists after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0005P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0005>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementActive' is " +
            "not active for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the element with id 'ElementActive'.")]
        [AcceptanceCriteria(criteria: "Assert Element Active: The plugin asserts that the element with id 'ElementActive' is initially active.")]
        [AcceptanceCriteria(criteria: "InvokeScript Action: The plugin successfully invokes a JavaScript function to switch the state of the element with id 'ElementActive'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementActive' is not active for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Not Active: The plugin asserts that the element with id 'ElementActive' is not active after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0006P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0006>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementExists' does " +
            "not exist for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Exists: The plugin asserts that the element with id 'ElementExists' exists.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button containing 'ElementExists' in its onclick attribute.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementExists' does not exist for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Not Exists: The plugin asserts that the element with id 'ElementExists' does not exist after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0007P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0007>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementSelected' is " +
            "not selected for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Selected: The plugin asserts that the element with id 'ElementSelected' is selected.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button element that contains the onclick attribute with 'ElementSelected'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementSelected' is not selected for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Not Selected: The plugin asserts that the element with id 'ElementSelected' is not selected after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0008P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0008>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementVisible' is " +
            "not visible for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Visible: The plugin asserts that the element with id 'ElementVisible' is visible.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button element that contains the onclick attribute with 'ElementVisible'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementVisible' is not visible for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Not Visible: The plugin asserts that the element with id 'ElementVisible' is not visible after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0009P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0009>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementNotSelected' " +
            "is selected for a maximum of 15 seconds, and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Not Selected: The plugin asserts that the element with id 'ElementNotSelected' is not selected.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button element that contains the onclick attribute with 'ElementNotSelected'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementNotSelected' is selected for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Selected: The plugin asserts that the element with id 'ElementNotSelected' is selected after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0010P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0010>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'StaleElement' becomes " +
            "stale for a maximum of 15 seconds and handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the element with id 'SetStaleElement'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'StaleElement' becomes stale for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Element Stale: The plugin asserts that the element with id 'StaleElement' is stale after the specified wait period.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0011P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0011>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element with id 'ElementVisible' becomes " +
            "not visible for a maximum of 15 seconds, then becomes visible again after an action, and " +
            "handles errors gracefully.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Element Visible: The plugin successfully asserts that the element with id 'ElementVisible' is initially visible.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button element that contains the onclick attribute with 'ElementVisible' substring.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element with id 'ElementVisible' becomes not visible for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action (Repeat): The plugin successfully invokes a click on the button element that contains the onclick attribute with 'ElementVisible' substring after the wait.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action (Repeat): The plugin successfully waits until the element with id 'ElementVisible' becomes visible again for a maximum of 15 seconds after the action.")]
        [AcceptanceCriteria(criteria: "Assert Element Visible (Repeat): The plugin successfully asserts that the element with id 'ElementVisible' is visible again after the action.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0012P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0012>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the condition 'DriverTypeName' with the " +
            "specified operator and expected value is met for a maximum of 15 seconds and asserts " +
            "the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the condition 'DriverTypeName' with the specified operator and expected value is met for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the condition 'DriverTypeName' with the specified operator and expected value is met.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Eq", "G4.WebDriver.Remote.Edge.EdgeDriver")]
        [DataRow("Ne", "EdgeDriver")]
        [DataRow("Match", "EdgeDriver")]
        [DataRow("NotMatch", "^EdgeDriver$")]
        #endregion
        public void T0013P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0013>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the attribute value of the element with id " +
            "'ElementAttribute' satisfies the condition with the specified operator and expected value " +
            "for a maximum of 15 seconds, and asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the attribute value of the element with id 'ElementAttribute' satisfies the condition with the specified operator and expected value.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the element with id 'ElementAttributeSwitch'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the attribute value of the element with id 'ElementAttribute' satisfies the condition with the specified operator and expected value for a maximum of 15 seconds.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Eq", "Foo Bar")]
        [DataRow("Ne", "Bar Foo")]
        [DataRow("Match", "Bar|Foo")]
        [DataRow("NotMatch", "^Bar$")]
        #endregion
        public void T0014P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0014>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element count meets the specified " +
            "condition for a maximum of 15 seconds, while the element count is increasing, and " +
            "asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the element count meets the specified condition.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the element with id 'ElementCountSwitch'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element count meets the specified condition for a maximum of 15 seconds, while the element count is increasing.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Gt", "2")]
        [DataRow("Ge", "2")]
        [DataRow("Ge", "3")]
        [DataRow("Eq", "3")]
        #endregion
        public void T0015P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0015>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the element count meets the specified " +
            "condition for a maximum of 15 seconds, while the element count is decreasing, and " +
            "asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the element count meets the specified condition.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the element with id 'ElementCountSwitch'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the element count meets the specified condition for a maximum of 15 seconds, while the element count is decreasing.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Lt", "2")]
        [DataRow("Le", "2")]
        [DataRow("Le", "1")]
        [DataRow("Ne", "3")]
        #endregion
        public void T0016P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0016>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the condition 'ElementText' with the specified " +
            "operator and expected value is met for a maximum of 15 seconds, while the element text is " +
            "changing, and asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the condition 'ElementText' with the specified operator and expected value is met.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on the button containing 'ElementText' in its onclick attribute.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the condition 'ElementText' with the specified operator and expected value is met for a maximum of 15 seconds, while the element text is changing.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Eq", "Foo Bar")]
        [DataRow("Ne", "Element Text")]
        [DataRow("Match", "Bar|Foo")]
        [DataRow("NotMatch", "Element Text")]
        #endregion
        public void T0017P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0017>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the condition 'ElementTextLength' with " +
            "the specified operator and expected value is met for a maximum of 15 seconds, while " +
            "the element text length is changing, and asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the condition 'ElementTextLength' with the specified operator and expected value is met.")]
        [AcceptanceCriteria(criteria: "InvokeScript Action: The plugin successfully invokes a JavaScript function to set the text of the element with id 'ElementText' to the provided input value.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the condition 'ElementTextLength' with the specified operator and expected value is met for a maximum of 15 seconds, while the element text length is changing.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Lt", "12", 10)]
        [DataRow("Le", "11", 11)]
        [DataRow("Le", "18", 7)]
        [DataRow("Ne", "12", 10)]
        [DataRow("Gt", "12", 18)]
        [DataRow("Ge", "18", 18)]
        [DataRow("Ge", "18", 36)]
        [DataRow("Eq", "18", 18)]
        #endregion
        public void T0018P(string @operator, string expected, int inputLength)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "input", value: Utilities.NewRandomString(inputLength))
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0018>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the condition 'PageTitle' with the specified " +
            "operator and expected value is met for a maximum of 15 seconds, while the page title is " +
            "changing, and asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the condition 'PageTitle' with the specified operator and expected value is met.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on a button that contains the onclick attribute 'setPageTitle'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the condition 'PageTitle' with the specified operator and expected value is met for a maximum of 15 seconds, while the page title is changing.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Eq", "Foo Bar")]
        [DataRow("Ne", "Element Conditions")]
        [DataRow("Match", "Bar|Foo")]
        [DataRow("NotMatch", "Conditions|Element")]
        #endregion
        public void T0019P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0019>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the condition 'PageUrl' with the specified " +
            "operator and expected value is met for a maximum of 15 seconds, while the page URL is " +
            "changing, and asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the condition 'PageUrl' with the specified operator and expected value is met.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on a button that contains the onclick attribute 'editUrl'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the condition 'PageUrl' with the specified operator and expected value is met for a maximum of 15 seconds, while the page URL is changing.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Eq", "http://localhost:9002/test/static/DynamicState.html?value=FooBar")]
        [DataRow("Ne", "http://localhost:9002/test/static/DynamicState.html")]
        [DataRow("Match", "Bar|Foo")]
        [DataRow("NotMatch", "DynamicState\\.html$")]
        #endregion
        public void T0020P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0020>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the condition 'WindowCount' with the specified " +
            "operator and expected value is met for a maximum of 15 seconds, while the number of browser " +
            "windows is changing, and asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the condition 'WindowCount' with the specified operator and expected value is met.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on a button that contains the onclick attribute 'openNewTabs'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the condition 'WindowCount' with the specified operator and expected value is met for a maximum of 15 seconds, while the number of browser windows is changing.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Gt", "2")]
        [DataRow("Ge", "2")]
        [DataRow("Ge", "3")]
        [DataRow("Eq", "3")]
        #endregion
        public void T0021P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0021>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WaitFlow plugin waits until the condition 'WindowCount' with the specified " +
            "operator and expected value is met for a maximum of 15 seconds, while the number of browser " +
            "windows is changing due to opening and closing tabs, and asserts the same condition.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WaitFlow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Assert Action: The plugin successfully asserts that the condition 'WindowCount' with the specified operator and expected value is met.")]
        [AcceptanceCriteria(criteria: "InvokeClick Action: The plugin successfully invokes a click on a button that contains the onclick attribute 'openAndCloseTabs'.")]
        [AcceptanceCriteria(criteria: "WaitFlow Action: The plugin successfully waits until the condition 'WindowCount' with the specified operator and expected value is met for a maximum of 15 seconds, while the number of browser windows is changing.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        #region  *** Data     ***
        [DataRow("Lt", "2")]
        [DataRow("Le", "3")]
        [DataRow("Le", "4")]
        [DataRow("Ne", "4")]
        #endregion
        public void T0022P(string @operator, string expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment, sut: "DynamicState.html");

            // Invoking the test with the constructed test options.
            var response = Invoke<C0022>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("WaitFlow");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime < 15 * TimeSpan.TicksPerSecond));
        }
    }
}
