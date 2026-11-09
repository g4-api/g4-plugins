using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace G4.UnitTests.Plugins.SqlServer
{
    [TestClass]
    [TestCategory("InvokeSqlServerProcedure")]
    [TestCategory("UnitTest")]
    public class InvokeSqlServerProcedureTests : TestBase
    {
        // Creates the procedure called by every scenario: it counts the matching literal rows into an output
        // parameter, returns their identifiers as a result set, and returns 7; static text with no runtime values.
        private const string SetupCommandText =
            "CREATE OR ALTER PROCEDURE dbo.ProcedureCountCustomers @Country NVARCHAR(2), @Total INT OUTPUT AS " +
            "BEGIN SET NOCOUNT ON; " +
            "SELECT @Total = COUNT(*) FROM (VALUES (1, N'GB'), (2, N'US'), (3, N'US')) AS c (Id, Country) " +
            "WHERE c.Country = @Country; " +
            "SELECT c.Id FROM (VALUES (1, N'GB'), (2, N'US'), (3, N'US')) AS c (Id, Country) " +
            "WHERE c.Country = @Country ORDER BY c.Id; " +
            "RETURN 7; END";

        // Names the procedure created by the setup command.
        private const string ProcedureName = "dbo.ProcedureCountCustomers";

        // Holds the first result set the procedure returns for the US country.
        private const string ExpectedResult = "[{\"Id\":2},{\"Id\":3}]";

        [TestMethod(DisplayName = "Verify that the InvokeSqlServerProcedure plugin manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the manifest renders and validates as the plugin cache expects.
            AssertManifest<InvokeSqlServerProcedure>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeSqlServerProcedure plugin is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin can be created through the plugin factory.
            AssertPlugin<InvokeSqlServerProcedure>();
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerProcedure fails with a missing mandatory argument " +
            "report when the Procedure argument is missing.")]
        [TestCategory("SqlServerLive")]
        public void InvokeSqlServerProcedureMissingProcedureTest()
        {
            // Arrange: provide a connection and parameters but no procedure name.
            var rule = NewRule(arguments: "--Parameters:{\"Country\":\"US\"} --CommandTimeout:30");

            // Act: run the step; the manifest marks Procedure mandatory, so the engine rejects it before OnSend.
            var response = Invoke<InvokeSqlServerProcedure>(rule).Response;

            // Assert: the response reports the missing argument by name and carries no procedure outputs.
            var messages = string.Join(" | ", response.Exceptions.Select(i => i.Exception.Message));
            Assert.Contains(substring: "'Procedure'", value: messages);
            Assert.IsFalse(response.Entity.ContainsKey("Result"));
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerProcedure omits the entity when the NoEntity switch is " +
            "set and still stores the session parameters.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void InvokeSqlServerProcedureNoEntityTest()
        {
            // Arrange: create the procedure and request no entity.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: $"--Procedure:{ProcedureName} --Parameters:{{\"Country\":\"US\"}} --NoEntity");

            // Act: call the procedure through the plugin.
            var result = Invoke<InvokeSqlServerProcedure>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the entity is omitted while the session output is still written.
            Assert.IsTrue(result.Response.Entity is null || result.Response.Entity.Count == 0);
            Assert.AreEqual(
                expected: "7",
                actual: $"{sessionParameters["InvokeSqlServerProcedure:ReturnValue"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerProcedure binds the input, and reports the result " +
            "sets, the output parameters, and the return value in the session and in the entity.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void InvokeSqlServerProcedureOutputsTest()
        {
            // Arrange: create the procedure and pass its input value only; the output needs no declaration.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: $"--Parameters:{{\"Country\":\"US\"}} --Procedure:{ProcedureName}");

            // Act: call the procedure through the plugin.
            var result = Invoke<InvokeSqlServerProcedure>(rule);
            var sessionParameters = result.Plugin.Invoker.Context.SessionParameters;

            // Assert: the session holds the Base64 minified JSON outputs, with the output named without '@'.
            Assert.AreEqual(
                expected: ExpectedResult,
                actual: $"{sessionParameters["InvokeSqlServerProcedure:Result"]}".ConvertFromBase64());
            Assert.AreEqual(
                expected: $"[{ExpectedResult}]",
                actual: $"{sessionParameters["InvokeSqlServerProcedure:ResultSets"]}".ConvertFromBase64());
            Assert.AreEqual(
                expected: "{\"Total\":2}",
                actual: $"{sessionParameters["InvokeSqlServerProcedure:OutputParameters"]}".ConvertFromBase64());
            Assert.AreEqual(
                expected: "7",
                actual: $"{sessionParameters["InvokeSqlServerProcedure:ReturnValue"]}".ConvertFromBase64());

            // Assert: the entity carries the same outputs, unqualified and in plain text.
            var entity = result.Response.Entity;
            Assert.AreEqual(expected: ExpectedResult, actual: entity["Result"]);
            Assert.AreEqual(expected: $"[{ExpectedResult}]", actual: entity["ResultSets"]);
            Assert.AreEqual(expected: "{\"Total\":2}", actual: entity["OutputParameters"]);
            Assert.AreEqual(expected: "7", actual: entity["ReturnValue"]);
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerProcedure matches input names case-insensitively and " +
            "with or without the '@' prefix.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        #region *** Data Set ***
        [DataRow("{\"country\":\"US\"}", DisplayName = "Lowercase name without prefix")]
        [DataRow("{\"@COUNTRY\":\"US\"}", DisplayName = "Uppercase name with prefix")]
        #endregion
        public void InvokeSqlServerProcedureParameterNamesTest(string parameters)
        {
            // Arrange: create the procedure and address its input in the casing and prefix form of the row.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: $"--Parameters:{parameters} --Procedure:{ProcedureName}");

            // Act: call the procedure through the plugin.
            var entity = Invoke<InvokeSqlServerProcedure>(rule).Response.Entity;

            // Assert: the value reached the procedure input, so the filtered rows and count are returned.
            Assert.AreEqual(expected: ExpectedResult, actual: entity["Result"]);
            Assert.AreEqual(expected: "{\"Total\":2}", actual: entity["OutputParameters"]);
        }

        [TestMethod(DisplayName = "Verify that InvokeSqlServerProcedure fails before execution when a parameter " +
            "name matches no procedure input.")]
        [TestCategory("SqlServerLive")]
        [DoNotParallelize]
        public void InvokeSqlServerProcedureUnknownInputTest()
        {
            // Arrange: create the procedure and pass a value for an input it does not declare.
            SqlServerTestContainer.InvokeCommand(SetupCommandText);

            var rule = NewRule(arguments: $"--Parameters:{{\"Region\":\"US\"}} --Procedure:{ProcedureName}");

            // Act and Assert: the plugin rejects the step and names the unknown input.
            var exception = Assert.ThrowsExactly<InvalidOperationException>(() => Invoke<InvokeSqlServerProcedure>(rule));
            Assert.Contains(substring: "Region", value: exception.Message);
        }

        // Creates an Action rule that connects to the shared test database through the raw connection string and
        // joins the scenario arguments into the CLI expression the plugin parses into its parameters.
        private static ActionRuleModel NewRule(string arguments)
        {
            // Compose the CLI expression with the shared container connection first.
            var connectionArguments = $"--ConnectionString:{SqlServerTestContainer.ConnectionString}";

            return new ActionRuleModel
            {
                PluginName = nameof(InvokeSqlServerProcedure),
                Argument = "{{$ " + connectionArguments + " " + arguments + "}}"
            };
        }
    }
}
