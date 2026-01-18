using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.NewWindow;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("NewWindow")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) " +
        "developer, I want a plugin within the G4™ framework that enables me to open new browser windows or " +
        "tabs effortlessly, So that I can simulate diverse user interactions and scenarios in my automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin must be easily accessible within the G4™ ecosystem, allowing seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Window Opening Functionality: The plugin must be capable of opening new browser windows or tabs, providing flexibility in simulating different user actions and behaviors.")]
    [AcceptanceCriteria(criteria: "Parameter Customization: Users must have the ability to specify parameters such as the type of window to open (e.g., window or tab), allowing customization based on specific automation requirements.")]
    [AcceptanceCriteria(criteria: "Integration with WebDriver: The plugin must integrate smoothly with the WebDriver's `TargetLocator` functionality to ensure reliable window opening actions during test execution.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms must be implemented to handle potential runtime errors and unexpected scenarios, ensuring the stability and resilience of automation workflows.")]
    #endregion
    public class NewWindowTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewWindow plugin, when configured with a specific window type, successfully " +
            "opens a new browser window or tab as specified.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewWindow plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with a specific window type parameter, the plugin opens a new browser window or tab.")]
        [AcceptanceCriteria(criteria: "Window Type Verification: The opened window type matches the specified configuration (e.g., window or tab).")]
        [AcceptanceCriteria(criteria: "Focus Switching: The SwitchWindow plugin successfully switches focus to the newly opened window or tab.")]
        [AcceptanceCriteria(criteria: "Page URL Assertion: The page URL of the newly opened window or tab is verified to match the expected value.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms ensure proper handling of unexpected scenarios during window opening.")]
        #endregion
        #region *** Data     ***
        [DataRow("tab")]
        [DataRow("window")]
        [DataRow(null)]
        [DataRow("")]
        #endregion
        public void T0001P(string type)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "type", value: type);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
