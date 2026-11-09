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
    public class InvokeSqlServerScript(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as InvokeSqlServerScript:<Name>.
        private const string NameReference = nameof(InvokeSqlServerScript);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the script batches, and the switches before opening resources.
            var connectionModel = pluginData.ResolveConnection();
            var batches = SqlServerClient.ConvertToBatches(script: pluginData.ResolveCommandText());
            var commandTimeout = pluginData.ResolveCommandTimeout();
            var noEntity = pluginData.TestSwitch(name: "NoEntity");
            var isTransaction = pluginData.TestSwitch(name: "Transaction");

            // Open a connection owned by this step so SET options and temp tables span only its own batches.
            using var connection = SqlServerClient.OpenConnection(connectionModel);

            // Start a transaction when requested so a failing batch rolls back every earlier batch.
            using var transaction = isTransaction ? connection.BeginTransaction() : null;

            // Accumulate the affected rows across batches so the script reports one total.
            var rowsAffected = 0L;

            // Run the batches in script order; the first failing batch stops the script.
            foreach (var batch in batches)
            {
                // Bind each batch to its own command that joins the shared connection and optional transaction.
                using var command = connection.CreateCommand();

                command.CommandText = batch;
                command.CommandTimeout = commandTimeout;
                command.Transaction = transaction;

                // Count only real row counts; DDL and SET statements report -1.
                var count = command.ExecuteNonQuery();
                rowsAffected += count > 0 ? count : 0;
            }

            // Commit only after every batch succeeded.
            transaction?.Commit();

            // Report the batch count and the row total as text so the session and the entity share one form.
            var outputs = new Dictionary<string, string>
            {
                ["BatchCount"] = $"{batches.Count}",
                ["RowsAffected"] = $"{rowsAffected}"
            };

            // Publish the script outcome as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewSqlServerResponse(nameReference: NameReference, outputs, noEntity);
        }
    }
}
