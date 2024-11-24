using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SetFocus;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SetFocus")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to set focus to UI elements effortlessly, So that I " +
        "can enhance the efficiency and reliability of user interactions within my automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The SetFocus plugin must be easily accessible within the G4™ platform's ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "UI Element Focus: The plugin effectively sets focus to UI elements specified by automation rules, facilitating smooth navigation and interaction within applications.")]
    [AcceptanceCriteria(criteria: "Flexibility: Users have the flexibility to configure the SetFocus plugin for different WebDriver instances and environment contexts, ensuring compatibility with diverse automation setups.")]
    [AcceptanceCriteria(criteria: "Error Handling: The SetFocus plugin includes robust error handling mechanisms to manage unexpected issues during focus setting, ensuring smooth execution of automation tasks.")]
    #endregion
    public class SetFocusTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SetFocus plugin, when invoked on a specific UI element, successfully " +
            "sets focus to that element, enhancing the efficiency and reliability of UI interactions " +
            "in automated testing scenarios.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SetFocus plugin seamlessly integrates into the G4™ automation framework.")]
        [AcceptanceCriteria(criteria: "UI Element Focus: When invoked on the specified UI element, the SetFocus plugin effectively sets focus, facilitating smooth navigation and interaction within applications.")]
        [AcceptanceCriteria(criteria: "Flexibility: Users have the flexibility to configure the SetFocus plugin for different WebDriver instances and environment contexts, ensuring compatibility with diverse automation setups.")]
        [AcceptanceCriteria(criteria: "Error Handling: The SetFocus plugin includes robust error handling mechanisms to manage unexpected issues during focus setting, ensuring smooth execution of automation tasks.")]
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
    }
}
