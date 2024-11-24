using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SwitchAlert;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SwitchAlert")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to handle alert dialogs during automated tasks, So that " +
        "I can automate processes involving alert dialogs without interruptions.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The SwitchAlert plugin must be easily accessible within the G4™ platform's ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Alert Dialog Handling: The plugin effectively switches to and handles alert dialogs, allowing users to accept or dismiss alerts based on specified actions.")]
    [AcceptanceCriteria(criteria: "Custom Input: Users have the capability to send custom input keys to alert dialogs if required, ensuring flexibility in handling diverse alert scenarios.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to address unexpected scenarios such as invalid inputs or runtime errors, ensuring the stability and reliability of automation workflows.")]
    #endregion
    public class SwitchAlertTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchAlert plugin successfully dismisses the alert dialog by default, " +
            "or clicks on the cancel button if available, when invoked without any arguments.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchAlert plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Invoking SwitchAlert: Upon invoking the SwitchAlert plugin without any arguments, it effectively dismisses the alert dialog by default, or clicks on the cancel button if available.")]
        [AcceptanceCriteria(criteria: "Alert Dialog Interaction: Once dismissed or cancelled, it returns control back to the automation script.")]
        [AcceptanceCriteria(criteria: "Verification of Default Behavior: The plugin ensures that the default behavior of dismissing the alert or clicking on cancel is correctly executed.")]
        [AcceptanceCriteria(criteria: "Error Handling: The SwitchAlert plugin gracefully handles any errors or unexpected conditions that may occur during execution.")]
        #endregion
        public void T0001P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Alerts.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchAlert plugin successfully switches to the alert dialog and accepts " +
            "it when provided with the 'Accept' argument.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchAlert plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Invoking SwitchAlert: Upon invoking the SwitchAlert plugin with the 'Accept' argument, it effectively switches to the alert dialog and accepts it.")]
        [AcceptanceCriteria(criteria: "Alert Dialog Interaction: Once accepted, it returns control back to the automation script.")]
        [AcceptanceCriteria(criteria: "Verification of Acceptance: The plugin ensures that the alert is accepted successfully.")]
        [AcceptanceCriteria(criteria: "Error Handling: The SwitchAlert plugin gracefully handles any errors or unexpected conditions that may occur during execution.")]
        #endregion
        public void T0002P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Alerts.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchAlert plugin successfully switches to the alert dialog, sends " +
            "specified keys to it, and then accepts it when provided with the appropriate arguments.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchAlert plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Invoking SwitchAlert with Keys: Upon invoking the SwitchAlert plugin with the 'Keys' argument, it effectively switches to the alert dialog and sends specified keys to it.")]
        [AcceptanceCriteria(criteria: "Invoking SwitchAlert with AlertAction: Upon invoking the SwitchAlert plugin with the 'AlertAction' argument set to 'Accept', it effectively switches to the alert dialog and accepts it.")]
        [AcceptanceCriteria(criteria: "Alert Dialog Interaction: Once keys are sent and the alert is accepted, it returns control back to the automation script.")]
        [AcceptanceCriteria(criteria: "Verification of Keys Sent: The plugin ensures that the specified keys are sent successfully to the alert dialog.")]
        [AcceptanceCriteria(criteria: "Verification of Acceptance: The plugin ensures that the alert is accepted successfully.")]
        [AcceptanceCriteria(criteria: "Error Handling: The SwitchAlert plugin gracefully handles any errors or unexpected conditions that may occur during execution.")]
        #endregion
        public void T0003P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Alerts.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchAlert plugin successfully switches to the alert dialog, sends " +
            "specified keys to it, and then accepts the alert when provided with both 'Keys' " +
            "and 'AlertAction' arguments.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchAlert plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Invoking SwitchAlert with Keys and AlertAction: Upon invoking the SwitchAlert plugin with both 'Keys' and 'AlertAction' arguments, it effectively switches to the alert dialog, sends specified keys to it, and then accepts the alert.")]
        [AcceptanceCriteria(criteria: "Alert Dialog Interaction: Once keys are sent and the alert is accepted, it returns control back to the automation script.")]
        [AcceptanceCriteria(criteria: "Verification of Keys Sent: The plugin ensures that the specified keys are sent successfully to the alert dialog.")]
        [AcceptanceCriteria(criteria: "Verification of Acceptance: The plugin ensures that the alert is accepted successfully.")]
        [AcceptanceCriteria(criteria: "Error Handling: The SwitchAlert plugin gracefully handles any errors or unexpected conditions that may occur during execution.")]
        #endregion
        public void T0004P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Alerts.html");

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SwitchAlert plugin successfully switches to the alert dialog, sends " +
            "specified keys to it, and then dismisses the alert when provided with both 'Keys' " +
            "and 'AlertAction' arguments.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SwitchAlert plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Invoking SwitchAlert with Keys and AlertAction: Upon invoking the SwitchAlert plugin with both 'Keys' and 'AlertAction' arguments, it effectively switches to the alert dialog, sends specified keys to it, and then dismisses the alert.")]
        [AcceptanceCriteria(criteria: "Alert Dialog Interaction: Once keys are sent and the alert is dismissed, it returns control back to the automation script.")]
        [AcceptanceCriteria(criteria: "Verification of Keys Sent: The plugin ensures that the specified keys are sent successfully to the alert dialog.")]
        [AcceptanceCriteria(criteria: "Verification of Dismissal: The plugin ensures that the alert is dismissed successfully.")]
        [AcceptanceCriteria(criteria: "Error Handling: The SwitchAlert plugin gracefully handles any errors or unexpected conditions that may occur during execution.")]
        #endregion
        public void T0005P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Alerts.html");

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);
        }
    }
}
