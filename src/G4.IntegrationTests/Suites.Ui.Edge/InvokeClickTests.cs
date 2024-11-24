using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.InvokeClick;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("InvokeClick")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ ecosystem that allows me to perform a click action on a web element, enabling " +
        "me to interact with various UI elements during automated tests or workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The InvokeClick plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Click Action: The plugin performs a click action on a specified web element, allowing automation engineers to interact with UI elements during automated tests or workflows.")]
    [AcceptanceCriteria(criteria: "Element Verification: The plugin verifies the existence of the target element before performing the click action, ensuring that the action is executed only when the element is present.")]
    [AcceptanceCriteria(criteria: "Conditional Click: The plugin supports conditional clicking based on specified conditions, such as clicking until a certain condition is met.")]
    [AcceptanceCriteria(criteria: "Polling Interval: When performing conditional clicking, the plugin allows setting a polling interval between clicks to efficiently monitor the condition.")]
    [AcceptanceCriteria(criteria: "Timeout Handling: The plugin handles timeout scenarios gracefully when performing conditional clicking, ensuring that the action terminates within a specified timeout period if the condition is not met.")]
    [AcceptanceCriteria(criteria: "Mouse Location Click: If the target element is not specified, the plugin performs a click action at the last known mouse location.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during the click action, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class InvokeClickTests : TestBase
    {
        [TestCategory("Negative")]
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeClick plugin gracefully handles failed assertions when " +
            "simulating a click action on a specified element.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates a click action on the specified element, even in scenarios where the assertions fail.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin handles failed assertions gracefully and does not disrupt the test execution flow.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures, including failed assertions.")]
        #endregion
        public void T0001N()
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment)
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeClick plugin accurately simulates a click action on " +
            "a specified element.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates a click action on the specified element.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the click action.")]
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
            "to verify that the InvokeClick plugin accurately simulates a click action on a " +
            "specified element until an alert dialog appears, and then verify the presence " +
            "of the alert.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin seamlessly integrates with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates clicking on the specified element until an alert dialog appears.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the click action and subsequent alert verification.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        // Alert Exists
        [DataRow("AlertExists")]
        [DataRow("alertExists")]
        // Alert Visible
        [DataRow("AlertVisible")]
        [DataRow("alertVisible")]
        // Has Alert
        [DataRow("HasAlert")]
        [DataRow("hasAlert")]
        #endregion
        public void T0002P(string condition)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "condition", value: condition);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeClick plugin accurately simulates a click action on " +
            "a specified element, dismissing any alert dialogs triggered, and ensuring no " +
            "further alerts are present.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin seamlessly integrates with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates clicking on the specified element, dismissing any alert dialogs triggered, and continues clicking until no further alerts are present.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the click action and subsequent alert dismissals.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        // Alert Not Exists
        [DataRow("AlertNotExists")]
        [DataRow("alertNotExists")]
        // Has No Alert
        [DataRow("HasNoAlert")]
        [DataRow("hasNoAlert")]
        // No Alert
        [DataRow("NoAlert")]
        [DataRow("noAlert")]
        #endregion
        public void T0003P(string condition)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "condition", value: condition);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeClick plugin gracefully handles failed assertions " +
            "when simulating clicking on a specified element until it becomes active.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin seamlessly integrates with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates clicking on the specified element until it becomes active.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the click action and the element becoming active.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures, including failed assertions.")]
        #endregion
        #region *** Data     ***
        // Alert Not Exists
        [DataRow("alertNotExists")]
        [DataRow("AlertNotExists")]
        // Has No Alert
        [DataRow("hasNoAlert")]
        [DataRow("HasNoAlert")]
        // No Alert
        [DataRow("noAlert")]
        [DataRow("NoAlert")]
        #endregion
        public void T0004N(string condition)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "condition", value: condition);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementInteractions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeClick plugin accurately simulates a click action on " +
            "a specified element until it becomes active.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin seamlessly integrates with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates clicking on the specified element until it becomes active.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the click action and the element becoming active.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("alertNotExists")]
        [DataRow("AlertNotExists")]
        [DataRow("hasNoAlert")]
        [DataRow("HasNoAlert")]
        [DataRow("noAlert")]
        [DataRow("NoAlert")]
        #endregion
        public void T0004P(string condition)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "condition", value: condition);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ElementInteractions.html");

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeClick plugin gracefully handles failed assertions " +
            "when simulating clicking on a specified element until a condition is met.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin seamlessly integrates with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates clicking on the specified element until the specified condition is met.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the click action and meeting the specified condition.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures, including failed assertions.")]
        #endregion
        #region *** Data     ***
        // Equal
        [DataRow("ElementAttribute", "10", "9", "Eq")]
        [DataRow("ElementAttribute", "10", "9", "eq")]
        [DataRow("ElementAttribute", "10", "9", "Equal")]
        [DataRow("ElementAttribute", "10", "9", "equal")]
        // Greater Equal
        [DataRow("ElementAttribute", "10", "11", "GreaterEqual")]
        [DataRow("ElementAttribute", "10", "11", "greaterEqual")]
        [DataRow("ElementAttribute", "10", "11", "Ge")]
        [DataRow("ElementAttribute", "10", "11", "ge")]
        // Greater
        [DataRow("ElementAttribute", "10", "11", "Greater")]
        [DataRow("ElementAttribute", "10", "11", "greater")]
        [DataRow("ElementAttribute", "10", "11", "Gt")]
        [DataRow("ElementAttribute", "10", "11", "gt")]
        // Lower Equal
        [DataRow("ElementAttribute", "10", "0", "LowerEqual")]
        [DataRow("ElementAttribute", "10", "0", "lowerEqual")]
        [DataRow("ElementAttribute", "10", "0", "Le")]
        [DataRow("ElementAttribute", "10", "0", "le")]
        // Lower
        [DataRow("ElementAttribute", "2", "0", "Lower")]
        [DataRow("ElementAttribute", "2", "0", "lower")]
        [DataRow("ElementAttribute", "2", "0", "Lt")]
        [DataRow("ElementAttribute", "2", "0", "lt")]
        // Match
        [DataRow("ElementAttribute", "10", "^0$", "Match")]
        [DataRow("ElementAttribute", "10", "^0$", "match")]
        // Not Match
        [DataRow("ElementAttribute", "10", "^1$", "NotMatch")]
        [DataRow("ElementAttribute", "10", "^1$", "notMatch")]
        #endregion
        public void T0005N(
            string condition,
            string clicks,
            string expected,
            string @operator)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "clicks", value: clicks)
                .AddTestParameter(key: "condition", value: condition)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment)
            {
                Negative = true,
            };

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeClick plugin accurately simulates a click action on " +
            "a specified element until a condition is met.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin seamlessly integrates with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates clicking on the specified element until the specified condition is met.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the click action and meeting the specified condition.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        // Equal
        [DataRow("ElementAttribute", "10", "10", "Eq")]
        [DataRow("ElementAttribute", "10", "10", "eq")]
        [DataRow("ElementAttribute", "10", "10", "Equal")]
        [DataRow("ElementAttribute", "10", "10", "equal")]
        // Greater Equal
        [DataRow("ElementAttribute", "10", "10", "Ge")]
        [DataRow("ElementAttribute", "10", "10", "ge")]
        [DataRow("ElementAttribute", "10", "10", "GreaterEqual")]
        [DataRow("ElementAttribute", "10", "10", "greaterEqual")]
        [DataRow("ElementAttribute", "10", "9", "Ge")]
        [DataRow("ElementAttribute", "10", "9", "ge")]
        [DataRow("ElementAttribute", "10", "9", "GreaterEqual")]
        [DataRow("ElementAttribute", "10", "9", "greaterEqual")]
        // Greater
        [DataRow("ElementAttribute", "10", "9", "Gt")]
        [DataRow("ElementAttribute", "10", "9", "gt")]
        [DataRow("ElementAttribute", "10", "9", "Greater")]
        [DataRow("ElementAttribute", "10", "9", "greater")]
        // Lower Equal
        [DataRow("ElementAttribute", "10", "10", "Le")]
        [DataRow("ElementAttribute", "10", "10", "le")]
        [DataRow("ElementAttribute", "10", "10", "LowerEqual")]
        [DataRow("ElementAttribute", "10", "10", "lowerEqual")]
        [DataRow("ElementAttribute", "10", "1", "Le")]
        [DataRow("ElementAttribute", "10", "1", "le")]
        [DataRow("ElementAttribute", "10", "1", "LowerEqual")]
        [DataRow("ElementAttribute", "10", "1", "lowerEqual")]
        // Lower
        [DataRow("ElementAttribute", "10", "2", "Lower")]
        [DataRow("ElementAttribute", "10", "2", "lower")]
        [DataRow("ElementAttribute", "10", "2", "Lt")]
        [DataRow("ElementAttribute", "10", "2", "lt")]
        // Match
        [DataRow("ElementAttribute", "10", "^10$", "Match")]
        [DataRow("ElementAttribute", "10", "^10$", "match")]
        // Not Match
        [DataRow("ElementAttribute", "10", "^0$", "NotMatch")]
        [DataRow("ElementAttribute", "10", "^0$", "notMatch")]
        #endregion
        public void T0005P(
            string condition,
            string clicks,
            string expected,
            string @operator)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "clicks", value: clicks)
                .AddTestParameter(key: "condition", value: condition)
                .AddTestParameter(key: "expected", value: expected)
                .AddTestParameter(key: "operator", value: @operator);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeClick plugin accurately simulates a click action on " +
            "a specified element until it becomes disabled.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeClick plugin seamlessly integrates with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately simulates clicking on the specified element until it becomes disabled.")]
        [AcceptanceCriteria(criteria: "Outcome Verification: The plugin correctly updates the outcome attribute after the click action and the element becoming disabled.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        // Disable
        [DataRow("Disable")]
        [DataRow("disable")]
        // Disabled
        [DataRow("Disabled")]
        [DataRow("disabled")]
        // Element Disabled
        [DataRow("ElementDisabled")]
        [DataRow("elementDisabled")]
        #endregion
        public void T0006P(string condition)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "condition", value: condition);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0006>(testOptions);
        }
    }
}
