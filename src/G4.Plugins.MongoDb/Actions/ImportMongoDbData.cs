using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Clients;
using G4.Plugins.MongoDb.Extensions;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G4.Plugins.MongoDb.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.MongoDb, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.MongoDb.Actions.Manifests.{NameReference}.json")]
    public class ImportMongoDbData(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as ImportMongoDbData:<Name>.
        private const string NameReference = nameof(ImportMongoDbData);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the destination collection, and the switches before opening any resource.
            var connectionModel = pluginData.ResolveConnection();
            var collectionName = pluginData.ResolveRequired(name: "Collection");
            var batchSize = pluginData.ResolveInteger(name: "BatchSize", defaultValue: 0);
            var noEntity = pluginData.TestSwitch(name: "NoEntity");
            var isOrdered = pluginData.TestSwitch(name: "Ordered");
            var isTransaction = pluginData.TestSwitch(name: "Transaction");

            // Read the source documents before connecting so a malformed payload fails without opening a client.
            var documents = ReadData(pluginData);

            // Open a client owned by this step and start a transaction when requested.
            using var client = MongoDbClient.OpenClient(connectionModel);
            using var session = LocalExtensions.NewTransaction(client, isTransaction);
            var collection = MongoDbClient.GetCollection(client, connectionModel, collectionName);

            // Insert unordered by default, so one rejected document does not stop the ones after it.
            var options = new InsertManyOptions
            {
                IsOrdered = isOrdered
            };

            // Insert in batches so one oversized payload never travels as a single command; a batch size of 0 sends
            // every document in one call and lets the driver split it.
            foreach (var batch in ConvertToBatches(documents, batchSize))
            {
                if (session is null)
                {
                    collection.InsertMany(batch, options);
                }
                else
                {
                    collection.InsertMany(session, batch, options);
                }
            }

            // Commit only after every document was inserted.
            session?.CommitTransaction();

            // Report the inserted count as text so the session and the entity share one form.
            var outputs = new Dictionary<string, string>
            {
                ["DocumentsInserted"] = $"{documents.Count}"
            };

            // Publish the inserted count as a Base64 session parameter and, unless suppressed, as the entity.
            return this.NewMongoDbResponse(nameReference: NameReference, outputs, noEntity);
        }

        // Splits the documents into insert batches. A batch size of 0 or one larger than the payload yields one
        // batch, so the driver decides how to split it.
        private static IEnumerable<List<BsonDocument>> ConvertToBatches(List<BsonDocument> documents, int batchSize)
        {
            // Send everything at once when the step set no batch size.
            if (batchSize <= 0 || batchSize >= documents.Count)
            {
                yield return documents;

                yield break;
            }

            // Walk the documents in fixed-size windows so each insert carries a bounded payload.
            for (var i = 0; i < documents.Count; i += batchSize)
            {
                yield return [.. documents.Skip(i).Take(batchSize)];
            }
        }

        // Reads the source documents from the inline Data argument (JSON) or from the DataFile argument (a .csv file,
        // or a JSON file for any other extension). Data wins when both are set.
        private static List<BsonDocument> ReadData(PluginDataModel pluginData)
        {
            // Prefer the inline JSON documents so a step can override a shared data file.
            var data = pluginData.Parameters.Get(key: "Data", defaultValue: string.Empty);

            if (!string.IsNullOrWhiteSpace(data))
            {
                return MongoDbClient.ConvertToDocuments(json: data, argumentName: "Data");
            }

            // Fall back to the data file, selecting the parser by extension.
            var dataFile = pluginData.Parameters.Get(key: "DataFile", defaultValue: string.Empty);

            if (string.IsNullOrWhiteSpace(dataFile))
            {
                throw new InvalidOperationException("Either 'Data' or 'DataFile' is required.");
            }

            // Read the file once and parse it as CSV only for the .csv extension; every other extension is JSON.
            var content = File.ReadAllText(dataFile);
            var isCsv = string.Equals(Path.GetExtension(dataFile), ".csv", StringComparison.OrdinalIgnoreCase);

            return isCsv
                ? MongoDbClient.ConvertCsvToDocuments(csv: content)
                : MongoDbClient.ConvertToDocuments(json: content, argumentName: "DataFile");
        }
    }
}
