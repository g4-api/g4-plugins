using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.SqlServer.Clients;
using G4.Plugins.SqlServer.Extensions;
using G4.Plugins.SqlServer.Models;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace G4.Plugins.SqlServer.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.SqlServer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.SqlServer.Actions.Manifests.{NameReference}.json")]
    public class InvokeSqlServerProcedure(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session outputs of this plugin as InvokeSqlServerProcedure:<Name>.
        private const string NameReference = nameof(InvokeSqlServerProcedure);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Resolve the connection, the procedure name, the input values, and the switches before opening resources.
            var connectionModel = pluginData.ResolveConnection();
            var procedure = pluginData.Parameters.Get(key: "Procedure", defaultValue: string.Empty);
            var inputs = pluginData.ResolveSqlParameters();
            var noEntity = pluginData.TestSwitch(name: "NoEntity");
            var isTransaction = pluginData.TestSwitch(name: "Transaction");

            // Require the procedure name so the failure names the missing argument.
            if (string.IsNullOrWhiteSpace(procedure))
            {
                throw new InvalidOperationException("The 'Procedure' argument is required.");
            }

            // Open a connection owned by this step and start a transaction when requested.
            using var connection = SqlServerClient.OpenConnection(connectionModel);
            using var transaction = isTransaction ? connection.BeginTransaction() : null;
            using var command = connection.CreateCommand();

            // Address the procedure by name as a stored-procedure command, so its name is never composed into SQL text.
            command.CommandText = procedure;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = pluginData.ResolveCommandTimeout();
            command.Transaction = transaction;

            // Derive the procedure signature from the server so output parameters need no type declarations.
            SqlCommandBuilder.DeriveParameters(command);

            // Assign the caller values to the matching input parameters; unmatched names fail before execution.
            SetInputValues(command, inputs);

            // Read every result set; output parameters and the return value become readable once the reader closes.
            List<SqlServerResultSetModel> resultSets;

            using (var reader = command.ExecuteReader())
            {
                resultSets = SqlServerClient.ConvertToResultSets(reader);
            }

            // Commit only after the procedure succeeded.
            transaction?.Commit();

            // Collect the return value and the output parameters (named without the @ prefix).
            var parameters = command.Parameters.Cast<SqlParameter>().ToArray();

            var returnValue = parameters
                .FirstOrDefault(i => i.Direction == ParameterDirection.ReturnValue)?
                .Value;

            var outputParameters = parameters
                .Where(i => i.Direction is ParameterDirection.Output or ParameterDirection.InputOutput)
                .ToDictionary(
                    keySelector: i => i.ParameterName.TrimStart('@'),
                    elementSelector: i => SqlServerClient.ConvertToJsonValue(value: i.Value));

            // Expose the first result set as the primary result and serialize every outcome once.
            var result = resultSets.FirstOrDefault() ?? new SqlServerResultSetModel();

            var outputs = new Dictionary<string, string>
            {
                ["OutputParameters"] = SqlServerClient.ConvertToJson(value: outputParameters),
                ["Result"] = SqlServerClient.ConvertToJson(value: result.Rows),
                ["ResultSets"] = SqlServerClient.ConvertToJson(value: resultSets.Select(i => i.Rows)),
                ["ReturnValue"] = SqlServerClient.ConvertToText(value: returnValue)
            };

            // Publish the procedure outcome as Base64 session parameters and, unless suppressed, as the entity.
            return this.NewSqlServerResponse(nameReference: NameReference, outputs, noEntity);
        }

        // Assigns the caller values to the derived procedure parameters by name, case-insensitively. Derived
        // parameters without a caller value receive DBNull, so procedure defaults apply only when declared with
        // NULL handling. A caller value that matches no input parameter fails the step before execution.
        private static void SetInputValues(SqlCommand command, IReadOnlyList<SqlParameter> inputs)
        {
            // Index the derived input parameters so caller names resolve without the @ prefix sensitivity.
            var derived = command
                .Parameters
                .Cast<SqlParameter>()
                .Where(i => i.Direction is ParameterDirection.Input or ParameterDirection.InputOutput)
                .ToDictionary(i => i.ParameterName, StringComparer.OrdinalIgnoreCase);

            // Default every input to DBNull so unassigned parameters are sent explicitly as NULL.
            foreach (var parameter in derived.Values)
            {
                parameter.Value = DBNull.Value;
            }

            // Copy each caller value onto its matching derived parameter.
            foreach (var input in inputs)
            {
                // Reject a caller value without a matching input parameter so a typo never silently sends NULL.
                if (!derived.TryGetValue(input.ParameterName, out var parameter))
                {
                    var message = $"The procedure has no input parameter named '{input.ParameterName}'.";
                    throw new InvalidOperationException(message);
                }

                parameter.Value = input.Value;
            }
        }
    }
}
