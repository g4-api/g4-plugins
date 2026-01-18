using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SaveScreenshot")]
    [TestCategory("UnitTest")]
    public class SaveScreenshotTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the SaveScreenshot plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SaveScreenshot>();
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SaveScreenshot>();
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action works with valid arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots --FileName:$[FileName]}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            const string directory = "Screenshots";

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => i.EndsWith(fileName, StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action works with no directory specified.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --FileName:$[FileName]}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotNoDirectoryTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            var directory = Environment.CurrentDirectory;

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => i.EndsWith(fileName, StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action works with no file name specified.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotNoFileNameTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            const string directory = "Screenshots";

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action works with no arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":null}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotNoArgumentTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            var directory = Environment.CurrentDirectory;

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action works with an element specified.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots --FileName:$[FileName]}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotElementTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            const string directory = "Screenshots";

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson, By.Custom.Positive()).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => i.EndsWith(fileName, StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action works with no " +
            "directory specified and an element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --FileName:$[FileName]}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotNoDirectoryElementTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            var directory = Environment.CurrentDirectory;

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson, By.Custom.Positive()).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => i.EndsWith(fileName, StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action works with no file " +
            "name specified and an element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotNoFileNameElementTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            const string directory = "Screenshots";

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson, By.Custom.Positive()).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action works with no arguments and an element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":null}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotNoArgumentElementTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            var directory = Environment.CurrentDirectory;

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson, By.Custom.Positive()).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action throws exceptions with null elements.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":null, ""onElement"":""null""}")]
        #endregion
        public void SaveScreenshotExceptionNullElementTest(string ruleJson)
        {
            // Default directory for saving screenshots
            var directory = Environment.CurrentDirectory;

            // Invoke the action to get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson, By.Custom.Positive()).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var entities = plugin.Invoker.Context.SessionParameters["SavedScreenshots"] as IEnumerable<string>;

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action throws " +
            "StaleElementReferenceException with stale elements.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":null, ""onElement"":""stale""}")]
        #endregion
        public void SaveScreenshotExceptionStaleElementTest(string ruleJson)
        {
            // Invoke the action to get the plugin
            Assert.Throws<StaleElementReferenceException>(() =>
                Invoke<SaveScreenshot>(ruleJson, By.Custom.Stale()));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action throws " +
            "NoSuchElementException with no elements.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":null, ""onElement"":""none""}")]
        #endregion
        public void SaveScreenshotExceptionNoElementTest(string ruleJson)
        {
            // Invoke the action to get the plugin
            Assert.Throws<NoSuchElementException>(() =>
                Invoke<SaveScreenshot>(ruleJson, By.Custom.Negative()));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action throws WebDriverException " +
            "with exception elements.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":null, ""onElement"":""exception""}")]
        #endregion
        public void SaveScreenshotExceptionElementTest(string ruleJson)
        {
            // Invoke the action to get the plugin
            Assert.Throws<WebDriverException>(() =>
                Invoke<SaveScreenshot>(ruleJson, By.Custom.Exception()));
        }
    }
}
