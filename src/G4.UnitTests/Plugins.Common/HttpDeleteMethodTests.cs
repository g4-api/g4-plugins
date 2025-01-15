using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.HttpMethods;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Json;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("HttpDeleteMethod")]
    [TestCategory("UnitTest")]
    public class HttpDeleteMethodTests : TestBase
    {
        [TestMethod(displayName: "Verify that the HttpDeleteMethod plugin named 'Delete' " +
            "complies with the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<HttpDeleteMethod>(pluginName: "Delete");
        }

        [TestMethod(displayName: "Verify that the HttpDeleteMethod plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<HttpDeleteMethod>();
        }

        [TestMethod(displayName: "Verify that the DELETE request returns the expected " +
            "status code and confirmation message.")]
        #region *** Data Set ***
        [DataRow("12345", 200, "Booking canceled successfully")]
        [DataRow("54321", 400, "Invalid booking ID")]
        #endregion
        public void DeleteRequestBasicTest(string id, int expectedStatusCode, string expectedMessage)
        {
            // Serialize an ActionRuleModel with a JSON body for a DELETE request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = $"http://localhost:9002/api/hotels/delete/{id}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpDeleteMethod plugin
            var plugin = Invoke<HttpDeleteMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is as expected
            Assert.AreEqual(expected: expectedStatusCode, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.IsTrue($"{response}".ConvertFromBase64().Contains(expectedMessage));
        }

        [TestMethod(displayName: "Verify that the DELETE request with a JSON body returns " +
            "the expected status code and confirmation message.")]
        #region *** Data Set ***
        [DataRow("12345", 200, "Booking canceled successfully")]
        [DataRow("54321", 400, "Invalid booking ID")]
        #endregion
        public void DeleteRequestWithBodyTest(string id, int expectedStatusCode, string expectedMessage)
        {
            // Serialize an ActionRuleModel with a JSON body for a DELETE request
            var ruleJson = JsonSerializer.Serialize(new ActionRuleModel
            {
                Argument = "{{$ " +
                    $"--url:http://localhost:9002/api/hotels/delete/{id}" +
                    " --Body:{}" +
                    "}}"
            });

            // Invoke the action with the serialized ActionRuleModel and get the HttpDeleteMethod plugin
            var plugin = Invoke<HttpDeleteMethod>(ruleJson).Plugin;

            // Retrieve the status code and response from the plugin's session parameters
            var statusCode = plugin.Invoker.Context.SessionParameters["HttpStatusCode"];
            var response = plugin.Invoker.Context.SessionParameters["HttpResponse"];

            // Assert that the status code is as expected
            Assert.AreEqual(expected: expectedStatusCode, actual: statusCode);

            // Assert that the decoded response contains the expected confirmation message
            Assert.IsTrue($"{response}".ConvertFromBase64().Contains(expectedMessage));
        }
    }
}
