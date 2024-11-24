using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SetWindowRectangle;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SetWindowRectangle")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to manipulate the size and position of application or " +
        "browser windows, So that I can tailor the viewing experience and optimize UI testing and automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The SetWindowRectangle plugin seamlessly integrates into the G4™ platform's ecosystem, providing effortless access for automation engineers.")]
    [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin accepts parameters defining the height, width, x-coordinate, and y-coordinate of the application or browser window rectangle, allowing for flexible window manipulation.")]
    [AcceptanceCriteria(criteria: "Integration Testing: Ensure seamless integration of the SetWindowRectangle plugin into the G4™ automation framework, maintaining compatibility with existing features and functionalities.")]
    [AcceptanceCriteria(criteria: "Window Manipulation: Validate that the plugin effectively manipulates application or browser window rectangles based on the provided parameters, allowing for precise control over window size and position.")]
    [AcceptanceCriteria(criteria: "Error Handling: Implement robust error handling mechanisms within the plugin to manage unexpected issues during window manipulation, ensuring smooth execution of automation tasks.")]
    #endregion
    public class SetWindowRectangleTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetWindowRectangle plugin, when configured with specific dimensions, " +
            "correctly resizes the application window.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetWindowRectangle plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with specific dimensions (Height: 300, Width: 300, X: 100, Y: 100), the plugin resizes the application window accordingly.")]
        [AcceptanceCriteria(criteria: "Window Resizing Verification: The resized window dimensions are verified to match the specified parameters.")]
        [AcceptanceCriteria(criteria: "Validation Process: The resized window undergoes thorough validation to ensure it reflects the specified dimensions.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides meaningful error messages in case of failure.")]
        #endregion
        #region *** Data Set ***
        [DataRow("{{$ --Height:750 --Width:750 --X:100 --Y:100}}" , @"H:750\sW:750\sX:100\sY:100")]
        [DataRow("{{$ --Height:750}}", "H:750")]
        [DataRow("{{$ --Width:750}}", "W:750")]
        [DataRow("{{$ --X:100}}", "X:100")]
        [DataRow("{{$ --Y:100}}", "Y:100")]
        [DataRow("{{$ --Height:750 --Width:800}}", @"H:750\sW:800")]
        [DataRow("{{$ --Height:750 --X:100}}", "H:750.*X:100")]
        [DataRow("{{$ --Height:750 --Y:100}}", "H:750.*Y:100")]
        #endregion
        public void T0001P(string argument, string expected)
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: argument)
                .AddTestParameter(key: "expected", value: expected);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "WindowRectangle.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
