using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(Assert)}.json")]
    public class Assert(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Call the Assert method to perform the specified action and assertions.
            var assertResponse = this.Assert(pluginData, addExtractions: true);

            // Return new plugin response.
            return this.NewPluginResponse(assertResponse);
        }
    }
}
