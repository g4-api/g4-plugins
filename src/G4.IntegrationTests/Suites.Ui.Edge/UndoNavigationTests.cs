using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.UndoNavigation;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("UndoNavigation")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to easily undo navigation actions in applications, So that " +
        "I can efficiently manage navigation flows and handle unexpected scenarios during UI automation tasks.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The UndoNavigation plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Navigation Undo Functionality: The plugin effectively performs the navigation undo action, allowing users to revert to the previous page or state during UI automation tasks.")]
    [AcceptanceCriteria(criteria: "Repeat Parameter: The plugin supports a 'repeat' parameter, enabling users to specify the number of times the navigation undo action is performed, providing flexibility in handling repetitive tasks.")]
    [AcceptanceCriteria(criteria: "Delay Parameter: The plugin includes a 'delay' parameter, allowing users to specify a time interval between each navigation undo action, facilitating controlled execution and avoiding overwhelming the application.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during navigation undo actions, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class UndoNavigationTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UndoNavigation plugin, when used to navigate back to the previous page, " +
            "correctly undoes the navigation to a specific URL.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UndoNavigation plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "OpenUrl Action: The plugin successfully opens the URL obtained from Get-PageUrl with '?Page=1' appended.")]
        [AcceptanceCriteria(criteria: "Page URL Assertion: The plugin asserts that the page URL matches the regular expression '(?i).*page=1$'.")]
        [AcceptanceCriteria(criteria: "NavigateBack Action: The plugin navigates back to the previous page.")]
        [AcceptanceCriteria(criteria: "Page URL Assertion after Navigation: The plugin asserts that the page URL does not contain 'page=1'.")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UndoNavigation plugin, when used to navigate back multiple steps, " +
            "correctly undoes the navigation to previous pages.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UndoNavigation plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "OpenUrl Actions: The plugin successfully opens URLs obtained from Get-PageUrl with '?Page=' appended for pages 1, 2, and 3.")]
        [AcceptanceCriteria(criteria: "Page URL Assertions: The plugin asserts that the page URLs match the regular expressions '(?i).*page=1$', '(?i).*page=2$', and '(?i).*page=3$' respectively.")]
        [AcceptanceCriteria(criteria: "NavigateBack Action: The plugin navigates back 3 steps.")]
        [AcceptanceCriteria(criteria: "Page URL Assertion after Navigation: The plugin asserts that the page URL does not contain 'page=1', 'page=2', or 'page=3'.")]
        #endregion
        public void T0002P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UndoNavigation plugin, when used to navigate back multiple steps with " +
            "repetition specified by the Repeat parameter, correctly undoes the navigation to previous pages.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UndoNavigation plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "OpenUrl Actions: The plugin successfully opens URLs obtained from Get-PageUrl with '?Page=' appended for pages 1, 2, and 3.")]
        [AcceptanceCriteria(criteria: "Page URL Assertions: The plugin asserts that the page URLs match the regular expressions '(?i).*page=1$', '(?i).*page=2$', and '(?i).*page=3$' respectively.")]
        [AcceptanceCriteria(criteria: "NavigateBack Action with Repetition: The plugin navigates back 3 steps as specified by the Repeat parameter.")]
        [AcceptanceCriteria(criteria: "Page URL Assertion after Navigation: The plugin asserts that the page URL does not contain 'page=1', 'page=2', or 'page=3'.")]
        #endregion
        public void T0003P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UndoNavigation plugin, when used to navigate back multiple steps with " +
            "repetition specified by the Repeat parameter and a delay between steps specified by the " +
            "Delay parameter, correctly undoes the navigation to previous pages.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UndoNavigation plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "OpenUrl Actions: The plugin successfully opens URLs obtained from Get-PageUrl with '?Page=' appended for pages 1, 2, and 3.")]
        [AcceptanceCriteria(criteria: "Page URL Assertions: The plugin asserts that the page URLs match the regular expressions '(?i).*page=1$', '(?i).*page=2$', and '(?i).*page=3$' respectively.")]
        [AcceptanceCriteria(criteria: "NavigateBack Action with Repetition and Delay: The plugin navigates back 3 steps with a delay of 1000 milliseconds between each step as specified by the Repeat and Delay parameters.")]
        [AcceptanceCriteria(criteria: "Page URL Assertion after Navigation: The plugin asserts that the page URL does not contain 'page=1', 'page=2', or 'page=3'.")]
        #endregion
        public void T0004P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options.
            var response = Invoke<C0004>(testOptions);

            // Filter performance points by plugin name "UndoNavigation".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("UndoNavigation");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime > 3 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UndoNavigation plugin, when used to navigate back multiple steps with " +
            "repetition specified by the Repeat parameter and a delay between steps specified by " +
            "the Delay parameter in the format 'HH:mm:ss', correctly undoes the navigation to previous pages.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UndoNavigation plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "OpenUrl Actions: The plugin successfully opens URLs obtained from Get-PageUrl with '?Page=' appended for pages 1, 2, and 3.")]
        [AcceptanceCriteria(criteria: "Page URL Assertions: The plugin asserts that the page URLs match the regular expressions '(?i).*page=1$', '(?i).*page=2$', and '(?i).*page=3$' respectively.")]
        [AcceptanceCriteria(criteria: "NavigateBack Action with Repetition and Delay: The plugin navigates back 3 steps with a delay of 1 second between each step as specified by the Repeat and Delay parameters.")]
        [AcceptanceCriteria(criteria: "Page URL Assertion after Navigation: The plugin asserts that the page URL does not contain 'page=1', 'page=2', or 'page=3'.")]
        #endregion
        public void T0005P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options.
            var response = Invoke<C0005>(testOptions);

            // Filter performance points by plugin name "UndoNavigation".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("UndoNavigation");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime > 3 * TimeSpan.TicksPerSecond));
        }
    }
}
