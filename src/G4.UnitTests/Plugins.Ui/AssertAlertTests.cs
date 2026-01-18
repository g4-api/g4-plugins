using G4.Plugins.Ui.Assertions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("Assert")]
    [TestCategory("UnitTest")]
    public class AssertAlertTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the AlertExists plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<AlertExists>();
        }

        [TestMethod(DisplayName = "Verify that the AlertExists plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<AlertExists>();
        }

        [TestMethod(DisplayName = "Verify that the AlertExists condition evaluates to " +
            "false when there is no alert.")]
        #region *** Data Set ***
        [DataRow("AlertExists")]
        [DataRow("HasAlert")]
        [DataRow("AlertVisible")]
        [DataRow("alertExists")]
        [DataRow("hasAlert")]
        [DataRow("alertVisible")]
        #endregion
        public void AlertExistsNegativeTest(string condition)
        {
            // Initialize the rule JSON for the test case.
            var ruleJson = "{\"$type\":\"Action\",\"pluginName\":\"Assert\",\"argument\":\"{{$ --Condition:" + condition + "}}\"}";

            // Define the capabilities for the WebDriver session.
            var capabilities = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                [SimulatorCapabilities.HasAlert] = false
            };

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson, capabilities).Response.First().Value.Sessions.First().Value;

            // Get the evaluation result from the plugin.
            var actual = session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation result is false.
            Assert.IsFalse(actual);
        }

        [TestMethod(DisplayName = "Verify that the AlertExists condition evaluates to " +
            "true when there is an alert.")]
        #region *** Data Set ***
        [DataRow("AlertExists")]
        [DataRow("HasAlert")]
        [DataRow("AlertVisible")]
        [DataRow("alertExists")]
        [DataRow("hasAlert")]
        [DataRow("alertVisible")]
        #endregion
        public void AlertExistsTest(string condition)
        {
            // Initialize the rule JSON for the test case.
            var ruleJson = "{\"$type\":\"Action\",\"pluginName\":\"Assert\",\"argument\":\"{{$ --Condition:" + condition + "}}\"}";

            // Define the capabilities for the WebDriver session.
            var capabilities = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                [SimulatorCapabilities.HasAlert] = true
            };

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson, capabilities).Response.First().Value.Sessions.First().Value;

            // Get the evaluation result from the plugin.
            var actual = session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation result is true.
            Assert.IsTrue(actual);
        }

        [TestMethod(DisplayName = "Verify that the AlertNotExists condition evaluates to " +
            "false when there is an alert.")]
        #region *** Data Set ***
        [DataRow("AlertNotExists")]
        [DataRow("NoAlert")]
        [DataRow("HasNoAlert")]
        [DataRow("alertNotExists")]
        [DataRow("noAlert")]
        [DataRow("hasNoAlert")]
        #endregion
        public void AlertNotExistsNegativeTest(string condition)
        {
            // Initialize the rule JSON for the test case.
            var ruleJson = "{\"$type\":\"Action\",\"pluginName\":\"Assert\",\"argument\":\"{{$ --Condition:" + condition + "}}\"}";

            // Define the capabilities for the WebDriver session.
            var capabilities = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                [SimulatorCapabilities.HasAlert] = true
            };

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson, capabilities).Response.First().Value.Sessions.First().Value;

            // Get the evaluation result from the plugin.
            var actual = session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation result is false.
            Assert.IsFalse(actual);
        }

        [TestMethod(DisplayName = "Verify that the AlertNotExists condition evaluates to " +
            "true when there is no alert.")]
        #region *** Data Set ***
        [DataRow("AlertNotExists")]
        [DataRow("NoAlert")]
        [DataRow("HasNoAlert")]
        [DataRow("alertNotExists")]
        [DataRow("noAlert")]
        [DataRow("hasNoAlert")]
        #endregion
        public void AlertNotExistsTest(string condition)
        {
            // Initialize the rule JSON for the test case.
            var ruleJson = "{\"$type\":\"Action\", \"pluginName\":\"Assert\",\"argument\":\"{{$ --Condition:" + condition + "}}\"}";

            // Invoke the action rule and retrieve the session from the test result.
            var session = Invoke(ruleJson).Response.First().Value.Sessions.First().Value;

            // Get the evaluation result from the plugin.
            var actual = session.ResponseData.Extractions.GetEvaluation();

            // Assert that the evaluation result is true.
            Assert.IsTrue(actual);
        }
    }
}
