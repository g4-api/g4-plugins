using G4.Attributes;
using G4.Models;
using G4.Plugins.SqlServer.Clients;
using G4.Plugins.SqlServer.Extensions;
using G4.Plugins.SqlServer.Models;

using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.SqlServer.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.SqlServer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.SqlServer.Actions.Manifests.{NameReference}.json")]
    public class ExportSqlServerQuery(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as ExportSqlServerQuery:<Name>.
        private const string NameReference = nameof(ExportSqlServerQuery);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the query, and its bound parameters before opening any resource.
            var connectionModel = pluginData.ResolveConnection();
            var commandText = pluginData.ResolveCommandText();
            var parameters = pluginData.ResolveSqlParameters();
            var noEntity = pluginData.TestSwitch(name: "NoEntity");

            // Open a connection owned by this step so no session state leaks into later steps.
            using var connection = SqlServerClient.OpenConnection(connectionModel);
            using var command = connection.CreateCommand();

            // Bind the user query and its parameters; values travel as parameters, never as command text.
            command.CommandText = commandText;
            command.CommandTimeout = pluginData.ResolveCommandTimeout();
            command.Parameters.AddRange([.. parameters]);

            // Read every result set so multi-statement queries keep all their rows.
            using var reader = command.ExecuteReader();
            var resultSets = SqlServerClient.ConvertToResultSets(reader);

            // Expose the first result set as the primary result and keep all result sets for multi-set queries.
            var result = resultSets.FirstOrDefault() ?? new SqlServerResultSetModel();
            var allRows = resultSets.Select(i => i.Rows);

            // Serialize the columns, the rows, and the row count once so the session and the entity share one form.
            var outputs = new Dictionary<string, string>
            {
                ["Columns"] = SqlServerClient.ConvertToJson(value: result.Columns),
                ["Result"] = SqlServerClient.ConvertToJson(value: result.Rows),
                ["ResultSets"] = SqlServerClient.ConvertToJson(value: allRows),
                ["RowCount"] = $"{result.Rows.Count}"
            };

            // Publish the minified JSON as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewSqlServerResponse(nameReference: NameReference, outputs, noEntity);
        }
    }
}
