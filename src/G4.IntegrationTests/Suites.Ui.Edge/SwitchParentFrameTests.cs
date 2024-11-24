using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SwitchParentFrame;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SwitchParentFrame")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to switch to the highest frame effortlessly, So that " +
        "I can navigate back to the main page during UI automation, ensuring accurate interaction with web applications.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin is easily accessible within the G4™ platform's ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Highest Frame Switching: The plugin effectively switches to the highest frame (main page) during UI automation tasks, enabling smooth navigation within nested iframes of web applications.")]
    [AcceptanceCriteria(criteria: "Error Handling: The plugin includes robust error handling mechanisms to manage unexpected issues during highest frame switching, ensuring smooth execution of automation tasks.")]
    #endregion
    public class SwitchParentFrameTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchParentFrame plugin, when invoked, navigates to the highest frame, " +
            "ensuring accurate navigation within nested iframes during UI automation.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchParentFrame plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Functionality Verification: Upon invocation, the plugin effectively navigates to the highest frame, facilitating traversal to the main page.")]
        [AcceptanceCriteria(criteria: "Robustness Check: The plugin handles scenarios with multiple levels of nested frames gracefully, ensuring reliable navigation across different layers of the application.")]
        [AcceptanceCriteria(criteria: "Configuration Flexibility: Users can configure the plugin to work with various automation contexts and environments, providing adaptability to different testing scenarios.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during frame navigation, ensuring stability and resilience in automation workflows.")]
        #endregion
        public void T0001P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Frames.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
