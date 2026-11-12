using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("ExportMongoDbQuery")]
    [TestCategory("UnitTest")]
    public class ExportMongoDbQueryTests : TestBase
    {
        // Names the collection every scenario of this class reads, so no other class shares its documents.
        private const string Collection = "ExportQueryDocuments";

        // Field names expected after the projection keeps the SKU alone.
        private static readonly string[] ExpectedProjectedColumns = ["sku"];

        [TestMethod(DisplayName = "Verify that the ExportMongoDbQuery plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<ExportMongoDbQuery>();
        }

        [TestMethod(DisplayName = "Verify that the ExportMongoDbQuery plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<ExportMongoDbQuery>();
        }

        [TestMethod(DisplayName = "Verify that ExportMongoDbQuery stores the matching documents, their field " +
            "names, and their count as Base64-encoded session parameters and in the entity.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ExportMongoDbQueryFilterTest()
        {
            // Arrange: seed three documents, two of which match the filter.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--CommandText:{\"status\":\"open\"} --Projection:{\"sku\":1,\"_id\":0}");

            // Act: export the matching documents through the plugin.
            var result = Invoke<ExportMongoDbQuery>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;
            var entity = result.Response.Entity;

            // Assert: the session holds the Base64-encoded outputs under the plugin namespace.
            Assert.AreEqual(
                expected: "2",
                actual: $"{sessionParameters["ExportMongoDbQuery:DocumentCount"]}".ConvertFromBase64());

            // Assert: the exported documents carry only the projected field.
            var documents = MongoDbTestJson.ToDocuments($"{entity["Result"]}");
            Assert.HasCount(expected: 2, collection: documents);
            Assert.IsTrue(condition: documents.All(i => i.ElementCount == 1 && i.Contains("sku")));

            // Assert: the field names follow the projection.
            Assert.AreSequenceEqual(expected: ExpectedProjectedColumns, actual: ReadColumns(entity));
        }

        [TestMethod(DisplayName = "Verify that ExportMongoDbQuery exports every document when the step sets no " +
            "filter.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ExportMongoDbQueryMatchAllTest()
        {
            // Arrange: seed the documents and export without a filter.
            SeedDocuments();
            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection}");

            // Act: export the whole collection through the plugin.
            var result = Invoke<ExportMongoDbQuery>(rule);

            // Assert: every seeded document is exported.
            Assert.AreEqual(expected: "3", actual: $"{result.Response.Entity["DocumentCount"]}");
        }

        [TestMethod(DisplayName = "Verify that ExportMongoDbQuery applies the sort, the limit, and the skip to the " +
            "exported page.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ExportMongoDbQueryPagingTest()
        {
            // Arrange: seed the documents and ask for the second document by descending total.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Sort:{\"total\":-1} --Limit:1 --Skip:1");

            // Act: export the page through the plugin.
            var result = Invoke<ExportMongoDbQuery>(rule);
            var documents = MongoDbTestJson.ToDocuments($"{result.Response.Entity["Result"]}");

            // Assert: exactly the second-highest total is exported.
            Assert.HasCount(expected: 1, collection: documents);
            Assert.AreEqual(expected: 20, actual: documents[0]["total"].ToInt32());
        }

        [TestMethod(DisplayName = "Verify that ExportMongoDbQuery decodes a Base64-encoded filter and keeps BSON " +
            "types through the Extended JSON output.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ExportMongoDbQueryBase64FilterTest()
        {
            // Arrange: seed the documents and encode a nested filter, which cannot travel inline.
            SeedDocuments();

            var filter = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes("{\"total\":{\"$gte\":20}}"));
            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                $"--CommandText:{filter} --Base64");

            // Act: export the matching documents through the plugin.
            var result = Invoke<ExportMongoDbQuery>(rule);

            // Assert: the decoded filter matched the two documents above the threshold.
            Assert.AreEqual(expected: "2", actual: $"{result.Response.Entity["DocumentCount"]}");

            // Assert: the identifier keeps its BSON type through the Extended JSON output.
            Assert.Contains(substring: "$oid", value: $"{result.Response.Entity["Result"]}");
        }

        [TestMethod(DisplayName = "Verify that ExportMongoDbQuery reads the filter from CommandFile when no inline " +
            "CommandText is set.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ExportMongoDbQueryCommandFileTest()
        {
            // Arrange: seed the documents and write the filter to a temporary UTF-8 file.
            SeedDocuments();
            var path = Path.Combine(Path.GetTempPath(), $"g4-mongo-filter-{Guid.NewGuid():N}.json");
            File.WriteAllText(path, contents: "{\"sku\":\"A-1\"}");

            try
            {
                var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                    $"--CommandFile:{path}");

                // Act: export the matching document through the plugin.
                var result = Invoke<ExportMongoDbQuery>(rule);

                // Assert: the file filter matched the single document that carries the SKU.
                Assert.AreEqual(expected: "1", actual: $"{result.Response.Entity["DocumentCount"]}");
            }
            finally
            {
                // Cleanup: remove the temporary filter file.
                File.Delete(path);
            }
        }

        [TestMethod(DisplayName = "Verify that ExportMongoDbQuery exports an empty result for a filter that " +
            "matches no document.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ExportMongoDbQueryEmptyResultTest()
        {
            // Arrange: seed the documents and filter on a value no document carries.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--CommandText:{\"sku\":\"missing\"}");

            // Act: export the matching documents through the plugin.
            var result = Invoke<ExportMongoDbQuery>(rule);
            var entity = result.Response.Entity;

            // Assert: an empty result is data, not a failure, so a flow can branch on the count.
            Assert.AreEqual(expected: "0", actual: $"{entity["DocumentCount"]}");
            Assert.AreEqual(expected: "[]", actual: $"{entity["Result"]}");
            Assert.AreEqual(expected: "[]", actual: $"{entity["Columns"]}");
        }

        [TestMethod(DisplayName = "Verify that ExportMongoDbQuery fails with a missing mandatory argument report " +
            "when the Collection argument is missing.")]
        public void ExportMongoDbQueryMissingCollectionTest()
        {
            // Arrange: provide a connection but no collection.
            var rule = NewRule(arguments: "--ConnectionString:mongodb://127.0.0.1:27017/G4Tests --CommandTimeout:5");

            // Act: run the step; the manifest marks Collection mandatory, so the engine rejects it before OnSend.
            var response = Invoke<ExportMongoDbQuery>(rule).Response;

            // Assert: the response reports the missing argument by name and exports nothing.
            var messages = string.Join(" | ", response.Exceptions.Select(i => i.Exception.Message));
            Assert.Contains(substring: "'Collection'", value: messages);
            Assert.IsFalse(response.Entity.ContainsKey("Result"));
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
                PluginName = nameof(ExportMongoDbQuery),
                Argument = "{{$ " + arguments + "}}"
            };
        }

        // Reads the exported field names from the entity, so a scenario can assert on the projection order.
        private static string[] ReadColumns(IDictionary<string, object> entity)
        {
            // Parse the JSON array the plugin stored as text.
            return MongoDbTestJson.ToStrings($"{entity["Columns"]}");
        }

        // Replaces the scenario collection with three documents: two open and one closed, with distinct totals.
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
