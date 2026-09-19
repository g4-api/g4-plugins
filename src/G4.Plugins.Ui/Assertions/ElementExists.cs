using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(ElementExists)}.json")]
    public class ElementExists(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Return a new assertion response indicating whether the
            // specified element exists using the provided plugin data.
            return this.NewAssertResponse(
                pluginData,
                factory: () => Factory(this, pluginData));

            // Assertion logic to check if the specified element exists using the provided plugin data.
            static bool Factory(PluginBase plugin, PluginDataModel pluginData)
            {
                return plugin.FindElement(pluginData.Rule, pluginData.Element) != null;
            }
        }
    }
}
