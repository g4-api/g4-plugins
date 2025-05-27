using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(ResolveOnlineFile)}.json")]
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
                // Parse the URI from the rule argument (must be a valid absolute URI)
                uri = new Uri(pluginData.Rule.Argument);

                // Prepare an HTTP GET request for the parsed URI
                request = new HttpRequestMessage(HttpMethod.Get, uri);

                // Send the request synchronously and capture the response
                response = HttpClient.SendAsync(request).Result;
            }
            catch (Exception e)
            {
                // Remove any previously set session parameters related to file resolution
                Invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileData", out _);
                Invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileExtension", out _);
                Invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileName", out _);
                Invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileSize", out _);
                Invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileStatusCode", out _);
                Invoker.Context.SessionParameters.TryRemove(key: "ResolvedFileUri", out _);

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

            // Store the processed values in session parameters (keys in alphabetical order)
            Invoker.Context.SessionParameters["ResolvedFileData"] = data.ConvertToBase64();
            Invoker.Context.SessionParameters["ResolvedFileExtension"] = extension.ConvertToBase64();
            Invoker.Context.SessionParameters["ResolvedFileName"] = name.ConvertToBase64();
            Invoker.Context.SessionParameters["ResolvedFileSize"] = size;
            Invoker.Context.SessionParameters["ResolvedFileStatusCode"] = statusCode;
            Invoker.Context.SessionParameters["ResolvedFileUri"] = uri.AbsoluteUri.ConvertToBase64();

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

        // Creates a new PluginResponseModel with the provided parameters.
        private static PluginResponseModel NewPluginResponse(
            PluginBase plugin, string data, string extension, string fullName, string name, long size, int statusCode, string uri)
        {
            // Build the plugin response
            var pluginResponse = plugin.NewPluginResponse();

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
