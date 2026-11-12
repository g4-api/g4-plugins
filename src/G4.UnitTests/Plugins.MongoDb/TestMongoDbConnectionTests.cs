using G4.Extensions;
using G4.Models;
using G4.Plugins.MongoDb.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("TestMongoDbConnection")]
    [TestCategory("UnitTest")]
    public class TestMongoDbConnectionTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the TestMongoDbConnection plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<TestMongoDbConnection>();
        }

        [TestMethod(DisplayName = "Verify that the TestMongoDbConnection plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<TestMongoDbConnection>();
        }

        [TestMethod(DisplayName = "Verify that TestMongoDbConnection reports a connected probe with the database " +
            "and server version as Base64-encoded session parameters and in the entity.")]
        [TestCategory("MongoDbLive")]
        public void TestMongoDbConnectionConnectedTest()
        {
            // Arrange: target the shared test deployment through its raw connection URI.
            var rule = NewRule(arguments: $"--ConnectionString:{MongoDbTestContainer.ConnectionString}");

            // Act: probe the deployment through the plugin.
            var result = Invoke<TestMongoDbConnection>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;
            var entity = result.Response.Entity;

            // Assert: the session holds the Base64-encoded probe outcome under the plugin namespace.
            Assert.AreEqual(
                expected: "true",
                actual: $"{sessionParameters["TestMongoDbConnection:Connected"]}".ConvertFromBase64());
            Assert.AreEqual(
                expected: MongoDbTestContainer.DatabaseName,
                actual: $"{sessionParameters["TestMongoDbConnection:Database"]}".ConvertFromBase64());

            // Assert: the entity reports the reached deployment details and no driver error.
            Assert.AreEqual(expected: "true", actual: entity["Connected"]);
            Assert.AreEqual(expected: MongoDbTestContainer.DatabaseName, actual: entity["Database"]);
            Assert.IsFalse(string.IsNullOrWhiteSpace($"{entity["ServerVersion"]}"));
            Assert.AreEqual(expected: string.Empty, actual: entity["Error"]);
        }

        [TestMethod(DisplayName = "Verify that TestMongoDbConnection omits the entity when the NoEntity switch is " +
            "set and still stores the session parameters.")]
        [TestCategory("MongoDbLive")]
        public void TestMongoDbConnectionNoEntityTest()
        {
            // Arrange: target the shared test deployment and request no entity.
            var rule = NewRule(
                arguments: $"--ConnectionString:{MongoDbTestContainer.ConnectionString} --NoEntity");

            // Act: probe the deployment through the plugin.
            var result = Invoke<TestMongoDbConnection>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the entity is omitted while the session output is still written.
            Assert.IsTrue(result.Response.Entity is null || result.Response.Entity.Count == 0);
            Assert.AreEqual(
                expected: "true",
                actual: $"{sessionParameters["TestMongoDbConnection:Connected"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that TestMongoDbConnection probes the admin database when the connection " +
            "names none.")]
        [TestCategory("MongoDbLive")]
        public void TestMongoDbConnectionAdminFallbackTest()
        {
            // Arrange: strip the database from the shared URI so the probe falls back to admin.
            var connectionString = MongoDbTestContainer.ConnectionString
                .Replace($"/{MongoDbTestContainer.DatabaseName}?", "/?");
            var rule = NewRule(arguments: $"--ConnectionString:{connectionString}");

            // Act: probe the deployment through the plugin.
            var result = Invoke<TestMongoDbConnection>(rule);
            var entity = result.Response.Entity;

            // Assert: the probe reaches the database every deployment carries.
            Assert.AreEqual(expected: "true", actual: entity["Connected"]);
            Assert.AreEqual(expected: "admin", actual: entity["Database"]);
        }

        [TestMethod(DisplayName = "Verify that TestMongoDbConnection fails when no MongoDB target is resolved.")]
        public void TestMongoDbConnectionMissingTargetTest()
        {
            // Arrange: provide only a switch, so neither credentials, a connection URI, nor a host is set.
            var rule = NewRule(arguments: "--NoEntity");

            // Act and Assert: the unresolved target is a configuration error, not a probe outcome.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(
                () => Invoke<TestMongoDbConnection>(rule));
            Assert.Contains(substring: "No MongoDB target was resolved", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that TestMongoDbConnection reports an unreachable deployment as not " +
            "connected with the driver error instead of failing.")]
        public void TestMongoDbConnectionUnreachableTest()
        {
            // Arrange: target a loopback port with no listener (port 1 is reserved and closed on test machines) and
            // bound the attempt so the probe fails fast.
            var rule = NewRule(
                arguments: "--Host:127.0.0.1 --Port:1 --Database:G4Tests --DirectConnection --CommandTimeout:2");

            // Act: probe the unreachable deployment through the plugin.
            var result = Invoke<TestMongoDbConnection>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;
            var entity = result.Response.Entity;

            // Assert: the probe outcome is reported, not thrown, so a flow can branch on availability.
            Assert.AreEqual(expected: "false", actual: entity["Connected"]);
            Assert.AreEqual(expected: string.Empty, actual: entity["Database"]);
            Assert.AreEqual(expected: string.Empty, actual: entity["ServerVersion"]);
            Assert.IsFalse(string.IsNullOrWhiteSpace($"{entity["Error"]}"));

            // Assert: the session carries the same failed outcome under the plugin namespace.
            Assert.AreEqual(
                expected: "false",
                actual: $"{sessionParameters["TestMongoDbConnection:Connected"]}".ConvertFromBase64());
        }

        // Creates an Action rule whose CLI argument holds the scenario arguments, including any connection input.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Compose the CLI expression the plugin parses into its parameters.
            return new ActionRuleModel
            {
                PluginName = nameof(TestMongoDbConnection),
                Argument = "{{$ " + arguments + "}}"
            };
        }
    }
}
