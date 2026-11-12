using G4.Attributes;
using G4.Models;
using G4.Plugins.MongoDb.Clients;
using G4.Plugins.MongoDb.Extensions;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;

namespace G4.Plugins.MongoDb.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.MongoDb, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.MongoDb.Actions.Manifests.{NameReference}.json")]
    public class TestMongoDbConnection(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as TestMongoDbConnection:<Name>.
        private const string NameReference = nameof(TestMongoDbConnection);

        // Names the database the probe runs on when neither the connection nor the step selects one. Every
        // deployment has it, and both commands the probe sends are allowed there for any authenticated user.
        private const string ProbeDatabase = "admin";

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection first; an unresolvable target is a configuration error, not a probe result.
            var connectionModel = pluginData.ResolveConnection();
            var noEntity = pluginData.TestSwitch(name: "NoEntity");

            // Probe the database the connection selected, falling back to the one every deployment carries.
            var databaseName = string.IsNullOrWhiteSpace(connectionModel.Database)
                ? ProbeDatabase
                : connectionModel.Database;

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
                // Open a client owned by this probe; the driver contacts the server on the first command.
                using var client = MongoDbClient.OpenClient(connectionModel);
                var database = MongoDbClient.GetDatabase(client, databaseName);

                // Send the cheapest command that proves the deployment answers this client.
                database.RunCommand<BsonDocument>(command: new BsonDocument(name: "ping", value: 1));

                // Record the reached database so the flow can confirm the resolved target.
                outputs["Connected"] = "true";
                outputs["Database"] = database.DatabaseNamespace.DatabaseName;

                // Read the server version separately, so a deployment that withholds it still reports as connected.
                outputs["ServerVersion"] = ReadServerVersion(database);
            }
            catch (Exception exception) when (exception is MongoException or TimeoutException)
            {
                // Record the driver message so the flow can report why the deployment is unreachable.
                outputs["Error"] = exception.Message;
            }

            // Publish the probe outcome as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewMongoDbResponse(nameReference: NameReference, outputs, noEntity);
        }

        // Reads the server version through the buildInfo command, reporting an empty version when the connected user
        // may not run it. Compute-only beyond the one command it sends.
        private static string ReadServerVersion(IMongoDatabase database)
        {
            try
            {
                // Read the version field of the build information document.
                var command = new BsonDocument(name: "buildInfo", value: 1);
                var buildInfo = database.RunCommand<BsonDocument>(command);

                return buildInfo.GetValue(name: "version", defaultValue: BsonString.Empty).AsString;
            }
            catch (MongoException)
            {
                // Report no version rather than failing the probe, because the connection itself already succeeded.
                return string.Empty;
            }
        }
    }
}
