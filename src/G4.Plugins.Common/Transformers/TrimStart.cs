using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Transformers
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Transformers.Manifests.{nameof(TrimStart)}.json")]
    public class TrimStart(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the value of "TrimChars" from the plugin parameters.
            // If "TrimChars" is not provided, default to an empty string.
            var trimCharsValue = pluginData.Parameters.Get(key: "TrimChars", defaultValue: string.Empty);

            // Convert the "TrimChars" string to a character array.
            // If "TrimChars" is empty or null, use an empty character array.
            var trimChars = string.IsNullOrEmpty(trimCharsValue)
                ? []
                : trimCharsValue.ToCharArray();

            // Extract the original value from the rule's OnElement property.
            var originalValue = pluginData.Rule.OnElement;

            // Determine the transformed value by trimming specified characters from the start if provided.
            // If "TrimChars" has characters, trim those; otherwise, trim whitespace only.
            var transformerResult = trimChars.Length > 0
                ? originalValue.TrimStart(trimChars)
                : originalValue.TrimStart();

            // Create and return a new PluginResponseModel with the transformed value.
            // The key "TransformerResult" identifies the result of this transformation.
            return this.NewTransformerResponse(transformerResult);
        }
    }
}
