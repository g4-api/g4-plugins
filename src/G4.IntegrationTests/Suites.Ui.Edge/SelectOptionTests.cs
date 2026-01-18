using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SelectOption;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SelectOption")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to select options from dropdown menus easily, So that " +
        "I can automate the selection process and enhance the efficiency of my automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin must be easily accessible within the G4™ platform's ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Option Selection: The plugin must be capable of selecting options from dropdown menus based on index, value, partial text, or exact text, providing flexibility for different automation scenarios.")]
    [AcceptanceCriteria(criteria: "Parameter Customization: Users have the flexibility to customize parameters such as the selection criteria and the option value or text to select, enabling precise control over the selection process.")]
    [AcceptanceCriteria(criteria: "Integration: The plugin seamlessly integrates with the existing G4™ automation framework, allowing users to incorporate option selection functionalities into their automation scripts with ease.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage exceptions such as invalid inputs, unavailable options, or unexpected scenarios, ensuring the stability and reliability of automation workflows.")]
    #endregion
    public class SelectOptionTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SelectOption plugin, when invoked to select an option by its 0-based " +
            "index, accurately chooses the desired option from a dropdown menu.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SelectOption plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with the 'OnAttribute' set to 'Index' with '1' as 'Argument', the plugin selects the option at the 0-based index 1 from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Selection Accuracy: The option at the specified index (0-based index 1) is accurately chosen from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Validation Process: The selected option undergoes validation to confirm its correctness and alignment with the specified parameters.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles exceptions such as invalid inputs or unavailable options, ensuring stability and reliability in automation workflows.")]
        #endregion
        public void T0001A()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: "1")
                .AddTestParameter(key: "attribute", value: "Index")
                .AddTestParameter(key: "expected", value: "option2");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SelectOption plugin, when invoked to select an option by its value, " +
            "accurately chooses the desired option from a dropdown menu.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SelectOption plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with the 'OnAttribute' set to 'Value', the plugin selects the option with the specified value from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Selection Accuracy: The option with the specified value ('Value') is accurately chosen from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Validation Process: The selected option undergoes validation to confirm its correctness and alignment with the specified parameters.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles exceptions such as invalid inputs or unavailable options, ensuring stability and reliability in automation workflows.")]
        #endregion
        public void T0001B()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: "option2")
                .AddTestParameter(key: "attribute", value: "Value")
                .AddTestParameter(key: "expected", value: "option2");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SelectOption plugin, when invoked to select an option by partial text, " +
            "accurately chooses the desired option from a dropdown menu.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SelectOption plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with the 'OnAttribute' set to 'PartialText', the plugin selects the option containing the specified partial text from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Selection Accuracy: The option containing the specified partial text ('PartialText') is accurately chosen from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Validation Process: The selected option undergoes validation to confirm its correctness and alignment with the specified parameters.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles exceptions such as invalid inputs or unavailable options, ensuring stability and reliability in automation workflows.")]
        #endregion
        public void T0001C()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: "2")
                .AddTestParameter(key: "attribute", value: "PartialText")
                .AddTestParameter(key: "expected", value: "option2");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SelectOption plugin, when invoked without specifying the OnAttribute " +
            "property, accurately chooses the desired option from a dropdown menu based on exact text match.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SelectOption plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When not provided with the OnAttribute property, the plugin selects the option with exact text matching the specified argument from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Selection Accuracy: The option with exact text matching the specified argument is accurately chosen from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Validation Process: The selected option undergoes validation to confirm its correctness and alignment with the specified parameters.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles exceptions such as invalid inputs or unavailable options, ensuring stability and reliability in automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("", "Option 2", "option2")]
        [DataRow(null, "Option 2", "option2")]
        #endregion
        public void T0001P(string attribute, string argument, string expected)
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: argument)
                .AddTestParameter(key: "attribute", value: attribute)
                .AddTestParameter(key: "expected", value: expected);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
