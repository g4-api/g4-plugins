/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.AssertKeyboardVisible;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Android
{
    /// <summary>
    /// Test class for testing the behavior of KeyboardVisible plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MobileWeb")]
    [TestCategory("Android")]
    [TestCategory("KeyboardVisible")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to assert the visibility of the on-screen keyboard on " +
        "a mobile device, So that I can verify the visibility state of the keyboard and ensure smooth interaction with " +
        "mobile applications.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The KeyboardVisible plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Keyboard Visibility Assertion: The plugin effectively asserts the visibility of the on-screen keyboard on a mobile device, allowing users to verify the visibility state of the keyboard during automation tasks.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during keyboard visibility assertion operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class AssertKeyboardVisibleTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the AssertKeyboardVisible plugin correctly identifies when the keyboard " +
            "is visible on the UI.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The AssertKeyboardVisible plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "UI Interaction: The plugin invokes a click action on the specified UI element with id 'SendKeys'.")]
        [AcceptanceCriteria(criteria: "Keyboard Visibility Detection: The plugin accurately detects and asserts that the keyboard is visible on the UI.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the detection process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0")]
        #endregion
        public void T0001(string appiumVersion, string device, string platformVersion)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "appiumVersion", value: appiumVersion)
                .AddTestParameter(key: "device", value: device)
                .AddTestParameter(key: "platformVersion", value: platformVersion);

            // Creating test options.
            var testOptions = new AndroidTestOptions(environment, sut: "ElementInteractions.html")
            {
                WebTest = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0001>(testOptions);
        }

        [TestCategory("Negative")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the AssertKeyboardVisible plugin correctly identifies when the keyboard " +
            "is not visible on the UI.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The AssertKeyboardVisible plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "UI Interaction: The plugin invokes a click action on the specified UI element with id 'SendKeys'.")]
        [AcceptanceCriteria(criteria: "Negative Assertion: The plugin accurately detects and asserts that the keyboard is not visible on the UI.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the detection process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0")]
        #endregion
        public void T0002(string appiumVersion, string device, string platformVersion)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "appiumVersion", value: appiumVersion)
                .AddTestParameter(key: "device", value: device)
                .AddTestParameter(key: "platformVersion", value: platformVersion);

            // Creating test options.
            var testOptions = new AndroidTestOptions(environment, sut: "ElementInteractions.html")
            {
                Negative = true
            };

            // Invoking the test with the constructed test options.
            Invoke<C0002>(testOptions);
        }
    }
}
