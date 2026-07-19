# Send Open Ai Prompt (SendOpenAiPrompt)

[Table of Content](../Home.md)  

~22 min · Action Plugin · [Roei Sabag](https://www.linkedin.com/in/roei-sabag-247aa18/)

## Description

### Purpose

Sends user messages to the OpenAI chat API and returns the assistant’s reply. It keeps track of conversation history for each session and lets you set a custom starting message if needed. It also records token usage and any internal reasoning steps so you can use those details later.

### Key Features and Functionality

| Feature                | Description                                                                                          |
|------------------------|------------------------------------------------------------------------------------------------------|
| Conversation History   | Keep track of user and system messages for each session.                                             |
| Custom System Prompt   | Let users supply a starting instruction, or default to a helpful assistant message.                  |
| Completion Settings    | Control response length and behavior with parameters like MaxTokens, Model, Temperature, TopK, TopP. |
| New Conversation Reset | Clear all past messages when a new chat is requested.                                                |
| Response Processing    | Pull out and store any hidden “think” steps or parts of the response for later use.                  |

### Usages in RPA

| Use Case               | Description                                                                                 |
|------------------------|---------------------------------------------------------------------------------------------|
| User Support Chatbot   | Let a robot chat with people, answer questions, or gather information in real time.         |
| Dynamic Form Filling   | Ask the API how to fill web forms and use that guidance in an automated workflow.           |
| Email Draft Generation | Automatically generate or suggest email drafts based on user prompts.                       |
| Content Summarization  | Send text to the API to get a quick summary and feed that back into other automation steps. |

### Usages in Automation Testing

| Use Case                  | Description                                                                                 |
|---------------------------|---------------------------------------------------------------------------------------------|
| Test Data Generation      | Ask the API to create sample inputs (names, addresses, etc.) for use in automated tests.    |
| Response Validation       | Compare the API’s reply to expected patterns to check if the integration works correctly.   |
| Error Handling Simulation | Trigger error messages from the API to test how the system handles bad or unexpected input. |
| Performance Tracking      | Track token usage over time to make sure API calls stay within expected limits.             |

## Examples

### Example No.1

### Start a New Chat with a Custom System Prompt

Start a new conversation with a custom system prompt and then send a user prompt.
It uses the `SendOpenAiPrompt` plugin with the flags `--NewChat`, `--SystemPrompt:You are a math tutor.`, and `--Prompt:Explain the Pythagorean theorem.`.
Values are returned as JSON for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendOpenAiPrompt",
    Argument = "{{$ --NewChat --SystemPrompt:You are a math tutor. --Prompt:Explain the Pythagorean theorem. --ApiKey:YOUR_API_KEY}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendOpenAiPrompt")
    .setArgument("{{$ --NewChat --SystemPrompt:You are a math tutor. --Prompt:Explain the Pythagorean theorem. --ApiKey:YOUR_API_KEY}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendOpenAiPrompt",
    argument: "{{$ --NewChat --SystemPrompt:You are a math tutor. --Prompt:Explain the Pythagorean theorem. --ApiKey:YOUR_API_KEY}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --NewChat --SystemPrompt:You are a math tutor. --Prompt:Explain the Pythagorean theorem. --ApiKey:YOUR_API_KEY}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --NewChat --SystemPrompt:You are a math tutor. --Prompt:Explain the Pythagorean theorem. --ApiKey:YOUR_API_KEY}}"
}
```
### Example No.2

### Send a Prompt with Custom Temperature and Token Limits

Send a prompt with specific parameters for temperature and token limits.
It uses the `SendOpenAiPrompt` plugin with the flags `--Prompt:Tell a joke.`, `--Temperature:0.7`, `--MaxTokens:100`, and `--Model:gpt-3.5-turbo`.
Values are returned as JSON for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendOpenAiPrompt",
    Argument = "{{$ --Prompt:Tell a joke. --Temperature:0.7 --MaxTokens:100 --Model:gpt-3.5-turbo --ApiKey:YOUR_API_KEY}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendOpenAiPrompt")
    .setArgument("{{$ --Prompt:Tell a joke. --Temperature:0.7 --MaxTokens:100 --Model:gpt-3.5-turbo --ApiKey:YOUR_API_KEY}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendOpenAiPrompt",
    argument: "{{$ --Prompt:Tell a joke. --Temperature:0.7 --MaxTokens:100 --Model:gpt-3.5-turbo --ApiKey:YOUR_API_KEY}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --Prompt:Tell a joke. --Temperature:0.7 --MaxTokens:100 --Model:gpt-3.5-turbo --ApiKey:YOUR_API_KEY}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --Prompt:Tell a joke. --Temperature:0.7 --MaxTokens:100 --Model:gpt-3.5-turbo --ApiKey:YOUR_API_KEY}}"
}
```
### Example No.3

### Extract Content Before `<think>` Tag from AI Response

Send a prompt to an AI endpoint and use a regular expression to extract only the content appearing before a `<think>` tag in the response.
It uses the `SendOpenAiPrompt` plugin with the flags `--Prompt:Analyze the following data.` and `--ApiKey:YOUR_API_KEY`, then applies the regular expression `^[^<]*` to the response text.
A regular expression `^[^<]*` is applied to capture all characters up to (but not including) the first `<` character, ensuring that only the text preceding `<think>` is returned.
Values are returned as strings for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendOpenAiPrompt",
    Argument = "{{$ --Prompt:Analyze the following data. --ApiKey:YOUR_API_KEY}}",
    RegularExpression = "^[^<]*"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendOpenAiPrompt")
    .setArgument("{{$ --Prompt:Analyze the following data. --ApiKey:YOUR_API_KEY}}")
    .setRegularExpression("^[^<]*");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendOpenAiPrompt",
    argument: "{{$ --Prompt:Analyze the following data. --ApiKey:YOUR_API_KEY}}",
    regularExpression: "^[^<]*"
};
```

_**JSON**_

```js
{
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --Prompt:Analyze the following data. --ApiKey:YOUR_API_KEY}}",
    "regularExpression": "^[^<]*"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --Prompt:Analyze the following data. --ApiKey:YOUR_API_KEY}}",
    "regularExpression": "^[^<]*"
}
```
### Example No.4

### Send a Prompt with TopK to Limit Candidate Tokens

Send a prompt with a TopK parameter to limit candidate tokens in the AI response.
It uses the `SendOpenAiPrompt` plugin with the flags `--Prompt:Recommend a movie.`, `--TopK:3`, and `--ApiKey:YOUR_API_KEY`.
Values are returned as JSON for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendOpenAiPrompt",
    Argument = "{{$ --Prompt:Recommend a movie. --TopK:3 --ApiKey:YOUR_API_KEY}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendOpenAiPrompt")
    .setArgument("{{$ --Prompt:Recommend a movie. --TopK:3 --ApiKey:YOUR_API_KEY}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendOpenAiPrompt",
    argument: "{{$ --Prompt:Recommend a movie. --TopK:3 --ApiKey:YOUR_API_KEY}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --Prompt:Recommend a movie. --TopK:3 --ApiKey:YOUR_API_KEY}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --Prompt:Recommend a movie. --TopK:3 --ApiKey:YOUR_API_KEY}}"
}
```
### Example No.5

### Send a Prompt with TopP to a Custom Open-WebUI Endpoint

Send a prompt with a TopP parameter to a custom Open-WebUI endpoint rather than the OpenAI API.
It uses the `SendOpenAiPrompt` plugin with the flags `--Prompt:Summarize this article.`, `--CompletionsUri:http://localhost:3000/api/chat/completions`, `--TopP:0.8`, and `--ApiKey:YOUR_API_KEY`.
Values are returned as JSON for downstream processing.

_**CSharp**_

```csharp
var actionRule = new ActionRuleModel
{
    PluginName = "SendOpenAiPrompt",
    Argument = "{{$ --Prompt:Summarize this article. --CompletionsUri:http://localhost:3000/api/chat/completions --TopP:0.8 --ApiKey:YOUR_API_KEY}}"
};
```

_**Java**_

```java
ActionRuleModel actionRule = new ActionRuleModel()
    .setPluginName("SendOpenAiPrompt")
    .setArgument("{{$ --Prompt:Summarize this article. --CompletionsUri:http://localhost:3000/api/chat/completions --TopP:0.8 --ApiKey:YOUR_API_KEY}}");
```

_**Javascript**_

```js
var actionRule = {
    pluginName: "SendOpenAiPrompt",
    argument: "{{$ --Prompt:Summarize this article. --CompletionsUri:http://localhost:3000/api/chat/completions --TopP:0.8 --ApiKey:YOUR_API_KEY}}"
};
```

_**JSON**_

```js
{
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --Prompt:Summarize this article. --CompletionsUri:http://localhost:3000/api/chat/completions --TopP:0.8 --ApiKey:YOUR_API_KEY}}"
}
```

_**Python**_

```python
action_rule = {
    "pluginName": "SendOpenAiPrompt",
    "argument": "{{$ --Prompt:Summarize this article. --CompletionsUri:http://localhost:3000/api/chat/completions --TopP:0.8 --ApiKey:YOUR_API_KEY}}"
}
```

## Output Parameter

### Send Open Ai Prompt Completion Tokens (SendOpenAiPrompt:CompletionTokens)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Count of tokens produced by the AI’s response.
It shows how long the reply is in token units.
Monitoring completion token usage helps manage resource consumption.

### Send Open Ai Prompt Prompt Tokens (SendOpenAiPrompt:PromptTokens)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Count of tokens included in all messages sent as the prompt.
It shows how many token units the request consumed.
Tracking prompt token usage helps control input size.

### Send Open Ai Prompt System Response (SendOpenAiPrompt:SystemResponse)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Base64-encoded final response after applying pattern filtering.
Decoding yields the clean reply that the AI generated.
Filtered content ensures only the intended output is returned.

### Send Open Ai Prompt Total Tokens (SendOpenAiPrompt:TotalTokens)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Total tokens used for both the request prompt and the response.
It indicates combined token usage for the API call.
Monitoring total tokens helps manage costs and limits.

### Send Open Ai Prompt Think (SendOpenAiPrompt:Think)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Base64-encoded content extracted from internal reasoning notes.
Decoding reveals the AI’s hidden annotations and thought steps.
These insights help understand how the AI arrived at its answer.

## Properties

### Argument (Argument)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String|Expression |

Template expression to pass parameters and prompt text.

### Regular Expression (RegularExpression)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | (?s).*            |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Regex             |

Regular expression to extract the desired portion of the system response.

## Parameters

### Api Key (ApiKey)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | Yes               |
| **Multiple**      | No                |
| **Value Type**    | String            |

A secret value that lets you authenticate requests to OpenAI.
It ensures the system can perform actions on your behalf.
Keeping a valid key protects your account.

### Completions Uri (CompletionsUri)

| Attribute                                  | Value                                      |
|--------------------------------------------|--------------------------------------------|
| **Default Value**                          | https://api.openai.com/v1/chat/completions |
| **Depends On**                             | None                                       |
| **Mandatory**                              | No                                         |
| **Multiple**                               | No                                         |
| **Value Type**                             | String                                     |

Address used for sending chat completion requests.
The default points to OpenAI’s official chat endpoint.

### Max Tokens (MaxTokens)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

A number that limits how long the response can be.
It controls how many tokens the reply can include.

### Model (Model)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | gpt-4.1-mini      |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Specifies which version of OpenAI to generate responses.
Defaults to gpt-4.1-mini when not provided.
Choosing a higher-capability model can produce more detailed answers.

### New Chat (NewChat)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Switch            |

Clears past messages and starts a fresh conversation when enabled.
Use this to avoid carrying over context from previous interactions.
Turning it on makes each prompt treated independently.

### Prompt (Prompt)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

Text sent to the assistant for generating a response.
The content guides the assistant on what to reply.
Providing a clear message leads to more relevant answers.

### System Prompt (SystemPrompt)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | String            |

A starting instruction that guides the conversation’s tone and focus.
It appears before any user messages to set context for the AI.
Using a clear prompt helps the AI understand what style or information to prioritize.

### Temperature (Temperature)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Adjusts how creative or predictable the AI’s response will be.
Higher values produce more varied and unexpected outputs.
Lower values keep replies more focused and consistent.

### Top K (TopK)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Limits token choices to the top candidates when generating a reply.
Smaller values make the AI pick from fewer options, making output more deterministic.
Larger values allow more variety in word selection.

### Top P (TopP)

| Attribute         | Value             |
|-------------------|-------------------|
| **Default Value** | Null              |
| **Depends On**    | None              |
| **Mandatory**     | No                |
| **Multiple**      | No                |
| **Value Type**    | Number            |

Not available directly from OpenAI and used by other tools to control which words the AI picks.
It sets a limit so words are chosen only until their combined chances reach this value.
Lower numbers force the AI to pick only the most likely words, making output more predictable.
Higher numbers let the AI include more word options, making responses more varied.

## Scope

* Any
## See Also

apiDocumentation: [https://platform.openai.com/docs/api-reference/chat/create](https://platform.openai.com/docs/api-reference/chat/create)
