﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.WriteLog;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("WriteLog")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to write logs during automation tasks, So that I can " +
        "monitor the execution of my automation workflows and troubleshoot any issues effectively.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The WriteLog plugin must be readily accessible within the G4™ ecosystem, enabling seamless integration into automation workflows without complex setup procedures.")]
    [AcceptanceCriteria(criteria: "Logging Functionality: The plugin effectively logs information provided in the plugin data, allowing users to capture relevant details during automation tasks.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during log writing operations, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class WriteLogTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the WriteLog plugin successfully writes a log message with the first 8 " +
            "alphanumeric characters of the GUID generated by the New-Guid plugin.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The WriteLog plugin integrates seamlessly into the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Log Message: The plugin successfully writes a log message containing the first 8 alphanumeric characters of the GUID.")]
        [AcceptanceCriteria(criteria: "GUID Generation: The plugin correctly generates a GUID using the New-Guid plugin.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully, providing clear and informative messages in case of failures.")]
        #endregion
        public void T0001P()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options.
            var testOptions = new EdgeTestOptions(environment);

            // Invoking the test with the constructed test options.
            Invoke<C0001>(testOptions);
        }
    }
}