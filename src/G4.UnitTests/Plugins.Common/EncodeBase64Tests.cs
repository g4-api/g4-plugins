using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Transformers;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("EncodeBase64")]
    [TestCategory("Transformer")]
    [TestCategory("UnitTest")]
    public class EncodeBase64Tests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the EncodeBase64 transformer encodes an empty string when " +
            "OnElement is not set.")]
        public void EncodeBase64NullOnElementTest()
        {
            // Arrange: a transformer rule without an OnElement value.
            var rule = new TransformerRuleModel
            {
                PluginName = "EncodeBase64"
            };

            // Act: invoke the transformer plugin directly.
            var testResult = Invoke<EncodeBase64>(rule);

            // Retrieve the encoded value from the transformer response entity.
            var actual = testResult
                .Response
                .Entity
                .Get(key: ResponseProperties.TransformerResult, defaultValue: default(object));

            // Assert: a missing input is treated as an empty string.
            Assert.AreEqual(expected: string.Empty, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the EncodeBase64 transformer encodes the input text to a " +
            "UTF-8 based Base64 string.")]
        #region *** Data Set ***
        [DataRow("Hello, World!", "SGVsbG8sIFdvcmxkIQ==")]
        [DataRow("", "")]
        [DataRow("Line 1\nLine 2", "TGluZSAxCkxpbmUgMg==")]
        [DataRow("שלום", "16nXnNeV150=")]
        #endregion
        public void EncodeBase64Test(string onElement, string expected)
        {
            // Arrange: a transformer rule whose OnElement holds the value to encode.
            var rule = new TransformerRuleModel
            {
                PluginName = "EncodeBase64",
                OnElement = onElement
            };

            // Act: invoke the transformer plugin directly.
            var testResult = Invoke<EncodeBase64>(rule);

            // Retrieve the encoded value from the transformer response entity.
            var actual = testResult
                .Response
                .Entity
                .Get(key: ResponseProperties.TransformerResult, defaultValue: default(object));

            // Assert: the transformer result is the Base64 encoding of the input text.
            Assert.AreEqual(expected, actual: $"{actual}");
        }

        [TestMethod(DisplayName = "Verify that the EncodeBase64 transformer manifest complies with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<EncodeBase64>();
        }

        [TestMethod(DisplayName = "Verify that the EncodeBase64 transformer is correctly registered and " +
            "operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<EncodeBase64>();
        }
    }
}
