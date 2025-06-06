﻿using System.Net.Http;

using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.HttpMethods.Abstraction;

namespace G4.Plugins.Common.HttpMethods
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.HttpMethods.Manifests.{nameof(HttpPatchMethod)}.json")]
    public class HttpPatchMethod(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // This method is called when the plugin is invoked to send a request
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Create a helper that wraps HTTP method logic, passing along configuration
            var methodBase = new HttpMethodPlugin(plugin: this);

            // Determine the URL: use the "Url" parameter if provided, otherwise fall back to the rule's argument
            var requestUri = pluginData.Parameters.Get(
                key: "Url",
                defaultValue: pluginData.Rule.Argument);

            // Create new HttpContent based on the plugin data
            var content = methodBase.NewContent(pluginData);

            // Build the PATCH request message
            var request = new HttpRequestMessage(HttpMethod.Patch, requestUri)
            {
                Content = content
            };

            // Send the request and return the response model
            return methodBase.SendMessage(pluginData, request);
        }
    }
}
