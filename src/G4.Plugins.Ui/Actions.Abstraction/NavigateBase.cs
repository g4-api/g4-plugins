using G4.Extensions;
using G4.Models;

using Microsoft.Extensions.Logging;

using System;
using System.Threading;

namespace G4.Plugins.Ui.Actions.Abstraction
{
    /// <summary>
    /// Provides shared navigation execution logic for UI navigation plugins,
    /// including repeat handling and optional delay between actions.
    /// </summary>
    /// <param name="pluginSetup">Plugin setup model containing configuration and logger.</param>
    internal class NavigateBase(G4PluginSetupModel pluginSetup)
    {
        #region *** Methods      ***
        /// <summary>
        /// Executes the specified navigation action using the repeat and delay
        /// values resolved from the provided plugin data.
        /// </summary>
        /// <param name="pluginData">The plugin execution data that contains the navigation parameters.</param>
        /// <param name="navigationAction">The navigation action to execute for each iteration.</param>
        public void CallNavigate(PluginDataModel pluginData, Action navigationAction)
        {
            // Resolve how many times the navigation action should run.
            var repeats = GetNumberOfRepeats(pluginData);

            // Resolve the optional delay between repeated navigation actions.
            var delay = pluginData
                .Parameters
                .Get("Delay", "0")
                .ConvertToTimeSpan();

            // Guard against delays that exceed what Thread.Sleep can safely accept.
            if (delay.TotalMilliseconds > int.MaxValue)
            {
                // Define the warning template used when the configured delay is too large.
                const string error400 = "Delay value ({TotalMilliseconds} milliseconds) exceeds " +
                    "the maximum allowed value ({MaxValue} milliseconds).";

                // Log a warning and fall back to the default delay value.
                pluginSetup.Invoker.Logger.LogWarning(message: error400, delay.TotalMilliseconds, int.MaxValue);

                // Reset the delay to zero when the configured value is invalid.
                delay = default;
            }

            // Execute the requested navigation action for the resolved number of iterations.
            for (int i = 0; i < repeats; i++)
            {
                // Invoke the provided navigation action.
                navigationAction();

                // Wait before the next iteration when a delay is configured.
                Thread.Sleep(timeout: delay);
            }
        }

        // Resolves the number of times the navigation action should be repeated.
        // The resolved repeat count. Returns <c>1</c> when no valid repeat value is provided.
        private static int GetNumberOfRepeats(PluginDataModel pluginData)
        {
            // Read the full parameter collection and the raw argument value.
            var arguments = pluginData.Parameters;
            var argument = pluginData.Rule.Argument;

            // Check whether the raw argument itself is a valid integer.
            var isArgumentValue = int.TryParse(argument, out int repeatOut);

            // Support the legacy case where Repeat is not provided
            // and the rule argument itself contains the repeat count.
            var isArgument = !arguments.ContainsKey("Repeat") && isArgumentValue;

            // Return the raw argument value when it is being used as the repeat count.
            if (isArgument)
            {
                return repeatOut;
            }

            // Read the Repeat parameter, defaulting to 1 when it is not provided.
            var repeatValue = pluginData.Parameters.Get(key: "Repeat", defaultValue: "1");

            // Parse the Repeat parameter and return it when valid.
            isArgumentValue = int.TryParse(repeatValue, out repeatOut);

            // Fall back to a single execution when parsing fails.
            return isArgumentValue ? repeatOut : 1;
        }
        #endregion
    }
}
