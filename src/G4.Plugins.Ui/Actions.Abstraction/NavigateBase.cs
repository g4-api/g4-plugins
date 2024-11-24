using G4.Extensions;
using G4.Models;

using Microsoft.Extensions.Logging;

using System.Threading;

namespace G4.Plugins.Ui.Actions.Abstraction
{
    /// <summary>
    /// Represents an abstract base class for navigation-related actions within a plugin.
    /// This class provides common functionality for executing navigation commands,
    /// such as repeating actions and applying delays between repetitions.
    /// </summary>
    /// <param name="pluginSetup">The setup model containing configuration and plugin information.</param>
    public abstract class NavigateBase(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the 'Repeat' argument from pluginData, with a default value of "1"
            var repeats = GetNumberOfRepeats(pluginData);

            // Convert the 'Delay' argument to a TimeSpan
            var delay = pluginData
                .Parameters
                .Get("Delay", "0")
                .ConvertToTimeSpan();

            // Check if delay exceeds the maximum allowed value
            if (delay.TotalMilliseconds > int.MaxValue)
            {
                // Define an error message indicating the delay value exceeds the maximum allowed value
                const string error400 = "Delay value ({TotalMilliseconds} milliseconds) exceeds " +
                    "the maximum allowed value ({MaxValue} milliseconds).";

                // Log a warning message indicating the delay value exceeds the maximum allowed value
                Logger.LogWarning(message: error400, delay.TotalMilliseconds, int.MaxValue);

                // Set the delay to the default value
                delay = default;
            }

            // Perform the navigation 'Back' action for the specified number of times with the specified delay
            for (int i = 0; i < repeats; i++)
            {
                // Invoke the navigation action based on the provided PluginDataModel
                InvokeNavigationAction(pluginData);

                // Wait for the specified delay before executing the next iteration
                Thread.Sleep(timeout: delay);
            }

            // Return a new PluginResponseModel indicating the successful completion of the action
            return this.NewPluginResponse();
        }

        /// <summary>
        /// Abstract method to invoke a navigation action based on the provided PluginDataModel.
        /// </summary>
        /// <param name="pluginData">The data model containing information for the navigation action.</param>
        protected abstract void InvokeNavigationAction(PluginDataModel pluginData);

        // Gets the number of repeats specified in the plugin data.
        private static int GetNumberOfRepeats(PluginDataModel pluginData)
        {
            // Extract relevant information from the plugin data
            var arguments = pluginData.Parameters;
            var argument = pluginData.Rule.Argument;

            // Check if the argument is a valid integer value
            var isArgumentValue = int.TryParse(argument, out int repeatOut);

            // Check if the 'Repeat' argument is not present and the 'Argument' is a valid integer value
            var isArgument = !arguments.ContainsKey("Repeat") && isArgumentValue;

            // Return the parsed repeat value if 'Argument' is a valid integer value
            if (isArgument)
            {
                return repeatOut;
            }

            // Get the 'Repeat' argument value or use the default value "1"
            var repeatValue = pluginData.Parameters.Get(key: "Repeat", defaultValue: "1");

            // Parse the 'Repeat' argument value to an integer
            isArgumentValue = int.TryParse(repeatValue, out repeatOut);

            // Return the parsed 'Repeat' value or default to 1 if parsing fails
            return isArgumentValue ? repeatOut : 1;
        }
    }
}
