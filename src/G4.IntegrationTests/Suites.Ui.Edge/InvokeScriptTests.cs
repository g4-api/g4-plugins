using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.InvokeScript;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("InvokeScript")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables execution of custom JavaScript code on a web page, facilitating " +
        "advanced interactions and manipulations of elements and functionalities.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The InvokeScript plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Script Execution: The plugin allows execution of custom JavaScript code on a web page, enabling advanced interactions and manipulations of elements and functionalities.")]
    [AcceptanceCriteria(criteria: "Argument Support: The plugin supports passing arguments to the JavaScript code, allowing for dynamic and flexible script execution.")]
    [AcceptanceCriteria(criteria: "Element Targeting: The plugin supports targeting specific elements on the web page, enabling JavaScript code to interact with those elements directly.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage script execution errors, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class InvokeScriptTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeScript plugin correctly executes a script on the " +
            "page, and ensures that the page behaves as expected after script execution.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeScript plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Script Execution: The plugin accurately executes the specified script on the page.")]
        [AcceptanceCriteria(criteria: "Page Behavior Assertion: The plugin ensures that the page behaves as expected after script execution.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("InvokeScript")]
        [DataRow("invokeScript")]
        [DataRow("ExecuteScript")]
        [DataRow("executeScript")]
        #endregion
        public void T0001P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeScript plugin correctly executes a script block " +
            "on the page, and ensures that the page behaves as expected after script execution.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeScript plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Script Execution: The plugin accurately executes the specified script block on the page.")]
        [AcceptanceCriteria(criteria: "Page Behavior Assertion: The plugin ensures that the page behaves as expected after script execution.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("InvokeScript")]
        [DataRow("invokeScript")]
        [DataRow("ExecuteScript")]
        [DataRow("executeScript")]
        #endregion
        public void T0002P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeScript plugin correctly executes a script block " +
            "on the page, passing arguments when necessary, and ensures that the page " +
            "behaves as expected after script execution.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeScript plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Script Execution: The plugin accurately executes the specified script block on the page, passing arguments when necessary.")]
        [AcceptanceCriteria(criteria: "Page Behavior Assertion: The plugin ensures that the page behaves as expected after script execution.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("InvokeScript")]
        [DataRow("invokeScript")]
        [DataRow("ExecuteScript")]
        [DataRow("executeScript")]
        #endregion
        public void T0003P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeScript plugin correctly executes a script block " +
            "on the specified element, passing arguments when necessary, and ensures " +
            "that the element behaves as expected after script execution.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeScript plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Script Execution: The plugin accurately executes the specified script block on the specified element, passing arguments when necessary.")]
        [AcceptanceCriteria(criteria: "Element Behavior Assertion: The plugin ensures that the specified element behaves as expected after script execution.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("InvokeScript")]
        [DataRow("invokeScript")]
        [DataRow("ExecuteScript")]
        [DataRow("executeScript")]
        #endregion
        public void T0004P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeScript plugin correctly executes a script block " +
            "on the specified element, and ensures that the element behaves as expected " +
            "after script execution.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeScript plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Script Execution: The plugin accurately executes the specified script block on the specified element.")]
        [AcceptanceCriteria(criteria: "Element Behavior Assertion: The plugin ensures that the specified element behaves as expected after script execution.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("InvokeScript")]
        [DataRow("invokeScript")]
        [DataRow("ExecuteScript")]
        [DataRow("executeScript")]
        #endregion
        public void T0005P(string pluginName)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementTextInput.html");

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);
        }
    }
}
