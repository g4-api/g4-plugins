using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.CloseBrowser;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("CloseBrowser")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to close browser windows programmatically, so that I can " +
        "ensure proper cleanup and resource management in my UI automation tasks.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin must be easily accessible within the G4™ ecosystem, allowing seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Browser Closing Functionality: The plugin must be capable of closing browser windows, ensuring proper cleanup and release of resources.")]
    [AcceptanceCriteria(criteria: "Compatibility: The plugin must work consistently across different browser environments and configurations.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms must be implemented to handle scenarios such as unexpected browser behavior and runtime exceptions, ensuring stability and resilience in automation workflows.")]
    [AcceptanceCriteria(criteria: "Verification: The plugin must provide a way to verify that the browser window has been closed and that specific elements no longer exist on the page.")]
    #endregion
    public class CloseBrowserTests : TestBase
    {
        [TestMethod(DisplayName = "Verify the closing of the browser window using the 'CloseBrowser' plugin " +
            "after maximizing the browser window. Additionally, confirm that the element with the ID 'ClickButtonOutcome' " +
            "does not exist using CSS selector.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CloseBrowser plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Close Action: When the plugin is invoked, it successfully closes the browser window.")]
        [AcceptanceCriteria(criteria: "Element Verification: The element with ID 'ClickButtonOutcome' does not exist after the browser window is closed.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any unexpected issues or failures during the browser closing process, ensuring stability and reliability.")]
        #endregion
        #region *** Data     ***
        [DataRow("CloseBrowser")]
        [DataRow("closeBrowser")]
        [DataRow("CloseSession")]
        [DataRow("closeSession")]
        [DataRow("QuitSession")]
        [DataRow("quitSession")]
        #endregion
        public void T0001P(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName)
                .AddContextParameter(key: "SkipCloseBrowser", value: true);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment)
            {
                FailOnException = false,
                Negative = true
            };

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
