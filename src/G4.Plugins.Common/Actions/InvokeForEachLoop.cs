using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote;

using System.Collections.Generic;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(InvokeForEachLoop)}.json")]
    public class InvokeForEachLoop(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Disables the invocation of rules initially to prevent unintended executions.
            pluginData.Rule.SetInvokeRules(invoke: false);

            // Initializes a list to hold the processed rules for iteration.
            var rules = new List<G4RuleModelBase>();

            // Iterates through each rule in the plugin data to set up the necessary context.
            foreach (var rule in pluginData.Rule.Rules)
            {
                // Assigns the current web element and HTML node to the rule's context.
                rule.Context[RuleProperties.WebElement] = pluginData.Element;
                rule.Context[RuleProperties.HtmlNode] = pluginData.HtmlNode;

                // Adds the configured rule to the list for later invocation.
                rules.Add(rule);
            }

            var elements = this.GetElements(pluginData.Rule, pluginData.Element);
            var iteration = 0;

            // Executes the iteration loop based on the parsed number of iterations.
            foreach (var element in elements)
            {
                // Invokes the rules for the current iteration.
                InvokeIteration(plugin: this, element, iteration, [.. rules]);
                iteration++;
            }

            // Creates and returns a new plugin response indicating successful execution.
            return this.NewPluginResponse();
        }

        // Invokes the specified rules for a given iteration.
        private static void InvokeIteration(PluginBase plugin, IWebElement element, int iteration, params G4RuleModelBase[] rules)
        {
            // Iterates through each rule to set the current iteration context.
            foreach (var rule in rules)
            {
                // Assigns the current iteration number to the rule and its reference.
                rule.Iteration = iteration;
                rule.Reference.Iteration = iteration;
                rule.Context[RuleProperties.WebElement] = element;

                // If the rule has child rules, sets their parent references appropriately.
                foreach (var childRule in rule.Rules ?? [])
                {
                    childRule.Reference.ParentReference = rule.Reference;
                }

                // Enables the invocation of rules now that the context is properly set.
                rule.SetInvokeRules(true);
            }

            // Invokes the configured rules using the plugin's invoker.
            plugin.Invoker.Invoke(rules);
        }
    }
}
