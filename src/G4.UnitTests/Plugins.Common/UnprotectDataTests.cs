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
    [TestCategory("UnprotectData")]
    [TestCategory("UnitTest")]
    public class UnprotectDataTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the UnprotectData plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<UnprotectData>();
        }

        [TestMethod(DisplayName = "Verify that the UnprotectData plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<UnprotectData>();
        }

        [TestMethod(DisplayName = "Verify that UnprotectData decrypts a protected value and that " +
            "the session parameter contains the original plaintext.")]
        public void UnprotectDataTest()
        {
            // Arrange: pre-encrypt the known plaintext using the same logic as ProtectData,
            // then pass the result as the Value parameter to UnprotectData.
            var protectedValue = "Bar Foo".Encrypt("g4").ConvertToBase64();

            var rule = new ActionRuleModel
            {
                PluginName = "UnprotectData",
                Argument = $"{{{{$ --Value:{protectedValue} --Key:g4}}}}"
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the decrypted result from the session parameter.
            // UnprotectData stores plain decrypted text, so no further decoding is needed.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "UnprotectData:Result", defaultValue: string.Empty);

            // Assert: the recovered value must equal the original plaintext.
            Assert.AreEqual(expected: "Bar Foo", actual: actual);
        }

        [TestMethod(DisplayName = "Verify that UnprotectData does not recover the original plaintext " +
            "when the wrong decryption key is supplied.")]
        public void UnprotectDataWrongKeyTest()
        {
            // Arrange: encrypt with one key, then attempt to decrypt with a different key.
            var protectedValue = "Bar Foo".Encrypt("g4").ConvertToBase64();

            var rule = new ActionRuleModel
            {
                PluginName = "UnprotectData",
                Argument = $"{{{{$ --Value:{protectedValue} --Key:WrongKey}}}}"
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the result from the session parameter.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "UnprotectData:Result", defaultValue: string.Empty);

            // Assert: decrypting with the wrong key must not produce the original plaintext.
            Assert.AreNotEqual(notExpected: "Bar Foo", actual: actual);
        }
    }
}
