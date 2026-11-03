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

            // Get the data collector rule that carries the 'Source' and 'Repository' properties
            var rule = (DataCollectorRuleModel)pluginData.Rule;

            // Read the 'Source' property, falling back to the default database path if missing
            var dbPath = string.IsNullOrEmpty(rule.Source)
                ? defaultDbPath
                : rule.Source;

            // Read the 'Repository' property to use as the table name, defaulting if absent
            var tableName = string.IsNullOrEmpty(rule.Repository)
                ? "default-warehouse"
                : rule.Repository;

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

            // Add the columns an existing table lacks so a repository created by an earlier, narrower
            // extraction accepts rows that carry new content keys instead of failing the insert
            AddMissingColumns(connection, tableName, content);

            // Insert all extracted rows into the newly created (or existing) table
            WriteContent(connection, tableName, content);

            // Return a fresh PluginResponseModel to indicate completion
            return this.NewPluginResponse();
        }

        // Adds every content key that the existing table does not yet define as a new column.
        // CREATE TABLE IF NOT EXISTS leaves an existing table untouched, so without this step a key added to
        // the extraction after the table was first created makes every later insert fail. Existing columns and
        // rows are never altered or removed; new columns start empty (NULL) for the rows already stored.
        private static void AddMissingColumns(
            SqliteConnection connection,
            string tableName,
            IEnumerable<IDictionary<string, object>> content)
        {
            // Read the table's current column names through the pragma table function, binding the table name
            // as a value so the lookup itself needs no identifier formatting
            const string ColumnsQuery = "SELECT name FROM pragma_table_info(@tableName);";
            var existingColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            using (var columnsCommand = connection.CreateCommand())
            {
                columnsCommand.CommandText = ColumnsQuery;
                columnsCommand.Parameters.AddWithValue("@tableName", tableName);

                // Collect the names case-insensitively, matching how SQLite resolves column identifiers
                using var reader = columnsCommand.ExecuteReader();
                while (reader.Read())
                {
                    existingColumns.Add(reader.GetString(0));
                }
            }

            // Find each missing key across all rows, not only the first one, keeping the first value seen
            // for each key so the column type is inferred the same way CREATE TABLE infers it
            var missingColumns = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            foreach (var key in content.SelectMany(entity => entity.Keys))
            {
                var isKnown = existingColumns.Contains(key) || missingColumns.ContainsKey(key);
                if (isKnown)
                {
                    continue;
                }

                missingColumns[key] = content.First(entity => entity.ContainsKey(key))[key];
            }

            // Add each missing column; SQLite identifiers cannot be bound as parameters, so the column and
            // table names are escaped and quoted the same way the CREATE TABLE statement quotes them
            foreach (var (columnName, value) in missingColumns)
            {
                // Compose the ALTER TABLE statement that appends the column with its inferred type
                var addColumnSql =
                    $"ALTER TABLE {FormatDataEntry(tableName)} " +
                    $"ADD COLUMN {FormatDataEntry(columnName)} {GetColumnType(value)};";

                // Apply the schema change before any row of this batch is inserted
                using var alterCommand = connection.CreateCommand();
                alterCommand.CommandText = addColumnSql;
                alterCommand.ExecuteNonQuery();
            }
        }

        // Escapes and quotes a data entry for use in SQLite (or other SQL) statements.
        private static string FormatDataEntry(string dataEntry)
        {
            // Replace each double-quote with two double-quotes to escape it
            var escaped = dataEntry.Replace("\"", "\"\"");

            // Wrap the escaped identifier in double quotes
            return $"\"{escaped}\"";
        }

        // Maps a .NET object's CLR type to the appropriate SQLite column type.
        // Shared by CREATE TABLE and ALTER TABLE so a column added later gets the same type a new table would.
        private static string GetColumnType(object value)
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

        // Builds a SQLite <c>CREATE TABLE IF NOT EXISTS</c> statement for the given table name and entity definition.
        private static string GetCreateStatement(string tableName, IDictionary<string, object> entity)
        {
            // Validate that there is at least one column definition
            if (entity == null || entity.Count == 0)
            {
                throw new ArgumentException("Entity must have at least one column", nameof(entity));
            }

            // Build each column definition: quoted name + inferred type
            var columnDefinition = entity
                .Select(kv => $"{FormatDataEntry(kv.Key)} {GetColumnType(kv.Value)}")
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
                // Snapshot the row once so column names and parameter values keep the same order
                var entries = contentEntries.ToArray();

                // Build comma-separated list of column names, properly formatted
                var columns = string.Join(", ", entries.Select(entry => FormatDataEntry(entry.Key)));

                // Build positional parameter placeholders (@p0, @p1, ...) instead of deriving them from the
                // content keys, so keys with '-', spaces or other non-identifier characters bind correctly
                var parameters = string.Join(", ", entries.Select((_, index) => $"@p{index}"));

                // Compose the INSERT SQL statement
                var insertSql =
                    $"INSERT INTO {FormatDataEntry(tableName)} " +
                    $"({columns}) VALUES ({parameters});";

                // Create a command to execute the INSERT
                using var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = insertSql;

                // Add each column value as a positional parameter to prevent SQL injection
                for (int i = 0; i < entries.Length; i++)
                {
                    // If the value is null, use DBNull for the parameter
                    insertCommand
                        .Parameters
                        .AddWithValue($"@p{i}", entries[i].Value ?? DBNull.Value);
                }

                // Execute the INSERT and advance to the next row
                insertCommand.ExecuteNonQuery();
            }
        }
    }
}
