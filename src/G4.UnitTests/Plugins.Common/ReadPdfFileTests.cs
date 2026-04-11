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
    [TestCategory("ReadPdfFile")]
    [TestCategory("UnitTest")]
    public class ReadPdfFileTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the ReadPdfFile plugin is correctly registered " +
            "and operational.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin type can be discovered and instantiated by the plugin framework.
            AssertPlugin<ReadPdfFile>();
        }

        [TestMethod(DisplayName = "Verify that the ReadPdfFile plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin manifest matches the expected schema and required metadata.
            AssertManifest<ReadPdfFile>();
        }

        [TestMethod(DisplayName = "Verify that ReadPdfFile correctly reads content from a PDF file " +
            "and stores the extracted text in the session parameter.")]
        public void ReadPdfFilePdfTest()
        {
            // Arrange: Create a rule pointing to the text-based PDF resource.
            // No explicit regex is set; the framework default matches the full content.
            var rule = new ActionRuleModel
            {
                PluginName = "ReadPdfFile",
                Argument = "Resources/TextBased.pdf"
            };

            // Act: Execute the rule through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the raw content stored in the session parameter by the plugin.
            // The key follows the namespace:name convention used by AddSessionParameter.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ReadPdfFile:Content", defaultValue: string.Empty)
                .ConvertFromBase64(); ;

            // Assert: The extracted PDF text must contain the known invoice number
            // that is embedded in the file's text layer.
            Assert.Contains("INV-2026-0042", actual);
        }

        [TestMethod(DisplayName = "Verify that ReadPdfFile correctly reads content from a PDF file " +
            "and that the session parameter also contains additional known values.")]
        public void ReadPdfFilePdfWithRegexTest()
        {
            // Arrange: Create a rule with a regex targeting the invoice number.
            // The regex is applied internally to compute fileResult, exercising that code path,
            // but the plugin stores the full raw content in the session parameter.
            var rule = new ActionRuleModel
            {
                PluginName = "ReadPdfFile",
                Argument = "Resources/TextBased.pdf",
                RegularExpression = @"INV-\d{4}-\d{4}"
            };

            // Act: Execute the rule through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the raw content stored in the session parameter.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ReadPdfFile:Content", defaultValue: string.Empty)
                .ConvertFromBase64(); ;

            // Assert: Regardless of the regex, the full raw content is stored.
            // Verify additional known values to confirm multi-page extraction works.
            Assert.Contains("Gravity API", actual);
        }

        [TestMethod(DisplayName = "Verify that ReadPdfFile correctly reads content from a plain-text " +
            "file and stores the full text in the session parameter.")]
        public void ReadPdfFileTextTest()
        {
            // Arrange: Create a rule pointing to the plain-text resource file.
            // No explicit regex is set; the framework default matches the full content.
            var rule = new ActionRuleModel
            {
                PluginName = "ReadPdfFile",
                Argument = "Resources/TextBased.txt"
            };

            // Act: Execute the rule through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the raw content stored in the session parameter by the plugin.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ReadPdfFile:Content", defaultValue: string.Empty)
                .ConvertFromBase64(); ;

            // Assert: The raw text must contain the known customer name present in the file.
            Assert.Contains("Gravity API", actual);
        }

        [TestMethod(DisplayName = "Verify that ReadPdfFile correctly reads content from a plain-text " +
            "file and that the session parameter contains additional known values.")]
        public void ReadPdfFileTextWithRegexTest()
        {
            // Arrange: Create a rule with a regex targeting a specific value.
            // The regex exercises the fileResult computation code path inside the plugin,
            // but the plugin stores the full raw content in the session parameter.
            var rule = new ActionRuleModel
            {
                PluginName = "ReadPdfFile",
                Argument = "Resources/TextBased.txt",
                RegularExpression = @"Gravity API"
            };

            // Act: Execute the rule through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Retrieve the raw content stored in the session parameter.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "ReadPdfFile:Content", defaultValue: string.Empty)
                .ConvertFromBase64();

            // Assert: The full raw content is stored; verify a second distinct known value
            // to confirm the entire file was read, not just the regex match.
            Assert.Contains("INV-2026-0042", actual);
        }
    }
}
