using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.SaveScreenshot;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("SaveScreenshot")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that enables me to capture and save screenshots during automated UI " +
        "testing tasks, So that I can efficiently document visual aspects of the applications under test and troubleshoot " +
        "any potential issues.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin must be easily accessible within the G4™ ecosystem, allowing seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Screenshot Capture: The plugin must be capable of capturing screenshots of either the entire page or specific elements, providing flexibility to meet diverse testing requirements.")]
    [AcceptanceCriteria(criteria: "Customizable Parameters: Users must have the flexibility to customize parameters such as the directory path where screenshots are saved and the file naming conventions, ensuring compatibility with different project structures and naming preferences.")]
    [AcceptanceCriteria(criteria: "Screenshot Format: Screenshots must be saved in the PNG format to maintain image quality and compatibility across different platforms and tools.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms must be implemented to handle scenarios where capturing or saving screenshots encounters issues, ensuring the stability and resilience of automation workflows.")]
    #endregion
    public class SaveScreenshotTests : TestBase
    {
        // Comparison type for string operations.
        private const StringComparison Compare = StringComparison.OrdinalIgnoreCase;

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SaveScreenshot plugin, when invoked with specific parameters to capture " +
            "and save a screenshot, successfully saves the screenshot in the specified directory with " +
            "the provided file name.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SaveScreenshot plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked with the 'Directory' parameter set to a specific directory path and the 'FileName' parameter set to a custom file name, the plugin captures and saves a screenshot.")]
        [AcceptanceCriteria(criteria: "File Existence Check: Upon completion, the saved screenshot exists in the specified directory with the provided file name.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any errors encountered during the screenshot capture and saving process, ensuring the stability of automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("GetScreenshot")]
        [DataRow("SaveScreenshot")]
        [DataRow("TakeScreenshot")]
        #endregion
        public void T0001P(string pluginName)
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = NewEnvironment(
                TestContext,
                pluginName,
                directoryInfo: new DirectoryInfo("Screenshots"),
                fileInfo: new FileInfo($"{Guid.NewGuid()}.png"));

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0001>(testOptions);

            // Get saved screenshots from response
            var entities = response
                .Environment
                .SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved screenshots exist and follow the expected naming conventions
            Assert.IsTrue(entities.All(File.Exists));
            Assert.IsTrue(entities.All((i) => i.StartsWith($"{environment.TestParameters["directory"]}", Compare)));
            Assert.IsTrue(entities.All((i) => i.EndsWith($"{environment.TestParameters["fileName"]}", Compare)));
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SaveScreenshot plugin, when invoked with specific parameters to capture " +
            "and save a screenshot, successfully saves the screenshot in the current working directory " +
            "if the directory parameter is not specified.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SaveScreenshot plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked with the 'FileName' parameter set to a custom file name and the 'Directory' parameter not specified, the plugin captures and saves a screenshot in the current working directory.")]
        [AcceptanceCriteria(criteria: "File Existence Check: Upon completion, the saved screenshot exists with the provided file name in the current working directory.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any errors encountered during the screenshot saving process, ensuring the stability of automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("GetScreenshot")]
        [DataRow("SaveScreenshot")]
        [DataRow("TakeScreenshot")]
        #endregion
        public void T0002P(string pluginName)
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = NewEnvironment(
                TestContext,
                pluginName,
                fileInfo: new FileInfo($"{Guid.NewGuid()}.png"));

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0002>(testOptions);

            // Get saved screenshots from response
            var entities = response
                .Environment
                .SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Verify that all saved screenshots exist and have the expected file path
            Assert.IsTrue(entities.All(File.Exists));
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SaveScreenshot plugin, when invoked with specific parameters to capture " +
            "and save a screenshot, successfully saves the screenshot with a default file name if the " +
            "FileName parameter is not specified.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SaveScreenshot plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked with the 'FileName' parameter not specified, the plugin captures and saves a screenshot with a default file name.")]
        [AcceptanceCriteria(criteria: "File Existence Check: Upon completion, the saved screenshot exists with the default file name in the specified directory or the current working directory.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any errors encountered during the screenshot saving process, ensuring the stability of automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("GetScreenshot")]
        [DataRow("SaveScreenshot")]
        [DataRow("TakeScreenshot")]
        #endregion
        public void T0003P(string pluginName)
        {
            // Create AutomationEnvironment instance with test context and parameters, specifying directory information
            var environment = NewEnvironment(
                TestContext,
                pluginName,
                directoryInfo: new DirectoryInfo("Screenshots"));

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0003>(testOptions);

            // Get saved screenshots from response
            var entities = response
                .Environment
                .SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved screenshots exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all saved screenshots start with the specified directory path
            Assert.IsTrue(entities.All((i) => i.StartsWith($"{environment.TestParameters["directory"]}", Compare)));

            // Assert that all saved screenshots match the expected file name pattern
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SaveScreenshot plugin, when invoked without specifying the Directory " +
            "and FileName parameters, successfully saves the screenshot in the current working " +
            "directory with a default file name.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SaveScreenshot plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked without specifying the 'Directory' and 'FileName' parameters, the plugin captures and saves a screenshot in the current working directory with a default file name.")]
        [AcceptanceCriteria(criteria: "File Existence Check: Upon completion, the saved screenshot exists in the current working directory with the default file name.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any errors encountered during the screenshot saving process, ensuring the stability of automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("GetScreenshot")]
        [DataRow("SaveScreenshot")]
        [DataRow("TakeScreenshot")]
        #endregion
        public void T0004P(string pluginName)
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = NewEnvironment(TestContext, pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0004>(testOptions);

            // Get saved screenshots from response
            var entities = response
                .Environment
                .SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved screenshots exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all saved screenshots are in the current directory
            Assert.IsTrue(entities.All((i) => Path.GetDirectoryName(i).Equals(Environment.CurrentDirectory, Compare)));

            // Assert that all saved screenshots match the expected file name pattern
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SaveScreenshot plugin, when configured to capture and save a screenshot " +
            "of a specified element with both the Directory and FileName parameters specified, successfully " +
            "saves the screenshot in the specified directory with the provided file name.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SaveScreenshot plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked with both the 'Directory' and 'FileName' parameters specified, the plugin captures and saves a screenshot of the specified element in the specified directory with the provided file name.")]
        [AcceptanceCriteria(criteria: "File Existence Check: Upon completion, the saved screenshot of the specified element exists in the specified directory with the provided file name.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any errors encountered during the screenshot saving process, ensuring the stability of automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("GetScreenshot")]
        [DataRow("SaveScreenshot")]
        [DataRow("TakeScreenshot")]
        #endregion
        public void T0005P(string pluginName)
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = NewEnvironment(
                TestContext,
                pluginName,
                directoryInfo: new DirectoryInfo("Screenshots"),
                fileInfo: new FileInfo($"{Guid.NewGuid()}.png"));

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0005>(testOptions);

            // Get saved screenshots from response
            var entities = response
                .Environment
                .SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved screenshots exist and follow the expected naming conventions
            Assert.IsTrue(entities.All(File.Exists));
            Assert.IsTrue(entities.All((i) => i.StartsWith($"{environment.TestParameters["directory"]}", Compare)));
            Assert.IsTrue(entities.All((i) => i.EndsWith($"{environment.TestParameters["fileName"]}", Compare)));
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SaveScreenshot plugin, when configured to capture and save a screenshot " +
            "of a specified element without specifying the Directory parameter, successfully saves " +
            "the screenshot in the current working directory with the provided file name.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SaveScreenshot plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked without specifying the 'Directory' parameter but with the 'FileName' parameter specified, the plugin captures and saves a screenshot of the specified element in the current working directory with the provided file name.")]
        [AcceptanceCriteria(criteria: "File Existence Check: Upon completion, the saved screenshot of the specified element exists in the current working directory with the provided file name.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any errors encountered during the screenshot saving process, ensuring the stability of automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("GetScreenshot")]
        [DataRow("SaveScreenshot")]
        [DataRow("TakeScreenshot")]
        #endregion
        public void T0006P(string pluginName)
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = NewEnvironment(
                TestContext,
                pluginName,
                fileInfo: new FileInfo($"{Guid.NewGuid()}.png"));

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0006>(testOptions);

            // Get saved screenshots from response
            var entities = response
                .Environment
                .SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Verify that all saved screenshots exist and have the expected file path
            Assert.IsTrue(entities.All(File.Exists));
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SaveScreenshot plugin, when configured to capture and save a screenshot " +
            "of a specified element without specifying the FileName parameter, successfully saves the " +
            "screenshot in the specified directory with a default file name.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SaveScreenshot plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked without specifying the 'FileName' parameter but with the 'Directory' parameter specified, the plugin captures and saves a screenshot of the specified element in the specified directory with a default file name.")]
        [AcceptanceCriteria(criteria: "File Existence Check: Upon completion, the saved screenshot of the specified element exists in the specified directory with a default file name.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any errors encountered during the screenshot saving process, ensuring the stability of automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("GetScreenshot")]
        [DataRow("SaveScreenshot")]
        [DataRow("TakeScreenshot")]
        #endregion
        public void T0007P(string pluginName)
        {
            // Create AutomationEnvironment instance with test context and parameters, specifying directory information
            var environment = NewEnvironment(
                TestContext,
                pluginName,
                directoryInfo: new DirectoryInfo("Screenshots"));

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0007>(testOptions);

            // Get saved screenshots from response
            var entities = response
                .Environment
                .SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved screenshots exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all saved screenshots start with the specified directory path
            Assert.IsTrue(entities.All((i) => i.StartsWith($"{environment.TestParameters["directory"]}", Compare)));

            // Assert that all saved screenshots match the expected file name pattern
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the SaveScreenshot plugin, when configured to capture and save a screenshot " +
            "of a specified element without specifying both the Directory and FileName parameters, " +
            "successfully saves the screenshot in the current working directory with a default file name.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SaveScreenshot plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When invoked without specifying both the 'Directory' and 'FileName' parameters, the plugin captures and saves a screenshot of the specified element in the current working directory with a default file name.")]
        [AcceptanceCriteria(criteria: "File Existence Check: Upon completion, the saved screenshot of the specified element exists in the current working directory with a default file name.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles any errors encountered during the screenshot saving process, ensuring the stability of automation workflows.")]
        #endregion
        #region *** Data     ***
        [DataRow("GetScreenshot")]
        [DataRow("SaveScreenshot")]
        [DataRow("TakeScreenshot")]
        #endregion
        public void T0008P(string pluginName)
        {
            // Create AutomationEnvironment instance with test context and parameters
            var environment = NewEnvironment(TestContext, pluginName);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options
            var response = Invoke<C0008>(testOptions);

            // Get saved screenshots from response
            var entities = response
                .Environment
                .SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved screenshots exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all saved screenshots are in the current directory
            Assert.IsTrue(entities.All((i) => Path.GetDirectoryName(i).Equals(Environment.CurrentDirectory, Compare)));

            // Assert that all saved screenshots match the expected file name pattern
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        // Creates a new AutomationEnvironment instance with a specified test context and plugin name.
        private static AutomationEnvironment NewEnvironment(TestContext testContext, string pluginName)
        {
            // Call the overloaded NewEnvironment method with default directory and file information
            return NewEnvironment(testContext, pluginName, directoryInfo: default, fileInfo: default);
        }

        // Creates a new AutomationEnvironment instance with a specified test context, plugin name, and directory information.
        private static AutomationEnvironment NewEnvironment(TestContext testContext, string pluginName, DirectoryInfo directoryInfo)
        {
            // Call the overloaded NewEnvironment method with specified directory information and default file information
            return NewEnvironment(testContext, pluginName, directoryInfo, fileInfo: default);
        }

        // Creates a new AutomationEnvironment instance with a specified test context, plugin name, and file information.
        private static AutomationEnvironment NewEnvironment(TestContext testContext, string pluginName, FileInfo fileInfo)
        {
            // Call the overloaded NewEnvironment method with default directory information and specified file information
            return NewEnvironment(testContext, pluginName, directoryInfo: default, fileInfo);
        }

        // Creates a new AutomationEnvironment instance with specified parameters.
        private static AutomationEnvironment NewEnvironment(
            TestContext testContext, string pluginName, DirectoryInfo directoryInfo, FileInfo fileInfo)
        {
            // Create a new AutomationEnvironment instance with the provided test context
            var environment = new AutomationEnvironment(testContext)
                .AddTestParameter(key: "pluginName", value: pluginName); // Add pluginName as a test parameter

            // If directory is specified, add it as a test parameter
            // Combine the provided directory with the current directory
            // Add directory as a test parameter
            if (directoryInfo != null)
            {
                var directory = Path.Combine(Environment.CurrentDirectory, directoryInfo.Name);
                environment.AddTestParameter(key: "directory", value: directory);
            }

            // If fileName is specified, add it as a test parameter
            // Add fileName as a test parameter
            if (fileInfo != null)
            {
                environment.AddTestParameter(key: "fileName", value: fileInfo.Name);
            }

            // Return the created AutomationEnvironment instance
            return environment;
        }
    }
}
