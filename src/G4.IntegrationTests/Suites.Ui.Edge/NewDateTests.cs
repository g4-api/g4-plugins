using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.NewDate;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("NewDate")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) " +
        "developer, I want a plugin within the G4™ framework that enables me to manipulate date and time seamlessly " +
        "in my automation workflows, So that I can automate time-sensitive tasks and streamline processes that " +
        "require precise control over date and time.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Integration: The plugin should seamlessly integrate into the G4™ framework, providing a user-friendly interface for automation engineers to incorporate into their workflows.")]
    [AcceptanceCriteria(criteria: "Date and Time Operations: The plugin should offer a range of operations including adding time, subtracting time, converting to Unix epoch, converting to OLE Automation Date, and extracting specific date parts.")]
    [AcceptanceCriteria(criteria: "Parameter Customization: Users should have the flexibility to customize parameters such as the time to add or subtract, output format, and specific date parts to extract, catering to diverse automation requirements.")]
    [AcceptanceCriteria(criteria: "Output Formatting: The plugin should support customizable output formatting, allowing automation engineers to format date and time according to their preferences or specific system requirements.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms should be implemented to gracefully manage invalid inputs or unexpected scenarios, ensuring smooth execution of automation tasks.")]
    #endregion
    public class NewDateTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the NewDate plugin correctly generates and inputs a new date " +
            "result into the target element, and ensures that the resulting date matches the " +
            "expected pattern.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewDate plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Macro Generation: The plugin accurately generates a new date macro according to the specified format.")]
        [AcceptanceCriteria(criteria: "Input Handling: The plugin correctly inputs the generated new date macro into the target element.")]
        [AcceptanceCriteria(criteria: "Pattern Matching: The plugin ensures that the resulting date matches the expected pattern.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{6}[+-]\d{2}:\d{2}$", "{{$NewDate}}")]
        [DataRow(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{6}[+-]\d{2}:\d{2}$", "{{$Date}}")]
        [DataRow(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{6}[+-]\d{2}:\d{2}$", "{{$date}}")]
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

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the NewDate plugin correctly generates and inputs a new date " +
            "result into the target element with a specific format, and ensures that the " +
            "resulting date matches the expected pattern.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewDate plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Macro Generation: The plugin accurately generates a new date result according to the specified format.")]
        [AcceptanceCriteria(criteria: "Input Handling: The plugin correctly inputs the generated new date result into the target element.")]
        [AcceptanceCriteria(criteria: "Pattern Matching: The plugin ensures that the resulting date matches the expected pattern.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow(@"^\d{4}-\d{2}-\d{2}$", "{{$New-Date --Format:yyyy-MM-dd}}")]
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

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the NewDate plugin correctly generates and inputs a new date " +
            "result into the target element with the format 'yyyy-MM-dd' in UTC, and ensures that the " +
            "resulting date matches the expected pattern.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewDate plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Macro Generation: The plugin accurately generates a new date result with the format 'yyyy-MM-dd' in UTC.")]
        [AcceptanceCriteria(criteria: "Input Handling: The plugin correctly inputs the generated new date result into the target element.")]
        [AcceptanceCriteria(criteria: "Pattern Matching: The plugin ensures that the resulting date matches the expected pattern.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow(@"^\d{4}-\d{2}-\d{2}$", "{{$New-Date --Format:yyyy-MM-dd --Utc}}")]
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

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the NewDate plugin correctly generates and inputs a new date " +
            "result into the target element using the Unix epoch format, and ensures that the " +
            "resulting date matches the expected pattern.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewDate plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Macro Generation: The plugin accurately generates a new date result using the Unix epoch format.")]
        [AcceptanceCriteria(criteria: "Input Handling: The plugin correctly inputs the generated new date result into the target element.")]
        [AcceptanceCriteria(criteria: "Pattern Matching: The plugin ensures that the resulting date matches the expected pattern.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow(@"^\d{10}$", "{{$New-Date --UnixEpoch}}")]
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

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the NewDate plugin correctly generates and inputs a new date " +
            "result into the target element using the OLE Automation (OaDate) format, and ensures that the " +
            "resulting date matches the expected pattern.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewDate plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Macro Generation: The plugin accurately generates a new date result using the OLE Automation (OaDate) format.")]
        [AcceptanceCriteria(criteria: "Input Handling: The plugin correctly inputs the generated new date result into the target element.")]
        [AcceptanceCriteria(criteria: "Pattern Matching: The plugin ensures that the resulting date matches the expected pattern.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow(@"^\d+\.\d+$", "{{$New-Date --OaDate}}")]
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

        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the NewDate plugin correctly generates and inputs a new date " +
            "result into the target element using a specific date part, and ensures that the " +
            "resulting date matches the expected pattern.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The NewDate plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Macro Generation: The plugin accurately generates a new date result using the specified date part.")]
        [AcceptanceCriteria(criteria: "Input Handling: The plugin correctly inputs the generated new date result into the target element.")]
        [AcceptanceCriteria(criteria: "Pattern Matching: The plugin ensures that the resulting date matches the expected pattern.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        #region *** Data     ***
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Year}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Month}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Day}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Hour}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Minute}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Second}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Millisecond}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Nanosecond}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Microsecond}}")]
        [DataRow(@"^\d{1,}$", "{{$New-Date --DatePart:Ticks}}")]
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
    }
}
