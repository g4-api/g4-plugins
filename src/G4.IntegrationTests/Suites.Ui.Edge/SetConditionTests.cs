using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.SetCondition;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SetCondition")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to automate conditional actions based on assertions, So " +
        "that I can efficiently manage complex automation workflows with adaptive execution flows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ ecosystem, allowing users to incorporate conditional automation logic without extensive setup requirements.")]
    [AcceptanceCriteria(criteria: "Assertion Handling: The plugin effectively handles assertions on various elements and properties within automation workflows, enabling users to define conditions based on evaluation outcomes.")]
    [AcceptanceCriteria(criteria: "Conditional Action Invocation: Users can specify actions to be triggered based on assertion evaluation results, supporting a range of conditional logic scenarios such as if-else conditions and loop constructs.")]
    [AcceptanceCriteria(criteria: "Configurability: The plugin offers flexibility in configuring assertion parameters and conditional actions, empowering users to tailor automation workflows to specific requirements.")]
    [AcceptanceCriteria(criteria: "Reliability: The SetCondition plugin consistently evaluates assertions and triggers conditional actions accurately, ensuring the reliability and predictability of automation outcomes.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during assertion evaluation and conditional action execution, ensuring the stability and resilience of automation workflows.")]
    #endregion
    public class SetConditionTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check for the existence " +
            "of an alert, triggers conditional actions accurately and seamlessly integrates " +
            "into the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the existence of an alert.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0001P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check for the absence of an alert, " +
            "triggers conditional actions accurately and seamlessly integrates into the automation " +
            "testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the absence of an alert.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0002P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to match a pattern with the driver " +
            "type name, triggers conditional actions accurately and seamlessly integrates into the " +
            "automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on matching a pattern with the driver type name.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0003P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "driverTypeName", value: "Edge");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is not active, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element not being active.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0004P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate a specified element " +
            "attribute and meet a condition, triggers conditional actions accurately and seamlessly " +
            "integrates into the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element's attribute meeting a condition.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0005P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the count of specified " +
            "elements and meet a condition, triggers conditional actions accurately and seamlessly " +
            "integrates into the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified elements count meeting a condition.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0006P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0006>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is disabled, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element being disabled.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0007P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0007>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is enabled, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element being enabled.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0008P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0008>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element exists, " +
            "triggers conditional actions accurately and seamlessly integrates into the automation " +
            "testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element's existence.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0009P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0009>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is not active, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element not being active.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0010P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0010>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "does not exist, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element not existing.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0011P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0011>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is not selected, triggers conditional actions accurately and seamlessly integrates " +
            "into the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element not being selected.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0012P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0012>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is not visible, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element not being visible.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0013P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0013>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is selected, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element being selected.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0014P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0014>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate a specified element's " +
            "text and meet a condition, triggers conditional actions accurately and seamlessly " +
            "integrates into the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the specified element's text meeting a condition.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0015P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0015>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the length of a " +
            "specified element's text and meet a condition, triggers conditional actions accurately " +
            "and seamlessly integrates into the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the length of the specified element's text meeting a condition.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0016P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0016>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is visible, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the visibility of the specified element.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0017P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0017>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the page title and " +
            "meet a condition, triggers conditional actions accurately and seamlessly integrates " +
            "into the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the evaluation of the page title meeting a condition.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0018P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0018>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the page URL and meet " +
            "a condition, triggers conditional actions accurately and seamlessly integrates into " +
            "the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the evaluation of the page URL meeting a condition.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0019P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0019>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the count of windows " +
            "and meet a condition, triggers conditional actions accurately and seamlessly integrates " +
            "into the automation testing framework.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes conditional actions based on the evaluation of the window count meeting a condition.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0020P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html");

            // Invoking the test with the constructed test options
            Invoke<C0020>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if an alert exists, " +
            "accurately handles negative scenarios where an alert is expected not to exist, ensuring " +
            "that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where an alert is expected not to exist, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0021N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0021>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if an alert does not exist, " +
            "accurately handles negative scenarios where an alert is expected to exist, ensuring " +
            "that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified conditions are not met, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0022N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0022>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate certain conditions, " +
            "accurately handles negative scenarios where the conditions are not met, ensuring that " +
            "no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified conditions are not met, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0023N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "driverTypeName", value: "Chrome");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is active, accurately handles negative scenarios where the element is expected not to " +
            "be active, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is not active, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0024N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0024>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate a specified element's " +
            "attribute and meet a condition, accurately handles negative scenarios where the element's " +
            "attribute does not meet the specified condition, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element's attribute does not meet the specified condition, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0025N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0025>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the count of specified " +
            "elements and meet a condition, accurately handles negative scenarios where the elements " +
            "count does not meet the specified condition, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the count of specified elements does not meet the specified condition, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0026N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0026>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is disabled, accurately handles negative scenarios where the element is expected not " +
            "to be disabled, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is not disabled, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0027N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0027>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is enabled, accurately handles negative scenarios where the element is expected not " +
            "to be enabled, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is not enabled, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0028N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0028>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "exists, accurately handles negative scenarios where the element is expected not to " +
            "exist, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element does not exist, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0029N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                FailOnException = false,
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0029>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is not active, accurately handles negative scenarios where the element is expected to " +
            "be active, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is expected to be active, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0030N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0030>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "does not exist, accurately handles negative scenarios where the element is expected to " +
            "exist, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is expected to exist, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0031N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0031>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is not selected, accurately handles negative scenarios where the element is expected to " +
            "be selected, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is expected to be selected, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0032N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0032>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is not visible, accurately handles negative scenarios where the element is expected " +
            "to be visible, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is expected to be visible, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0033N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                FailOnException = false,
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0033>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is selected, accurately handles negative scenarios where the element is expected not " +
            "to be selected, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is not expected to be selected, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0034N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0034>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate a specified element's " +
            "text and meet a condition, accurately handles negative scenarios where the element's " +
            "text does not meet the specified condition, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element's text does not meet the specified condition, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0035N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0035>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate a specified element's " +
            "text length and meet a condition, accurately handles negative scenarios where the " +
            "element's text length does not meet the specified condition, ensuring that no actions are execute")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element's text does not meet the specified condition, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0036N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0036>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to check if a specified element " +
            "is visible, accurately handles negative scenarios where the element is expected not to " +
            "be visible, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the specified element is not expected to be visible, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0037N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0037>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the page title and " +
            "meet a condition, accurately handles negative scenarios where the page title does not " +
            "meet the specified condition, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the page title does not meet the specified condition, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0038N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0038>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the page URL and meet " +
            "a condition, accurately handles negative scenarios where the page URL does not meet the " +
            "specified condition, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the page URL does not meet the specified condition, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0039P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0039>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetCondition plugin, when configured to evaluate the count of open " +
            "windows and meet a condition, accurately handles negative scenarios where the count " +
            "of open windows does not meet the specified condition, ensuring that no actions are executed.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetCondition plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately handles scenarios where the count of open windows does not meet the specified condition, ensuring that no actions are executed.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: Test parameters are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during action execution.")]
        #endregion
        public void T0040N()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Conditions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0040>(testOptions);
        }
    }
}
