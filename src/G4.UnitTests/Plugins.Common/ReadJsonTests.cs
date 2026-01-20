using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("ReadJson")]
    [TestCategory("UnitTest")]
    public class ReadJsonTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the ReadJson plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin type can be discovered and instantiated by the plugin framework.
            AssertPlugin<ReadJson>();
        }

        [TestMethod(DisplayName = "Verify that the ReadJson plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin manifest matches the expected schema and required metadata.
            AssertManifest<ReadJson>();
        }

        [TestMethod(DisplayName = "Verify that ReadJson correctly extracts an array value from a " +
            "JSON string input.")]
        public void ReadJsonArrayTest()
        {
            // Arrange: Create a rule that targets an array inside a JSON string.
            var rule = new ActionRuleModel
            {
                PluginName = "ReadJson",
                Argument = @"{""id"":1,""tags"":[""a"",""b"",""c""]}",
                OnElement = "$.tags"
            };

            // Act: Execute the rule through the plugin pipeline.
            var responseModel = Invoke([rule]);

            // Extract the Base64-encoded result from the session parameters.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ReadJsonResult", defaultValue: string.Empty);

            // Assert: Verify the decoded result matches the expected JSON array.
            Assert.AreEqual(expected: @"[""a"",""b"",""c""]", actual: actual.ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that ReadJson correctly reads JSON content from a file path.")]
        public void ReadJsonFileTest()
        {
            // Arrange: Create a rule that loads JSON from a file instead of an inline string.
            var rule = new ActionRuleModel
            {
                PluginName = "ReadJson",
                Argument = "Resources/Example.json",
                OnElement = "$.name"
            };

            // Act: Execute the rule.
            var responseModel = Invoke([rule]);

            // Extract the Base64-encoded result from the session parameters.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ReadJsonResult", defaultValue: string.Empty);

            // Assert: Verify the extracted value matches the expected field.
            Assert.AreEqual(expected: "demo", actual: actual.ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that ReadJson correctly extracts multiple matching values " +
            "using a JSONPath filter.")]
        public void ReadJsonMultipleValuesTest()
        {
            // Arrange: Create a JSON payload with multiple matching items.
            var rule = new ActionRuleModel
            {
                PluginName = "ReadJson",
                Argument = @"{""items"":[{""type"":""a"",""value"":1},{""type"":""a"",""value"":2},{""type"":""b"",""value"":3}]}",
                OnElement = "$.items[?(@.type=='a')].value"
            };

            // Act: Execute the rule.
            var responseModel = Invoke([rule]);

            // Extract the Base64-encoded result from the session parameters.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ReadJsonResult", defaultValue: string.Empty);

            // Assert: Verify that only the filtered values are returned.
            Assert.AreEqual(expected: "[1,2]", actual: actual.ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that ReadJson correctly extracts a single scalar value " +
            "from a JSON object.")]
        public void ReadJsonTest()
        {
            // Arrange: Create a simple JSON payload.
            var rule = new ActionRuleModel
            {
                PluginName = "ReadJson",
                Argument = @"{""id"":1,""name"":""demo""}",
                OnElement = "$.name"
            };

            // Act: Execute the rule.
            var responseModel = Invoke([rule]);

            // Extract the Base64-encoded result from the session parameters.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ReadJsonResult", defaultValue: string.Empty);

            // Assert: Verify the extracted value matches the expected result.
            Assert.AreEqual(expected: "demo", actual: actual.ConvertFromBase64());
        }
    }
}
