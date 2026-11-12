using G4.Models;
using G4.Plugins.MongoDb.Clients;
using G4.Plugins.MongoDb.Extensions;
using G4.Plugins.MongoDb.Models;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.MongoDb
{
    [TestClass]
    [TestCategory("MongoDbConnectionResolution")]
    [TestCategory("UnitTest")]
    public class MongoDbConnectionResolutionTests
    {
        // Connection URI used as the baseline in every scenario; it never reaches a deployment.
        private const string BaselineUri = "mongodb://baseline-host:27018/BaselineDatabase";

        // Names the credentials record seeded by the record-lookup scenario; unique so parallel tests never collide.
        private const string CredentialName = "mongodb-connection-resolution-tests";

        [TestMethod(DisplayName = "Verify that ResolveConnection reads the host, port, and database of a raw " +
            "connection URI passed through Credentials.")]
        public void ResolveConnectionRawUriTest()
        {
            // Act: resolve a URI passed as the credentials value, which carries a scheme.
            var connectionModel = LocalExtensions.ResolveConnection(
                credentials: BaselineUri,
                connectionString: string.Empty,
                overrides: null);

            // Assert: the URI parts reach the client settings and the model database.
            var server = connectionModel.ClientSettings.Server;
            Assert.AreEqual(expected: "baseline-host", actual: server.Host);
            Assert.AreEqual(expected: 27018, actual: server.Port);
            Assert.AreEqual(expected: "BaselineDatabase", actual: connectionModel.Database);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection applies the discrete overrides on top of the " +
            "baseline connection URI and leaves unset parts untouched.")]
        public void ResolveConnectionOverridesTest()
        {
            // Arrange: override the host, the database, the login, and the transport options.
            var overrides = new Dictionary<string, string>
            {
                ["AllowInvalidCertificates"] = string.Empty,
                ["AuthenticationDatabase"] = "admin",
                ["AuthenticationMechanism"] = MongoDbAuthenticationMechanisms.ScramSha256,
                ["Database"] = "Overridden",
                ["Host"] = "override-host",
                ["Password"] = "secret",
                ["ReplicaSet"] = "rs0",
                ["Tls"] = MongoDbTlsModes.Enabled,
                ["Username"] = "reporter"
            };

            // Act: resolve the connection from the baseline and the overrides.
            var connectionModel = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineUri,
                overrides: overrides);

            // Assert: the host is overridden while the baseline port survives, because no port override was set.
            var settings = connectionModel.ClientSettings;
            Assert.AreEqual(expected: "override-host", actual: settings.Server.Host);
            Assert.AreEqual(expected: 27018, actual: settings.Server.Port);

            // Assert: the database, the login, and the transport options follow the overrides.
            Assert.AreEqual(expected: "Overridden", actual: connectionModel.Database);
            Assert.AreEqual(expected: "reporter", actual: settings.Credential.Username);
            Assert.AreEqual(expected: "admin", actual: settings.Credential.Source);
            Assert.AreEqual(expected: "rs0", actual: settings.ReplicaSetName);
            Assert.IsTrue(condition: settings.UseTls);
            Assert.IsTrue(condition: settings.AllowInsecureTls);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection re-targets the baseline host port when only the " +
            "Port override is set.")]
        public void ResolveConnectionPortOnlyOverrideTest()
        {
            // Arrange: override the port alone, which keeps the baseline host.
            var overrides = new Dictionary<string, string>
            {
                ["Port"] = "27019"
            };

            // Act: resolve the connection from the baseline and the port override.
            var connectionModel = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineUri,
                overrides: overrides);

            // Assert: the baseline host keeps its name and receives the overridden port.
            Assert.AreEqual(expected: "baseline-host", actual: connectionModel.ClientSettings.Server.Host);
            Assert.AreEqual(expected: 27019, actual: connectionModel.ClientSettings.Server.Port);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection composes a connection from the discrete " +
            "parameters alone, using the default port when none is set.")]
        public void ResolveConnectionDiscreteOnlyTest()
        {
            // Arrange: set only the host and the database, with no baseline at all.
            var overrides = new Dictionary<string, string>
            {
                ["Database"] = "shop",
                ["DirectConnection"] = string.Empty,
                ["Host"] = "mongo.internal"
            };

            // Act: resolve the connection from the overrides alone.
            var connectionModel = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: string.Empty,
                overrides: overrides);

            // Assert: the host is addressed on the driver default port and the direct connection is requested.
            Assert.AreEqual(expected: "mongo.internal", actual: connectionModel.ClientSettings.Server.Host);
            Assert.AreEqual(expected: MongoDbClient.DefaultPort, actual: connectionModel.ClientSettings.Server.Port);
            Assert.AreEqual(expected: "shop", actual: connectionModel.Database);
            Assert.IsTrue(condition: connectionModel.ClientSettings.DirectConnection);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection bounds connecting and server selection by the " +
            "command timeout and keeps the driver defaults for a timeout of zero.")]
        public void ResolveConnectionTimeoutTest()
        {
            // Arrange: resolve the same target once with a timeout and once without one, through the arguments the
            // resolver reads.
            var boundedOverrides = new Dictionary<string, string>
            {
                ["CommandTimeout"] = "5",
                ["Host"] = "mongo.internal"
            };

            var unboundedOverrides = new Dictionary<string, string>
            {
                ["CommandTimeout"] = "0",
                ["Host"] = "mongo.internal"
            };

            // Act: resolve both connections.
            var bounded = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: string.Empty,
                overrides: boundedOverrides);
            var unbounded = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: string.Empty,
                overrides: unboundedOverrides);

            // Assert: the bounded connection carries the timeout and reports it on the model.
            Assert.AreEqual(expected: TimeSpan.FromSeconds(5), actual: bounded.ClientSettings.ConnectTimeout);
            Assert.AreEqual(expected: TimeSpan.FromSeconds(5), actual: bounded.ClientSettings.ServerSelectionTimeout);
            Assert.AreEqual(expected: 5, actual: bounded.CommandTimeoutSeconds);

            // Assert: a timeout of zero leaves the driver defaults in place.
            Assert.AreNotEqual(notExpected: TimeSpan.FromSeconds(5), actual: unbounded.ClientSettings.ConnectTimeout);
            Assert.AreEqual(expected: 0, actual: unbounded.CommandTimeoutSeconds);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection resolves a stored credentials record by name and " +
            "applies its discrete parts on top of its stored URI.")]
        public void ResolveConnectionCredentialsRecordTest()
        {
            // Arrange: seed a record whose discrete parts override its own stored URI.
            var credential = MongoDbTestCredentials.AddCredential(credential: new MongoDbCredentialModel
            {
                Name = CredentialName,
                ConnectionString = BaselineUri,
                Database = "RecordDatabase",
                Host = "record-host",
                Port = 27020,
                Username = "record-user",
                Password = "record-secret",
                AuthenticationDatabase = "admin",
                ReplicaSet = "rs0"
            });

            try
            {
                // Act: resolve the connection through the record name.
                var connectionModel = LocalExtensions.ResolveConnection(
                    credentials: CredentialName,
                    connectionString: string.Empty,
                    overrides: null);

                // Assert: the record parts win over its stored URI.
                var settings = connectionModel.ClientSettings;
                Assert.AreEqual(expected: "record-host", actual: settings.Server.Host);
                Assert.AreEqual(expected: 27020, actual: settings.Server.Port);
                Assert.AreEqual(expected: "RecordDatabase", actual: connectionModel.Database);
                Assert.AreEqual(expected: "record-user", actual: settings.Credential.Username);
                Assert.AreEqual(expected: "rs0", actual: settings.ReplicaSetName);
            }
            finally
            {
                // Cleanup: remove the record from the cache so other tests resolve their own credentials only.
                MongoDbTestCredentials.RemoveCredential(credential);
            }
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection lets the step arguments override a resolved " +
            "credentials record.")]
        public void ResolveConnectionCredentialsWithOverridesTest()
        {
            // Arrange: seed a record and override its database per step.
            var credential = MongoDbTestCredentials.AddCredential(credential: new MongoDbCredentialModel
            {
                Name = $"{CredentialName}-overridden",
                Host = "record-host",
                Database = "RecordDatabase"
            });

            try
            {
                // Act: resolve the record and override the database only.
                var overrides = new Dictionary<string, string> { ["Database"] = "StepDatabase" };

                var connectionModel = LocalExtensions.ResolveConnection(
                    credentials: credential.Name,
                    connectionString: string.Empty,
                    overrides: overrides);

                // Assert: the step argument wins over the record, while the record host survives.
                Assert.AreEqual(expected: "record-host", actual: connectionModel.ClientSettings.Server.Host);
                Assert.AreEqual(expected: "StepDatabase", actual: connectionModel.Database);
            }
            finally
            {
                // Cleanup: remove the record from the cache so other tests resolve their own credentials only.
                MongoDbTestCredentials.RemoveCredential(credential);
            }
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection rejects a credentials value that matches no record " +
            "and carries no URI scheme.")]
        public void ResolveConnectionUnmatchedCredentialsTest()
        {
            // Act: resolve a record name that was never seeded and capture the rejection.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => LocalExtensions.ResolveConnection(
                credentials: "mongodb-record-that-does-not-exist",
                connectionString: string.Empty,
                overrides: null));

            // Assert: the message names the unmatched value, so a typo never reads as a host name.
            Assert.Contains(substring: "mongodb-record-that-does-not-exist", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection fails when neither credentials, a connection URI, " +
            "nor a host is set.")]
        public void ResolveConnectionMissingTargetTest()
        {
            // Act: resolve with no inputs at all and capture the rejection.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: string.Empty,
                overrides: null));

            // Assert: the message names the inputs a flow can set.
            Assert.Contains(substring: "No MongoDB target was resolved", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that ResolveCommandTimeout reads a non-negative CommandTimeout and falls " +
            "back to the default for missing or invalid values.")]
        #region *** Data Set ***
        [DataRow(null, MongoDbClient.DefaultCommandTimeoutSeconds, DisplayName = "Missing value")]
        [DataRow("45", 45, DisplayName = "Positive value")]
        [DataRow("0", 0, DisplayName = "No timeout")]
        [DataRow("-1", MongoDbClient.DefaultCommandTimeoutSeconds, DisplayName = "Negative value")]
        [DataRow("abc", MongoDbClient.DefaultCommandTimeoutSeconds, DisplayName = "Non-numeric value")]
        #endregion
        public void ResolveCommandTimeoutTest(string value, int expected)
        {
            // Arrange: build the plugin data with only the timeout argument set.
            var pluginData = NewPluginData(arguments: value is null
                ? []
                : new Dictionary<string, string> { ["CommandTimeout"] = value });

            // Act and Assert: a usable value is read and every other value selects the default.
            Assert.AreEqual(expected, actual: pluginData.ResolveCommandTimeout());
        }

        [TestMethod(DisplayName = "Verify that ResolveMaxTime reports the command timeout as a time span and " +
            "reports no limit for a timeout of zero.")]
        public void ResolveMaxTimeTest()
        {
            // Arrange: build one bounded and one unbounded plugin data.
            var bounded = NewPluginData(new Dictionary<string, string> { ["CommandTimeout"] = "15" });
            var unbounded = NewPluginData(new Dictionary<string, string> { ["CommandTimeout"] = "0" });

            // Act and Assert: a positive timeout bounds the operation and zero leaves it unbounded.
            Assert.AreEqual(expected: TimeSpan.FromSeconds(15), actual: bounded.ResolveMaxTime());
            Assert.IsNull(value: unbounded.ResolveMaxTime());
        }

        [TestMethod(DisplayName = "Verify that ResolvePayload prefers the inline value, decodes it when its switch " +
            "is set, and rejects invalid Base64 by naming the argument.")]
        public void ResolvePayloadFormsTest()
        {
            // Arrange: build the payload arguments of each documented path.
            var inline = NewPluginData(new Dictionary<string, string> { ["Document"] = "{\"a\":1}" });
            var encoded = NewPluginData(new Dictionary<string, string>
            {
                ["Document"] = "eyIkc2V0Ijp7ImEiOjF9fQ==",
                ["DocumentBase64"] = string.Empty
            });
            var invalid = NewPluginData(new Dictionary<string, string>
            {
                ["Document"] = "not base64 at all",
                ["DocumentBase64"] = string.Empty
            });
            var missing = NewPluginData(arguments: null);

            // Act and Assert: the inline value is read as-is and an encoded value is decoded as UTF-8.
            Assert.AreEqual(expected: "{\"a\":1}", actual: inline.ResolveDocumentText());
            Assert.AreEqual(expected: "{\"$set\":{\"a\":1}}", actual: encoded.ResolveDocumentText());

            // Assert: a missing payload is empty, so each plugin decides whether its payload is optional.
            Assert.AreEqual(expected: string.Empty, actual: missing.ResolveDocumentText());

            // Assert: invalid Base64 names the argument and the switch that caused the decode.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => invalid.ResolveDocumentText());
            Assert.Contains(substring: "Document", value: exception.Message);
            Assert.Contains(substring: "DocumentBase64", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that ResolveRequired reads a set argument and names a missing one.")]
        public void ResolveRequiredTest()
        {
            // Arrange: build one plugin data with the argument set and one without it.
            var present = NewPluginData(new Dictionary<string, string> { ["Collection"] = "  orders  " });
            var missing = NewPluginData(arguments: null);

            // Act and Assert: the value is trimmed, and a missing argument is named in the failure.
            Assert.AreEqual(expected: "orders", actual: present.ResolveRequired(name: "Collection"));

            var exception = Assert.ThrowsExactly<InvalidOperationException>(
                () => missing.ResolveRequired(name: "Collection"));
            Assert.Contains(substring: "Collection", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that NewTransaction reports no session when the step runs without a " +
            "transaction.")]
        public void NewTransactionWithoutSwitchTest()
        {
            // Arrange: open a client against an address the test never contacts.
            using var client = new MongoDB.Driver.MongoClient("mongodb://127.0.0.1:27017");

            // Act: request no transaction.
            var session = LocalExtensions.NewTransaction(client, isTransaction: false);

            // Assert: no session is started, so every operation stays unsessioned.
            Assert.IsNull(value: session);
        }

        // Creates the plugin data model the extension members read, carrying only the given arguments. The model is
        // built directly, so no plugin, driver, or server is involved.
        private static PluginDataModel NewPluginData(IDictionary<string, string> arguments)
        {
            // Normalize the arguments so a scenario can pass an empty collection.
            return new PluginDataModel
            {
                Parameters = arguments?.ToDictionary(i => i.Key, i => i.Value, StringComparer.OrdinalIgnoreCase)
                    ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            };
        }
    }
}
