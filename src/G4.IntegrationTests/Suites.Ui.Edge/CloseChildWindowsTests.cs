using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.CloseChildWindows;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("CloseChildWindows")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to close all child windows except the main window, So " +
        "that I can maintain a clean and organized testing environment during automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The CloseChildWindows plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Window Closing Functionality: The plugin effectively closes all child windows except the main window, ensuring a clean testing environment and improving automation workflow management.")]
    [AcceptanceCriteria(criteria: "Customization Options: The plugin allows users to specify the number of child windows to close using the Argument property, providing flexibility and adaptability to different automation scenarios.")]
    [AcceptanceCriteria(criteria: "Delay Between Window Closures: The plugin includes a small delay between window closures to prevent potential issues and ensure smooth execution of automation tasks.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during window closing operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class CloseChildWindowsTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the CloseChildWindows plugin, when configured to close a specific number " +
            "of child windows, correctly handles the window count.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CloseChildWindows plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Windows Closing: The plugin successfully closes the specified number of child windows.")]
        [AcceptanceCriteria(criteria: "Window Count Verification: The automation script verifies that the count of windows after closing is equal to the expected value.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("1", null)]
        [DataRow("4", "0")]
        [DataRow("2", "2")]
        [DataRow("1", "NotNumber")]
        [DataRow("1", "5")]
        [DataRow("4", "-5")]
        #endregion
        public void T0001P(string expected, string argument)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", argument)
                .AddTestParameter(key: "expected", value: expected);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment)
            {
                FailOnException = false
            };

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
