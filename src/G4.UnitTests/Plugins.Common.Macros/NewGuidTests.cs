using G4.Plugins.Common.Macros;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Data;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Common.Macros
{
    [TestClass]
    [TestCategory("NewGuid")]
    [TestCategory("UnitTest")]
    public class NewGuidTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the NewGuid plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<NewGuid>(pluginName: "New-Guid");
        }

        [TestMethod(DisplayName = "Verify that the NewGuid plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<NewGuid>();
        }

        [TestMethod(DisplayName = "Verify that the NewGuid plugin correctly generates GUIDs in various formats.")]
        #region *** Data Set ***
        [DataRow("{\"argument\":\"{{$New-Guid --Format:N}}\"}", @"^\w{32}$")]
        [DataRow("{\"argument\":\"{{$New-Guid --Format:D}}\"}", @"^\w{8}-(\w{4}-){3}\w{12}$")]
        [DataRow("{\"argument\":\"{{$New-Guid --Format:B}}\"}", @"^\{\w{8}-(\w{4}-){3}\w{12}\}$")]
        [DataRow("{\"argument\":\"{{$New-Guid --Format:P}}\"}", @"^\(\w{8}-(\w{4}-){3}\w{12}\)$")]
        [DataRow("{\"argument\":\"{{$New-Guid --Format:X}}\"}", @"^\{0x\w{8},0x\w{4},0x\w{4},\{0x\w{2},0x\w{2},0x\w{2},0x\w{2},0x\w{2},0x\w{2},0x\w{2},0x\w{2}\}\}$")]
        #endregion
        public void NewGuidFormatTest(string ruleJson, string expectedPattern)
        {
            // Invoke the NewGuid action with the specified format and retrieve the response model.
            var actual = Invoke<NewGuid>(ruleJson).Response;

            // Assert that the response model contains the expected result.
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Assert that the resulting GUID string matches the expected pattern using regular expression.
            Assert.IsTrue(Regex.IsMatch(input: $"{actual.Entity[MacroResultKey]}", pattern: expectedPattern));
        }

        [TestMethod(DisplayName = "Verify that the NewGuid plugin correctly generates GUIDs " +
            "matching the specified pattern.")]
        public void NewGuidPatternTest()
        {
            // Invoke the NewGuid action with the specified pattern and retrieve the response model.
            var actual = Invoke<NewGuid>(ruleJson: "{\"argument\":\"{{$New-Guid --Pattern:\\\\w{2}}}\"}").Response;

            // Assert that the response model contains the expected result.
            Assert.IsTrue(actual.Entity.ContainsKey(MacroResultKey));

            // Assert that the resulting GUID string matches the expected pattern using a regular expression.
            Assert.IsTrue(Regex.IsMatch(input: $"{actual.Entity[MacroResultKey]}", pattern: @"^\w{2}$"));
        }

        [TestMethod(DisplayName = "Verify that the NewGuid plugin generates a valid GUID " +
            "in the default format.")]
        public void NewGuidTest()
        {
            // Invoke the NewGuid action with the provided action rule to generate a new GUID macro.
            var input = Invoke<NewGuid>(ruleJson: "{\"argument\":\"{{$New-Guid}}\"}")
                .Response
                .Entity[MacroResultKey]
                .ToString();

            // Assert that the generated GUID macro matches the expected pattern.
            Assert.IsTrue(Regex.IsMatch(input, @"^\w{8}-(\w{4}-){3}\w{12}$"));
        }
    }
}
