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
            var parameters = NewArguments();

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

        [TestMethod(DisplayName = "Verify that ResolveConnection uses the ConnectionString argument as the " +
            "connection when no credentials are set.")]
        public void ResolveConnectionConnectionStringTest()
        {
            // Act: resolve the connection from the plain connection string.
            var connection = LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: BaselineConnectionString,
                accessToken: string.Empty);

            // Assert: the connection parts are kept and no access token is attached.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "baseline-host", actual: builder.DataSource);
            Assert.AreEqual(expected: "BaselineDatabase", actual: builder.InitialCatalog);
            Assert.AreEqual(expected: string.Empty, actual: connection.AccessToken);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection ignores step arguments that name discrete " +
            "connection parts, so a removed argument never changes the connection.")]
        public void ResolveConnectionDiscreteArgumentsIgnoredTest()
        {
            // Arrange: pass the connection string next to arguments that were discrete connection parts before.
            var parameters = NewArguments();
            parameters["ConnectionString"] = BaselineConnectionString;
            parameters["Server"] = "override-host";
            parameters["Port"] = "14330";
            parameters["Database"] = "OverrideDatabase";
            parameters["Username"] = "override-user";
            parameters["Password"] = "override-password";
            parameters["Authentication"] = SqlServerAuthenticationTypes.SqlPassword;
            parameters["Encrypt"] = SqlServerEncryptTypes.Strict;
            parameters["TrustServerCertificate"] = string.Empty;

            var pluginData = new PluginDataModel { Parameters = parameters };

            // Act: resolve the connection from the step arguments.
            var connection = pluginData.ResolveConnection();

            // Assert: every part comes from the connection string and no ignored argument reaches the provider.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "baseline-host", actual: builder.DataSource);
            Assert.AreEqual(expected: "BaselineDatabase", actual: builder.InitialCatalog);
            Assert.AreEqual(expected: string.Empty, actual: builder.UserID);
            Assert.AreEqual(expected: string.Empty, actual: builder.Password);
            Assert.AreEqual(expected: SqlAuthenticationMethod.NotSpecified, actual: builder.Authentication);
            Assert.AreEqual(expected: SqlConnectionEncryptOption.Mandatory, actual: builder.Encrypt);
            Assert.IsFalse(builder.TrustServerCertificate);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection fails with a message naming the inputs when no " +
            "server is resolved.")]
        public void ResolveConnectionNoServerTest()
        {
            // Act and Assert: without credentials and without a connection string, no server can be resolved.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => LocalExtensions.ResolveConnection(
                credentials: string.Empty,
                connectionString: string.Empty,
                accessToken: string.Empty));

            Assert.Contains(substring: "No SQL Server target was resolved", value: exception.Message);
            Assert.Contains(substring: "Set 'Credentials' or 'ConnectionString'", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection uses an unmatched Credentials value that contains " +
            "'=' as a raw connection string and ignores the ConnectionString argument.")]
        public void ResolveConnectionRawConnectionStringTest()
        {
            // Arrange: pass a connection string as the credentials value next to a different connection string.
            var credentials = "Data Source=raw-host;Initial Catalog=RawDatabase";

            // Act: resolve the connection with no matching credentials record.
            var connection = LocalExtensions.ResolveConnection(
                credentials,
                connectionString: BaselineConnectionString,
                accessToken: string.Empty);

            // Assert: the credentials value wins over the ConnectionString argument and carries no token.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "raw-host", actual: builder.DataSource);
            Assert.AreEqual(expected: "RawDatabase", actual: builder.InitialCatalog);
            Assert.AreEqual(expected: string.Empty, actual: connection.AccessToken);
        }

        [TestMethod(DisplayName = "Verify that ResolveConnection uses an unmatched Credentials value without '=' as " +
            "a raw access token, keeping the ConnectionString argument as the connection.")]
        public void ResolveConnectionRawTokenTest()
        {
            // Act: resolve the connection with a token-like credentials value and no matching credentials record.
            var connection = LocalExtensions.ResolveConnection(
                credentials: "raw-access-token",
                connectionString: BaselineConnectionString,
                accessToken: "explicit-access-token");

            // Assert: the credentials value replaces the explicit token, and the connection string names the server.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "raw-access-token", actual: connection.AccessToken);
            Assert.AreEqual(expected: "baseline-host", actual: builder.DataSource);
            Assert.AreEqual(expected: "BaselineDatabase", actual: builder.InitialCatalog);
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
                    accessToken: string.Empty);

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

        [TestMethod(DisplayName = "Verify that ResolveConnection reads the Token argument of the step as the access " +
            "token next to the ConnectionString argument.")]
        public void ResolveConnectionTokenArgumentTest()
        {
            // Arrange: pass the connection string and the token as step arguments.
            var parameters = NewArguments();
            parameters["ConnectionString"] = BaselineConnectionString;
            parameters["Token"] = "argument-access-token";

            var pluginData = new PluginDataModel { Parameters = parameters };

            // Act: resolve the connection from the step arguments.
            var connection = pluginData.ResolveConnection();

            // Assert: the token is attached while the connection string names the server.
            var builder = new SqlConnectionStringBuilder(connection.ConnectionString);
            Assert.AreEqual(expected: "argument-access-token", actual: connection.AccessToken);
            Assert.AreEqual(expected: "baseline-host", actual: builder.DataSource);
        }

        [TestMethod(DisplayName = "Verify that ResolveSqlParameters returns no parameters when the argument is " +
            "missing.")]
        public void ResolveSqlParametersMissingTest()
        {
            // Arrange: create step arguments without the Parameters argument.
            var pluginData = new PluginDataModel { Parameters = NewArguments() };

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
            var parameters = NewArguments();
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
            var parameters = NewArguments();
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
        private static Dictionary<string, string> NewArguments()
        {
            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }
    }
}
