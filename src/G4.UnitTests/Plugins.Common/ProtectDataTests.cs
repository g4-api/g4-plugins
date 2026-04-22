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
    [TestCategory("ProtectData")]
    [TestCategory("UnitTest")]
    public class ProtectDataTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the ProtectData plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ProtectData>();
        }

        [TestMethod(DisplayName = "Verify that the ProtectData plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ProtectData>();
        }

        [TestMethod(DisplayName = "Verify that ProtectData encrypts the value and that decoding " +
            "and decrypting the result recovers the original plaintext.")]
        public void ProtectDataTest()
        {
            // Arrange: supply a known plaintext value and encryption key.
            var rule = new ActionRuleModel
            {
                PluginName = "ProtectData",
                Argument = "{{$ --Value:Bar Foo --Key:g4}}"
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the Base64-encoded encrypted result from the session parameter.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ProtectData:Result", defaultValue: string.Empty);

            // Assert: decoding from Base64 then decrypting with the same key must recover
            // the original plaintext value.
            Assert.AreEqual(expected: "Bar Foo", actual: actual.ConvertFromBase64().Decrypt("g4"));
        }

        [TestMethod(DisplayName = "Verify that ProtectData produces different outputs for the " +
            "same value when different encryption keys are used.")]
        public void ProtectDataDifferentKeysTest()
        {
            // Arrange: two rules with the same Value but different Keys.
            var rule1 = new ActionRuleModel
            {
                PluginName = "ProtectData",
                Argument = "{{$ --Value:Bar Foo --Key:KeyOne}}"
            };

            var rule2 = new ActionRuleModel
            {
                PluginName = "ProtectData",
                Argument = "{{$ --Value:Bar Foo --Key:KeyTwo}}"
            };

            // Act: execute both rules independently.
            var result1 = Invoke([rule1])
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ProtectData:Result", defaultValue: string.Empty);

            var result2 = Invoke([rule2])
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ProtectData:Result", defaultValue: string.Empty);

            // Assert: the same plaintext encrypted with different keys must produce different outputs.
            Assert.AreNotEqual(notExpected: result1, actual: result2);
        }
    }
}
