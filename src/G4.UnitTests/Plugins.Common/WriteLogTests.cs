using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("WriteLog")]
    [TestCategory("UnitTest")]
    public class WriteLogTests : TestBase
    {
        [TestMethod(displayName: "Verify that the WriteLog plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<WriteLog>();
        }

        [TestMethod(displayName: "Verify that the WriteLog plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<WriteLog>();
        }

        [TestMethod(displayName: "Verify that the WriteLog plugin executes successfully " +
            "without any exceptions.")]
        public void WriteLogTest()
        {
            // Invoke the action and get the plugin instance along with any exceptions
            var exceptions = Invoke(ruleJson: "{\"$type\":\"Action\", \"pluginName\":\"WriteLog\",\"argument\":\"Log Entry.\"}").GetExceptions();

            // Assert that the plugin's exceptions list is empty, indicating success
            Assert.IsTrue(!exceptions.Any());
        }
    }
}
