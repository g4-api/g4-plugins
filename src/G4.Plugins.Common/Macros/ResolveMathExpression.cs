using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace G4.Plugins.Common.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Macros.Manifests.{nameof(ResolveMathExpression)}.json")]
    public class ResolveMathExpression(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            try
            {
                // Extracting parameters from plugin data
                var xParameter = pluginData.Parameters.Get(key: "X", defaultValue: "0");
                var yParameter = pluginData.Parameters.Get(key: "Y", defaultValue: "0");
                var roundParameter = pluginData.Parameters.Get(key: "Round", defaultValue: "-1");
                var operation = pluginData.Parameters.Get(key: "Operation", defaultValue: "+");
                var isDesc = pluginData.Parameters.ContainsKey("Desc");
                var isAsc = pluginData.Parameters.ContainsKey("Asc");
                var isAbs = pluginData.Parameters.ContainsKey("Abs");

                // Parsing parameters
                _ = double.TryParse(xParameter, out double xParameterOut);
                _ = double.TryParse(yParameter, out double yParameterOut);
                _ = int.TryParse(roundParameter, out int roundParameterOut);

                // Creating an array of input values
                var input = new[] { xParameterOut, yParameterOut };

                // Sorting input array based on Asc and Desc flags
                if (isDesc && !isAsc)
                {
                    Array.Sort(input, (a, b) => -a.CompareTo(b));
                }
                else if (isAsc && !isDesc)
                {
                    Array.Sort(input);
                }

                // Finding the method for the specified operation
                var method = FindOperationMethod(operation);

                // Handling case when method is not found
                if (method == default)
                {
                    return this.NewMacroResponse("Err");
                }

                // Creating NewStruct object with input values
                var (X, Y) = (input[0], input[1]);

                // Determining whether the method is static or instance
                var instance = method.IsStatic ? null : this;

                // Invoking the method with appropriate parameters
                var value = (double)method.Invoke(obj: instance, parameters: [X, Y]);

                // Rounding the value if specified
                if (roundParameterOut >= 0)
                {
                    value = Math.Round(value, roundParameterOut);
                }

                // Taking absolute value if specified
                if (isAbs)
                {
                    value = Math.Abs(value);
                }

                // Formatting the macro result
                var macroResult = $"{value}".EndsWith(".00")
                    ? $"{value}".Replace(".00", string.Empty)
                    : $"{value}";

                // Returning the macro response
                return this.NewMacroResponse(macroResult);
            }
            catch
            {
                // Handling exceptions by returning an error response
                return this.NewMacroResponse("Err");
            }
        }

        #region *** Methods: Private ***
        // Finds the method corresponding to a specified mathematical operation.
        [SuppressMessage(
            category: "Major Code Smell",
            checkId: "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields",
            Justification = "Reflection is used internally within the same class for specialized functionality.")]
        private static MethodInfo FindOperationMethod(string operation)
        {
            // StringComparison to perform case-insensitive comparison
            const StringComparison Compare = StringComparison.OrdinalIgnoreCase;

            // Get all static non-public methods of ResolveMathExpression class
            var methods = typeof(ResolveMathExpression)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(method => method.GetCustomAttribute<MathOperationAttribute>() != null);

            // Find the first method with the specified operation name
            return methods.FirstOrDefault(i => i.GetCustomAttribute<MathOperationAttribute>().Operation.Equals(operation, Compare));
        }

        // Performs addition operation on two numbers.
        [MathOperation(operation: "+")]
        private static double Add(double x, double y) => x + y;

        // Performs division operation on two numbers.
        [MathOperation(operation: "/")]
        private static double DivideSlash(double x, double y) => x / y;

        // Performs division operation on two numbers.
        [MathOperation(operation: @"\")]
        private static double DivideBackslash(double x, double y) => x / y;

        // Performs modulus operation on two numbers.
        [MathOperation(operation: "%")]
        private static double Modulus(double x, double y) => x % y;

        // Performs multiplication operation on two numbers.
        [MathOperation(operation: "*")]
        private static double Multiply(double x, double y) => x * y;

        // Raises a number to a power.
        [MathOperation(operation: "^")]
        private static double Power(double x, double y) => Math.Pow(x, y);

        // Performs subtraction operation on two numbers.
        [MathOperation(operation: "-")]
        private static double Subtract(double x, double y) => x - y;
        #endregion

        #region *** Nested Types     ***
        /// <summary>
        /// Attribute to mark methods as math operations.
        /// </summary>
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        private sealed class MathOperationAttribute(string operation) : Attribute
        {
            /// <summary>
            /// Gets the mathematical operation represented by the attributed method.
            /// </summary>
            public string Operation { get; } = operation;
        }
        #endregion
    }
}
