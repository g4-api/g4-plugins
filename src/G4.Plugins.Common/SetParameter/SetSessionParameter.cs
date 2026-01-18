using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.SetParameter
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.SetParameter.Manifests.{nameof(SetSessionParameter)}.json")]
    public class SetSessionParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the name from the action rule.
            var name = pluginData.Rule.OnElement;

            // Set the session-level parameter.
            Invoker.Context.SessionParameters[name] = pluginData.Parameters.Get("Value", string.Empty);

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
