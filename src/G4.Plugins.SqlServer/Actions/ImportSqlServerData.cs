using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Clients;
using G4.Plugins.SqlServer.Extensions;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace G4.Plugins.SqlServer.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.SqlServer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.SqlServer.Actions.Manifests.{NameReference}.json")]
    public class ImportSqlServerData(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as ImportSqlServerData:<Name>.
        private const string NameReference = nameof(ImportSqlServerData);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the destination table, and the switches before opening any resource.
            var connectionModel = pluginData.ResolveConnection();
            var (schema, table) = SqlServerClient.ConvertToTableParts(
                tableName: pluginData.Parameters.Get(key: "Table", defaultValue: string.Empty));
            var batchSize = LocalExtensions.ConvertToNonNegativeInteger(
                value: pluginData.Parameters.Get(key: "BatchSize", defaultValue: string.Empty),
                defaultValue: 0);
            var noEntity = pluginData.TestSwitch(name: "NoEntity");
            var isTransaction = pluginData.TestSwitch(name: "Transaction");

            // Read the source rows before connecting so a malformed payload fails without opening a connection.
            using var data = ReadData(pluginData);

            // Open a connection owned by this step and start a transaction when requested.
            using var connection = SqlServerClient.OpenConnection(connectionModel);
            using var transaction = isTransaction ? connection.BeginTransaction() : null;

            // Map source columns to destination columns by name so the source column order does not matter.
            using var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction)
            {
                BatchSize = batchSize,
                BulkCopyTimeout = pluginData.ResolveCommandTimeout(),
                DestinationTableName = SqlServerClient.ConvertToQuotedName(schema, table)
            };

            foreach (DataColumn column in data.Columns)
            {
                bulkCopy.ColumnMappings.Add(sourceColumn: column.ColumnName, destinationColumn: column.ColumnName);
            }

            // Copy the rows; SQL Server converts the text values to the destination column types.
            bulkCopy.WriteToServer(data);

            // Commit only after every row was copied.
            transaction?.Commit();

            // Report the 64-bit copied row count as text so the session and the entity share one form.
            var outputs = new Dictionary<string, string>
            {
                ["RowsCopied"] = $"{bulkCopy.RowsCopied64}"
            };

            // Publish the copied row count as a Base64 session parameter and, unless suppressed, as the entity.
            return this.NewSqlServerResponse(nameReference: NameReference, outputs, noEntity);
        }

        // Reads the source rows from the inline Data argument (a JSON array) or from the DataFile argument (a .csv
        // file, or a JSON file for any other extension). Data wins when both are set. The returned table is owned
        // and disposed by the caller.
        private static DataTable ReadData(PluginDataModel pluginData)
        {
            // Prefer the inline JSON rows so a step can override a shared data file.
            var data = pluginData.Parameters.Get(key: "Data", defaultValue: string.Empty);

            if (!string.IsNullOrWhiteSpace(data))
            {
                return SqlServerClient.ConvertToDataTable(json: data);
            }

            // Fall back to the data file, selecting the parser by extension.
            var dataFile = pluginData.Parameters.Get(key: "DataFile", defaultValue: string.Empty);

            if (string.IsNullOrWhiteSpace(dataFile))
            {
                throw new InvalidOperationException("Either 'Data' or 'DataFile' is required.");
            }

            // Read the file once and parse it as CSV only for the .csv extension; every other extension is JSON.
            var content = File.ReadAllText(dataFile);
            var isCsv = string.Equals(Path.GetExtension(dataFile), ".csv", StringComparison.OrdinalIgnoreCase);

            return isCsv
                ? SqlServerClient.ConvertCsvToDataTable(csv: content)
                : SqlServerClient.ConvertToDataTable(json: content);
        }
    }
}
