using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SwitchWindow;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SwitchWindow")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to effortlessly switch between application windows during " +
        "UI automation tasks, So that I can efficiently manage multi-window interactions and enhance the robustness of " +
        "my automated processes.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The SwitchWindow plugin must be readily accessible within the G4™ ecosystem, enabling easy integration into automation workflows without requiring elaborate setup procedures.")]
    [AcceptanceCriteria(criteria: "Window Switching Functionality: The plugin effectively switches between application windows based on either index or window handle name, ensuring smooth navigation between multiple windows during automated tasks.")]
    [AcceptanceCriteria(criteria: "Parameter Flexibility: Users have the flexibility to specify the window to switch to using either an index or a window handle name, providing versatility in handling different window navigation scenarios.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage scenarios such as out-of-range indices and non-existent window handle names, ensuring stable and reliable performance of automation workflows.")]
    #endregion
    public class SwitchWindowTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchWindow plugin, when invoked to switch to a specific window index, " +
            "correctly changes the focus to the targeted window.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchWindow plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked with a window index parameter, the plugin successfully switches focus to the specified window.")]
        [AcceptanceCriteria(criteria: "Window Index Validity: The plugin ensures that the provided window index is within the valid range of available windows.")]
        [AcceptanceCriteria(criteria: "Focus Verification: After execution, the plugin ensures that the focus is correctly shifted to the targeted window.")]
        [AcceptanceCriteria(criteria: "Error Handling: If an invalid window index is provided, the plugin gracefully handles the error and provides appropriate feedback.")]
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
    }
}
