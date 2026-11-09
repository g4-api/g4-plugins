using G4.Credentials.Models;
using G4.Models;
using G4.Plugins.SqlServer.DataCollectors;
using G4.UnitTests.Framework;

using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("SqlServerDataCollector")]
    [TestCategory("UnitTest")]
    public class SqlServerDataCollectorTests : TestBase
    {
        // Drops the table of the create scenario so the collector creates it; static text with no runtime values.
        private const string DropCreatedTableCommandText =
            "IF OBJECT_ID(N'dbo.CollectorProducts', N'U') IS NOT NULL DROP TABLE dbo.CollectorProducts;";

        // Recreates the one-column table an earlier, narrower extraction leaves behind, with one existing row;
        // static text with no runtime values.
        private const string CreateLegacyTableCommandText =
            "IF OBJECT_ID(N'dbo.CollectorLegacy', N'U') IS NOT NULL DROP TABLE dbo.CollectorLegacy; " +
            "CREATE TABLE dbo.CollectorLegacy (Legacy NVARCHAR(50) NULL); " +
            "INSERT INTO dbo.CollectorLegacy (Legacy) VALUES (N'kept');";

        // Drops the table of the hyphenated-key scenario; static text with no runtime values.
        private const string DropHyphenatedTableCommandText =
            "IF OBJECT_ID(N'dbo.CollectorHyphenated', N'U') IS NOT NULL DROP TABLE dbo.CollectorHyphenated;";

        // Drops the table and the schema of the schema-qualified scenario so the collector creates both; static text
        // with no runtime values.
        private const string DropSchemaCommandText =
            "IF OBJECT_ID(N'CollectorSchema.Products', N'U') IS NOT NULL DROP TABLE CollectorSchema.Products; " +
            "IF SCHEMA_ID(N'CollectorSchema') IS NOT NULL DROP SCHEMA CollectorSchema;";

        // Drops the table of the credentials-name scenario; static text with no runtime values.
        private const string DropCredentialsTableCommandText =
            "IF OBJECT_ID(N'dbo.CollectorCredentials', N'U') IS NOT NULL DROP TABLE dbo.CollectorCredentials;";

        // Counts the legacy rows that existed before the export and kept their values with a NULL new column.
        private const string CountKeptLegacyRowsCommandText =
            "SELECT COUNT(*) FROM dbo.CollectorLegacy WHERE Legacy = N'kept' AND Description IS NULL;";

        // Counts the rows the export appended to the legacy table, which carry the new column only.
        private const string CountNewLegacyRowsCommandText =
            "SELECT COUNT(*) FROM dbo.CollectorLegacy WHERE Legacy IS NULL AND Description IS NOT NULL;";

        // Counts the rows of the created table that carry an extracted value.
        private const string CountCreatedRowsCommandText =
            "SELECT COUNT(*) FROM dbo.CollectorProducts WHERE Description IS NOT NULL;";

        // Counts the rows written through the credentials-name Source.
        private const string CountCredentialsRowsCommandText = "SELECT COUNT(*) FROM dbo.CollectorCredentials;";

        // Counts the rows of the hyphenated-key table that carry an extracted value.
        private const string CountHyphenatedRowsCommandText =
            "SELECT COUNT(*) FROM dbo.CollectorHyphenated WHERE [product-description] IS NOT NULL;";

        // Reads the identifier of the schema the collector creates; NULL while the schema is missing.
        private const string GetSchemaIdCommandText = "SELECT SCHEMA_ID(N'CollectorSchema');";

        // Counts the rows of the schema-qualified table.
        private const string CountSchemaRowsCommandText = "SELECT COUNT(*) FROM CollectorSchema.Products;";

        // Reads the ordered column names of a dbo table, binding the table name as a value.
        private const string ReadColumnsCommandText =
            "SELECT STRING_AGG(name, N'|') WITHIN GROUP (ORDER BY column_id) " +
            "FROM sys.columns WHERE object_id = OBJECT_ID(N'dbo.' + QUOTENAME(@Table));";

        // Names the credentials record the credentials-name scenario resolves; unique so parallel tests never collide.
        private const string CredentialName = "sqlserver-collector-tests";

        // Columns expected after the collector adds the new key to the legacy table, in creation order.
        private static readonly string[] ExpectedLegacyColumns = ["Legacy", "Description"];

        // Columns expected when the collector creates the table for the plain key.
        private static readonly string[] ExpectedCreatedColumns = ["Description"];

        // Columns expected when the collector creates the table for a hyphenated key.
        private static readonly string[] ExpectedHyphenatedColumns = ["product-description"];

        [TestMethod(DisplayName = "Verify that the SqlServerDataCollector plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the collector manifest documentation renders as the cache expects.
            AssertManifest<SqlServerDataCollector>();
        }

        [TestMethod(DisplayName = "Verify that the SqlServerDataCollector plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the collector can be created through the plugin factory.
            AssertPlugin<SqlServerDataCollector>();
        }

        [TestMethod(DisplayName = "Verify that the SqlServerDataCollector adds the columns an existing table lacks " +
            "without altering the existing rows.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void SqlServerDataCollectorAddsMissingColumnsTest()
        {
            // Arrange: create the narrower table with one existing row, so the 'Description' key has no column yet.
            SqlServerTestContainer.InvokeCommand(CreateLegacyTableCommandText);

            // Act: export both simulator entities into the existing table.
            var exceptions = InvokeExport(
                source: SqlServerTestContainer.ConnectionString,
                repository: "CollectorLegacy",
                key: "Description");

            // Assert: the export reports no failure and the missing column is added next to the legacy one.
            var failures = string.Join(" | ", exceptions.Select(i => i.Exception.Message));
            Assert.IsEmpty(collection: exceptions, message: failures);
            Assert.AreSequenceEqual(expected: ExpectedLegacyColumns, actual: ReadColumns(table: "CollectorLegacy"));

            // Assert: the existing row is kept unchanged and both entities are appended.
            var keptRows = SqlServerTestContainer.GetScalar(CountKeptLegacyRowsCommandText);
            var newRows = SqlServerTestContainer.GetScalar(CountNewLegacyRowsCommandText);
            Assert.AreEqual(expected: 1, actual: keptRows);
            Assert.AreEqual(expected: 2, actual: newRows);
        }

        [TestMethod(DisplayName = "Verify that the SqlServerDataCollector creates the table and writes every entity " +
            "when the Source is a raw connection string.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void SqlServerDataCollectorCreatesTableTest()
        {
            // Arrange: remove the destination table so the collector creates it.
            SqlServerTestContainer.InvokeCommand(DropCreatedTableCommandText);

            // Act: export both simulator entities through the raw connection string.
            var exceptions = InvokeExport(
                source: SqlServerTestContainer.ConnectionString,
                repository: "CollectorProducts",
                key: "Description");

            // Assert: the export reports no failure and the table holds one column per content key.
            var failures = string.Join(" | ", exceptions.Select(i => i.Exception.Message));
            Assert.IsEmpty(collection: exceptions, message: failures);
            Assert.AreSequenceEqual(expected: ExpectedCreatedColumns, actual: ReadColumns(table: "CollectorProducts"));

            // Assert: both entities are stored with their extracted values.
            var rows = SqlServerTestContainer.GetScalar(CountCreatedRowsCommandText);
            Assert.AreEqual(expected: 2, actual: rows);
        }

        [TestMethod(DisplayName = "Verify that the SqlServerDataCollector resolves the Source as a stored SQL Server " +
            "credentials record name.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void SqlServerDataCollectorCredentialsNameTest()
        {
            // Arrange: remove the destination table and store the test server login as a named record.
            SqlServerTestContainer.InvokeCommand(DropCredentialsTableCommandText);

            var credential = SqlServerTestCredentials.AddCredential(credential: new SqlServerCredentialModel
            {
                Name = CredentialName,
                ConnectionString = SqlServerTestContainer.ConnectionString
            });

            try
            {
                // Act: export both simulator entities through the record name.
                var exceptions = InvokeExport(
                    source: CredentialName,
                    repository: "CollectorCredentials",
                    key: "Description");

                // Assert: the record connection reached the test database and both entities are stored.
                var failures = string.Join(" | ", exceptions.Select(i => i.Exception.Message));
                var rows = SqlServerTestContainer.GetScalar(CountCredentialsRowsCommandText);
                Assert.IsEmpty(collection: exceptions, message: failures);
                Assert.AreEqual(expected: 2, actual: rows);
            }
            finally
            {
                // Cleanup: remove the record from the cache so other tests resolve their own credentials only.
                SqlServerTestCredentials.RemoveCredential(credential: credential);
            }
        }

        [TestMethod(DisplayName = "Verify that the SqlServerDataCollector writes content keys that contain '-' and " +
            "other characters that are not valid in unquoted SQL identifiers.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void SqlServerDataCollectorHyphenatedKeyTest()
        {
            // Arrange: remove the destination table so the collector creates it from a hyphenated key.
            SqlServerTestContainer.InvokeCommand(DropHyphenatedTableCommandText);

            // Act: export both simulator entities into a new table.
            var exceptions = InvokeExport(
                source: SqlServerTestContainer.ConnectionString,
                repository: "CollectorHyphenated",
                key: "product-description");

            // Assert: the table is created with the hyphenated column and both entities are stored.
            var failures = string.Join(" | ", exceptions.Select(i => i.Exception.Message));
            var rows = SqlServerTestContainer.GetScalar(CountHyphenatedRowsCommandText);
            var columns = ReadColumns(table: "CollectorHyphenated");
            Assert.IsEmpty(collection: exceptions, message: failures);
            Assert.AreSequenceEqual(expected: ExpectedHyphenatedColumns, actual: columns);
            Assert.AreEqual(expected: 2, actual: rows);
        }

        [TestMethod(DisplayName = "Verify that the SqlServerDataCollector creates the missing schema of a " +
            "schema-qualified repository and writes every entity into it.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void SqlServerDataCollectorSchemaRepositoryTest()
        {
            // Arrange: remove the destination table and its schema so the collector creates both.
            SqlServerTestContainer.InvokeCommand(DropSchemaCommandText);

            // Act: export both simulator entities into the schema-qualified repository.
            var exceptions = InvokeExport(
                source: SqlServerTestContainer.ConnectionString,
                repository: "CollectorSchema.Products",
                key: "Description");

            // Assert: the schema exists and holds the table with both entities.
            var failures = string.Join(" | ", exceptions.Select(i => i.Exception.Message));
            var schemaId = SqlServerTestContainer.GetScalar(GetSchemaIdCommandText);
            var rows = SqlServerTestContainer.GetScalar(CountSchemaRowsCommandText);
            Assert.IsEmpty(collection: exceptions, message: failures);
            Assert.IsInstanceOfType<int>(schemaId);
            Assert.AreEqual(expected: 2, actual: rows);
        }

        // Runs an Elements-scope export over the simulator page with one content rule and a SQL Server collector
        // that writes per entity, returning the exceptions reported by the session. The collector owns its
        // connection, so the destination table is observable through a separate connection once this returns.
        private IEnumerable<G4ExceptionModel> InvokeExport(string source, string repository, string key)
        {
            // Build the export container: the simulator resolves '//positive' to two elements, so the
            // collector writes two entities.
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
                            Type = "SqlServerDataCollector"
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

        // Reads the column names of a dbo test table in creation order, binding the table name as a value so the
        // command text stays static. Uses a short-lived connection so it observes committed collector writes only.
        private static string[] ReadColumns(string table)
        {
            // Open a connection owned by this read.
            using var connection = new SqlConnection(SqlServerTestContainer.ConnectionString);
            connection.Open();

            // Aggregate the names on the server so one scalar read returns the ordered column list.
            using var command = connection.CreateCommand();
            command.CommandText = ReadColumnsCommandText;
            command.Parameters.Add(new SqlParameter("@Table", SqlDbType.NVarChar, 128) { Value = table });

            return $"{command.ExecuteScalar()}".Split('|');
        }
    }
}
