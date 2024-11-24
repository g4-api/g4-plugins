using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(NewWindow)}.json")]
    public class NewWindow(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Determine the type of new window to open, defaulting to "tab" if not specified
            var type = string.IsNullOrEmpty(pluginData.Rule.Argument)
                ? "tab"
                : pluginData.Rule.Argument;

            // Call the "NewWindow" method on the WebDriver's TargetLocator to open a new window
            WebDriver.SwitchTo().NewWindow(type);

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
