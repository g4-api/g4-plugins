using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Exceptions;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(WaitFlow)}.json")]
    public class WaitFlow(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Check if the plugin data contains a condition
            var isCondition = pluginData.Parameters.Keys.Any(i => i.Equals("Condition", StringComparison.OrdinalIgnoreCase));

            // Determine whether to wait based on a condition or timeout
            return isCondition
                ? WaitCondition(this, pluginData)
                : WaitTimeout(this, pluginData);
        }

        // Executes a wait timeout for the specified duration.
        private static PluginResponseModel WaitTimeout(PluginBase plugin, PluginDataModel pluginData)
        {
            // A constant string representing the key for the timeout parameter
            const string Timeout = "Timeout";

            // Determine the timeout duration, either from plugin arguments or using the default timeout
            var timeout = pluginData.Parameters.Keys.Any(i => i.Equals(Timeout, StringComparison.OrdinalIgnoreCase))
                    ? pluginData.Parameters.Get(key: Timeout, defaultValue: "0").ConvertToTimeSpan()
                    : TimeSpan.FromSeconds(0);

            // Extract the timeout duration from the plugin data rule argument and convert it to a TimeSpan
            if (timeout == TimeSpan.FromSeconds(0))
            {
                timeout = pluginData
                    .Rule
                    .Argument
                    .ConvertToTimeSpan(defaultValue: TimeSpan.FromSeconds(0));
            }

            // Pause execution for the specified timeout duration
            Thread.Sleep(timeout);

            // Return a new plugin response indicating the completion of the wait timeout
            return plugin.NewPluginResponse();
        }

        // Waits until a condition is met or a timeout occurs.
        private static PluginResponseModel WaitCondition(PluginBase plugin, PluginDataModel pluginData)
        {
            // A constant string representing the key for the timeout parameter
            const string Timeout = "Timeout";

            // A constant string representing the key for the evaluation parameter
            const string Evaluation = "Evaluation";

            // Retrieve the default timeout from the engine configuration
            var defaultTimeout = plugin.Automation.Settings.AutomationSettings.SearchTimeout;

            // Determine the timeout duration, either from plugin arguments or using the default timeout
            var timeout = pluginData.Parameters.ContainsKey(Timeout)
                ? pluginData.Parameters.Get(key: Timeout, defaultValue: "0").ConvertToTimeSpan()
                : TimeSpan.FromMilliseconds(defaultTimeout);

            // Calculate the end time for the timeout
            var endTime = DateTime.UtcNow.Add(timeout);

            // Snapshot exceptions before polling so WaitFlow compacts only the transient assertion failures it owns.
            var originalExceptions = plugin.Exceptions.ToArray();
            var pollingExceptions = new List<G4ExceptionModel>();

            // Check if the condition has been met
            var conditionMet = InvokeAssertion(plugin, pluginData, pollingExceptions)
                .Entity
                .Get(key: Evaluation, defaultValue: false);

            // Loop until the condition is met or the timeout expires
            while (!conditionMet && DateTime.UtcNow < endTime)
            {
                // Pause execution for a short interval
                Thread.Sleep(millisecondsTimeout: 100);

                // Check the condition again
                conditionMet = InvokeAssertion(plugin, pluginData, pollingExceptions)
                    .Entity
                    .Get(key: Evaluation, defaultValue: false);
            }

            // Replace repeated polling failures with their last distinct KeyNotFoundException entries.
            NormalizePollingExceptions(plugin, pluginData, originalExceptions, pollingExceptions);

            if (!conditionMet)
            {
                // Report the wait timeout once after noisy polling failures have been compacted.
                AddTimeoutException(plugin, pluginData, timeout);
            }

            // Return a new plugin response indicating the completion of the wait operation
            return plugin.NewPluginResponse();
        }

        // Adds the final timeout failure produced by WaitFlow after assertion polling exhausts the timeout.
        private static void AddTimeoutException(PluginBase plugin, PluginDataModel pluginData, TimeSpan timeout)
        {
            // Create one timeout diagnostic so the response records the wait failure without interval duplicates.
            var condition = pluginData.Parameters.Get(key: "Condition", defaultValue: string.Empty);
            var message = $"WaitFlow condition '{condition}' timed out after '{timeout}' " +
                $"for element '{pluginData.Rule.OnElement}'.";
            var exception = new WebDriverTimeoutException(message, timeout);

            plugin.Exceptions.Add(new G4ExceptionModel(pluginData.Rule, exception));
        }

        // Invokes the assertion and captures the assertion response exceptions in polling order.
        private static PluginResponseModel InvokeAssertion(
            PluginBase plugin,
            PluginDataModel pluginData,
            List<G4ExceptionModel> pollingExceptions)
        {
            // Preserve per-interval assertion exceptions before WaitFlow compacts the plugin exception bag.
            var assertion = plugin.Assert(pluginData, addExtractions: false);

            foreach (var exception in assertion.Exceptions ?? [])
            {
                pollingExceptions.Add(exception);
            }

            return assertion;
        }

        // Keeps pre-existing exceptions and the last distinct polling KeyNotFoundException entries.
        private static void NormalizePollingExceptions(
            PluginBase plugin,
            PluginDataModel pluginData,
            IEnumerable<G4ExceptionModel> originalExceptions,
            IEnumerable<G4ExceptionModel> pollingExceptions)
        {
            // Retain only the final KeyNotFoundException for each report-visible identity and element.
            var distinctExceptions = new Dictionary<string, G4ExceptionModel>(StringComparer.Ordinal);
            foreach (var exception in pollingExceptions)
            {
                if (exception.Exception is not KeyNotFoundException)
                {
                    continue;
                }

                var key = GetExceptionKey(exception, pluginData.Rule.OnElement);
                distinctExceptions[key] = exception;
            }

            // Replace the bag in one step so non-KeyNotFound polling noise is excluded from the final response.
            plugin.Exceptions = new ConcurrentBag<G4ExceptionModel>(originalExceptions.Concat(distinctExceptions.Values));
        }

        // Returns the identity used to collapse repeated polling exceptions for one WaitFlow invocation.
        private static string GetExceptionKey(G4ExceptionModel exception, string onElement)
        {
            return string.Join(
                separator: "\u001F",
                exception.PluginName,
                exception.Type,
                exception.ReasonPhrase,
                onElement);
        }
    }
}
