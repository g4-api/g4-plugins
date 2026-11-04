using G4.Extensions;
using G4.Models;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.Json;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("InvokeForLoop")]
    [TestCategory("InvokeForEachLoop")]
    [TestCategory("InvokeDataForEachLoop")]
    [TestCategory("SetCondition")]
    [TestCategory("SetSwitchCase")]
    [TestCategory("Regression")]
    [TestCategory("UnitTest")]
    public class LoopBranchRuntimeIdTests : TestBase
    {
        // The plugin name of the branch rule, used to count how many times a branch ran.
        private const string BranchPluginName = "RegisterParameter";

        // InvokeForLoop runs three iterations of a SetCondition whose TRUE branch registers a parameter.
        private const string RuleJsonForLoopSetCondition =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeForLoop\",\n" +
            "    \"argument\": \"3\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Switch\",\n" +
            "            \"pluginName\": \"SetCondition\",\n" +
            "            \"argument\": \"{{$ --Condition:ElementExists}}\",\n" +
            "            \"onElement\": \"//positive\",\n" +
            "            \"branches\": {\n" +
            "                \"true\": [\n" +
            "                    {\n" +
            "                        \"$type\": \"Action\",\n" +
            "                        \"pluginName\": \"RegisterParameter\",\n" +
            "                        \"argument\": \"{{$ --Name:TestParameter --Value:Foo Bar}}\"\n" +
            "                    }\n" +
            "                ]\n" +
            "            }\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // InvokeForLoop runs three iterations of a SetSwitchCase whose matching case registers a parameter.
        private const string RuleJsonForLoopSetSwitchCase =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeForLoop\",\n" +
            "    \"argument\": \"3\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Switch\",\n" +
            "            \"pluginName\": \"SetSwitchCase\",\n" +
            "            \"argument\": \"Foo\",\n" +
            "            \"branches\": {\n" +
            "                \"Foo\": [\n" +
            "                    {\n" +
            "                        \"$type\": \"Action\",\n" +
            "                        \"pluginName\": \"RegisterParameter\",\n" +
            "                        \"argument\": \"{{$ --Name:TestParameter --Value:Foo Bar}}\"\n" +
            "                    }\n" +
            "                ]\n" +
            "            }\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // InvokeForEachLoop runs a SetCondition for each '//positive' element (the simulator returns two).
        private const string RuleJsonForEachLoopSetCondition =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeForEachLoop\",\n" +
            "    \"onElement\": \"//positive\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Switch\",\n" +
            "            \"pluginName\": \"SetCondition\",\n" +
            "            \"argument\": \"{{$ --Condition:ElementExists}}\",\n" +
            "            \"onElement\": \"//positive\",\n" +
            "            \"branches\": {\n" +
            "                \"true\": [\n" +
            "                    {\n" +
            "                        \"$type\": \"Action\",\n" +
            "                        \"pluginName\": \"RegisterParameter\",\n" +
            "                        \"argument\": \"{{$ --Name:TestParameter --Value:Foo Bar}}\"\n" +
            "                    }\n" +
            "                ]\n" +
            "            }\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // InvokeDataForEachLoop runs a SetCondition for each of two JSON records.
        private const string RuleJsonDataForEachLoopSetCondition =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeDataForEachLoop\",\n" +
            "    \"argument\": \"[{\\\"id\\\":\\\"1\\\"},{\\\"id\\\":\\\"2\\\"}]\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Switch\",\n" +
            "            \"pluginName\": \"SetCondition\",\n" +
            "            \"argument\": \"{{$ --Condition:ElementExists}}\",\n" +
            "            \"onElement\": \"//positive\",\n" +
            "            \"branches\": {\n" +
            "                \"true\": [\n" +
            "                    {\n" +
            "                        \"$type\": \"Action\",\n" +
            "                        \"pluginName\": \"RegisterParameter\",\n" +
            "                        \"argument\": \"{{$ --Name:TestParameter --Value:Foo Bar}}\"\n" +
            "                    }\n" +
            "                ]\n" +
            "            }\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        [TestMethod(DisplayName = "Verify that a branching rule inside a loop returns a complete response in " +
            "which every iteration of the branch rule has a unique runtime identifier.")]
        #region *** Data Set ***
        [DataRow(RuleJsonForLoopSetCondition, 3, DisplayName = "InvokeForLoop with SetCondition")]
        [DataRow(RuleJsonForLoopSetSwitchCase, 3, DisplayName = "InvokeForLoop with SetSwitchCase")]
        [DataRow(RuleJsonForEachLoopSetCondition, 2, DisplayName = "InvokeForEachLoop with SetCondition")]
        [DataRow(RuleJsonDataForEachLoopSetCondition, 2, DisplayName = "InvokeDataForEachLoop with SetCondition")]
        #endregion
        public void LoopBranchUniqueRuntimeIdTest(string ruleJson, int expectedBranchRuns)
        {
            // Arrange: deserialize the loop rule that holds the branching rule.
            var ruleModel = JsonSerializer.Deserialize<G4RuleModelBase>(ruleJson, JsonOptions);

            // Act: run the automation through G4Client, which builds the response tree from runtime identifiers.
            var result = Invoke([ruleModel]);

            // Assert: the response is not empty; a duplicate runtime identifier made the client return no responses.
            Assert.IsNotEmpty(result.Response, message: "The automation response is empty.");
            Assert.IsEmpty(result.GetExceptions());

            // Assert: the branch rule ran once per iteration and registered its parameter.
            var pluginPoints = result
                .GetPerformancePoints()
                .OfType<G4PluginPerformancePointModel>()
                .ToList();
            var branchPoints = pluginPoints.Where(i => i.RuleData?.PluginName == BranchPluginName);
            var actual = result
                .GetParameterValue(parameterName: "TestParameter", scope: "Session")
                .ConvertFromBase64();

            Assert.HasCount(expected: expectedBranchRuns, collection: branchPoints);
            Assert.AreEqual(expected: "Foo Bar", actual);

            // Assert: every performance point has its own runtime identifier, so no iteration overwrites another.
            var runtimeIds = pluginPoints.Select(i => i.Reference.GetRuntimeId());

            Assert.HasCount(expected: pluginPoints.Count, collection: runtimeIds.Distinct());
        }
    }
}
