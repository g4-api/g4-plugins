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
        // Names the session parameter the loop publishes for the iteration it is currently running.
        private const string IterationParameter = "InvokeForLoop:Iteration";

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

        [TestMethod(DisplayName = "Verify that the InvokeForLoop plugin publishes the zero-based index of the " +
            "running iteration and removes it once the loop ends.")]
        public void InvokeForLoopIterationParameterTest()
        {
            // Act: run a loop of three iterations whose step records the index it reads.
            var resultModel = Invoke([NewRuleModel(Stubs.RuleJsonInvokeForLoopWithIteration)]);

            // Act: read the index the last iteration recorded and the index the loop left behind.
            var recorded = resultModel
                .GetParameterValue(parameterName: "TestParameter", scope: "Session")
                .ConvertFromBase64();
            var published = resultModel.GetParameterValue(parameterName: IterationParameter, scope: "Session");

            // Assert: the index is zero-based, so the last of three iterations reports two.
            Assert.AreEqual(expected: "2", actual: recorded);

            // Assert: the parameter is published only while a loop runs, so no stale index outlives it.
            Assert.AreEqual(expected: string.Empty, actual: published);
        }

        [TestMethod(DisplayName = "Verify that a step placed after a nested InvokeForLoop reads the index of its " +
            "own loop instead of the index the nested loop left.")]
        public void InvokeForLoopNestedIterationParameterTest()
        {
            // Act: run an outer loop of two iterations, each running a nested loop of three and then recording its
            // own index.
            var resultModel = Invoke([NewRuleModel(Stubs.RuleJsonInvokeForLoopNestedWithIteration)]);

            // Act: read the index each loop recorded.
            var inner = resultModel
                .GetParameterValue(parameterName: "InnerParameter", scope: "Session")
                .ConvertFromBase64();
            var outer = resultModel
                .GetParameterValue(parameterName: "OuterParameter", scope: "Session")
                .ConvertFromBase64();

            // Assert: the nested loop reports its own last index, which is two of three iterations.
            Assert.AreEqual(expected: "2", actual: inner);

            // Assert: the outer step reports the outer index, so the nested loop restored the frame it inherited.
            Assert.AreEqual(expected: "1", actual: outer);
        }

        [TestMethod(DisplayName = "Verify that every depth of a triple-nested InvokeForLoop reads the index of the " +
            "loop its step belongs to.")]
        public void InvokeForLoopTripleNestedIterationParameterTest()
        {
            // Act: run loops of two, three and four iterations, each recording its own index after the loop it holds.
            var resultModel = Invoke([NewRuleModel(Stubs.RuleJsonInvokeForLoopTripleWithIteration)]);

            // Act: read the index each depth recorded.
            var inner = resultModel
                .GetParameterValue(parameterName: "InnerParameter", scope: "Session")
                .ConvertFromBase64();
            var middle = resultModel
                .GetParameterValue(parameterName: "MiddleParameter", scope: "Session")
                .ConvertFromBase64();
            var outer = resultModel
                .GetParameterValue(parameterName: "OuterParameter", scope: "Session")
                .ConvertFromBase64();

            // Assert: each depth reports the last index of its own loop, so neither depth reads another's index.
            Assert.AreEqual(expected: "3", actual: inner);
            Assert.AreEqual(expected: "2", actual: middle);
            Assert.AreEqual(expected: "1", actual: outer);
        }

        // Deserializes the rule JSON into the rule model the invoker runs.
        private static ActionRuleModel NewRuleModel(string ruleJson)
        {
            // Act: read the stub as the action rule the plugin is addressed through.
            return JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);
        }

        // Invokes the test with the specified rule JSON and checks the expected performance points.
        private static void Invoke(TestBase testBase, string ruleJson, int expectedPerformancePoints)
        {
            // Invoke the test with the deserialized rule model.
            var resultModel = testBase.Invoke([NewRuleModel(ruleJson)]);

            // Retrieve the parameter value from the test result and decode it from Base64.
            var actual = resultModel
                .GetParameterValue(parameterName: "TestParameter", scope: "Session")
                .ConvertFromBase64();

            // Retrieve the performance points from the test result.
            var performancePoints = resultModel.GetPerformancePoints();

            // Assert that the actual parameter value matches the expected value.
            Assert.AreEqual(expected: "Foo Bar", actual);

            // Assert that the number of performance points matches the expected count.
            Assert.HasCount(expected: expectedPerformancePoints, collection: [.. performancePoints]);
        }
    }
}
