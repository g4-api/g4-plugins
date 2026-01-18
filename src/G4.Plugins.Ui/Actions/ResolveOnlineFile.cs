using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Engine;
using G4.WebDriver.Remote;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(ResolveOnlineFile)}.json")]
    public class ResolveOnlineFile(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Initialize the parameters for the HTTP client
            Uri uri;
            HttpRequestMessage request;
            HttpResponseMessage response;

            try
            {
                // Get the web element based on the rule and element in the plugin data.
                var element = this.GetElement(pluginData.Rule, pluginData.Element);

                // Get the URL to navigate to.
                var resolvedUri = GetUri(pluginData.Rule, element);

                // Parse the URI from the rule argument (must be a valid absolute URI)
                uri = new Uri(resolvedUri);

                // Prepare an HTTP GET request for the parsed URI
                request = new HttpRequestMessage(HttpMethod.Get, uri);

                // Send the request synchronously and capture the response
                response = HttpClient.SendAsync(request).Result;
            }
            catch (Exception e)
            {
                // Remove any previously set session parameters related to file resolution
                CleanSessionParameters(Invoker);

                // If an exception occurs while sending the request, log it as a G4ExceptionModel.
                Exceptions.Add(new G4ExceptionModel(rule: pluginData.Rule, exception: e.GetBaseException()));

                // Return the populated response back to the caller
                return NewPluginResponse(
                    plugin: this,
                    data: string.Empty,
                    extension: string.Empty,
                    fullName: string.Empty,
                    name: string.Empty,
                    size: 0,
                    statusCode: 400,
                    uri: string.Empty);
            }

            // Convert status code to integer
            var statusCode = (int)response.StatusCode;

            // Read the entire response content as a byte array
            var bytes = response.Content.ReadAsByteArrayAsync().Result;

            // Encode the byte array as a Base64 string
            var data = Convert.ToBase64String(bytes);

            // Extract file name components from the URI's local path
            var fullName = Path.GetFileName(uri.LocalPath);
            var name = Path.GetFileNameWithoutExtension(fullName);
            var extension = Path.GetExtension(fullName).TrimStart('.');

            // Determine the file size in bytes
            var size = bytes.LongLength;

            // Return the populated response back to the caller
            return NewPluginResponse(
                plugin: this,
                data,
                extension,
                fullName,
                name,
                size,
                statusCode,
                uri: uri.AbsoluteUri);
        }

        // Cleans up session parameters related to file resolution.
        private static void CleanSessionParameters(IAutomationInvoker invoker)
        {
            // Remove any previously set session parameters related to file resolution
            invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileData", out _);
            invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileExtension", out _);
            invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileFullName", out _);
            invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileName", out _);
            invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileSize", out _);
            invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileStatusCode", out _);
            invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileUri", out _);
        }

        // Gets the URI based on the provided action rule and web element.
        private static string GetUri(G4RuleModelBase rule, IWebElement element)
        {
            // If the element is not found, return the URL from the rule argument.
            if (element == default)
            {
                return rule.Argument;
            }

            // If OnAttribute is not specified, use the element's text content as the URL.
            // Otherwise, get the URL from the specified attribute.
            var url = string.IsNullOrEmpty(rule.OnAttribute)
                ? element.Text
                : element.GetAttribute(rule.OnAttribute);

            // Use regular expression to match and extract the desired part of the URL.
            var match = Regex.Match(
                input: url,
                pattern: rule.RegularExpression);

            // Return the desired part of the URL.
            return match.Value;
        }

        // Creates a new PluginResponseModel with the provided parameters.
        private static PluginResponseModel NewPluginResponse(
            PluginBase plugin, string data, string extension, string fullName, string name, long size, int statusCode, string uri)
        {
            // Build the plugin response
            var pluginResponse = plugin.NewPluginResponse();

            // Store the processed values in session parameters (keys in alphabetical order)
            plugin.Invoker.Context.SessionParameters["ResolvedFileData"] = data.ConvertToBase64();
            plugin.Invoker.Context.SessionParameters["ResolvedFileExtension"] = extension.ConvertToBase64();
            plugin.Invoker.Context.SessionParameters["ResolvedFileFullName"] = fullName;
            plugin.Invoker.Context.SessionParameters["ResolvedFileName"] = name.ConvertToBase64();
            plugin.Invoker.Context.SessionParameters["ResolvedFileSize"] = size;
            plugin.Invoker.Context.SessionParameters["ResolvedFileStatusCode"] = statusCode;
            plugin.Invoker.Context.SessionParameters["ResolvedFileUri"] = uri.ConvertToBase64();

            // Populate the Entity dictionary with the provided parameters
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["Data"] = data,
                ["Extension"] = extension,
                ["FullName"] = fullName,
                ["Name"] = name,
                ["Size"] = size,
                ["StatusCode"] = statusCode,
                ["Uri"] = uri
            };

            // Return the populated response back to the caller
            return pluginResponse;
        }
    }
}
