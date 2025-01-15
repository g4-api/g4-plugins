using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.InvokeForEachLoop;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("InvokeForEachLoop")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to execute a set of actions iteratively for a specified " +
        "number of times, facilitating repetitive tasks and bulk operations during automation processes.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The InvokeForLoop plugin must be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Iterative Execution: The plugin should execute a set of actions iteratively based on the specified number of iterations, enabling automation engineers to perform repetitive tasks efficiently.")]
    [AcceptanceCriteria(criteria: "Rule Adjustment: The plugin should adjust rule references and context appropriately for each iteration, ensuring correct execution of actions within the loop.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during iterative execution, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class InvokeForEachLoopTests : TestBase
    {
        [TestMethod(displayName: "As an automation engineer using the G4™ platform, I need " +
            "to verify that the InvokeForLoop plugin correctly executes a series of actions " +
            "a specified number of times.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The InvokeForLoop plugin integrates seamlessly with the automation testing framework.")]
        [AcceptanceCriteria(criteria: "Action Execution: The plugin accurately executes the specified actions the specified number of times.")]
        [AcceptanceCriteria(criteria: "Loop Termination: The plugin terminates the loop after the specified number of iterations.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of failures.")]
        #endregion
        public void T0001P()
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "Loops.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);
        }
    }
}
