using G4.Models;
using G4.Plugins.Ui.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.Json;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeInputActions")]
    [TestCategory("InputActions")]
    [TestCategory("UnitTest")]
    public class InvokeInputActionsTests : TestBase
    {
        // Holds Control, clicks an element, and releases Control: one key press, a move, a press, a release,
        // and a key release (five input actions).
        private const string RuleJsonModifierClick =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeInputActions\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyDown\",\n" +
            "            \"argument\": \"Control\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddPointerMove\",\n" +
            "            \"onElement\": \"//positive\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddPointerDown\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddPointerUp\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyUp\",\n" +
            "            \"argument\": \"{{$ --Key:Control}}\"\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // Drags from one element to another with a timed move and a pause, then scrolls: every kind of input
        // action in one gesture (six input actions).
        private const string RuleJsonDragAndScroll =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeInputActions\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddPointerMove\",\n" +
            "            \"onElement\": \"//positive\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddPointerDown\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddPointerMove\",\n" +
            "            \"argument\": \"{{$ --X:120 --Y:40 --Duration:600}}\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddPause\",\n" +
            "            \"argument\": \"200\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddPointerUp\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddScroll\",\n" +
            "            \"argument\": \"{{$ --DeltaY:600}}\"\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // A container with a single child, which is the smallest valid gesture (one input action).
        private const string RuleJsonSingleAction =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeInputActions\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyDown\",\n" +
            "            \"argument\": \"Shift\"\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // A container with two child rules; the test sets its argument, a name the container does not act on.
        private const string RuleJsonNamedGesture =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeInputActions\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyDown\",\n" +
            "            \"argument\": \"Shift\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyUp\",\n" +
            "            \"argument\": \"Shift\"\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // A container without child rules, which has nothing to send.
        private const string RuleJsonEmpty =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeInputActions\"\n" +
            "}";

        // A container that holds an ordinary action beside an input action; the ordinary action must not run.
        private const string RuleJsonForeignRule =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeInputActions\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyDown\",\n" +
            "            \"argument\": \"Control\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"Click\",\n" +
            "            \"onElement\": \"//positive\"\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // A container whose second child names a key that does not exist, so that child adds no action.
        private const string RuleJsonFailingRule =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeInputActions\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyDown\",\n" +
            "            \"argument\": \"Control\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyDown\",\n" +
            "            \"argument\": \"NoSuchKey\"\n" +
            "        },\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"AddKeyUp\",\n" +
            "            \"argument\": \"Control\"\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // An input action placed directly in the flow, outside any container.
        private const string RuleJsonOutsideContainer =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"AddPointerDown\"\n" +
            "}";

        // InvokeForLoop runs three iterations of a container that holds a key press and a key release.
        private const string RuleJsonInsideForLoop =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeForLoop\",\n" +
            "    \"argument\": \"3\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"InvokeInputActions\",\n" +
            "            \"rules\": [\n" +
            "                {\n" +
            "                    \"$type\": \"Action\",\n" +
            "                    \"pluginName\": \"AddKeyDown\",\n" +
            "                    \"argument\": \"Shift\"\n" +
            "                },\n" +
            "                {\n" +
            "                    \"$type\": \"Action\",\n" +
            "                    \"pluginName\": \"AddKeyUp\",\n" +
            "                    \"argument\": \"Shift\"\n" +
            "                }\n" +
            "            ]\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        // InvokeForEachLoop runs the container once per '//positive' element. The child searches for an element
        // that does not exist, relative to the element the loop passes down. A search beneath an element fails at
        // once with "no such element", while a search without one waits and fails with a timeout, so the kind of
        // failure tells whether the child inherited the loop element.
        private const string RuleJsonInsideForEachLoop =
            "{\n" +
            "    \"$type\": \"Action\",\n" +
            "    \"pluginName\": \"InvokeForEachLoop\",\n" +
            "    \"onElement\": \"//positive\",\n" +
            "    \"rules\": [\n" +
            "        {\n" +
            "            \"$type\": \"Action\",\n" +
            "            \"pluginName\": \"InvokeInputActions\",\n" +
            "            \"rules\": [\n" +
            "                {\n" +
            "                    \"$type\": \"Action\",\n" +
            "                    \"pluginName\": \"AddPointerMove\",\n" +
            "                    \"onElement\": \".//none\"\n" +
            "                }\n" +
            "            ]\n" +
            "        }\n" +
            "    ]\n" +
            "}";

        [TestMethod(DisplayName = "Verify that the InvokeInputActions plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: the embedded manifest matches the plugin key and carries a summary, a description and examples.
            AssertManifest<InvokeInputActions>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeInputActions plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert: the plugin is registered and the factory creates it with a driver.
            AssertPlugin<InvokeInputActions>();
        }

        [TestMethod(DisplayName = "Verify that InvokeInputActions runs every child rule once, sends the sequence, " +
            "and reports no error.")]
        #region *** Data Set ***
        [DataRow(RuleJsonSingleAction, 2)]
        [DataRow(RuleJsonModifierClick, 6)]
        [DataRow(RuleJsonDragAndScroll, 7)]
        #endregion
        public void InvokeInputActionsPositiveTest(string ruleJson, int expectedPerformancePoints)
        {
            // Arrange: read the container and its child rules from the fixture.
            var rule = JsonSerializer.Deserialize<G4RuleModelBase>(ruleJson, JsonOptions);

            // Act: run the container through the engine, which resolves and reports every child rule.
            var result = Invoke([rule]);

            // Assert: neither the container nor a child reported an error.
            Assert.IsEmpty(result.GetExceptions());

            // Assert: the container and each child ran exactly once.
            Assert.HasCount(expectedPerformancePoints, result.GetPerformancePoints());
        }

        [TestMethod(DisplayName = "Verify that InvokeInputActions named through its argument runs its child rules " +
            "and reports no error.")]
        #region *** Data Set ***
        [DataRow("Ctrl+click rows 1 and 3")]
        [DataRow("Hold Shift -- then release it")]
        [DataRow("Gesture {{$Get-Parameter --Name:Missing --Scope:Session}}")]
        #endregion
        public void InvokeInputActionsArgumentTest(string argument)
        {
            // Arrange: read the container with two child rules, and give it the name under test as its argument.
            var rule = JsonSerializer.Deserialize<G4RuleModelBase>(RuleJsonNamedGesture, JsonOptions);
            rule.Argument = argument;

            // Act: run the container through the engine, which resolves the macros in the argument.
            var result = Invoke([rule]);

            // Assert: the name does not change the gesture, so neither the container nor a child reported an error.
            Assert.IsEmpty(result.GetExceptions());

            // Assert: the container and both children ran exactly once.
            Assert.HasCount(3, result.GetPerformancePoints());
        }

        [TestMethod(DisplayName = "Verify that InvokeInputActions without child rules is rejected and runs nothing.")]
        public void InvokeInputActionsEmptyTest()
        {
            // Arrange: read a container that holds no child rules.
            var rule = JsonSerializer.Deserialize<G4RuleModelBase>(RuleJsonEmpty, JsonOptions);

            // Act: run the container through the engine.
            var result = Invoke([rule]);

            // Assert: the error tells the flow author what the container needs.
            var exception = result.GetExceptions().Single();
            Assert.Contains("has no rules", exception.Exception.Message);

            // Assert: only the container was reported, because it has no child to run.
            Assert.HasCount(1, result.GetPerformancePoints());
        }

        [TestMethod(DisplayName = "Verify that InvokeInputActions rejects a child rule that is not an input " +
            "action, names it, and runs no child.")]
        public void InvokeInputActionsForeignRuleTest()
        {
            // Arrange: read a container that holds a Click beside an input action.
            var rule = JsonSerializer.Deserialize<G4RuleModelBase>(RuleJsonForeignRule, JsonOptions);

            // Act: run the container through the engine.
            var result = Invoke([rule]);

            // Assert: the error names the misplaced rule.
            var exception = result.GetExceptions().Single();
            Assert.Contains("runs only input actions", exception.Exception.Message);
            Assert.Contains("Click", exception.Exception.Message);

            // Assert: only the container was reported; neither the Click nor the input action ran.
            Assert.HasCount(1, result.GetPerformancePoints());
        }

        [TestMethod(DisplayName = "Verify that InvokeInputActions sends nothing and names the failed child when " +
            "one child rule does not add its action.")]
        public void InvokeInputActionsFailingRuleTest()
        {
            // Arrange: read a container whose second child names a key that does not exist.
            var rule = JsonSerializer.Deserialize<G4RuleModelBase>(RuleJsonFailingRule, JsonOptions);

            // Act: run the container through the engine and collect the error messages it and its children reported.
            var result = Invoke([rule]);
            var messages = result
                .GetExceptions()
                .Select(item => item.Exception.Message)
                .ToArray();

            // Assert: the child reports its own error, and the container reports that nothing was sent.
            Assert.HasCount(2, messages);
            Assert.Contains(message => message.Contains("Key 'NoSuchKey' is not valid"), messages);
            Assert.Contains(message => message.Contains("these rules did not add their action: AddKeyDown"), messages);

            // Assert: the container and all three children were reported, so the flow shows which one failed.
            Assert.HasCount(4, result.GetPerformancePoints());
        }

        [TestMethod(DisplayName = "Verify that an input action placed outside InvokeInputActions fails with a " +
            "message that names the container.")]
        public void InvokeInputActionsOutsideContainerTest()
        {
            // Arrange: read an input action that sits directly in the flow.
            var rule = JsonSerializer.Deserialize<G4RuleModelBase>(RuleJsonOutsideContainer, JsonOptions);

            // Act: run the rule through the engine, which resolves it by name like any other action.
            var result = Invoke([rule]);

            // Assert: the rule fails and tells the flow author where it belongs.
            var exception = result.GetExceptions().Single();
            Assert.Contains("runs only as a child rule of 'InvokeInputActions'", exception.Exception.Message);
        }

        [TestMethod(DisplayName = "Verify that InvokeInputActions inside a for loop runs its child rules on every " +
            "iteration with no error.")]
        public void InvokeInputActionsInsideForLoopTest()
        {
            // Arrange: read a three-iteration loop around a container with two child rules.
            var rule = JsonSerializer.Deserialize<G4RuleModelBase>(RuleJsonInsideForLoop, JsonOptions);

            // Act: run the loop through the engine.
            var result = Invoke([rule]);

            // Assert: no iteration reported an error, which also proves every rule got a unique runtime identifier.
            Assert.IsEmpty(result.GetExceptions());

            // Assert: the loop ran once, and the container with its two children ran three times.
            Assert.HasCount(10, result.GetPerformancePoints());
        }

        [TestMethod(DisplayName = "Verify that InvokeInputActions inside a for-each loop passes the element of " +
            "the loop to its child rules.")]
        public void InvokeInputActionsInsideForEachLoopTest()
        {
            // Arrange: read a for-each loop whose container child searches beneath the loop element.
            var rule = JsonSerializer.Deserialize<G4RuleModelBase>(RuleJsonInsideForEachLoop, JsonOptions);

            // Act: run the loop through the engine and collect the kinds of failure the rules reported.
            var result = Invoke([rule]);
            var exceptions = result
                .GetExceptions()
                .Select(item => item.Exception)
                .ToArray();

            // Assert: the child searched beneath an element, so it inherited the element of the loop.
            Assert.Contains(exception => exception is NoSuchElementException, exceptions);

            // Assert: no child searched the whole page, which is what a rule without an inherited element does.
            Assert.DoesNotContain(exception => exception is WebDriverTimeoutException, exceptions);
        }
    }
}
