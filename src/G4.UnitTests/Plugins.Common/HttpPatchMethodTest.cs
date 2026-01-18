using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.HttpMethods;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Json;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("HttpPatchMethod")]
    [TestCategory("UnitTest")]
    public class HttpPatchMethodTest : TestBase
    {
        [TestMethod(DisplayName = "Verify that the HttpPatchMethod plugin named 'Patch' " +
            "complies with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<HttpPatchMethod>(pluginName: "Patch");
        }

        [TestMethod(DisplayName = "Verify that the HttpPatchMethod plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<HttpPatchMethod>();
        }

        [TestMethod(DisplayName = "Verify that the HTTP PATCH request with a JSON body " +
            "returns a status code of 200 and the response contains the expected confirmation message.")]
        public void PatchRequestWithJsonBodyTest()
        {
            // Serialize an ActionRuleModel with a JSON body for a PATCH request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:{\"hotelName\":\"Luxury Hotel\",\"review\":\"Suite\"} " +
                    "--Url:http://localhost:9002/api/hotels/update}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPatchMethod plugin
            var plugin = Invoke<HttpPatchMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Review posted for Luxury Hotel", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP PATCH request with text body and different " +
            "Content-Types returns the expected status code.")]
        #region *** Data Set ***
        [DataRow("application/json", 415)]
        [DataRow("text/plain", 200)]
        #endregion
        public void PatchRequestWithTextAndContentTypeBodyTest(string contentType, int expectedStatusCode)
        {
            // Serialize the action rule for sending a PATCH request.
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;Review=Suite " +
                    "--Url:http://localhost:9002/api/hotels/update/text " +
                    "--ContentType:" + contentType + "}}"
            });

            // Invoke the action and get the plugin instance.
            var plugin = Invoke<HttpPatchMethod>(ruleJson).Plugin;

            // Get the actual HTTP status code from the session parameters.
            var actualStatusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];

            // Assert that the actual status code matches the expected status code.
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [TestMethod(DisplayName = "Verify that the HTTP PATCH request with text body and ASCII " +
            "encoding returns a status code of 200 and the response contains the expected confirmation message.")]
        public void PatchRequestWithTextBodyAndEncodingTest()
        {
            // Serialize an ActionRuleModel with a text body for a PATCH request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;Review=Suite " +
                    "--Url:http://localhost:9002/api/hotels/update/text " +
                    "--Encoding:ASCII}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPatchMethod plugin
            var plugin = Invoke<HttpPatchMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Review posted for Luxury Hotel", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP PATCH request with text body returns " +
            "a status code of 200 and the response contains the expected confirmation message.")]
        public void PatchRequestWithTextBodyTest()
        {
            // Serialize an ActionRuleModel with a text body for a PATCH request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:HotelName=Luxury Hotel;Review=Suite " +
                    "--Url:http://localhost:9002/api/hotels/update/text}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPatchMethod plugin
            var plugin = Invoke<HttpPatchMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Review posted for Luxury Hotel", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP PATCH request with URL-encoded body returns " +
            "a status code of 200 and the response contains the expected confirmation message.")]
        public void PatchRequestWithUrlEncodedBodyTest()
        {
            // Create an action rule model with the necessary parameters for updating hotel information with form-urlencoded data
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Url:http://localhost:9002/api/hotels/update/encoded " +
                    "--Field:HotelName=Luxury Hotel " +
                    "--Field:NewInfo=Foo Bar}}"
            });

            // Invoke the action using the HTTP PATCH method
            var plugin = Invoke<HttpPatchMethod>(ruleJson).Plugin;

            // Retrieve the HTTP status code and response from the plugin context
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the HTTP status code is 200 (OK)
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the response contains the confirmation message for the hotel update
            Assert.Contains("Review posted for Luxury Hotel", $"{response}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that the HTTP PATCH request with XML body returns a status " +
            "code of 200 and the response contains the expected confirmation message.")]
        public void PatchRequestWithXmlBodyTest()
        {
            // Serialize an ActionRuleModel with an XML body for a PATCH request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    "--Body:<HotelReviewRequest><HotelName>Luxury Hotel</HotelName><Review>Foo Bar</Review></HotelReviewRequest> " +
                    "--Url:http://localhost:9002/api/hotels/update/xml}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpPatchMethod plugin
            var plugin = Invoke<HttpPatchMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is 200
            Assert.AreEqual(expected: 200, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.Contains("Review posted for Luxury Hotel", $"{response}".ConvertFromBase64());
        }
    }
}
