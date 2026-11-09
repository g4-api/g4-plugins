using G4.Credentials.Models;
using G4.Models;
using G4.Plugins.SqlServer.Clients;
using G4.Plugins.SqlServer.Extensions;
using G4.UnitTests.Framework;

using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("SqlServerConnectionResolution")]
    [TestCategory("UnitTest")]
    public class SqlServerConnectionResolutionTests
    {
        // Connection string used as the baseline in every scenario; it never reaches a server.
        private const string BaselineConnectionString = "Data Source=baseline-host;Initial Catalog=BaselineDatabase";

        // Names the credentials record seeded by the record-lookup scenario; unique so parallel tests never collide.
        private const string CredentialName = "connection-resolution-tests";

        // Parameters payload covering every documented JSON-to-CLR mapping of the Parameters argument.
        private const string TypedParametersJson =
            "{\"Name\":\"Ada\",\"Count\":42,\"Price\":12.5,\"Active\":true,\"Missing\":null," +
            "\"Meta\":{\"Level\":1},\"Tags\":[1,2],\"@Id\":7}";

        [TestMethod(DisplayName = "Verify that ResolveCommandTimeout reads a non-negative CommandTimeout and falls " +
            "back to the default for missing or invalid values.")]
        #region *** Data Set ***
        [DataRow(null, SqlServerClient.DefaultCommandTimeoutSeconds, DisplayName = "Missing value")]
        [DataRow("45", 45, DisplayName = "Positive value")]
        [DataRow("0", 0, DisplayName = "No timeout")]
        [DataRow("-1", SqlServerClient.DefaultCommandTimeoutSeconds, DisplayName = "Negative value")]
        [DataRow("abc", SqlServerClient.DefaultCommandTimeoutSeconds, DisplayName = "Non-numeric value")]
        #endregion
        public void ResolveCommandTimeoutTest(string value, int expected)
        {
            // Arrange: set the argument only for rows that carry a value.
            var parameters = NewOverrides();

            if (value is not null)
            {
                parameters["CommandTimeout"] = value;
            }

            var pluginData = new PluginDataModel { Parameters = parameters };

            // Act: resolve the timeout from the step arguments.
            var actual = pluginData.ResolveCommandTimeout();

            // Assert: valid values are kept and every other value falls back to the default.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection applies the Authentication override as the " +
            "provider Authentication keyword.")]
        public void ResolveConnectionAuthenticationOverrideTest()
        {
            // Arrange: request SQL password authentication on top of the baseline connection string.
            var overrides = NewOverrides();
            overrides["Authentication"] = SqlServerAuthenticationTypes.SqlPassword;

            // Act: resolve the connection without credentials.
            var connection = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineConnectionString,
                overrides);

            // Assert: the keyword is passed to the provider unchanged and the baseline server is kept.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: SqlAuthenticationMethod.SqlPassword, actual: builder.Authentication);
            Assert.AreEqual(expected: "baseline-host", actual: builder.DataSource);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection uses the ConnectionString argument as the baseline " +
            "when no credentials are set.")]
        public void ResolveConnectionConnectionStringTest()
        {
            // Act: resolve the connection from the plain connection string with no overrides.
            var connection = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineConnectionString,
                overrides: null);

            // Assert: the baseline parts are kept and no access token is attached.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "baseline-host", actual: builder.DataSource);
            Assert.AreEqual(expected: "BaselineDatabase", actual: builder.InitialCatalog);
            Assert.AreEqual(expected: string.Empty, actual: connection.AccessToken);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection replaces the baseline values with the discrete " +
            "Server, Port, Database, Username, Password, and Encrypt overrides.")]
        public void ResolveConnectionDiscreteOverridesTest()
        {
            // Arrange: override every discrete connection part on top of the baseline connection string.
            var overrides = NewOverrides();
            overrides["Server"] = "override-host";
            overrides["Port"] = "14330";
            overrides["Database"] = "OverrideDatabase";
            overrides["Username"] = "override-user";
            overrides["Password"] = "override-password";
            overrides["Encrypt"] = SqlServerEncryptTypes.Strict;

            // Act: resolve the connection without credentials.
            var connection = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineConnectionString,
                overrides);

            // Assert: the server and port compose the data source and every other override replaces its baseline.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "override-host,14330", actual: builder.DataSource);
            Assert.AreEqual(expected: "OverrideDatabase", actual: builder.InitialCatalog);
            Assert.AreEqual(expected: "override-user", actual: builder.UserID);
            Assert.AreEqual(expected: "override-password", actual: builder.Password);
            Assert.AreEqual(expected: SqlConnectionEncryptOption.Strict, actual: builder.Encrypt);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection maps the Integrated authentication value to " +
            "Integrated Security instead of the Authentication keyword.")]
        public void ResolveConnectionIntegratedAuthenticationTest()
        {
            // Arrange: request Windows authentication through the Integrated value, in a different casing.
            var overrides = NewOverrides();
            overrides["Authentication"] = "integrated";

            // Act: resolve the connection without credentials.
            var connection = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineConnectionString,
                overrides);

            // Assert: Integrated Security is enabled and no Authentication keyword is sent to the provider.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.IsTrue(builder.IntegratedSecurity);
            Assert.AreEqual(expected: SqlAuthenticationMethod.NotSpecified, actual: builder.Authentication);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection fails with a message naming the inputs when no " +
            "server is resolved.")]
        public void ResolveConnectionNoServerTest()
        {
            // Arrange: provide a database override only, so no input resolves a server.
            var overrides = NewOverrides();
            overrides["Database"] = "OrphanDatabase";

            // Act and Assert: the resolver rejects the inputs before any provider call.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: string.Empty,
                overrides));

            Assert.Contains(substring: "No SQL Server target was resolved", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection applies a Port override without a Server override " +
            "to the baseline host, replacing any baseline port.")]
        #region *** Data Set ***
        [DataRow("Data Source=db01,1433", DisplayName = "Baseline with port")]
        [DataRow("Data Source=db01", DisplayName = "Baseline without port")]
        #endregion
        public void ResolveConnectionPortOverrideTest(string connectionString)
        {
            // Arrange: override only the port so the baseline host is re-targeted.
            var overrides = NewOverrides();
            overrides["Port"] = "2000";

            // Act: resolve the connection without credentials.
            var connection = LocalExtensions.ResolveConnection(credentials: string.Empty, connectionString, overrides);

            // Assert: the baseline host is kept and the override port replaces or adds the port part.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "db01,2000", actual: builder.DataSource);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection uses an unmatched Credentials value that contains " +
            "'=' as a raw connection string and ignores the ConnectionString argument.")]
        public void ResolveConnectionRawConnectionStringTest()
        {
            // Arrange: pass a connection string as the credentials value next to a different baseline.
            var credentials = "Data Source=raw-host;Initial Catalog=RawDatabase";

            // Act: resolve the connection with no matching credentials record.
            var connection = LocalExtensions.ResolveConnection(
                credentials,
                connectionString: BaselineConnectionString,
                overrides: null);

            // Assert: the credentials value wins over the ConnectionString argument and carries no token.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "raw-host", actual: builder.DataSource);
            Assert.AreEqual(expected: "RawDatabase", actual: builder.InitialCatalog);
            Assert.AreEqual(expected: string.Empty, actual: connection.AccessToken);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection uses an unmatched Credentials value without '=' as " +
            "a raw access token.")]
        public void ResolveConnectionRawTokenTest()
        {
            // Arrange: pass a token-like credentials value and supply the server through an override.
            var overrides = NewOverrides();
            overrides["Server"] = "token-host";

            // Act: resolve the connection with no matching credentials record.
            var connection = LocalExtensions.ResolveConnection(
                credentials: "raw-access-token",
                connectionString: BaselineConnectionString,
                overrides);

            // Assert: the value becomes the access token and the ConnectionString argument is not the baseline.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "raw-access-token", actual: connection.AccessToken);
            Assert.AreEqual(expected: "token-host", actual: builder.DataSource);
            Assert.AreEqual(expected: string.Empty, actual: builder.InitialCatalog);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection resolves a stored credentials record by name and " +
            "uses its connection instead of the ConnectionString argument.")]
        public void ResolveConnectionRecordNameTest()
        {
            // Arrange: store a record composed from discrete parts only.
            var credential = SqlServerTestCredentials.AddCredential(credential: new SqlServerCredentialModel
            {
                Name = CredentialName,
                Server = "record-host",
                Port = 1500,
                Database = "RecordDatabase",
                Username = "record-user",
                Password = "record-password",
                TrustServerCertificate = true
            });

            try
            {
                // Act: resolve the connection through the record name, in a different casing.
                var connection = LocalExtensions.ResolveConnection(
                    credentials: CredentialName.ToUpperInvariant(),
                    connectionString: BaselineConnectionString,
                    overrides: null);

                // Assert: every record part reaches the connection string and no token is attached.
                var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
                Assert.AreEqual(expected: "record-host,1500", actual: builder.DataSource);
                Assert.AreEqual(expected: "RecordDatabase", actual: builder.InitialCatalog);
                Assert.AreEqual(expected: "record-user", actual: builder.UserID);
                Assert.AreEqual(expected: "record-password", actual: builder.Password);
                Assert.IsTrue(builder.TrustServerCertificate);
                Assert.AreEqual(expected: string.Empty, actual: connection.AccessToken);
            }
            finally
            {
                // Cleanup: remove the record from the cache so other tests resolve their own credentials only.
                SqlServerTestCredentials.RemoveCredential(credential: credential);
            }
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection sets the explicit Token override as the access token.")]
        public void ResolveConnectionTokenOverrideTest()
        {
            // Arrange: pass the token through the dedicated override next to the baseline connection string.
            var overrides = NewOverrides();
            overrides["Token"] = "override-access-token";

            // Act: resolve the connection without credentials.
            var connection = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineConnectionString,
                overrides);

            // Assert: the token is attached while the baseline connection is kept.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "override-access-token", actual: connection.AccessToken);
            Assert.AreEqual(expected: "baseline-host", actual: builder.DataSource);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection turns on TrustServerCertificate only when the " +
            "switch is present.")]
        #region *** Data Set ***
        [DataRow(true, DisplayName = "Switch present")]
        [DataRow(false, DisplayName = "Switch absent")]
        #endregion
        public void ResolveConnectionTrustServerCertificateTest(bool isSwitch)
        {
            // Arrange: add the switch, which carries no value, only for the switch-present row.
            var overrides = NewOverrides();

            if (isSwitch)
            {
                overrides["TrustServerCertificate"] = string.Empty;
            }

            // Act: resolve the connection without credentials.
            var connection = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineConnectionString,
                overrides);

            // Assert: the switch presence alone decides the certificate trust.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: isSwitch, actual: builder.TrustServerCertificate);
        }

        [TestMethod(DisplayName = "Verify that ResolveSqlParameters returns no parameters when the argument is " +
            "missing.")]
        public void ResolveSqlParametersMissingTest()
        {
            // Arrange: create step arguments without the Parameters argument.
            var pluginData = new PluginDataModel { Parameters = NewOverrides() };

            // Act: resolve the parameters.
            var sqlParameters = pluginData.ResolveSqlParameters();

            // Assert: a parameterless command needs no placeholder payload.
            Assert.IsEmpty(sqlParameters);
        }

        [TestMethod(DisplayName = "Verify that ResolveSqlParameters rejects a Parameters value that is not a JSON " +
            "object.")]
        public void ResolveSqlParametersNotObjectTest()
        {
            // Arrange: pass a JSON array where an object is required.
            var parameters = NewOverrides();
            parameters["Parameters"] = "[1,2]";

            var pluginData = new PluginDataModel { Parameters = parameters };

            // Act and Assert: the malformed payload fails before any command runs.
            Assert.ThrowsExactly<FormatException>(() => pluginData.ResolveSqlParameters());
        }

        [TestMethod(DisplayName = "Verify that ResolveSqlParameters binds every JSON value with its documented " +
            "type and adds the '@' prefix only when missing.")]
        public void ResolveSqlParametersTypingTest()
        {
            // Arrange: pass one property of each documented JSON kind.
            var parameters = NewOverrides();
            parameters["Parameters"] = TypedParametersJson;

            var pluginData = new PluginDataModel { Parameters = parameters };

            // Act: resolve the parameters and index them by name.
            var sqlParameters = pluginData
                .ResolveSqlParameters()
                .ToDictionary(i => i.ParameterName, i => i.Value);

            // Assert: every name carries exactly one '@' prefix.
            string[] expectedNames = ["@Name", "@Count", "@Price", "@Active", "@Missing", "@Meta", "@Tags", "@Id"];
            Assert.AreSequenceEqual(expected: expectedNames, actual: sqlParameters.Keys.ToArray());

            // Assert: scalars keep their CLR type, null becomes DBNull, and objects or arrays become JSON text.
            Assert.AreEqual(expected: "Ada", actual: sqlParameters["@Name"]);
            Assert.AreEqual(expected: 42L, actual: sqlParameters["@Count"]);
            Assert.AreEqual(expected: 12.5m, actual: sqlParameters["@Price"]);
            Assert.IsTrue((bool)sqlParameters["@Active"]);
            Assert.AreEqual(expected: DBNull.Value, actual: sqlParameters["@Missing"]);
            Assert.AreEqual(expected: "{\"Level\":1}", actual: sqlParameters["@Meta"]);
            Assert.AreEqual(expected: "[1,2]", actual: sqlParameters["@Tags"]);
            Assert.AreEqual(expected: 7L, actual: sqlParameters["@Id"]);
        }

        // Creates an empty, case-insensitive argument dictionary, matching the shape the engine passes to plugins.
        private static Dictionary<string, string> NewOverrides()
        {
            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }
    }
}
