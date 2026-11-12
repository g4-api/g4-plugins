using G4.Credentials.Models;
using G4.Models;
using G4.Plugins.MongoDb.DataCollectors;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;

using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("MongoDbDataCollector")]
    [TestCategory("UnitTest")]
    public class MongoDbDataCollectorTests : TestBase
    {
        // Names the credentials record the credentials-name scenario resolves; unique so parallel tests never collide.
        private const string CredentialName = "mongodb-collector-tests";

        [TestMethod(DisplayName = "Verify that the MongoDbDataCollector plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the collector manifest documentation renders as the cache expects.
            AssertManifest<MongoDbDataCollector>();
        }

        [TestMethod(DisplayName = "Verify that the MongoDbDataCollector plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the collector can be created through the plugin factory.
            AssertPlugin<MongoDbDataCollector>();
        }

        [TestMethod(DisplayName = "Verify that the MongoDbDataCollector creates the collection and writes every " +
            "entity when the Source is a raw connection URI.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void MongoDbDataCollectorCreatesCollectionTest()
        {
            // Arrange: remove the destination collection so the first insert creates it.
            const string collection = "CollectorCreated";
            MongoDbTestContainer.Drop(collection);

            // Act: export both simulator entities into the new collection.
            var exceptions = InvokeExport(
                source: MongoDbTestContainer.ConnectionString,
                repository: collection,
                key: "Description");

            // Assert: the export reports no failure and both entities are stored with the extracted key.
            var failures = string.Join(" | ", exceptions.Select(i => i.Exception.Message));
            Assert.IsEmpty(collection: exceptions, message: failures);

            var documents = MongoDbTestContainer.Find(collection);
            Assert.HasCount(expected: 2, collection: documents);
            Assert.IsTrue(condition: documents.TrueForAll(i => i.Contains("Description")));
        }

        [TestMethod(DisplayName = "Verify that the MongoDbDataCollector writes into the collection of a " +
            "database-qualified repository.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void MongoDbDataCollectorQualifiedRepositoryTest()
        {
            // Arrange: remove the destination collection and qualify it with the test database.
            const string collection = "CollectorQualified";
            MongoDbTestContainer.Drop(collection);

            // Act: export both simulator entities into the qualified repository.
            var exceptions = InvokeExport(
                source: MongoDbTestContainer.ConnectionString,
                repository: $"{MongoDbTestContainer.DatabaseName}.{collection}",
                key: "Description");

            // Assert: the qualified name addressed the same database and both entities are stored.
            var failures = string.Join(" | ", exceptions.Select(i => i.Exception.Message));
            Assert.IsEmpty(collection: exceptions, message: failures);
            Assert.AreEqual(expected: 2, actual: MongoDbTestContainer.Count(collection));
        }

        [TestMethod(DisplayName = "Verify that the MongoDbDataCollector resolves a stored credentials record by " +
            "name and writes every entity through it.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void MongoDbDataCollectorCredentialsNameTest()
        {
            // Arrange: remove the destination collection and store the test deployment as a named record.
            const string collection = "CollectorCredentials";
            MongoDbTestContainer.Drop(collection);

            var credential = MongoDbTestCredentials.AddCredential(credential: new MongoDbCredentialModel
            {
                Name = CredentialName,
                ConnectionString = MongoDbTestContainer.ConnectionString
            });

            try
            {
                // Act: export both simulator entities through the record name.
                var exceptions = InvokeExport(
                    source: CredentialName,
                    repository: collection,
                    key: "Description");

                // Assert: the record connection reached the test database and both entities are stored.
                var failures = string.Join(" | ", exceptions.Select(i => i.Exception.Message));
                Assert.IsEmpty(collection: exceptions, message: failures);
                Assert.AreEqual(expected: 2, actual: MongoDbTestContainer.Count(collection));
            }
            finally
            {
                // Cleanup: remove the record from the cache so other tests resolve their own credentials only.
                MongoDbTestCredentials.RemoveCredential(credential);
            }
        }

        [TestMethod(DisplayName = "Verify that the MongoDbDataCollector reports a content key that MongoDB cannot " +
            "address as a failure instead of writing it.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void MongoDbDataCollectorInvalidKeyTest()
        {
            // Arrange: remove the destination collection and extract into a key that holds the path separator.
            const string collection = "CollectorInvalidKey";
            MongoDbTestContainer.Drop(collection);

            // Act: export both simulator entities under a key the collector must reject.
            var exceptions = InvokeExport(
                source: MongoDbTestContainer.ConnectionString,
                repository: collection,
                key: "product.description");

            // Assert: the collector reports the offending key and writes nothing.
            Assert.IsNotEmpty(collection: exceptions);
            Assert.Contains(
                substring: "product.description",
                value: string.Join(" | ", exceptions.Select(i => i.Exception.Message)));
            Assert.AreEqual(expected: 0, actual: MongoDbTestContainer.Count(collection));
        }

        // Runs an Elements-scope export over the simulator page with one content rule and a MongoDB collector that
        // writes per entity, returning the exceptions reported by the session. The collector owns its client, so the
        // destination collection is observable through a separate client once this returns.
        private IEnumerable<G4ExceptionModel> InvokeExport(string source, string repository, string key)
        {
            // Build the export container: the simulator resolves '//positive' to two elements, so the collector
            // writes two entities.
            var action = new ActionRuleModel
            {
                PluginName = "NoAction",
                Argument = "Export Data Container",
                Rules =
                [
                    new ExtractionRuleModel
                    {
                        Argument = "{{$ --Scope:Elements}}",
                        OnElement = "//positive",
                        DataCollector = new G4DataProviderModel
                        {
                            ForEntity = true,
                            Repository = repository,
                            Source = source,
                            Type = nameof(MongoDbDataCollector)
                        },
                        Rules =
                        [
                            new ContentRuleModel
                            {
                                OnElement = ".//positive",
                                Key = key,
                                PluginName = "WebElementContent"
                            }
                        ]
                    }
                ]
            };

            // Invoke the automation and return the session exceptions for the caller's assertions.
            var session = Invoke([action]).Response.Values.First().Sessions.First().Value;

            return session.ResponseData.Exceptions ?? [];
        }
    }
}
