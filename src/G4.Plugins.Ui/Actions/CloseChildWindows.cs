using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Linq;
using System.Threading;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(CloseChildWindows)}.json")]
    public class CloseChildWindows(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // If there's only one window, nothing to close
            if (WebDriver.WindowHandles.Count == 1)
            {
                return this.NewPluginResponse();
            }

            // Store the main window handle
            var mainWindow = WebDriver.WindowHandles[0];

            // Get the list of window handles excluding the main window
            var handlers = WebDriver
                .WindowHandles
                .Where(i => !i.Equals(mainWindow, StringComparison.OrdinalIgnoreCase))
                .Reverse()
                .ToArray();

            // Determine the number of windows to close
            var length = GetLength(pluginData.Rule, handlers);

            // Iterate through all window handles to close them
            CloseWindows(this, pluginData.Rule, handlers, numberOfWindows: length);

            // Switch back to the main window
            WebDriver.SwitchTo().Window(mainWindow);

            // Return new plugin response.
            return this.NewPluginResponse();
        }

        // Gets the length to be used for processing windows.
        private static int GetLength(G4RuleModelBase rule, string[] handlers)
        {
            // Determine the number of windows to process
            var isArgument = int.TryParse(rule.Argument, out int numberOfWindows);

            // Adjust negative argument to 0
            numberOfWindows = isArgument && numberOfWindows < 0 ? 0 : numberOfWindows;

            // Calculate the length based on the argument or total handlers
            var length = isArgument ? numberOfWindows : handlers.Length;
            if (length > handlers.Length)
            {
                length = handlers.Length;
            }

            // Return the determined length
            return length;
        }

        // Closes the specified number of child windows using the given plugin.
        private static void CloseWindows(
            PluginBase plugin,
            G4RuleModelBase rule,
            string[] handlers,
            int numberOfWindows)
        {
            // Iterate through all window handles to close them
            for (int i = 0; i < numberOfWindows; i++)
            {
                try
                {
                    // Switch to the child window and close it
                    plugin.WebDriver.SwitchTo().Window(handlers[i])?.Close();
                }
                catch (Exception e)
                {
                    // Create an G4ExceptionModel to capture the exception details
                    var exception = new G4ExceptionModel(rule, e.GetBaseException());

                    // Add the exception to the plugin's exceptions collection
                    plugin.AddExceptions(exception);
                }

                // Add a small delay between window closures
                Thread.Sleep(100);
            }
        }
    }
}
