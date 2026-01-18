/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.NewGuid;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    /// <summary>
    /// Test class for testing the behavior of NewGuid plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("NewGuid")]
    [UserStory(story: "As a G4™ user, specifically an automation engineer or RPA (Robotic Process Automation) " +
        "developer, I want a plugin within the G4™ framework that enables me to generate unique identifiers (GUIDs) effortlessly, " +
        "So that I can efficiently create unique references within my automation workflows, ensuring reliability and consistency " +
        "across processes and data management tasks.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The plugin is easily accessible within the G4™ platform's ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "GUID Generation: The plugin offers the functionality to generate a new GUID upon invocation, allowing users to specify a format or use a default format.")]
    [AcceptanceCriteria(criteria: "Flexibility: Users have the flexibility to specify a format for the generated GUID or allow the plugin to use a default format, ensuring adaptability to various automation requirements.")]
    [AcceptanceCriteria(criteria: "Integration: Seamless integration with existing automation workflows within the G4™ platform is crucial for efficient usage of the plugin.")]
    [AcceptanceCriteria(criteria: "Error Handling: The plugin includes robust error handling mechanisms to manage unexpected issues during GUID generation, ensuring smooth execution of automation tasks.")]
    #endregion
    public class NewGuidTests : TestBase
    {
        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the default generation functionality of the {{$NewGuid}} plugin, so that I can " +
            "ensure it generates unique identifiers (GUIDs) correctly without specifying a format.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Accessibility: The {{$NewGuid}} plugin is easily accessible within the G4™ platform's ecosystem for testing purposes.")]
        [AcceptanceCriteria(criteria: "Default Generation: Upon invocation without specifying a format, the {{$NewGuid}} plugin generates a new GUID in the default format.")]
        [AcceptanceCriteria(criteria: "Uniqueness: Testing confirms that each generated GUID is unique, ensuring reliability in identifying entities or processes.")]
        [AcceptanceCriteria(criteria: "Integration: Testing confirms seamless integration of the {{$NewGuid}} plugin into existing automation workflows within the G4™ platform.")]
        [AcceptanceCriteria(criteria: "Error Handling: Testing includes scenarios to verify robust error handling mechanisms in the {{$NewGuid}} plugin, ensuring graceful management of unexpected issues during GUID generation.")]
        #endregion
        #region *** Data     ***
        [DataRow(@"^\w{8}-(\w{4}-){3}\w{12}$", "{{$NewGuid}}")]
        [DataRow(@"^\w{8}-(\w{4}-){3}\w{12}$", "{{$Guid}}")]
        [DataRow(@"^\w{8}-(\w{4}-){3}\w{12}$", "{{$guid}}")]
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

        [TestMethod(DisplayName = "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the functionality of the {{$NewGuid}} plugin when specifying different GUID " +
            "formats (e.g., N, D, B, P, and X), to ensure it generates unique identifiers (GUIDs) " +
            "correctly according to the specified format.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Accessibility: The {{$NewGuid}} plugin is easily accessible within the G4™ platform's ecosystem for testing purposes.")]
        [AcceptanceCriteria(criteria: "Format Specification: Users can specify different GUID formats (e.g., N, D, B, P, and X) when invoking the {{$NewGuid}} plugin.")]
        [AcceptanceCriteria(criteria: "Generation: The {{$NewGuid}} plugin generates a new GUID according to the specified format.")]
        [AcceptanceCriteria(criteria: "Uniqueness: Testing confirms that each generated GUID is unique, regardless of the specified format.")]
        [AcceptanceCriteria(criteria: "Integration: Testing confirms seamless integration of the {{$NewGuid}} plugin into existing automation workflows within the G4™ platform.")]
        [AcceptanceCriteria(criteria: "Error Handling: Testing includes scenarios to verify robust error handling mechanisms in the {{$NewGuid}} plugin, ensuring graceful management of unexpected issues during GUID generation.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-Guid --Format:N}}", @"^\w{32}$")]
        [DataRow("{{$New-Guid --Format:D}}", @"^\w{8}-(\w{4}-){3}\w{12}$")]
        [DataRow("{{$New-Guid --Format:B}}", @"^\{\w{8}-(\w{4}-){3}\w{12}\}$")]
        [DataRow("{{$New-Guid --Format:P}}", @"^\(\w{8}-(\w{4}-){3}\w{12}\)$")]
        [DataRow("{{$New-Guid --Format:X}}", @"^\{0x\w{8},0x\w{4},0x\w{4},\{0x\w{2},0x\w{2},0x\w{2},0x\w{2},0x\w{2},0x\w{2},0x\w{2},0x\w{2}\}\}$")]
        #endregion
        public void T0001B(string macro, string expectedPattern)
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
