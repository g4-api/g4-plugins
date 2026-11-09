using G4.Attributes;
using G4.Models;
using G4.Plugins.SqlServer.Clients;
using G4.Plugins.SqlServer.Extensions;

using System.Collections.Generic;

namespace G4.Plugins.SqlServer.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.SqlServer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.SqlServer.Actions.Manifests.{NameReference}.json")]
    public class InvokeSqlServerNonQuery(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as InvokeSqlServerNonQuery:<Name>.
        private const string NameReference = nameof(InvokeSqlServerNonQuery);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the statement, its bound parameters, and the switches before opening resources.
            var connectionModel = pluginData.ResolveConnection();
            var commandText = pluginData.ResolveCommandText();
            var parameters = pluginData.ResolveSqlParameters();
            var noEntity = pluginData.TestSwitch(name: "NoEntity");
            var isTransaction = pluginData.TestSwitch(name: "Transaction");

            // Open a connection owned by this step so no session state leaks into later steps.
            using var connection = SqlServerClient.OpenConnection(connectionModel);

            // Start a transaction when requested so a failing statement leaves no partial change.
            using var transaction = isTransaction ? connection.BeginTransaction() : null;
            using var command = connection.CreateCommand();

            // Bind the user statement and its parameters; values travel as parameters, never as command text.
            command.CommandText = commandText;
            command.CommandTimeout = pluginData.ResolveCommandTimeout();
            command.Transaction = transaction;
            command.Parameters.AddRange([.. parameters]);

            // Execute the statement; an exception disposes the open transaction, which rolls it back.
            var rowsAffected = command.ExecuteNonQuery();

            // Commit only after the statement succeeded.
            transaction?.Commit();

            // Report the provider row count as text so the session and the entity share one form.
            var outputs = new Dictionary<string, string>
            {
                ["RowsAffected"] = $"{rowsAffected}"
            };

            // Publish the affected row count as a Base64 session parameter and, unless suppressed, as the entity.
            return this.NewSqlServerResponse(nameReference: NameReference, outputs, noEntity);
        }
    }
}
