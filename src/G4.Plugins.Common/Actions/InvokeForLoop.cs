using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Collections.Generic;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(InvokeForLoop)}.json")]
    public class InvokeForLoop(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
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

            // Execute the iteration loop based on the parsed number of iterations.
            for (int i = 0; i < iterations; i++)
            {
                // Invoke the rules for the current iteration.
                InvokeIteration(plugin: this, iteration: i, [.. rules]);
            }

            // Create and return a new plugin response indicating successful execution.
            return this.NewPluginResponse();
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
