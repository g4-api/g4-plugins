/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.GetWindowHandle;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    /// <summary>
    /// Test class for testing the behavior of GetWindowHandle plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("GetWindowHandle")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to retrieve window handles, So that I can interact with " +
        "specific browser windows during automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The GetWindowHandle plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Window Handle Retrieval Functionality: The plugin effectively retrieves window handles based on the specified index, allowing automation scripts to interact with specific browser windows.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during window handle retrieval, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class GetWindowHandleTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to ensure that the Get-WindowHandle plugin correctly registers the window handle " +
            "with session scope, sends this handle to a designated element, and asserts its presence.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-WindowHandle plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Handle Registration: The plugin accurately registers the window handle obtained from the browser.")]
        [AcceptanceCriteria(criteria: "Value Sending: The plugin successfully sends the registered window handle to an element on the webpage.")]
        [AcceptanceCriteria(criteria: "Value Assertion: The plugin correctly asserts the presence of the window handle in the designated element.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-WindowHandle")]
        [DataRow("GetWindowHandle")]
        [DataRow("GetHandle")]
        [DataRow("gethandle")]
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

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to ensure that the Get-WindowHandle plugin correctly registers the window handle " +
            "of a new tab with session scope, sends this handle to a designated element, and " +
            "asserts its presence.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-WindowHandle plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Handle Registration: The plugin accurately registers the window handle of the specified tab obtained from the browser.")]
        [AcceptanceCriteria(criteria: "Value Sending: The plugin successfully sends the registered window handle to an element on the webpage.")]
        [AcceptanceCriteria(criteria: "Value Assertion: The plugin correctly asserts the presence of the window handle in the designated element.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-WindowHandle")]
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

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to ensure that the Get-WindowHandle plugin correctly registers the window handle " +
            "of the current tab with session scope, opens a new tab, retrieves its handle " +
            "directly with SendKeys action, and asserts that the window handles of the current " +
            "and new tabs are not equal.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-WindowHandle plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Handle Registration: The plugin accurately registers the window handle of the current tab with session scope.")]
        [AcceptanceCriteria(criteria: "New Tab Handling: The automation script opens a new tab and retrieves its handle directly using SendKeys action.")]
        [AcceptanceCriteria(criteria: "Value Assertion: The plugin correctly asserts that the window handles of the current and new tabs are not equal.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-WindowHandle")]
        #endregion
        public void T0003P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }
    }
}
