using G4.Attributes;
using G4.Models;

namespace G4.Plugins.Common.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Macros.Manifests.{nameof(GetParameter)}.json")]
    public class GetParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            return GetParameterValue(pluginData);
        }
    }
}
