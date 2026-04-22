using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(ConvertFromBase64)}.json")]
    public class ConvertFromBase64(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Decode the Base64 argument, then apply the regular expression to the
            // decoded string. Only the first matched portion is kept as the result.
            var value = Regex
                .Match(pluginData.Rule.Argument.ConvertFromBase64(), pluginData.Rule.RegularExpression)
                .Value;

            // Store the decoded result in the session context for downstream plugins.
            Invoker.Context.SessionParameters["ConvertFromBase64:Result"] = value;

            // Create a new plugin response and expose the result in the entity.
            var pluginResponse = this.NewPluginResponse();

            // Construct the entity with the decoded
            // value, which downstream plugins can also access.
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["Result"] = value
            };

            // Return the plugin response to the caller,
            // which may be used by other plugins
            return pluginResponse;
        }
    }
}
