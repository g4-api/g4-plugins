using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.InvokeScroll;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("InvokeScroll")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to scroll to specific elements or positions on a web " +
        "page using various scroll options, so that I can easily navigate through web pages and interact with elements " +
        "that are not immediately visible on the screen.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The InvokeScroll plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Element Scrolling: The plugin should allow scrolling to specific elements on a web page, supporting both vertical and horizontal scrolling.")]
    [AcceptanceCriteria(criteria: "Page Scrolling: The plugin should support scrolling the entire page, enabling navigation to specific coordinates or sections of the webpage.")]
    [AcceptanceCriteria(criteria: "Scroll Behavior Customization: The plugin should allow customization of scroll behavior, including options for smooth scrolling and instant scrolling.")]
    [AcceptanceCriteria(criteria: "Scrolling Offset: The plugin should support scrolling to specific coordinates on the page, allowing for precise positioning of the viewport.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during scrolling operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class InvokeScrollTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeScroll plugin correctly scrolls the page according to " +
            "the specified argument, and ensures that the page scroll left and top outcomes " +
            "match the expected values, considering different scroll behaviors (smooth, instant, or auto).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeScroll plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Page Scrolling: The plugin accurately scrolls the page according to the specified argument, considering different scroll behaviors (smooth, instant, or auto).")]
        [AcceptanceCriteria(criteria: "Left Attribute Assertion: The plugin asserts the equality of the left attribute to the specified value.")]
        [AcceptanceCriteria(criteria: "Top Attribute Assertion: The plugin asserts the equality of the top attribute to the specified value.")]
        [AcceptanceCriteria(criteria: "Behavior Handling: The plugin handles different scroll behaviors (smooth, instant, or auto) gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("0", "10", "{{$ --Top:10}}")]
        [DataRow("10", "0", "{{$ --Left:10}}")]
        [DataRow("0", "10", "{{$ --Top:10 --Behavior:smooth}}")]
        [DataRow("0", "10", "{{$ --Top:10 --Behavior:instant}}")]
        [DataRow("0", "10", "{{$ --Top:10 --Behavior:auto}}")]
        [DataRow("10", "0", "{{$ --Left:10 --Behavior:smooth}}")]
        [DataRow("10", "0", "{{$ --Left:10 --Behavior:instant}}")]
        [DataRow("10", "0", "{{$ --Left:10 --Behavior:auto}}")]
        [DataRow("10", "10", "{{$ --Top:10 --Left:10}}")]
        [DataRow("10", "10", "{{$ --Top:10 --Left:10 --Behavior:smooth}}")]
        [DataRow("10", "10", "{{$ --Top:10 --Left:10 --Behavior:instant}}")]
        [DataRow("10", "10", "{{$ --Top:10 --Left:10 --Behavior:auto}}")]
        #endregion
        public void T0001P(string left, string top, string argument)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: argument)
                .AddTestParameter(key: "left", value: left)
                .AddTestParameter(key: "top", value: top);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Scrolls.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeScroll plugin correctly scrolls the specified element " +
            "according to the specified argument, and ensures that the element scroll left " +
            "and top outcomes match the expected values, considering different scroll " +
            "behaviors (smooth, instant, or auto).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeScroll plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Element Scrolling: The plugin accurately scrolls the specified element according to the specified argument, considering different scroll behaviors (smooth, instant, or auto).")]
        [AcceptanceCriteria(criteria: "Left Attribute Assertion: The plugin asserts the equality of the left attribute of the specified element to the specified value.")]
        [AcceptanceCriteria(criteria: "Top Attribute Assertion: The plugin asserts the equality of the top attribute of the specified element to the specified value.")]
        [AcceptanceCriteria(criteria: "Behavior Handling: The plugin handles different scroll behaviors (smooth, instant, or auto) gracefully.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow("0", "10", "{{$ --Top:10}}")]
        [DataRow("10", "0", "{{$ --Left:10}}")]
        [DataRow("0", "10", "{{$ --Top:10 --Behavior:smooth}}")]
        [DataRow("0", "10", "{{$ --Top:10 --Behavior:instant}}")]
        [DataRow("0", "10", "{{$ --Top:10 --Behavior:auto}}")]
        [DataRow("10", "0", "{{$ --Left:10 --Behavior:smooth}}")]
        [DataRow("10", "0", "{{$ --Left:10 --Behavior:instant}}")]
        [DataRow("10", "0", "{{$ --Left:10 --Behavior:auto}}")]
        [DataRow("10", "10", "{{$ --Top:10 --Left:10}}")]
        [DataRow("10", "10", "{{$ --Top:10 --Left:10 --Behavior:smooth}}")]
        [DataRow("10", "10", "{{$ --Top:10 --Left:10 --Behavior:instant}}")]
        [DataRow("10", "10", "{{$ --Top:10 --Left:10 --Behavior:auto}}")]
        #endregion
        public void T0002P(string left, string top, string argument)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "argument", value: argument)
                .AddTestParameter(key: "left", value: left)
                .AddTestParameter(key: "top", value: top);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Scrolls.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }
    }
}
