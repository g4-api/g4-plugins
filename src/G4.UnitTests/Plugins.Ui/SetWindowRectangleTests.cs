using G4.Exceptions;
using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("SetWindowRectangle")]
    [TestCategory("UnitTest")]
    public class SetWindowRectangleTests : TestBase
    {
        [TestMethod(displayName: "Verify that the SetWindowRectangle plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<SetWindowRectangle>();
        }

        [TestMethod(displayName: "Verify that the SetWindowRectangle plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin can be instantiated without issues
            AssertPlugin<SetWindowRectangle>();
        }

        [TestMethod(displayName: "Verify that the SetWindowRectangle action works correctly.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"": ""{{$ --Height:100 --Width:150 --X:20 --Y:30}}""}")]
        [DataRow(@"{""argument"": ""{{$ --height:100 --width:150 --x:20 --y:30}}""}")]
        #endregion
        public void SetWindowRectangleTest(string ruleJson)
        {
            // Invoke the SetWindowRectangle action with the specified action rule
            var plugin = Invoke<SetWindowRectangle>(ruleJson).Plugin;

            // Get the window rectangle
            var windowRectangle = plugin.WebDriver.Manage().Window.WindowRect;

            // Assert that the window rectangle properties match the expected values
            Assert.AreEqual(expected: 100, actual: windowRectangle.Height);
            Assert.AreEqual(expected: 150, actual: windowRectangle.Width);
            Assert.AreEqual(expected: 20, actual: windowRectangle.X);
            Assert.AreEqual(expected: 30, actual: windowRectangle.Y);
        }

        [TestMethod(displayName: "Verify that the SetWindowRectangle action throws MissingMandatoryPropertyException " +
            "for incomplete arguments.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"": """"}")]
        #endregion
        public void SetWindowRectangleNegativeTest(string ruleJson)
        {
            // Invoke the SetWindowRectangle action with the specified action rule
            var responseModel = Invoke<SetWindowRectangle>(ruleJson).Response;

            // Assert that MissingMandatoryParameterException was thrown
            Assert.IsTrue(responseModel.Exceptions.Any(i => i.Exception is MissingMandatoryPropertyException));
        }

        [TestMethod(displayName: "Verify that the SetWindowRectangle action works correctly " +
            "with an element.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"": ""{{$ --Height:100 --Width:150 --X:20 --Y:30}}""}")]
        [DataRow(@"{""argument"": ""{{$ --height:100 --width:150 --x:20 --y:30}}""}")]
        #endregion
        public void SetWindowRectangleElementTest(string ruleJson)
        {
            // Invoke the SetWindowRectangle action with the specified action rule
            var plugin = Invoke<SetWindowRectangle>(ruleJson, By.Custom.Positive()).Plugin;

            // Get the window rectangle
            var windowRectangle = plugin.WebDriver.Manage().Window.WindowRect;

            // Assert that the window rectangle properties match the expected values
            Assert.AreEqual(expected: 100, actual: windowRectangle.Height);
            Assert.AreEqual(expected: 150, actual: windowRectangle.Width);
            Assert.AreEqual(expected: 20, actual: windowRectangle.X);
            Assert.AreEqual(expected: 30, actual: windowRectangle.Y);
        }
    }
}
