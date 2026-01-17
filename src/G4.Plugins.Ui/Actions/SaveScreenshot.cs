using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;

using System;
using System.Collections.Generic;
using System.IO;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SaveScreenshot)}.json")]
    public class SaveScreenshot(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve screenshot-related arguments from the plugin data
            var directory = pluginData.Parameters.Get(key: "Directory", defaultValue: Environment.CurrentDirectory);
            var fileName = FormatFileName(pluginData);
            var screenshots = Invoker.Context.SessionParameters.Get(key: "Screenshots", defaultValue: new List<string>());
            var path = Path.Combine(directory, fileName);
            var element = this.GetElement(pluginData.Rule, pluginData.Element);

            // Save the screenshot using the WebDriver
            Directory.CreateDirectory(directory);
            if (element != null)
            {
                element.SaveScreenshot(fileName: path);
            }
            else
            {
                WebDriver.SaveScreenshot(fileName: path);
            }

            // Add the path of the saved screenshot to the list of screenshots
            screenshots.Add(path);

            // Update the session parameters with the updated list of saved screenshots
            Invoker.Context.SessionParameters["SavedScreenshots"] = screenshots;

            // Return a new plugin response indicating success
            return this.NewPluginResponse();
        }

        // Formats the file name based on the specified plugin data, ensuring it ends with ".png".
        private static string FormatFileName(PluginDataModel pluginData)
        {
            // Define the key used to retrieve the file name from the plugin data
            const string Key = "FileName";

            // Generate a default value for the file name using a new GUID string value
            var defaultValue = Guid.NewGuid().ToString();

            // Retrieve the file name from the plugin data, using the specified key, or use a default value
            var fileName = $"{pluginData.Parameters.Get(Key, defaultValue)}";

            // Ensure the file name ends with ".png"
            return fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                ? fileName
                : $"{fileName}.png";
        }
    }
}
