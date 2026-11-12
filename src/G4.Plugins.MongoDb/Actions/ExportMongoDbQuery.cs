using G4.Attributes;
using G4.Models;
using G4.Plugins.MongoDb.Clients;
using G4.Plugins.MongoDb.Extensions;

using MongoDB.Bson;
using MongoDB.Driver;

using System.Collections.Generic;

namespace G4.Plugins.MongoDb.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.MongoDb, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.MongoDb.Actions.Manifests.{NameReference}.json")]
    public class ExportMongoDbQuery(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as ExportMongoDbQuery:<Name>.
        private const string NameReference = nameof(ExportMongoDbQuery);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the collection, and the query shape before opening any resource.
            var connectionModel = pluginData.ResolveConnection();
            var collectionName = pluginData.ResolveRequired(name: "Collection");
            var filter = MongoDbClient.ConvertToDocument(
                json: pluginData.ResolveCommandText(),
                argumentName: "CommandText");
            var noEntity = pluginData.TestSwitch(name: "NoEntity");

            // Read the shaping arguments; an empty projection or sort document means the option is not set.
            var projection = pluginData.ResolveDocument(name: "Projection");
            var sort = pluginData.ResolveDocument(name: "Sort");
            var limit = pluginData.ResolveInteger(name: "Limit", defaultValue: 0);
            var skip = pluginData.ResolveInteger(name: "Skip", defaultValue: 0);

            // Bind only the options the step sets, so an unset option keeps the server default.
            var options = new FindOptions<BsonDocument, BsonDocument>
            {
                MaxTime = pluginData.ResolveMaxTime(),
                Projection = projection.ElementCount > 0 ? projection : null,
                Sort = sort.ElementCount > 0 ? sort : null,
                Limit = limit > 0 ? limit : null,
                Skip = skip > 0 ? skip : null
            };

            // Open a client owned by this step so no session state leaks into later steps.
            using var client = MongoDbClient.OpenClient(connectionModel);
            var collection = MongoDbClient.GetCollection(client, connectionModel, collectionName);

            // Read every matching document; the filter travels as BSON, never as composed command text.
            using var cursor = collection.FindSync(filter, options);
            var result = MongoDbClient.NewResultSet(documents: cursor.ToEnumerable());

            // Serialize the field names, the documents, and the document count once so the session and the entity
            // share one form.
            var outputs = new Dictionary<string, string>
            {
                ["Columns"] = MongoDbClient.ConvertToJson(values: result.Columns),
                ["DocumentCount"] = $"{result.Documents.Count}",
                ["Result"] = MongoDbClient.ConvertToJson(documents: result.Documents)
            };

            // Publish the Extended JSON as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewMongoDbResponse(nameReference: NameReference, outputs, noEntity);
        }
    }
}
