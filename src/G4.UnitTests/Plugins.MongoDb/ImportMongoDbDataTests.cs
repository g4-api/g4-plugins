using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;

using System;
using System.IO;
using System.Linq;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("ImportMongoDbData")]
    [TestCategory("UnitTest")]
    public class ImportMongoDbDataTests : TestBase
    {
        // Names the collection every scenario of this class writes, so no other class shares its documents.
        private const string Collection = "ImportDocuments";

        [TestMethod(DisplayName = "Verify that the ImportMongoDbData plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<ImportMongoDbData>();
        }

        [TestMethod(DisplayName = "Verify that the ImportMongoDbData plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<ImportMongoDbData>();
        }

        [TestMethod(DisplayName = "Verify that ImportMongoDbData inserts inline JSON documents and reports their " +
            "count as a Base64-encoded session parameter and in the entity.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ImportMongoDbDataInlineJsonTest()
        {
            // Arrange: start from an empty collection and import two documents inline.
            MongoDbTestContainer.Drop(Collection);

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                "--Data:[{\"name\":\"Ada\",\"tier\":\"gold\"},{\"name\":\"Linus\",\"tier\":\"silver\"}]");

            // Act: import the documents through the plugin.
            var result = Invoke<ImportMongoDbData>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: both documents landed and the plugin reported their count in both outputs.
            Assert.AreEqual(expected: "2", actual: $"{result.Response.Entity["DocumentsInserted"]}");
            Assert.AreEqual(
                expected: "2",
                actual: $"{sessionParameters["ImportMongoDbData:DocumentsInserted"]}".ConvertFromBase64());
            Assert.AreEqual(expected: 2, actual: MongoDbTestContainer.Count(Collection));
        }

        [TestMethod(DisplayName = "Verify that ImportMongoDbData parses a CSV file by its extension, inserts every " +
            "cell as text, and omits empty unquoted fields.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ImportMongoDbDataCsvFileTest()
        {
            // Arrange: start from an empty collection and write a CSV with a quoted comma and an empty field.
            MongoDbTestContainer.Drop(Collection);

            var csv = "name,tier,note\r\n" +
                "\"Doe, Jane\",gold,first\r\n" +
                "Linus,,second\r\n";
            var path = NewTempFile(extension: ".csv", contents: csv);

            try
            {
                var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                    $"--DataFile:{path} --BatchSize:1");

                // Act: import the CSV through the plugin.
                var result = Invoke<ImportMongoDbData>(rule);

                // Assert: both records landed, even though each batch carried one document.
                Assert.AreEqual(expected: "2", actual: $"{result.Response.Entity["DocumentsInserted"]}");

                // Assert: the quoted comma survived and every cell is stored as text.
                var documents = MongoDbTestContainer.Find(Collection);
                var jane = documents.Single(i => $"{i.GetValue("name", string.Empty)}" == "Doe, Jane");
                Assert.AreEqual(expected: BsonType.String, actual: jane["tier"].BsonType);

                // Assert: the empty unquoted field is omitted, so a query can tell it from an empty value.
                var linus = documents.Single(i => $"{i.GetValue("name", string.Empty)}" == "Linus");
                Assert.IsFalse(condition: linus.Contains("tier"));
            }
            finally
            {
                // Cleanup: remove the temporary CSV file.
                File.Delete(path);
            }
        }

        [TestMethod(DisplayName = "Verify that ImportMongoDbData parses a JSON file for any extension other than " +
            "csv and commits the import as one transaction.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ImportMongoDbDataJsonFileInTransactionTest()
        {
            // Arrange: start from an empty collection and write the documents to a JSON file.
            MongoDbTestContainer.Drop(Collection);

            var path = NewTempFile(extension: ".json", contents: "[{\"sku\":\"A-1\"},{\"sku\":\"B-2\"}]");

            try
            {
                var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                    $"--DataFile:{path} --Ordered --Transaction");

                // Act: import the file through the plugin.
                var result = Invoke<ImportMongoDbData>(rule);

                // Assert: the transaction committed, so both documents are observable.
                Assert.AreEqual(expected: "2", actual: $"{result.Response.Entity["DocumentsInserted"]}");
                Assert.AreEqual(expected: 2, actual: MongoDbTestContainer.Count(Collection));
            }
            finally
            {
                // Cleanup: remove the temporary JSON file.
                File.Delete(path);
            }
        }

        [TestMethod(DisplayName = "Verify that ImportMongoDbData prefers the inline Data payload over the DataFile " +
            "argument.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void ImportMongoDbDataInlineWinsTest()
        {
            // Arrange: start from an empty collection and set both payload arguments to different content.
            MongoDbTestContainer.Drop(Collection);

            var path = NewTempFile(extension: ".json", contents: "[{\"sku\":\"FROM-FILE\"}]");

            try
            {
                var rule = NewRule(arguments: $"{NewConnectionArgument()} --Collection:{Collection} " +
                    $"--Data:[{{\"sku\":\"FROM-INLINE\"}}] --DataFile:{path}");

                // Act: import through the plugin, which must read the inline payload.
                Invoke<ImportMongoDbData>(rule);

                // Assert: only the inline document landed.
                var documents = MongoDbTestContainer.Find(Collection);
                Assert.HasCount(expected: 1, collection: documents);
                Assert.AreEqual(expected: "FROM-INLINE", actual: documents[0]["sku"].AsString);
            }
            finally
            {
                // Cleanup: remove the temporary JSON file.
                File.Delete(path);
            }
        }

        [TestMethod(DisplayName = "Verify that ImportMongoDbData fails when neither Data nor DataFile is set.")]
        public void ImportMongoDbDataMissingPayloadTest()
        {
            // Arrange: name a collection but pass no payload; the target is never contacted.
            var rule = NewRule(arguments: "--Host:127.0.0.1 --Database:G4Tests --Collection:x");

            // Act and Assert: the failure names both payload arguments.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => Invoke<ImportMongoDbData>(rule));
            Assert.Contains(substring: "'Data' or 'DataFile'", value: exception.Message);
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
                PluginName = nameof(ImportMongoDbData),
                Argument = "{{$ " + arguments + "}}"
            };
        }

        // Writes a UTF-8 payload file with the given extension and returns its path; the caller deletes it.
        private static string NewTempFile(string extension, string contents)
        {
            // Name the file uniquely so parallel runs never read each other's payload.
            var path = Path.Combine(Path.GetTempPath(), $"g4-mongo-import-{Guid.NewGuid():N}{extension}");
            File.WriteAllText(path, contents);

            return path;
        }
    }
}
