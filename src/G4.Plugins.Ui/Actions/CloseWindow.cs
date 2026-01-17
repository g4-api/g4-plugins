using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Exceptions;

using System;
using System.Linq;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(CloseWindow)}.json")]
    public class CloseWindow(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Specify string comparison type
            const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;
            var comparer = StringComparer.OrdinalIgnoreCase;

            // Get the argument from the action
            var argument = pluginData.Rule.Argument;

            // Get the window handles of the WebDriver
            var windowHandles = WebDriver.WindowHandles;

            // Check if the argument is a valid index
            var isIndex = int.TryParse(argument, out int index);

            // Check if the argument is a valid window handle
            var isHandle = !isIndex && windowHandles.Contains(argument, comparer);

            // Check for invalid index or handle
            var invalidIndex = isIndex && index >= windowHandles.Count;
            var invalidHandle = !isIndex
                && !string.IsNullOrEmpty(argument)
                && !windowHandles.Any(i => i.Equals(argument, Comparison));

            // Throw an exception if the provided index or handle is invalid
            if (invalidHandle || invalidIndex)
            {
                throw new NoSuchWindowException("Invalid window handle or index provided.");
            }

            // If neither a handle nor an index is provided, simply close the active window
            if (!isHandle && !isIndex)
            {
                WebDriver.Close();
                return this.NewPluginResponse();
            }

            // Determine the window handle to switch to and close based on provided handle or index
            var handle = isHandle
                ? windowHandles.First(i => i.Equals(argument, Comparison)) // Find handle by matching string
                : windowHandles[index];                                    // Use the handle at the specified index

            // Switch to the specified window handle or index and then close it
            WebDriver.SwitchTo().Window(handle).Close();

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
