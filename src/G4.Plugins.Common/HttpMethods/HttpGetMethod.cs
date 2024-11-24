using G4.Attributes;
using G4.Models;
using G4.Plugins.Common.HttpMethods.Abstraction;

using System.Collections.Generic;
using System.Net.Http;

namespace G4.Plugins.Common.HttpMethods
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.HttpMethods.Manifests.{nameof(HttpGetMethod)}.json")]
    public class HttpGetMethod(G4PluginSetupModel pluginSetup) : HttpMethodBase(pluginSetup)
    {
        protected override HttpRequestMessage NewRequestMessage(
            PluginDataModel pluginData, string url, IDictionary<string, string> headers)
        {
            // Create an HTTP GET request with the specified URL.
            return new HttpRequestMessage(HttpMethod.Get, url);
        }
    }
}
