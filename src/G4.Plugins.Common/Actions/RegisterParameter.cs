using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Remote;

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(RegisterParameter)}.json")]
    public class RegisterParameter(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define constants for the plugin parameters.
        private const string Name = "Name";
        private const string Value = "Value";
        private const string Scope = "Scope";
        private const string Environment = "Environment";

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract arguments, action, and element information from the plugin data.
            PluginResponseModel responseModel;
            var arguments = pluginData.Parameters;
            var element = pluginData.Element;
            var isValue = arguments.ContainsKey(Value);

            // Get the parameter name, value, and scope from the formatted arguments or use defaults.
            var name = arguments.Get(Name, defaultValue: pluginData.Rule.Argument);
            var value = arguments.Get(Value, defaultValue: string.Empty);
            var scope = arguments.Get(Scope, defaultValue: "Session");
            var environment = arguments.Get(Environment, "SystemParameters");

            try
            {
                // This code block is executed when isValue is false.
                if (!isValue)
                {
                    // Get the WebElement to interact with based on the action's settings.
                    var onElement = this.GetElement(pluginData.Rule, element);

                    // If the WebElement is not found or the value is not empty, use the provided value.
                    // Otherwise, try to obtain the value from the WebElement using GetTextOrAttribute.
                    value = onElement == null || !string.IsNullOrEmpty(value)
                        ? value
                        : GetTextOrAttribute(pluginData.Rule, element: onElement);
                }
            }
            catch (Exception e) when (e is NoSuchElementException || e is WebDriverTimeoutException || e is StaleElementReferenceException)
            {
                // Handle exceptions related to WebElement not found or timeouts by using the OnElement value.
                value = pluginData.Rule.OnElement;
            }
            catch (Exception)
            {
                // Handle other exceptions and rethrow them.
                if (!string.IsNullOrEmpty(pluginData.Rule.Argument))
                {
                    Invoker.Context.SessionParameters[pluginData.Rule.Argument] = string.Empty;
                }
                throw;
            }
            finally
            {
                // Using Regex to match the value based on the regular expression defined in the 'action' object
                value = Regex.Match(value, pluginData.Rule.RegularExpression).Value.ConvertToBase64();

                // Creating a new scope action with the specified name, value, and scope
                var scopeRule = NewScopeAction(pluginData, name, value, scope, environment);

                // Setting the parent reference of the scope action to the reference of the plugin data rule
                scopeRule.Reference.ParentReference = pluginData.Rule.Reference;

                // Creating a new plugin for the scope action using the SetParameterPluginFactory
                var scopeActionPlugin = Invoker
                    .PluginFactoryAdapter
                    .SetParameterPluginFactory
                    .NewPlugin(driver: WebDriver, invoker: Invoker, rule: scopeRule);

                // Sending the plugin data converted to a data model using the created scope action plugin
                responseModel = scopeActionPlugin.Send(pluginData: scopeRule.ConvertToDataModel());
            }

            // Return new plugin response.
            return responseModel == null
                ? this.NewPluginResponse()
                : this.NewPluginResponse(responseModel);
        }

        // Get the text content or attribute value of a WebElement.
        private static string GetTextOrAttribute(G4RuleModelBase rule, IWebElement element)
        {
            // Check if the WebElement is null.
            if (element == null)
            {
                return string.Empty;
            }

            // If OnAttribute is not specified, return the element's text content.
            if (string.IsNullOrEmpty(rule.OnAttribute))
            {
                return element.Text;
            }

            // Otherwise, return the value of the specified attribute.
            return element.GetAttribute(rule.OnAttribute);
        }

        // Creates a new scope action rule based on the provided data model, name, value, scope, and environment.
        private static ActionRuleModel NewScopeAction(
            PluginDataModel pluginData,
            string name,
            string value,
            string scope,
            string environment)
        {
            // Clear existing parameters and set new parameters for the data model.
            pluginData.Parameters[Name] = null;
            pluginData.Parameters[Scope] = null;
            pluginData.Parameters[Value] = value;
            pluginData.Parameters[Environment] = environment;

            // Filter out parameters with null values and create argument string.
            var parameters = pluginData
                .Parameters
                .Where(i => i.Value != null)
                .Select(i => $"--{i.Key}:{i.Value}");
            var argument = "{{$ " + string.Join(' ', parameters) + "}}";

            // Create a new action rule model.
            var rule = new ActionRuleModel
            {
                PluginName = scope,
                Argument = argument,
                OnElement = name
            };

            // Set the reference for the action rule.
            rule.Reference = rule.NewReference(pluginData.Rule.Reference.JobReference);
            rule.Reference.ParentReference = pluginData.Rule.Reference;

            // Return the newly created scope action rule.
            return rule;
        }
    }
}
