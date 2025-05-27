using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Utilities;

using Microsoft.Data.Sqlite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G4.Plugins.Common.DataCollectors
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.DataCollectors.Manifests.{nameof(SqlLiteDataCollector)}.json")]
    public class SqlLiteDataCollector(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            var tempPath = $"{Path.GetTempPath()}";
            var defaultDbName = Path.Combine(tempPath, "g4-data-collector.db");


            var dbName = pluginData.Parameters.Get(key: "Source", defaultValue: defaultDbName);
            var tableName = pluginData.Parameters.Get(key: "Repository", defaultValue: "default-warehouse");
            var connectionString = $"Data Source={dbName}";

            var content = pluginData.Extraction.Entities.Select(entity => entity.Content);
            var entity = content.FirstOrDefault();
            var createCommandSql = GetCreateStatement(tableName, entity);

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            using (var createCommand = connection.CreateCommand())
            {
                createCommand.CommandText = createCommandSql;
                createCommand.ExecuteNonQuery();
            }


            // 2. Build INSERT statement
            foreach (var data in content)
            {
                var columns = string.Join(", ", data.Keys.Select(FormatDataEntry));
                var parameters = string.Join(", ", data.Keys.Select(col => $"@{col}"));
                var insertSql = $"INSERT INTO {FormatDataEntry(tableName)} ({columns}) VALUES ({parameters});";

                using var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = insertSql;

                // Add parameter values
                foreach (var kv in data)
                {
                    insertCmd.Parameters.AddWithValue($"@{kv.Key}", kv.Value ?? DBNull.Value);
                }

                insertCmd.ExecuteNonQuery();
            }

            // Return default PluginResponseModel as the result.
            return this.NewPluginResponse();
        }

        // Escapes and quotes a data entry for use in SQLite (or other SQL) statements.
        private static string FormatDataEntry(string dataEntry)
        {
            // Replace each double-quote with two double-quotes to escape it
            var escaped = dataEntry.Replace("\"", "\"\"");

            // Wrap the escaped identifier in double quotes
            return $"\"{escaped}\"";
        }

        // Builds a SQLite <c>CREATE TABLE IF NOT EXISTS</c> statement for the given table name and entity definition.
        private static string GetCreateStatement(string tableName, IDictionary<string, object> entity)
        {
            // Maps a .NET object's CLR type to the appropriate SQLite column type.
            static string FormatTypes(object value)
            {
                // Get the runtime type of the value, or default to string if value is null
                var type = value?.GetType() ?? typeof(string);

                // Byte arrays are stored as BLOBs
                if (type == typeof(byte[]))
                {
                    return "BLOB";
                }

                // Determine if the type is any of the integer types (including bool)
                var isInteger = type == typeof(bool)
                    || type == typeof(byte)
                    || type == typeof(sbyte)
                    || type == typeof(short)
                    || type == typeof(ushort)
                    || type == typeof(int)
                    || type == typeof(uint)
                    || type == typeof(long)
                    || type == typeof(ulong);
                if (isInteger)
                {
                    return "INTEGER";
                }

                // Determine if the type is a floating-point or decimal type
                var isReal = type == typeof(float)
                    || type == typeof(double)
                    || type == typeof(decimal);
                if (isReal)
                {
                    return "REAL";
                }

                // Determine if the type represents date/time data
                var isDate = type == typeof(DateTime)
                    || type == typeof(DateTimeOffset)
                    || type == typeof(TimeSpan);
                if (isDate)
                {
                    // Store DateTime/TimeSpan values as ISO-8601 text
                    return "TEXT";
                }

                // Fallback: store everything else (strings, enums, custom types) as TEXT
                return "TEXT";
            }

            // Validate that there is at least one column definition
            if (entity == null || entity.Count == 0)
            {
                throw new ArgumentException("Entity must have at least one column", nameof(entity));
            }

            // Build each column definition: quoted name + inferred type
            var columnDefinition = entity
                .Select(kv => $"{FormatDataEntry(kv.Key)} {FormatTypes(kv.Value)}")
                .ToArray();

            // Assemble and return the full CREATE TABLE statement
            return
                $"CREATE TABLE IF NOT EXISTS {FormatDataEntry(tableName)} " +
                $"({string.Join(", ", columnDefinition)});";
        }

        // Writes content to a XML file, appending it to the end of the file.
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
                    CloseBytes = "</DataRoot>",

                    // Convert the entity to XML format and store it in the 'Data' property.
                    Data = entity.ConvertToXml().ToString(),

                    // Specify the placeholder for an empty file.
                    EmptyFilePlaceholder = "<DataRoot></DataRoot>",

                    // Set the file path for writing the data.
                    File = filePath,

                    // Define a separator (if any) for the data.
                    Separator = string.Empty
                };

                // Enqueue the 'fileConfiguration' for writing by the DataFilesWriter.
                DataFilesWriter.Enqueue(fileConfiguration);
            }
        }
    }
}
