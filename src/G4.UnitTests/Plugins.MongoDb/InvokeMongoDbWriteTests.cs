using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;

using System;
using System.Text;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("InvokeMongoDbWrite")]
    [TestCategory("UnitTest")]
    public class InvokeMongoDbWriteTests : TestBase
    {
        // Names the collection every scenario of this class writes, so no other class shares its documents.
        private const string Collection = "WriteDocuments";

        [TestMethod(DisplayName = "Verify that the InvokeMongoDbWrite plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<InvokeMongoDbWrite>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeMongoDbWrite plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<InvokeMongoDbWrite>();
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbWrite inserts an array of documents and reports their " +
            "count and generated identifiers.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbWriteInsertManyTest()
        {
            // Arrange: start from an empty collection and insert two documents.
            MongoDbTestContainer.Drop(Collection);

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Operation:InsertMany --Document:[{\"sku\":\"A-1\"},{\"sku\":\"B-2\"}]");

            // Act: insert the documents through the plugin.
            var result = Invoke<InvokeMongoDbWrite>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;
            var entity = result.Response.Entity;

            // Assert: both documents landed and the plugin reported their count.
            Assert.AreEqual(expected: "2", actual: $"{entity["InsertedCount"]}");
            Assert.AreEqual(expected: 2, actual: MongoDbTestContainer.Count(Collection));

            // Assert: the driver-generated identifiers are reported, so a flow can address the new documents.
            var insertedIds = MongoDbTestJson.ToValues($"{entity["InsertedIds"]}");
            Assert.HasCount(expected: 2, collection: insertedIds);
            Assert.AreEqual(expected: BsonType.ObjectId, actual: insertedIds[0].BsonType);

            // Assert: the session carries the same count under the plugin namespace.
            Assert.AreEqual(
                expected: "2",
                actual: $"{sessionParameters["InvokeMongoDbWrite:InsertedCount"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbWrite inserts a single document passed as one JSON " +
            "object.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbWriteInsertOneTest()
        {
            // Arrange: start from an empty collection and insert one document without an array wrapper.
            MongoDbTestContainer.Drop(Collection);

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Operation:InsertOne --Document:{\"sku\":\"A-1\"}");

            // Act: insert the document through the plugin.
            var result = Invoke<InvokeMongoDbWrite>(rule);

            // Assert: exactly one document landed.
            Assert.AreEqual(expected: "1", actual: $"{result.Response.Entity["InsertedCount"]}");
            Assert.AreEqual(expected: 1, actual: MongoDbTestContainer.Count(Collection));
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbWrite applies a Base64-encoded update document to every " +
            "matching document and reports the matched and modified counts.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbWriteUpdateManyTest()
        {
            // Arrange: seed two open documents and encode the update, which ends in two closing braces.
            SeedDocuments();
            var update = NewBase64(payload: "{\"$set\":{\"status\":\"processed\"}}");

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                $"--Operation:UpdateMany --CommandText:{{\"status\":\"open\"}} --Document:{update} " +
                "--DocumentBase64");

            // Act: update the matching documents through the plugin.
            var result = Invoke<InvokeMongoDbWrite>(rule);
            var entity = result.Response.Entity;

            // Assert: both open documents were matched and changed.
            Assert.AreEqual(expected: "2", actual: $"{entity["MatchedCount"]}");
            Assert.AreEqual(expected: "2", actual: $"{entity["ModifiedCount"]}");

            // Assert: the stored documents carry the new status.
            var processed = MongoDbTestContainer.Count(
                Collection,
                filter: new BsonDocument { ["status"] = "processed" });
            Assert.AreEqual(expected: 2, actual: processed);
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbWrite inserts a document and reports its identifier " +
            "when an update with the Upsert switch matches nothing.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbWriteUpsertTest()
        {
            // Arrange: seed the documents and update a status none of them carries.
            SeedDocuments();
            var update = NewBase64(payload: "{\"$set\":{\"sku\":\"Z-9\"}}");

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                $"--Operation:UpdateOne --CommandText:{{\"status\":\"missing\"}} --Document:{update} " +
                "--DocumentBase64 --Upsert");

            // Act: update the non-existent document through the plugin.
            var result = Invoke<InvokeMongoDbWrite>(rule);
            var entity = result.Response.Entity;

            // Assert: nothing matched and the upserted identifier is reported as a one-item array.
            Assert.AreEqual(expected: "0", actual: $"{entity["MatchedCount"]}");

            var upsertedIds = MongoDbTestJson.ToValues($"{entity["UpsertedIds"]}");
            Assert.HasCount(expected: 1, collection: upsertedIds);

            // Assert: the upserted document joined the three seeded ones.
            Assert.AreEqual(expected: 4, actual: MongoDbTestContainer.Count(Collection));
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbWrite replaces one document and keeps only the fields " +
            "of the replacement.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbWriteReplaceOneTest()
        {
            // Arrange: seed the documents and replace the one that carries the known SKU.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Operation:ReplaceOne --CommandText:{\"sku\":\"A-1\"} " +
                "--Document:{\"sku\":\"A-1\",\"total\":99}");

            // Act: replace the document through the plugin.
            var result = Invoke<InvokeMongoDbWrite>(rule);

            // Assert: exactly one document was matched and changed.
            Assert.AreEqual(expected: "1", actual: $"{result.Response.Entity["ModifiedCount"]}");

            // Assert: the replacement removed the fields it omitted, so the status is gone.
            var documents = MongoDbTestContainer.Find(Collection, filter: new BsonDocument { ["sku"] = "A-1" });
            Assert.HasCount(expected: 1, collection: documents);
            Assert.IsFalse(condition: documents[0].Contains("status"));
            Assert.AreEqual(expected: 99, actual: documents[0]["total"].ToInt32());
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbWrite deletes every matching document inside a " +
            "transaction and reports the deleted count.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbWriteDeleteManyInTransactionTest()
        {
            // Arrange: seed the documents and delete the open ones inside a transaction.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Operation:DeleteMany --CommandText:{\"status\":\"open\"} --Transaction");

            // Act: delete the documents through the plugin.
            var result = Invoke<InvokeMongoDbWrite>(rule);

            // Assert: both open documents were deleted and committed, leaving the closed one.
            Assert.AreEqual(expected: "2", actual: $"{result.Response.Entity["DeletedCount"]}");
            Assert.AreEqual(expected: 1, actual: MongoDbTestContainer.Count(Collection));
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbWrite rejects a delete without a filter, so a step " +
            "never clears a collection by an omitted argument.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbWriteEmptyFilterTest()
        {
            // Arrange: seed the documents and delete without naming a filter.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Operation:DeleteMany");

            // Act and Assert: the guard fails the step and names the deliberate way to address every document.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => Invoke<InvokeMongoDbWrite>(rule));
            Assert.Contains(substring: "must carry a filter", value: exception.Message);

            // Assert: nothing was deleted, because the guard runs before the write.
            Assert.AreEqual(expected: 3, actual: MongoDbTestContainer.Count(Collection));
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbWrite fails for an unknown Operation and names the " +
            "accepted values.")]
        public void InvokeMongoDbWriteUnknownOperationTest()
        {
            // Arrange: request an operation the plugin does not offer; the target is never contacted.
            var rule = NewRule(arguments: "--Host:127.0.0.1 --Database:G4Tests --Collection:x " +
                "--Operation:Upsert --Document:{\"a\":1}");

            // Act and Assert: the failure names the operations a step may request.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => Invoke<InvokeMongoDbWrite>(rule));
            Assert.Contains(substring: "InsertOne", value: exception.Message);
            Assert.Contains(substring: "DeleteMany", value: exception.Message);
        }

        // Encodes a payload as UTF-8 Base64, for a nested JSON document that cannot travel inside an inline argument.
        private static string NewBase64(string payload)
        {
            // Encode exactly as the documented Base64 switches expect.
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
        }

        // Composes the connection argument of the shared test deployment.
        private static string NewConnectionArgument()
        {
            // Pass the URI as the step connection input, which the plugin resolves without credentials.
            return $"--ConnectionString:{MongoDbTestContainer.ConnectionString}";
        }

        // Creates an Action rule whose CLI argument holds the scenario arguments.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Compose the CLI expression the plugin parses into its parameters.
            return new ActionRuleModel
            {
                PluginName = nameof(InvokeMongoDbWrite),
                Argument = "{{$ " + arguments + "}}"
            };
        }

        // Replaces the scenario collection with three documents: two open and one closed.
        private static void SeedDocuments()
        {
            // Drop the collection first so every scenario starts from the same three documents.
            MongoDbTestContainer.Drop(Collection);

            MongoDbTestContainer.Insert(Collection,
            [
                new BsonDocument { ["sku"] = "A-1", ["status"] = "open", ["total"] = 10 },
                new BsonDocument { ["sku"] = "B-2", ["status"] = "open", ["total"] = 20 },
                new BsonDocument { ["sku"] = "C-3", ["status"] = "closed", ["total"] = 30 }
            ]);
        }
    }
}
