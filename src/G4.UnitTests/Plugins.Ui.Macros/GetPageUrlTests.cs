using G4.Plugins.Ui.Macros;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.Ui.Macros
{
    [TestClass]
    [TestCategory("GetPageUrl")]
    [TestCategory("UnitTest")]
    public class GetPageUrlTests : TestBase
    {
        [TestMethod(displayName: "Verify that the GetPageUrl macro plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the macro plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<GetPageUrl>(pluginName: "Get-PageUrl");
        }

        [TestMethod(displayName: "Verify that the GetPageUrl macro plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the macro plugin can be instantiated without issues
            AssertPlugin<GetPageUrl>();
        }

        [TestMethod(displayName: "Verify that the GetPageUrl macro plugin returns an empty result " +
            "when the driver is null.")]
        public void GetPageUrlExceptionTest()
        {
            // Invoke the macro to get the page URL with a null driver
            var resultModel = Invoke<GetPageUrl>(capabilities: new Dictionary<string, object>
            {
                ["ExceptionOnUrl"] = true
            });

            // Assert that a WebDriverException was thrown
            Assert.IsTrue(resultModel.Response.Exceptions.Any(i => i.Exception is WebDriverException));

            // Assert that the response contains the macro result
            Assert.IsTrue(resultModel.Response.Entity.ContainsKey(MacroResultKey));

            // Assert that the macro result is empty, indicating an exception occurred
            Assert.AreEqual(expected: string.Empty, resultModel.Response.Entity[MacroResultKey]);
        }

        [TestMethod(displayName: "Verify that the GetPageUrl macro plugin returns the correct page URL.")]
        public void GetPageUrlTest()
        {
            // Define the expected URL
            const string Expected = "http://positive.io/20";

            // Invoke the macro to get the page URL
            var resultModel = Invoke<GetPageUrl>();

            // Assert that the response contains the macro result
            Assert.IsTrue(resultModel.Response.Entity.ContainsKey(MacroResultKey));

            // Assert that the page URL matches the expected value
            Assert.AreEqual(Expected, actual: $"{resultModel.Response.Entity[MacroResultKey]}");
        }

        [DataTestMethod(displayName: "Verify that the GetPageUrl macro plugin returns the correct page URL " +
            "when a pattern is specified.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Pattern:\\d+$}}""}")]
        #endregion
        public void GetPageUrlByPatternTest(string ruleJson)
        {
            // Define the expected URL
            const string Expected = "20";

            // Invoke the macro to get the page URL
            var resultModel = Invoke<GetPageUrl>(ruleJson);

            // Assert that the response contains the macro result
            Assert.IsTrue(resultModel.Response.Entity.ContainsKey(MacroResultKey));

            // Assert that the page URL matches the expected value
            Assert.AreEqual(Expected, actual: $"{resultModel.Response.Entity[MacroResultKey]}");
        }
    }
}
