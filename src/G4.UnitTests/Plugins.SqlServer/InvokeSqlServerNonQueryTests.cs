using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Actions;
using G4.UnitTests.Framework;

using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("InvokeSqlServerNonQuery")]
    [TestCategory("UnitTest")]
    [DoNotParallelize]
    public class InvokeSqlServerNonQueryTests : TestBase
    {
        // Counts the rows of the scenario table so assertions observe the committed state; static query text.
        private const string CountCommandText = "SELECT COUNT(*) FROM dbo.NonQueryOrders;";

        // Creates the table changed by every scenario with three known rows; static text with no runtime values.
        private const string SetupCommandText =
            "IF OBJECT_ID(N'dbo.NonQueryOrders', N'U') IS NOT NULL DROP TABLE dbo.NonQueryOrders; " +
            "CREATE TABLE dbo.NonQueryOrders (Id INT NOT NULL PRIMARY KEY, Status NVARCHAR(20) NOT NULL); " +
            "INSERT INTO dbo.NonQueryOrders VALUES (1, N'Open'), (2, N'Open'), (3, N'Closed');";

        [TestMethod(DisplayName = "Verify that the InvokeSqlServerNonQuery plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<InvokeSqlServerNonQuery>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeSqlServerNonQuery plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<InvokeSqlServerNonQuery>();
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerNonQuery keeps the statements that succeeded before a " +
            "failure when the Transaction switch is not set.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerNonQueryAutoCommitTest()
        {
            // Arrange: seed known rows and insert a new row followed by a duplicate primary key.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:INSERT INTO dbo.NonQueryOrders VALUES (10, N'Open'); " +
                "INSERT INTO dbo.NonQueryOrders VALUES (1, N'Open');");

            // Act and Assert: the duplicate key fails the step with the provider error.
            Assert.ThrowsExactly<SqlException>(() => Invoke<InvokeSqlServerNonQuery>(rule));

            // Assert: without a transaction, the first insert stays committed.
            Assert.AreEqual(expected: 4, actual: SqlServerTestContainer.GetScalar(CountCommandText));
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerNonQuery decodes Base64 CommandText when the Base64 " +
            "switch is set and runs the decoded statement.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerNonQueryBase64Test()
        {
            // Arrange: seed known rows and encode an update whose comment contains the inline terminators.
            SqlServerTestContainer.InvokeCommand(commandText: SetupCommandText);

            var commandText = "-- Ships the open orders; }} and -- travel safely inside Base64.\n" +
                "UPDATE dbo.NonQueryOrders SET Status = N'Shipped' WHERE Status = N'Open';";
            var rule = NewRule(arguments: $"--CommandText:{commandText.ConvertToBase64()} --Base64");

            // Act: run the encoded statement through the plugin.
            var entity = Invoke<InvokeSqlServerNonQuery>(rule).Response.Entity;

            // Assert: the decoded statement updated the two open orders.
            Assert.AreEqual(expected: "2", actual: entity["RowsAffected"]);
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerNonQuery omits the entity when the NoEntity switch is " +
            "set and still stores the session parameter.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerNonQueryNoEntityTest()
        {
            // Arrange: seed known rows and request no entity.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:DELETE FROM dbo.NonQueryOrders WHERE Id = 3 --NoEntity");

            // Act: run the statement through the plugin.
            var result = Invoke<InvokeSqlServerNonQuery>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the entity is omitted while the session output is still written.
            Assert.IsTrue(result.Response.Entity is null || result.Response.Entity.Count == 0);
            Assert.AreEqual(
                expected: "1",
                actual: $"{sessionParameters["InvokeSqlServerNonQuery:RowsAffected"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerNonQuery binds the parameters and reports the affected " +
            "row count as a Base64-encoded session parameter and in the entity.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerNonQueryRowsAffectedTest()
        {
            // Arrange: seed known rows and update the open orders through a bound parameter.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:UPDATE dbo.NonQueryOrders SET Status = N'Shipped' " +
                "WHERE Status = @Status --Parameters:{\"Status\":\"Open\"}");

            // Act: run the statement through the plugin.
            var result = Invoke<InvokeSqlServerNonQuery>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: both outputs report the two updated rows.
            Assert.AreEqual(
                expected: "2",
                actual: $"{sessionParameters["InvokeSqlServerNonQuery:RowsAffected"]}".ConvertFromBase64());
            Assert.AreEqual(expected: "2", actual: result.Response.Entity["RowsAffected"]);

            // Assert: the change is committed and visible to another connection.
            var shippedCommandText = "SELECT COUNT(*) FROM dbo.NonQueryOrders WHERE Status = N'Shipped';";
            Assert.AreEqual(expected: 2, actual: SqlServerTestContainer.GetScalar(shippedCommandText));
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerNonQuery rolls back every statement when the " +
            "Transaction switch is set and a later statement fails.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerNonQueryTransactionRollbackTest()
        {
            // Arrange: seed known rows and insert a new row followed by a duplicate primary key inside a transaction.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:INSERT INTO dbo.NonQueryOrders VALUES (10, N'Open'); " +
                "INSERT INTO dbo.NonQueryOrders VALUES (1, N'Open'); --Transaction");

            // Act and Assert: the duplicate key fails the step with the provider error.
            Assert.ThrowsExactly<SqlException>(() => Invoke<InvokeSqlServerNonQuery>(rule));

            // Assert: the transaction is rolled back, so the table keeps its seeded rows only.
            Assert.AreEqual(expected: 3, actual: SqlServerTestContainer.GetScalar(CountCommandText));
        }

        // Creates an Action rule that connects to the shared test database through the raw connection string.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Compose the CLI expression the plugin parses into its parameters.
            var connectionArguments = $"--ConnectionString:{SqlServerTestContainer.ConnectionString}";

            return new ActionRuleModel
            {
                PluginName = nameof(InvokeSqlServerNonQuery),
                Argument = "{{$ " + connectionArguments + " " + arguments + "}}"
            };
        }
    }
}
