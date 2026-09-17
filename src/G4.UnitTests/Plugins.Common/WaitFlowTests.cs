using G4.Plugins.Common.Actions;
using G4.Models;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("WaitFlow")]
    [TestCategory("UnitTest")]
    public class WaitFlowTests : TestBase
    {
        // The type name of the driver being used.
        private const string DriverTypeName = "G4.WebDriver.Simulator.SimulatorDriver";

        // The attribute of the element being interacted with.
        private const string ElementAttribute = "http://m.from-href.io/";

        // The text of the element being interacted with.
        private const string ElementText = "Mock: Positive Element 20";

        // The title of the page being tested.
        private const string PageTitle = "Mock G4™ API Page Title 20";

        // The URL of the page being tested.
        private const string PageUrl = "http://positive.io/20";

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<WaitFlow>();
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<WaitFlow>();
        }

        [TestMethod(DisplayName = "Verify that WaitFlow keeps pre-existing exceptions and last distinct key lookup failures.")]
        public void WaitFlowPollingExceptionNormalizationTest()
        {
            // Arrange: create a plugin and rule context that matches the report-visible exception identity.
            var plugin = NewPlugin<WaitFlow>();
            var rule = new ActionRuleModel(pluginName: "WaitFlow")
            {
                OnElement = "//positive"
            };
            var pluginData = new PluginDataModel
            {
                Rule = rule
            };

            // Arrange: model the exception state before polling and the noisy assertion failures produced by intervals.
            var originalException = new G4ExceptionModel(rule, new InvalidOperationException("Original failure."));
            var firstKeyFailure = new G4ExceptionModel(rule, new KeyNotFoundException("Repeated key failure."));
            var lastKeyFailure = new G4ExceptionModel(rule, new KeyNotFoundException("Repeated key failure."));
            var distinctKeyFailure = new G4ExceptionModel(rule, new KeyNotFoundException("Distinct key failure."));
            var ignoredPollingFailure = new G4ExceptionModel(rule, new InvalidOperationException("Ignored polling failure."));

            // Act: invoke the normalization helper directly so the test isolates the compaction contract.
            typeof(WaitFlow)
                .GetMethod(name: "NormalizePollingExceptions", BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(
                    obj: default,
                    parameters:
                    [
                        plugin,
                        pluginData,
                        new[] { originalException },
                        new[] { firstKeyFailure, lastKeyFailure, distinctKeyFailure, ignoredPollingFailure }
                    ]);

            // Assert: pre-existing exceptions remain and non-key polling failures are discarded.
            var exceptions = plugin.Exceptions.ToArray();

            Assert.AreEqual(expected: 3, actual: exceptions.Length);
            Assert.IsTrue(exceptions.Contains(originalException));
            Assert.IsFalse(exceptions.Contains(ignoredPollingFailure));

            // Assert: repeated key lookup failures keep only the last item for the distinct identity.
            Assert.IsFalse(exceptions.Contains(firstKeyFailure));
            Assert.IsTrue(exceptions.Contains(lastKeyFailure));
            Assert.IsTrue(exceptions.Contains(distinctKeyFailure));
        }

        [TestMethod(DisplayName = "Verify that WaitFlow reports one timeout when a wait condition expires.")]
        public void WaitFlowTimeoutExceptionTest()
        {
            // Arrange: use a condition that stays false so the wait path reaches its timeout branch.
            var ruleJson =
                "{\n" +
                "    \"$type\":\"Action\",\n" +
                "    \"pluginName\":\"WaitFlow\",\n" +
                "    \"argument\":\"{{$ --Condition:PageTitle --Expected:FooBar --Timeout:300}}\",\n" +
                "    \"onElement\":\"//positive\"\n" +
                "}";

            // Act: invoke the wait path long enough to poll more than once and then time out.
            var exceptions = Invoke(ruleJson).GetExceptions().ToArray();

            // Assert: the failed wait reports exactly one timeout with the configured duration and element.
            var timeoutExceptions = exceptions
                .Where(i => i.Exception is WebDriverTimeoutException)
                .ToArray();

            Assert.AreEqual(expected: 1, actual: timeoutExceptions.Length);
            Assert.AreEqual(expected: 1, actual: exceptions.Length);

            var timeoutException = (WebDriverTimeoutException)timeoutExceptions[0].Exception;
            Assert.AreEqual(expected: TimeSpan.FromMilliseconds(300), actual: timeoutException.Timeout);
            StringAssert.Contains(value: timeoutExceptions[0].ReasonPhrase, substring: "//positive");
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin meets boolean conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:AlertNotExists     --Timeout:00:00:05}}\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementActive      --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementDisabled    --Timeout:00:00:05}}\",\"onElement\":\"//negative\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementEnabled     --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementExists      --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementNotActive   --Timeout:00:00:05}}\",\"onElement\":\"//negative\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementNotExists   --Timeout:00:00:05}}\",\"onElement\":\"//none\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementNotSelected --Timeout:00:00:05}}\",\"onElement\":\"//negative\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementNotVisible  --Timeout:00:00:05}}\",\"onElement\":\"//negative\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementSelected    --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementStale       --Timeout:00:00:05}}\",\"onElement\":\"//stale\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementVisible     --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowBooleanConditionMetTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout when boolean conditions are not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:AlertExists        --Timeout:00:00:05}}\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementActive      --Timeout:00:00:05}}\",\"onElement\":\"//negative\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementDisabled    --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementEnabled     --Timeout:00:00:05}}\",\"onElement\":\"//negative\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementExists      --Timeout:00:00:05}}\",\"onElement\":\"//none\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementNotActive   --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementNotExists   --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementNotSelected --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementNotVisible  --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementSelected    --Timeout:00:00:05}}\",\"onElement\":\"//negative\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementStale       --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementVisible     --Timeout:00:00:05}}\",\"onElement\":\"//negative\"}")]
        #endregion
        public void WaitFlowBooleanConditionTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin correctly handles " +
            "DriverTypeName conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:DriverTypeName --Operator:Eq       --Expected:" + DriverTypeName + " --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:DriverTypeName --Operator:Ne       --Expected:FooBar                 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:DriverTypeName --Operator:Match    --Expected:Simulator              --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:DriverTypeName --Operator:NotMatch --Expected:FooBar                 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionDriverTypeNameTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout " +
            "for DriverTypeName conditions when not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:DriverTypeName --Operator:Ne       --Expected:" + DriverTypeName + " --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:DriverTypeName --Operator:Eq       --Expected:FooBar                 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:DriverTypeName --Operator:NotMatch --Expected:Simulator              --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:DriverTypeName --Operator:Match    --Expected:FooBar                 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionDriverTypeNameTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin correctly handles " +
            "ElementAttribute conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementAttribute --Operator:Eq       --Expected:" + ElementAttribute + " --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementAttribute --Operator:Ne       --Expected:FooBar                   --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementAttribute --Operator:Match    --Expected:from-href                --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:FooBar                   --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        #endregion
        public void WaitFlowConditionElementAttributeTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout " +
            "for ElementAttribute conditions when not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementAttribute --Operator:Ne       --Expected:" + ElementAttribute + " --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementAttribute --Operator:Eq       --Expected:FooBar                   --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementAttribute --Operator:NotMatch --Expected:from-href                --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementAttribute --Operator:Match    --Expected:FooBar                   --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        #endregion
        public void WaitFlowConditionElementAttributeTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin correctly handles " +
            "ElementCount conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Gt --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Ge --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Ge --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Lt --Expected:3 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Le --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Le --Expected:3 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Eq --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Ne --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionElementCountTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout " +
            "for ElementCount conditions when not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Gt --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Ge --Expected:3 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Lt --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Le --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Eq --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementCount --Operator:Ne --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionElementCountTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin correctly handles " +
            "ElementText conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementText --Operator:Eq       --Expected:" + ElementText + " --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementText --Operator:Ne       --Expected:FooBar              --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementText --Operator:Match    --Expected:Positive Element    --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementText --Operator:NotMatch --Expected:FooBar              --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionElementTextTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout " +
            "for ElementText conditions when not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementText --Operator:Ne       --Expected:" + ElementText + " --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementText --Operator:Eq       --Expected:FooBar              --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementText --Operator:NotMatch --Expected:Positive Element    --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementText --Operator:Match    --Expected:FooBar              --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionElementTextTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin correctly handles " +
            "ElementTextLength conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Gt --Expected:24 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Ge --Expected:25 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Ge --Expected:24 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Lt --Expected:26 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Le --Expected:26 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Le --Expected:25 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Eq --Expected:25 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Ne --Expected:26 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionElementTextLengthTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout " +
            "for ElementTextLength conditions when not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Gt --Expected:26 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Ge --Expected:26 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Lt --Expected:20 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Le --Expected:20 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Eq --Expected:20 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:ElementTextLength --Operator:Ne --Expected:25 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionElementTextLengthTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin correctly handles " +
            "PageTitle conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageTitle --Operator:Eq       --Expected:" + PageTitle + "    --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageTitle --Operator:Ne       --Expected:FooBar               --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageTitle --Operator:Match    --Expected:(?is)^Mock.*?\\\\d+$ --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageTitle --Operator:NotMatch --Expected:FooBar               --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        #endregion
        public void WaitFlowConditionPageTitleTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout " +
            "for PageTitle conditions when not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageTitle --Operator:Ne       --Expected:" + PageTitle + "    --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageTitle --Operator:Eq       --Expected:FooBar               --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageTitle --Operator:NotMatch --Expected:(?is)^Mock.*?\\\\d+$ --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageTitle --Operator:Match    --Expected:FooBar               --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        #endregion
        public void WaitFlowConditionPageTitleTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin correctly handles " +
            "PageUrl conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageUrl --Operator:Eq       --Expected:" + PageUrl + "         --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageUrl --Operator:Ne       --Expected:FooBar                  --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageUrl --Operator:Match    --Expected:(?is)positive.*?\\\\d+$ --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageUrl --Operator:NotMatch --Expected:FooBar                  --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        #endregion
        public void WaitFlowConditionPageUrlTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout " +
            "for PageUrl conditions when not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageUrl --Operator:Ne       --Expected:" + PageUrl + "         --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageUrl --Operator:Eq       --Expected:FooBar                  --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageUrl --Operator:NotMatch --Expected:(?is)positive.*?\\\\d+$ --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:PageUrl --Operator:Match    --Expected:FooBar                  --Timeout:00:00:05}}\",\"onElement\":\"//positive\",\"onAttribute\":\"href\"}")]
        #endregion
        public void WaitFlowConditionPageUrlTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin correctly handles " +
            "WindowCount conditions within the timeout period.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Gt --Expected:0 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Ge --Expected:0 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Ge --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Lt --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Le --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Le --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Eq --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Ne --Expected:0 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionWindowCountTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is less than 5000 milliseconds (5 seconds)
            Assert.IsLessThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the timeout " +
            "for WindowCount conditions when not met.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Gt --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Ge --Expected:2 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Lt --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Le --Expected:0 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Eq --Expected:0 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Condition:WindowCount --Operator:Ne --Expected:1 --Timeout:00:00:05}}\",\"onElement\":\"//positive\"}")]
        #endregion
        public void WaitFlowConditionWindowCountTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 5000 milliseconds (5 seconds)
            Assert.IsGreaterThan(5000, runtime / TimeSpan.TicksPerMillisecond);
        }

        [TestMethod(DisplayName = "Verify that the WaitFlow plugin respects the specified timeout.")]
        #region *** Data Set ***
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"3000\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"00:00:03\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Timeout:3000}}\"}")]
        [DataRow("{\"$type\":\"Action\", \"pluginName\":\"WaitFlow\",\"argument\":\"{{$ --Timeout:00:00:03}}\"}")]
        #endregion
        public void WaitFlowTimeoutTest(string ruleJson)
        {
            // Invoke the WaitFlow action with the specified timeout
            var runtime = Invoke(ruleJson).GetPerformancePoint(pluginName: "WaitFlow").RunTime;

            // Assert that the elapsed time is greater than 3000 milliseconds (3 seconds)
            Assert.IsGreaterThan(3000, runtime / TimeSpan.TicksPerMillisecond);
        }
    }
}
