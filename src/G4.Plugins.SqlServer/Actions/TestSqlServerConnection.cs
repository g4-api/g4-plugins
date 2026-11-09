using G4.Attributes;
using G4.Models;
using G4.Plugins.SqlServer.Clients;
using G4.Plugins.SqlServer.Extensions;

using Microsoft.Data.SqlClient;

using System.Collections.Generic;

namespace G4.Plugins.SqlServer.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.SqlServer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.SqlServer.Actions.Manifests.{NameReference}.json")]
    public class TestSqlServerConnection(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as TestSqlServerConnection:<Name>.
        private const string NameReference = nameof(TestSqlServerConnection);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection first; an unresolvable target is a configuration error, not a probe result.
            var connectionModel = pluginData.ResolveConnection();
            var noEntity = pluginData.TestSwitch(name: "NoEntity");

            // Report the probe outcome instead of failing, so a flow can branch on server availability.
            var outputs = new Dictionary<string, string>
            {
                ["Connected"] = "false",
                ["Database"] = string.Empty,
                ["Error"] = string.Empty,
                ["ServerVersion"] = string.Empty
            };

            try
            {
                // Open and immediately release a connection owned by this probe.
                using var connection = SqlServerClient.OpenConnection(connectionModel);

                // Record the reached database and server version so the flow can confirm the resolved target.
                outputs["Connected"] = "true";
                outputs["Database"] = connection.Database;
                outputs["ServerVersion"] = connection.ServerVersion;
            }
            catch (SqlException exception)
            {
                // Record the provider message so the flow can report why the server is unreachable.
                outputs["Error"] = exception.Message;
            }

            // Publish the probe outcome as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewSqlServerResponse(nameReference: NameReference, outputs, noEntity);
        }
    }
}
