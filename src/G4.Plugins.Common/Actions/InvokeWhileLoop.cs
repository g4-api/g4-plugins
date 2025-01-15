using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.Threading;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(InvokeWhileLoop)}.json")]
    public class InvokeWhileLoop(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Disable the invocation of child rules initially to prevent redundant executions.
            pluginData.Rule.SetInvokeRules(invoke: false);

            // Initialize the iteration counter.
            var iteration = 0;

            // Initialize a list to hold the processed rules for iteration.
            var rules = new List<G4RuleModelBase>();

            // Iterate through each rule in the plugin data to set up the necessary context.
            foreach (var rule in pluginData.Rule.Rules)
            {
                // Assign the current web element and HTML node to the rule's context.
                rule.Context[RuleProperties.WebElement] = pluginData.Element;
                rule.Context[RuleProperties.HtmlNode] = pluginData.HtmlNode;

                // Add the configured rule to the list for later invocation.
                rules.Add(rule);
            }

            // Determine the timeout span based on plugin data parameters.
            var timeoutSpan = GetTimeoutSpan(pluginData);

            // Calculate the absolute timeout DateTime if a timeout span is specified.
            var timeout = timeoutSpan == Timeout.InfiniteTimeSpan
                ? default
                : DateTime.UtcNow.Add(timeoutSpan);

            // Evaluate whether the loop should continue based on the initial condition and timeout.
            var continueLoop = AssertLoopCondition(plugin: this, pluginData, timeout);

            // Set the invocation rules based on the inverse of the loop condition.
            pluginData.Rule.SetInvokeRules(continueLoop);

            // Execute the loop as long as the condition evaluates to true.
            while (continueLoop)
            {
                // Invoke the current iteration of rules.
                InvokeIteration(plugin: this, iteration, [.. rules]);

                // Increment the iteration counter.
                iteration++;

                // Re-evaluate the loop condition after the iteration.
                continueLoop = AssertLoopCondition(plugin: this, pluginData, timeout);

                // Update the invocation rules based on the new loop condition.
                pluginData.Rule.SetInvokeRules(invoke: continueLoop);
            }

            // Create and return a new plugin response indicating successful execution.
            return this.NewPluginResponse();
        }

        // Asserts the loop condition based on the plugin's condition, plugin data, and timeout.
        // Determines whether the loop should continue executing.
        private static bool AssertLoopCondition(PluginBase plugin, PluginDataModel pluginData, DateTime timeout)
        {
            // Evaluate the plugin's condition. If the condition is not met, continue the loop.
            var isInvoke = AssertPluginCondition(plugin, pluginData);

            // Determine if a timeout has been specified.
            var isTimeout = timeout != default;

            // If a timeout is specified, ensure the current time has not exceeded the timeout.
            // The loop continues only if the condition is met and the timeout has not been reached.
            return isTimeout
                ? isInvoke && DateTime.UtcNow < timeout
                : isInvoke;
        }

        // Asserts a condition based on the given <see cref="PluginBase"/> instance and PluginDataModel.
        private static bool AssertPluginCondition(PluginBase plugin, PluginDataModel pluginData)
        {
            // Perform the assertion using the plugin, disabling the addition of extractions.
            var assertionResult = plugin.Assert(pluginData, addExtractions: false);

            // Retrieve the evaluation result from the assertion result.
            var evaluation = assertionResult.Entity[AssertionProperties.Evaluation];

            // Return true if the evaluation result is a boolean and is true; otherwise, return false.
            return evaluation is bool isTrue && isTrue;
        }

        // Retrieves the timeout value specified in the PluginDataModel.
        private static TimeSpan GetTimeoutSpan(PluginDataModel pluginData)
        {
            // Attempt to retrieve the 'Timeout' parameter from the plugin data.
            var isTimeout = pluginData.Parameters.TryGetValue("Timeout", out string timeout);

            // Convert the timeout value to a TimeSpan.
            // If conversion fails or 'Timeout' is not specified, default to InfiniteTimeSpan.
            return isTimeout
                ? timeout.ConvertToTimeSpan(defaultValue: TimeSpan.FromMilliseconds(0))
                : Timeout.InfiniteTimeSpan;
        }

        // Invokes the specified rules for a given iteration.
        private static void InvokeIteration(PluginBase plugin, int iteration, params G4RuleModelBase[] rules)
        {
            // Iterate through each rule to set the current iteration context.
            foreach (var rule in rules)
            {
                // Assign the current iteration number to the rule and its reference.
                rule.Iteration = iteration;
                rule.Reference.Iteration = iteration;

                // If the rule has child rules, set their parent references appropriately.
                foreach (var childRule in rule.Rules ?? [])
                {
                    childRule.Reference.ParentReference = rule.Reference;
                }

                // Enable the invocation of rules now that the context is properly set.
                rule.SetInvokeRules(true);
            }

            // Invoke the configured rules using the plugin's invoker.
            plugin.Invoker.Invoke(rules);
        }
    }
}
