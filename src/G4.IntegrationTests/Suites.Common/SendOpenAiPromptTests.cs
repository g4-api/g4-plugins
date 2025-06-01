using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.SendOpenAiPrompt;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.IntegrationTests.Suites.Common
{
    [TestClass]
    public class SendOpenAiPromptTests : TestBase
    {
        [Ignore(message: "This test is currently skipped in the production environment due to cost management.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SendOpenAiPrompt plugin sends prompts and stores the response and token counts correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendOpenAiPrompt plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "System Prompt Support: When provided with a SystemPrompt, the plugin uses it as the system role message.")]
        [AcceptanceCriteria(criteria: "User Prompt Transmission: When provided with a Prompt, the plugin sends it to OpenAI.")]
        [AcceptanceCriteria(criteria: "Response Storage: The plugin stores a non-empty response in session parameter 'OpenAiSystemResponse'.")]
        [AcceptanceCriteria(criteria: "Prompt Token Counting: The plugin stores the correct number of prompt tokens in 'OpenAiPromptTokens'.")]
        [AcceptanceCriteria(criteria: "Completion Token Counting: The plugin stores a value greater than zero for 'OpenAiCompletionTokens'.")]
        [AcceptanceCriteria(criteria: "Total Token Counting: The plugin stores a value greater than zero for 'OpenAiTotalTokens'.")]
        #endregion
        public void T0001()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating non-UI test options
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test case with the constructed test options
            Invoke<C0001>(testOptions);
        }

        [Ignore(message: "This test is currently skipped in the production environment due to cost management.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SendOpenAiPrompt plugin sends prompts across new chat sessions and stores the response and token counts correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendOpenAiPrompt plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "System Prompt Support: When provided with a SystemPrompt, the plugin uses it as the system role message.")]
        [AcceptanceCriteria(criteria: "User Prompt Transmission: When provided with a Prompt, the plugin sends it to OpenAI.")]
        [AcceptanceCriteria(criteria: "New Chat Invocation: When provided with the NewChat flag, the plugin starts a new conversation session.")]
        [AcceptanceCriteria(criteria: "Response Storage: The plugin stores a non-empty response in session parameter 'OpenAiSystemResponse'.")]
        [AcceptanceCriteria(criteria: "Prompt Token Counting: The plugin stores the correct number of prompt tokens in 'OpenAiPromptTokens'.")]
        [AcceptanceCriteria(criteria: "Completion Token Counting: The plugin stores a value greater than zero for 'OpenAiCompletionTokens'.")]
        [AcceptanceCriteria(criteria: "Total Token Counting: The plugin stores a value greater than zero for 'OpenAiTotalTokens'.")]
        #endregion
        public void T0002()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating non-UI test options
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test case with the constructed test options
            Invoke<C0002>(testOptions);
        }

        [Ignore(message: "This test is currently skipped in the production environment due to cost management.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SendOpenAiPrompt plugin respects the MaxTokens parameter and stores token counts correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendOpenAiPrompt plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "MaxTokens Support: When provided with MaxTokens, the plugin limits the completion tokens accordingly.")]
        [AcceptanceCriteria(criteria: "Response Storage: The plugin stores a non-empty response in session parameter 'OpenAiSystemResponse'.")]
        [AcceptanceCriteria(criteria: "Completion Token Counting: The plugin stores exactly 5 completion tokens in 'OpenAiCompletionTokens'.")]
        [AcceptanceCriteria(criteria: "Prompt Token Counting: The plugin stores the correct number of prompt tokens in 'OpenAiPromptTokens'.")]
        [AcceptanceCriteria(criteria: "Total Token Counting: The plugin stores a value greater than zero for 'OpenAiTotalTokens'.")]
        #endregion
        public void T0003()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating non-UI test options
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test case with the constructed test options
            Invoke<C0003>(testOptions);
        }

        [Ignore(message: "This test is currently skipped in the production environment due to cost management.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SendOpenAiPrompt plugin respects MaxTokens and Temperature parameters and stores token counts correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendOpenAiPrompt plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "MaxTokens Support: When provided with MaxTokens, the plugin limits the completion tokens accordingly.")]
        [AcceptanceCriteria(criteria: "Temperature Support: When provided with Temperature, the plugin adjusts response variability.")]
        [AcceptanceCriteria(criteria: "Response Storage: The plugin stores a non-empty response in session parameter 'OpenAiSystemResponse'.")]
        [AcceptanceCriteria(criteria: "Completion Token Counting: The plugin stores exactly 5 completion tokens in 'OpenAiCompletionTokens'.")]
        [AcceptanceCriteria(criteria: "Prompt Token Counting: The plugin stores the correct number of prompt tokens in 'OpenAiPromptTokens'.")]
        [AcceptanceCriteria(criteria: "Total Token Counting: The plugin stores a value greater than zero for 'OpenAiTotalTokens'.")]
        #endregion
        public void T0004()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating non-UI test options
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test case with the constructed test options
            Invoke<C0004>(testOptions);
        }

        [Ignore(message: "This test is currently skipped in the production environment due to cost management.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SendOpenAiPrompt plugin respects MaxTokens, Temperature, and TopP parameters and stores token counts correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendOpenAiPrompt plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "MaxTokens Support: When provided with MaxTokens, the plugin limits the completion tokens accordingly.")]
        [AcceptanceCriteria(criteria: "Temperature Support: When provided with Temperature, the plugin adjusts response variability.")]
        [AcceptanceCriteria(criteria: "TopP Support: When provided with TopP, the plugin applies nucleus sampling to control output diversity.")]
        [AcceptanceCriteria(criteria: "Response Storage: The plugin stores a non-empty response in session parameter 'OpenAiSystemResponse'.")]
        [AcceptanceCriteria(criteria: "Completion Token Counting: The plugin stores exactly 5 completion tokens in 'OpenAiCompletionTokens'.")]
        [AcceptanceCriteria(criteria: "Prompt Token Counting: The plugin stores the correct number of prompt tokens in 'OpenAiPromptTokens'.")]
        [AcceptanceCriteria(criteria: "Total Token Counting: The plugin stores a value greater than zero for 'OpenAiTotalTokens'.")]
        #endregion
        public void T0005()
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Creating non-UI test options
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test case with the constructed test options
            Invoke<C0005>(testOptions);
        }

        [Ignore(message: "This test is currently skipped in the production environment due to cost management.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SendOpenAiPrompt plugin respects CompletionsUri, MaxTokens, Temperature, and TopP parameters and stores token counts correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendOpenAiPrompt plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "CompletionsUri Support: When provided with CompletionsUri, the plugin sends requests to the specified URI.")]
        [AcceptanceCriteria(criteria: "MaxTokens Support: When provided with MaxTokens, the plugin limits the completion tokens accordingly.")]
        [AcceptanceCriteria(criteria: "Temperature Support: When provided with Temperature, the plugin adjusts response variability.")]
        [AcceptanceCriteria(criteria: "TopP Support: When provided with TopP, the plugin applies nucleus sampling to control output diversity.")]
        [AcceptanceCriteria(criteria: "Response Storage: The plugin stores a non-empty response in session parameter 'OpenAiSystemResponse'.")]
        [AcceptanceCriteria(criteria: "Completion Token Counting: The plugin stores exactly 5 completion tokens in 'OpenAiCompletionTokens'.")]
        [AcceptanceCriteria(criteria: "Prompt Token Counting: The plugin stores the correct number of prompt tokens in 'OpenAiPromptTokens'.")]
        [AcceptanceCriteria(criteria: "Total Token Counting: The plugin stores a value greater than zero for 'OpenAiTotalTokens'.")]
        #endregion
        #region *** Data     ***
        [DataRow("http://localhost:3000/api/chat/completions")]
        #endregion
        public void T0006(string completionsUri)
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Set the CompletionsUri test parameter
            environment.TestParameters["CompletionsUri"] = completionsUri;

            // Create non-UI test options
            var testOptions = new NonUiTestOptions(environment);

            // Invoke the test case with the constructed test options
            Invoke<C0006>(testOptions);
        }

        [Ignore(message: "This test is currently skipped in the production environment due to cost management.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SendOpenAiPrompt plugin respects Model, CompletionsUri, MaxTokens, Temperature, and TopP parameters and " +
            "stores token counts correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendOpenAiPrompt plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Model Support: When provided with Model, the plugin uses the specified model for completion.")]
        [AcceptanceCriteria(criteria: "CompletionsUri Support: When provided with CompletionsUri, the plugin sends requests to the specified URI.")]
        [AcceptanceCriteria(criteria: "MaxTokens Support: When provided with MaxTokens, the plugin limits the completion tokens accordingly.")]
        [AcceptanceCriteria(criteria: "Temperature Support: When provided with Temperature, the plugin adjusts response variability.")]
        [AcceptanceCriteria(criteria: "TopP Support: When provided with TopP, the plugin applies nucleus sampling to control output diversity.")]
        [AcceptanceCriteria(criteria: "Response Storage: The plugin stores a non-empty response in session parameter 'OpenAiSystemResponse'.")]
        [AcceptanceCriteria(criteria: "Completion Token Counting: The plugin stores a value greater than zero for 'OpenAiCompletionTokens'.")]
        [AcceptanceCriteria(criteria: "Prompt Token Counting: The plugin stores a value greater than zero for 'OpenAiPromptTokens'.")]
        [AcceptanceCriteria(criteria: "Total Token Counting: The plugin stores a value greater than zero for 'OpenAiTotalTokens'.")]
        #endregion
        #region *** Data     ***
        [DataRow("http://localhost:3000/api/chat/completions")]
        #endregion
        public void T0007(string completionsUri)
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Set test parameters
            environment.TestParameters["CompletionsUri"] = completionsUri;

            // Create non-UI test options
            var testOptions = new NonUiTestOptions(environment);

            // Invoke the test case with the constructed test options
            Invoke<C0007>(testOptions);
        }

        [Ignore(message: "This test is currently skipped in the production environment due to cost management.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to verify that the " +
            "SendOpenAiPrompt plugin respects TopK, Model, CompletionsUri, MaxTokens, Temperature, and TopP " +
            "parameters and stores token counts correctly.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The SendOpenAiPrompt plugin integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "TopK Support: When provided with TopK, the plugin limits the token selection accordingly.")]
        [AcceptanceCriteria(criteria: "Model Support: When provided with Model, the plugin uses the specified model for completion.")]
        [AcceptanceCriteria(criteria: "CompletionsUri Support: When provided with CompletionsUri, the plugin sends requests to the specified URI.")]
        [AcceptanceCriteria(criteria: "MaxTokens Support: When provided with MaxTokens, the plugin limits the completion tokens accordingly.")]
        [AcceptanceCriteria(criteria: "Temperature Support: When provided with Temperature, the plugin adjusts response variability.")]
        [AcceptanceCriteria(criteria: "TopP Support: When provided with TopP, the plugin applies nucleus sampling to control output diversity.")]
        [AcceptanceCriteria(criteria: "Response Storage: The plugin stores a non-empty response in session parameter 'OpenAiSystemResponse'.")]
        [AcceptanceCriteria(criteria: "Completion Token Counting: The plugin stores a value greater than zero for 'OpenAiCompletionTokens'.")]
        [AcceptanceCriteria(criteria: "Prompt Token Counting: The plugin stores a value greater than zero for 'OpenAiPromptTokens'.")]
        [AcceptanceCriteria(criteria: "Total Token Counting: The plugin stores a value greater than zero for 'OpenAiTotalTokens'.")]
        #endregion
        #region *** Data     ***
        [DataRow("http://localhost:3000/api/chat/completions")]
        #endregion
        public void T0008(string completionsUri)
        {
            // Create AutomationEnvironment instance with test context
            var environment = new AutomationEnvironment(TestContext);

            // Set the CompletionsUri test parameter
            environment.TestParameters["CompletionsUri"] = completionsUri;

            // Creating non-UI test options
            var testOptions = new NonUiTestOptions(environment);

            // Invoking the test case with the constructed test options
            Invoke<C0008>(testOptions);
        }
    }
}
