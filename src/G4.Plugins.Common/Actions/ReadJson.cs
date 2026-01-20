using G4.Attributes;
using G4.Extensions;
using G4.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(ReadJson)}.json")]
    public class ReadJson(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Determine whether the argument is a file path or raw JSON content.
            // If the file exists, read its contents; otherwise, treat the argument as inline JSON.
            var jsonData = File.Exists(pluginData.Rule.Argument)
                ? File.ReadAllText(pluginData.Rule.Argument)
                : pluginData.Rule.Argument;

            // Parse the JSON into a JObject for querying.
            var json = JObject.Parse(jsonData);

            // Select tokens using the provided JSONPath expression.
            var selected = json.SelectTokens(pluginData.Rule.OnElement);

            // Convert the selected tokens into a JSON array for uniform handling.
            var array = JArray.FromObject(selected);

            // If only a single item is found, serialize just that object;
            // otherwise, serialize the full array.
            var input = array.Count == 1
                ? array.First().ToString(Formatting.None).Trim('"')
                : array.ToString(Formatting.None).Trim('"');

            // Apply the regular expression (if provided) to the serialized JSON
            // and convert the matched value to Base64.
            // If no match is found, return an empty string.
            var jsonResult = Regex
                .Match(input, pattern: pluginData.Rule.RegularExpression)?
                .Value
                .ConvertToBase64() ?? string.Empty;

            // Store the result in the session context for downstream plugins.
            Invoker.Context.SessionParameters["ReadJsonResult"] = jsonResult;

            // Create a new plugin response.
            var pluginResponse = this.NewPluginResponse();

            // Expose the result in the response entity.
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["JsonResult"] = jsonResult
            };

            // Return the plugin response to the framework.
            return pluginResponse;
        }
    }
}
