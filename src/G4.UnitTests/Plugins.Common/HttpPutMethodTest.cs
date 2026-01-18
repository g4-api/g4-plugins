using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.HttpMethods;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Json;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("HttpPutMethod")]
    [TestCategory("UnitTest")]
    public class HttpPutMethodTest : TestBase
    {
        [TestMethod(DisplayName = "Verify that the HttpPutMethod plugin named 'Put' complies " +
            "with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<HttpPutMethod>(pluginName: "Put");
        }

        [TestMethod(DisplayName = "Verify that the HttpPutMethod plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<HttpPutMethod>();
        }

        [TestMethod(DisplayName = "Verify that the HTTP PUT request with JSON body returns " +
            "a status code of 200 and the response contains the expected confirmation message.")]
        public void PutRequestWithJsonBodyTest()
        {
            // Serialize an ActionRuleModel with a JSON body for a PUT request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:{\"hotelName\":\"Luxury Hotel\",\"roomType\":\"Suite\"} " +
                    "--Url:http://localhost:9002/api/hotels/edit}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPutMethod plugin
            var plugin = Invoke<HttpPutMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Hotel information updated for Luxury Hotel", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP PUT request with text body and different" +
            " Content-Types returns the expected status code.")]
        #region *** Data Set ***
        [DataRow("application/json", 415)]
        [DataRow("text/plain", 200)]
        #endregion
        public void PutRequestWithTextAndContentTypeBodyTest(string contentType, int expectedStatusCode)
        {
            // Serialize the action rule for sending a PUT request.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;RoomType=Suite " +
                    "--Url:http://localhost:9002/api/hotels/edit/text " +
                    "--ContentType:" + contentType + "}}"
            });

            // Invoke the action and get the plugin instance.
            var plugin = Invoke<HttpPutMethod>(ruleJson).Plugin;

            // Get the actual HTTP status code from the session parameters.
            var actualStatusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];

            // Assert that the actual status code matches the expected status code.
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [TestMethod(DisplayName = "Verify that the HTTP PUT request with text body returns " +
            "a status code of 200 and the response contains the expected confirmation message.")]
        public void PutRequestWithTextBodyTest()
        {
            // Serialize an ActionRuleModel with a text body for a PUT request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;RoomType=Suite " +
                    "--Url:http://localhost:9002/api/hotels/edit/text}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPutMethod plugin
            var plugin = Invoke<HttpPutMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Hotel information updated for Luxury Hotel", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP PUT request with text body and ASCII " +
            "encoding returns a status code of 200 and the response contains the expected confirmation message.")]
        public void PutRequestWithTextBodyAndEncodingTest()
        {
            // Serialize an ActionRuleModel with a text body for a PUT request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;RoomType=Suite " +
                    "--Url:http://localhost:9002/api/hotels/edit/text " +
                    "--Encoding:ASCII}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPutMethod plugin
            var plugin = Invoke<HttpPutMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Hotel information updated for Luxury Hotel", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP PUT request with URL-encoded body " +
            "returns a status code of 200 and the response contains the expected confirmation message.")]
        public void PutRequestWithUrlEncodedBodyTest()
        {
            // Create an action rule model with the necessary parameters for updating hotel information with form-urlencoded data
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Url:http://localhost:9002/api/hotels/edit/encoded " +
                    "--Field:HotelName=Luxury Hotel " +
                    "--Field:NewInfo=Foo Bar}}"
            });

            // Invoke the action using the HTTP PUT method
            var plugin = Invoke<HttpPutMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the HTTP status code is 200 (OK)
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the confirmation message for the hotel update
            Assert.Contains("Hotel information updated for Luxury Hotel", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP PUT request with XML body returns " +
            "a status code of 200 and the response contains the expected confirmation message.")]
        public void PutRequestWithXmlBodyTest()
        {
            // Serialize an ActionRuleModel with an XML body for a PUT request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:<HotelUpdateRequest><HotelName>Luxury Hotel</HotelName><NewInfo>Foo Bar</NewInfo></HotelUpdateRequest> " +
                    "--Url:http://localhost:9002/api/hotels/edit/xml}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPutMethod plugin
            var plugin = Invoke<HttpPutMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Hotel information updated for Luxury Hotel", $"{response}".ConvertFromBase64());
        }
    }
}
