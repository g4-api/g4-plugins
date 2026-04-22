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
    [TestCategory("ConvertFromBase64")]
    [TestCategory("UnitTest")]
    public class ConvertFromBase64Tests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the ConvertFromBase64 plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ConvertFromBase64>();
        }

        [TestMethod(DisplayName = "Verify that the ConvertFromBase64 plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ConvertFromBase64>();
        }

        [TestMethod(DisplayName = "Verify that ConvertFromBase64 decodes the full Base64 argument " +
            "when no RegularExpression is specified.")]
        public void ConvertFromBase64Test()
        {
            // Arrange: "Hello, World!" encoded to Base64 — no regex, full decoded value expected.
            var rule = new ActionRuleModel
            {
                PluginName = "ConvertFromBase64",
                Argument = "SGVsbG8sIFdvcmxkIQ=="
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the decoded result directly from the session parameter.
            // The plugin stores the plain decoded string (not re-encoded), so no ConvertFromBase64 call is needed here.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ConvertFromBase64:Result", defaultValue: string.Empty);

            // Assert: the decoded value must match the original pre-encoded text.
            Assert.AreEqual(expected: "Hello, World!", actual: actual);
        }

        [TestMethod(DisplayName = "Verify that ConvertFromBase64 keeps only the first regex-matched " +
            "portion of the decoded string.")]
        public void ConvertFromBase64WithRegexTest()
        {
            // Arrange: "Order-12345-Details" encoded to Base64, regex targets numeric sequences only.
            var rule = new ActionRuleModel
            {
                PluginName = "ConvertFromBase64",
                Argument = "T3JkZXItMTIzNDUtRGV0YWlscw==",
                RegularExpression = @"\d+"
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the result from the session parameter.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ConvertFromBase64:Result", defaultValue: string.Empty);

            // Assert: only the first numeric sequence of the decoded string is kept.
            Assert.AreEqual(expected: "12345", actual: actual);
        }

        [TestMethod(DisplayName = "Verify that ConvertFromBase64 stores an empty string when the " +
            "RegularExpression produces no match on the decoded value.")]
        public void ConvertFromBase64NoMatchTest()
        {
            // Arrange: "no-digits-here" encoded to Base64, paired with a digits-only regex.
            var rule = new ActionRuleModel
            {
                PluginName = "ConvertFromBase64",
                Argument = "bm8tZGlnaXRzLWhlcmU=",
                RegularExpression = @"^\d+$"
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the result from the session parameter.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ConvertFromBase64:Result", defaultValue: string.Empty);

            // Assert: the regex matched nothing in the decoded string, so the result is empty.
            Assert.AreEqual(expected: string.Empty, actual: actual);
        }
    }
}
