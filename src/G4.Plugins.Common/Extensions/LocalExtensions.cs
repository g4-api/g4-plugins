using G4.Exceptions;
using G4.Models;
using G4.Plugins;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.Extensions
{
    /// <summary>
    /// Provides extension methods and utilities for the framework.
    /// </summary>
    internal static class LocalExtensions
    {
        /// <summary>
        /// Confirms a boolean assertion based on the provided PluginResponseModel.
        /// </summary>
        /// <param name="response">The PluginResponseModel containing the assertion data.</param>
        /// <returns>A tuple indicating whether it's a boolean assertion and the evaluation value.</returns>
        public static (bool IsBoolean, bool Evaluation) ConfirmBooleanAssertion(this PluginResponseModel response)
        {
            // Get the evaluation value from the response entity.
            var evaluationValue = response.Entity.Get(key: AssertionProperties.Evaluation, defaultValue: default(bool));

            // Get the actual value from the response entity.
            var actual = response.Entity.Get(key: AssertionProperties.Actual, defaultValue: default(bool));

            // Use the evaluation value unless it's different from the actual value.
            var evaluation = evaluationValue != actual ? actual : evaluationValue;

            // Retrieve the operator and expected values from the response entity.
            var @operator = $"{response.Entity.Get(key: AssertionProperties.Operator, defaultValue: "Boolean")}";

            // Determine if the assertion is a boolean assertion based on the operator and expected values.
            var isBoolean = @operator.Equals("Boolean", StringComparison.OrdinalIgnoreCase);

            // Return a tuple with information about whether it's a boolean assertion and the evaluation value.
            return (isBoolean, isBoolean && evaluation);
        }

        /// <summary>
        /// Extension method to format assertion arguments for a plugin.
        /// </summary>
        /// <param name="plugin">The plugin for which the assertion arguments are formatted.</param>
        /// <param name="cli">The Command Line Interface (CLI) string containing assertion arguments.</param>
        /// <returns>A dictionary containing formatted assertion arguments.</returns>
        public static IDictionary<string, string> FormatAssertionArguments(this PluginBase plugin, string cli)
        {
            // Convert CLI string to a dictionary of arguments.
            var args = plugin.CliFactory.ConvertToDictionary(cli);

            // Set default values for assertion properties if not provided.
            args[AssertionProperties.Condition] = args.Get(key: AssertionProperties.Condition, defaultValue: string.Empty);
            args[AssertionProperties.Expected] = args.Get(key: AssertionProperties.Expected, defaultValue: string.Empty);
            args[AssertionProperties.Operator] = args.Get(key: AssertionProperties.Operator, defaultValue: "Boolean");

            // Return the formatted assertion arguments.
            return args;
        }

        /// <summary>
        /// Invokes an assertion for a given <see cref="PluginBase"/> instance and <see cref="PluginDataModel"/>.
        /// </summary>
        /// <param name="plugin">The <see cref="PluginBase"/> instance to invoke the assertion on.</param>
        /// <param name="pluginData">The <see cref="PluginDataModel"/> containing the assertion details.</param>
        /// <returns>The <see cref="PluginResponseModel"/> representing the result of the assertion.</returns>
        public static PluginResponseModel InvokeAssertion(this PluginBase plugin, PluginDataModel pluginData)
        {
            // Extract the action rule and element from the provided pluginData.
            var action = pluginData.Rule;
            var element = pluginData.Element;

            // Ensure the action's context is initialized with the assertion type.
            action.Context ??= new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            action.Context["Type"] = "Assertion";

            // Invoke the plugin's Get method to perform the assertion.
            var actual = plugin.Send(new PluginDataModel(action, element));

            // If the assertion result is null or empty, throw an exception.
            if (actual?.Entity == null || actual.Entity.Count == 0)
            {
                const string error404 = "No assertions found. " +
                    "The method 'Get-Assertion' returned either NotFound or NotImplemented.";
                throw new NoSuchAssertionMethodException(error404);
            }

            // Return the actual assertion result.
            return actual;
        }

        /// <summary>
        /// Creates a new operator rule based on the provided rule and arguments.
        /// </summary>
        /// <param name="rule">The original <see cref="G4RuleModelBase"/> from which the new operator rule will be derived.</param>
        /// <param name="arguments">A dictionary containing key-value pairs that provide additional data required to create the new operator rule.</param>
        /// <returns>A new instance of <see cref="G4RuleModelBase"/> representing the operator rule configured with the provided arguments.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="arguments"/> dictionary does not contain a valid "Actual" key or when its value is null.</exception>
        public static G4RuleModelBase NewOperatorRule(this G4RuleModelBase rule, IDictionary<string, object> arguments)
        {
            // Create a new entity dictionary based on the provided arguments with case-insensitive keys.
            var entity = new Dictionary<string, object>(arguments, StringComparer.OrdinalIgnoreCase);

            // Check if the "Actual" key exists and its value is not null.
            var isKey = entity.ContainsKey("Actual");
            var isValue = isKey && entity["Actual"] != null;

            if (!isValue)
            {
                // Throw an ArgumentException indicating that the "Actual" key is missing or its value is null.
                throw new ArgumentException(
                    message: "The 'Actual' argument is required and cannot be null.",
                    paramName: nameof(arguments));
            }

            // Extract the left-hand value from the "Actual" key, ensuring it is converted to a string.
            var leftHand = $"{entity["Actual"]}";

            // Get the assert operator and right-hand value from the action.
            var (assertOperator, rightHand) = rule.GetOperator();

            // Create a new ActionRuleModel instance representing the operator action.
            var operatorRule = new ActionRuleModel
            {
                // Construct the argument string using the extracted left-hand and right-hand values.
                Argument = "{{$ --LeftHand:" + leftHand + " --RightHand:" + rightHand + "}}",

                // Inherit capabilities from the original rule.
                Capabilities = rule.Capabilities,

                // Inherit context from the original rule.
                Context = rule.Context,

                // Inherit the iteration count from the original rule.
                Iteration = rule.Iteration,

                // Set the plugin name to the retrieved assert operator.
                PluginName = assertOperator,

                // Inherit any child rules from the original rule.
                Rules = rule.Rules
            };

            // Ensure the operator rule's context is initialized. If it's null, create a new dictionary with case-insensitive keys.
            operatorRule.Context ??= new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            // Set the type of the operator rule in its context to indicate it's an operator.
            operatorRule.Context["Type"] = "Operator";

            // Create a new reference for the operator rule based on the job reference of the original rule.
            operatorRule.Reference = operatorRule.NewReference(rule.Reference.JobReference);

            // Set the parent reference of the operator rule's reference to the reference of the original rule.
            operatorRule.Reference.ParentReference = rule.Reference;

            // Return the newly created operator rule.
            return operatorRule;
        }

        /// <summary>
        /// Creates a new assertion action based on the provided rule and arguments.
        /// </summary>
        /// <param name="rule">The rule associated with the assertion action.</param>
        /// <param name="arguments">The arguments for constructing the assertion action.</param>
        /// <returns>A new assertion action represented as a <see cref="G4RuleModelBase"/>.</returns>
        public static G4RuleModelBase NewAssertionRule(this G4RuleModelBase rule, IDictionary<string, string> arguments)
        {
            // Extract non-empty and non-"Until" arguments for constructing the CLI.
            var cliArguments = arguments
                .Where(i => !string.IsNullOrEmpty(i.Value) && !i.Key.Equals(AssertionProperties.Condition))
                .Select(i => $"--{i.Key}:{i.Value}");

            // Construct the CLI string from the selected arguments.
            var cli = "{{$ " + string.Join(' ', cliArguments) + "}}";

            // Get the "Until" condition from the arguments.
            var condition = arguments[AssertionProperties.Condition];

            // Check if the "Until" condition is empty, log an error, and throw an exception.
            if (string.IsNullOrEmpty(arguments[AssertionProperties.Condition]))
            {
                const string errorMessage =
                    "The 'Condition' for 'Get-AssertionAction' method '{condition}' with arguments '{cli}' is " +
                    "either NotFound, NotImplemented, or has an InvalidName.";

                // Throw a PluginNotFoundException with the error message.
                throw new PluginNotFoundException(errorMessage.Replace("{condition}", condition).Replace("{cli}", cli));
            }

            // Create a new ActionRuleModel object for the assertion action.
            var assertionRule = new ActionRuleModel
            {
                PluginName = arguments[AssertionProperties.Condition],
                Argument = cli,
                Iteration = rule.Iteration,
                OnAttribute = rule.OnAttribute,
                OnElement = rule.OnElement,
                Locator = rule.Locator,
                RegularExpression = rule.RegularExpression
            };

            // Create a new reference for the assertion rule based on the job reference of the original rule.
            assertionRule.Reference = assertionRule.NewReference(rule.Reference.JobReference);

            // Set the parent reference of the assertion rule's reference to the reference of the original rule.
            assertionRule.Reference.ParentReference = rule.Reference;

            // Return the assertion rule.
            return assertionRule;
        }
    }
}
