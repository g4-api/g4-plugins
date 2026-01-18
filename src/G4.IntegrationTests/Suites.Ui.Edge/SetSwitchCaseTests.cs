using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.SetSwitchCase;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SetSwitchCase")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to automate conditional actions based on switch‐case logic, so " +
        "that I can efficiently manage complex automation workflows with dynamic branching and default handling.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Integration: The SetSwitchCase plugin seamlessly integrates into the G4™ ecosystem, allowing users to incorporate switch‐case logic without extensive setup requirements.")]
    [AcceptanceCriteria(criteria: "Conditional Branching: The plugin effectively evaluates element values, attributes, or provided arguments and triggers the correct branch.")]
    [AcceptanceCriteria(criteria: "Parameter Registration: The plugin correctly registers parameters (e.g., TestParameter and TestResult) within the session context for downstream use.")]
    [AcceptanceCriteria(criteria: "Regular Expression Support: The plugin supports regex matching on element values or attributes, including case‐insensitive evaluation when the IgnoreCase flag is set.")]
    [AcceptanceCriteria(criteria: "Default Branch Handling: The plugin selects the Default branch when no explicit case matches the evaluated value.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to manage unexpected issues during switch evaluation and branch execution.")]
    #endregion
    public class SetSwitchCaseTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that " +
            "the SetSwitchCase plugin correctly assigns TestResult based on a randomly generated TestParameter.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetSwitchCase plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Conditional Branching: The plugin accurately assigns TestResult based on the value of TestParameter.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: TestParameter and TestResult are correctly registered within the plugin.")]
        [AcceptanceCriteria(criteria: "Assertion Validation: The Assert action verifies that TestResult equals TestParameter.")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that " +
            "the SetSwitchCase plugin correctly selects a branch based on an element’s text and sets TestResult to 3.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetSwitchCase plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Conditional Branching: The plugin accurately selects the branch when the element text matches \"ElementText\".")]
        [AcceptanceCriteria(criteria: "Parameter Registration: TestResult is correctly registered within the plugin session.")]
        [AcceptanceCriteria(criteria: "Assertion Validation: The Assert action verifies that TestResult equals 3.")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SetSwitchCase plugin correctly selects a branch based on the onclick attribute of the input element and sets TestResult to 3.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetSwitchCase plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Conditional Branching: The plugin accurately selects the branch when the onclick attribute matches \"setStaleElement()\".")]
        [AcceptanceCriteria(criteria: "Parameter Registration: TestResult is correctly registered within the plugin session.")]
        [AcceptanceCriteria(criteria: "Assertion Validation: The Assert action verifies that TestResult equals 3.")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SetSwitchCase plugin correctly matches the onclick attribute against the RegularExpression \"([A-Z])\\w+\" and " +
            "selects the 'StaleElement' branch, sets TestResult to 3.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetSwitchCase plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Regular Expression Matching: The plugin accurately applies the RegularExpression \"([A-Z])\\w+\" on the onclick attribute and selects the 'StaleElement' branch.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: TestResult is correctly registered within the plugin session.")]
        [AcceptanceCriteria(criteria: "Assertion Validation: The Assert action verifies that TestResult equals 3.")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SetSwitchCase plugin correctly applies ignore-case regex matching on the onclick attribute and selects the 'staleelement' " +
            "branch, setting TestResult to 3.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetSwitchCase plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Ignore-Case Matching: The plugin accurately applies case-insensitive regex matching \"([A-Z])\\w+\" on the onclick attribute and matches 'staleelement'.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: TestResult is correctly registered within the plugin session.")]
        [AcceptanceCriteria(criteria: "Assertion Validation: The Assert action verifies that TestResult equals 3.")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SetSwitchCase plugin correctly uses the SwitchOn argument to set TestResult based on the randomly generated " +
            "TestParameter.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetSwitchCase plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "SwitchOn Evaluation: The plugin accurately uses the SwitchOn argument to select the branch matching the TestParameter value.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: TestParameter and TestResult are correctly registered within the plugin session.")]
        [AcceptanceCriteria(criteria: "Assertion Validation: The Assert action verifies that TestResult equals TestParameter.")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SetSwitchCase plugin correctly selects the Default branch when TestParameter is outside defined " +
            "cases (5–10) and sets TestResult to 5.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetSwitchCase plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Default Branch Handling: The plugin accurately selects the Default branch when TestParameter does not match any explicit case.")]
        [AcceptanceCriteria(criteria: "Parameter Registration: TestParameter and TestResult are correctly registered within the plugin session.")]
        [AcceptanceCriteria(criteria: "Assertion Validation: The Assert action verifies that TestResult equals 5.")]
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
    }
}
