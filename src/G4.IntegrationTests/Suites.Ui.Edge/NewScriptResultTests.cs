/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Ui.NewScriptResult;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    /// <summary>
    /// Test class for testing the behavior of NewScriptResult plugin.
    /// </summary>
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("Macros")]
    [TestCategory("NewScriptResult")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that can execute custom scripts effortlessly, " +
        "So that I can enhance the flexibility of my automation workflows and integrate external functionalities seamlessly.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The NewScriptResult plugin should integrate smoothly into the G4™ ecosystem, ensuring easy accessibility for automation developers without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Script Execution: The plugin must effectively execute custom scripts provided as input, allowing automation engineers to incorporate diverse script functionalities into their workflows.")]
    [AcceptanceCriteria(criteria: "Argument Handling: Users have the ability to pass script arguments flexibly to the plugin, supporting various data types and serialization formats for enhanced customization.")]
    [AcceptanceCriteria(criteria: "Error Management: The plugin handles exceptions gracefully during script execution, logging errors appropriately for debugging purposes and ensuring the stability of automation workflows.")]
    #endregion
    public class NewScriptResultTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the NewScriptResult plugin's ability to execute a specific script, ensuring " +
            "accurate retrieval of the inner text of an HTML element identified by the 'ScriptData' ID.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Script Functionality: The NewScriptResult plugin must successfully execute the provided script, retrieving the inner text of the HTML element with the 'ScriptData' ID.")]
        [AcceptanceCriteria(criteria: "Correctness: The retrieved inner text must be trimmed to remove any leading or trailing whitespace.")]
        [AcceptanceCriteria(criteria: "Integration: The plugin must seamlessly integrate into the existing automation framework and execute the script without errors.")]
        [AcceptanceCriteria(criteria: "Output Verification: The automation test must verify that the retrieved inner text matches the expected content of the 'ScriptData' element.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-ScriptResult --Src:return document.getElementById('ScriptData').innerText.trim();}}", "^Foo Bar$")]
        #endregion
        public void T0001A(string macro, string expectedPattern)
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
            "verify the NewScriptResult plugin's ability to execute a custom JavaScript function, " +
            "multiplying a given number by a value retrieved from an HTML input element, to ensure " +
            "accurate computation of the multiplication result within my automation workflows.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Script Execution: The NewScriptResult plugin must successfully execute the provided JavaScript function, multiplying the given number by the value retrieved from the 'ScriptDataNumber' input element.")]
        [AcceptanceCriteria(criteria: "Argument Handling: The plugin must correctly handle the provided argument, passing it to the JavaScript function for multiplication.")]
        [AcceptanceCriteria(criteria: "Integration: The plugin must seamlessly integrate into the existing automation framework and execute the script without errors.")]
        [AcceptanceCriteria(criteria: "Output Verification: The automation test must verify that the multiplication result matches the expected value.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-ScriptResult --Src:function multiply(num){return parseInt(document.getElementById('ScriptDataNumber').value)*num}return multiply(arguments[0]); --Arg:5}}", "^25$")]
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

        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify the NewScriptResult plugin's ability to execute a custom JavaScript function, " +
            "which multiplies two given numbers and a value retrieved from an HTML input element, to ensure " +
            "accurate computation of the multiplication result within my automation workflows.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Script Execution: The NewScriptResult plugin must successfully execute the provided JavaScript function, multiplying the two given numbers and the value retrieved from the 'ScriptDataNumber' input element.")]
        [AcceptanceCriteria(criteria: "Argument Handling: The plugin must correctly handle the provided arguments, passing them to the JavaScript function for multiplication.")]
        [AcceptanceCriteria(criteria: "Integration: The plugin must seamlessly integrate into the existing automation framework and execute the script without errors.")]
        [AcceptanceCriteria(criteria: "Output Verification: The automation test must verify that the multiplication result matches the expected value.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-ScriptResult --Src:function multiply(num1,num2){return parseInt(document.getElementById('ScriptDataNumber').value)*num1*num2}return multiply(arguments[0],arguments[1]); --Arg:5 --Arg:2}}", "^50$")]
        #endregion
        public void T0001C(string macro, string expectedPattern)
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
            "verify the NewScriptResult plugin's ability to execute a custom JavaScript function, " +
            "which multiplies two given numbers passed as an object with two fields, ensuring " +
            "correct handling of data types, to ensure accurate computation of the multiplication " +
            "result within my automation workflows.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Script Execution: The NewScriptResult plugin must successfully execute the provided JavaScript function, multiplying the two given numbers passed as an object with two fields, ensuring correct handling of data types, and the value retrieved from the 'ScriptDataNumber' input element.")]
        [AcceptanceCriteria(criteria: "Argument Handling: The plugin must correctly handle the provided arguments and their data types, passing them to the JavaScript function for multiplication.")]
        [AcceptanceCriteria(criteria: "Integration: The plugin must seamlessly integrate into the existing automation framework and execute the script without errors.")]
        [AcceptanceCriteria(criteria: "Output Verification: The automation test must verify that the multiplication result matches the expected value.")]
        #endregion
        #region *** Data     ***
        [DataRow("{{$New-ScriptResult --Src:function multiply(nums){return parseInt(document.getElementById('ScriptDataNumber').value)*nums.num1*nums.num2}return multiply(arguments[0]); --Arg:{\"num1\":5,\"num2\":2}}}", "^50$")]
        #endregion
        public void T0001D(string macro, string expectedPattern)
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
