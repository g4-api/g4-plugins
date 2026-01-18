using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("CopyResource")]
    [TestCategory("UnitTest")]
    public class CopyResourceTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the CopyResource plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the CopyResource plugin is correct
            AssertManifest<CopyResource>();
        }

        [TestMethod(DisplayName = "Verify that the CopyResource plugin is correctly " +
            "registered and operational.")]
        public override void NewPluginTest()
        {
            // Assert that the CopyResource plugin can be created successfully
            AssertPlugin<CopyResource>();
        }
    }
}
