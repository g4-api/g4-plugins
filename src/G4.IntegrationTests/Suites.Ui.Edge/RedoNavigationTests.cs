using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.RedoNavigation;
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
    [TestCategory("RedoNavigation")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to easily redo navigation actions in applications, So that " +
        "I can efficiently manage navigation flows and handle unexpected scenarios during UI automation tasks.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The RedoNavigation plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Navigation Redo Functionality: The plugin effectively performs the navigation redo action, allowing users to reapply the previous navigation action during UI automation tasks.")]
    [AcceptanceCriteria(criteria: "Repeat Parameter: The plugin supports a 'repeat' parameter, enabling users to specify the number of times the navigation redo action is performed, providing flexibility in handling repetitive tasks.")]
    [AcceptanceCriteria(criteria: "Delay Parameter: The plugin includes a 'delay' parameter, allowing users to specify a time interval between each navigation redo action, facilitating controlled execution and avoiding overwhelming the application.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during navigation redo actions, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class RedoNavigationTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the RedoNavigation plugin, when used to redo a navigation action, correctly " +
            "restores the page URL to the state prior to the undo action.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The RedoNavigation plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Navigation Redo: When the RedoNavigation plugin is invoked after an undo action, it restores the page URL to its state prior to the undo action.")]
        [AcceptanceCriteria(criteria: "URL State Validation: The restored page URL is validated to ensure it matches the state before the undo action.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations of RedoNavigation with the same undo action produce consistent results.")]
        [AcceptanceCriteria(criteria: "Error Handling: The RedoNavigation plugin gracefully handles unexpected errors and exceptions.")]
        #endregion
        public void T0001P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the RedoNavigation plugin, when used to redo multiple navigation actions, " +
            "correctly restores the page URL to its state prior to the undo actions.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The RedoNavigation plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Navigation Redo: When the RedoNavigation plugin is invoked after undoing multiple navigation actions, it restores the page URL to its state prior to the undo actions.")]
        [AcceptanceCriteria(criteria: "URL State Validation: The restored page URL is validated to ensure it matches the state before the undo actions.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations of RedoNavigation with the same undo actions produce consistent results.")]
        [AcceptanceCriteria(criteria: "Error Handling: The RedoNavigation plugin gracefully handles unexpected errors and exceptions.")]
        #endregion
        public void T0002P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the RedoNavigation plugin, when used to redo multiple navigation actions " +
            "specified with a repeat parameter, correctly restores the page URL to its state prior " +
            "to the undo actions.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The RedoNavigation plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Navigation Redo: When the RedoNavigation plugin is invoked after undoing multiple navigation actions specified with a repeat parameter, it restores the page URL to its state prior to the undo actions.")]
        [AcceptanceCriteria(criteria: "URL State Validation: The restored page URL is validated to ensure it matches the state before the undo actions.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations of RedoNavigation with the same undo actions and repeat parameter produce consistent results.")]
        [AcceptanceCriteria(criteria: "Error Handling: The RedoNavigation plugin gracefully handles unexpected errors and exceptions.")]
        #endregion
        public void T0003P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the RedoNavigation plugin, when used to redo multiple navigation actions " +
            "specified with a repeat parameter and delay, correctly restores the page URL to its " +
            "state prior to the undo actions with the specified delay between actions.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The RedoNavigation plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Navigation Redo: When the RedoNavigation plugin is invoked after undoing multiple navigation actions specified with a repeat parameter and delay, it restores the page URL to its state prior to the undo actions with the specified delay between actions.")]
        [AcceptanceCriteria(criteria: "Delay Handling: The RedoNavigation plugin correctly applies the specified delay between each navigation action.")]
        [AcceptanceCriteria(criteria: "URL State Validation: The restored page URL is validated to ensure it matches the state before the undo actions.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations of RedoNavigation with the same undo actions, repeat parameter, and delay produce consistent results.")]
        [AcceptanceCriteria(criteria: "Error Handling: The RedoNavigation plugin gracefully handles unexpected errors and exceptions.")]
        #endregion
        public void T0004P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0004>(testOptions);

            // Filter performance points by plugin name "RedoNavigation".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("RedoNavigation");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime > 3 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the RedoNavigation plugin, when used to redo multiple navigation actions " +
            "specified with a repeat parameter and delay, correctly restores the page URL to its " +
            "state prior to the undo actions with the specified delay between actions.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The RedoNavigation plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Navigation Redo: When the RedoNavigation plugin is invoked after undoing multiple navigation actions specified with a repeat parameter and delay, it restores the page URL to its state prior to the undo actions with the specified delay between actions.")]
        [AcceptanceCriteria(criteria: "Delay Handling: The RedoNavigation plugin correctly applies the specified delay between each navigation action provided as a TimeSpan formatted string.")]
        [AcceptanceCriteria(criteria: "URL State Validation: The restored page URL is validated to ensure it matches the state before the undo actions.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations of RedoNavigation with the same undo actions, repeat parameter, and delay produce consistent results.")]
        [AcceptanceCriteria(criteria: "Error Handling: The RedoNavigation plugin gracefully handles unexpected errors and exceptions.")]
        #endregion
        public void T0005P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0005>(testOptions);

            // Filter performance points by plugin name "RedoNavigation".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("RedoNavigation");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime > 3 * TimeSpan.TicksPerSecond));
        }
    }
}
