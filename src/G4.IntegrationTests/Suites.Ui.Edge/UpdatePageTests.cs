using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.UpdatePage;
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
    [TestCategory("UpdatePage")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to easily update or refresh application pages during UI " +
        "automation tasks, So that I can ensure the application remains in sync with the latest data and state changes.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The UpdatePage plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Page Update Functionality: The plugin effectively performs the page update or refresh action, allowing users to refresh the current page during UI automation tasks.")]
    [AcceptanceCriteria(criteria: "Repeat Parameter: The plugin supports a 'repeat' parameter, enabling users to specify the number of times the page update action is performed, providing flexibility in handling repetitive tasks.")]
    [AcceptanceCriteria(criteria: "Delay Parameter: The plugin includes a 'delay' parameter, allowing users to specify a time interval between each page update action, facilitating controlled execution and avoiding overwhelming the application.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during page update actions, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class UpdatePageTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UpdatePage plugin, when invoked, correctly updates the page, resetting " +
            "input fields and refreshing content.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UpdatePage plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "SendKeys Action: The plugin successfully sends 'Foo Bar' to the element with ID 'SendKeys' using CSS selector.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion before Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector matches '(?i)foo bar'.")]
        [AcceptanceCriteria(criteria: "UpdatePage Action: The plugin updates the page.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion after Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector is empty.")]
        #endregion
        public void T0001P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UpdatePage plugin, when invoked multiple times, correctly updates the " +
            "page, resetting input fields and refreshing content.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UpdatePage plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "SendKeys Action: The plugin successfully sends 'Foo Bar' to the element with ID 'SendKeys' using CSS selector.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion before Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector matches '(?i)foo bar'.")]
        [AcceptanceCriteria(criteria: "UpdatePage Action with Repetition: The plugin updates the page 3 times.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion after Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector is empty.")]
        #endregion
        public void T0002P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0002>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UpdatePage plugin, when invoked multiple times with repetition specified " +
            "by the Repeat parameter, correctly updates the page, resetting input fields and refreshing " +
            "content.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UpdatePage plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "SendKeys Action: The plugin successfully sends 'Foo Bar' to the element with ID 'SendKeys' using CSS selector.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion before Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector matches '(?i)foo bar'.")]
        [AcceptanceCriteria(criteria: "UpdatePage Action with Repetition: The plugin updates the page 3 times as specified by the Repeat parameter.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion after Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector is empty.")]
        #endregion
        public void T0003P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0003>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UpdatePage plugin, when invoked to refresh the page multiple times with " +
            "repetition specified by the Repeat parameter and a delay between each refresh specified " +
            "by the Delay parameter, correctly resets input fields and refreshes content.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UpdatePage plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "SendKeys Action: The plugin successfully sends 'Foo Bar' to the element with ID 'SendKeys' using CSS selector.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion before Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector matches '(?i)foo bar'.")]
        [AcceptanceCriteria(criteria: "RefreshPage Action with Repetition and Delay: The plugin refreshes the page 4 times with a delay of 1000 milliseconds between each refresh as specified by the Repeat and Delay parameters.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion after Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector is empty.")]
        #endregion
        public void T0004P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options.
            var response = Invoke<C0004>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("UpdatePage");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime > 3 * TimeSpan.TicksPerSecond));
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the UpdatePage plugin, when invoked to update the page multiple times with " +
            "repetition specified by the Repeat parameter and a delay between updates specified in " +
            "the 'HH:mm:ss' format by the Delay parameter, correctly resets input fields and refreshes " +
            "content.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The UpdatePage plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "SendKeys Action: The plugin successfully sends 'Foo Bar' to the element with ID 'SendKeys' using CSS selector.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion before Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector matches '(?i)foo bar'.")]
        [AcceptanceCriteria(criteria: "UpdatePage Action with Repetition and Delay: The plugin updates the page 4 times with a delay of 1 second between updates as specified by the Repeat and Delay parameters in the 'HH:mm:ss' format.")]
        [AcceptanceCriteria(criteria: "Element Attribute Assertion after Update: The plugin asserts that the value attribute of the element with ID 'SendKeys' using CSS selector is empty.")]
        #endregion
        public void T0005P()
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options.
            var response = Invoke<C0005>(testOptions);

            // Filter performance points by plugin name "UpdatePage".
            var performancePoints = response
                .ResponseData
                .PerformancePoints
                .FilterByPluginName<G4PluginPerformancePointModel>("UpdatePage");

            // Assert that all performance points have a runtime greater than 3 seconds.
            Assert.IsTrue(performancePoints.All(i => i.RunTime > 3 * TimeSpan.TicksPerSecond));
        }
    }
}
