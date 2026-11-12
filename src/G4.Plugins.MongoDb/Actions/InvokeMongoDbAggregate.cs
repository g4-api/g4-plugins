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
    public class InvokeMongoDbAggregate(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as InvokeMongoDbAggregate:<Name>.
        private const string NameReference = nameof(InvokeMongoDbAggregate);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the collection, and the pipeline before opening any resource.
            var connectionModel = pluginData.ResolveConnection();
            var collectionName = pluginData.ResolveRequired(name: "Collection");
            var stages = ResolveStages(pluginData);
            var noEntity = pluginData.TestSwitch(name: "NoEntity");
            var isTransaction = pluginData.TestSwitch(name: "Transaction");

            // Bind the options the step sets; disk use matters for a pipeline that exceeds the memory limit.
            var options = new AggregateOptions
            {
                AllowDiskUse = pluginData.TestSwitch(name: "AllowDiskUse"),
                MaxTime = pluginData.ResolveMaxTime()
            };

            // Open a client owned by this step and start a transaction when requested, which gives a read pipeline
            // one consistent snapshot. A writing pipeline cannot use one, because the server rejects $merge and
            // $out inside a transaction.
            using var client = MongoDbClient.OpenClient(connectionModel);
            using var session = LocalExtensions.NewTransaction(client, isTransaction);
            var collection = MongoDbClient.GetCollection(client, connectionModel, collectionName);

            // Run the pipeline; its stages travel as BSON, never as composed command text.
            var pipeline = PipelineDefinition<BsonDocument, BsonDocument>.Create(stages);

            using var cursor = session is null
                ? collection.Aggregate(pipeline, options)
                : collection.Aggregate(session, pipeline, options);

            // A pipeline that ends in $merge or $out returns no documents of its own; the driver then reads the
            // written collection, so the result reports what the pipeline wrote.
            var result = MongoDbClient.NewResultSet(documents: cursor.ToEnumerable());

            // Commit only after the pipeline completed, so the snapshot is released in one step.
            session?.CommitTransaction();

            // Serialize the field names, the documents, and the counts once so the session and the entity share one
            // form.
            var outputs = new Dictionary<string, string>
            {
                ["Columns"] = MongoDbClient.ConvertToJson(values: result.Columns),
                ["DocumentCount"] = $"{result.Documents.Count}",
                ["Result"] = MongoDbClient.ConvertToJson(documents: result.Documents),
                ["StageCount"] = $"{stages.Length}"
            };

            // Publish the pipeline outcome as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewMongoDbResponse(nameReference: NameReference, outputs, noEntity);
        }

        // Resolves the pipeline stages from the primary payload, requiring a JSON array of stage documents. A single
        // stage object is accepted too, so a one-stage pipeline needs no array wrapper.
        private static BsonDocument[] ResolveStages(PluginDataModel pluginData)
        {
            // Read the payload and reject an empty one, because an aggregation without stages has nothing to run.
            var json = pluginData.ResolveCommandText();

            if (string.IsNullOrWhiteSpace(json))
            {
                throw new InvalidOperationException("The 'CommandText' argument must carry the pipeline stages.");
            }

            // Parse the stages, accepting both an array and a single stage document.
            var stages = MongoDbClient.ConvertToDocuments(json, argumentName: "CommandText");

            return [.. stages];
        }
    }
}
