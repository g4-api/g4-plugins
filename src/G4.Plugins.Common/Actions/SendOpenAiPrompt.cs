using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(SendOpenAiPrompt)}.json")]
    public class SendOpenAiPrompt(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        #region *** Fields             ***
        private static readonly ConcurrentDictionary<string, List<Message>> s_conversationHistories = new(StringComparer.OrdinalIgnoreCase);

        private static readonly JsonSerializerOptions s_jsonOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            WriteIndented = false
        };
        #endregion

        #region *** Methods: Protected ***
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the API key from plugin parameters (or null if not provided)
            var apiKey = pluginData.Parameters.Get(key: "ApiKey", defaultValue: default(string));

            // Retrieve the URI for completions endpoint or use default OpenAI chat endpoint
            var completionsUri = pluginData.Parameters.Get(key: "CompletionsUri", defaultValue: "https://api.openai.com/v1/chat/completions");

            // Retrieve the maximum token limit for this request (nullable int)
            var maxTokensValue = pluginData.Parameters.Get(key: "MaxTokens", defaultValue: default(string));
            var maxTokens = string.IsNullOrEmpty(maxTokensValue)
                ? null
                : int.TryParse(maxTokensValue, out var parsedMaxTokens)
                    ? parsedMaxTokens
                    : default(int?);

            // Retrieve the model identifier or default to "gpt-4.1-mini"
            var model = pluginData.Parameters.Get(key: "Model", defaultValue: "gpt-4.1-mini");

            // Determine if this call should start a new conversation (clears previous history)
            var newChat = pluginData.Parameters.ContainsKey("NewChat");

            // Retrieve the user's prompt text from parameters or rule argument
            var prompt = pluginData.Parameters.Get(key: "Prompt", defaultValue: pluginData.Rule.Argument);

            // Retrieve a custom system prompt if provided
            var systemPrompt = pluginData.Parameters.Get(key: "SystemPrompt", defaultValue: default(string));

            // Retrieve temperature setting (nullable double) for controlling response randomness
            var temperatureValue = pluginData.Parameters.Get(key: "Temperature", defaultValue: default(string));
            var temperature = string.IsNullOrEmpty(temperatureValue)
                ? null
                : double.TryParse(temperatureValue, out var parsedTemperature)
                    ? parsedTemperature
                    : default(double?);

            // Retrieve TopK sampling cutoff (nullable int) to limit candidate tokens
            var topKValue = pluginData.Parameters.Get(key: "TopK", defaultValue: default(string));
            var topK = string.IsNullOrEmpty(topKValue)
                ? null
                : int.TryParse(topKValue, out var parsedTopK)
                    ? parsedTopK
                    : default(int?);

            // Retrieve TopP nucleus sampling threshold (nullable double)
            var topPValue = pluginData.Parameters.Get(key: "TopP", defaultValue: default(string));
            var topP = string.IsNullOrEmpty(topPValue) ?
                null
                : double.TryParse(topPValue, out var parsedTopP)
                    ? parsedTopP
                    : default(double?);

            // Get the unique identifier for the current user session
            var userId = WebDriver.GetSession().OpaqueKey;

            // If a new chat is requested, reset this user's conversation history
            if (newChat)
            {
                s_conversationHistories[userId] = [];
            }

            // Initialize or retrieve this user's conversation history, injecting the system prompt if provided
            var messages = InitializeHistory(s_conversationHistories, userId, systemPrompt);

            // Append the user's latest prompt message to the history
            messages.Add(new Message
            {
                Role = "user",
                Content = prompt
            });

            // Build the ChatRequest object with all required parameters
            var chatRequest = new ChatRequest
            {
                Model = model,
                Messages = messages,
                MaxTokens = maxTokens,
                Temperature = temperature,
                TopK = topK,
                TopP = topP
            };

            // Construct the HTTP request for the OpenAI completions endpoint
            var request = NewCompletionsRequest(completionsUri, apiKey, chatRequest);

            // Send the prompt asynchronously and wait for the ChatResponse
            var chatResponse = SendPromptAsync(plugin: this, rule: pluginData.Rule, request).Result;

            // If the response contains no choices, create an empty plugin response
            if (chatResponse?.Choices == null || chatResponse.Choices.Length == 0)
            {
                return NewPluginResponse(plugin: this, pluginData, chatResponse, input: string.Empty);
            }

            // Extract the assistant's reply text from the first choice and trim whitespace
            var input = chatResponse.Choices[0].Message.Content.Trim();

            // Create and return a PluginResponseModel populated with tokens, think data, and system response
            return NewPluginResponse(plugin: this, pluginData, chatResponse, input);
        }
        #endregion

        #region *** Methods: Private   ***
        // Initializes or retrieves the message history for a user and ensures a system prompt is present.
        private static List<Message> InitializeHistory(
            ConcurrentDictionary<string, List<Message>> conversationHistories, string userId, string systemPrompt)
        {
            // Attempt to get existing history for the user
            if (!conversationHistories.TryGetValue(userId, out var history))
            {
                // Create a new list for the user's history
                history = [];

                // Capture custom system prompt if provided (value assigned but not used directly here)
                string initialSystem = systemPrompt;

                // Store the new history list under the userId
                conversationHistories[userId] = history;
            }

            // Check if a new system prompt was provided
            if (!string.IsNullOrWhiteSpace(systemPrompt))
            {
                // Inject the custom system message into the history
                history.Add(new Message
                {
                    Role = "system",
                    Content = systemPrompt
                });
            }
            else
            {
                // Determine if any system message already exists in the history
                bool hasSystem = history.Any(i => i.Role == "system");
                if (!hasSystem)
                {
                    // Insert a default system message at the beginning if none exists
                    history.Insert(0, new Message
                    {
                        Role = "system",
                        Content = "You are a helpful assistant."
                    });
                }
            }

            // Return the initialized or retrieved history list
            return history;
        }

        // Constructs a new HttpRequestMessage for the OpenAI chat completions endpoint,
        // including authorization and JSON content.
        private static HttpRequestMessage NewCompletionsRequest(string completionsUri, string apiKey, ChatRequest chatRequest)
        {
            // Serialize the ChatRequest object to JSON string
            var content = JsonSerializer.Serialize(chatRequest, s_jsonOptions);

            // Create a new HttpRequestMessage with POST method and attach the JSON content
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: completionsUri)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            // Set the Authorization header with the Bearer token
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            // Add "application/json" to the Accept header to specify expected response format
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Return the fully configured HTTP request
            return request;
        }

        // Creates a new PluginResponseModel by processing the chat response data,
        // extracting relevant information (such as <think> tags and system response),
        // storing token usage and extracted data into session parameters, and then returning the plugin response.
        private static PluginResponseModel NewPluginResponse(
            PluginBase plugin,
            PluginDataModel pluginData,
            ChatResponse chatResponse,
            string input)
        {
            // Define regex options to ignore case and treat input as a single line
            const RegexOptions regexOptions = RegexOptions.IgnoreCase | RegexOptions.Singleline;

            // Extract content enclosed within <think>...</think> tags from the input
            var think = Regex
                .Match(input, pattern: @"(?<=<think>).*(?=<\/think>)", options: regexOptions)
                .Value
                .Trim();

            // Remove any <think>...</think> sections from the input to isolate the system response
            var systemResponse = Regex
                .Replace(input, pattern: @"<think>.*<\/think>", replacement: string.Empty, options: regexOptions)
                .Trim();

            // Extract token usage statistics from the chat response, defaulting to zero if not present
            var completionTokens = chatResponse?.Usage.CompletionTokens ?? 0;
            var promptTokens = chatResponse?.Usage.PromptTokens ?? 0;
            var totalTokens = chatResponse?.Usage.TotalTokens ?? 0;

            // Store token usage values into session parameters for later reference
            plugin.Invoker.Context.SessionParameters["OpenAiCompletionTokens"] = completionTokens;
            plugin.Invoker.Context.SessionParameters["OpenAiPromptTokens"] = promptTokens;
            plugin.Invoker.Context.SessionParameters["OpenAiTotalTokens"] = totalTokens;

            // Store the extracted think content into a session parameter
            plugin.Invoker.Context.SessionParameters["OpenAiThink"] = think?.ConvertToBase64() ?? string.Empty;

            // Apply the rule's regular expression to the system response, convert the match to Base64, 
            // and store it into a session parameter (or store an empty string if no match)
            var openAiSystemResponse = Regex
                .Match(input: systemResponse, pattern: pluginData.Rule.RegularExpression)?
                .Value
                .ConvertToBase64() ?? string.Empty;
            plugin.Invoker.Context.SessionParameters["OpenAiSystemResponse"] = openAiSystemResponse;

            // Create a new PluginResponseModel to hold the response data
            var pluginResponse = plugin.NewPluginResponse();

            // Populate the Entity property with relevant data extracted from the chat response
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["CompletionTokens"] = completionTokens,
                ["PromptTokens"] = promptTokens,
                ["SystemResponse"] = openAiSystemResponse,
                ["TotalTokens"] = totalTokens,
                ["Think"] = think
            };

            // Return a new PluginResponseModel based on the plugin context and processed data
            return pluginResponse;
        }

        // Sends a chat prompt via HTTP, handles the API response, updates the conversation history,
        // and returns the assistant's reply text.
        private static async Task<ChatResponse> SendPromptAsync(PluginBase plugin, G4RuleModelBase rule, HttpRequestMessage request)
        {
            // Initialize the HTTP response message variable
            HttpResponseMessage response;

            // Attempt to send the HTTP request and ensure a successful status code
            try
            {
                response = await HttpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                // Create an exception model around the caught exception
                var exception = new G4ExceptionModel(rule, exception: e);

                // Add the exception to the plugin's exception list
                plugin.Exceptions.Add(exception);

                // Return an empty string to indicate failure
                return default;
            }

            // Read the raw JSON response content as a string
            var responseContent = await response.Content.ReadAsStringAsync();

            // Return the assistant's message
            return JsonSerializer.Deserialize<ChatResponse>(responseContent, s_jsonOptions);
        }
        #endregion

        #region *** Nested Types       ***
        // Represents a single choice returned by the API, including its message content, index, and finish reason.
        private class Choice
        {
            /// <summary>
            /// Gets or sets the reason why this choice finished (for example, "stop" or "length").
            /// e.g. "stop" indicates the model stopped naturally
            /// </summary>
            public string FinishReason { get; set; }

            /// <summary>
            /// Gets or sets the zero-based index of this choice in the response array.
            /// Position of this choice among multiple choices.
            /// </summary>
            public int Index { get; set; }

            /// <summary>
            /// Gets or sets the message content associated with this choice.
            /// The actual content (role and text) returned for this choice
            /// </summary>
            public Message Message { get; set; }
        }

        // Represents the full response from the chat completion API, including metadata, the list of generated choices,
        // and usage statistics.
        private class ChatResponse
        {
            /// <summary>
            /// Gets or sets the unique identifier for this chat response.
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// Gets or sets the type of the returned object, typically "chat.completion".
            /// </summary>
            public string Object { get; set; }

            /// <summary>
            /// Gets or sets an array of <see cref="Choice"/> instances, each representing one of the model's generated completions.
            /// </summary>
            public Choice[] Choices { get; set; }

            /// <summary>
            /// Gets or sets usage statistics for this API call, such as token counts.
            /// </summary>
            public Usage Usage { get; set; }
        }

        // Represents the request payload for a chat completion API call, including model settings and message history.
        private class ChatRequest
        {
            /// <summary>
            /// Gets or sets the maximum number of tokens allowed in the response.
            /// </summary>
            public int? MaxTokens { get; set; }

            /// <summary>
            /// Gets or sets the sequence of messages (conversation history) to send to the model.
            /// </summary>
            public List<Message> Messages { get; set; }

            /// <summary>
            /// Gets or sets the model identifier to use for this request (e.g., "gpt-4.1-mini").
            /// </summary>
            public string Model { get; set; }

            /// <summary>
            /// Gets or sets the sampling temperature to use, controlling 
            /// randomness (0.0 = deterministic, 1.0 = more random).
            /// </summary>
            public double? Temperature { get; set; }

            /// <summary>
            /// Gets or sets the number of highest-probability tokens to keep for sampling; 0 means disabled.
            /// </summary>
            public int? TopK { get; set; }

            /// <summary>
            /// Gets or sets the cumulative probability threshold for nucleus (top-p) sampling, 
            /// between 0.0 and 1.0.
            /// </summary>
            public double? TopP { get; set; }
        }

        // Represents a single message in the chat exchange, including who sent it and its content.
        private class Message
        {
            /// <summary>
            /// Gets or sets the text content of this message.
            /// </summary>
            public string Content { get; set; }

            /// <summary>
            /// Gets or sets the role of the sender (e.g., "user", "assistant", "system").
            /// </summary>
            public string Role { get; set; }
        }

        // Represents the token usage metrics for a chat completion API call, including how many tokens were 
        // used in the prompt, the completion, and the total combined count.
        private class Usage
        {
            /// <summary>
            /// Gets or sets the number of tokens generated in the completion (the model's response).
            /// </summary>
            public int CompletionTokens { get; set; }

            /// <summary>
            /// Gets or sets the number of tokens contained in the prompt (all messages sent to the model).
            /// </summary>
            public int PromptTokens { get; set; }

            /// <summary>
            /// Gets or sets the total number of tokens used by this API call (prompt tokens + completion tokens).
            /// </summary>
            public int TotalTokens { get; set; }
        }
        #endregion
    }
}
