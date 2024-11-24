using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SwitchFrame)}.json")]
    public class SwitchFrame(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Try parsing the argument as an integer to check if it's index
            var isId = int.TryParse(pluginData.Rule.Argument, out int index);

            // If the argument is an index
            if (isId)
            {
                // Switch to the frame by index
                WebDriver.SwitchTo().Frame(index);

                // Return a new plugin response
                return this.NewPluginResponse();
            }

            // If the argument is not an index, get the element
            var element = this.GetElement(pluginData.Rule, pluginData.Element);

            // Switch to the frame by element
            WebDriver.SwitchTo().Frame(element);

            // Return a new plugin response
            return this.NewPluginResponse();
        }
    }
}
