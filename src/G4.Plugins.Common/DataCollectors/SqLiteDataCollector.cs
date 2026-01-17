using G4.Attributes;
using G4.Extensions;
using G4.Models;

using Microsoft.Data.Sqlite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G4.Plugins.Common.DataCollectors
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.DataCollectors.Manifests.{nameof(SqLiteDataCollector)}.json")]
    public class SqLiteDataCollector(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Determine temporary folder and default database file path
            var tempPath = Path.GetTempPath();
            var defaultDbPath = Path.Combine(tempPath, "G4DataCollector.db");

            // Read the 'Source' parameter, falling back to the default database path if missing
            var dbPath = pluginData.Parameters.Get(
                key: "Source",
                defaultValue: defaultDbPath);

            // Read the 'Repository' parameter to use as the table name, defaulting if absent
            var tableName = pluginData.Parameters.Get(
                key: "Repository",
                defaultValue: "default-warehouse");

            // Build the SQLite connection string using the resolved file path
            var connectionString = $"Data Source={dbPath}";

            // Extract the content dictionaries from the plugin's entity extraction results
            var content = pluginData
                .Extraction
                .Entities
                .Select(entity => entity.Content);

            // Peek at the first entity (if any) to infer table schema
            var entity = content.FirstOrDefault();

            // Generate the CREATE TABLE SQL statement based on the table name and sample entity
            var createCommandSql = GetCreateStatement(tableName, entity);

            // Open a connection to the SQLite database file
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            // Create the table if it does not already exist
            using (var createCommand = connection.CreateCommand())
            {
                createCommand.CommandText = createCommandSql;
                createCommand.ExecuteNonQuery();
            }

            // Insert all extracted rows into the newly created (or existing) table
            WriteContent(connection, tableName, content);

            // Return a fresh PluginResponseModel to indicate completion
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

        // Inserts a batch of row data into the specified SQLite table.
        private static void WriteContent(SqliteConnection connection, string tableName, IEnumerable<IDictionary<string, object>> content)
        {
            // Iterate over each row's data dictionary
            foreach (var contentEntries in content)
            {
                // Build comma-separated list of column names, properly formatted
                var columns = string.Join(", ", contentEntries.Keys.Select(FormatDataEntry));

                // Build comma-separated list of parameter placeholders (@ColumnName)
                var parameters = string.Join(", ", contentEntries.Keys.Select(key => $"@{key}"));

                // Compose the INSERT SQL statement
                var insertSql =
                    $"INSERT INTO {FormatDataEntry(tableName)} " +
                    $"({columns}) VALUES ({parameters});";

                // Create a command to execute the INSERT
                using var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = insertSql;

                // Add each column value as a parameter to prevent SQL injection
                foreach (var contentEntry in contentEntries)
                {
                    // If the value is null, use DBNull for the parameter
                    insertCommand
                        .Parameters
                        .AddWithValue($"@{contentEntry.Key}", contentEntry.Value ?? DBNull.Value);
                }

                // Execute the INSERT and advance to the next row
                insertCommand.ExecuteNonQuery();
            }
        }
    }
}
