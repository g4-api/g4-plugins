using G4.Credentials.Models;
using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Actions;
using G4.UnitTests.Framework;

using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Text.Json;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("ExportSqlServerQuery")]
    [TestCategory("UnitTest")]
    public class ExportSqlServerQueryTests : TestBase
    {
        // Creates the table read by every scenario with three known rows; static text with no runtime values.
        private const string SetupCommandText =
            "IF OBJECT_ID(N'dbo.ExportQueryCustomers', N'U') IS NOT NULL DROP TABLE dbo.ExportQueryCustomers; " +
            "CREATE TABLE dbo.ExportQueryCustomers " +
            "(Id INT NOT NULL, Name NVARCHAR(50) NULL, Country NVARCHAR(2) NOT NULL); " +
            "INSERT INTO dbo.ExportQueryCustomers VALUES (1, N'Ada', N'GB'), (2, N'Grace', N'US'), (3, NULL, N'US');";

        [TestMethod(DisplayName = "Verify that the ExportSqlServerQuery plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<ExportSqlServerQuery>();
        }

        [TestMethod(DisplayName = "Verify that the ExportSqlServerQuery plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<ExportSqlServerQuery>();
        }

        [TestMethod(DisplayName = "Verify that ExportSqlServerQuery decodes Base64 CommandText when the Base64 " +
            "switch is set and binds the parameters of the decoded query.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ExportSqlServerQueryBase64Test()
        {
            // Arrange: seed known rows and encode a filtered query whose comment contains the inline terminators.
            SqlServerTestContainer.InvokeCommand(commandText: SetupCommandText);

            var commandText = "SELECT Id, Name FROM dbo.ExportQueryCustomers -- }} and -- stay inside the comment\n" +
                "WHERE Country = @Country ORDER BY Id;";
            var arguments = $"--CommandText:{commandText.ConvertToBase64()} --Base64 " +
                "--Parameters:{\"Country\":\"US\"}";
            var rule = NewRule(arguments);

            // Act: run the encoded query through the plugin.
            var entity = Invoke<ExportSqlServerQuery>(rule).Response.Entity;

            // Assert: the decoded query returned the two bound rows.
            var expected = "[{\"Id\":2,\"Name\":\"Grace\"},{\"Id\":3,\"Name\":null}]";
            Assert.AreEqual(expected, actual: entity["Result"]);
        }

        [TestMethod(DisplayName = "Verify that ExportSqlServerQuery resolves the connection from a stored SQL Server " +
            "credentials record name and applies the Database override.")]
        [TestCategory("SqlServerLive")]
        public void ExportSqlServerQueryCredentialsNameTest()
        {
            // Arrange: store the test server login as a named credentials record that targets master.
            var builder = new SqlConnectionStringBuilder(connectionString: SqlServerTestContainer.ConnectionString);
            var credential = SqlServerTestCredentials.AddCredential(credential: new SqlServerCredentialModel
            {
                Name = "export-query-tests",
                ConnectionString = builder.ConnectionString,
                Database = "master"
            });

            try
            {
                // Arrange: reference the record by name and override its database per step.
                var arguments = $"--Database:{SqlServerTestContainer.DatabaseName} " +
                    "--CommandText:SELECT DB_NAME() AS Name";
                var rule = NewRule(connectionArguments: "--Credentials:export-query-tests", arguments);

                // Act: run the query through the plugin.
                var entity = Invoke<ExportSqlServerQuery>(rule).Response.Entity;

                // Assert: the override wins over the database stored in the record.
                Assert.AreEqual(
                    expected: $"[{{\"Name\":\"{SqlServerTestContainer.DatabaseName}\"}}]",
                    actual: entity["Result"]);
            }
            finally
            {
                // Cleanup: remove the record from the cache so other tests resolve their own credentials only.
                SqlServerTestCredentials.RemoveCredential(credential: credential);
            }
        }

        [TestMethod(DisplayName = "Verify that ExportSqlServerQuery fails when neither CommandText nor CommandFile " +
            "is set.")]
        [TestCategory("SqlServerLive")]
        public void ExportSqlServerQueryMissingCommandTest()
        {
            // Arrange: provide a connection only.
            var rule = NewRule(arguments: string.Empty);

            // Act: run the step through the plugin and capture the rejection.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => Invoke<ExportSqlServerQuery>(rule));

            // Assert: the failure names the missing arguments.
            Assert.Contains(substring: "CommandText", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that ExportSqlServerQuery omits the entity when the NoEntity switch is set " +
            "and still stores the session parameters.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ExportSqlServerQueryNoEntityTest()
        {
            // Arrange: seed known rows and request no entity.
            SqlServerTestContainer.InvokeCommand(commandText: SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:SELECT COUNT(*) AS Total FROM dbo.ExportQueryCustomers " +
                "--NoEntity");

            // Act: run the query through the plugin.
            var result = Invoke<ExportSqlServerQuery>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the entity is omitted while the session output is still written.
            var isEntityOmitted = result.Response.Entity is null || result.Response.Entity.Count == 0;

            Assert.IsTrue(isEntityOmitted);
            Assert.AreEqual(
                expected: "[{\"Total\":3}]",
                actual: $"{sessionParameters["ExportSqlServerQuery:Result"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that ExportSqlServerQuery binds the parameters and stores the rows as " +
            "minified, Base64-encoded JSON session parameters and in the entity.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ExportSqlServerQueryParametersTest()
        {
            // Arrange: seed known rows and filter them through a bound parameter.
            SqlServerTestContainer.InvokeCommand(commandText: SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:SELECT Id, Name FROM dbo.ExportQueryCustomers " +
                "WHERE Country = @Country ORDER BY Id --Parameters:{\"Country\":\"US\"}");

            // Act: run the query through the plugin.
            var result = Invoke<ExportSqlServerQuery>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the session holds Base64 minified JSON; NULL values stay JSON null.
            var expected = "[{\"Id\":2,\"Name\":\"Grace\"},{\"Id\":3,\"Name\":null}]";
            var actual = $"{sessionParameters["ExportSqlServerQuery:Result"]}".ConvertFromBase64();
            var actualRowCount = $"{sessionParameters["ExportSqlServerQuery:RowCount"]}".ConvertFromBase64();
            var actualColumns = $"{sessionParameters["ExportSqlServerQuery:Columns"]}".ConvertFromBase64();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected: "2", actual: actualRowCount);
            Assert.AreEqual(expected: "[\"Id\",\"Name\"]", actual: actualColumns);

            // Assert: the entity carries the same outputs, unqualified and in plain text.
            Assert.AreEqual(expected, actual: result.Response.Entity["Result"]);
            Assert.AreEqual(expected: "2", actual: result.Response.Entity["RowCount"]);
        }

        [TestMethod(DisplayName = "Verify that ExportSqlServerQuery reports every result set and keeps the columns " +
            "of an empty first result set.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ExportSqlServerQueryResultSetsTest()
        {
            // Arrange: seed known rows and run two statements, the first returning no rows.
            SqlServerTestContainer.InvokeCommand(commandText: SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:SELECT Id FROM dbo.ExportQueryCustomers WHERE Id = 0; " +
                "SELECT COUNT(*) AS Total FROM dbo.ExportQueryCustomers;");

            // Act: run both statements through the plugin.
            var entity = Invoke<ExportSqlServerQuery>(rule).Response.Entity;

            // Assert: the empty first result still reports its columns and both result sets are returned in order.
            Assert.AreEqual(expected: "[]", actual: entity["Result"]);
            Assert.AreEqual(expected: "[\"Id\"]", actual: entity["Columns"]);
            Assert.AreEqual(expected: "0", actual: entity["RowCount"]);
            Assert.AreEqual(expected: "[[],[{\"Total\":3}]]", actual: entity["ResultSets"]);
        }

        [TestMethod(DisplayName = "Verify that ExportSqlServerQuery maps dates, decimals, binary values, and " +
            "unique identifiers to their documented JSON forms.")]
        [TestCategory("SqlServerLive")]
        public void ExportSqlServerQueryTypeMappingTest()
        {
            // Arrange: select one literal of each mapped type.
            var rule = NewRule(arguments: "--CommandText:SELECT CAST('2024-01-02T03:04:05' AS DATETIME2(0)) AS Date, " +
                "CAST(12.50 AS DECIMAL(5,2)) AS Amount, CAST(0x0102 AS VARBINARY(2)) AS Data, " +
                "CAST('6F9619FF-8B86-D011-B42D-00C04FC964FF' AS UNIQUEIDENTIFIER) AS Id, CAST(1 AS BIT) AS Flag");

            // Act: run the query through the plugin and parse the first exported row.
            var json = $"{Invoke<ExportSqlServerQuery>(rule).Response.Entity["Result"]}";

            using var document = JsonDocument.Parse(json);
            var row = document.RootElement[0];

            // Assert: each value uses its documented JSON representation.
            Assert.AreEqual(expected: "2024-01-02T03:04:05", actual: row.GetProperty("Date").GetString());
            Assert.AreEqual(expected: 12.50m, actual: row.GetProperty("Amount").GetDecimal());
            Assert.AreEqual(expected: "AQI=", actual: row.GetProperty("Data").GetString());
            Assert.AreEqual(
                expected: "6f9619ff-8b86-d011-b42d-00c04fc964ff",
                actual: row.GetProperty("Id").GetString());
            Assert.IsTrue(row.GetProperty("Flag").GetBoolean());
        }

        // Creates an Action rule that connects to the shared test database through the raw connection string.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Route through the complete overload with the shared container connection.
            var connectionArguments = $"--ConnectionString:{SqlServerTestContainer.ConnectionString}";

            return NewRule(connectionArguments, arguments);
        }

        // Creates an Action rule whose CLI argument joins the connection arguments and the scenario arguments.
        private static ActionRuleModel NewRule(string connectionArguments, string arguments)
        {
            // Compose the CLI expression the plugin parses into its parameters.
            return new ActionRuleModel
            {
                PluginName = nameof(ExportSqlServerQuery),
                Argument = "{{$ " + connectionArguments + " " + arguments + "}}"
            };
        }
    }
}
