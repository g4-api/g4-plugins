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
    [TestCategory("ConvertToBase64")]
    [TestCategory("UnitTest")]
    public class ConvertToBase64Tests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the ConvertToBase64 plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<ConvertToBase64>();
        }

        [TestMethod(DisplayName = "Verify that the ConvertToBase64 plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<ConvertToBase64>();
        }

        [TestMethod(DisplayName = "Verify that ConvertToBase64 encodes the full argument to Base64 " +
            "when no RegularExpression is specified.")]
        public void ConvertToBase64Test()
        {
            // Arrange: a plain string with no regex — the full value should be encoded.
            var rule = new ActionRuleModel
            {
                PluginName = "ConvertToBase64",
                Argument = "Hello, World!"
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the Base64-encoded result from the session and decode it.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ConvertToBase64:Result", defaultValue: string.Empty)
                .ConvertFromBase64();

            // Assert: the decoded value must match the original argument.
            Assert.AreEqual(expected: "Hello, World!", actual: actual);
        }

        [TestMethod(DisplayName = "Verify that ConvertToBase64 encodes only the first regex-matched " +
            "portion of the argument.")]
        public void ConvertToBase64WithRegexTest()
        {
            // Arrange: a mixed string with a regex that targets numeric sequences only.
            var rule = new ActionRuleModel
            {
                PluginName = "ConvertToBase64",
                Argument = "Order-12345-Details",
                RegularExpression = @"\d+"
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the Base64-encoded result from the session and decode it.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ConvertToBase64:Result", defaultValue: string.Empty)
                .ConvertFromBase64();

            // Assert: only the first matched numeric sequence is encoded, not the full string.
            Assert.AreEqual(expected: "12345", actual: actual);
        }

        [TestMethod(DisplayName = "Verify that ConvertToBase64 stores an empty Base64 string when " +
            "the RegularExpression produces no match.")]
        public void ConvertToBase64NoMatchTest()
        {
            // Arrange: a string that contains no digits, paired with a digits-only regex.
            var rule = new ActionRuleModel
            {
                PluginName = "ConvertToBase64",
                Argument = "no-digits-here",
                RegularExpression = @"^\d+$"
            };

            // Act: execute through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the Base64-encoded result from the session and decode it.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ConvertToBase64:Result", defaultValue: string.Empty)
                .ConvertFromBase64();

            // Assert: the regex matched nothing, so the encoded value decodes to an empty string.
            Assert.AreEqual(expected: string.Empty, actual: actual);
        }
    }
}
