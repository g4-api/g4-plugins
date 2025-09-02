/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.ResolveMathExpression;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    /// <summary>
    /// Test class for testing the behavior of ResolveMathExpression plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("ResolveMathExpression")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that resolves mathematical expressions, So that I can seamlessly " +
        "incorporate dynamic calculations into my automation workflows, enhancing their flexibility and efficiency.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Integration: The plugin seamlessly integrates into the G4™ ecosystem, ensuring easy accessibility and compatibility with existing automation workflows without intricate setup procedures.")]
    [AcceptanceCriteria(criteria: "Mathematical Operation Support: The plugin supports basic arithmetic operations such as addition, subtraction, multiplication, division, and exponentiation, enabling users to perform diverse mathematical calculations within their automation scripts.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully handle invalid inputs, unexpected scenarios, and potential runtime errors, ensuring the stability and resilience of automation workflows.")]
    [AcceptanceCriteria(criteria: "Extensibility: The plugin architecture facilitates easy extension for adding new mathematical operations in the future, allowing for the incorporation of additional functionalities as per user requirements.")]
    #endregion
    public class ResolveMathExpressionTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=2, Y=10, and Operation='-', correctly resolves the mathematical expression " +
            "and returns the expected result (-8).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=2, Y=10, and Operation='-', ensuring accurate processing of the mathematical expression.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (-8) after resolving the mathematical expression.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^-8$", "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:-}}")]
        [DataRow("^-8$", "{{$math --X:2 --Y:10 --Operation:-}}")]
        #endregion
        public void T0001A(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=10, Y=2, and Operation='+', correctly resolves the mathematical expression " +
            "and returns the expected result (12).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=10, Y=2, and Operation='+', ensuring accurate processing of the mathematical expression.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (12) after resolving the mathematical expression.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^12$", "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:+}}")]
        #endregion
        public void T0001B(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=10, Y=2, and Operation='/', correctly resolves the mathematical expression " +
            "and returns the expected result (5).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=10, Y=2, and Operation='/', ensuring accurate processing of the mathematical expression.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (5) after resolving the mathematical expression.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^5$", "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:/}}")]
        [DataRow("^5$", "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:\\}}")]
        #endregion
        public void T0001C(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin gracefully handles invalid operations " +
            "when provided with specific parameters such as X=10, Y=2, and an invalid Operation, " +
            "ensuring it provides informative error messages.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=10, Y=2, and an invalid Operation.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin gracefully handles the invalid operation scenario, providing an informative error message to indicate the unsupported operation.")]
        #endregion
        #region *** Data     ***
        [DataRow("^Err$", "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:INVALID}}")]
        #endregion
        public void T0001D(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=10, Y=3, and Operation='%', correctly resolves the modulus operation and " +
            "returns the expected result (1).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=10, Y=3, and Operation='%'.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (1) after resolving the modulus operation.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^1$", "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:%}}")]
        #endregion
        public void T0001E(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=10, Y=2, and Operation='*', correctly resolves the multiplication operation " +
            "and returns the expected result (20).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=10, Y=2, and Operation='*'.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (20) after resolving the multiplication operation.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^20$", "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:*}}")]
        #endregion
        public void T0001F(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=10, Y=3, Operation='%', and Ascending sorting flag, correctly sorts the input " +
            "numbers in ascending order before resolving the modulus operation and returns the expected " +
            "result (3).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=10, Y=3, Operation='%', and Ascending sorting flag.")]
        [AcceptanceCriteria(criteria: "Input Sorting: The plugin sorts the input numbers (10, 3) in ascending order (3, 10) before resolving the modulus operation.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (3) after resolving the modulus operation on the sorted input.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^3$", "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:% --Asc}}")]
        #endregion
        public void T0001G(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=3, Y=10, Operation='%', and Descending sorting flag, correctly sorts the input " +
            "numbers in descending order before resolving the modulus operation and returns the expected " +
            "result (1).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=3, Y=10, Operation='%', and Descending sorting flag.")]
        [AcceptanceCriteria(criteria: "Input Sorting: The plugin sorts the input numbers (3, 10) in descending order (10, 3) before resolving the modulus operation.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (1) after resolving the modulus operation on the sorted input.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^1$", "{{$Resolve-MathExpression --X:3 --Y:10 --Operation:% --Desc}}")]
        #endregion
        public void T0001H(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=10, Y=2, and Operation='^' (exponentiation), correctly resolves the " +
            "exponentiation operation and returns the expected result (100).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=10, Y=2, and Operation='^' (exponentiation).")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (100) after resolving the exponentiation operation.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^100$", "{{$Resolve-MathExpression --X:10 --Y:2 --Operation:^}}")]
        #endregion
        public void T0001I(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=10, Y=3, Operation='/' (division), and Round=2, correctly resolves the division " +
            "operation, rounds the result to two decimal places, and returns the expected result (3.33).")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=10, Y=3, Operation='/' (division), and Round=2.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result (3.33) after resolving the division operation and rounding the result to two decimal places.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow(@"^\d+\.\d{3,}$", "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/}}")]
        [DataRow(@"^\d+\.\d{2}$", "{{$Resolve-MathExpression --X:10 --Y:3 --Operation:/ --Round:2}}")]
        #endregion
        public void T0001J(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin can correctly resolve mathematical " +
            "expressions to decimal numbers.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with parameters that result in decimal numbers during expression resolution.")]
        [AcceptanceCriteria(criteria: "Decimal Resolution: The plugin correctly resolves the mathematical expression to a decimal number.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected decimal number as the result of the expression resolution.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^9.5$", "{{$Resolve-MathExpression --X:10 --Y:0.5 --Operation:-}}")]
        #endregion
        public void T0001K(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with specific parameters " +
            "such as X=2, Y=10, Operation='-' (subtraction), and Abs flag, correctly resolves the " +
            "subtraction operation and returns the absolute value of the result.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: The plugin is invoked with the specified parameters X=2, Y=10, Operation='-' (subtraction), and Abs flag.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the absolute value of the result after resolving the subtraction operation.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^-8$", "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:-}}")]
        [DataRow("^8$", "{{$Resolve-MathExpression --X:2 --Y:10 --Operation:- --Abs}}")]
        #endregion
        public void T0001L(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the Resolve-MathExpression plugin, when provided with nested expressions " +
            "as parameters, correctly resolves the inner expression first and then uses the result " +
            "to resolve the outer expression.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The Resolve-MathExpression plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Nested Expression Resolution: The plugin correctly resolves nested expressions, resolving the inner expression first and then using the result to resolve the outer expression.")]
        [AcceptanceCriteria(criteria: "Output Verification: The plugin returns the expected result after resolving the nested expressions.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles any potential errors or exceptions gracefully during the test, providing informative error messages if necessary.")]
        #endregion
        #region *** Data     ***
        [DataRow("^3$", "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:1 --Y:1 --Operation:+}} --Y:3 --Operation:^}} --Y:5 --Operation:%}}")]
        [DataRow("^15$", "{{$Resolve-MathExpression --X:{{$Resolve-MathExpression --X:10 --Y:5 --Operation:-}} --Y:3 --Operation:*}}")]
        #endregion
        public void T0001M(string expectedPattern, string macro)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "expectedPattern", value: expectedPattern)
                .AddTestParameter(key: "macro", value: macro);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
