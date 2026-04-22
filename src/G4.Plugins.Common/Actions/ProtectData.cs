using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Collections.Generic;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(ProtectData)}.json")]
    public class ProtectData(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract the plaintext value and encryption key from the parsed parameters.
            var value = pluginData.Parameters.Get(key: "Value", defaultValue: string.Empty);
            var key = pluginData.Parameters.Get(key: "Key", defaultValue: string.Empty);

            // Encrypt the value with the provided key, then encode the result to Base64
            // for safe transport and storage.
            var result = value.Encrypt(key).ConvertToBase64();

            // Store the protected result in the session context for downstream plugins.
            Invoker.Context.SessionParameters["ProtectData:Result"] = result;

            // Create a new plugin response and expose the result in the entity.
            var pluginResponse = this.NewPluginResponse();

            // Include the protected value in the plugin response
            // entity for downstream processing.
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["Result"] = result
            };

            // Return the plugin response to allow downstream plugins
            // to access the protected result.
            return pluginResponse;
        }
    }
}
