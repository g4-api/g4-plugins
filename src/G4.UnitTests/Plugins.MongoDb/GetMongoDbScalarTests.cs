using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;

using System;
using System.Linq;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("GetMongoDbScalar")]
    [TestCategory("UnitTest")]
    public class GetMongoDbScalarTests : TestBase
    {
        // Names the collection every scenario of this class reads, so no other class shares its documents.
        private const string Collection = "ScalarDocuments";

        // Statuses expected from the distinct scenario, sorted so the comparison never depends on server order.
        private static readonly string[] ExpectedStatuses = ["closed", "open"];

        [TestMethod(DisplayName = "Verify that the GetMongoDbScalar plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<GetMongoDbScalar>();
        }

        [TestMethod(DisplayName = "Verify that the GetMongoDbScalar plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<GetMongoDbScalar>();
        }

        [TestMethod(DisplayName = "Verify that GetMongoDbScalar counts the matching documents and stores the count " +
            "as a Base64-encoded session parameter and in the entity.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void GetMongoDbScalarCountTest()
        {
            // Arrange: seed the documents and count the open ones, without naming the default mode.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--CommandText:{\"status\":\"open\"}");

            // Act: read the count through the plugin.
            var result = Invoke<GetMongoDbScalar>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the count reaches both outputs, so a condition can branch on it.
            Assert.AreEqual(expected: "2", actual: $"{result.Response.Entity["Value"]}");
            Assert.AreEqual(
                expected: "2",
                actual: $"{sessionParameters["GetMongoDbScalar:Value"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that GetMongoDbScalar reads one field of the first matching document, " +
            "following a dot path and honoring the sort.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void GetMongoDbScalarFieldTest()
        {
            // Arrange: seed the documents and read the city of the highest total.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} --Mode:Field " +
                "--Field:address.city --Sort:{\"total\":-1}");

            // Act: read the field through the plugin.
            var result = Invoke<GetMongoDbScalar>(rule);

            // Assert: a string value is stored raw, so a later step can use it directly.
            Assert.AreEqual(expected: "Tel Aviv", actual: $"{result.Response.Entity["Value"]}");
        }

        [TestMethod(DisplayName = "Verify that GetMongoDbScalar stores an empty value when the Field mode finds no " +
            "document or no field.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void GetMongoDbScalarMissingFieldTest()
        {
            // Arrange: seed the documents and read a field no document carries.
            SeedDocuments();

            var missingField = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Mode:Field --Field:address.zip");
            var missingDocument = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Mode:Field --Field:sku --CommandText:{\"sku\":\"missing\"}");

            // Act: read both missing values through the plugin.
            var fieldResult = Invoke<GetMongoDbScalar>(missingField);
            var documentResult = Invoke<GetMongoDbScalar>(missingDocument);

            // Assert: both report an empty value instead of failing.
            Assert.AreEqual(expected: string.Empty, actual: $"{fieldResult.Response.Entity["Value"]}");
            Assert.AreEqual(expected: string.Empty, actual: $"{documentResult.Response.Entity["Value"]}");
        }

        [TestMethod(DisplayName = "Verify that GetMongoDbScalar collects the distinct values of a field as a JSON " +
            "array, keeping mixed types.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void GetMongoDbScalarDistinctTest()
        {
            // Arrange: seed the documents and collect the distinct status values.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} --Mode:Distinct " +
                "--Field:status");

            // Act: read the distinct values through the plugin.
            var result = Invoke<GetMongoDbScalar>(rule);
            var values = MongoDbTestJson.ToValues($"{result.Response.Entity["Value"]}");

            // Assert: both distinct statuses are reported, each exactly once.
            var statuses = values
                .Select(i => i.AsString)
                .OrderBy(i => i)
                .ToArray();

            Assert.AreSequenceEqual(expected: ExpectedStatuses, actual: statuses);
        }

        [TestMethod(DisplayName = "Verify that GetMongoDbScalar fails for an unknown Mode and names the accepted " +
            "values.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void GetMongoDbScalarUnknownModeTest()
        {
            // Arrange: seed the documents and request a mode the plugin does not offer.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} --Mode:Average");

            // Act and Assert: the failure names the modes a step may request.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => Invoke<GetMongoDbScalar>(rule));
            Assert.Contains(substring: "Count", value: exception.Message);
            Assert.Contains(substring: "Distinct", value: exception.Message);
            Assert.Contains(substring: "Field", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that GetMongoDbScalar fails when the Distinct mode names no field.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void GetMongoDbScalarDistinctWithoutFieldTest()
        {
            // Arrange: seed the documents and omit the field the distinct mode needs.
            SeedDocuments();

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} --Mode:Distinct");

            // Act and Assert: the missing argument is named in the failure.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => Invoke<GetMongoDbScalar>(rule));
            Assert.Contains(substring: "Field", value: exception.Message);
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
                PluginName = nameof(GetMongoDbScalar),
                Argument = "{{$ " + arguments + "}}"
            };
        }

        // Replaces the scenario collection with three documents: two open and one closed, each with a nested
        // address, so the dot-path and distinct scenarios read known values.
        private static void SeedDocuments()
        {
            // Drop the collection first so every scenario reads the same three documents.
            MongoDbTestContainer.Drop(Collection);

            MongoDbTestContainer.Insert(Collection,
            [
                new BsonDocument
                {
                    ["sku"] = "A-1",
                    ["status"] = "open",
                    ["total"] = 10,
                    ["address"] = new BsonDocument { ["city"] = "Haifa" }
                },
                new BsonDocument
                {
                    ["sku"] = "B-2",
                    ["status"] = "open",
                    ["total"] = 20,
                    ["address"] = new BsonDocument { ["city"] = "Jerusalem" }
                },
                new BsonDocument
                {
                    ["sku"] = "C-3",
                    ["status"] = "closed",
                    ["total"] = 30,
                    ["address"] = new BsonDocument { ["city"] = "Tel Aviv" }
                }
            ]);
        }
    }
}
