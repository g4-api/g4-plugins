using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.OpenUrl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("OpenUrl")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that can open URLs based on specified conditions, " +
        "So that I can enhance the flexibility of my automation workflows and integrate external web content seamlessly.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The OpenUrl plugin should integrate smoothly into the G4™ ecosystem, ensuring easy accessibility for automation developers without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "URL Opening: The plugin must effectively open URLs specified in various HTML attributes, allowing automation engineers to navigate to different web resources.")]
    [AcceptanceCriteria(criteria: "Argument Handling: Users have the ability to specify URL matching conditions flexibly, supporting various patterns and regular expressions for enhanced customization.")]
    [AcceptanceCriteria(criteria: "Error Management: The plugin handles exceptions gracefully during URL navigation, logging errors appropriately for debugging purposes and ensuring the stability of automation workflows.")]
    #endregion
    public class OpenUrlTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the OpenUrl plugin can assert the page URL " +
            "matches the expected value in ExportData.html")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "URL Matching: The OpenUrl plugin must correctly assert that the page URL matches the expected pattern in ExportData.html.")]
        [AcceptanceCriteria(criteria: "Integration: The plugin must seamlessly integrate into the existing automation framework and perform the URL assertion without errors.")]
        #endregion
        public void T0001P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl plugin can open the URL from " +
            "the 'src' attribute of the image with alt text 'ImageA' and assert the page URL")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "URL Opening: The OpenUrl plugin must correctly open the URL specified in the 'src' attribute of the image element with alt text 'ImageA'.")]
        [AcceptanceCriteria(criteria: "URL Matching: The plugin must correctly assert that the page URL matches the expected pattern after navigation.")]
        [AcceptanceCriteria(criteria: "Integration: The plugin must seamlessly integrate into the existing automation framework and perform the URL opening and assertion without errors.")]
        #endregion
        public void T0002P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(DisplayName = "Verify that the OpenUrl plugin can open the URL matching " +
            "the regular expression in the paragraph containing 'Image A' and assert the page URL")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "URL Opening: The OpenUrl plugin must correctly open the URL matching the regular expression in the paragraph element containing the text 'Image A'.")]
        [AcceptanceCriteria(criteria: "URL Matching: The plugin must correctly assert that the page URL matches the expected pattern after navigation.")]
        [AcceptanceCriteria(criteria: "Integration: The plugin must seamlessly integrate into the existing automation framework and perform the URL opening and assertion without errors.")]
        #endregion
        public void T0003P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }
    }
}
