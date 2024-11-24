using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.InvokeDoubleClick;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [DoNotParallelize]
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("InvokeDoubleClick")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to perform a double-click action on a web element, allowing " +
        "me to interact with web elements that require double-clicking for specific actions or functionalities.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The InvokeDoubleClick plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Double-Click Action: The plugin should perform a double-click action on a specified web element, enabling automation engineers to simulate double-click interactions during automated tests or workflows.")]
    [AcceptanceCriteria(criteria: "Element Verification: The plugin should verify the existence of the target element before performing the double-click action, ensuring that the action is executed only when the element is present.")]
    [AcceptanceCriteria(criteria: "Mouse Cursor Movement: If the target element is not immediately visible, the plugin should move the mouse cursor to the element's location before performing the double-click action, ensuring accurate interaction with the element.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during the double-click action, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class InvokeDoubleClickTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeDoubleClick plugin accurately simulates a double-click " +
            "action on a specified element.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeDoubleClick plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates a double-click action on the specified element.")]
        [AcceptanceCriteria(criteria: "Element Selection: The plugin correctly identifies and interacts with the specified element.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the double-click action.")]
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
            "to verify that the InvokeDoubleClick plugin accurately simulates a double-click " +
            "action on the last known mouse location.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeDoubleClick plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates a double-click action on the last known mouse location.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the double-click action.")]
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
