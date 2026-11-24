using G4.Attributes;
using G4.Cache;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.InputActions;
using G4.WebDriver.Remote.Interactions;

using System;
using System.Linq;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeInputActions)}.json")]
    public class InvokeInputActions(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The plugin type every child rule must belong to. Only plugins of this type add to the shared sequence;
        // any other rule acts on the driver before the sequence is sent.
        private const string InputActionType = "InputAction";

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Take over the child rules, so the engine does not invoke them a second time after this plugin returns.
            pluginData.Rule.SetInvokeRules(invoke: false);

            // Stamp this rule's iteration on its child rules and link them to its live reference, so a container
            // inside a loop gives every child a unique runtime identifier on every iteration.
            pluginData.Rule.SetIterationContext(iteration: pluginData.Rule.Iteration);

            // Read the child rules once; a container without rules has an empty list here.
            var rules = (pluginData.Rule.Rules ?? []).ToArray();

            // Assert the children before anything is built, so a misplaced rule never reaches the driver.
            AssertRules(rules);

            // Create the one sequence every child adds to; it is sent once, after the last child.
            var sequence = new ActionSequence(driver: WebDriver);

            try
            {
                // Hand the sequence, and the element this container runs on, to every child rule.
                foreach (var rule in rules)
                {
                    rule.Context[RuleProperties.WebElement] = pluginData.Element;
                    rule.Context[RuleProperties.HtmlNode] = pluginData.HtmlNode;
                    rule.Context[InputActionBase.SequenceKey] = sequence;
                }

                // Run the children through the engine, which resolves their macros and reports each one. A child
                // only adds its action to the sequence; nothing is sent to the driver yet.
                Invoker.Invoke(rules);

                // Stop before sending when a child did not add its action; a partial sequence can leave a key
                // or a button pressed.
                AssertHandoff(rules);

                // Send every action in one request, which is what keeps their order and timing.
                SendSequence(sequence);
            }
            finally
            {
                // Take the sequence back from every child, so no rule holds a sequence that was already sent.
                foreach (var rule in rules)
                {
                    rule.Context.Remove(key: InputActionBase.SequenceKey);
                }
            }

            // Return a new plugin response indicating successful execution.
            return this.NewPluginResponse();
        }

        // Asserts that every child rule gave its handoff back, which a child does only after it added its action.
        // A child that failed, or that the engine skipped, still holds the entry and stops the container here.
        private static void AssertHandoff(G4RuleModelBase[] rules)
        {
            // Collect the children that still hold the sequence, in the order they appear in the container.
            var failedRules = rules
                .Where(rule => rule.Context.ContainsKey(key: InputActionBase.SequenceKey))
                .Select(rule => rule.PluginName)
                .ToArray();

            // Leave without an error when every child gave its handoff back, so the sequence is sent.
            if (failedRules.Length == 0)
            {
                return;
            }

            // Name the failed children; each one also reports its own error on its own rule.
            var names = string.Join(separator: ", ", value: failedRules);
            var message = $"No input action was sent, because these rules did not add their action: {names}.";
            throw new InvalidOperationException(message);
        }

        // Asserts that the container has child rules and that every one of them is an input action plugin.
        // Runs before the sequence is created, so a failure here sends nothing and runs no child.
        private static void AssertRules(G4RuleModelBase[] rules)
        {
            // Reject an empty container, because sending an empty sequence does nothing and hides a broken flow.
            if (rules.Length == 0)
            {
                var message = $"'{nameof(InvokeInputActions)}' has no rules. Add at least one input action.";
                throw new InvalidOperationException(message);
            }

            // Collect the children that are not input actions; the lookup accepts keys, aliases and qualified names.
            var cache = CacheManager.Instance;
            var foreignRules = rules
                .Where(rule => !TestInputAction(cache, rule))
                .Select(rule => rule.PluginName)
                .ToArray();

            // Leave without an error when every child is an input action, so the children may run.
            if (foreignRules.Length == 0)
            {
                return;
            }

            // Name the misplaced rules, so the flow author knows which ones to move out of the container.
            var names = string.Join(separator: ", ", value: foreignRules);
            var foreignMessage = $"'{nameof(InvokeInputActions)}' runs only input actions. " +
                $"Move these rules out of it: {names}.";
            throw new InvalidOperationException(foreignMessage);
        }

        // Releases the input state of the driver after a failed send. A failure of the release itself is ignored,
        // because the rule already fails with the error of the send, which is the one the flow author needs.
        private static void ReleaseInputState(ActionSequence sequence)
        {
            try
            {
                // Clearing the sequence asks the driver to release every pressed key and button.
                sequence.ClearActions();
            }
            catch (Exception)
            {
                // Nothing to do: the driver that rejected the sequence may also reject the release.
            }
        }

        // Sends the sequence to the driver in one request. When the driver rejects it, the input state is released
        // so no key or button stays pressed, and the original failure is what the rule reports.
        private static void SendSequence(ActionSequence sequence)
        {
            try
            {
                // Perform every action the children added, as one request.
                sequence.Invoke();
            }
            catch (Exception)
            {
                // Release the keys and buttons the driver may hold after a sequence that stopped half way.
                ReleaseInputState(sequence);
                throw;
            }
        }

        // Tests whether a rule names an input action plugin. The lookup reads the plugin cache only, and accepts
        // the key, an alias or the qualified name of the plugin.
        private static bool TestInputAction(CacheManager cache, G4RuleModelBase rule)
        {
            // Search the input action bucket alone, so an ordinary action with the same name is not accepted.
            return cache.TryResolvePlugin(pluginType: InputActionType, reference: rule.PluginName, model: out _);
        }
    }
}
