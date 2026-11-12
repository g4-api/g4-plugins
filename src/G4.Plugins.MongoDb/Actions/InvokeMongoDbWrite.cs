using G4.Attributes;
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
    public class InvokeMongoDbWrite(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as InvokeMongoDbWrite:<Name>.
        private const string NameReference = nameof(InvokeMongoDbWrite);

        // Deletes every matching document; the Operation argument names it.
        private const string DeleteManyOperation = "DeleteMany";

        // Deletes the first matching document; the Operation argument names it.
        private const string DeleteOneOperation = "DeleteOne";

        // Inserts every document of the Document array; the Operation argument names it.
        private const string InsertManyOperation = "InsertMany";

        // Inserts the single document of the Document argument; the Operation argument names it.
        private const string InsertOneOperation = "InsertOne";

        // Replaces the first matching document; the Operation argument names it.
        private const string ReplaceOneOperation = "ReplaceOne";

        // Applies the update operators to every matching document; the Operation argument names it.
        private const string UpdateManyOperation = "UpdateMany";

        // Applies the update operators to the first matching document; the Operation argument names it.
        private const string UpdateOneOperation = "UpdateOne";

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the collection, the operation, and the switches before opening resources.
            var connectionModel = pluginData.ResolveConnection();
            var collectionName = pluginData.ResolveRequired(name: "Collection");
            var operation = pluginData.ResolveRequired(name: "Operation");
            var noEntity = pluginData.TestSwitch(name: "NoEntity");
            var isTransaction = pluginData.TestSwitch(name: "Transaction");

            // Open a client owned by this step and start a transaction when requested.
            using var client = MongoDbClient.OpenClient(connectionModel);
            using var session = LocalExtensions.NewTransaction(client, isTransaction);

            // Carry the addressed collection, the step arguments, the session, and the outputs as one input, and
            // report every count, so a flow reads one output shape regardless of the operation it ran.
            var options = new WriteOptions
            {
                Collection = MongoDbClient.GetCollection(client, connectionModel, collectionName),
                Outputs = new Dictionary<string, string>
                {
                    ["DeletedCount"] = "0",
                    ["InsertedCount"] = "0",
                    ["InsertedIds"] = "[]",
                    ["MatchedCount"] = "0",
                    ["ModifiedCount"] = "0",
                    ["UpsertedIds"] = "[]"
                },
                PluginData = pluginData,
                Session = session
            };

            // Run the requested operation; an unknown operation names the accepted values.
            switch (operation)
            {
                case var _ when IsOperation(operation, InsertOneOperation):
                case var _ when IsOperation(operation, InsertManyOperation):
                    Insert(options);
                    break;
                case var _ when IsOperation(operation, UpdateOneOperation):
                    Update(options, isMany: false);
                    break;
                case var _ when IsOperation(operation, UpdateManyOperation):
                    Update(options, isMany: true);
                    break;
                case var _ when IsOperation(operation, ReplaceOneOperation):
                    Replace(options);
                    break;
                case var _ when IsOperation(operation, DeleteOneOperation):
                    Delete(options, isMany: false);
                    break;
                case var _ when IsOperation(operation, DeleteManyOperation):
                    Delete(options, isMany: true);
                    break;
                default:
                    var accepted = string.Join("', '", GetOperations());
                    var message = $"The 'Operation' argument must be one of '{accepted}'.";
                    throw new InvalidOperationException(message);
            }

            // Commit only after the operation succeeded.
            session?.CommitTransaction();

            // Publish the write counts as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewMongoDbResponse(nameReference: NameReference, options.Outputs, noEntity);
        }

        // Deletes the matching documents and records the deleted count. Mutates the caller-owned outputs.
        private static void Delete(WriteOptions options, bool isMany)
        {
            // Require a filter, so a delete never removes the whole collection by an omitted argument.
            var filter = ResolveFilter(options.PluginData);
            var collection = options.Collection;
            var session = options.Session;

            // Run the delete inside the open transaction when the step started one.
            var result = (isMany, session) switch
            {
                (true, null) => collection.DeleteMany(filter),
                (true, _) => collection.DeleteMany(session, filter),
                (false, null) => collection.DeleteOne(filter),
                (false, _) => collection.DeleteOne(session, filter, options: null)
            };

            options.Outputs["DeletedCount"] = $"{result.DeletedCount}";
        }

        // Names the accepted operations in the order the documentation lists them.
        private static string[] GetOperations() =>
        [
            InsertOneOperation,
            InsertManyOperation,
            UpdateOneOperation,
            UpdateManyOperation,
            ReplaceOneOperation,
            DeleteOneOperation,
            DeleteManyOperation
        ];

        // Inserts the documents of the Document argument and records their count and identifiers. One document and an
        // array of documents follow the same path, so InsertOne and InsertMany differ only in the payload they carry.
        private static void Insert(WriteOptions options)
        {
            // Require the documents so an insert never runs empty.
            var documents = MongoDbClient.ConvertToDocuments(
                json: options.PluginData.ResolveDocumentText(),
                argumentName: "Document");

            // Keep the insert order so a failing document stops the ones after it, matching the server default.
            var insertOptions = new InsertManyOptions
            {
                IsOrdered = true
            };

            // Join the open transaction when the step started one.
            if (options.Session is null)
            {
                options.Collection.InsertMany(documents, insertOptions);
            }
            else
            {
                options.Collection.InsertMany(options.Session, documents, insertOptions);
            }

            // Read the identifiers the driver assigned, so a flow can address the new documents.
            var insertedIds = documents
                .Select(i => i.GetValue(name: "_id", defaultValue: BsonNull.Value))
                .ToList();

            options.Outputs["InsertedCount"] = $"{documents.Count}";
            options.Outputs["InsertedIds"] = MongoDbClient.ConvertToJson(value: new BsonArray(insertedIds));
        }

        // Tests whether the requested operation is the named one, case-insensitively like every other argument value.
        private static bool IsOperation(string operation, string name)
        {
            return string.Equals(operation, name, StringComparison.OrdinalIgnoreCase);
        }

        // Replaces the first matching document with the Document argument and records the write counts.
        private static void Replace(WriteOptions options)
        {
            // Require the filter and the replacement, which together address and rewrite exactly one document.
            var filter = ResolveFilter(options.PluginData);
            var replacement = MongoDbClient.ConvertToDocument(
                json: options.PluginData.ResolveDocumentText(),
                argumentName: "Document");

            if (replacement.ElementCount == 0)
            {
                throw new InvalidOperationException("The 'Document' argument is required for a replace.");
            }

            // Insert the replacement when nothing matches only if the step asked for it.
            var replaceOptions = new ReplaceOptions
            {
                IsUpsert = options.PluginData.TestSwitch(name: "Upsert")
            };

            var result = options.Session is null
                ? options.Collection.ReplaceOne(filter, replacement, replaceOptions)
                : options.Collection.ReplaceOne(options.Session, filter, replacement, replaceOptions);

            // A replace reports its own result type, so its counts are copied field by field.
            var counts = new WriteCounts
            {
                MatchedCount = result.MatchedCount,
                ModifiedCount = result.ModifiedCount,
                UpsertedId = result.UpsertedId
            };

            SetUpdateOutputs(counts, options.Outputs);
        }

        // Resolves the filter of a write, rejecting an empty one so a write never addresses every document by an
        // omitted argument. An explicit empty document in CommandText is still empty, so the guard is deliberate.
        private static BsonDocument ResolveFilter(PluginDataModel pluginData)
        {
            // Read the primary payload, which carries the filter for every write except an insert.
            var filter = MongoDbClient.ConvertToDocument(
                json: pluginData.ResolveCommandText(),
                argumentName: "CommandText");

            // Reject an empty filter so the step states which documents it changes.
            if (filter.ElementCount == 0)
            {
                var message = "The 'CommandText' argument must carry a filter for this operation. Pass " +
                    "{\"_id\":{\"$exists\":true}} to address every document on purpose.";
                throw new InvalidOperationException(message);
            }

            return filter;
        }

        // Records the counts of an update or a replace, including the identifier of an upserted document. Mutates the
        // caller-owned outputs.
        private static void SetUpdateOutputs(WriteCounts counts, Dictionary<string, string> outputs)
        {
            // Report the matched and modified counts, which differ when a document already held the new values.
            outputs["MatchedCount"] = $"{counts.MatchedCount}";
            outputs["ModifiedCount"] = $"{counts.ModifiedCount}";

            // Report the upserted identifier as a one-item array, so the output shape never changes.
            var upsertedIds = counts.UpsertedId is null
                ? new BsonArray()
                : new BsonArray { counts.UpsertedId };

            outputs["UpsertedIds"] = MongoDbClient.ConvertToJson(value: upsertedIds);
        }

        // Applies the update of the Document argument to the matching documents and records the write counts.
        private static void Update(WriteOptions options, bool isMany)
        {
            // Require the filter and the update document, which must carry update operators such as $set.
            var filter = ResolveFilter(options.PluginData);
            var update = MongoDbClient.ConvertToDocument(
                json: options.PluginData.ResolveDocumentText(),
                argumentName: "Document");

            if (update.ElementCount == 0)
            {
                throw new InvalidOperationException("The 'Document' argument is required for an update.");
            }

            // Insert a new document when nothing matches only if the step asked for it.
            var updateOptions = new UpdateOptions
            {
                IsUpsert = options.PluginData.TestSwitch(name: "Upsert")
            };

            // Pass the update as a document definition, so the step controls the operators the server applies.
            var definition = new BsonDocumentUpdateDefinition<BsonDocument>(document: update);
            var collection = options.Collection;
            var session = options.Session;

            // Run the update inside the open transaction when the step started one.
            var result = (isMany, session) switch
            {
                (true, null) => collection.UpdateMany(filter, definition, updateOptions),
                (true, _) => collection.UpdateMany(session, filter, definition, updateOptions),
                (false, null) => collection.UpdateOne(filter, definition, updateOptions),
                (false, _) => collection.UpdateOne(session, filter, definition, updateOptions)
            };

            // Copy the counts so both result types reach one output mapping.
            var counts = new WriteCounts
            {
                MatchedCount = result.MatchedCount,
                ModifiedCount = result.ModifiedCount,
                UpsertedId = result.UpsertedId
            };

            SetUpdateOutputs(counts, options.Outputs);
        }

        // Carries the counts an update or a replace reports, so both driver result types reach one output mapping.
        private sealed class WriteCounts
        {
            /// <summary>
            /// Gets or sets the number of documents the filter matched.
            /// </summary>
            public long MatchedCount { get; set; }

            /// <summary>
            /// Gets or sets the number of documents the write actually changed.
            /// </summary>
            public long ModifiedCount { get; set; }

            /// <summary>
            /// Gets or sets the identifier of an upserted document; <c>null</c> when nothing was upserted.
            /// </summary>
            public BsonValue UpsertedId { get; set; }
        }

        // Carries everything one write operation needs: the addressed collection, the step arguments, the optional
        // transaction session, and the outputs the operation records into.
        private sealed class WriteOptions
        {
            /// <summary>
            /// Gets or sets the collection the operation writes to.
            /// </summary>
            public IMongoCollection<BsonDocument> Collection { get; set; }

            /// <summary>
            /// Gets or sets the outputs the operation records its counts into.
            /// </summary>
            public Dictionary<string, string> Outputs { get; set; }

            /// <summary>
            /// Gets or sets the step arguments the operation reads its payloads and switches from.
            /// </summary>
            public PluginDataModel PluginData { get; set; }

            /// <summary>
            /// Gets or sets the open transaction session, or <c>null</c> when the step runs without a transaction.
            /// </summary>
            public IClientSessionHandle Session { get; set; }
        }
    }
}
