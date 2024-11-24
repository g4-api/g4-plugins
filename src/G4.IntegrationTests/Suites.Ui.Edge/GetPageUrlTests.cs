/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.GetPageUrl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("GetPageUrl")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to retrieve the URL of the current page, So that I can " +
        "obtain information about the current page's URL during automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The GetPageUrl plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Page URL Retrieval Functionality: The plugin effectively retrieves the URL of the current page, allowing automation engineers to obtain information about the current page's URL during automation workflows.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during page URL retrieval, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class GetPageUrlTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the Get-PageUrl plugin correctly retrieves the current page URL, " +
            "registers it as a session parameter, sends it to the designated element, and " +
            "asserts its value.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-PageUrl plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Sequence: The plugin executes a sequence of actions, including registering the page URL as a session parameter, sending the URL to an element, and asserting its value.")]
        [AcceptanceCriteria(criteria: "Page URL Retrieval: The plugin accurately retrieves the current page URL.")]
        [AcceptanceCriteria(criteria: "Element Interaction: The plugin sends the page URL to an element on the webpage and asserts that the element's attribute value matches the page URL.")]
        [AcceptanceCriteria(criteria: "Parameter Usage: The plugin registers the page URL as a session parameter and uses it in subsequent actions.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-PageUrl")]
        [DataRow("GetPageUrl")]
        [DataRow("GpageUrl")]
        [DataRow("gpageurl")]
        #endregion
        public void T0001P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the Get-PageUrl plugin correctly retrieves the current page URL, " +
            "opens it with additional parameters, sends a numeric value extracted from the URL " +
            "to a designated element using a specified pattern, and asserts its value.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-PageUrl plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Sequence: The plugin executes a sequence of actions, including opening the page URL with additional parameters, sending a numeric value extracted using the specified pattern to an element, and asserting its value.")]
        [AcceptanceCriteria(criteria: "Page URL Retrieval: The plugin accurately retrieves the current page URL.")]
        [AcceptanceCriteria(criteria: "URL Parameter Handling: The plugin successfully appends additional parameters to the page URL.")]
        [AcceptanceCriteria(criteria: "Pattern Usage: The plugin correctly applies the specified pattern to extract the numeric value from the URL.")]
        [AcceptanceCriteria(criteria: "Element Interaction: The plugin sends the extracted numeric value to an element on the webpage and asserts that the element's attribute value matches the expected value.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-PageUrl")]
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
