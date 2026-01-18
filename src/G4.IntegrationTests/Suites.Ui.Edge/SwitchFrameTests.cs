using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SwitchFrame;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SwitchFrame")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to navigate frames within web pages effortlessly, So " +
        "that I can effectively interact with frame-bound elements during automated tasks and RPA processes.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchFrame plugin seamlessly integrates into the G4™ ecosystem, ensuring easy incorporation into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Frame Navigation Functionality: The plugin accurately handles frame navigation within web pages, supporting both frame identification by ID and by HTML element.")]
    [AcceptanceCriteria(criteria: "Parameter Flexibility: Users can specify frame navigation parameters such as frame ID or HTML element, providing adaptability to diverse automation scenarios and web page structures.")]
    [AcceptanceCriteria(criteria: "Reliable Frame Switching: The plugin reliably switches frames within web pages, ensuring consistency and predictability in automation outcomes across different scenarios.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage scenarios where the specified frame ID or element cannot be found, providing informative feedback to users for troubleshooting and resolution.")]
    #endregion
    public class SwitchFrameTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchFrame plugin, when configured with a specific frame index, correctly " +
            "switches to the designated frame, enabling subsequent actions within it.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchFrame plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'FrameIndex' parameter set to 0, the plugin switches to the frame with index 0.")]
        [AcceptanceCriteria(criteria: "Frame Switching Verification: Subsequent actions are executed within the switched frame context.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle scenarios where the specified frame index is invalid.")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchFrame plugin, when configured with a specific frame element, correctly " +
            "switches to the designated frame, enabling subsequent actions within it.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchFrame plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Frame Identification: When configured with 'OnElement' property set to '#FrameOne' CSS selector, the plugin switches to the frame with the corresponding element.")]
        [AcceptanceCriteria(criteria: "Frame Switching Verification: Subsequent actions are executed within the switched frame context.")]
        [AcceptanceCriteria(criteria: "Error Handling: Proper error handling mechanisms are in place to handle scenarios where the specified frame element is invalid or not found.")]
        #endregion
        public void T0002P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Frames.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }
    }
}
