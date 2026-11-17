using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(InvokeForLoop)}.json")]
    public class InvokeForLoop(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The unqualified name of the session parameter that carries the index of the running iteration.
        private const string IterationName = "Iteration";

        // The session key the iteration index is stored under, qualified by the plugin name as every other plugin
        // output is. A nested loop overwrites the key and gives the enclosing value back when it ends.
        private const string IterationParameter = $"{nameof(InvokeForLoop)}:{IterationName}";

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Disable the invocation of rules initially to prevent unintended executions.
            pluginData.Rule.SetInvokeRules(invoke: false);

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

            // Attempt to parse the 'Argument' property of the rule as an integer to determine the number of iterations.
            // If parsing fails, 'iterations' will be set to 0, and the loop will not invoke.
            _ = int.TryParse(pluginData.Rule.Argument, out int iterations);

            // Read the index this loop inherited from an enclosing loop, if any. The local holds the enclosing frame
            // for exactly as long as this loop runs, so the call stack itself carries the nested loop indexes.
            var sessionParameters = Invoker.Context.SessionParameters;
            var isInherited = sessionParameters.TryGetValue(IterationParameter, out object inheritedIteration);

            try
            {
                // Execute the iteration loop based on the parsed number of iterations.
                for (int i = 0; i < iterations; i++)
                {
                    // Invoke the rules for the current iteration.
                    InvokeIteration(plugin: this, iteration: i, [.. rules]);
                }
            }
            finally
            {
                // Hand the enclosing frame back even when an iteration failed, so no stale index outlives the loop.
                RestoreIteration(sessionParameters, isInherited, iteration: inheritedIteration);
            }

            // Create and return a new plugin response indicating successful execution.
            return this.NewPluginResponse();
        }

        // Invokes the specified rules for a given iteration.
        private static void InvokeIteration(PluginBase plugin, int iteration, params G4RuleModelBase[] rules)
        {
            // Publish the index before the iteration runs, so every step inside the loop reads the index of the
            // iteration it belongs to. The value is Base64-encoded, which Get-Parameter decodes by default.
            plugin.AddSessionParameter(
                @namespace: nameof(InvokeForLoop),
                name: IterationName,
                value: $"{iteration}");

            // Iterate through each rule to set the current iteration context.
            foreach (var rule in rules)
            {
                // Stamp the iteration on the rule and its entire subtree (child rules, transformers and switch
                // branches), linking each descendant to its parent's live reference for a unique runtime identifier.
                rule.SetIterationContext(iteration);

                // Enable the invocation of rules now that the context is properly set.
                rule.SetInvokeRules(true);
            }

            // Invoke the configured rules using the plugin's invoker.
            plugin.Invoker.Invoke(rules);
        }

        // Restores the iteration index the loop inherited, which its own iterations overwrote, so that a step placed
        // after a nested loop reads the index of the loop it belongs to.
        private static void RestoreIteration(
            ConcurrentDictionary<string, object> sessionParameters,
            bool isInherited,
            object iteration)
        {
            // Give the inherited value back when this loop ran inside another loop.
            if (isInherited)
            {
                sessionParameters[IterationParameter] = iteration;
                return;
            }

            // Remove the parameter when no enclosing loop published one, so the index does not outlive the loop.
            sessionParameters.TryRemove(IterationParameter, out _);
        }
    }
}
