using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.HttpMethods;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Json;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("HttpPostMethod")]
    [TestCategory("UnitTest")]
    public class HttpPostMethodTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the HttpPostMethod plugin named 'Post' " +
            "complies with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<HttpPostMethod>(pluginName: "Post");
        }

        [TestMethod(DisplayName = "Verify that the HttpPostMethod plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<HttpPostMethod>();
        }

        [TestMethod(DisplayName = "Verify that the HTTP POST request with authorization returns " +
            "a status code of 200 and the response contains the custom headers.")]
        public void PostRequestWithAuthorizationPositiveTest()
        {
            // Serialize an ActionRuleModel for the HTTP POST request with custom headers.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Url:http://localhost:9002/api/hotels/connect " +
                    "--Header:Authorization=Basic username:password}}"
            });

            // Invoke the action with the HttpPostMethod plugin.
            var plugin = Invoke<HttpPostMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context.
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var httpResponse = $"{plugin.Invoker.Context.SessionParameters["HttpResponse"]}".ConvertFromBase64();
            var response = Regex
                .Match(input: httpResponse, pattern: @"(?<=Basic\s+)([A-Za-z0-9+/=]+)")
                .Value
                .Trim();

            // Assert that the status code is 200 (OK).
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the custom headers.
            Assert.AreEqual(expected: "username:password", actual: response.ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP POST request with JSON body returns " +
            "a status code of 200 and the response contains the expected confirmation message.")]
        public void PostRequestWithJsonBodyTest()
        {
            // Serialize an ActionRuleModel with a JSON body for a POST request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:{\"hotelName\":\"Luxury Hotel\",\"roomType\":\"Suite\"} " +
                    "--Url:http://localhost:9002/api/hotels/book}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPostMethod plugin
            var plugin = Invoke<HttpPostMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Booking confirmed for Luxury Hotel, Suite", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP POST request with text body and different " +
            "Content-Types returns the expected status code.")]
        #region *** Data Set ***
        [DataRow("application/json", 415)]
        [DataRow("text/plain", 200)]
        #endregion
        public void PostRequestWithTextAndContentTypeBodyTest(string contentType, int expectedStatusCode)
        {
            // Serialize the action rule for sending a POST request.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;RoomType=Suite " +
                    "--Url:http://localhost:9002/api/hotels/book/text " +
                    "--ContentType:" + contentType + "}}"
            });

            // Invoke the action and get the plugin instance.
            var plugin = Invoke<HttpPostMethod>(ruleJson).Plugin;

            // Get the actual HTTP status code from the session parameters.
            var actualStatusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];

            // Assert that the actual status code matches the expected status code.
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [TestMethod(DisplayName = "Verify that the HTTP POST request with text body returns a status " +
            "code of 200 and the response contains the expected confirmation message.")]
        public void PostRequestWithTextBodyTest()
        {
            // Serialize an ActionRuleModel with a text body for a POST request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;RoomType=Suite " +
                    "--Url:http://localhost:9002/api/hotels/book/text}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPostMethod plugin
            var plugin = Invoke<HttpPostMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Booking confirmed for Luxury Hotel, Suite", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP POST request with text body and ASCII " +
            "encoding returns a status code of 200 and the response contains the expected confirmation message.")]
        public void PostRequestWithTextBodyAndEncodingTest()
        {
            // Serialize an ActionRuleModel with a text body for a POST request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;RoomType=Suite " +
                    "--Url:http://localhost:9002/api/hotels/book/text " +
                    "--Encoding:ASCII}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPostMethod plugin
            var plugin = Invoke<HttpPostMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Booking confirmed for Luxury Hotel, Suite", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP POST request with URL-encoded body " +
            "returns a status code of 200 and the response contains the expected confirmation message.")]
        public void PostRequestWithUrlEncodedBodyTest()
        {
            // Create an action rule model with the necessary parameters for booking a hotel with form-urlencoded data
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Url:http://localhost:9002/api/hotels/book/encoded " +
                    "--Field:HotelName=Luxury Hotel " +
                    "--Field:RoomType=Suite " +
                    "--Field:Rating=4.5}}"
            });

            // Invoke the action using the HTTP POST method
            var plugin = Invoke<HttpPostMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the HTTP status code is 200 (OK)
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the confirmation message for the hotel booking
            Assert.Contains("Booking confirmed for Luxury Hotel, Suite", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP POST request with XML body returns " +
            "a status code of 200 and the response contains the expected confirmation message.")]
        public void PostRequestWithXmlBodyTest()
        {
            // Serialize an ActionRuleModel with an XML body for a POST request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:<HotelBookingRequest><HotelName>Luxury Hotel</HotelName><RoomType>Suite</RoomType></HotelBookingRequest> " +
                    "--Url:http://localhost:9002/api/hotels/book/xml}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPostMethod plugin
            var plugin = Invoke<HttpPostMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Booking confirmed for Luxury Hotel, Suite", $"{response}".ConvertFromBase64());
        }
    }
}
