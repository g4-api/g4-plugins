using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Linq;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(SetCondition)}.json")]
    public class SetCondition(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        /// <summary>
        /// Executes the plugin's main logic when a send action is performed.
        /// </summary>
        /// <param name="pluginData">The plugin data model containing execution context.</param>
        /// <returns>A <see cref="PluginResponseModel"/> representing the result of the execution.</returns>
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Perform an assertion based on the plugin data and get the result.
            var assertionResult = this.Assert(pluginData, addExtractions: false);

            // Retrieve the evaluation result from the assertion's entity.
            var evaluation = assertionResult.Entity[AssertionProperties.Evaluation];

            // Determine if the evaluation result indicates that sub-actions should be invoked.
            var actionsBranchEvaluation = evaluation is bool assertionEvaluation && assertionEvaluation;

            // Avoid redundant invocation of the rules by setting 'InvokeRules' to false.
            pluginData.Rule.SetInvokeRules(false);

            // Get the positive and negative actions associated with the plugin data.
            var (positiveActions, negativeActions) = GetActions(pluginData);

            // Select the appropriate set of rules to invoke based on the evaluation result.
            var rulesToInvoke = actionsBranchEvaluation ? positiveActions : negativeActions;

            // Invoke the selected rules.
            Invoker.Invoke(rulesToInvoke);

            // Return a new plugin response indicating successful execution.
            return this.NewPluginResponse();
        }

        /// <summary>
        /// Retrieves the positive and negative actions from the plugin data.
        /// </summary>
        /// <param name="pluginData">The plugin data model containing the rule information.</param>
        /// <returns>
        /// A tuple containing arrays of positive actions and negative actions (<see cref="G4RuleModelBase"/>[]).
        /// </returns>
        private static (G4RuleModelBase[] PositiveActions, G4RuleModelBase[] NegativeActions) GetActions(PluginDataModel pluginData)
        {
            // Check if the rule in the plugin data is a condition rule.
            var isConditionRule = pluginData.Rule is ConditionRuleModel;

            // If it is a condition rule, get the negative rules; otherwise, use an empty array.
            var negativeRules = isConditionRule
                ? ((ConditionRuleModel)pluginData.Rule).NegativeRules?.ToArray() ?? []
                : [];

            // Get the positive actions from the rule's 'Rules' property, or use an empty array if null.
            var positiveActions = pluginData.Rule.Rules?.ToArray() ?? [];

            // Return the positive and negative actions as a tuple.
            return (PositiveActions: positiveActions, NegativeActions: negativeRules);
        }
    }
}
