using G4.Attributes;
using G4.Models;
using G4.Extensions;

namespace G4.Plugins.Common.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Assertions.Manifests.{nameof(Text)}.json")]
    public class Text(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            return this.NewAssertResponse(
                pluginData,
                factory: () => pluginData.Rule.OnElement);
        }
    }
}
