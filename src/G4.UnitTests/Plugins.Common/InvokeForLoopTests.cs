using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Stubs = G4.UnitTests.Framework.ActionRuleStubs;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("InvokeForLoop")]
    [TestCategory("UnitTest")]
    public class InvokeForLoopTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeForLoop plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<InvokeForLoop>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeForLoop plugin complies with " +
            "the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<InvokeForLoop>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeForLoop plugin performs the loop " +
            "correctly and awards the expected performance points.")]
        public void InvokeForLoopPositiveTest()
        {
            Invoke(
                testBase: this,
                ruleJson: Stubs.RuleJsonInvokeForLoop,
                expectedPerformancePoints: 4);
        }

        [TestMethod(DisplayName = "Verify that the InvokeForLoop plugin performs nested " +
            "loops correctly and awards the expected performance points.")]
        public void InvokeForLoopWithNestedLoopPositiveTest()
        {
            Invoke(
                testBase: this,
                ruleJson: Stubs.RuleJsonInvokeForLoopWithNestedLoop,
                expectedPerformancePoints: 13);
        }

        [TestMethod(DisplayName = "Verify that the InvokeForLoop plugin performs triple " +
            "nested loops correctly and awards the expected performance points.")]
        public void InvokeForLoopTripleLoopPositiveTest()
        {
            Invoke(
                testBase: this,
                ruleJson: Stubs.RuleJsonInvokeForLoopTripleLoop,
                expectedPerformancePoints: 40);
        }

        // Invokes the test with the specified rule JSON and checks the expected performance points.
        private static void Invoke(TestBase testBase, string ruleJson, int expectedPerformancePoints)
        {
            // Deserialize the rule JSON into a G4RuleModelBase object.
            var ruleModel = (G4RuleModelBase)JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);

            // Invoke the test with the deserialized rule model.
            var resultModel = testBase.Invoke([ruleModel]);

            // Retrieve the parameter value from the test result and decode it from Base64.
            var actual = resultModel
                .GetParameterValue(parameterName: "TestParameter", scope: "Session")
                .ConvertFromBase64();

            // Retrieve the performance points from the test result.
            var performancePoints = resultModel.GetPerformancePoints();

            // Assert that the actual parameter value matches the expected value.
            Assert.AreEqual(expected: "Foo Bar", actual);

            // Assert that the number of performance points matches the expected count.
            Assert.AreEqual(expectedPerformancePoints, performancePoints.Count());
        }
    }
}
