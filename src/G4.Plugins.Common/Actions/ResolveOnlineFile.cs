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
            // Parse the file URI from the rule argument
            var uri = new Uri(pluginData.Rule.Argument);

            // Create and send the GET request synchronously
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = HttpClient.SendAsync(request).Result;

            // Extract HTTP status code
            var statusCode = (int)response.StatusCode;

            // Read the response content as a byte array
            var bytes = response.Content.ReadAsByteArrayAsync().Result;

            // Convert the file bytes to a Base64 string
            var fileData = Convert.ToBase64String(bytes);

            // Extract file metadata: full name, name without extension, and extension
            var fileFullName = Path.GetFileName(uri.LocalPath);
            var fileName = Path.GetFileNameWithoutExtension(fileFullName);
            var fileExtension = Path.GetExtension(fileFullName).TrimStart('.');

            // Determine the file size in bytes
            var fileSize = bytes.LongLength;

            // Store processed values in session parameters (sorted by key)
            Invoker.Context.SessionParameters["ResolvedFileData"] = fileData.ConvertToBase64();
            Invoker.Context.SessionParameters["ResolvedFileExtension"] = fileExtension.ConvertToBase64();
            Invoker.Context.SessionParameters["ResolvedFileName"] = fileName.ConvertToBase64();
            Invoker.Context.SessionParameters["ResolvedFileSize"] = fileSize;
            Invoker.Context.SessionParameters["ResolvedFileStatusCode"] = statusCode;
            Invoker.Context.SessionParameters["ResolvedFileUri"] = uri.AbsolutePath.ConvertToBase64();
            Invoker.Context.SessionParameters["ResolvedFileUri"] = fileFullName.ConvertToBase64();

            // Build and return the plugin response with entity data (sorted by key)
            var pluginResponse = this.NewPluginResponse();
            pluginResponse.Entity = new Dictionary<string, object>
            {
                ["Data"] = fileData,       // Raw Base64 data
                ["Extension"] = fileExtension,
                ["FullName"] = fileFullName,
                ["Name"] = fileName,
                ["Size"] = fileSize,
                ["StatusCode"] = statusCode,
                ["Uri"] = uri.AbsolutePath
            };

            // return the plugin response
            return pluginResponse;
        }
    }
}
