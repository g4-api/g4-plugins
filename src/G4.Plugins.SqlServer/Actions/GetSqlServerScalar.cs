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
    public class GetSqlServerScalar(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as GetSqlServerScalar:<Name>.
        private const string NameReference = nameof(GetSqlServerScalar);

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

            // Read the first column of the first row; no row and a NULL value both yield an empty value.
            var value = command.ExecuteScalar();

            // Convert the value to its session text so strings stay raw and other values match the exported JSON.
            var outputs = new Dictionary<string, string>
            {
                ["Value"] = SqlServerClient.ConvertToText(value)
            };

            // Publish the value as a Base64 session parameter and, unless suppressed, as the entity.
            return this.NewSqlServerResponse(nameReference: NameReference, outputs, noEntity);
        }
    }
}
