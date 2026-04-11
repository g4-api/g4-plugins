using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using UglyToad.PdfPig;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(ReadPdfFile)}.json")]
    public class ReadPdfFile(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a constant for the plugin name reference to ensure
        // consistent namespacing of session parameters.
        private const string NameReference = nameof(ReadPdfFile);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the file path from the rule argument.
            var filePath = pluginData.Rule.Argument;

            // Read file content based on extension.
            // PDF files are processed with PdfPig; all other types are read as plain text.
            string content;
            if (Path.GetExtension(filePath).Equals(".pdf", System.StringComparison.OrdinalIgnoreCase))
            {
                using var document = PdfDocument.Open(filePath);
                var stringBuilder = new StringBuilder();
                foreach (var page in document.GetPages())
                {
                    stringBuilder.AppendLine(string.Join(" ", page.GetWords().Select(i => i.Text)));
                }
                content = stringBuilder.ToString();
            }
            else
            {
                content = File.ReadAllText(filePath);
            }

            // Apply the regular expression to the file content and convert the matched value to Base64.
            // If no match is found, fall back to an empty string.
            var fileResult = Regex
                .Match(content, pattern: pluginData.Rule.RegularExpression)?
                .Value
                .ConvertToBase64() ?? string.Empty;

            // Store the list of copied resources in the session parameters
            this.AddSessionParameter(
                @namespace: NameReference,
                name: "Content",
                value: content);

            // Create a new plugin response.
            var pluginResponse = this.NewPluginResponse();

            // Expose the result in the response entity.
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["Content"] = content
            };

            // Return the plugin response to the framework.
            return pluginResponse;
        }
    }
}
