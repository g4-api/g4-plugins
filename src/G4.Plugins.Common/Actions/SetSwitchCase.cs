using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(SetSwitchCase)}.json")]
    public class SetSwitchCase(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Constants for string comparison to ensure case-insensitive matching
            const StringComparison comparison = StringComparison.OrdinalIgnoreCase;

            // Determine if the current rule is a SwitchRuleModel
            var isSwitchRule = pluginData.Rule is SwitchRuleModel;

            if (isSwitchRule)
            {
                // Ensure that the Branches dictionary is initialized (if null) for the switch rule
                ((SwitchRuleModel)pluginData.Rule).Branches
                    ??= new Dictionary<string, IEnumerable<G4RuleModelBase>>();
            }

            // Prepare a local copy of branches with case-insensitive keys if it's a switch rule,
            // or an empty dictionary otherwise
            var branches = isSwitchRule
                ? new Dictionary<string, IEnumerable<G4RuleModelBase>>(((SwitchRuleModel)pluginData.Rule).Branches)
                : [];

            // Retrieve the element associated with this rule invocation
            var element = this.GetElement(pluginData.Rule, pluginData.Element);

            // Determine the key to use for branching based on the rule's parameters or argument
            var key = pluginData.Parameters.Get(key: "SwitchOn", defaultValue: pluginData.Rule.Argument);

            // Check if the IgnoreCase parameter is set in the plugin data
            var ignoreCase = pluginData.Parameters.ContainsKey("IgnoreCase");

            // Compute the branch key based on the rule and the element
            key = string.IsNullOrEmpty(pluginData.Rule.OnElement)
                ? key
                : GetKey(rule: pluginData.Rule, element);

            // If the key is null or empty, default it to "Default" to ensure a valid lookup
            key = string.IsNullOrEmpty(key) ? "Default" : key;

            // Lookup any child rules (branches) for the computed key; default to empty if none exist
            var rulesToInvoke = ignoreCase
                ? branches.FirstOrDefault(i => i.Key.Equals(key, comparison)).Value
                : branches.Get(key, defaultValue: Enumerable.Empty<G4RuleModelBase>());

            // If no rules are found for the key, check if a "Default" branch exists
            if (rulesToInvoke?.Any() != true)
            {
                rulesToInvoke = branches.FirstOrDefault(i => i.Key.Equals("Default", comparison)).Value ?? [];
            }

            // Disable further invocation of child rules on the original rule node
            pluginData.Rule.SetInvokeRules(false);

            // Invoke all retrieved child rules in order
            Invoker.Invoke([.. rulesToInvoke]);

            // Return a new, empty plugin response indicating successful execution
            return this.NewPluginResponse();
        }

        // Computes a branching key based on the provided rule and web element. 
        // If the element is not found, the rule’s Argument is returned. 
        // Otherwise, the element’s text or the specified attribute is extracted and matched against the rule’s RegularExpression.
        private static string GetKey(G4RuleModelBase rule, IWebElement element)
        {
            // If the element is not found, return the key from the rule argument.
            if (element == default)
            {
                return rule.Argument;
            }

            // If OnAttribute is not specified, use the element's text content as the key.
            // Otherwise, get the key from the specified attribute.
            var key = string.IsNullOrEmpty(rule.OnAttribute)
                ? element.Text
                : element.GetAttribute(rule.OnAttribute);

            // Use regular expression to match and extract the desired part of the key.
            var match = Regex.Match(
                input: key,
                pattern: rule.RegularExpression);

            // Return the desired part of the key.
            return match.Value;
        }
    }
}
