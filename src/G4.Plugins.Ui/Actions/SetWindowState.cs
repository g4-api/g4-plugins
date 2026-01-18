using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SetWindowState)}.json")]
    public class SetWindowState(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define the comparison type for string comparison.
            const StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;

            // Get the window state from the action argument.
            var windowState = pluginData.Rule.Argument;

            // Set the browser window to `Maximized`.
            if (windowState.Equals(value: "Maximized", comparisonType))
            {
                WebDriver.Manage().Window.Maximize();
            }

            // Set the browser window to `Minimized`.
            if (windowState.Equals(value: "Minimized", comparisonType))
            {
                WebDriver.Manage().Window.Minimize();
            }

            // Set the browser window to `Full Screen`.
            if (windowState.Equals(value: "FullScreen", comparisonType))
            {
                WebDriver.Manage().Window.FullScreen();
            }

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
