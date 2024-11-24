/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.GetParameter;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    /// <summary>
    /// Test class for testing the behavior of GetParameter plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("GetParameter")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to retrieve parameter values from the environment, So " +
        "that I can access environment parameters and use them in automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The GetParameter plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Parameter Retrieval Functionality: The plugin effectively retrieves parameter values from the specified scope in the environment, supporting regular expressions for flexible retrieval.")]
    [AcceptanceCriteria(criteria: "Base64 Encoding/Decoding: All parameter values are encoded as base64 by default, ensuring consistent handling of encoded parameters. The NoDecode flag can be used to notify that a parameter is not encoded, providing flexibility in handling decoded parameters.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during parameter retrieval, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class GetParameterTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the Get-Parameter plugin correctly registers a parameter with " +
            "an expected value and scope, sends this value to a designated element, and " +
            "asserts its presence.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-Parameter plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: The plugin accurately registers a parameter with the expected value and specified scope.")]
        [AcceptanceCriteria(criteria: "Value Sending: The plugin successfully sends the registered parameter value to an element on the webpage.")]
        [AcceptanceCriteria(criteria: "Value Assertion: The plugin correctly asserts the presence of the parameter value in the designated element.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-Parameter", "Application")]
        [DataRow("Get-Parameter", "Machine")]
        [DataRow("Get-Parameter", "Process")]
        [DataRow("Get-Parameter", "Session")]
        [DataRow("Get-Parameter", "User")]
        [DataRow("GetParameter", "Application")]
        [DataRow("GetParameter", "Machine")]
        [DataRow("GetParameter", "Process")]
        [DataRow("GetParameter", "Session")]
        [DataRow("GetParameter", "User")]
        [DataRow("getparam", "Application")]
        [DataRow("getparam", "Machine")]
        [DataRow("getparam", "Process")]
        [DataRow("getparam", "Session")]
        [DataRow("getparam", "User")]
        #endregion
        public void T0001P(string pluginName, string scope)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "scope", value: scope)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the Get-Parameter plugin correctly registers a parameter with " +
            "an expected value (decoded from Base64) and scope, sends this value to a " +
            "designated element without decoding, and asserts its presence as a Base64 " +
            "encoded string.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-Parameter plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: The plugin accurately registers a parameter with the expected value (decoded from Base64) and specified scope.")]
        [AcceptanceCriteria(criteria: "Value Sending: The plugin successfully sends the registered parameter value to an element on the webpage without decoding.")]
        [AcceptanceCriteria(criteria: "Value Assertion: The plugin correctly asserts the presence of the parameter value in the designated element as a Base64 encoded string.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-Parameter", "Application")]
        [DataRow("Get-Parameter", "Machine")]
        [DataRow("Get-Parameter", "Process")]
        [DataRow("Get-Parameter", "Session")]
        [DataRow("Get-Parameter", "User")]
        #endregion
        public void T0002P(string pluginName, string scope)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "scope", value: scope)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the Get-Parameter plugin correctly registers a parameter with " +
            "an expected value, application scope, and specific environment, sends this " +
            "value to a designated element, and asserts its presence.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Get-Parameter plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: The plugin accurately registers a parameter with the expected value, application scope, and specific environment.")]
        [AcceptanceCriteria(criteria: "Value Sending: The plugin successfully sends the registered parameter value to an element on the webpage.")]
        [AcceptanceCriteria(criteria: "Value Assertion: The plugin correctly asserts the presence of the parameter value in the designated element.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("Get-Parameter")]
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
