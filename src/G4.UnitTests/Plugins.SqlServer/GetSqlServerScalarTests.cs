using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Text;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("GetSqlServerScalar")]
    [TestCategory("UnitTest")]
    [DoNotParallelize]
    public class GetSqlServerScalarTests : TestBase
    {
        // Creates the table read by every scenario with three known rows; static text with no runtime values.
        private const string SetupCommandText =
            "IF OBJECT_ID(N'dbo.ScalarCustomers', N'U') IS NOT NULL DROP TABLE dbo.ScalarCustomers; " +
            "CREATE TABLE dbo.ScalarCustomers (Id INT NOT NULL PRIMARY KEY, Name NVARCHAR(50) NULL); " +
            "INSERT INTO dbo.ScalarCustomers VALUES (1, N'Ada'), (2, N'Grace'), (3, NULL);";

        [TestMethod(DisplayName = "Verify that the GetSqlServerScalar plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<GetSqlServerScalar>();
        }

        [TestMethod(DisplayName = "Verify that the GetSqlServerScalar plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<GetSqlServerScalar>();
        }

        [TestMethod(DisplayName = "Verify that GetSqlServerScalar reads CommandFile as plain text when the Base64 " +
            "switch is set, because the switch decodes only CommandText.")]
        [TestCategory("SqlServerLive")]
        public void GetSqlServerScalarBase64CommandFileTest()
        {
            // Arrange: seed known rows and write a plain query file.
            SqlServerTestContainer.InvokeCommand(commandText: SetupCommandText);

            var script = "SELECT Name FROM dbo.ScalarCustomers WHERE Id = 2";
            var fileName = $"g4-sqlserver-scalar-{Guid.NewGuid():N}.sql";
            var commandFile = Path.Combine(path1: Path.GetTempPath(), path2: fileName);

            File.WriteAllText(path: commandFile, contents: script, encoding: Encoding.UTF8);

            try
            {
                // Arrange: reference the file and set the Base64 switch.
                var rule = NewRule(arguments: $"--CommandFile:{commandFile} --Base64");

                // Act: run the file query through the plugin.
                var entity = Invoke<GetSqlServerScalar>(rule).Response.Entity;

                // Assert: the file content runs unchanged instead of being decoded.
                Assert.AreEqual(expected: "Grace", actual: entity["Value"]);
            }
            finally
            {
                // Cleanup: remove the temporary script so repeated runs leave no files behind.
                File.Delete(path: commandFile);
            }
        }

        [TestMethod(DisplayName = "Verify that GetSqlServerScalar decodes Base64 CommandText when the Base64 switch " +
            "is set, including SQL with sequences that end an inline argument value.")]
        [TestCategory("SqlServerLive")]
        public void GetSqlServerScalarBase64Test()
        {
            // Arrange: seed known rows and encode a query whose comments contain the inline-argument terminators.
            SqlServerTestContainer.InvokeCommand(commandText: SetupCommandText);

            var commandText = "-- Counts the customers; }} and -- travel safely inside Base64.\n" +
                "SELECT COUNT(*) FROM dbo.ScalarCustomers WHERE Id > @Id -- bound, never composed\n";
            var arguments = $"--CommandText:{commandText.ConvertToBase64()} --Base64 --Parameters:{{\"Id\":1}}";
            var rule = NewRule(arguments);

            // Act: run the encoded query through the plugin.
            var entity = Invoke<GetSqlServerScalar>(rule).Response.Entity;

            // Assert: the decoded query ran with its comments intact and counted the two matching rows.
            Assert.AreEqual(expected: "2", actual: entity["Value"]);
        }

        [TestMethod(DisplayName = "Verify that GetSqlServerScalar reads a script from CommandFile, including SQL " +
            "comments that cannot travel inside an inline argument.")]
        [TestCategory("SqlServerLive")]
        public void GetSqlServerScalarCommandFileTest()
        {
            // Arrange: seed known rows and write a query whose comments contain the inline-argument terminator.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var script = "-- Reads the name of one customer.\n" +
                "SELECT Name FROM dbo.ScalarCustomers WHERE Id = @Id -- bound, never composed\n";
            var commandFile = Path.Combine(Path.GetTempPath(), $"g4-sqlserver-scalar-{Guid.NewGuid():N}.sql");

            File.WriteAllText(path: commandFile, contents: script, encoding: Encoding.UTF8);

            try
            {
                // Arrange: reference the file and bind the filter value.
                var rule = NewRule(arguments: $"--CommandFile:{commandFile} --Parameters:{{\"Id\":1}}");

                // Act: run the file query through the plugin.
                var entity = Invoke<GetSqlServerScalar>(rule).Response.Entity;

                // Assert: the comments are passed to the server intact and the bound row is read.
                Assert.AreEqual(expected: "Ada", actual: entity["Value"]);
            }
            finally
            {
                // Cleanup: remove the temporary script so repeated runs leave no files behind.
                File.Delete(commandFile);
            }
        }

        [TestMethod(DisplayName = "Verify that GetSqlServerScalar returns an empty value when the first column is " +
            "NULL or the query returns no row.")]
        [TestCategory("SqlServerLive")]
        #region *** Data Set ***
        [DataRow("SELECT Name FROM dbo.ScalarCustomers WHERE Id = 3")]
        [DataRow("SELECT Name FROM dbo.ScalarCustomers WHERE Id = 0")]
        #endregion
        public void GetSqlServerScalarEmptyValueTest(string commandText)
        {
            // Arrange: seed known rows and select either a NULL value or no row.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: $"--CommandText:{commandText}");

            // Act: run the query through the plugin.
            var result = Invoke<GetSqlServerScalar>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: a NULL value and a missing row both yield an empty value in the entity and the session.
            Assert.AreEqual(expected: string.Empty, actual: result.Response.Entity["Value"]);
            Assert.AreEqual(
                expected: string.Empty,
                actual: $"{sessionParameters["GetSqlServerScalar:Value"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that GetSqlServerScalar fails before reaching the server when the Base64 " +
            "switch is set and CommandText is not valid Base64.")]
        [TestCategory("SqlServerLive")]
        public void GetSqlServerScalarInvalidBase64Test()
        {
            // Arrange: send plain SQL, which is not valid Base64, with the Base64 switch set.
            var rule = NewRule(arguments: "--CommandText:SELECT * FROM dbo.ScalarCustomers --Base64");

            // Act: run the step through the plugin and capture the rejection.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(
                action: () => Invoke<GetSqlServerScalar>(rule));

            // Assert: the failure names the argument and the switch instead of a provider syntax error.
            Assert.Contains(substring: "'CommandText' is not valid Base64", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that GetSqlServerScalar returns non-string values as their JSON text.")]
        [TestCategory("SqlServerLive")]
        #region *** Data Set ***
        [DataRow("SELECT 42", "42")]
        [DataRow("SELECT CAST(1 AS BIT)", "true")]
        [DataRow("SELECT CAST(12.50 AS DECIMAL(5,2))", "12.50")]
        [DataRow("SELECT CAST('2024-01-01' AS DATETIME2(0))", "2024-01-01T00:00:00")]
        #endregion
        public void GetSqlServerScalarJsonTextTest(string commandText, string expected)
        {
            // Arrange: select one literal of a non-string type.
            var rule = NewRule(arguments: $"--CommandText:{commandText}");

            // Act: run the query through the plugin.
            var entity = Invoke<GetSqlServerScalar>(rule).Response.Entity;

            // Assert: the value uses its minified JSON text without surrounding quotes.
            Assert.AreEqual(expected, actual: entity["Value"]);
        }

        [TestMethod(DisplayName = "Verify that GetSqlServerScalar omits the entity when the NoEntity switch is set " +
            "and still stores the session parameter.")]
        [TestCategory("SqlServerLive")]
        public void GetSqlServerScalarNoEntityTest()
        {
            // Arrange: seed known rows and request no entity.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:SELECT COUNT(*) FROM dbo.ScalarCustomers --NoEntity");

            // Act: run the query through the plugin.
            var result = Invoke<GetSqlServerScalar>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the entity is omitted while the session output is still written.
            Assert.IsTrue(result.Response.Entity is null || result.Response.Entity.Count == 0);
            Assert.AreEqual(
                expected: "3",
                actual: $"{sessionParameters["GetSqlServerScalar:Value"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that GetSqlServerScalar binds the parameters and stores the value as a " +
            "Base64-encoded session parameter and in the entity.")]
        [TestCategory("SqlServerLive")]
        public void GetSqlServerScalarParametersTest()
        {
            // Arrange: seed known rows and filter them through a bound parameter.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: "--CommandText:SELECT Name FROM dbo.ScalarCustomers WHERE Id = @Id " +
                "--Parameters:{\"Id\":2}");

            // Act: run the query through the plugin.
            var result = Invoke<GetSqlServerScalar>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the string value is stored raw, without JSON quotes, in the session and the entity.
            Assert.AreEqual(
                expected: "Grace",
                actual: $"{sessionParameters["GetSqlServerScalar:Value"]}".ConvertFromBase64());
            Assert.AreEqual(expected: "Grace", actual: result.Response.Entity["Value"]);
        }

        // Creates an Action rule that connects to the shared test database through the raw connection string.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Compose the CLI expression the plugin parses into its parameters.
            var connectionArguments = $"--ConnectionString:{SqlServerTestContainer.ConnectionString}";

            return new ActionRuleModel
            {
                PluginName = nameof(GetSqlServerScalar),
                Argument = "{{$ " + connectionArguments + " " + arguments + "}}"
            };
        }
    }
}
