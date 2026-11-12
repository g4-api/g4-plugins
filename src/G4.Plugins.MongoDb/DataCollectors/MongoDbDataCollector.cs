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

namespace G4.Plugins.MongoDb.DataCollectors
{
    [G4Plugin(
        assembly: "G4.Plugins.MongoDb, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.MongoDb.DataCollectors.Manifests.{nameof(MongoDbDataCollector)}.json")]
    public class MongoDbDataCollector(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Names the destination collection when the rule sets no Repository, matching the SQLite collector default.
        private const string DefaultRepository = "default-warehouse";

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the Source (credentials name or connection URI) and the Repository of the rule, so the
            // destination is validated before any entity is converted. MongoDB creates the database and the
            // collection on the first insert, so the collector needs no schema step at all.
            var rule = (DataCollectorRuleModel)pluginData.Rule;
            var repository = string.IsNullOrWhiteSpace(rule.Repository) ? DefaultRepository : rule.Repository;

            // Collect the extracted entities; an extraction without entities has nothing to write.
            var entities = pluginData
                .Extraction?
                .Entities?
                .Select(i => i.Content)
                .Where(i => i is not null)
                .ToArray() ?? [];

            if (entities.Length == 0)
            {
                return this.NewPluginResponse();
            }

            // Convert the entities before connecting so an unaddressable content key fails without a client.
            var documents = entities.Select(NewDocument).ToList();

            // Resolve the connection from the rule Source alone; the collector rule carries no discrete overrides.
            var connectionModel = LocalExtensions.ResolveConnection(
                credentials: rule.Source,
                connectionString: string.Empty,
                overrides: null);

            // Open a client owned by this collector run so no session state leaks into later runs.
            using var client = MongoDbClient.OpenClient(connectionModel);
            var collection = MongoDbClient.GetCollection(client, connectionModel, repository);

            // Insert unordered, so one rejected document still lets the rest of the extraction land.
            var options = new InsertManyOptions
            {
                IsOrdered = false
            };

            // Insert every entity in one round trip; a failure surfaces to the engine as the collector error.
            collection.InsertMany(documents, options);

            // Report success without an entity; the collector output is the written collection itself.
            return this.NewPluginResponse();
        }

        // Converts one entity into a document, keeping nested content as real subdocuments and arrays so it stays
        // queryable by dot path and by aggregation, which is the reason to collect into MongoDB at all.
        private static BsonDocument NewDocument(IDictionary<string, object> entity)
        {
            // Build the document field by field so every key is validated before the document is inserted.
            var document = new BsonDocument();

            foreach (var content in entity)
            {
                AssertFieldName(content.Key);
                document[content.Key] = MongoDbClient.ConvertToBsonValue(content.Value);
            }

            return document;
        }

        // Asserts that a content key is addressable as a MongoDB field name, so the failure names the offending key
        // instead of surfacing as a server write error.
        private static void AssertFieldName(string name)
        {
            // Reject an empty key, which no query can address.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidOperationException("An extracted content key cannot be empty.");
            }

            // Reject a key the query language reads as an operator reference.
            if (name.StartsWith('$'))
            {
                throw new InvalidOperationException($"The content key '{name}' cannot start with '$'.");
            }

            // Reject a key that holds the path separator, which would make the field unreachable by dot path.
            if (name.Contains('.'))
            {
                throw new InvalidOperationException($"The content key '{name}' cannot contain '.'.");
            }
        }
    }
}
