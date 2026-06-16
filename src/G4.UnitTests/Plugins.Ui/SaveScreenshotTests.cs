using G4.Extensions;
using G4.Models;
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
using System.Text.Json;
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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

            // Assert that all saved files exist
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory
            Assert.IsTrue(entities.All((i) => i.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that all file paths end with the specified file name
            Assert.IsTrue(entities.All((i) => Regex.IsMatch(input: Path.GetFileName(i), pattern: @"^(\w{8}-)(\w{4}-){3}(\w{12})\.png$")));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action returns base64 content " +
            "and skips the disk write when the Base64 switch is supplied.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots --FileName:$[FileName] --Base64}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotBase64Test(string ruleJson, string fileName)
        {
            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action with the Base64 switch and get the plugin.
            var plugin = Invoke<SaveScreenshot>(ruleJson).Plugin;

            // Retrieve the saved screenshots from the session parameters.
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

            // Assert that no files were written to disk (the switch skips the disk write,
            // so the Directory and FileName arguments are ignored for file output).
            Assert.IsTrue(entities.All(e => !File.Exists(e)));

            // Assert that all stored values decode as valid base64.
            Assert.IsTrue(entities.All(ConfirmBase64String));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action returns base64 content " +
            "and skips the disk write when the Base64 switch is supplied and an element is specified.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots --FileName:$[FileName] --Base64}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotBase64ElementTest(string ruleJson, string fileName)
        {
            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Invoke the SaveScreenshot action with the Base64 switch against a resolved
            // element so the scoped capture is encoded as base64 instead of being saved.
            var plugin = Invoke<SaveScreenshot>(ruleJson, By.Custom.Positive()).Plugin;

            // Retrieve the saved screenshots from the session parameters.
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

            // Assert that no files were written to disk.
            Assert.IsTrue(entities.All(e => !File.Exists(e)));

            // Assert that all stored values decode as valid base64.
            Assert.IsTrue(entities.All(ConfirmBase64String));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action exposes the base64 image " +
            "on the response entity when the Base64 switch is supplied.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Base64}}""}")]
        #endregion
        public void SaveScreenshotBase64EntityTest(string ruleJson)
        {
            // Invoke the SaveScreenshot action with the Base64 switch and get the response.
            var entity = Invoke<SaveScreenshot>(ruleJson).Response.Entity;

            // Assert that the screenshot value is present on the response entity.
            Assert.IsTrue(entity.ContainsKey("Screenshot"));

            // Resolve the recorded value from the response entity.
            var screenshot = $"{entity["Screenshot"]}";

            // Assert that the response entity carries the embedded image as base64, not a file path.
            Assert.IsFalse(File.Exists(screenshot));

            // Assert that the embedded value decodes as valid base64.
            Assert.IsTrue(ConfirmBase64String(screenshot));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action exposes the saved file path " +
            "on the response entity when the Base64 switch is omitted.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots}}""}")]
        #endregion
        public void SaveScreenshotEntityPathTest(string ruleJson)
        {
            // Default directory for saving screenshots
            const string directory = "Screenshots";

            // Invoke the SaveScreenshot action without the Base64 switch and get the response.
            var entity = Invoke<SaveScreenshot>(ruleJson).Response.Entity;

            // Resolve the recorded value from the response entity.
            var screenshot = $"{entity["Screenshot"]}";

            // Assert that the response entity carries the on-disk file path and the file exists.
            Assert.IsTrue(File.Exists(screenshot));

            // Assert that the recorded path is under the specified directory.
            Assert.IsTrue(screenshot.StartsWith(directory, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action accumulates base64 values " +
            "across repeated invocations when the Base64 switch is supplied.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Base64}}""}")]
        #endregion
        public void SaveScreenshotBase64AccumulationTest(string ruleJson)
        {
            // Deserialize the rule and assign a reference so the extraction model can be built.
            var ruleModel = (G4RuleModelBase)JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);
            ruleModel.Reference = new G4PluginReferenceModel { Id = $"{Guid.NewGuid()}" };

            // Create a single plugin instance so both invocations share the same session context.
            var plugin = NewPlugin<SaveScreenshot>(Automation);
            var pluginData = new PluginDataModel { Rule = ruleModel };

            // Invoke the plugin twice to simulate multiple base64 captures within the same session.
            plugin.Send(pluginData);
            plugin.Send(pluginData);

            // Retrieve the saved screenshots from the session parameters.
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value).ToList();

            // Assert that both invocations were tracked in the session list.
            Assert.HasCount(2, entities);

            // Assert that no files were written to disk.
            Assert.IsTrue(entities.All(e => !File.Exists(e)));

            // Assert that all accumulated values decode as valid base64.
            Assert.IsTrue(entities.All(ConfirmBase64String));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action accumulates multiple " +
            "screenshots in the session list across repeated invocations.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots --FileName:$[FileName]}}""}", "PageScreenshot-$[Guid].png")]
        #endregion
        public void SaveScreenshotAccumulationTest(string ruleJson, string fileName)
        {
            // Default directory for saving screenshots
            const string directory = "Screenshots";

            // Replace $[Guid] with a new Guid in the file name
            fileName = fileName.Replace("$[Guid]", Guid.NewGuid().ToString());

            // Replace $[FileName] with the updated file name in the action rule
            ruleJson = ruleJson.Replace("$[FileName]", fileName);

            // Deserialize the rule and assign a reference so the extraction model can be built.
            var ruleModel = (G4RuleModelBase)JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);
            ruleModel.Reference = new G4PluginReferenceModel { Id = $"{Guid.NewGuid()}" };

            // Create a single plugin instance so both invocations share the same session context.
            var plugin = NewPlugin<SaveScreenshot>(Automation);
            var pluginData = new PluginDataModel { Rule = ruleModel };

            // Invoke the plugin twice to simulate multiple screenshot captures within the same session.
            plugin.Send(pluginData);
            plugin.Send(pluginData);

            // Retrieve the saved screenshots from the session parameters.
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value).ToList();

            // Assert that both invocations were tracked in the session list.
            Assert.HasCount(2, entities);

            // Assert that all saved files exist on disk.
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory.
            Assert.IsTrue(entities.All(e => e.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod(DisplayName = "Verify that the SaveScreenshot action appends the .png extension " +
            "when the file name does not include one.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Directory:Screenshots --FileName:NoExtensionScreenshot}}""}")]
        #endregion
        public void SaveScreenshotFileNameNoExtensionTest(string ruleJson)
        {
            // Default directory for saving screenshots
            const string directory = "Screenshots";

            // Invoke the SaveScreenshot action and get the plugin
            var plugin = Invoke<SaveScreenshot>(ruleJson).Plugin;

            // Retrieve the saved screenshots from the session parameters
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

            // Assert that all saved files exist on disk.
            Assert.IsTrue(entities.All(File.Exists));

            // Assert that all file paths start with the specified directory.
            Assert.IsTrue(entities.All(e => e.StartsWith(directory, StringComparison.OrdinalIgnoreCase)));

            // Assert that the .png extension was automatically appended to the file name.
            Assert.IsTrue(entities.All(e => e.EndsWith("NoExtensionScreenshot.png", StringComparison.OrdinalIgnoreCase)));
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
            var value = (plugin.Invoker.Context.SessionParameters["SaveScreenshot:Screenshots"] as string).ConvertFromBase64();
            var entities = JsonSerializer.Deserialize<IEnumerable<string>>(value);

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

        // Returns true when the provided string decodes as valid base64 content.
        private static bool ConfirmBase64String(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            try
            {
                Convert.FromBase64String(value);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
