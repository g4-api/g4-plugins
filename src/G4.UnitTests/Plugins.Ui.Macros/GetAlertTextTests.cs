using G4.Plugins.Ui.Macros;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Ui.Macros
{
    [TestClass]
    [TestCategory("GetAlertText")]
    [TestCategory("UnitTest")]
    public class GetAlertTextTests : TestBase
    {
        [TestMethod(displayName: "Verify that the GetAlertText macro plugin throws NoSuchAlertException " +
            "when no alert is present.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""""}")]
        #endregion
        public void GetAlertTextNoAlertTest(string ruleJson)
        {
            // Invoke the GetAlertText macro plugin with the specified rule
            var responseModel = Invoke<GetAlertText>(ruleJson, capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.HasAlert] = false
            }).Response;

            // Assert that NoSuchAlertException was thrown
            Assert.IsTrue(responseModel.Exceptions.Any(i => i.Exception is NoSuchAlertException));
        }

        [TestMethod(displayName: "Verify that the GetAlertText macro plugin works correctly " +
            "when an alert is present and matches the specified pattern.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --Pattern:.{4}}}""}")]
        #endregion
        public void GetAlertTextByPatternTest(string ruleJson)
        {
            // Invoke the GetAlertText macro plugin with the specified rule
            var testResult = Invoke<GetAlertText>(ruleJson, capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.HasAlert] = true
            });

            // Assert that the response contains the macro result
            Assert.IsTrue(testResult.Response.Entity.ContainsKey(MacroResultKey));

            // Assert that the macro result length is 4
            Assert.AreEqual(expected: 4, actual: $"{testResult.Response.Entity[MacroResultKey]}".Length);
        }

        [TestMethod(displayName: "Verify that the GetAlertText macro plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Ensure the macro plugin can be instantiated without issues
            AssertPlugin<GetAlertText>();
        }

        [TestMethod(displayName: "Verify that the GetAlertText macro plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the macro plugin's manifest adheres to the expected structure and contains all required elements
            AssertManifest<GetAlertText>(pluginName: "Get-AlertText");
        }

        [TestMethod(displayName: "Verify that the GetAlertText macro plugin works correctly " +
            "and returns the correct text.")]
        public void GetAlertTextTest()
        {
            // Invoke the GetAlertText macro plugin
            var testResult = Invoke<GetAlertText>(capabilities: new Dictionary<string, object>
            {
                [SimulatorCapabilities.HasAlert] = true
            });

            // Assert that the response contains the macro result
            Assert.IsTrue(testResult.Response.Entity.ContainsKey(MacroResultKey));

            // Assert that the macro result contains text (not empty)
            Assert.IsTrue(Regex.IsMatch(input: $"{testResult.Response.Entity[MacroResultKey]}", pattern: ".+"));
        }
    }
}
