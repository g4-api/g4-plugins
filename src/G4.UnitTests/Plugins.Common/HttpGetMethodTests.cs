using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.HttpMethods;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Text.Json;
using System.Text.RegularExpressions;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("HttpGetMethod")]
    [TestCategory("UnitTest")]
    public class HttpGetMethodTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the HttpGetMethod plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<HttpGetMethod>();
        }

        [TestMethod(DisplayName = "Verify that the HttpGetMethod plugin named 'Get' " +
            "complies with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<HttpGetMethod>(pluginName: "Get");
        }

        [TestMethod(DisplayName = "Verify that the HTTP GET request returns a status code " +
            "of 200 (OK) and the response content is in JSON format.")]
        public void GetRequestPositiveTest()
        {
            // Serialize an ActionRuleModel for the HTTP GET request.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ --Url:http://localhost:9002/api/hotels/find}}"
            });

            // Invoke the action with the HttpGetMethod plugin.
            var plugin = Invoke<HttpGetMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200 (OK).
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response content is in JSON format.
            Assert.IsTrue($"{response}".ConvertFromBase64().AssertJson());
        }

        [TestMethod(DisplayName = "Verify that the HTTP GET request returns a status code " +
            "of 200 (OK) and the response content is in XML format.")]
        public void GetRequestPositiveXmlTest()
        {
            // Serialize an ActionRuleModel for the HTTP GET request.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ --Url:http://localhost:9002/api/hotels/find/xml}}"
            });

            // Invoke the action with the HttpGetMethod plugin.
            var plugin = Invoke<HttpGetMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200 (OK).
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response content is in XML format.
            Assert.IsTrue($"{response}".ConvertFromBase64().AssertXml());
        }

        [TestMethod(DisplayName = "Verify that the HTTP GET request with authorization returns " +
            "a status code of 405 and the response contains the custom headers.")]
        public void GetRequestWithAuthorizationPositiveTest()
        {
            // Serialize an ActionRuleModel for the HTTP GET request with custom headers.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Url:http://localhost:9002/api/hotels/connect " +
                    "--Header:Authorization=Basic username:password}}"
            });

            // Invoke the action with the HttpGetMethod plugin.
            var plugin = Invoke<HttpGetMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var httpResponse = $"{plugin.Invoker.Context.SessionParameters["HttpResponse"]}".ConvertFromBase64();
            var response = Regex
                .Match(input: httpResponse, pattern: @"(?<=Basic\s+)([A-Za-z0-9+/=]+)")
                .Value
                .Trim();

            // Assert that the status code is 405 (Method Not Allowed).
            Assert.AreEqual(expected: 405, actual: statusCode);

            // Assert that the response contains the custom headers.
            Assert.IsTrue(response.Equals(string.Empty));
        }

        [TestMethod(DisplayName = "Verify that the HTTP GET request with custom headers returns " +
            "a status code of 200 (OK) and the response contains the custom headers.")]
        public void GetRequestWithHeadersPositiveTest()
        {
            // Serialize an ActionRuleModel for the HTTP GET request with custom headers.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Url: http://localhost:9002/api/hotels/headers " +
                    "--Header:Authorization=Bearer YourAccessToken " +
                    "--Header:ContentType=application/json " +
                    "--Header:UserAgent=MyCustomUserAgent " +
                    "}}"
            });

            // Invoke the action with the HttpGetMethod plugin.
            var plugin = Invoke<HttpGetMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = $"{plugin.Invoker.Context.SessionParameters["HttpResponse"]}".ConvertFromBase64();

            // Assert that the status code is 200 (OK).
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the custom headers.
            Assert.IsTrue(response.Contains("Authorization", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(response.Contains("Bearer YourAccessToken", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(response.Contains("ContentType", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(response.Contains("application/json", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(response.Contains("UserAgent", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(response.Contains("MyCustomUserAgent", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod(DisplayName = "Verify that the HTTP GET request returns a status code of 200 (OK) " +
            "and the response contains the expected data extracted using JSONPath.")]
        public void GetRequestWithJsonPathTest()
        {
            // Serialize an ActionRuleModel for the HTTP GET request with JSONPath extraction.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ --Url:http://localhost:9002/api/hotels/find}}",
                OnElement = "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight"
            });

            // Invoke the action with the HttpGetMethod plugin.
            var plugin = Invoke<HttpGetMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200 (OK).
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the expected data extracted using JSONPath.
            Assert.IsTrue($"{response}".ConvertFromBase64().Equals("250"));
        }

        [TestMethod(DisplayName = "Verify that the HTTP GET request returns a status code of 200 (OK) " +
            "and the response contains the expected data extracted using both Regular Expression and JSONPath.")]
        public void GetRequestWithRegularExpressionAndJsonPath()
        {
            // Serialize an ActionRuleModel for the HTTP GET request with Regular Expression and JSONPath extraction.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ --Url:http://localhost:9002/api/hotels/find}}",
                OnElement = "$.hotels[?(@.name=='Luxury Hotel')].pricePerNight",
                RegularExpression = "\\d{2}"
            });

            // Invoke the action with the HttpGetMethod plugin.
            var plugin = Invoke<HttpGetMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200 (OK).
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the expected data extracted using both Regular Expression and JSONPath.
            Assert.IsTrue($"{response}".ConvertFromBase64().Equals("25"));
        }

        [TestMethod(DisplayName = "Verify that the HTTP GET request returns a status code of 200 (OK) " +
            "and the response contains the expected data extracted using Regular Expression.")]
        public void GetRequestWithRegularExpressionTest()
        {
            // Serialize an ActionRuleModel for the HTTP GET request with Regular Expression extraction.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ --Url:http://localhost:9002/api/hotels/find}}",
                RegularExpression = "(?s)(?<=\"Luxury Hotel\".*\"pricePerNight\":(\\s+)?)250"
            });

            // Invoke the action with the HttpGetMethod plugin.
            var plugin = Invoke<HttpGetMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200 (OK).
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the expected data extracted using Regular Expression.
            Assert.IsTrue($"{response}".ConvertFromBase64().Equals("250"));
        }

        [TestMethod(DisplayName = "Verify that the HTTP GET request returns a status code of 200 (OK) " +
            "and the response contains the expected data extracted using XPath.")]
        public void GetRequestWithXpathTest()
        {
            // Serialize an ActionRuleModel for the HTTP GET request with XPath extraction.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ --Url:http://localhost:9002/api/hotels/find/xml}}",
                OnElement = "//HotelResult[./Name[.='Luxury Hotel']]",
                OnAttribute = "PricePerNight"
            });

            // Invoke the action with the HttpGetMethod plugin.
            var plugin = Invoke<HttpGetMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200 (OK).
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the expected data extracted using XPath.
            Assert.IsTrue($"{response}".ConvertFromBase64().Equals("250"));
        }
    }
}
