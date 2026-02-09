using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("WriteHost")]
    [TestCategory("UnitTest")]
    public class WriteHostTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the WriteHost plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<WriteHost>();
        }

        [TestMethod(DisplayName = "Verify that the WriteHost plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<WriteHost>();
        }

        [DoNotParallelize]
        [TestMethod(DisplayName = "Verify that the WriteHost plugin executes successfully " +
            "without any exceptions.")]
        public void WriteHostTest()
        {
            // Preserve the original console output stream
            var standardOutput = Console.Out;

            // Redirect Console.Out to capture output for assertion
            using var writer = new StringWriter();
            Console.SetOut(writer);

            // Execute the WriteHost action and collect any thrown exceptions
            var exceptions = Invoke(
                ruleJson: "{\"$type\":\"Action\", \"pluginName\":\"WriteHost\",\"argument\":\"Log Entry.\"}"
            ).GetExceptions();

            // Restore the original console output
            Console.SetOut(standardOutput);

            // Retrieve captured console output
            var output = writer.ToString();

            // Assert that the expected log message was written
            Assert.Contains("Log Entry.", output);

            // Ensure no exceptions occurred during execution
            Assert.IsFalse(exceptions.Any());
        }
    }
}
