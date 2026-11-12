using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Clients;
using G4.Plugins.MongoDb.Extensions;

using MongoDB.Bson;

using System;
using System.Collections.Generic;

namespace G4.Plugins.MongoDb.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.MongoDb, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.MongoDb.Actions.Manifests.{NameReference}.json")]
    public class InvokeMongoDbCommand(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as InvokeMongoDbCommand:<Name>.
        private const string NameReference = nameof(InvokeMongoDbCommand);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection and the command document before opening any resource.
            var connectionModel = pluginData.ResolveConnection();
            var json = pluginData.ResolveCommandText();
            var noEntity = pluginData.TestSwitch(name: "NoEntity");

            // Reject a step without a command so the failure names the missing argument.
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new InvalidOperationException("The 'CommandText' argument must carry the command document.");
            }

            // Parse the command; its first field names the command the server runs.
            var command = MongoDbClient.ConvertToDocument(json, argumentName: "CommandText");

            if (command.ElementCount == 0)
            {
                throw new InvalidOperationException("The command document must name a command in its first field.");
            }

            // Prefer the database the step names, then the one the connection resolved.
            var databaseName = pluginData.Parameters.Get(key: "Database", defaultValue: string.Empty);

            if (string.IsNullOrWhiteSpace(databaseName))
            {
                databaseName = connectionModel.Database;
            }

            // Open a client owned by this step so no session state leaks into later steps.
            using var client = MongoDbClient.OpenClient(connectionModel);
            var database = MongoDbClient.GetDatabase(client, databaseName);

            // Run the command; the server reports a rejected command as a driver exception, which fails the step.
            var response = database.RunCommand<BsonDocument>(command);

            // Report the whole response and its ok flag, so a flow can branch without parsing the response.
            var isOk = response.GetValue(name: "ok", defaultValue: new BsonInt32(0)).ToDouble() >= 1;

            var outputs = new Dictionary<string, string>
            {
                ["Database"] = database.DatabaseNamespace.DatabaseName,
                ["Ok"] = isOk ? "true" : "false",
                ["Result"] = MongoDbClient.ConvertToJson(value: response)
            };

            // Publish the command outcome as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewMongoDbResponse(nameReference: NameReference, outputs, noEntity);
        }
    }
}
