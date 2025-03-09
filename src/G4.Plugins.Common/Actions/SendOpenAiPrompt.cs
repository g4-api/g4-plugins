using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace G4.Plugins.Common.Actions
{
    //[G4Plugin(
    //    assembly: "G4.Plugins.OpenAi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
    //    manifest: $"G4.Plugins.OpenAi.Manifests.{nameof(SendOpenAiPrompt)}.json")]
    public class SendOpenAiPrompt(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the API key, system, and user prompts from plugin parameters
            var apiKey = pluginData.Parameters.Get("ApiKey", string.Empty);
            var systemPrompt = pluginData.Parameters.Get("SystemPrompt", string.Empty);
            var userPrompt = pluginData.Parameters.Get("UserPrompt", string.Empty);

            // Validate that the API key and user prompt are provided
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return this.NewPluginResponse();
            }

            if (string.IsNullOrWhiteSpace(userPrompt))
            {
                return this.NewPluginResponse();
            }

            // Call OpenAI API and get response (Placeholder for actual OpenAI call)
            var openAiResponse = GetOpenAiResponseAsync(apiKey, systemPrompt, userPrompt).Result;

            // Return the response from OpenAI API as an output parameter
            return this.NewPluginResponse();
        }

        // Placeholder method for actual OpenAI API call
        private async Task<string> GetOpenAiResponseAsync(string apiKey, string systemPrompt, string userPrompt)
        {
            var authentication =  new AuthenticationHeaderValue("Bearer", "bearerToken");

            using var request = new HttpRequestMessage(HttpMethod.Post, "");
            request.Headers.Authorization = authentication;

            var body = new
            {
                Role = "",
                Stor = false,
                Messages = new[]
                {
                    new
                    {
                        Role = "",
                        Content = systemPrompt
                    },
                    new
                    {
                        Role = "",
                        Content = userPrompt
                    }
                }
            };

            // Here you would integrate your actual OpenAI API logic using the provided apiKey
            // This is a simplified placeholder response
            await Task.Delay(100); // simulate API call delay
            return "This is a mocked response from OpenAI based on provided prompts.";
        }
    }
}
