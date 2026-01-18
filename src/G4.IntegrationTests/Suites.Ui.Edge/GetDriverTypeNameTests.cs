/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.GetDriverTypeName;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    /// <summary>
    /// Test class for testing the behavior of GetDriverType plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("GetDriverTypeName")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to retrieve the type name of the WebDriver, So that " +
        "I can obtain information about the type of driver being used during automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The GetDriverTypeName plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Driver Type Name Retrieval Functionality: The plugin effectively retrieves the type name of the WebDriver, allowing automation engineers to obtain information about the type of driver being used during automation workflows.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during driver type name retrieval, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class GetDriverTypeNameTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the Get-DriverTypeName plugin correctly interacts with the web driver " +
            "and retrieves the expected driver type name.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-DriverTypeName plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Sequence: The plugin executes a sequence of actions, including sending the plugin value to an element and asserting the element's attribute value.")]
        [AcceptanceCriteria(criteria: "Web Driver Interaction: The plugin interacts with the web driver to retrieve the driver type name.")]
        [AcceptanceCriteria(criteria: "Element Interaction: The plugin sends the retrieved driver type name to an element on the webpage and asserts that the element's attribute value matches the expected value.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-DriverTypeName")]
        [DataRow("GetDriverTypeName")]
        [DataRow("gdriver")]
        [DataRow("GetDriver")]
        [DataRow("getDriver")]
        #endregion
        public void T0001P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName)
                .AddTestParameter(key: "expected", value: "G4.WebDriver.Remote.Edge.EdgeDriver");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need " +
            "to verify that the Get-DriverTypeName plugin correctly interacts with the web driver, " +
            "extracts the file name using a regex pattern, and sends it to the designated element.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-DriverTypeName plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Sequence: The plugin executes a sequence of actions, including sending the plugin value to an element and asserting the element's attribute value.")]
        [AcceptanceCriteria(criteria: "Web Driver Interaction: The plugin interacts with the web driver to retrieve the driver type name.")]
        [AcceptanceCriteria(criteria: "Element Interaction: The plugin sends the extracted file name, using a regex pattern, to an element on the webpage and asserts that the element's attribute value matches the expected value.")]
        [AcceptanceCriteria(criteria: "Pattern Usage: The plugin utilizes a regex pattern to extract the exact value from the driver type name.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data      ***
        [DataRow("Get-DriverTypeName")]
        #endregion
        public void T0002P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName)
                .AddTestParameter(key: "expected", value: "EdgeDriver");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }
    }
}
