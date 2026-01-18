using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SendKeys;
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
    [TestCategory("SendKeys")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to send keystrokes to web elements, So that I can accurately " +
        "simulate user interactions in UI automation tasks.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin must be easily accessible within the G4™ ecosystem, allowing seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Key Input Functionality: The plugin must be capable of sending keystrokes to web elements, enabling precise interaction with input fields, buttons, and other UI components.")]
    [AcceptanceCriteria(criteria: "Parameter Customization: Users must have the flexibility to customize parameters such as delay between keystrokes, use of modifier keys (e.g., Alt, Shift), and option to clear input fields before sending keys.")]
    [AcceptanceCriteria(criteria: "Native Browser Support: The plugin must support native browser clear functionality if specified, ensuring compatibility across different browser environments.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms must be implemented to handle scenarios such as element not found, unexpected browser behavior, and runtime exceptions, ensuring stability and resilience in automation workflows.")]
    #endregion
    public class SendKeysTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeys plugin, when configured to send specific keystrokes, accurately " +
            "simulates user interactions in UI automation tasks.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeys plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured to send 'Foo Bar' keystrokes, the plugin accurately sends the specified input.")]
        [AcceptanceCriteria(criteria: "Input Simulation: The target UI element receives and processes the sent keystrokes 'Foo Bar' as expected.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected issues or failures during keystroke input interactions, ensuring stability and reliability.")]
        #endregion
        public void T0001P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeys plugin, when configured to send specific keystrokes with a " +
            "specified delay between each character, accurately simulates user interactions in UI " +
            "automation tasks, and ensures that the specified delay occurs between each character.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeys plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured to send 'Foo Bar' keystrokes with the specified delay between each character, the plugin accurately simulates user input with the specified delay.")]
        [AcceptanceCriteria(criteria: "Input Simulation: The target UI element receives and processes the sent keystrokes 'Foo Bar' with the specified delay between each character as expected.")]
        [AcceptanceCriteria(criteria: "Delay Verification: The plugin ensures that the specified delay occurs between each character during keystroke input interactions.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected issues or failures during keystroke input interactions, ensuring stability and reliability.")]
        #endregion
        #region *** Data     ***
        [DataRow("1000")]
        [DataRow("00:00:01")]
        #endregion
        public void T0002P(string delay)
        {
            // Create AutomationEnvironment instance with test context and delay parameter
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "delay", value: delay);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            var response = Invoke<C0002>(testOptions);

            // Get the performance point related to sending keys
            var performancePoint = response
                .ResponseData
                .PerformancePoints.FilterByPluginName<G4PluginPerformancePointModel>("SendKeys")
                .First();

            // Assert that the runtime of the performance point is greater than 6 seconds
            Assert.IsGreaterThan(6 * TimeSpan.TicksPerSecond, performancePoint.RunTime);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeys plugin, when configured to send specific keystrokes after clearing " +
            "a designated input element, accurately simulates user interactions in UI automation tasks, " +
            "ensuring the input element is cleared before inputting the specified keystrokes.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeys plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Clear Element: The plugin clears the specified input element '#InputEnabledWithText' before sending keystrokes 'Foo Bar'.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured to send 'Foo Bar' keystrokes after clearing the input element, the plugin accurately simulates user input.")]
        [AcceptanceCriteria(criteria: "Input Simulation: The target input element '#InputEnabledWithText' receives and processes the sent keystrokes 'Foo Bar' as expected.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected issues or failures during keystroke input interactions, ensuring stability and reliability.")]
        #endregion
        public void T0003P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeys plugin, when configured to send specific keystrokes using the " +
            "native clear option for a designated input element, accurately simulates user interactions " +
            "in UI automation tasks, ensuring the input element is cleared before inputting the " +
            "specified keystrokes.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeys plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Native Clear Option: The plugin utilizes the native clear option to clear the specified input element '#InputEnabledWithText' before sending keystrokes 'Foo Bar'.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured to send 'Foo Bar' keystrokes using the native clear option, the plugin accurately simulates user input.")]
        [AcceptanceCriteria(criteria: "Input Simulation: The target input element '#InputEnabledWithText' receives and processes the sent keystrokes 'Foo Bar' as expected.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected issues or failures during keystroke input interactions, ensuring stability and reliability.")]
        #endregion
        public void T0004P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeys plugin, when configured to send specific keystrokes with a " +
            "modifier key, accurately simulates user interactions in UI automation tasks, ensuring " +
            "the modifier key is applied during keystroke input.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeys plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Modifier Key Support: The plugin supports sending keystrokes with the Control modifier applied to the specified element '#TextAreaEnabled'.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured to send 'A' keystroke with the Control modifier, the plugin accurately simulates user input.")]
        [AcceptanceCriteria(criteria: "Input Simulation: The target input element '#TextAreaEnabled' receives and processes the sent keystrokes 'A' with the Control modifier as expected.")]
        [AcceptanceCriteria(criteria: "Modifier Key Application: The plugin ensures that the Control modifier is applied during keystroke input interactions.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected issues or failures during keystroke input interactions, ensuring stability and reliability.")]
        #endregion
        public void T0005P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeys plugin gracefully handles non-interactive elements, such as divs, " +
            "by throwing and handling relevant exceptions during keystroke input interactions.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeys plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Non-Interactive Element Handling: When attempting to send keystrokes to a non-interactive element, such as '#UrlDivText', the plugin throws a relevant exception.")]
        [AcceptanceCriteria(criteria: "Exception Handling: The plugin gracefully handles the thrown exception, ensuring stability and reliability of automation test execution.")]
        [AcceptanceCriteria(criteria: "Error Reporting: Relevant details of the exception, including the element and action, are reported for debugging purposes.")]
        #endregion
        public void T0006P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html")
            {
                FailOnException = false
            };

            // Invoking the test with the constructed test options
            var response = Invoke<C0006>(testOptions);

            // Ensure that there are exceptions in the response
            Assert.IsTrue(response.ResponseData.Exceptions.Any());
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeys plugin gracefully handles disabled elements by throwing and " +
            "handling relevant exceptions during keystroke input interactions.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeys plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Disabled Element Handling: When attempting to send keystrokes to a disabled element, the plugin throws a relevant exception.")]
        [AcceptanceCriteria(criteria: "Exception Handling: The plugin gracefully handles the thrown exception, ensuring stability and reliability of automation test execution.")]
        [AcceptanceCriteria(criteria: "Error Reporting: Relevant details of the exception, including the element and action, are reported for debugging purposes.")]
        #endregion
        public void T0007P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html")
            {
                FailOnException = false,
                Negative = true
            };

            // Invoking the test with the constructed test options
            var response = Invoke<C0007>(testOptions);

            // Ensure that there are exceptions in the response
            Assert.IsTrue(response.ResponseData.Exceptions.Any());
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeys plugin accurately sends keystrokes with Control and Alt modifiers " +
            "to an input element.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Initial State: The input element '#InputText' should be empty before sending any keys.")]
        [AcceptanceCriteria(criteria: "Key Sending: The SendKeys plugin must correctly send 'Ctrl+Alt+S' to the input element '#InputText'.")]
        [AcceptanceCriteria(criteria: "Final State: The input element '#InputText' should contain the value 'Ctrl+Alt+S detected' after sending the keys.")]
        [AcceptanceCriteria(criteria: "Integration: The plugin must seamlessly integrate into the existing automation framework and perform the key sending and assertion without errors.")]
        #endregion
        public void T0008P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0008>(testOptions);
        }
    }
}
