using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Linq;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("ImportSqlServerData")]
    [TestCategory("UnitTest")]
    public class ImportSqlServerDataTests : TestBase
    {
        // Recreates the empty destination table of the dbo scenarios; static text with no runtime values.
        private const string SetupCommandText =
            "IF OBJECT_ID(N'dbo.ImportCustomers', N'U') IS NOT NULL DROP TABLE dbo.ImportCustomers; " +
            "CREATE TABLE dbo.ImportCustomers (Id INT NOT NULL, Name NVARCHAR(50) NULL, Country NVARCHAR(2) NULL);";

        // Creates the schema of the schema-qualified scenario when missing; static text with no runtime values.
        private const string SetupSchemaCommandText =
            "IF SCHEMA_ID(N'ImportSchema') IS NULL EXEC (N'CREATE SCHEMA ImportSchema');";

        // Recreates the empty destination table of the schema-qualified scenario; static text with no runtime values.
        private const string SetupSchemaTableCommandText =
            "IF OBJECT_ID(N'ImportSchema.Customers', N'U') IS NOT NULL DROP TABLE ImportSchema.Customers; " +
            "CREATE TABLE ImportSchema.Customers (Id INT NOT NULL, Name NVARCHAR(50) NULL);";

        // Counts the rows of the dbo destination table.
        private const string CountRowsCommandText = "SELECT COUNT(*) FROM dbo.ImportCustomers;";

        // Counts the dbo rows whose Name is NULL.
        private const string CountNullNamesCommandText = "SELECT COUNT(*) FROM dbo.ImportCustomers WHERE Name IS NULL;";

        // Counts the rows of the schema-qualified destination table.
        private const string CountSchemaRowsCommandText = "SELECT COUNT(*) FROM ImportSchema.Customers;";

        // Reads the Country of the first dbo row.
        private const string GetFirstCountryCommandText = "SELECT Country FROM dbo.ImportCustomers WHERE Id = 1;";

        // Reads the Name of the first dbo row.
        private const string GetFirstNameCommandText = "SELECT Name FROM dbo.ImportCustomers WHERE Id = 1;";

        // Inline rows imported by the Data scenarios; the keys are out of table order to prove name mapping.
        private const string InlineData =
            "[{\"Name\":\"Ada\",\"Id\":1,\"Country\":\"GB\"},{\"Id\":2,\"Name\":null,\"Country\":\"US\"}]";

        // CSV rows whose quoted Name field contains a comma, imported by the CSV file scenario.
        private const string CsvData = "Id,Name,Country\r\n1,\"Lovelace, Ada\",GB\r\n2,Grace,US\r\n";

        // JSON rows imported by the JSON file scenario.
        private const string JsonData = "[{\"Id\":1,\"Name\":\"Ada\"},{\"Id\":2,\"Name\":\"Grace\"},{\"Id\":3}]";

        [TestMethod(DisplayName = "Verify that the ImportSqlServerData plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<ImportSqlServerData>();
        }

        [TestMethod(DisplayName = "Verify that the ImportSqlServerData plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<ImportSqlServerData>();
        }

        [TestMethod(DisplayName = "Verify that ImportSqlServerData copies RFC 4180 CSV file rows, including quoted " +
            "fields that contain commas.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ImportSqlServerDataCsvFileTest()
        {
            // Arrange: recreate the destination table and write the CSV rows to a temporary file.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var dataFile = NewDataFile(extension: ".csv", content: CsvData);

            try
            {
                // Arrange: reference the file instead of inline data.
                var rule = NewRule(arguments: $"--Table:ImportCustomers --DataFile:{dataFile}");

                // Act: import the file through the plugin.
                var entity = Invoke<ImportSqlServerData>(rule).Response.Entity;

                // Assert: both records are copied and the quoted comma stays inside its field.
                var name = SqlServerTestContainer.GetScalar(GetFirstNameCommandText);
                Assert.AreEqual(expected: "2", actual: entity["RowsCopied"]);
                Assert.AreEqual(expected: 2, actual: SqlServerTestContainer.GetScalar(CountRowsCommandText));
                Assert.AreEqual(expected: "Lovelace, Ada", actual: name);
            }
            finally
            {
                // Cleanup: delete the temporary file so the run leaves no data behind.
                File.Delete(dataFile);
            }
        }

        [TestMethod(DisplayName = "Verify that ImportSqlServerData copies inline JSON rows into an existing table, " +
            "mapping columns by name, and stores RowsCopied in the session and in the entity.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ImportSqlServerDataInlineTest()
        {
            // Arrange: recreate the destination table and pass the rows inline.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: $"--Data:{InlineData} --Table:ImportCustomers");

            // Act: import the rows through the plugin.
            var result = Invoke<ImportSqlServerData>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the session and the entity report both copied rows.
            Assert.AreEqual(
                expected: "2",
                actual: $"{sessionParameters["ImportSqlServerData:RowsCopied"]}".ConvertFromBase64());
            Assert.AreEqual(expected: "2", actual: result.Response.Entity["RowsCopied"]);

            // Assert: the rows reached their columns by name and JSON null stays NULL.
            var nullNames = SqlServerTestContainer.GetScalar(CountNullNamesCommandText);
            var country = SqlServerTestContainer.GetScalar(GetFirstCountryCommandText);
            Assert.AreEqual(expected: 2, actual: SqlServerTestContainer.GetScalar(CountRowsCommandText));
            Assert.AreEqual(expected: 1, actual: nullNames);
            Assert.AreEqual(expected: "GB", actual: country);
        }

        [TestMethod(DisplayName = "Verify that ImportSqlServerData treats a DataFile with a non-CSV extension as a " +
            "JSON array of rows.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ImportSqlServerDataJsonFileTest()
        {
            // Arrange: recreate the destination table and write the JSON rows to a temporary file.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var dataFile = NewDataFile(extension: ".json", content: JsonData);

            try
            {
                // Arrange: reference the file instead of inline data.
                var rule = NewRule(arguments: $"--Table:ImportCustomers --DataFile:{dataFile}");

                // Act: import the file through the plugin.
                var entity = Invoke<ImportSqlServerData>(rule).Response.Entity;

                // Assert: every row is copied, including the row without a Name key.
                Assert.AreEqual(expected: "3", actual: entity["RowsCopied"]);
                Assert.AreEqual(expected: 3, actual: SqlServerTestContainer.GetScalar(CountRowsCommandText));
            }
            finally
            {
                // Cleanup: delete the temporary file so the run leaves no data behind.
                File.Delete(dataFile);
            }
        }

        [TestMethod(DisplayName = "Verify that ImportSqlServerData fails when neither Data nor DataFile is set.")]
        [TestCategory("SqlServerLive")]
        public void ImportSqlServerDataMissingDataTest()
        {
            // Arrange: provide a connection and a table but no source rows.
            var rule = NewRule(arguments: "--Table:ImportCustomers");

            // Act and Assert: the plugin rejects the step and names both source arguments.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => Invoke<ImportSqlServerData>(rule));
            Assert.Contains(substring: "DataFile", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that ImportSqlServerData fails with a missing mandatory argument report " +
            "when the Table argument is missing.")]
        [TestCategory("SqlServerLive")]
        public void ImportSqlServerDataMissingTableTest()
        {
            // Arrange: provide a connection and rows but no destination table.
            var rule = NewRule(arguments: $"--Data:{InlineData} --CommandTimeout:30");

            // Act: run the step; the manifest marks Table mandatory, so the engine rejects it before OnSend.
            var response = Invoke<ImportSqlServerData>(rule).Response;

            // Assert: the response reports the missing argument by name and copies no rows.
            var messages = string.Join(" | ", response.Exceptions.Select(i => i.Exception.Message));
            Assert.Contains(substring: "'Table'", value: messages);
            Assert.IsFalse(response.Entity.ContainsKey("RowsCopied"));
        }

        [TestMethod(DisplayName = "Verify that ImportSqlServerData omits the entity when the NoEntity switch is set " +
            "and still stores the session parameters.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ImportSqlServerDataNoEntityTest()
        {
            // Arrange: recreate the destination table and request no entity.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: $"--Data:{InlineData} --Table:ImportCustomers --NoEntity");

            // Act: import the rows through the plugin.
            var result = Invoke<ImportSqlServerData>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the entity is omitted while the session output is still written.
            Assert.IsTrue(result.Response.Entity is null || result.Response.Entity.Count == 0);
            Assert.AreEqual(
                expected: "2",
                actual: $"{sessionParameters["ImportSqlServerData:RowsCopied"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that ImportSqlServerData copies rows into a schema-qualified table.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ImportSqlServerDataSchemaTableTest()
        {
            // Arrange: create the schema in its own batch, then recreate the schema-qualified table.
            SqlServerTestContainer.InvokeCommand(SetupSchemaCommandText);
            SqlServerTestContainer.InvokeCommand(SetupSchemaTableCommandText);

            var rule = NewRule(arguments: "--Data:[{\"Id\":1,\"Name\":\"Ada\"}] --Table:ImportSchema.Customers");

            // Act: import the row through the plugin.
            var entity = Invoke<ImportSqlServerData>(rule).Response.Entity;

            // Assert: the rows land in the named schema, not in dbo.
            var count = SqlServerTestContainer.GetScalar(CountSchemaRowsCommandText);
            Assert.AreEqual(expected: "1", actual: entity["RowsCopied"]);
            Assert.AreEqual(expected: 1, actual: count);
        }

        [TestMethod(DisplayName = "Verify that ImportSqlServerData commits the copied rows when the Transaction " +
            "switch is set.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void ImportSqlServerDataTransactionTest()
        {
            // Arrange: recreate the destination table and wrap the copy in a transaction.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: $"--Data:{InlineData} --Table:dbo.ImportCustomers --Transaction");

            // Act: import the rows through the plugin.
            var entity = Invoke<ImportSqlServerData>(rule).Response.Entity;

            // Assert: the committed rows are visible to a separate connection.
            Assert.AreEqual(expected: "2", actual: entity["RowsCopied"]);
            Assert.AreEqual(expected: 2, actual: SqlServerTestContainer.GetScalar(CountRowsCommandText));
        }

        // Writes the content to a uniquely named temporary file with the given extension, which selects the parser.
        // The caller owns the file and deletes it in a finally block.
        private static string NewDataFile(string extension, string content)
        {
            // Build a unique path under the temporary folder so parallel runs never share a file.
            var dataFile = Path.Combine(Path.GetTempPath(), $"g4-sqlserver-import-{Guid.NewGuid():N}{extension}");

            File.WriteAllText(dataFile, content);

            return dataFile;
        }

        // Creates an Action rule that connects to the shared test database through the raw connection string and
        // joins the scenario arguments into the CLI expression the plugin parses into its parameters.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Compose the CLI expression with the shared container connection first.
            var connectionArguments = $"--ConnectionString:{SqlServerTestContainer.ConnectionString}";

            return new ActionRuleModel
            {
                PluginName = nameof(ImportSqlServerData),
                Argument = "{{$ " + connectionArguments + " " + arguments + "}}"
            };
        }
    }
}
