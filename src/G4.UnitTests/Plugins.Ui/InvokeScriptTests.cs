using G4.Api;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.Actions;
using G4.UnitTests.Framework;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

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
    }
}
