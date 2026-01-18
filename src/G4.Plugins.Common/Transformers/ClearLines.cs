using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Transformers
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Transformers.Manifests.{nameof(ClearLines)}.json")]
    public class ClearLines(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract the target value from the rule's OnElement property.
            // This assumes that OnElement contains the content to be processed.
            var originalValue = pluginData.Rule.OnElement;

            // Define a regular expression pattern to match one or more carriage return or newline characters.
            const string pattern = @"[\r\n]+";

            // Replace all line breaks in the original value with an empty string, effectively removing them.
            var transformerResult = Regex.Replace(input: originalValue, pattern, replacement: string.Empty);

            // Create and return a new PluginResponseModel with the cleaned value.
            // The key "TransformerResult" is used to identify the result of the transformation.
            return this.NewTransformerResponse(transformerResult);
        }
    }
}
