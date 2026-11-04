using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Transformers;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("DecodeBase64")]
    [TestCategory("Transformer")]
    [TestCategory("UnitTest")]
    public class DecodeBase64Tests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the DecodeBase64 transformer returns the input unchanged when " +
            "it is not a valid Base64 value.")]
        public void DecodeBase64InvalidValueTest()
        {
            // Arrange: a transformer rule whose OnElement is not a valid Base64 value.
            var rule = new TransformerRuleModel
            {
                PluginName = "DecodeBase64",
                OnElement = "Not Base64!"
            };

            // Act: invoke the transformer plugin directly.
            var testResult = Invoke<DecodeBase64>(rule);

            // Retrieve the transformer result from the transformer response entity.
            var actual = testResult
                .Response
                .Entity
                .Get(key: ResponseProperties.TransformerResult, defaultValue: default(object));

            // Assert: the invalid value passes through without a failure.
            Assert.AreEqual(expected: "Not Base64!", actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the DecodeBase64 transformer decodes an empty string when " +
            "OnElement is not set.")]
        public void DecodeBase64NullOnElementTest()
        {
            // Arrange: a transformer rule without an OnElement value.
            var rule = new TransformerRuleModel
            {
                PluginName = "DecodeBase64"
            };

            // Act: invoke the transformer plugin directly.
            var testResult = Invoke<DecodeBase64>(rule);

            // Retrieve the decoded value from the transformer response entity.
            var actual = testResult
                .Response
                .Entity
                .Get(key: ResponseProperties.TransformerResult, defaultValue: default(object));

            // Assert: a missing input is treated as an empty string.
            Assert.AreEqual(expected: string.Empty, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the DecodeBase64 transformer decodes a Base64 value to " +
            "UTF-8 text.")]
        #region *** Data Set ***
        [DataRow("SGVsbG8sIFdvcmxkIQ==", "Hello, World!")]
        [DataRow("", "")]
        [DataRow("TGluZSAxCkxpbmUgMg==", "Line 1\nLine 2")]
        [DataRow("16nXnNeV150=", "שלום")]
        #endregion
        public void DecodeBase64Test(string onElement, string expected)
        {
            // Arrange: a transformer rule whose OnElement holds the Base64 value to decode.
            var rule = new TransformerRuleModel
            {
                PluginName = "DecodeBase64",
                OnElement = onElement
            };

            // Act: invoke the transformer plugin directly.
            var testResult = Invoke<DecodeBase64>(rule);

            // Retrieve the decoded value from the transformer response entity.
            var actual = testResult
                .Response
                .Entity
                .Get(key: ResponseProperties.TransformerResult, defaultValue: default(object));

            // Assert: the transformer result is the decoded UTF-8 text.
            Assert.AreEqual(expected, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the DecodeBase64 transformer manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<DecodeBase64>();
        }

        [TestMethod(DisplayName = "Verify that the DecodeBase64 transformer is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<DecodeBase64>();
        }
    }
}
