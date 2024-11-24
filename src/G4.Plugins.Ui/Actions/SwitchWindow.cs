using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SwitchWindow)}.json")]
    public class SwitchWindow(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the window handle or index from the rule argument.
            var handle = pluginData.Rule.Argument;

            // Determine if the handle is an index (integer) or a window handle (string).
            var isIndex = int.TryParse(handle, out int index);

            // Switch to the specified window or tab based on the handle type.
            if (isIndex)
            {
                // Switch by index
                WebDriver.SwitchTo().Window(index);
            }
            else
            {
                // Switch by window handle
                WebDriver.SwitchTo().Window(handle);
            }

            // Return a new plugin response indicating the successful completion of the action.
            return this.NewPluginResponse();
        }
    }
}
