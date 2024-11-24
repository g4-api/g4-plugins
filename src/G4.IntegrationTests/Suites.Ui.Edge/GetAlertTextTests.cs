/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.GetAlertText;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    /// <summary>
    /// Test class for testing the behavior of GetAlertText plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("GetAlertText")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to retrieve the text of alert dialogs, So that I can " +
        "extract and process alert messages during automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The GetAlertText plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Alert Text Retrieval Functionality: The plugin effectively retrieves the text of alert dialogs, allowing automation engineers to capture and process alert messages displayed during automation workflows.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during alert text retrieval, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class GetAlertTextTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the Get-AlertText plugin correctly interacts with alert dialogs on " +
            "webpages and handles alert text.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-AlertText plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Sequence: The plugin executes a sequence of actions, including clicking on an element, registering the alert text, switching to the alert dialog, and dismissing it.")]
        [AcceptanceCriteria(criteria: "Alert Text Handling: The plugin registers the alert text as a session parameter and sends it to a designated element on the webpage.")]
        [AcceptanceCriteria(criteria: "Alert Dismissal: The plugin switches to the alert dialog and dismisses it.")]
        [AcceptanceCriteria(criteria: "Element Interaction: The plugin sends the registered alert text to an element on the webpage and asserts that the element's attribute value matches the expected text.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-AlertText")]
        [DataRow("GetAlertText")]
        [DataRow("gAlertText")]
        [DataRow("galerttext")]
        #endregion
        public void T0001P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the Get-AlertText plugin correctly interacts with alert dialogs on " +
            "webpages, handles alert text with pattern matching, and extracts the exact text.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-AlertText plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Sequence: The plugin executes a sequence of actions, including clicking on an element, registering the alert text with a regular expression pattern for exact text extraction, switching to the alert dialog, and dismissing it.")]
        [AcceptanceCriteria(criteria: "Alert Text Handling: The plugin registers the alert text as a session parameter with a regular expression pattern for exact text extraction and sends it to a designated element on the webpage.")]
        [AcceptanceCriteria(criteria: "Alert Dismissal: The plugin switches to the alert dialog and dismisses it.")]
        [AcceptanceCriteria(criteria: "Element Interaction: The plugin sends the registered alert text to an element on the webpage and asserts that the element's attribute value matches the expected exact text.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-AlertText")]
        #endregion
        public void T0002P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }
    }
}
