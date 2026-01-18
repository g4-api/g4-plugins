using G4.Exceptions;
using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetFocus")]
    [TestCategory("UnitTest")]
    public class SetFocusTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the SetFocus plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SetFocus>();
        }

        [TestMethod(DisplayName = "Verify that the SetFocus plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SetFocus>();
        }

        [TestMethod(DisplayName = "Verify that the SetFocus action works with valid elements " +
            "inside an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//positive""}")]
        [DataRow(@"{""onElement"":"".//negative""}")]
        [DataRow(@"{""onElement"":"".//null""}")]
        #endregion
        public void SetFocusElementInsideElementTest(string ruleJson)
        {
            // Invoke the SetFocus action with the specified action rule
            var responseModel = Invoke<SetFocus>(ruleJson, By.Custom.Positive()).Response;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsFalse(responseModel.Exceptions.Any());
        }

        [TestMethod(DisplayName = "Verify that the SetFocus action throws NoSuchElementException " +
            "for none element inside an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//none""}")]
        #endregion
        public void SetFocusElementInsideElementNoElementExceptionTest(string ruleJson)
        {
            // Invoke the SetFocus action with the specified action rule
            Assert.Throws<NoSuchElementException>(()
                => Invoke<SetFocus>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the SetFocus action throws StaleElementReferenceException " +
            "for stale element inside an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//stale""}")]
        #endregion
        public void SetFocusElementInsideElementStaleExceptionTest(string ruleJson)
        {
            // Invoke the SetFocus action with the specified action rule
            Assert.Throws<StaleElementReferenceException>(()
                => Invoke<SetFocus>(ruleJson, By.Custom.Positive()));
        }

        [TestMethod(DisplayName = "Verify that the SetFocus action works with valid elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive""}")]
        [DataRow(@"{""onElement"":""//negative""}")]
        #endregion
        public void SetFocusOnElementTest(string ruleJson)
        {
            // Invoke the SetFocus action with the specified action rule
            var responseModel = Invoke<SetFocus>(ruleJson, By.Custom.Positive()).Response;

            // Assert that no exceptions were thrown during the plugin invocation
            Assert.IsFalse(responseModel.Exceptions.Any());
        }

        [TestMethod(DisplayName = "Verify that the SetFocus action throws " +
            "WebDriverTimeoutException for invalid elements.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//none""}")]
        [DataRow(@"{""onElement"":""//null""}")]
        [DataRow(@"{""onElement"":""//stale""}")]
        #endregion
        public void SetFocusTimeoutExceptionTest(string ruleJson)
        {
            // Invoke the SetFocus action with the specified action rule
            Assert.Throws<WebDriverTimeoutException>(() => Invoke<SetFocus>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify that the SetFocus action throws " +
            "MissingMandatoryPropertyException for no element.")]
        public void SetFocusNoElementTest()
        {
            // Invoke the SetFocus action with the specified action rule
            var responseModel = Invoke<SetFocus>(ruleJson: @"{""pluginName"":""SetFocus""}").Response;

            // Assert that MissingMandatoryPropertyException was thrown
            Assert.IsTrue(responseModel.Exceptions.Any(i => i.Exception is MissingMandatoryPropertyException));
        }
    }
}
