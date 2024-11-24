using G4.Models;
using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SwitchParentFrame")]
    [TestCategory("UnitTest")]
    public class SwitchParentFrameTests : TestBase
    {
        [TestMethod(displayName: "Verify that the SwitchParentFrame plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SwitchParentFrame>();
        }

        [TestMethod(displayName: "Verify that the SwitchParentFrame plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SwitchParentFrame>();
        }

        [TestMethod(displayName: "Verify that the SwitchParentFrame action works correctly.")]
        public void SwitchParentFrameByIdTest()
        {
            // Define the action rule model
            var ruleModel = new ActionRuleModel
            {
                PluginName = "SwitchParentFrame"
            };

            // Invoke the SwitchParentFrame action with the specified action rule
            var responseModel = Invoke<SwitchParentFrame>(ruleModel).Response;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(!responseModel.Exceptions.Any());
        }

        [TestMethod(displayName: "Verify that the SwitchParentFrame action works correctly " +
            "with an element inside an element.")]
        public void SwitchParentFrameByIdOnElementInsideElementTest()
        {
            // Define the action rule model
            var ruleModel = new ActionRuleModel
            {
                PluginName = "SwitchParentFrame"
            };

            // Invoke the SwitchParentFrame action with the specified action rule
            var responseModel = Invoke<SwitchParentFrame>(ruleModel, By.Custom.Positive()).Response;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsTrue(!responseModel.Exceptions.Any());
        }
    }
}
