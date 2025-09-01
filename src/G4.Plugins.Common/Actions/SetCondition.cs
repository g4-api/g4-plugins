using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(SetCondition)}.json")]
    public class SetCondition(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
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

        // Retrieves the positive (TRUE) and negative (FALSE) actions from the given plugin data.
        private static (G4RuleModelBase[] PositiveActions, G4RuleModelBase[] NegativeActions) GetActions(PluginDataModel pluginData)
        {
            // Use a case-insensitive string comparer for branch keys.
            var comparer = StringComparer.OrdinalIgnoreCase;

            // Determine if the plugin data rule is a SwitchRuleModel.
            var isSwitchRule = pluginData.Rule is SwitchRuleModel;

            // If it's a SwitchRuleModel, ensure its Branches dictionary is initialized.
            if (isSwitchRule)
            {
                ((SwitchRuleModel)pluginData.Rule).Branches
                    ??= new Dictionary<string, IEnumerable<G4RuleModelBase>>(comparer);
            }

            // Create a local copy of the branches dictionary (or an empty one if not a SwitchRuleModel).
            var branches = isSwitchRule
                ? new Dictionary<string, IEnumerable<G4RuleModelBase>>(((SwitchRuleModel)pluginData.Rule).Branches, comparer)
                : new Dictionary<string, IEnumerable<G4RuleModelBase>>(comparer);

            // Retrieve the rules for FALSE and TRUE branches; defaults to an empty collection if not found.
            var falseRules = branches.Get(key: "FALSE", defaultValue: Enumerable.Empty<G4RuleModelBase>());
            var trueRules = branches.Get(key: "TRUE", defaultValue: Enumerable.Empty<G4RuleModelBase>());

            // Return the positive (TRUE) and negative (FALSE) actions as arrays.
            return (
                PositiveActions: [.. trueRules],
                NegativeActions: [.. falseRules]
            );
        }
    }
}
