using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SetWindowState;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SetWindowState")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to control browser window states, such as full-screen, maximized, and minimized, " +
        "so that I can optimize UI testing and automation workflows with different window state scenarios.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin seamlessly integrates into the G4™ platform's ecosystem, providing effortless access for automation engineers.")]
    [AcceptanceCriteria(criteria: "Window State Control: The plugin reliably toggles browser windows to full-screen, maximized, and minimized modes, enhancing the testing environment.")]
    [AcceptanceCriteria(criteria: "Compatibility: Window state functionality works across major web browsers supported by G4, ensuring consistency in automation processes.")]
    [AcceptanceCriteria(criteria: "Error Handling: The plugin includes robust error handling mechanisms to manage unexpected issues during window state control, ensuring smooth execution of automation tasks.")]
    #endregion
    public class SetWindowStateTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetWindowState plugin, when invoked, successfully toggles the browser " +
            "window to full-screen mode, ensuring an immersive viewing experience during UI testing " +
            "and automation workflows.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetWindowState plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Full-Screen Mode: Upon invocation, the plugin reliably toggles the browser window to full-screen mode.")]
        [AcceptanceCriteria(criteria: "Compatibility Check: Full-screen mode functionality works across major web browsers supported by G4.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin includes robust error handling mechanisms to manage unexpected issues during full-screen mode activation, ensuring smooth execution of automation tasks.")]
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

        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the SetWindowState plugin correctly maximizes the browser " +
            "window and triggers the corresponding event on the specified element.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetWindowState plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Maximization: The plugin accurately maximizes the browser window when invoked.")]
        [AcceptanceCriteria(criteria: "Event Triggering: The plugin triggers the corresponding event on the specified element after window maximization.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        public void T0002P()
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the SetWindowState plugin correctly minimizes the browser " +
            "window and triggers the corresponding event on the specified element.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetWindowState plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Minimization: The plugin accurately minimizes the browser window when invoked.")]
        [AcceptanceCriteria(criteria: "Event Triggering: The plugin triggers the corresponding event on the specified element after window minimization.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        public void T0003P()
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }
    }
}
