/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.CopyResource;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass, DoNotParallelize]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("CopyResource")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to copy resources from web elements, So that I can efficiently " +
        "extract data from web pages and streamline automation workflows.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The CopyResource plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Resource Extraction Functionality: The plugin effectively extracts resources from web elements based on specified rules, supporting regular expressions for flexible extraction.")]
    [AcceptanceCriteria(criteria: "Customization Options: The plugin allows users to specify extraction patterns, destination paths, and whether to execute extraction in parallel, providing flexibility in resource extraction.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during resource extraction, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class CopyResourceTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the CopyResource plugin, when configured to copy a specific resource from " +
            "the source to the destination, correctly copies the resource.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CopyResource plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Resource Copying: The plugin successfully copies the specified resource from the source to the destination.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the resource copying process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("CopyResource")]
        [DataRow("copyResource")]
        [DataRow("CopyResources")]
        [DataRow("copyResources")]
        [DataRow("DownloadResource")]
        [DataRow("downloadResource")]
        [DataRow("DownloadResources")]
        [DataRow("downloadResources")]
        #endregion
        public void T0001P(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            var response = Invoke<C0001>(testOptions);

            // Assert the expected number of resources copied
            Assert.AreEqual(
                expected: 3,
                actual: (response.Environment.SessionParameters["CopiedResources"] as IEnumerable<string>).Count(),
                message: "The expected number of resources was not copied. Check the CopyResource action.");
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the CopyResource plugin, when configured to copy a specific resource from " +
            "the source to the destination in parallel, correctly copies the resource.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CopyResource plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Resource Copying: The plugin successfully copies the specified resource from the source to the destination in parallel.")]
        [AcceptanceCriteria(criteria: "Error Handling: In case of any errors during the resource copying process, the automation script captures and handles the errors gracefully.")]
        #endregion
        #region *** Data     ***
        [DataRow("CopyResource")]
        [DataRow("copyResource")]
        [DataRow("CopyResources")]
        [DataRow("copyResources")]
        [DataRow("DownloadResource")]
        [DataRow("downloadResource")]
        [DataRow("DownloadResources")]
        [DataRow("downloadResources")]
        #endregion
        public void T0002P(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            var response = Invoke<C0002>(testOptions);

            // Assert the expected number of resources copied
            Assert.AreEqual(
                expected: 3,
                actual: (response.Environment.SessionParameters["CopiedResources"] as IEnumerable<string>).Count(),
                message: "The expected number of resources was not copied. Check the CopyResource action.");
        }

        [TestCategory("Negative")]
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the behavior of the CopyResource plugin when the destination is not provided.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CopyResource plugin integrates seamlessly.")]
        [AcceptanceCriteria(criteria: "Failure Notification: Provides appropriate failure notification or logging if the destination is not provided.")]
        [AcceptanceCriteria(criteria: "Clear Error Messages: Provides clear and informative error messages when the destination is not provided.")]
        [AcceptanceCriteria(criteria: "Error Handling: Handles the situation gracefully without causing any errors if the destination is not provided.")]
        #endregion
        #region *** Data     ***
        [DataRow("CopyResource")]
        [DataRow("copyResource")]
        [DataRow("CopyResources")]
        [DataRow("copyResources")]
        [DataRow("DownloadResource")]
        [DataRow("downloadResource")]
        [DataRow("DownloadResources")]
        [DataRow("downloadResources")]
        #endregion
        public void T0003N(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html")
            {
                FailOnException = false
            };

            // Invoking the test with the constructed test options
            var response = Invoke<C0003>(testOptions);

            // Assert that the "CopiedResources" key does not exist in the session parameters
            Assert.IsFalse(
                condition: response.Environment.SessionParameters.ContainsKey("CopiedResources"),
                message: "Unexpected CopiedResources found. The action must not copy any resources.");
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the CopyResource plugin, when the source is not provided, unavailable, " +
            "or corrupted, gracefully handles the situation.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CopyResource plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles the absence, unavailability, or corruption of the source resource gracefully without causing errors.")]
        [AcceptanceCriteria(criteria: "Failure Notification: The automation script provides appropriate failure notification or logging if the source resource is not provided, unavailable, or corrupted.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin provides clear and informative error messages when the source resource is not provided, unavailable, or corrupted.")]
        #endregion
        #region *** Data     ***
        [DataRow("CopyResource")]
        [DataRow("copyResource")]
        [DataRow("CopyResources")]
        [DataRow("copyResources")]
        [DataRow("DownloadResource")]
        [DataRow("downloadResource")]
        [DataRow("DownloadResources")]
        [DataRow("downloadResources")]
        #endregion
        public void T0004N(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html")
            {
                FailOnException = false
            };

            // Invoking the test with the constructed test options
            var response = Invoke<C0004>(testOptions);

            // Assert that the "CopiedResources" key does not exist in the session parameters
            Assert.IsFalse(
                condition: response.Environment.SessionParameters.ContainsKey("CopiedResources"),
                message: "Unexpected CopiedResources found. The action must not copy any resources.");
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the CopyResource action, when triggered, successfully copies the resource " +
            "from the extracted source to the 'TestImages' destination folder. This ensures availability " +
            "for further testing, with the requirement of employing a regular expression to extract the " +
            "exact source.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The CopyResource action seamlessly integrates into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Invocation: Triggering the CopyResource action copies the resource from the extracted source to the 'TestImages' destination folder.")]
        [AcceptanceCriteria(criteria: "Element Identification: The action is performed on the specified element in the UI, identified by the XPath '//div[not(@class)]/p'.")]
        [AcceptanceCriteria(criteria: "Regular Expression Application: The regular expression '(?!(.*: ))\\w+.*' is applied on the source value to extract the exact source before the copy process.")]
        [AcceptanceCriteria(criteria: "Parallel Execution: The action is executed in parallel for efficiency.")]
        [AcceptanceCriteria(criteria: "Error Handling: The CopyResource action gracefully handles any potential failures during the copy process, providing clear error messages and logging for troubleshooting.")]
        #endregion
        #region *** Data     ***
        [DataRow("CopyResource")]
        [DataRow("copyResource")]
        [DataRow("CopyResources")]
        [DataRow("copyResources")]
        [DataRow("DownloadResource")]
        [DataRow("downloadResource")]
        [DataRow("DownloadResources")]
        [DataRow("downloadResources")]
        #endregion
        public void T0005P(string pluginName)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "pluginName", value: pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            var response = Invoke<C0005>(testOptions);

            // Assert the expected number of resources copied
            Assert.AreEqual(
                expected: 3,
                actual: (response.Environment.SessionParameters["CopiedResources"] as IEnumerable<string>).Count(),
                message: "The expected number of resources was not copied. Check the CopyResource action.");
        }
    }
}
