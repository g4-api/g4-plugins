using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.ResolveOnlineFile;

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
    public class ResolveOnlineFileTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SelectOption plugin, when invoked to select an option by its 0-based " +
            "index, accurately chooses the desired option from a dropdown menu.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SelectOption plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with the 'OnAttribute' set to 'Index' with '1' as 'Argument', the plugin selects the option at the 0-based index 1 from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Selection Accuracy: The option at the specified index (0-based index 1) is accurately chosen from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Validation Process: The selected option undergoes validation to confirm its correctness and alignment with the specified parameters.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles exceptions such as invalid inputs or unavailable options, ensuring stability and reliability in automation workflows.")]
        #endregion
        public void T0001()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: "1")
                .AddTestParameter(key: "attribute", value: "Index")
                .AddTestParameter(key: "expected", value: "option2");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Downloads.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SelectOption plugin, when invoked to select an option by its 0-based " +
            "index, accurately chooses the desired option from a dropdown menu.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SelectOption plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with the 'OnAttribute' set to 'Index' with '1' as 'Argument', the plugin selects the option at the 0-based index 1 from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Selection Accuracy: The option at the specified index (0-based index 1) is accurately chosen from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Validation Process: The selected option undergoes validation to confirm its correctness and alignment with the specified parameters.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles exceptions such as invalid inputs or unavailable options, ensuring stability and reliability in automation workflows.")]
        #endregion
        public void T0002()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: "1")
                .AddTestParameter(key: "attribute", value: "Index")
                .AddTestParameter(key: "expected", value: "option2");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Downloads.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SelectOption plugin, when invoked to select an option by its 0-based " +
            "index, accurately chooses the desired option from a dropdown menu.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SelectOption plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with the 'OnAttribute' set to 'Index' with '1' as 'Argument', the plugin selects the option at the 0-based index 1 from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Selection Accuracy: The option at the specified index (0-based index 1) is accurately chosen from the dropdown menu.")]
        [AcceptanceCriteria(criteria: "Validation Process: The selected option undergoes validation to confirm its correctness and alignment with the specified parameters.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles exceptions such as invalid inputs or unavailable options, ensuring stability and reliability in automation workflows.")]
        #endregion
        public void T0003()
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: "1")
                .AddTestParameter(key: "attribute", value: "Index")
                .AddTestParameter(key: "expected", value: "option2");

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Downloads.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }
    }
}
