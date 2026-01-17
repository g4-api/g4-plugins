using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Utilities;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace G4.Plugins.Common.DataCollectors
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.DataCollectors.Manifests.{nameof(JsonDataCollector)}.json")]
    public class JsonDataCollector(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the file path from the arguments.
            var filePath = pluginData.Parameters["Source"];

            // Extract content from the extraction entities.
            var content = pluginData.Extraction.Entities.Select(entity => entity.Content);

            // If the file doesn't exist, create an empty JSON array file.
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            // Writes content to a JSON file, appending it to the end of the file.
            WriteContent(filePath, content);

            // Return default PluginResponseModel as the result.
            return this.NewPluginResponse();
        }

        // Writes content to a JSON file, appending it to the end of the file.
        private static void WriteContent(string filePath, IEnumerable<IDictionary<string, object>> content)
        {
            // Iterate through each entity in the 'content' collection.
            foreach (var entity in content)
            {
                // If the entity is null or empty, skip to the next entity.
                if (entity?.Any() != true)
                {
                    continue;
                }

                // Create a new 'FileConfiguration' for the DataFilesWriter.
                var fileConfiguration = new DataFilesWriter.FileConfiguration
                {
                    // Specify the closing bytes for the data.
                    CloseBytes = "]",

                    // Convert the entity to JSON format and store it in the 'Data' property.
                    Data = JsonSerializer.Serialize(entity),

                    // Specify the placeholder for an empty file.
                    EmptyFilePlaceholder = "[]",

                    // Set the file path for writing the data.
                    File = filePath,

                    // Define a separator (if any) for the data.
                    Separator = ","
                };

                // Enqueue the 'fileConfiguration' for writing by the DataFilesWriter.
                DataFilesWriter.Enqueue(fileConfiguration);
            }
        }
    }
}
