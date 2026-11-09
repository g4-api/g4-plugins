using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Actions;
using G4.UnitTests.Framework;

using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Text;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("InvokeSqlServerScript")]
    [TestCategory("UnitTest")]
    [DoNotParallelize]
    public class InvokeSqlServerScriptTests : TestBase
    {
        // Counts the rows of the orders table so assertions observe the committed state; static query text.
        private const string CountCommandText = "SELECT COUNT(*) FROM dbo.ScriptOrders;";

        // Counts the rows of the ticks table written by the repeated batch; static query text.
        private const string CountTicksCommandText = "SELECT COUNT(*) FROM dbo.ScriptTicks;";

        // Recreates the orders and ticks tables with known rows and drops the procedure created by the scripts;
        // static text with no runtime values.
        private const string SetupCommandText =
            "IF OBJECT_ID(N'dbo.ScriptOrderCount', N'P') IS NOT NULL DROP PROCEDURE dbo.ScriptOrderCount; " +
            "IF OBJECT_ID(N'dbo.ScriptOrders', N'U') IS NOT NULL DROP TABLE dbo.ScriptOrders; " +
            "IF OBJECT_ID(N'dbo.ScriptTicks', N'U') IS NOT NULL DROP TABLE dbo.ScriptTicks; " +
            "CREATE TABLE dbo.ScriptOrders (Id INT NOT NULL PRIMARY KEY, Status NVARCHAR(20) NOT NULL); " +
            "CREATE TABLE dbo.ScriptTicks (Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Note NVARCHAR(20) NOT NULL); " +
            "INSERT INTO dbo.ScriptOrders VALUES (1, N'Open'), (2, N'Open'), (3, N'Closed');";

        [TestMethod(DisplayName = "Verify that the InvokeSqlServerScript plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<InvokeSqlServerScript>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeSqlServerScript plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<InvokeSqlServerScript>();
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerScript decodes Base64 CommandText when the Base64 " +
            "switch is set and splits the decoded script on GO lines.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerScriptBase64Test()
        {
            // Arrange: seed known rows and encode a two-batch script whose comments contain the inline terminators.
            SqlServerTestContainer.InvokeCommand(commandText: SetupCommandText);

            var script = "-- First batch; }} and -- travel safely inside Base64.\n" +
                "UPDATE dbo.ScriptOrders SET Status = N'Shipped' WHERE Id = 1;\n" +
                "GO -- end of the first batch\n" +
                "DELETE FROM dbo.ScriptOrders WHERE Id = 3;\n";
            var rule = NewRule(arguments: $"--CommandText:{script.ConvertToBase64()} --Base64");

            // Act: run the encoded script through the plugin.
            var entity = Invoke<InvokeSqlServerScript>(rule).Response.Entity;

            // Assert: the decoded script ran as two batches that changed one row each.
            Assert.AreEqual(expected: "2", actual: entity["BatchCount"]);
            Assert.AreEqual(expected: "2", actual: entity["RowsAffected"]);
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerScript splits the script on GO lines, runs each batch " +
            "in order, and reports the batch count as a Base64-encoded session parameter and in the entity.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerScriptBatchesTest()
        {
            // Arrange: seed known rows and write a script whose CREATE PROCEDURE requires its own batch.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var script = "INSERT INTO dbo.ScriptOrders VALUES (4, N'Open');\n" +
                "GO\n" +
                "CREATE PROCEDURE dbo.ScriptOrderCount AS SELECT COUNT(*) FROM dbo.ScriptOrders;\n" +
                "go\n" +
                "INSERT INTO dbo.ScriptOrders VALUES (5, N'Open');\n";
            var commandFile = NewCommandFile(script);
            var rule = NewRule(arguments: $"--CommandFile:{commandFile}");

            try
            {
                // Act: run the script through the plugin.
                var result = Invoke<InvokeSqlServerScript>(rule);
                var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

                // Assert: both separator spellings split the script into three batches.
                Assert.AreEqual(
                    expected: "3",
                    actual: $"{sessionParameters["InvokeSqlServerScript:BatchCount"]}".ConvertFromBase64());
                Assert.AreEqual(expected: "3", actual: result.Response.Entity["BatchCount"]);

                // Assert: the procedure created in the middle batch reads the rows inserted around it.
                Assert.AreEqual(expected: 5, actual: SqlServerTestContainer.GetScalar("EXEC dbo.ScriptOrderCount;"));
            }
            finally
            {
                // Cleanup: remove the temporary script so repeated runs leave no files behind.
                File.Delete(commandFile);
            }
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerScript repeats a batch as many times as its GO count " +
            "requests.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerScriptRepeatTest()
        {
            // Arrange: seed known rows and write one insert batch repeated three times.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var script = "INSERT INTO dbo.ScriptTicks (Note) VALUES (N'tick');\nGO 3\n";
            var commandFile = NewCommandFile(script);
            var rule = NewRule(arguments: $"--CommandFile:{commandFile}");

            try
            {
                // Act: run the script through the plugin.
                var entity = Invoke<InvokeSqlServerScript>(rule).Response.Entity;

                // Assert: each repetition counts as one batch and inserts one row.
                Assert.AreEqual(expected: "3", actual: entity["BatchCount"]);
                Assert.AreEqual(expected: "3", actual: entity["RowsAffected"]);
                Assert.AreEqual(expected: 3, actual: SqlServerTestContainer.GetScalar(CountTicksCommandText));
            }
            finally
            {
                // Cleanup: remove the temporary script so repeated runs leave no files behind.
                File.Delete(commandFile);
            }
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerScript sums the positive row counts of every batch and " +
            "ignores the counts DDL statements report.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerScriptRowsAffectedTest()
        {
            // Arrange: seed known rows and write an update, a delete, and a DDL-only batch.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var script = "UPDATE dbo.ScriptOrders SET Status = N'Shipped' WHERE Id = 1;\n" +
                "GO\n" +
                "DELETE FROM dbo.ScriptOrders WHERE Id IN (2, 3);\n" +
                "GO\n" +
                "CREATE TABLE #ScriptScratch (Id INT NOT NULL);\n";
            var commandFile = NewCommandFile(script);
            var rule = NewRule(arguments: $"--CommandFile:{commandFile}");

            try
            {
                // Act: run the script through the plugin.
                var entity = Invoke<InvokeSqlServerScript>(rule).Response.Entity;

                // Assert: the one updated and two deleted rows are summed and the DDL batch adds nothing.
                Assert.AreEqual(expected: "3", actual: entity["BatchCount"]);
                Assert.AreEqual(expected: "3", actual: entity["RowsAffected"]);
            }
            finally
            {
                // Cleanup: remove the temporary script so repeated runs leave no files behind.
                File.Delete(commandFile);
            }
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerScript rolls back every earlier batch when the " +
            "Transaction switch is set and a later batch fails.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerScriptTransactionRollbackTest()
        {
            // Arrange: seed known rows and write a valid insert batch followed by a duplicate primary key batch.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var script = "INSERT INTO dbo.ScriptOrders VALUES (4, N'Open');\n" +
                "GO\n" +
                "INSERT INTO dbo.ScriptOrders VALUES (1, N'Open');\n" +
                "GO\n";
            var commandFile = NewCommandFile(script);
            var rule = NewRule(arguments: $"--CommandFile:{commandFile} --Transaction");

            try
            {
                // Act and Assert: the failing batch stops the script with the provider error.
                Assert.ThrowsExactly<SqlException>(() => Invoke<InvokeSqlServerScript>(rule));

                // Assert: the transaction is rolled back, so the first batch insert is gone.
                Assert.AreEqual(expected: 3, actual: SqlServerTestContainer.GetScalar(CountCommandText));
            }
            finally
            {
                // Cleanup: remove the temporary script so repeated runs leave no files behind.
                File.Delete(commandFile);
            }
        }

        // Writes the script to a unique UTF-8 file in the temporary directory, because GO separators require line
        // breaks that an inline argument cannot carry. The caller owns the file and deletes it in its cleanup stage.
        private static string NewCommandFile(string script)
        {
            // Use a unique name so repeated and concurrent runs never read each other's scripts.
            var commandFile = Path.Combine(Path.GetTempPath(), $"g4-sqlserver-script-{Guid.NewGuid():N}.sql");

            File.WriteAllText(path: commandFile, contents: script, encoding: Encoding.UTF8);

            return commandFile;
        }

        // Creates an Action rule that connects to the shared test database through the raw connection string.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Compose the CLI expression the plugin parses into its parameters.
            var connectionArguments = $"--ConnectionString:{SqlServerTestContainer.ConnectionString}";

            return new ActionRuleModel
            {
                PluginName = nameof(InvokeSqlServerScript),
                Argument = "{{$ " + connectionArguments + " " + arguments + "}}"
            };
        }
    }
}
