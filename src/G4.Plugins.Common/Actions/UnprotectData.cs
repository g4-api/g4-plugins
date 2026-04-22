using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Collections.Generic;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(UnprotectData)}.json")]
    public class UnprotectData(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract the Base64-encoded encrypted value and the decryption key from the parsed parameters.
            var value = pluginData.Parameters.Get(key: "Value", defaultValue: string.Empty);
            var key = pluginData.Parameters.Get(key: "Key", defaultValue: string.Empty);

            // Decode from Base64 to recover the encrypted bytes, then decrypt to recover
            // the original plaintext.
            var result = value.ConvertFromBase64().Decrypt(key);

            // Store the decrypted plaintext in the session context for downstream plugins.
            Invoker.Context.SessionParameters["UnprotectData:Result"] = result;

            // Create a new plugin response and expose the result in the entity.
            var pluginResponse = this.NewPluginResponse();

            // Expose the decrypted plaintext in the plugin
            // response's entity for downstream plugins.
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["Result"] = result
            };

            // Return the plugin response to the G4 engine.
            // Downstream plugins can access the decrypted
            // plaintext from the plugin response's entity
            // or from the session context.
            return pluginResponse;
        }
    }
}
