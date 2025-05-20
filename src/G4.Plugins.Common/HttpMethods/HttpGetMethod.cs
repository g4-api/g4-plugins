﻿using System.Net.Http;

using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.HttpMethods.Abstraction;

namespace G4.Plugins.Common.HttpMethods
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.HttpMethods.Manifests.{nameof(HttpGetMethod)}.json")]
    public class HttpGetMethod(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
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

            // Build the GET request message
            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri);

            // Send the request and return the response model
            return methodBase.SendMessage(pluginData, request);
        }
    }
}
