using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.NewBrowserWindow;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("NewBrowserWindow")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables opening new browser windows, So that I can perform tasks " +
        "requiring multiple browser windows in automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The NewBrowserWindow plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Opening New Browser Windows: The plugin effectively executes JavaScript to open new browser windows based on the specified action rules, supporting customizable URL extraction and target settings.")]
    [AcceptanceCriteria(criteria: "Support for Multiple Windows: The plugin allows opening multiple browser windows at once, with the option to specify the number of windows to open.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during window opening, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class NewBrowserWindowTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the NewBrowserWindow plugin correctly opens a new browser window " +
            "with the specified URL, amount, and target, and ensures that the number of " +
            "windows equals the expected value.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewBrowserWindow plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Opening: The plugin accurately opens a new browser window with the specified URL, amount, and target.")]
        [AcceptanceCriteria(criteria: "Window Count Assertion: The plugin asserts that the number of opened windows equals the expected value.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("about:blank", "_blank", 3, 4)]
        [DataRow("about:blank", "_parent", 3, 1)]
        [DataRow("about:blank", "_self", 3, 1)]
        [DataRow("about:blank", "_top", 3, 1)]
        #endregion
        public void T0001P(
            string url,
            string target,
            int amount,
            int expected)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "amount", value: amount)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "target", value: target)
                .AddTestParameter(key: "url", value: url);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment)
            {
                FailOnException = false // Workaround driver issue
            };

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the NewBrowserWindow plugin correctly opens a new browser window " +
            "with the specified URL, and ensures that the number of opened windows equals " +
            "2, and that switching to the second window and verifying its URL matches the " +
            "expected URL works as expected.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewBrowserWindow plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Opening: The plugin accurately opens a new browser window with the specified URL.")]
        [AcceptanceCriteria(criteria: "Window Count Assertion: The plugin asserts that the number of opened windows equals 2.")]
        [AcceptanceCriteria(criteria: "Window Switching: The plugin successfully switches to the second window.")]
        [AcceptanceCriteria(criteria: "URL Verification: The plugin verifies that the page URL of the second window matches the expected URL.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("about:blank")]
        #endregion
        public void T0002P(string url)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "url", value: url);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }
    }
}
