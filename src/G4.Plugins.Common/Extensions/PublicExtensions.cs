using G4.Models;
using G4.Plugins;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.Extensions
{
    /// <summary>
    /// Provides extension methods for the PluginBase class.
    /// </summary>
    public static class PublicExtensions
    {
        /// <summary>
        /// Executes an assertion using the provided PluginDataModel and handles any exceptions.
        /// </summary>
        /// <param name="plugin">The PluginBase-derived instance to execute the assertion.</param>
        /// <param name="pluginData">The PluginDataModel containing assertion information.</param>
        /// <param name="addExtractions">A flag indicating whether to add extractions.</param>
        /// <returns>The PluginResponseModel representing the assertion result.</returns>
        public static PluginResponseModel Assert(this PluginBase plugin, PluginDataModel pluginData, bool addExtractions)
        {
            // Retrieve the action rule from pluginData and store it in the 'action' variable.
            var action = pluginData.Rule;

            // Confirm if the assertion fails on exception by checking the plugin parameters for the key 'FailOnException'.
            var failOnException = pluginData.Parameters.ContainsKey(key: "FailOnException");

            // Initialize a new PluginResponseModel to store the assertion results
            var assertion = new PluginResponseModel();

            // Initialize a list to collect any assertion exceptions
            var assertionExceptions = new List<G4ExceptionModel>();

            // Initialize assertion response properties
            assertion.Entity ??= new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            assertion.Exceptions ??= [];
            plugin.Exceptions ??= [];

            try
            {
                // Get assertion arguments and action from the provided action
                var arguments = plugin.FormatAssertionArguments(cli: action.Argument);
                var assertRule = pluginData.Rule.NewAssertionRule(arguments);

                // Store the name of the assertion method in the action context
                action.Context["AssertMethod"] = assertRule.GetManifest()?.Key ?? plugin.GetType().Name;

                var response = plugin.Invoker.Invoke(assertRule).First();

                // Invoke the assertion action and retrieve the response
                var (isBoolean, evaluation) = response.ConfirmBooleanAssertion();

                // If the response is a boolean assertion, update the assertion model
                // with the response and set the evaluation result in the entity
                if (isBoolean)
                {
                    assertion = response; // Update the assertion model with the response
                    assertion.Entity[AssertionProperties.Evaluation] = evaluation;
                }
                else
                {
                    // Add any exceptions from the assertion response to the plugin
                    plugin.AddExceptions([.. response.Exceptions]);

                    // Create an operator rule from the assertion response entity
                    var operatorRule = assertRule.NewOperatorRule(response.Entity);

                    // If the assertion is not a boolean, invoke an operator if applicable
                    assertion = plugin.Invoker.Invoke(operatorRule).First();
                }
            }
            catch (Exception e)
            {
                // Handle exceptions during assertion and store evaluation result as false
                assertion.Entity["Evaluation"] = false;
                assertionExceptions.Add(new G4ExceptionModel(action, e));
            }

            // Create and add extractions if required
            if (addExtractions)
            {
                var session = $"{plugin.WebDriver?.Invoker.Session}";
                var extraction = new G4ExtractionModel().SetDefault(session, pluginData.Rule.Reference);
                extraction.Entities =
                [
                    new G4EntityModel { Content =  assertion.Entity}
                ];
                plugin.Extractions.Add(extraction);
            }

            // Concatenate the exceptions from the assertion response with any assertion exceptions
            assertion.Exceptions = assertion.Exceptions.Concat(assertionExceptions);

            // Update the assertion model with the evaluation result based on the
            // exceptions and the 'FailOnException' flag value
            if (failOnException && !plugin.Exceptions.IsEmpty)
            {
                assertion.Entity["Evaluation"] = false;
            }

            // Add all collected exceptions to the plugin's exception list
            plugin.AddExceptions([.. assertion.Exceptions]);

            // Store the assertion response model in the action context for reference
            action.Context["PluginResponseModel"] = assertion;

            // Return the assertion response model
            return assertion;
        }
    }
}
