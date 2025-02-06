using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote.Uia;

namespace G4.Plugins.Ui.Actions.User32
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.User32.Manifests.{nameof(SetUser32Focus)}.json")]
    public class SetUser32Focus(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the WebDriver instance from the plugin data and check if it is a UiaDriver.
            // Exit the plugin if the WebDriver is not a UiaDriver.
            if (WebDriver is not IUser32Driver)
            {
                return this.NewPluginResponse();
            }

            // Get the element using provided plugin data.
            var element = this.GetUser32Element(pluginData);

            // If the element found, set focus to the element.
            element?.SetFocus();

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
