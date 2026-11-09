using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("TestSqlServerConnection")]
    [TestCategory("UnitTest")]
    public class TestSqlServerConnectionTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the TestSqlServerConnection plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<TestSqlServerConnection>();
        }

        [TestMethod(DisplayName = "Verify that the TestSqlServerConnection plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<TestSqlServerConnection>();
        }

        [TestMethod(DisplayName = "Verify that TestSqlServerConnection reports a connected probe with the database " +
            "and server version as Base64-encoded session parameters and in the entity.")]
        [TestCategory("SqlServerLive")]
        public void TestSqlServerConnectionConnectedTest()
        {
            // Arrange: target the shared test database through its raw connection string.
            var rule = NewRule(arguments: $"--ConnectionString:{SqlServerTestContainer.ConnectionString}");

            // Act: probe the server through the plugin.
            var result = Invoke<TestSqlServerConnection>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;
            var entity = result.Response.Entity;

            // Assert: the session holds the Base64-encoded probe outcome under the plugin namespace.
            Assert.AreEqual(
                expected: "true",
                actual: $"{sessionParameters["TestSqlServerConnection:Connected"]}".ConvertFromBase64());
            Assert.AreEqual(
                expected: SqlServerTestContainer.DatabaseName,
                actual: $"{sessionParameters["TestSqlServerConnection:Database"]}".ConvertFromBase64());

            // Assert: the entity reports the open session details and no provider error.
            Assert.AreEqual(expected: "true", actual: entity["Connected"]);
            Assert.AreEqual(expected: SqlServerTestContainer.DatabaseName, actual: entity["Database"]);
            Assert.IsFalse(string.IsNullOrWhiteSpace($"{entity["ServerVersion"]}"));
            Assert.AreEqual(expected: string.Empty, actual: entity["Error"]);
        }

        [TestMethod(DisplayName = "Verify that TestSqlServerConnection omits the entity when the NoEntity switch is " +
            "set and still stores the session parameters.")]
        [TestCategory("SqlServerLive")]
        public void TestSqlServerConnectionNoEntityTest()
        {
            // Arrange: target the shared test database and request no entity.
            var rule = NewRule(arguments: $"--ConnectionString:{SqlServerTestContainer.ConnectionString} --NoEntity");

            // Act: probe the server through the plugin.
            var result = Invoke<TestSqlServerConnection>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the entity is omitted while the session output is still written.
            Assert.IsTrue(result.Response.Entity is null || result.Response.Entity.Count == 0);
            Assert.AreEqual(
                expected: "true",
                actual: $"{sessionParameters["TestSqlServerConnection:Connected"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that TestSqlServerConnection fails when no SQL Server target is resolved.")]
        public void TestSqlServerConnectionMissingTargetTest()
        {
            // Arrange: provide only a switch, so neither credentials, a connection string, nor a server is set.
            var rule = NewRule(arguments: "--NoEntity");

            // Act and Assert: the unresolved target is a configuration error, not a probe outcome.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(
                () => Invoke<TestSqlServerConnection>(rule));
            Assert.Contains(substring: "No SQL Server target was resolved", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that TestSqlServerConnection reports an unreachable server as not " +
            "connected with the provider error instead of failing.")]
        public void TestSqlServerConnectionUnreachableTest()
        {
            // Arrange: target a loopback port with no listener (port 1 is reserved and closed on test machines) and
            // bound the login attempt so the probe fails fast.
            var unreachableConnectionString = "Server=127.0.0.1,1;Connect Timeout=2;Encrypt=Optional";
            var rule = NewRule(arguments: $"--ConnectionString:{unreachableConnectionString}");

            // Act: probe the unreachable server through the plugin.
            var result = Invoke<TestSqlServerConnection>(rule);
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
                actual: $"{sessionParameters["TestSqlServerConnection:Connected"]}".ConvertFromBase64());
        }

        // Creates an Action rule whose CLI argument holds the scenario arguments, including any connection input.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Compose the CLI expression the plugin parses into its parameters.
            return new ActionRuleModel
            {
                PluginName = nameof(TestSqlServerConnection),
                Argument = "{{$ " + arguments + "}}"
            };
        }
    }
}
