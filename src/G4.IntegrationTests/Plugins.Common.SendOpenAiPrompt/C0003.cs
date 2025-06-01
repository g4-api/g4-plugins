using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.SendOpenAiPrompt
{
    internal class C0003(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Retrieve the OpenAI API key from the environment's context properties (defaulting to empty string if not found)
            var apiKey = environment.ContextProperties.Get(key: "OpenAi.ApiKey", defaultValue: string.Empty);

            // Build and return the list of action rules to execute
            return
            [
                // Action: Send an OpenAI prompt asking for C developer guidance
                new ActionRuleModel
                {
                    Argument = "{{$ " +
                        "--SystemPrompt:You are an expert C developer who writes clear, efficient code and provides practical guidance on C programming tasks. " +
                        "--Prompt:Hey there! How's your day going? " +
                        "--ApiKey:" + apiKey + " " +
                        "--MaxTokens:5}}",
                    PluginName = "SendOpenAiPrompt"
                },

                // Assertion: Ensure that the system response text is not empty or whitespace
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Match --Expected:^(?!\\s*$).+}}",
                    OnElement = "{{$Get-Parameter --Name:OpenAiSystemResponse --Scope:Session}}"
                },

                // Assertion: Ensure that 5 completion token was used
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:5}}",
                    OnElement = "{{$Get-Parameter --Name:OpenAiCompletionTokens --Scope:Session}}"
                },

                // Assertion: Ensure that 41 prompt token were used
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Equal --Expected:41}}",
                    OnElement = "{{$Get-Parameter --Name:OpenAiPromptTokens --Scope:Session}}"
                },

                // Assertion: Ensure that the total token count is greater than zero
                new ActionRuleModel
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Greater --Expected:0}}",
                    OnElement = "{{$Get-Parameter --Name:OpenAiTotalTokens --Scope:Session}}"
                },
            ];
        }
    }
}
