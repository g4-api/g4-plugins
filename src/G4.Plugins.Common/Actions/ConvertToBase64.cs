using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(ConvertToBase64)}.json")]
    public class ConvertToBase64(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Apply the regular expression to the argument value before encoding.
            // If the pattern matches, only the matched portion is encoded.
            var value = Regex
                .Match(pluginData.Rule.Argument, pluginData.Rule.RegularExpression)
                .Value
                .ConvertToBase64();

            // Store the Base64-encoded result in the session context for downstream plugins.
            Invoker.Context.SessionParameters["ConvertToBase64:Result"] = value;

            // Create a new plugin response and expose the result in the entity.
            var pluginResponse = this.NewPluginResponse();

            // Include the Base64-encoded value in the plugin
            // response entity for downstream processing.
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["Result"] = value
            };

            // Return the plugin response to allow
            // downstream plugins to access the result.
            return pluginResponse;
        }
    }
}
