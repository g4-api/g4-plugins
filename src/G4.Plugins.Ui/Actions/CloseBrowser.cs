using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(CloseBrowser)}.json")]
    public class CloseBrowser(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            try
            {
                // Close the browser window
                WebDriver?.Quit();
            }
            finally
            {
                // Dispose of the WebDriver instance
                WebDriver?.Dispose();
            }

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
