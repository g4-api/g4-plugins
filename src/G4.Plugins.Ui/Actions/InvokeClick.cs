using G4.Attributes;
using G4.Exceptions;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeClick)}.json")]
    public class InvokeClick(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extracting action and element from pluginData
            var action = pluginData.Rule;
            var element = pluginData.Element;

            // Converting action arguments to dictionary
            var arguments = CliFactory.ConvertToDictionary(action?.Argument);

            // Creating a sequence of actions
            var actions = new ActionSequence(WebDriver);

            // Checking if the element is absent
            if (action.AssertHasNoElement(element))
            {
                // If so, perform a click action
                actions.AddClick().Invoke();

                // Return a new plugin response
                return this.NewPluginResponse();
            }

            // Retrieving the element based on action
            var onElement = this.GetElement(action, element);

            // Checking if the arguments contain 'Condition'
            if (arguments.ContainsKey("Condition"))
            {
                // If 'Condition' is present, invoke conditional action
                InvokeConditionalClick(plugin: this, pluginData, onElement, arguments);

                // Return a new plugin response
                return this.NewPluginResponse();
            }

            // Try to move to the element and then click on it
            onElement.MoveToElement().Click();

            // Return a new plugin response
            return this.NewPluginResponse();
        }

        #region *** Methods: Private ***
        // Invokes a conditional click on the specified element, checking a condition until it is met or a timeout occurs.
        private static void InvokeConditionalClick(
            PluginBase plugin,
            PluginDataModel pluginData,
            IWebElement element,
            IDictionary<string, string> arguments)
        {
            // Get the timeout and polling interval values.
            var polling = GetPolling(arguments);
            var timeout = GetTimeout(plugin.Automation, arguments);
            var condition = arguments.Get(key: "Condition", string.Empty);

            if(string.IsNullOrEmpty(condition))
            {
                const string error400 = "The 'Condition' argument is required for conditional click actions.";
                throw new MissingMandatoryParameterException(message: error400);
            }

            // Create the assert rule based on the condition.
            var assertRule = NewAssertionAction(pluginData.Rule);

            // Initial click to trigger the condition check.
            element.MoveToElement().Click();

            // Perform the initial assertion and get the evaluation result.
            var assertPluginData = new PluginDataModel(assertRule, pluginData.Element);
            var response = plugin.Assert(assertPluginData, addExtractions: false);
            var actual = GetEvaluation(response);

            // Return if the condition is already met.
            if (actual)
            {
                return;
            }

            // Loop until the timeout is reached or the condition is met.
            while (DateTime.UtcNow < timeout)
            {
                // Perform assertion and get the evaluation result.
                response = plugin.Assert(assertPluginData, addExtractions: false);
                actual = GetEvaluation(response);

                if (actual)
                {
                    break;
                }

                // Invoke the specified handler method for the condition.
                var handler = ClickHandler.FindHandlerMethod(condition);
                var instance = handler?.IsStatic == true ? null : plugin;

                handler?.Invoke(instance, [plugin.WebDriver]);

                // Pause for polling interval.
                Thread.Sleep(polling);

                // Click the element to trigger another iteration.
                element.MoveToElement().Click();
            }
        }

        // Retrieves the evaluation result from the plugin response model.
        private static bool GetEvaluation(PluginResponseModel model)
        {
            // Check if the evaluation result exists in the response entity.
            var isEvaluation = model
                .Entity
                .TryGetValue(AssertionProperties.Evaluation, out object evaluation);

            // Return true if evaluation exists and is true, otherwise return false.
            return isEvaluation && (bool)evaluation;
        }

        // Retrieves the polling interval from the provided arguments or returns a default value.
        private static TimeSpan GetPolling(IDictionary<string, string> arguments)
        {
            // Check if the 'Polling' argument is specified in the action.
            var isPolling = arguments.TryGetValue("Polling", out var pollingOut);

            // Define the default polling interval value.
            var defaultPolling = TimeSpan.FromMilliseconds(1500);

            // Return the specified polling interval if available, otherwise use the default value.
            return isPolling
                ? pollingOut.ConvertToTimeSpan(defaultPolling)
                : defaultPolling;
        }

        // Retrieves the timeout interval from the provided arguments or returns a default value from the automation settings.
        private static DateTime GetTimeout(G4AutomationModel automation, IDictionary<string, string> arguments)
        {
            // Check if the 'Timeout' argument is specified in the action.
            var isTimeout = arguments.TryGetValue("Timeout", out var timeoutOut);

            // Get the default timeout value from the automation configuration.
            var defaultTimeout = TimeSpan.FromMilliseconds(automation.Settings.AutomationSettings.LoadTimeout);

            // Return the specified timeout if available, otherwise use the default timeout.
            var timeout = isTimeout
                ? timeoutOut.ConvertToTimeSpan(defaultTimeout)
                : defaultTimeout;

            // Return the calculated timeout value based on the current time.
            return DateTime.UtcNow.Add(timeout);
        }

        // Creates a new assertion action based on the provided condition and rule model.
        private static ActionRuleModel NewAssertionAction(G4RuleModelBase rule)
        {
            // Create a new ActionRuleModel based on the original action with modified argument.
            var assetAction = new ActionRuleModel()
            {
                PluginName = "Assert",
                Argument = rule.Argument,
                OnAttribute = rule.OnAttribute,
                Capabilities = rule.Capabilities,
                Locator = rule.Locator,
                OnElement = rule.OnElement,
                RegularExpression = rule.RegularExpression,
                Iteration = rule.Iteration
            };

            // Set the reference for the new assertion action.
            assetAction.Reference = assetAction.NewReference(rule.Reference.JobReference, forceId: true);

            // Set the parent reference for the new assertion action.
            assetAction.Reference.ParentReference = rule.Reference;

            // return the new assertion action.
            return assetAction;
        }
        #endregion

        #region *** Nested Types     ***
        /// <summary>
        /// Contains methods for handling different click scenarios.
        /// </summary>
        private static class ClickHandler
        {
            /// <summary>
            /// Gets the method to handle the specified click scenario.
            /// </summary>
            /// <param name="handler">The handler name to look for.</param>
            /// <returns>The method for handling the specified click scenario, or null if not found.</returns>
            public static MethodInfo FindHandlerMethod(string handler)
            {
                // Define the binding flags to search for methods.
                const BindingFlags binding = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

                // Get all methods in the ClickHandler class with the DescriptionAttribute.
                var methods = typeof(ClickHandler)
                    .GetMethods(binding)
                    .Where(i => i.GetCustomAttribute<DescriptionAttribute>() != null);

                // Return null if no methods are found.
                if (!methods.Any())
                {
                    return default;
                }

                // Iterate through methods and find one matching the specified handler.
                foreach (var method in methods)
                {
                    // Get all handlers for the method.
                    var handlers = method
                        .GetCustomAttributes<ClickHandlerAttribute>()
                        .Select(i => i.Handler.Trim());

                    // Return the method if the handler is found.
                    if (handlers.Contains(handler, StringComparer.OrdinalIgnoreCase))
                    {
                        return method;
                    }
                }

                // Return null if no matching method is found.
                return default;
            }

            // Handles the click scenario to close an alert if it exists.
            [ClickHandler("AlertNotExists")]
            [ClickHandler("HasNoAlert")]
            [ClickHandler("NoAlert")]
            public static void CloseAlert(IWebDriver driver)
            {
                // Check if an alert is present.
                var isAlert = driver.ConfirmAlert();

                // If an alert is present, dismiss it.
                if (isAlert)
                {
                    driver.SwitchTo().Alert().Close();
                }
            }
        }

        /// <summary>
        /// Specifies a method that handles a specific click scenario.
        /// </summary>
        /// <param name="handler">The name of the handler for the click scenario.</param>
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        private sealed class ClickHandlerAttribute(string handler) : Attribute
        {
            /// <summary>
            /// Gets the name of the handler for the click scenario.
            /// </summary>
            public string Handler { get; } = handler;
        }
        #endregion
    }
}
