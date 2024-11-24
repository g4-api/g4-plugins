using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.HideKeyboard;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Android
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MobileNative")]
    [TestCategory("Android")]
    [TestCategory("HideSoftKeyboard")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to hide the soft keyboard on a mobile device, So that " +
        "I can interact with elements underneath the keyboard and ensure smooth automation of mobile applications.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The HideSoftKeyboard plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Soft Keyboard Hiding Functionality: The plugin effectively hides the soft keyboard on a mobile device, allowing users to interact with elements underneath the keyboard during automation tasks.")]
    [AcceptanceCriteria(criteria: "Customization Options: The plugin provides users with options to customize the keyboard hiding behavior, such as specifying the hiding strategy or using different key codes.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during soft keyboard hiding operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class HideSoftKeyboardTests : TestBase
    {
        [TestCategory("MobileWeb")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the HideKeyboard plugin correctly hides the soft keyboard on the UI.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The HideKeyboard plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "UI Interaction: The plugin invokes a click action on the specified UI element with id 'SendKeys'.")]
        [AcceptanceCriteria(criteria: "Initial Keyboard State Verification: The plugin asserts that the keyboard is not visible initially.")]
        [AcceptanceCriteria(criteria: "Hiding Keyboard: The plugin successfully hides the soft keyboard upon invoking the 'HideSoftKeyboard' action.")]
        [AcceptanceCriteria(criteria: "Final Keyboard State Verification: The plugin asserts that the keyboard is not visible after hiding.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the process, the automation script captures and handles the errors gracefully.")]
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

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the HideKeyboard plugin correctly hides the soft keyboard on the UI using " +
            "different strategies.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The HideKeyboard plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "UI Interaction: The plugin invokes a click action on the specified mobile element with resource id 'org.wikipedia.alpha:id/search_container'.")]
        [AcceptanceCriteria(criteria: "Initial Keyboard State Verification: The plugin asserts that the keyboard is not visible initially.")]
        [AcceptanceCriteria(criteria: "Hiding Keyboard: The plugin successfully hides the soft keyboard using the specified strategy upon invoking the 'HideSoftKeyboard' action.")]
        [AcceptanceCriteria(criteria: "Final Keyboard State Verification: The plugin asserts that the keyboard is not visible after hiding.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0", "swipeDown")]
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0", "tapOut")]
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0", "tapOutside")]
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0", "default")]
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0", null)]
        #endregion
        public void T0002(string appiumVersion, string device, string platformVersion, string strategy)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "appiumVersion", value: appiumVersion)
                .AddTestParameter(key: "device", value: device)
                .AddTestParameter(key: "platformVersion", value: platformVersion)
                .AddTestParameter(key: "strategy", value: strategy);

            // Creating test options.
            var testOptions = new AndroidTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the HideKeyboard plugin correctly hides the soft keyboard on the UI by " +
            "pressing a specified key code.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The HideKeyboard plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "UI Interaction: The plugin invokes a click action on the specified mobile element with resource id 'org.wikipedia.alpha:id/search_container'.")]
        [AcceptanceCriteria(criteria: "Initial Keyboard State Verification: The plugin asserts that the keyboard is not visible initially.")]
        [AcceptanceCriteria(criteria: "Hiding Keyboard: The plugin successfully hides the soft keyboard by pressing the specified key code upon invoking the 'HideSoftKeyboard' action.")]
        [AcceptanceCriteria(criteria: "Final Keyboard State Verification: The plugin asserts that the keyboard is not visible after hiding.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0")]
        #endregion
        public void T0003(string appiumVersion, string device, string platformVersion)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "appiumVersion", value: appiumVersion)
                .AddTestParameter(key: "device", value: device)
                .AddTestParameter(key: "platformVersion", value: platformVersion)
                .AddTestParameter(key: "keyCode", value: "4");

            // Creating test options.
            var testOptions = new AndroidTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0003>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the HideKeyboard plugin correctly hides the soft keyboard on the UI by " +
            "pressing a specified key name.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The HideKeyboard plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "UI Interaction: The plugin invokes a click action on the specified mobile element with resource id 'org.wikipedia.alpha:id/search_container'.")]
        [AcceptanceCriteria(criteria: "Initial Keyboard State Verification: The plugin asserts that the keyboard is not visible initially.")]
        [AcceptanceCriteria(criteria: "Hiding Keyboard: The plugin successfully hides the soft keyboard by pressing the specified key name upon invoking the 'HideSoftKeyboard' action.")]
        [AcceptanceCriteria(criteria: "Final Keyboard State Verification: The plugin asserts that the keyboard is not visible after hiding.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0")]
        #endregion
        public void T0004(string appiumVersion, string device, string platformVersion)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "appiumVersion", value: appiumVersion)
                .AddTestParameter(key: "device", value: device)
                .AddTestParameter(key: "platformVersion", value: platformVersion)
                .AddTestParameter(key: "keyName", value: "Back");

            // Creating test options.
            var testOptions = new AndroidTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0004>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the HideKeyboard plugin correctly hides the soft keyboard on the UI by " +
            "pressing a specified key.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The HideKeyboard plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "UI Interaction: The plugin invokes a click action on the specified mobile element with resource id 'org.wikipedia.alpha:id/search_container'.")]
        [AcceptanceCriteria(criteria: "Initial Keyboard State Verification: The plugin asserts that the keyboard is not visible initially.")]
        [AcceptanceCriteria(criteria: "Hiding Keyboard: The plugin successfully hides the soft keyboard by pressing the specified key upon invoking the 'HideSoftKeyboard' action.")]
        [AcceptanceCriteria(criteria: "Final Keyboard State Verification: The plugin asserts that the keyboard is not visible after hiding.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("2.0.1", "Samsung Galaxy S20", "10.0")]
        #endregion
        public void T0005(string appiumVersion, string device, string platformVersion)
        {
            // Create a new automation environment with test parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "appiumVersion", value: appiumVersion)
                .AddTestParameter(key: "device", value: device)
                .AddTestParameter(key: "platformVersion", value: platformVersion)
                .AddTestParameter(key: "key", value: "Back");

            // Creating test options.
            var testOptions = new AndroidTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0005>(testOptions);
        }
    }
}
