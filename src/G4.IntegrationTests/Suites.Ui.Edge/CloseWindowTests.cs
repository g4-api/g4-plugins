using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.CloseWindow;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("CloseWindow")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to close browser windows, So that I can efficiently manage " +
        "browser instances and streamline automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The CloseWindow plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Window Closing Functionality: The plugin effectively closes browser windows based on the specified window handle or index, ensuring efficient management of browser instances during automation workflows.")]
    [AcceptanceCriteria(criteria: "Customization Options: The plugin allows users to specify either a window handle or an index to close a specific window, providing flexibility in browser window management.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during window closing operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class CloseWindowTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the CloseWindow plugin, when configured to close the current browser window " +
            "or tab, correctly closes the window and updates the window count.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CloseWindow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Closing: The plugin successfully closes the current browser window or tab.")]
        [AcceptanceCriteria(criteria: "Window Count Verification: The automation script verifies that the count of windows is updated after closing the current window or tab.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the window closing process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("CloseWindow")]
        [DataRow("closeWindow")]
        #endregion
        public void T0001P(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment)
            {
                FailOnException = false,
            };

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the CloseWindow plugin, when configured to close a specific browser " +
            "window or tab by its 0-based index, correctly closes the window and updates the window count.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CloseWindow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Closing: The plugin successfully closes the browser window or tab at the specified 0-based index.")]
        [AcceptanceCriteria(criteria: "Window Count Verification: The automation script verifies that the count of windows is updated after closing the specified window or tab.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the window closing process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("CloseWindow")]
        [DataRow("closeWindow")]
        #endregion
        public void T0002P(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment)
            {
                FailOnException = false,
            };

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the CloseWindow plugin, when configured to close a specific browser window " +
            "or tab by getting the window handle at a given index, correctly closes the window and " +
            "updates the window count.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CloseWindow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Closing: The plugin successfully closes the browser window or tab by getting the window handle at the specified index.")]
        [AcceptanceCriteria(criteria: "Window Count Verification: The automation script verifies that the count of windows is updated after closing the specified window or tab.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the window closing process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("CloseWindow")]
        [DataRow("closeWindow")]
        #endregion
        public void T0003P(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }
    }
}
