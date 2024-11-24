using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("RedoNavigation")]
    [TestCategory("UnitTest")]
    public class RedoNavigationTests : TestBase
    {
        [TestMethod(displayName: "Verify that the RedoNavigation plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<RedoNavigation>();
        }

        [TestMethod(displayName: "Verify that the RedoNavigation plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<RedoNavigation>();
        }

        [TestMethod(displayName: "Verify that the RedoNavigation action works with arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""3""}")]
        #endregion
        public void RedoNavigationArgumentTest(string ruleJson)
        {
            // Invoke the RedoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson);
        }

        [TestMethod(displayName: "Verify that the RedoNavigation action works with invalid delay arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:A}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:0x7fffffff}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:2222222222}}""}")]
        #endregion
        public void RedoNavigationDelayArgumentNegativeTest(string ruleJson)
        {
            // Invoke the RedoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson);
        }

        [TestMethod(displayName: "Verify that the RedoNavigation action works with repeat " +
            "and delay arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:1000}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:1000.0}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:00:00:01}}""}")]
        #endregion
        public void RedoNavigationDelayArgumentTest(string ruleJson)
        {
            // Invoke the RedoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson);
        }

        [TestMethod(displayName: "Verify that the RedoNavigation action works with no arguments.")]
        public void RedoNavigationNoArgumentTest()
        {
            // Invoke the RedoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson: @"{""pluginName"":""RedoNavigation""}");
        }

        [TestMethod(displayName: "Verify that the RedoNavigation action works with repeat arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Repeat:3}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:A}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:0.5}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:0x7fffffff}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:2222222222}}""}")]
        #endregion
        public void RedoNavigationRepeatArgumentTest(string ruleJson)
        {
            // Invoke the RedoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson);
        }

        // Invokes the RedoNavigation action using the provided test base and rule JSON,
        // then asserts that no exceptions are present in the plugin or the response.
        private static void InvokeTest(TestBase testBase, string ruleJson)
        {
            // Invoke the RedoNavigation action with the specified action rule
            var testResult = testBase.Invoke<RedoNavigation>(ruleJson);

            // Assert that exceptions are not present in the plugin
            Assert.IsTrue(testResult.Plugin.Exceptions.IsEmpty);

            // Assert that exceptions are not present in the response
            Assert.IsFalse(testResult.Plugin.Exceptions.Any());
        }
    }
}
