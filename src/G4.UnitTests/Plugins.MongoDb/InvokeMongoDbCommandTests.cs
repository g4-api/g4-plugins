using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("InvokeMongoDbCommand")]
    [TestCategory("UnitTest")]
    public class InvokeMongoDbCommandTests : TestBase
    {
        // Names the collection the command scenarios address, so no other class shares its documents.
        private const string Collection = "CommandDocuments";

        [TestMethod(DisplayName = "Verify that the InvokeMongoDbCommand plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<InvokeMongoDbCommand>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeMongoDbCommand plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<InvokeMongoDbCommand>();
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbCommand runs a command and stores the whole response, " +
            "the ok flag, and the database.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbCommandPingTest()
        {
            // Arrange: send the cheapest command every deployment answers.
            var rule = NewRule(arguments: $"{NewConnectionArgument()} --CommandText:{{\"ping\":1}}");

            // Act: run the command through the plugin.
            var result = Invoke<InvokeMongoDbCommand>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;
            var entity = result.Response.Entity;

            // Assert: the response reports success and names the database it ran on.
            Assert.AreEqual(expected: "true", actual: $"{entity["Ok"]}");
            Assert.AreEqual(expected: MongoDbTestContainer.DatabaseName, actual: $"{entity["Database"]}");

            // Assert: the whole response document is stored, not a selected field.
            var response = BsonDocument.Parse($"{entity["Result"]}");
            Assert.IsTrue(condition: response.Contains("ok"));

            // Assert: the session carries the same flag under the plugin namespace.
            Assert.AreEqual(
                expected: "true",
                actual: $"{sessionParameters["InvokeMongoDbCommand:Ok"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbCommand creates an index and that the index is " +
            "observable afterwards.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbCommandCreateIndexTest()
        {
            // Arrange: start from a collection that holds one document, so it exists before the index is created.
            MongoDbTestContainer.Drop(Collection);
            MongoDbTestContainer.Insert(Collection, [new BsonDocument { ["status"] = "open" }]);

            var command = $"{{\"createIndexes\":\"{Collection}\",\"indexes\":" +
                "[{\"key\":{\"status\":1},\"name\":\"status_1\"}]}";
            var rule = NewRule(arguments: $"{NewConnectionArgument()} --CommandText:{command}");

            // Act: create the index through the plugin.
            var result = Invoke<InvokeMongoDbCommand>(rule);

            // Assert: the server reported the command as successful.
            Assert.AreEqual(expected: "true", actual: $"{result.Response.Entity["Ok"]}");

            // Assert: the index is observable through a separate client, so the command really ran.
            var indexNames = MongoDbTestContainer.GetIndexNames(Collection);

            Assert.Contains("status_1", indexNames);
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbCommand runs on the database named by the step instead " +
            "of the one the connection resolved.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbCommandDatabaseOverrideTest()
        {
            // Arrange: run a command on the database every deployment carries, overriding the connection database.
            var rule = NewRule(arguments: $"{NewConnectionArgument()} --Database:admin " +
                "--CommandText:{\"buildInfo\":1}");

            // Act: run the command through the plugin.
            var result = Invoke<InvokeMongoDbCommand>(rule);
            var entity = result.Response.Entity;

            // Assert: the step argument selected the target and the response carries the version.
            Assert.AreEqual(expected: "admin", actual: $"{entity["Database"]}");
            Assert.Contains(substring: "version", value: $"{entity["Result"]}");
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbCommand fails when the command document is missing or " +
            "names no command.")]
        public void InvokeMongoDbCommandMissingCommandTest()
        {
            // Arrange: pass no command and then an empty command document; the target is never contacted.
            var missing = NewRule(arguments: "--ConnectionString:mongodb://127.0.0.1:27017 --Database:G4Tests");
            var empty = NewRule(
                arguments: "--ConnectionString:mongodb://127.0.0.1:27017 --Database:G4Tests --CommandText:{}");

            // Act and Assert: both failures name what the step must carry.
            var missingException = Assert.ThrowsExactly<InvalidOperationException>(
                () => Invoke<InvokeMongoDbCommand>(missing));
            Assert.Contains(substring: "CommandText", value: missingException.Message);

            var emptyException = Assert.ThrowsExactly<InvalidOperationException>(
                () => Invoke<InvokeMongoDbCommand>(empty));
            Assert.Contains(substring: "must name a command", value: emptyException.Message);
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbCommand fails when no database is resolved.")]
        public void InvokeMongoDbCommandMissingDatabaseTest()
        {
            // Arrange: resolve a host without a database, so the command has no target.
            var rule = NewRule(arguments: "--ConnectionString:mongodb://127.0.0.1:27017 --CommandText:{\"ping\":1}");

            // Act and Assert: the failure names the inputs a flow can set.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(
                () => Invoke<InvokeMongoDbCommand>(rule));
            Assert.Contains(substring: "No MongoDB database was resolved", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbCommand drops a collection addressed through a raw " +
            "connection URI and that the collection is gone afterwards.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbCommandDropCollectionTest()
        {
            // Arrange: start from a collection that holds one document, so it exists before the drop.
            MongoDbTestContainer.Drop(Collection);
            MongoDbTestContainer.Insert(Collection, [new BsonDocument { ["status"] = "open" }]);

            var rule = NewRule(arguments: $"{NewConnectionArgument()} --CommandText:{{\"drop\":\"{Collection}\"}}");

            // Act: drop the collection through the plugin.
            var result = Invoke<InvokeMongoDbCommand>(rule);

            // Assert: the server reported the command as successful.
            Assert.AreEqual(expected: "true", actual: $"{result.Response.Entity["Ok"]}");

            // Assert: the collection is gone, so the command dropped it instead of only removing its documents.
            Assert.DoesNotContain(Collection, GetCollectionNames());
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbCommand decodes a Base64-encoded command document and " +
            "runs the command it carries.")]
        [TestCategory("MongoDbLive")]
        [DoNotParallelize]
        public void InvokeMongoDbCommandBase64Test()
        {
            // Arrange: start from a collection that holds one document, so the index has something to index.
            MongoDbTestContainer.Drop(Collection);
            MongoDbTestContainer.Insert(Collection, [new BsonDocument { ["priority"] = 1 }]);

            // Arrange: encode a command whose nested documents end in braces that would end an inline value.
            var command = $"{{\"createIndexes\":\"{Collection}\",\"indexes\":" +
                "[{\"key\":{\"priority\":1},\"name\":\"priority_1\"}]}";
            var rule = NewRule(arguments: $"{NewConnectionArgument()} --CommandText:{command.ConvertToBase64()} " +
                "--Base64");

            // Act: run the encoded command through the plugin.
            var result = Invoke<InvokeMongoDbCommand>(rule);

            // Assert: the server reported the command as successful.
            Assert.AreEqual(expected: "true", actual: $"{result.Response.Entity["Ok"]}");

            // Assert: the index the decoded command names exists, so the switch decoded the payload.
            Assert.Contains("priority_1", MongoDbTestContainer.GetIndexNames(Collection));
        }

        [TestMethod(DisplayName = "Verify that InvokeMongoDbCommand fails when the Base64 switch is set and the " +
            "command document is not valid Base64.")]
        public void InvokeMongoDbCommandInvalidBase64Test()
        {
            // Arrange: mark a plain command document as encoded; the target is never contacted.
            var rule = NewRule(arguments: "--ConnectionString:mongodb://127.0.0.1:27017 --Database:G4Tests " +
                "--CommandText:{\"ping\":1} --Base64");

            // Act and Assert: the failure names the argument and the switch that caused the decode.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(
                () => Invoke<InvokeMongoDbCommand>(rule));
            Assert.Contains(substring: "CommandText", value: exception.Message);
            Assert.Contains(substring: "Base64", value: exception.Message);
        }

        // Lists the collection names of the test database through a separate client, so a drop is observable.
        private static List<string> GetCollectionNames()
        {
            // Act: read the names the deployment reports, which no longer include a dropped collection.
            using var client = MongoDbTestContainer.NewClient();

            return client.GetDatabase(MongoDbTestContainer.DatabaseName).ListCollectionNames().ToList();
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
                PluginName = nameof(InvokeMongoDbCommand),
                Argument = "{{$ " + arguments + "}}"
            };
        }
    }
}
