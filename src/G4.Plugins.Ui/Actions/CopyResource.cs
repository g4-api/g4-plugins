using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(CopyResource)}.json")]
    public class CopyResource(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Static instance of HttpClient for making HTTP requests.
        private static readonly HttpClient s_httpClient = new();

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get elements based on the rule and element specified in the PluginDataModel
            var elements = this.GetElements(pluginData.Rule, pluginData.Element);

            // Determine the target path for saving the data
            var path = pluginData.Parameters.TryGetValue("Path", out string pathOut)
                ? pathOut
                : pluginData.Rule.Argument;

            // Create a ConcurrentBag to store file paths in a thread-safe manner
            var files = new ConcurrentBag<string>();

            // Check if the "Parallel" argument is specified
            if (pluginData.Parameters.ContainsKey("Parallel"))
            {
                // If parallel processing is enabled, use Parallel.ForEach for concurrent execution
                var parallelOptions = new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };
                Parallel.ForEach(source: elements, parallelOptions, element =>
                {
                    // Save data for each element and add the file path to the ConcurrentBag
                    var filePath = SaveData(
                        plugin: this,
                        pluginData,
                        element,
                        path,
                        pattern: pluginData.Rule.RegularExpression);
                    files.AddIfNotNullOrEmpty(filePath);
                });
            }
            else
            {
                // If parallel processing is not specified, use regular foreach loop
                foreach (var element in elements)
                {
                    // Save data for each element and add the file path to the ConcurrentBag
                    var filePath = SaveData(
                        plugin: this,
                        pluginData,
                        element,
                        path,
                        pattern: pluginData.Rule.RegularExpression);
                    files.AddIfNotNullOrEmpty(filePath);
                }
            }

            // Store the list of copied resources in the session parameters
            Invoker.Context.SessionParameters["CopiedResources"] = files;

            // Create and return a new PluginResponseModel
            return this.NewPluginResponse();
        }

        // Retrieves the byte array from the specified endpoint. Supports both 'data' URIs and HTTP/HTTPS endpoints.
        private static byte[] GetBytes(PluginBase plugin, string endpoint)
        {
            // Create a URI instance from the specified endpoint
            var uri = new Uri(endpoint);

            // Handle 'data' URIs by extracting and decoding the base64-encoded content
            if (uri.Scheme == "data")
            {
                // Extract the base64-encoded portion of the URI
                string base64Data = uri.OriginalString[(uri.OriginalString.IndexOf(',') + 1)..];

                // Convert the base64 string to a byte array and return it
                return Convert.FromBase64String(base64Data);
            }

            // Create a new HttpRequestMessage with a GET method and the specified endpoint
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            // Make a synchronous GET request to the specified HTTP/HTTPS endpoint
            var responseMessage = s_httpClient.SendAsync(request).Result;

            // Check if the response indicates success (status code 200-299)
            if (!responseMessage.IsSuccessStatusCode)
            {
                // Log a warning with detailed information about the failed request
                plugin.Logger.LogWarning("Failed to retrieve data from the endpoint '{Endpoint}'. Status Code: {StatusCode}, Reason: {ReasonPhrase}",
                    endpoint,
                    responseMessage.StatusCode,
                    responseMessage.ReasonPhrase);

                // Return an empty byte array if the request failed
                return [];
            }

            // Read the content of the response as a byte array and return it
            return responseMessage.Content.ReadAsByteArrayAsync().Result;
        }

        // Action for downloading data from a web element and saving it to a local file
        private static string SaveData(
            PluginBase plugin,
            PluginDataModel pluginData,
            IWebElement element,
            string path,
            string pattern)
        {
            // Determine the endpoint based on the presence of the OnAttribute
            var input = !string.IsNullOrEmpty(pluginData.Rule.OnAttribute)
                ? element.GetAttribute(pluginData.Rule.OnAttribute)
                : element.Text;
            var endpoint = Regex.Match(input, pattern).Value;

            // Call the SaveData method to save data to the specified path and endpoint
            return SaveData(plugin, endpoint, path);
        }

        // Saves data from a specified endpoint to a local file.
        private static string SaveData(PluginBase plugin, string endpoint, string path)
        {
            try
            {
                // Read the content of the response into a byte array
                var buffer = GetBytes(plugin, endpoint);

                // Extract the directory and file name from the provided path
                var directoryName = GetDirectoryName(path);
                var fileName = GetFileName(endpoint, path);

                // Check if the file name is null or empty
                if (string.IsNullOrEmpty(fileName))
                {
                    // Log a warning if the file name is invalid
                    plugin.Logger.LogWarning("Invalid file name for endpoint '{Endpoint}'.", endpoint);
                    return string.Empty;
                }

                // Create the directory if it does not exist
                Directory.CreateDirectory(directoryName);

                // Combine the directory and file name to create the complete file path
                var filePath = Path.Combine(directoryName, fileName);

                // Write the byte array to the specified file path
                File.WriteAllBytes(filePath, buffer);

                // Log a message indicating successful data saving
                plugin.Logger.LogInformation("Data successfully saved from endpoint '{Endpoint}' to '{FilePath}'.",
                    endpoint,
                    filePath);

                return filePath;
            }
            catch (Exception e)
            {
                // Log an error if an exception occurs during the process
                plugin.Logger.LogError(
                    exception: e,
                    message: "An error occurred while saving data from endpoint '{Endpoint}': {Message}",
                    endpoint,
                    e.Message);
                return string.Empty;
            }
        }

        // Gets the directory name from the specified file path.
        private static string GetDirectoryName(string path)
        {
            // If the path is null or empty, return the current directory
            if (string.IsNullOrEmpty(path))
            {
                return Environment.CurrentDirectory;
            }

            // Use Path.GetDirectoryName to get the directory name from the path
            var directoryName = Path.GetDirectoryName(path);

            // If Path.GetDirectoryName returns null or empty, return the original path
            return string.IsNullOrEmpty(directoryName) ? path : directoryName;
        }

        // Gets the file name from the specified endpoint and fallback path.
        private static string GetFileName(string endpoint, string path)
        {
            // Extract the file name from the endpoint URI's absolute path
            var fileName = Path.GetFileName(new Uri(endpoint).AbsolutePath);

            // If the extracted file name is null or empty, use the file name from the fallback path
            return string.IsNullOrEmpty(fileName)
                ? Path.GetFileName(path)
                : fileName;
        }
    }
}
