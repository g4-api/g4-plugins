using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Utilities;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.DataCollectors
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.DataCollectors.Manifests.{nameof(CsvDataCollector)}.json")]
    public class CsvDataCollector(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the file path from the arguments.
            var filePath = pluginData.Parameters["Source"];

            // Extract content from the extraction entities.
            var content = pluginData.Extraction.Entities.Select(entity => entity.Content);

            // If the file doesn't exist, create an empty CSV array file.
            if (!File.Exists(filePath))
            {
                var entity = content.First() ?? new Dictionary<string, object>();
                var headers = FormatCsvHeaders(entity);
                File.WriteAllText(filePath, headers);
            }

            // Writes content to a CSV file, appending it to the end of the file.
            WriteContent(filePath, content);

            // Return default PluginResponseModel as the result.
            return this.NewPluginResponse();
        }

        // Writes content to a CSV file, appending it to the end of the file.
        private static void WriteContent(string filePath, IEnumerable<IDictionary<string, object>> content)
        {
            // Generate a placeholder for an empty file with CSV headers.
            var emptyFilePlaceholder = FormatCsvHeaders(entity: content.First());

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
                    // Convert the entity to CSV format and store it in the 'Data' property.
                    Data = FormatCsvEntry(entity),

                    // Specify the placeholder for an empty file.
                    EmptyFilePlaceholder = emptyFilePlaceholder,

                    // Set the file path for writing the data.
                    File = filePath,

                    // Define a separator (if any) for the data.
                    Separator = "\n"
                };

                // Enqueue the 'fileConfiguration' for writing by the DataFilesWriter.
                DataFilesWriter.Enqueue(fileConfiguration);
            }
        }

        // Formats the headers for a CSV file.
        private static string FormatCsvHeaders(IDictionary<string, object> entity)
        {
            // Select and format each header, removing unwanted characters.
            var headers = entity.Keys.Select(header =>
            {
                // Remove commas and double quotes from the header.
                header = header.Replace(",", string.Empty).Replace("\"", string.Empty);

                // Remove line breaks and trim any remaining whitespace.
                return Regex.Replace(header, @"[\r\n]+", "").Trim();
            });

            // Join the formatted headers with commas and add a newline character.
            return string.Join(",", headers.ToArray()) + "\n";
        }

        // Formats an entity represented as a dictionary into a CSV string.
        private static string FormatCsvEntry(IDictionary<string, object> entity)
        {
            // Format each value in the entity using the FormatCsvValue method.
            var values = entity.Values.Select(FormatCsvValue).ToArray();

            // Join the formatted values with commas to create the CSV entry.
            return string.Join(",", values);
        }

        // Formats a value as a CSV field.
        private static string FormatCsvValue(object value)
        {
            // Check if the value is not a string, then convert it to a string.
            if (value is not string)
            {
                return $"{value}";
            }

            // Convert the value to a string.
            var stringValue = $"{value}";

            // If the string contains double quotes, escape them by doubling them.
            if (stringValue.Contains('"'))
            {
                stringValue = stringValue.Replace("\"", "\"\"");
            }

            // If the string contains commas or newlines, enclose it in double quotes.
            if (stringValue.Contains(',') || stringValue.Contains('\n'))
            {
                stringValue = $"\"{stringValue}\"";
            }

            // Return the formatted CSV field as a string.
            return stringValue;
        }
    }
}
