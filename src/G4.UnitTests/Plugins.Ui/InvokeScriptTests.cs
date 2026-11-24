using G4.Api;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Simulator;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("InvokeScript")]
    [TestCategory("UnitTest")]
    public class InvokeScriptTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeScript plugin can be " +
            "successfully created.")]
        public override void NewPluginTest()
        {
            // Assert that the InvokeScript plugin can be created successfully
            AssertPlugin<InvokeScript>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeScript plugin manifest complies " +
            "with the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert that the manifest documentation of the InvokeScript plugin is correct
            AssertManifest<InvokeScript>();
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method with no arguments and " +
            "check the result against a regex pattern.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""return document.readyState;""}")]
        #endregion
        public void InvokeScriptArgumentTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: false);
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method with script block and " +
            "check the result against a regex pattern.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""argument"":""{{$ --scriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""argument"":""{{$ --scriptblock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptScriptBlockTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: false);
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method with script block and " +
            "arguments, and check the result against a regex pattern.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --ScriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""argument"":""{{$ --scriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""argument"":""{{$ --scriptblock:return document.readyState; --arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        #endregion
        public void InvokeScriptScriptBlockWithArgumentsTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: false);
        }

        [TestMethod(DisplayName = "Verify the behavior of invoking a script with a script block, " +
            "arguments, and an element.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":"".//positive"",""argument"":""{{$ --ScriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":"".//positive"",""argument"":""{{$ --scriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":"".//positive"",""argument"":""{{$ --scriptblock:return document.readyState; --arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":"".//negative"",""argument"":""{{$ --ScriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":"".//negative"",""argument"":""{{$ --scriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":"".//negative"",""argument"":""{{$ --scriptblock:return document.readyState; --arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""{{$ --ScriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""{{$ --scriptBlock:return document.readyState; --Arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""{{$ --scriptblock:return document.readyState; --arguments:[1.5,false,'Foo Bar',{'number':0,'text':'a','boolean':true}]}}""}")]
        #endregion
        public void InvokeScriptScriptBlockWithArgumentsAndElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: true);
        }

        [TestMethod(DisplayName = "Verify the behavior of invoking a script with a script block " +
            "and an element for positive cases.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --scriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --scriptblock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptWithElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            InvokeScriptTest(this, ruleJson, onElement: true);
        }

        [TestMethod(DisplayName = "Verify the behavior of invoking a script with a script block " +
            "and a stale element, expecting a StaleElementReferenceException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//stale"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptWithStaleElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            Assert.Throws<StaleElementReferenceException>(()
                => InvokeScriptTest(this, ruleJson, onElement: true));
        }

        [TestMethod(DisplayName = "Verify the behavior of invoking a script with a script block " +
            "and no element, expecting a NoSuchElementException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//none"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptWithNoElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            Assert.Throws<NoSuchElementException>(()
                => InvokeScriptTest(this, ruleJson, onElement: true));
        }

        [TestMethod(DisplayName = "Verify the behavior of invoking a script with a script block " +
            "and an exception element, expecting a WebDriverException.")]
        #region *** Data Set ***
        [DataRow(@"{""onElement"":""..//exception"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptWithExceptionElementTest(string ruleJson)
        {
            // Invoke the script test with the specified rule JSON
            Assert.Throws<WebDriverException>(()
                => InvokeScriptTest(this, ruleJson, onElement: true));
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method stores its return value as a " +
            "session parameter and produces a node in the structured per-plugin response.")]
        public void InvokeScriptStructuredReportIsEmptyTest()
        {
            // Build a single-rule automation that runs InvokeScript against the SimulatorDriver.
            // The script 'return document.readyState;' is resolved by the simulator and produces a
            // non-empty result (the same value the other InvokeScript tests assert against).
            var invokeScriptRule = new ActionRuleModel
            {
                PluginName = "InvokeScript",
                Argument = "return document.readyState;"
            };

            // Wrap the rule in a single job.
            var job = new G4JobModel
            {
                Reference = new() { Name = NewRandomString(5) },
                Rules = [invokeScriptRule]
            };

            // Wrap the job in a single stage.
            var stage = new G4StageModel
            {
                Name = NewRandomString(10),
                Jobs = [job]
            };

            // Assemble the automation model with the SimulatorDriver, a structured response, and
            // ReturnEnvironment enabled so the 'InvokeScript:ScriptResult' session parameter is observable.
            var automation = new G4AutomationModel
            {
                Authentication = new AuthenticationModel
                {
                    Username = $"{TestContext.Properties["G4.Username"]}"
                },
                DriverParameters = new Dictionary<string, object>
                {
                    ["driver"] = "SimulatorDriver",
                    ["driverBinaries"] = "."
                },
                Stages = [stage],
                Settings = new G4SettingsModel
                {
                    AutomationSettings = new AutomationSettingsModel
                    {
                        SearchTimeout = 1,
                        ReturnStructuredResponse = true
                    },
                    EnvironmentsSettings = new EnvironmentsSettingsModel
                    {
                        ReturnEnvironment = true
                    }
                }
            };

            // Run the full automation through the engine and take the first session response.
            var response = new G4Client()
                .Automation
                .Invoke(automation)
                .First()
                .Value
                .Sessions
                .First()
                .Value;

            // Precondition: the script actually executed and its return value was captured — but only
            // as the 'InvokeScript:ScriptResult' session parameter (the sole location InvokeScript writes to).
            var scriptResult = $"{response.Environment.SessionParameters.Get(key: "InvokeScript:ScriptResult", defaultValue: string.Empty)}";
            Assert.IsTrue(
                condition: Regex.IsMatch(scriptResult, "uninitialized|loading|loaded|interactive|complete"),
                message: "Precondition failed: InvokeScript did not capture a ScriptResult session parameter.");

            // Locate the InvokeScript node inside the engine's structured per-plugin response tree.
            var invokeScriptNode = response
                .ResponseTree
                .Stages
                .SelectMany(stageNode => stageNode.Jobs)
                .SelectMany(jobNode => jobNode.Plugins ?? [])
                .FirstOrDefault(pluginNode => pluginNode.Rule?.PluginName == "InvokeScript");

            // Confirm the structured response actually produced a node for the InvokeScript rule.
            Assert.IsNotNull(
                value: invokeScriptNode,
                message: "The InvokeScript plugin node was not found in the structured response tree.");
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method preserves a PowerShell script " +
            "value that passes a -ScriptBlock parameter and does not truncate it during parsing.")]
        public void InvokeScriptPowershellScriptBlockParameterTest()
        {
            // A PowerShell-style script whose value itself passes a single-dash '-ScriptBlock'
            // parameter. The plugin receives the script through the '--ScriptBlock' macro parameter,
            // so the inner '-ScriptBlock' token must survive the CLI argument parsing untouched.
            // The 'readyState' token lets the SimulatorDriver resolve the script and return a value —
            // a script value truncated at '-ScriptBlock' would lose it and match no simulator script.
            var ruleModel = new ActionRuleModel
            {
                PluginName = "InvokeScript",
                Argument = "{{$ --ScriptBlock:Invoke-Command -ScriptBlock { Write-Output 'readyState' }}}"
            };

            // Invoke the plugin against the SimulatorDriver and retrieve the response model.
            var responseModel = Invoke<InvokeScript>(ruleModel).Response;

            // Read the captured script result from the session parameters.
            var scriptResult = responseModel
                .SessionParameters
                .Get(key: "InvokeScript:ScriptResult", defaultValue: string.Empty);

            // Assert the script was resolved and executed, confirming the '-ScriptBlock' token inside
            // the PowerShell value was preserved (neither stripped nor split by the parameter parser).
            var actual = Regex.IsMatch(
                input: scriptResult,
                pattern: "uninitialized|loading|loaded|interactive|complete");

            // Assert that the actual result matches the expected pattern.
            Assert.IsTrue(actual, "The InvokeScript parser did not preserve the PowerShell '-ScriptBlock' script value.");
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method decodes a Base64 script block " +
            "with the Base64 switch before executing it.")]
        public void InvokeScriptBase64ScriptBlockTest()
        {
            // Arrange: encode a script and pass it through the ScriptBlock parameter with the Base64 switch.
            var encodedScript = "return document.readyState;".ConvertToBase64();
            var ruleModel = new ActionRuleModel
            {
                PluginName = "InvokeScript",
                Argument = "{{$ --ScriptBlock:" + encodedScript + " --Base64}}"
            };

            // Act: invoke the plugin against the SimulatorDriver.
            var responseModel = Invoke<InvokeScript>(ruleModel).Response;

            // Assert: the decoded script executed and its result was captured in the session parameters.
            var scriptResult = responseModel
                .SessionParameters
                .Get(key: "InvokeScript:ScriptResult", defaultValue: string.Empty);

            var actual = Regex.IsMatch(
                input: scriptResult,
                pattern: "uninitialized|loading|loaded|interactive|complete");

            // Assert that the actual result matches the expected pattern.
            Assert.IsTrue(actual, "The InvokeScript method did not decode the Base64 script block before execution.");
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method executes the raw script value " +
            "and does not decode Base64 when the Base64 switch is absent.")]
        public void InvokeScriptBase64SwitchRequiredTest()
        {
            // Arrange: encode a script but omit the Base64 switch so the encoded text stays literal.
            var encodedScript = "return document.readyState;".ConvertToBase64();
            var ruleModel = new ActionRuleModel
            {
                PluginName = "InvokeScript",
                Argument = "{{$ --ScriptBlock:" + encodedScript + "}}"
            };

            // Act and Assert: the still-encoded value is executed as-is, which the driver cannot resolve.
            Assert.Throws<WebDriverException>(() => Invoke<InvokeScript>(ruleModel));
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method resolves the macros of a Base64 script block " +
            "after decoding it, keeping the rest of the script as is.")]
        public void InvokeScriptBase64MacroTest()
        {
            // Arrange: encode a script whose macro and inline flags the engine cannot see while it is encoded.
            const string script = "run('--myParam', '{{$Convert-Number --Number:255 --To:Hex --Case:Upper}}');";
            var ruleJson = @"{""argument"":""{{$ --ScriptBlock:" + script.ConvertToBase64() + @" --Base64}}""}";
            var driver = new RecordingSimulatorDriver();

            // Act: invoke the plugin on a driver that records the script it receives.
            Invoke<InvokeScript>(driver, ruleJson);

            // Assert: the driver received the decoded script with the macro replaced by its result.
            Assert.AreEqual(expected: "run('--myParam', 'FF');", actual: driver.Script);
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method injects the context element as " +
            "arguments[0] when OnElement is '.'.")]
        public void InvokeScriptContextElementTest()
        {
            // Arrange: a script with '.' requesting the context element.
            const string ruleJson = @"{""onElement"":""."",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}";

            // Act: invoke the plugin with a context element, as a loop or an extraction scope would.
            var arguments = InvokeRecordedScript(testBase: this, ruleJson);

            // Assert: the context element is the only script argument.
            Assert.HasCount(expected: 1, collection: arguments);
            Assert.IsInstanceOfType<IWebElement>(arguments[0], "The context element was not injected for '.'.");
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method fails when OnElement is '.' and " +
            "there is no context element.")]
        public void InvokeScriptContextElementMissingTest()
        {
            // Arrange: a script requesting the context element outside a loop or an extraction scope.
            const string ruleJson = @"{""onElement"":""."",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}";

            // Act and Assert: the plugin rejects the request instead of running the script without the element.
            Assert.ThrowsExactly<NoSuchElementException>(() => Invoke<InvokeScript>(ruleJson));
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method does not inject the context element " +
            "when OnElement is empty.")]
        #region *** Data Set ***
        [DataRow(@"{""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        [DataRow(@"{""onElement"":"""",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}")]
        #endregion
        public void InvokeScriptEmptyOnElementTest(string ruleJson)
        {
            // Act: invoke the plugin with a context element, as a loop or an extraction scope would.
            var arguments = InvokeRecordedScript(testBase: this, ruleJson);

            // Assert: the script ran on the driver without any element argument.
            Assert.IsEmpty(arguments, "The context element was injected for an empty OnElement.");
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method injects an explicitly located element " +
            "when a context element exists.")]
        public void InvokeScriptExplicitElementTest()
        {
            // Arrange: a script with an explicit element locator.
            const string ruleJson = @"{""onElement"":""//positive"",""argument"":""{{$ --ScriptBlock:return document.readyState;}}""}";

            // Act: invoke the plugin with a context element, as a loop or an extraction scope would.
            var arguments = InvokeRecordedScript(testBase: this, ruleJson);

            // Assert: the located element is the only script argument.
            Assert.HasCount(expected: 1, collection: arguments);
            Assert.IsInstanceOfType<IWebElement>(arguments[0], "The explicitly located element was not injected.");
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method stores the first regular expression match " +
            "of a string script result.")]
        public void InvokeScriptRegularExpressionTest()
        {
            // Arrange: a script that returns a ready state and a pattern that keeps its first part.
            const string ruleJson = @"{""argument"":""return document.readyState;"",""regularExpression"":""^comp""}";

            // Act: invoke the plugin on a driver that returns the ready state.
            var scriptResult = InvokeScriptResult(testBase: this, ruleJson, scriptResult: "complete");

            // Assert: only the matched part of the result was stored.
            Assert.AreEqual(expected: "comp", actual: scriptResult);
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method writes a non-string script result as JSON " +
            "before it applies the regular expression.")]
        public void InvokeScriptRegularExpressionJsonTest()
        {
            // Arrange: a script that returns an object and a pattern that reads one of its values.
            const string ruleJson = @"{""argument"":""return { count: 42 };"",""regularExpression"":""(?<=\""count\"":)\\d+""}";
            var objectResult = new Dictionary<string, object> { ["count"] = 42L };

            // Act: invoke the plugin on a driver that returns the object.
            var scriptResult = InvokeScriptResult(testBase: this, ruleJson, scriptResult: objectResult);

            // Assert: the pattern reached the value inside the JSON text of the object.
            Assert.AreEqual(expected: "42", actual: scriptResult);
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method stores an empty string when the regular " +
            "expression does not match the script result.")]
        public void InvokeScriptRegularExpressionNoMatchTest()
        {
            // Arrange: a pattern that the returned ready state does not contain.
            const string ruleJson = @"{""argument"":""return document.readyState;"",""regularExpression"":""\\d+""}";

            // Act: invoke the plugin on a driver that returns the ready state.
            var scriptResult = InvokeScriptResult(testBase: this, ruleJson, scriptResult: "complete");

            // Assert: no match stores an empty value instead of the unrefined result.
            Assert.AreEqual(expected: string.Empty, actual: scriptResult);
        }

        [TestMethod(DisplayName = "Verify the InvokeScript method stores the whole script result when the rule " +
            "has no regular expression.")]
        public void InvokeScriptNoRegularExpressionTest()
        {
            // Arrange: a script that returns a ready state and a rule without a pattern.
            const string ruleJson = @"{""argument"":""return document.readyState;""}";

            // Act: invoke the plugin on a driver that returns the ready state.
            var scriptResult = InvokeScriptResult(testBase: this, ruleJson, scriptResult: "complete");

            // Assert: the stored value is the unrefined result, as before the regular expression support.
            Assert.AreEqual(expected: "complete", actual: $"{scriptResult}");
        }

        // Invokes the plugin with a context element on a recording driver and returns the script arguments.
        private static object[] InvokeRecordedScript(TestBase testBase, string ruleJson)
        {
            // Create a driver that records the arguments of every script call.
            var driver = new RecordingSimulatorDriver();

            // Invoke the plugin with the positive element as the context element.
            testBase.Invoke<InvokeScript>(driver, ruleJson, By.Custom.Positive());

            // Return the arguments of the script call.
            return driver.ScriptArguments;
        }

        // Invokes the plugin on a recording driver that returns the given result, and returns the value the plugin
        // stored as the ScriptResult session parameter.
        private static object InvokeScriptResult(TestBase testBase, string ruleJson, object scriptResult)
        {
            // Create a driver whose script calls return the given result.
            var driver = new RecordingSimulatorDriver
            {
                ScriptResult = scriptResult
            };

            // Invoke the plugin on that driver.
            var responseModel = testBase.Invoke<InvokeScript>(driver, ruleJson).Response;

            // Return the stored value as is, so each test decides how to compare it.
            return responseModel.SessionParameters["InvokeScript:ScriptResult"];
        }

        // Invokes the script block test with the specified test base and action rule.
        private static void InvokeScriptTest(TestBase testBase, string ruleJson, bool onElement)
        {
            // Invoke the InvokeScript method with the specified action rule and retrieve the response model
            var responseModel = onElement
                ? testBase.Invoke<InvokeScript>(ruleJson, By.Custom.Positive()).Response
                : testBase.Invoke<InvokeScript>(ruleJson).Response;

            // Extract the ScriptResult from the session parameters, defaulting to an empty string if not present
            var scriptResult = responseModel
                .SessionParameters
                .Get(key: "InvokeScript:ScriptResult", defaultValue: string.Empty);

            // Use a regex pattern to check if the script result matches certain states of document.readyState
            var actual = Regex.IsMatch(
                input: scriptResult,
                pattern: "uninitialized|loading|loaded|interactive|complete");

            // Assert that the actual result matches the expected pattern
            Assert.IsTrue(actual, "The InvokeScript method did not return the expected document.readyState value.");
        }

        // A simulator driver that records the arguments of the last script call. It re-implements the script
        // interface so the plugin's calls through IWebDriver reach the recording method.
        private sealed class RecordingSimulatorDriver() : SimulatorDriver(NewSession()), IJavaScriptInvoker
        {
            // Gets the script text of the last script call.
            public string Script { get; private set; } = string.Empty;

            // Gets the arguments of the last script call.
            public object[] ScriptArguments { get; private set; } = [];

            // Gets or sets the value every script call returns; a ready state by default, so the element tests
            // keep their result.
            public object ScriptResult { get; set; } = "complete";

            // Records the script and its arguments and returns the configured result. The simulator resolves its
            // script handlers from the runtime type, so a derived driver cannot delegate the call to the base driver.
            public new object InvokeScript(string script, params object[] args)
            {
                Script = script;
                ScriptArguments = args ?? [];
                return ScriptResult;
            }

            // Creates an empty simulator session.
            private static SessionModel NewSession() => new()
            {
                Capabilities = new CapabilitiesModel
                {
                    AlwaysMatch = new Dictionary<string, object>()
                }
            };
        }
    }
}
