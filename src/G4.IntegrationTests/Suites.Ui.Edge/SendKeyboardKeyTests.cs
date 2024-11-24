using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SendKeyboardKey;
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
    [TestCategory("SendKeyboardKey")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to simulate keyboard input on UI elements, So that " +
        "I can efficiently automate user interactions and test scenarios comprehensively.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The SendKeyboardKey plugin seamlessly integrates into the G4™ platform's ecosystem, providing easy access and seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Keyboard Input Simulation: The plugin is capable of simulating keyboard input by sending keys to designated web elements, allowing for versatile automation scenarios.")]
    [AcceptanceCriteria(criteria: "Input Field Clearing: Users have the option to clear input fields on web pages using either native or standard clearing methods, enhancing the versatility of the plugin for different testing requirements.")]
    [AcceptanceCriteria(criteria: "Customization Options: Users can customize parameters such as the delay between key presses, providing flexibility to adjust the plugin's behavior according to specific automation needs.")]
    [AcceptanceCriteria(criteria: "Exception Handling: The plugin gracefully handles exceptions during keyboard input and clearing operations, ensuring stable and reliable automation workflows. Detailed error logging is provided for effective debugging and troubleshooting.")]
    #endregion
    public class SendKeyboardKeyTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeyboardKey plugin, when configured to send the 'Enter' key to a " +
            "designated element, accurately simulates the keyboard input and triggers the expected " +
            "action on the web UI.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeyboardKey plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'Key' parameter set to 'Enter' and 'OnElement' parameter set to the designated element, the plugin sends the 'Enter' key.")]
        [AcceptanceCriteria(criteria: "Outcome Validation: The action triggered by sending the 'Enter' key to the designated element is validated to ensure the expected behavior on the web UI.")]
        [AcceptanceCriteria(criteria: "Verification Process: The functionality of the SendKeyboardKey plugin is thoroughly verified to guarantee accurate keyboard input simulation and reliable automation workflows.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected errors or exceptions during the keyboard input simulation process.")]
        #endregion
        public void T0001P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeyboardKey plugin, when configured to send a specified key (e.g., 'Enter') " +
            "to a designated element using the 'Key' parameter, accurately simulates the keyboard " +
            "input and captures the expected outcome.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeyboardKey plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'Key' parameter set to 'Enter' and 'OnElement' parameter set to the designated element, the plugin sends the 'Enter' key.")]
        [AcceptanceCriteria(criteria: "Outcome Capture: The outcome of sending the specified key to the designated element is accurately captured for further validation.")]
        [AcceptanceCriteria(criteria: "Assertion: The attribute value of the specified element is asserted to be equal to the specified key (e.g., 'Enter'), ensuring the expected outcome of the keyboard input.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected errors or exceptions during the keyboard input simulation process.")]
        #endregion
        public void T0002P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeyboardKey plugin, when configured to send multiple specified " +
            "keys (e.g., 'Enter' and 'Backspace') to a designated element using the 'Key' parameter, " +
            "accurately simulates the keyboard input and captures the expected outcomes.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeyboardKey plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'Key' parameters set to 'Enter' and 'Backspace', and 'OnElement' parameter set to the designated element, the plugin sends the 'Enter' and 'Backspace' keys.")]
        [AcceptanceCriteria(criteria: "Outcome Capture: The outcomes of sending the specified keys to the designated element are accurately captured for further validation.")]
        [AcceptanceCriteria(criteria: "Assertion: The attribute value of the specified element is asserted to be equal to the specified keys (e.g., 'Enter' and 'Backspace'), ensuring the expected outcomes of the keyboard input.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected errors or exceptions during the keyboard input simulation process.")]
        #endregion
        public void T0003P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeyboardKey plugin, when configured to send multiple specified " +
            "keys (e.g., 'Enter' and 'Backspace') to a designated element with a specified delay " +
            "between each key input, accurately simulates the keyboard input with the expected " +
            "delay and captures the expected outcomes.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeyboardKey plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'Key' parameters set to 'Enter' and 'Backspace', and 'Delay' parameter set to the specified delay value between each key input, the plugin sends the 'Enter' and 'Backspace' keys with the specified delay.")]
        [AcceptanceCriteria(criteria: "Outcome Capture: The outcomes of sending the specified keys to the designated element with a specified delay between each key input are accurately captured for further validation.")]
        [AcceptanceCriteria(criteria: "Delay Assertion: The delay between each key input is accurately asserted to be the specified delay value.")]
        [AcceptanceCriteria(criteria: "Assertion: The attribute value of the specified elements is asserted to be equal to the specified keys (e.g., 'Enter' and 'Backspace'), ensuring the expected outcomes of the keyboard input.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected errors or exceptions during the keyboard input simulation process.")]
        #endregion
        #region *** Data     ***
        [DataRow("00:00:04")]
        [DataRow("4000")]
        #endregion
        public void T0004P(string delay)
        {
            // Create AutomationEnvironment instance with test context and delay parameter
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "delay", value: delay);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0004>(testOptions);

            // Get the performance point related to sending keyboard keys
            var performancePoint = response
                .ResponseData
                .PerformancePoints.FilterByPluginName<G4PluginPerformancePointModel>("SendKeyboardKey")
                .First();

            // Assert that the runtime of the performance point is greater than 8 seconds
            Assert.IsTrue(performancePoint.RunTime > 8 * TimeSpan.TicksPerSecond);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeyboardKey plugin, when configured to clear any existing text in " +
            "the designated element and send the 'Enter' key, accurately performs the specified " +
            "actions and triggers the expected outcomes.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeyboardKey plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Clearing Existing Text: The plugin clears any existing text in the designated element before sending the 'Enter' key.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'Key' parameter set to 'Enter' and 'Clear' parameter, the plugin sends the 'Enter' key after clearing existing text.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The attribute value of the designated element is verified to be equal to 'KeyboardKeyOutcome', ensuring proper initialization.")]
        [AcceptanceCriteria(criteria: "Assertion: The attribute value of the first specified element is asserted to be equal to 'Enter', confirming the successful keyboard input.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected errors or exceptions during the keyboard input simulation process.")]
        #endregion
        public void T0005P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SendKeyboardKey plugin, when configured to clear any existing text in " +
            "the designated element using native clear functionality and send the 'Enter' key, " +
            "accurately performs the specified actions and triggers the expected outcomes.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendKeyboardKey plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Native Clear Functionality: The plugin utilizes native clear functionality to clear any existing text in the designated element before sending the 'Enter' key.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'Key' parameter set to 'Enter' and 'NativeClear' parameter, the plugin clears any existing text using native clear functionality before sending the 'Enter' key.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The attribute value of the designated element is verified to be equal to 'KeyboardKeyOutcome', ensuring proper initialization.")]
        [AcceptanceCriteria(criteria: "Assertion: The attribute value of the last specified element is asserted to be equal to 'Enter', confirming the successful keyboard input.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected errors or exceptions during the keyboard input simulation process.")]
        #endregion
        public void T0006P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0006>(testOptions);
        }
    }
}
