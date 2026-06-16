using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{NameReference}.json")]
    public class SaveScreenshot(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(SaveScreenshot);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Continue only when the active WebDriver supports screenshots.
            if (WebDriver is not ITakesScreenshot driver)
            {
                Logger.LogWarning("WebDriver is not available or not suitable for taking a screenshot.");
                return this.NewPluginResponse();
            }

            // Resolve the target directory from the plugin parameters.
            // If no directory is provided, use the current process directory.
            var directory = pluginData.Parameters.Get(
                key: "Directory",
                defaultValue: Environment.CurrentDirectory);

            // Resolve and normalize the screenshot file name.
            var fileName = FormatFileName(pluginData);

            // Read the existing screenshot list from the session.
            // The value is stored as JSON so multiple screenshots can be tracked.
            var screenshots = Invoker.Context.SessionParameters.Get(
                key: $"{NameReference}:Screenshots",
                defaultValue: "[]");

            // Build the full screenshot path from the target directory and file name.
            var path = Path.Combine(directory, fileName);

            // Try to resolve the target element from the current rule and element data.
            // When an element exists, the screenshot will be scoped to that element.
            var element = this.GetElement(pluginData.Rule, pluginData.Element);

            // Initialize a variable to hold the screenshot model, which will
            // be populated based on whether an element was resolved.
            ScreenshotModel screenshot;

            // Capture an element-level screenshot when an element was resolved.
            // Otherwise, fallback to a full WebDriver screenshot.
            if (element != null)
            {
                screenshot = element.GetScreenshot();
            }
            else
            {
                screenshot = driver.GetScreenshot();
            }

            // Determine the output mode from the plugin's own Base64 switch.
            // This keeps the plugin self-contained: its behavior is driven by its
            // own argument rather than the automation-wide ScreenshotsSettings.
            var isBase64 = pluginData.Parameters.ContainsKey("Base64");

            // Store either the base64 screenshot content or the screenshot path,
            // depending on whether the Base64 switch was supplied.
            var value = isBase64
                ? screenshot.Base64
                : path;

            // When not returning base64, write to disk: ensure the target directory
            // exists and persist the screenshot bytes to the resolved file path.
            if (!isBase64)
            {
                Directory.CreateDirectory(directory);
                screenshot.Save(path);
            }

            // Deserialize the current screenshot list and append the new value.
            var list = JsonSerializer.Deserialize<List<string>>(screenshots.ConvertFromBase64()) ?? [];
            list.Add(value);

            // Save the updated screenshot list back into the session parameters.
            this.AddSessionParameter(
                @namespace: NameReference,
                name: "Screenshots",
                value: JsonSerializer.Serialize(list));

            // Build a successful plugin response.
            var response = this.NewPluginResponse();

            // Expose the recorded value (file path or base64 content) on the response
            // entity so downstream plugins can access the latest screenshot directly.
            response.Entity = new Dictionary<string, object>
            {
                ["Screenshot"] = value
            };

            // Return the plugin response to the caller.
            return response;
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
