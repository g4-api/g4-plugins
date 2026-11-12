using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Clients;
using G4.Plugins.MongoDb.Extensions;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.MongoDb.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.MongoDb, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.MongoDb.Actions.Manifests.{NameReference}.json")]
    public class GetMongoDbScalar(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as GetMongoDbScalar:<Name>.
        private const string NameReference = nameof(GetMongoDbScalar);

        // Counts the matching documents, which is the mode a step gets without naming one.
        private const string CountMode = "Count";

        // Collects the distinct values of one field across the matching documents.
        private const string DistinctMode = "Distinct";

        // Reads one field of the first matching document.
        private const string FieldMode = "Field";

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the collection, the mode, and the filter before opening any resource.
            var connectionModel = pluginData.ResolveConnection();
            var collectionName = pluginData.ResolveRequired(name: "Collection");
            var mode = pluginData.Parameters.Get(key: "Mode", defaultValue: CountMode);
            var filter = MongoDbClient.ConvertToDocument(
                json: pluginData.ResolveCommandText(),
                argumentName: "CommandText");
            var noEntity = pluginData.TestSwitch(name: "NoEntity");

            // Open a client owned by this step so no session state leaks into later steps.
            using var client = MongoDbClient.OpenClient(connectionModel);
            var collection = MongoDbClient.GetCollection(client, connectionModel, collectionName);

            // Select the single value the step asked for; an unknown mode names the accepted values. The declared
            // type keeps each reader free to report its own BSON type.
            BsonValue value = mode switch
            {
                _ when string.Equals(mode, CountMode, StringComparison.OrdinalIgnoreCase) =>
                    ReadCount(collection, filter, pluginData),
                _ when string.Equals(mode, DistinctMode, StringComparison.OrdinalIgnoreCase) =>
                    ReadDistinct(collection, filter, pluginData),
                _ when string.Equals(mode, FieldMode, StringComparison.OrdinalIgnoreCase) =>
                    ReadField(collection, filter, pluginData),
                _ => throw new InvalidOperationException(
                    $"The 'Mode' argument must be '{CountMode}', '{DistinctMode}', or '{FieldMode}'.")
            };

            // Convert the value to its session text so strings stay raw and other values match the exported JSON.
            var outputs = new Dictionary<string, string>
            {
                ["Value"] = MongoDbClient.ConvertToText(value)
            };

            // Publish the value as a Base64 session parameter and, unless suppressed, as the entity.
            return this.NewMongoDbResponse(nameReference: NameReference, outputs, noEntity);
        }

        // Counts the documents the filter matches, which the server evaluates without returning them.
        private static BsonInt64 ReadCount(
            IMongoCollection<BsonDocument> collection,
            BsonDocument filter,
            PluginDataModel pluginData)
        {
            // Bound the count by the shared command timeout so a collection scan cannot run unbounded.
            var options = new CountOptions
            {
                MaxTime = pluginData.ResolveMaxTime()
            };

            return new BsonInt64(collection.CountDocuments(filter, options));
        }

        // Collects the distinct values of the named field across the matching documents, as an array.
        private static BsonArray ReadDistinct(
            IMongoCollection<BsonDocument> collection,
            BsonDocument filter,
            PluginDataModel pluginData)
        {
            // Require the field, because distinct values are always values of one field.
            var field = pluginData.ResolveRequired(name: "Field");

            var options = new DistinctOptions
            {
                MaxTime = pluginData.ResolveMaxTime()
            };

            // Read the values as raw BSON so every type the field holds survives, mixed types included.
            using var cursor = collection.Distinct<BsonValue>(field, filter, options);

            return new BsonArray(cursor.ToList());
        }

        // Reads the named field of the first matching document, following a dot path into subdocuments.
        private static BsonValue ReadField(
            IMongoCollection<BsonDocument> collection,
            BsonDocument filter,
            PluginDataModel pluginData)
        {
            // Require the field and read the optional sort, which decides which document is first.
            var field = pluginData.ResolveRequired(name: "Field");
            var sort = pluginData.ResolveDocument(name: "Sort");

            // Project only the field so the server returns the smallest possible document.
            var options = new FindOptions<BsonDocument, BsonDocument>
            {
                Limit = 1,
                MaxTime = pluginData.ResolveMaxTime(),
                Projection = new BsonDocument { [field] = 1, ["_id"] = 0 },
                Sort = sort.ElementCount > 0 ? sort : null
            };

            using var cursor = collection.FindSync(filter, options);
            var document = cursor.FirstOrDefault();

            // Report no document and an absent field alike as a missing value, which reads as empty text.
            return document is null
                ? BsonNull.Value
                : ReadPath(document, field);
        }

        // Follows a dot path into a document, so "address.city" reads the city of the address subdocument. Returns
        // BSON null when any segment is missing, so an absent field never fails the step.
        private static BsonValue ReadPath(BsonDocument document, string field)
        {
            // Walk the path one segment at a time, stopping at the first segment the document does not carry.
            BsonValue current = document;

            foreach (var segment in field.Split('.'))
            {
                if (current is not BsonDocument map || !map.TryGetValue(segment, out var next))
                {
                    return BsonNull.Value;
                }

                current = next;
            }

            return current;
        }
    }
}
