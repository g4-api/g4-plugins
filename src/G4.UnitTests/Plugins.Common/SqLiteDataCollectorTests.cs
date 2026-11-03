using G4.Models;
using G4.Plugins.Common.DataCollectors;
using G4.UnitTests.Framework;

using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("SqLiteDataCollector")]
    [TestCategory("UnitTest")]
    public class SqLiteDataCollectorTests : TestBase
    {
        // Table name the collector writes to in every scenario; each test owns its own database file.
        private const string TableName = "products";

        // Creates the one-column table an earlier, narrower extraction leaves behind; static text built at compile time.
        private const string CreateLegacyTableSql = $"CREATE TABLE \"{TableName}\" (\"Legacy\" TEXT);";

        // Counts the rows the collector stored in the test table; static text built at compile time.
        private const string CountRowsSql = $"SELECT COUNT(*) FROM \"{TableName}\";";

        // Reads the column names of the test table, binding the table name as a value.
        private const string ReadColumnsSql = "SELECT name FROM pragma_table_info(@tableName);";

        // Columns expected after the collector adds the new key to the legacy table, in creation order.
        private static readonly string[] ExpectedLegacyColumns = ["Legacy", "Description"];

        // Columns expected when the collector creates the table for a hyphenated key.
        private static readonly string[] ExpectedHyphenatedColumns = ["product-description"];

        [TestMethod(DisplayName = "Verify that the SqLiteDataCollector plugin manifest complies with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the collector manifest documentation renders as the cache expects.
            AssertManifest<SqLiteDataCollector>();
        }

        [TestMethod(DisplayName = "Verify that the SqLiteDataCollector plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert: the collector can be created through the plugin factory.
            AssertPlugin<SqLiteDataCollector>();
        }

        [TestMethod(DisplayName = "Verify that the SqLiteDataCollector adds the columns an existing table lacks " +
            "and writes every entity of the extraction.")]
        [DoNotParallelize]
        public void SqLiteDataCollectorAddsMissingColumnsTest()
        {
            // Arrange: create the table an earlier, narrower extraction left behind, with one column only,
            // so the new 'Description' key does not exist yet when the collector runs.
            var databasePath = NewDatabasePath();

            try
            {
                // Arrange: write the legacy table and close the connection before the collector opens the file.
                using (var connection = new SqliteConnection($"Data Source={databasePath}"))
                {
                    connection.Open();
                    using var command = connection.CreateCommand();
                    command.CommandText = CreateLegacyTableSql;
                    command.ExecuteNonQuery();
                }

                // Act: export both simulator entities into the existing table.
                var exceptions = InvokeExport(databasePath, key: "Description");

                // Assert: the insert succeeds, the missing column is added next to the legacy one,
                // and both entities are stored.
                var (columns, rows) = ReadTable(databasePath);
                var failures = string.Join(" | ", exceptions.Select(exception => exception.Exception.Message));
                Assert.IsEmpty(collection: exceptions, message: failures);
                Assert.AreSequenceEqual(expected: ExpectedLegacyColumns, actual: columns);
                Assert.AreEqual(expected: 2, actual: rows);
            }
            finally
            {
                // Cleanup: release pooled connections so the temporary database file can be deleted.
                DeleteDatabase(databasePath);
            }
        }

        [TestMethod(DisplayName = "Verify that the SqLiteDataCollector writes content keys that contain '-' " +
            "and other characters that are not valid in SQL parameter names.")]
        [DoNotParallelize]
        public void SqLiteDataCollectorHyphenatedKeyTest()
        {
            // Arrange: use a key that is not a valid SQL parameter name, which used to be bound as '@product-description'.
            var databasePath = NewDatabasePath();

            try
            {
                // Act: export both simulator entities into a new table.
                var exceptions = InvokeExport(databasePath, key: "product-description");

                // Assert: the table is created with the hyphenated column and both entities are stored.
                var (columns, rows) = ReadTable(databasePath);
                var failures = string.Join(" | ", exceptions.Select(exception => exception.Exception.Message));
                Assert.IsEmpty(collection: exceptions, message: failures);
                Assert.AreSequenceEqual(expected: ExpectedHyphenatedColumns, actual: columns);
                Assert.AreEqual(expected: 2, actual: rows);
            }
            finally
            {
                // Cleanup: release pooled connections so the temporary database file can be deleted.
                DeleteDatabase(databasePath);
            }
        }

        // Deletes a temporary database after clearing the SQLite connection pool, which otherwise keeps the
        // file open after the collector's connection is disposed and blocks the delete on Windows.
        private static void DeleteDatabase(string databasePath)
        {
            // Release every pooled handle before touching the file.
            SqliteConnection.ClearAllPools();

            // Remove the file only when the scenario created it.
            if (File.Exists(databasePath))
            {
                File.Delete(databasePath);
            }
        }

        // Runs an Elements-scope export over the simulator page with one content rule and an SQLite collector
        // that writes per entity, returning the exceptions reported by the session.
        private IEnumerable<G4ExceptionModel> InvokeExport(string databasePath, string key)
        {
            // Build the export container: the simulator resolves '//positive' to two elements, so the
            // collector is invoked once per entity.
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
                            Repository = TableName,
                            Source = databasePath,
                            Type = "SqLiteDataCollector"
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

        // Builds a unique database path under the temporary folder so scenarios never share state.
        private static string NewDatabasePath()
        {
            return Path.Combine(Path.GetTempPath(), $"g4-sqlite-collector-{Guid.NewGuid():N}.db");
        }

        // Reads the column names and row count of the test table.
        private static (List<string> Columns, long Rows) ReadTable(string databasePath)
        {
            // Open the database written by the collector.
            using var connection = new SqliteConnection($"Data Source={databasePath}");
            connection.Open();

            // Collect the column names through the pragma table function.
            var columns = new List<string>();
            using (var columnsCommand = connection.CreateCommand())
            {
                columnsCommand.CommandText = ReadColumnsSql;
                columnsCommand.Parameters.AddWithValue("@tableName", TableName);

                using var reader = columnsCommand.ExecuteReader();
                while (reader.Read())
                {
                    columns.Add(reader.GetString(0));
                }
            }

            // Count the stored rows.
            using var countCommand = connection.CreateCommand();
            countCommand.CommandText = CountRowsSql;
            var rows = (long)countCommand.ExecuteScalar();

            return (columns, rows);
        }
    }
}
