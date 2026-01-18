using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.NewRandomNumber;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("NewRandomNumber")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) " +
        "developer, I want a plugin within the G4™ framework that enables me to generate random numbers effortlessly, " +
        "So that I can introduce randomness into my automation workflows and simulate diverse scenarios.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin must be easily accessible within the G4™ platform's ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Random Number Generation: The plugin must offer the functionality to generate random numbers of various types (byte, double, float, integer, and long), ensuring versatility for different automation scenarios.")]
    [AcceptanceCriteria(criteria: "Parameter Customization: Users must have the flexibility to customize parameters such as the type of random number to generate, minimum and maximum values, and the option to specify a seed for reproducible randomness.")]
    [AcceptanceCriteria(criteria: "Output Consistency: The plugin must consistently generate random numbers within the specified range and type, ensuring reliability and predictability in automation outcomes.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms must be implemented to handle invalid inputs, unexpected scenarios, and potential runtime errors, ensuring the stability and resilience of automation workflows.")]
    #endregion
    public class NewRandomNumberTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when invoked without parameters, generates a " +
            "random integer within the range of int.MinValue and int.MaxValue.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Invocation Testing: Upon invocation without parameters, the plugin generates a random integer.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random integer falls within the range of int.MinValue and int.MaxValue.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations without parameters produce different random integers.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random integer undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$NewRandomNumber}}", "-2147483648", "2147483647")]
        [DataRow("{{$rndnum}}", "-2147483648", "2147483647")]
        [DataRow("{{$New-RandomNumber}}", "-2147483648", "2147483647")]
        #endregion
        public void T0001A(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with specific minimum and maximum " +
            "values, generates a random integer within the specified range.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MinValue' and 'MaxValue' parameters set to 100 and 1000 respectively, the plugin generates a random integer.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random integer is validated to fall within the range of 100 and 1000.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random integers.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random integer undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MinValue:100 --MaxValue:1000}}", "100", "1000")]
        #endregion
        public void T0001B(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with a specific minimum value, " +
            "generates a random integer greater than or equal to the specified minimum and less than " +
            "or equal to the maximum value of the integer type.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MinValue' parameter set to 100, the plugin generates a random integer.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random integer is validated to be greater than or equal to 100 and less than or equal to the maximum value of the integer type.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random integers.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random integer undergoes thorough validation to ensure randomness and uniform distribution.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MinValue:100}}", "100", "2147483647")]
        #endregion
        public void T0001C(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with a specific maximum value, " +
            "generates a random integer greater than or equal to the minimum value of the integer " +
            "type and less than or equal to the specified maximum.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MaxValue' parameter set to 1000, the plugin generates a random integer.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random integer is validated to be greater than or equal to the minimum value of the integer type and less than or equal to 1000.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random integers.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random integer undergoes thorough validation to ensure randomness and uniform distribution.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MaxValue:1000}}", "-2147483648", "1000")]
        #endregion
        public void T0001D(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured to generate a random long integer, " +
            "produces a random integer within the range of long.MinValue and long.MaxValue.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'NumberType' parameter set to 'Long', the plugin generates a random long integer.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random long integer is validated to fall within the range of long.MinValue and long.MaxValue.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random long integers.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random long integer undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --NumberType:Long}}", "-9223372036854775808", "9223372036854775807")]
        #endregion
        public void T0001E(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with specific minimum and maximum " +
            "values and set to generate a random long integer, produces a random integer within the " +
            "range of -2147483649 and 2147483648.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MinValue' parameter set to -2147483649, 'MaxValue' parameter set to 2147483648, and 'NumberType' parameter set to 'Long', the plugin generates a random long integer.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random long integer is validated to fall within the range of -2147483649 and 2147483648.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random long integers.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random long integer undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MinValue:-2147483649 --MaxValue:2147483648 --NumberType:Long}}", "-2147483649", "2147483648")]
        #endregion
        public void T0001F(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with a specific minimum value " +
            "and set to generate a random long integer, produces a random integer greater than or " +
            "equal to the specified minimum and within the range of long.MinValue and long.MaxValue.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MinValue' parameter set to 100 and 'NumberType' parameter set to 'Long', the plugin generates a random long integer.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random long integer is validated to be greater than or equal to 100 and fall within the range of long.MinValue and long.MaxValue.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random long integers.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random long integer undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MinValue:100 --NumberType:Long}}", "100", "9223372036854775807")]
        #endregion
        public void T0001G(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with a specific maximum value " +
            "and set to generate a random long integer, produces a random integer less than or equal " +
            "to the specified maximum and within the range of long.MinValue and long.MaxValue.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MaxValue' parameter set to 1000 and 'NumberType' parameter set to 'Long', the plugin generates a random long integer.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random long integer is validated to be less than or equal to 1000 and fall within the range of long.MinValue and long.MaxValue.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random long integers.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random long integer undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MaxValue:1000 --NumberType:Long}}", "-9223372036854775808", "1000")]
        #endregion
        public void T0001H(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured to generate a random byte, " +
            "produces a random integer within the range of byte.MinValue and byte.MaxValue.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'NumberType' parameter set to 'Byte', the plugin generates a random byte.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random byte is validated to fall within the range of byte.MinValue and byte.MaxValue.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random bytes.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random byte undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --NumberType:Byte}}", "0", "255")]
        #endregion
        public void T0001I(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with specific minimum and maximum " +
            "values and set to generate a random byte, produces a random integer greater than or equal " +
            "to the specified minimum and less than or equal to the specified maximum.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MinValue' parameter set to 100, 'MaxValue' parameter set to 150, and 'NumberType' parameter set to 'Byte', the plugin generates a random byte.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random byte is validated to be greater than or equal to 100 and less than or equal to 150.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random bytes.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random byte undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MinValue:100 --MaxValue:150 --NumberType:Byte}}", "100", "150")]
        #endregion
        public void T0001J(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with a specific minimum value " +
            "and set to generate a random byte, produces a random integer greater than or equal to " +
            "the specified minimum and within the range of byte.MinValue and byte.MaxValue.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MinValue' parameter set to 100 and 'NumberType' parameter set to 'Byte', the plugin generates a random byte.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random byte is validated to be greater than or equal to 100 and fall within the range of byte.MinValue and byte.MaxValue.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random bytes.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random byte undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MinValue:100 --NumberType:Byte}}", "100", "255")]
        #endregion
        public void T0001K(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured with a specific maximum value " +
            "and set to generate a random byte, produces a random integer less than or equal to " +
            "the specified maximum and within the range of byte.MinValue and byte.MaxValue.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'MaxValue' parameter set to 150 and 'NumberType' parameter set to 'Byte', the plugin generates a random byte.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random byte is validated to be less than or equal to 150 and fall within the range of byte.MinValue and byte.MaxValue.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random bytes.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random byte undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --MaxValue:150 --NumberType:Byte}}", "0", "150")]
        #endregion
        public void T0001L(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured to generate a random float, " +
            "produces a random floating-point number within the range of 0.0 and 1.0.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'NumberType' parameter set to 'Float', the plugin generates a random float.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random float is validated to fall within the range of 0.0 and 1.0.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random floats.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random float undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --NumberType:Float}}", "0.0", "1.0")]
        #endregion
        public void T0001M(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the NewRandomNumber plugin, when configured to generate a random double, " +
            "produces a random floating-point number within the range of 0.0 and 1.0.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewRandomNumber plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When configured with 'NumberType' parameter set to 'Double', the plugin generates a random double.")]
        [AcceptanceCriteria(criteria: "Output Range Verification: The generated random double is validated to fall within the range of 0.0 and 1.0.")]
        [AcceptanceCriteria(criteria: "Reproducibility Check: Subsequent invocations with the same parameter values produce different random doubles.")]
        [AcceptanceCriteria(criteria: "Validation Process: The generated random double undergoes thorough validation to ensure randomness and uniform distribution within the specified range.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-RandomNumber --NumberType:Double}}", "0.0", "1.0")]
        #endregion
        public void T0001N(string macro, string minValue, string maxValue)
        {
            // Create an automation environment instance.
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "macro", value: macro)
                .AddTestParameter(key: "maxValue", value: maxValue)
                .AddTestParameter(key: "minValue", value: minValue);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Macros.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
