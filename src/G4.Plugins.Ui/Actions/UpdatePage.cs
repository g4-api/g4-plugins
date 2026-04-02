using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.Actions.Abstraction;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(UpdatePage)}.json")]
    public class UpdatePage(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Stores the plugin setup required to initialize the shared navigation helper.
        private readonly G4PluginSetupModel _pluginSetup = pluginSetup;

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Create the shared navigation helper that handles repeat and delay behavior.
            var methodBase = new NavigateBase(_pluginSetup);

            // Execute the browser update or refresh action through the shared helper.
            methodBase.CallNavigate(
                pluginData,
                navigationAction: () => WebDriver.Navigate().Update());

            // Return a standard successful plugin response.
            return this.NewPluginResponse();
        }
    }
}
