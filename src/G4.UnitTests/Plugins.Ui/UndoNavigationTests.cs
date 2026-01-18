using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("UndoNavigation")]
    [TestCategory("UnitTest")]
    public class UndoNavigationTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the UndoNavigation plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<UndoNavigation>();
        }

        [TestMethod(DisplayName = "Verify that the UndoNavigation plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<UndoNavigation>();
        }

        [TestMethod(DisplayName = "Verify that the UndoNavigation action works with arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""3""}")]
        #endregion
        public void UndoNavigationArgumentTest(string ruleJson)
        {
            // Invoke the UndoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson);
        }

        [TestMethod(DisplayName = "Verify that the UndoNavigation action works with invalid delay arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:A}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:0x7fffffff}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:2222222222}}""}")]
        #endregion
        public void UndoNavigationDelayArgumentNegativeTest(string ruleJson)
        {
            // Invoke the UndoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson);
        }

        [TestMethod(DisplayName = "Verify that the UndoNavigation action works with repeat " +
            "and delay arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:1000}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:1000.0}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:3 --Delay:00:00:01}}""}")]
        #endregion
        public void UndoNavigationDelayArgumentTest(string ruleJson)
        {
            // Invoke the UndoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson);
        }

        [TestMethod(DisplayName = "Verify that the UndoNavigation action works with no arguments.")]
        public void UndoNavigationNoArgumentTest()
        {
            // Invoke the UndoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson: @"{""pluginName"":""UndoNavigation""}");
        }

        [TestMethod(DisplayName = "Verify that the UndoNavigation action works with repeat arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Repeat:3}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:A}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:0.5}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:0x7fffffff}}""}")]
        [DataRow(@"{""argument"":""{{$ --Repeat:2222222222}}""}")]
        #endregion
        public void UndoNavigationRepeatArgumentTest(string ruleJson)
        {
            // Invoke the UndoNavigation action with the specified action rule
            InvokeTest(testBase: this, ruleJson);
        }

        // Invokes the UndoNavigation action using the provided test base and rule JSON,
        // then asserts that no exceptions are present in the plugin or the response.
        private static void InvokeTest(TestBase testBase, string ruleJson)
        {
            // Invoke the UndoNavigation action with the specified action rule
            var testResult = testBase.Invoke<UndoNavigation>(ruleJson);

            // Assert that exceptions are not present in the plugin
            Assert.IsTrue(testResult.Plugin.Exceptions.IsEmpty);

            // Assert that exceptions are not present in the response
            Assert.IsFalse(testResult.Plugin.Exceptions.Any());
        }
    }
}
