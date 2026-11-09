using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Clients;
using G4.Plugins.SqlServer.Extensions;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;

namespace G4.Plugins.SqlServer.DataCollectors
{
    [G4Plugin(
        assembly: "G4.Plugins.SqlServer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.SqlServer.DataCollectors.Manifests.{nameof(SqlServerDataCollector)}.json")]
    public class SqlServerDataCollector(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Names the destination table when the rule sets no Repository, matching the SQLite collector default.
        private const string DefaultRepository = "default-warehouse";

        // Declares the SqlParameter size that maps the column-list parameter to NVARCHAR(MAX), so any key count fits.
        private const int MaximumTextSize = -1;

        // Ensures the destination schema, table, and columns exist. The batch is static: the schema, table, and
        // column names arrive as parameters and are quoted on the server with QUOTENAME, so no identifier is ever
        // composed into client-side command text. New tables and columns are NVARCHAR(MAX) NULL, existing columns and
        // rows are never altered. Requires SQL Server 2017 or later (STRING_AGG and OPENJSON).
        private const string EnsureTableCommandText =
            """
            DECLARE @qualifiedName NVARCHAR(300) = QUOTENAME(@Schema) + N'.' + QUOTENAME(@Table);
            DECLARE @statement NVARCHAR(MAX);

            IF SCHEMA_ID(@Schema) IS NULL
            BEGIN
                SET @statement = N'CREATE SCHEMA ' + QUOTENAME(@Schema) + N';';
                EXEC sys.sp_executesql @statement;
            END;

            IF OBJECT_ID(@qualifiedName, N'U') IS NULL
            BEGIN
                SELECT @statement = N'CREATE TABLE ' + @qualifiedName + N' (' +
                    STRING_AGG(CAST(QUOTENAME(columns.[value]) + N' NVARCHAR(MAX) NULL' AS NVARCHAR(MAX)), N', ') +
                    N');'
                FROM OPENJSON(@Columns) AS columns;

                EXEC sys.sp_executesql @statement;
            END
            ELSE
            BEGIN
                SELECT @statement = STRING_AGG(CAST(N'ALTER TABLE ' + @qualifiedName + N' ADD ' +
                    QUOTENAME(columns.[value]) + N' NVARCHAR(MAX) NULL;' AS NVARCHAR(MAX)), N' ')
                FROM OPENJSON(@Columns) AS columns
                WHERE COL_LENGTH(@qualifiedName, columns.[value]) IS NULL;

                IF @statement IS NOT NULL
                BEGIN
                    EXEC sys.sp_executesql @statement;
                END;
            END;
            """;

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the Source (credentials name, raw connection string, or token) and the Repository (table) of the
            // rule, so the destination table is validated before any entity is converted.
            var rule = (DataCollectorRuleModel)pluginData.Rule;
            var repository = string.IsNullOrWhiteSpace(rule.Repository) ? DefaultRepository : rule.Repository;
            var (schema, table) = SqlServerClient.ConvertToTableParts(tableName: repository);

            // Collect the extracted entities; an extraction without entities has nothing to write.
            var entities = pluginData
                .Extraction?
                .Entities?
                .Select(i => i.Content)
                .Where(i => i is not null)
                .ToArray() ?? [];

            if (entities.Length == 0)
            {
                return this.NewPluginResponse();
            }

            // Build the union of the content keys of every entity, so later entities with new keys still map to
            // columns.
            var columns = entities
                .SelectMany(i => i.Keys)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            // Convert the entities before connecting so an unaddressable content key fails without a connection.
            using var data = NewDataTable(columns, entities);

            // Resolve the connection from the rule Source alone; the collector rule carries no discrete overrides.
            var connectionModel = LocalExtensions.ResolveConnection(
                credentials: rule.Source,
                connectionString: string.Empty,
                overrides: null);

            // Open a connection owned by this collector run so no session state leaks into later runs.
            using var connection = SqlServerClient.OpenConnection(connectionModel);

            // Create the schema, the table, or the missing columns through the static server-side batch; the names
            // travel only as bound parameters, so the command text never changes.
            using (var command = connection.CreateCommand())
            {
                var schemaParameter = new SqlParameter(
                    parameterName: "@Schema",
                    dbType: SqlDbType.NVarChar,
                    size: SqlServerClient.MaximumIdentifierLength)
                {
                    Value = schema
                };

                var tableParameter = new SqlParameter(
                    parameterName: "@Table",
                    dbType: SqlDbType.NVarChar,
                    size: SqlServerClient.MaximumIdentifierLength)
                {
                    Value = table
                };

                var columnsParameter = new SqlParameter(
                    parameterName: "@Columns",
                    dbType: SqlDbType.NVarChar,
                    size: MaximumTextSize)
                {
                    Value = JsonSerializer.Serialize(columns)
                };

                command.CommandText = EnsureTableCommandText;
                command.Parameters.Add(schemaParameter);
                command.Parameters.Add(tableParameter);
                command.Parameters.Add(columnsParameter);

                // Run the batch before the bulk copy so every destination column exists when the rows arrive.
                command.ExecuteNonQuery();
            }

            // Prepare one bulk copy into the quoted destination, mapping columns by name so key order never matters.
            using var bulkCopy = new SqlBulkCopy(connection)
            {
                DestinationTableName = SqlServerClient.ConvertToQuotedName(schema, table)
            };

            foreach (var column in columns)
            {
                bulkCopy.ColumnMappings.Add(sourceColumn: column, destinationColumn: column);
            }

            // Insert every entity in one round trip; a failure surfaces to the engine as the collector error.
            bulkCopy.WriteToServer(data);

            // Report success without an entity; the collector output is the written table itself.
            return this.NewPluginResponse();
        }

        // Creates a string-typed table with one row per entity. String values are stored raw, null values become
        // DBNull, and every other value is stored as its minified JSON text so nested content survives the copy.
        private static DataTable NewDataTable(string[] columns, IDictionary<string, object>[] entities)
        {
            // Declare one string column per content key, rejecting names SQL Server cannot address.
            var table = new DataTable();

            foreach (var column in columns)
            {
                var isTooLong = column.Length > SqlServerClient.MaximumIdentifierLength;

                // Reject a key QUOTENAME cannot quote so the failure names the offending content key.
                if (isTooLong)
                {
                    var message = $"The content key '{column}' exceeds " +
                        $"{SqlServerClient.MaximumIdentifierLength} characters.";
                    throw new InvalidOperationException(message);
                }

                table.Columns.Add(columnName: column, type: typeof(string));
            }

            // Copy each entity into a row, matching keys case-insensitively like SQL Server column names.
            foreach (var entity in entities)
            {
                var content = new Dictionary<string, object>(entity, StringComparer.OrdinalIgnoreCase);
                var row = table.NewRow();

                // Fill every declared column; a key the entity lacks becomes DBNull.
                foreach (var column in columns)
                {
                    row[column] = content.TryGetValue(column, out var value) ? ConvertToCellValue(value) : DBNull.Value;
                }

                // Attach the row only after every cell is set.
                table.Rows.Add(row);
            }

            return table;
        }

        // Converts one entity content value into the stored cell value. Compute-only: it owns no state and never
        // throws for supported content, because every non-string value has a JSON text form.
        private static object ConvertToCellValue(object value)
        {
            // Keep nulls and strings as-is and serialize everything else to minified JSON text.
            return value switch
            {
                null => DBNull.Value,
                string text => text,
                _ => SqlServerClient.ConvertToJson(value)
            };
        }
    }
}
