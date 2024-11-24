using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.MoveMouseCursor;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("MoveMouseCursor")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables moving the mouse cursor to specified coordinates or " +
        "an element, So that I can simulate mouse interactions in automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The MoveMouseCursor plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Mouse Cursor Movement: The plugin effectively moves the mouse cursor to specified coordinates or an element on the webpage, supporting both absolute and relative positioning.")]
    [AcceptanceCriteria(criteria: "Support for Coordinates: The plugin allows specifying X and Y coordinates to move the mouse cursor to a specific location on the screen.")]
    [AcceptanceCriteria(criteria: "Support for Elements: The plugin supports moving the mouse cursor to specific elements on the webpage, enabling interaction with UI elements.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during mouse cursor movement, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class MoveMouseCursorTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the MoveMouseCursor plugin correctly maximizes the browser window, " +
            "asserts the equality of the ScrollOutcomeY attribute to 0, moves the mouse cursor " +
            "to the MoveOutcome element, and asserts that the ScrollOutcomeY attribute is greater " +
            "than 0.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The MoveMouseCursor plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Maximize: The plugin successfully maximizes the browser window.")]
        [AcceptanceCriteria(criteria: "Attribute Equality Assertion: The plugin asserts the equality of the ScrollOutcomeY attribute to 0.")]
        [AcceptanceCriteria(criteria: "Cursor Movement: The plugin accurately moves the mouse cursor to the MoveOutcome element.")]
        [AcceptanceCriteria(criteria: "Attribute Greater Than Assertion: The plugin asserts that the ScrollOutcomeY attribute is greater than 0.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        public void T0001P()
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the MoveMouseCursor plugin correctly maximizes the browser window, " +
            "moves the mouse cursor to the specified coordinates, and asserts that the " +
            "MouseXPosition and MouseYPosition elements display the expected coordinates.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The MoveMouseCursor plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Window Maximize: The plugin successfully maximizes the browser window.")]
        [AcceptanceCriteria(criteria: "Cursor Movement: The plugin accurately moves the mouse cursor to the specified coordinates.")]
        [AcceptanceCriteria(criteria: "X Coordinate Assertion: The plugin asserts that the text of the MouseXPosition element equals 100.")]
        [AcceptanceCriteria(criteria: "Y Coordinate Assertion: The plugin asserts that the text of the MouseYPosition element equals 150.")]
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
    }
}
