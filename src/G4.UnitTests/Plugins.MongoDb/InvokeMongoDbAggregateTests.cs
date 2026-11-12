using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Linq;
using System.Text;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("InvokeMongoDbAggregate")]
    [TestCategory("UnitTest")]
    public class InvokeMongoDbAggregateTests : TestBase
    {
        // Names the collection every scenario of this class reads, so no other class shares its documents.
        private const string Collection = "AggregateDocuments";

        // Names the collection the merging scenario writes, which the pipeline creates.
        private const string MergeCollection = "AggregateTotals";

        [TestMethod(DisplayName = "Verify that the InvokeMongoDbAggregate plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<InvokeMongoDbAggregate>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeMongoDbAggregate plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<InvokeMongoDbAggregate>();
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbAggregate groups the matching documents and stores the " +
            "produced documents, their field names, and the counts.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbAggregateGroupTest()
        {
            // Arrange: seed the documents and group the open ones by SKU, encoded because the stages nest.
            SeedDocuments();

            var pipeline = NewBase64(payload: "[{\"$match\":{\"status\":\"open\"}}," +
                "{\"$group\":{\"_id\":\"$sku\",\"total\":{\"$sum\":\"$total\"}}}]");

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                $"--CommandText:{pipeline} --Base64");

            // Act: run the pipeline through the plugin.
            var result = Invoke<InvokeMongoDbAggregate>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;
            var entity = result.Response.Entity;

            // Assert: the two open SKUs each produced one grouped document.
            Assert.AreEqual(expected: "2", actual: $"{entity["DocumentCount"]}");
            Assert.AreEqual(expected: "2", actual: $"{entity["StageCount"]}");

            // Assert: the grouped documents carry the group key and the summed total.
            var documents = MongoDbTestJson.ToDocuments($"{entity["Result"]}");
            Assert.IsTrue(condition: documents.All(i => i.Contains("_id") && i.Contains("total")));

            // Assert: the session carries the same count under the plugin namespace.
            Assert.AreEqual(
                expected: "2",
                actual: $"{sessionParameters["InvokeMongoDbAggregate:DocumentCount"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbAggregate accepts a single stage object with no array " +
            "wrapper.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbAggregateSingleStageTest()
        {
            // Arrange: seed the documents and count them with a one-stage pipeline.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--CommandText:{\"$count\":\"all\"}");

            // Act: run the pipeline through the plugin.
            var result = Invoke<InvokeMongoDbAggregate>(rule);
            var entity = result.Response.Entity;

            // Assert: the single stage ran and produced the count document.
            Assert.AreEqual(expected: "1", actual: $"{entity["StageCount"]}");

            var documents = MongoDbTestJson.ToDocuments($"{entity["Result"]}");
            Assert.AreEqual(expected: 3, actual: documents[0]["all"].ToInt32());
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbAggregate writes the result of a merging pipeline, " +
            "which the server allows only outside a transaction, and reports the written documents.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbAggregateMergeTest()
        {
            // Arrange: seed the documents, clear the target, and group into it with a merging pipeline.
            SeedDocuments();
            MongoDbTestContainer.Drop(MergeCollection);


            var pipeline = NewBase64(payload:
                "[{\"$group\":{\"_id\":\"$status\",\"total\":{\"$sum\":\"$total\"}}}," +
                $"{{\"$merge\":{{\"into\":\"{MergeCollection}\"}}}}]");

            // Run without a transaction, because MongoDB rejects $merge inside one.
            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                $"--CommandText:{pipeline} --Base64");

            // Act: run the merging pipeline through the plugin.
            var result = Invoke<InvokeMongoDbAggregate>(rule);

            // Assert: the two grouped documents were written, and the driver read them back from the written
            // collection, because $merge itself returns no documents.
            Assert.AreEqual(expected: 2, actual: MongoDbTestContainer.Count(MergeCollection));
            Assert.AreEqual(expected: "2", actual: $"{result.Response.Entity["DocumentCount"]}");
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbAggregate surfaces the server rejection when a " +
            "merging pipeline is run inside a transaction.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbAggregateMergeInTransactionTest()
        {
            // Arrange: seed the documents and ask for a merge inside a transaction, which the server rejects.
            SeedDocuments();
            MongoDbTestContainer.Drop(MergeCollection);

            var pipeline = NewBase64(payload:
                "[{\"$group\":{\"_id\":\"$status\",\"total\":{\"$sum\":\"$total\"}}}," +
                $"{{\"$merge\":{{\"into\":\"{MergeCollection}\"}}}}]");

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                $"--CommandText:{pipeline} --Base64 --Transaction");

            // Act and Assert: the server rejection reaches the caller instead of being swallowed.
            var exception = Assert.ThrowsExactly<MongoCommandException>(
                () => Invoke<InvokeMongoDbAggregate>(rule));
            Assert.Contains(substring: "$merge cannot be used in a transaction", value: exception.Message);

            // Assert: nothing was written, because the pipeline never ran.
            Assert.AreEqual(expected: 0, actual: MongoDbTestContainer.Count(MergeCollection));
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbAggregate fails when the pipeline is missing.")]
        public void InvokeMongoDbAggregateMissingPipelineTest()
        {
            // Arrange: name a collection but pass no pipeline; the target is never contacted.
            var rule = NewRule(arguments: "--Host:127.0.0.1 --Database:G4Tests --Collection:x");

            // Act and Assert: the missing payload is named in the failure.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(
                () => Invoke<InvokeMongoDbAggregate>(rule));
            Assert.Contains(substring: "CommandText", value: exception.Message);
        }

        // Encodes a payload as UTF-8 Base64, for a nested pipeline that cannot travel inside an inline argument.
        private static string NewBase64(string payload)
        {
            // Encode exactly as the documented Base64 switch expects.
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
                PluginName = nameof(InvokeMongoDbAggregate),
                Argument = "{{$ " + arguments + "}}"
            };
        }

        // Replaces the scenario collection with three documents: two open with distinct SKUs and one closed.
        private static void SeedDocuments()
        {
            // Drop the collection first so every scenario reads the same three documents.
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
