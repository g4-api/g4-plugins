using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Transformers
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Transformers.Manifests.{nameof(EncodeBase64)}.json")]
    public class EncodeBase64(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract the original value from the rule's OnElement property.
            // In a transformer pipeline, the engine resolves OnElement to the value of the targeted field.
            var originalValue = pluginData.Rule.OnElement ?? string.Empty;

            // Encode the original value as a UTF-8 based Base64 string.
            var transformerResult = originalValue.ConvertToBase64();

            // Create and return a new PluginResponseModel with the encoded value.
            // The key "TransformerResult" identifies the result of this transformation.
            return this.NewTransformerResponse(transformerResult);
        }
    }
}
