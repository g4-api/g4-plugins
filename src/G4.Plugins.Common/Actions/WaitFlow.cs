using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Threading;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(WaitFlow)}.json")]
    public class WaitFlow(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Check if the plugin data contains a condition
            var isCondition = pluginData.Parameters.Count > 0;

            // Determine whether to wait based on a condition or timeout
            return isCondition
                ? WaitCondition(this, pluginData)
                : WaitTimeout(this, pluginData);
        }

        // Executes a wait timeout for the specified duration.
        private static PluginResponseModel WaitTimeout(PluginBase plugin, PluginDataModel pluginData)
        {
            // Extract the timeout duration from the plugin data rule argument and convert it to a TimeSpan
            var timeout = pluginData
                .Rule
                .Argument
                .ConvertToTimeSpan(defaultValue: TimeSpan.FromSeconds(0));

            // Pause execution for the specified timeout duration
            Thread.Sleep(timeout);

            // Return a new plugin response indicating the completion of the wait timeout
            return plugin.NewPluginResponse();
        }

        // Waits until a condition is met or a timeout occurs.
        private static PluginResponseModel WaitCondition(PluginBase plugin, PluginDataModel pluginData)
        {
            // Retrieve the default timeout from the engine configuration
            var defaultTimeout = plugin.Automation.Settings.AutomationSettings.SearchTimeout;

            // Determine the timeout duration, either from plugin arguments or using the default timeout
            var timeout = pluginData.Parameters.ContainsKey("Timeout")
                ? pluginData.Parameters.Get(key: "Timeout", defaultValue: "0").ConvertToTimeSpan()
                : TimeSpan.FromMilliseconds(defaultTimeout);

            // Calculate the end time for the timeout
            var endTime = DateTime.UtcNow.Add(timeout);

            // Check if the condition has been met
            var conditionMet = plugin
                .Assert(pluginData, addExtractions: false)
                .Entity
                .Get(key: "Evaluation", defaultValue: false);

            // Loop until the condition is met or the timeout expires
            while (!conditionMet && DateTime.UtcNow < endTime)
            {
                // Pause execution for a short interval
                Thread.Sleep(millisecondsTimeout: 100);

                // Check the condition again
                conditionMet = plugin
                    .Assert(pluginData, addExtractions: false)
                    .Entity
                    .Get(key: "Evaluation", defaultValue: false);
            }

            // Return a new plugin response indicating the completion of the wait operation
            return plugin.NewPluginResponse();
        }
    }
}
