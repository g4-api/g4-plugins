using G4.Abstraction.WebDriver;
using G4.Api;
using G4.Extensions;
using G4.IntegrationTests.Engine;
using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace G4.IntegrationTests.Suites.Engine
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("Engine")]
    public class MultiPhaseDriverTests : TestBase
    {
        [TestMethod(displayName: "Verify that two WebDriver instances are initiated when a " +
            "job takes the driver from its parent stage.")]
        #region *** Data Set ***
        [DataRow("Default()")]
        [DataRow("Stage()")]
        [DataRow(null)]
        [DataRow("")]
        #endregion
        public void GetJobDriverTest(string jobDriver)
        {
            // Initialize the automation environment with the current test context
            var environment = new AutomationEnvironment(TestContext).AddTestParameter(key: "jobDriver", jobDriver);

            // Create test options for a non-UI test scenario
            var testOptions = new NonUiTestOptions(environment);

            // Invoke the test case C0001 with the specified test options and retrieve the response
            var response = Invoke<C0001>(testOptions);

            // Extract driver session IDs from the performance points in the flat request
            var driverSessions = response.ResponseData.PerformancePoints.Select(i => i.DriverSession);

            // Extract the automation driver session ID from the main performance point
            var automationDriverSession = response.PerformancePoint.DriverSession;

            // Combine both driver session IDs and ensure they are distinct
            var sessions = driverSessions.Concat([automationDriverSession]).Distinct().ToArray();

            // Assert that exactly two unique driver sessions were created
            Assert.AreEqual(
                expected: 2,
                actual: sessions.Length,
                message: "Expected two distinct WebDriver sessions to be initiated.");

            // Assert that none of the plugins within the job are using the automation driver
            // They must be using the driver created by the stage instead
            Assert.IsTrue(
                condition: response.ResponseData.PerformancePoints.All(i => i.DriverSession != automationDriverSession),
                message: "All plugins within the job must use the stage driver, not the automation driver.");

            // Assert that the 'TestParameter' has the expected value after base64 decoding
            Assert.AreEqual(
                expected: "Foo Bar",
                actual: $"{response.Environment.SessionParameters["TestParameter"]}".ConvertFromBase64(),
                message: "The 'TestParameter' should be 'Foo Bar' after decoding.");
        }

        [TestMethod(displayName: "Verify that a stage can take a driver from the preceding " +
            "stage or use the default driver from the parent automation.")]
        #region *** Data Set ***
        [DataRow("Default()")]
        [DataRow("Stage(1)")]
        [DataRow(null)]
        [DataRow("")]
        #endregion
        public void GetStageDriverTest(string stageDriver)
        {
            // Initialize the automation environment with the current test context and add the stageDriver parameter
            var environment = new AutomationEnvironment(TestContext).AddTestParameter(key: "stageDriver", stageDriver);

            // Create test options for a non-UI test scenario using the configured environment
            var testOptions = new NonUiTestOptions(environment);

            // Invoke the test case C0002 with the specified test options and retrieve the response
            var response = Invoke<C0002>(testOptions);

            // Extract driver session IDs from the performance points in the flat request
            var driverSessions = response.ResponseData.PerformancePoints.Select(i => i.DriverSession);

            // Extract the automation driver session ID from the main performance point
            var automationDriverSession = response.PerformancePoint.DriverSession;

            // Combine both driver session IDs and ensure they are distinct
            var sessions = driverSessions.Concat([automationDriverSession]).Distinct().ToArray();

            // Assert that exactly two unique driver sessions were created
            Assert.AreEqual(
                expected: 2,
                actual: sessions.Length,
                message: "Expected two distinct WebDriver sessions to be initiated.");

            // Assert that the environment's session parameters count is exactly two
            Assert.AreEqual(
                expected: 2,
                actual: response.Environment.SessionParameters.Count,
                message: "Expected exactly two session parameters to be present.");

            // Assert that all session parameters have the expected decoded value "Foo Bar"
            Assert.IsTrue(
                condition: response.Environment.SessionParameters.All(i => $"{i.Value}".ConvertFromBase64() == "Foo Bar"),
                message: "All session parameters should have the decoded value 'Foo Bar'.");
        }

        [TestMethod(displayName: "Verify that the automation driver is correctly retrieved " +
            "and no exceptions occur during GetStateDriver invocation.")]
        public void GetStateDriverTest()
        {
            // Initialize the automation environment with the current test context.
            var environment = new AutomationEnvironment(TestContext);

            // Create test options using the initialized environment.
            var testOptions = new NonUiTestOptions(environment);

            // Invoke the plugin with test options and capture the response.
            var response = Invoke<C0003>(testOptions);

            // Extract the automation driver session from the response's performance point.
            var automationDriver = response.PerformancePoint.DriverSession;

            // Add the automation driver ID to the test parameters for use in subsequent invocations.
            environment.TestParameters.Add(key: "automationDriver", $"Id({automationDriver})");

            // Update test options with the modified environment containing the automation driver.
            testOptions = new NonUiTestOptions(environment);

            // Invoke a nested plugin action (C0003A) with the updated test options and capture the response.
            response = Invoke<C0003.C0003A>(testOptions);

            // Assert that no exceptions were captured in the response's response data.
            Assert.IsFalse(response.ResponseData.Exceptions.Any(), "Exceptions were found during the GetStateDriver invocation.");
        }

        [TestMethod]
        public void ReadFromFileTest()
        {
            // Read the JSON content from the specified file path.
            var json = File.ReadAllText(@"E:\Garbage\z.txt");

            // Deserialize the JSON content into a G4AutomationModel object using the provided options.
            var automation = JsonSerializer.Deserialize<G4AutomationModel>(json, JsonSerializerOptions);

            // Create a new G4Client instance.
            var client = new G4Client();

            // Subscribe to the RuleInvoking event to output the PluginName of each rule as it is invoked.
            client.Automation.RuleInvoking += (sender, e) => Console.WriteLine(e.Rule.PluginName);

            // Invoke the automation process with the deserialized model and store the results.
            var result = client.Automation.Invoke(automation);

            // Assert that the result collection is not empty.
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void NewDriverTest()
        {
            //// Create a dictionary containing driver parameters for initializing the driver.
            //var driverParameters = new Dictionary<string, object>
            //{
            //    // Specify the driver type to use (e.g., Microsoft Edge).
            //    ["driver"] = "MicrosoftEdgeDriver",
            //    // Specify the URL for the driver binaries (e.g., WebDriver server endpoint).
            //    ["driverBinaries"] = "http://localhost:4444/wd/hub",
            //    // Define capabilities for the driver.
            //    ["capabilities"] = new Dictionary<string, object>
            //    {
            //        // 'alwaysMatch' specifies capabilities that must be met.
            //        ["alwaysMatch"] = new Dictionary<string, object>
            //        {
            //            // Set Edge-specific options.
            //            ["ms:edgeOptions"] = new Dictionary<string, object>
            //            {
            //                // Pass arguments to the driver; here, running in headless mode.
            //                ["args"] = new[]
            //                {
            //                    "--headless"
            //                }
            //            }
            //        }
            //    }
            //};

            // Create a dictionary containing driver parameters for initializing the driver.
            var driverParameters = new Dictionary<string, object>
            {
                // Specify the driver type to use (e.g., Microsoft Edge).
                ["driver"] = "UiaDriver",
                // Specify the URL for the driver binaries (e.g., WebDriver server endpoint).
                ["driverBinaries"] = "http://localhost:5555/wd/hub",
                // Define capabilities for the driver.
                ["capabilities"] = new Dictionary<string, object>
                {
                    // 'alwaysMatch' specifies capabilities that must be met.
                    ["alwaysMatch"] = new Dictionary<string, object>
                    {
                        // Set Edge-specific options.
                        ["uia:options"] = new Dictionary<string, object>
                        {
                            // Pass arguments to the driver; here, running in headless mode.
                            ["app"] = "notepad.exe"
                        }
                    }
                }
            };

            var automation = new G4AutomationModel
            {
                DriverParameters = driverParameters,
                Authentication = new AuthenticationModel
                {
                    Username = "pyhBifB6z1YxJv53xLip"
                },
                Stages =
                [
                    new G4StageModel
                    {
                        Jobs =
                        [
                            new G4JobModel
                            {
                                Rules =
                                [
                                    //new ActionRuleModel
                                    //{
                                    //    Argument= "{{$ --Keys:H W --Delay:300}}",
                                    //    PluginName = "SendUser32Keys",
                                    //    OnElement = "//Document[@Name='Text editor']"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    Argument= "{{$ --X:150 --Y:250}}",
                                    //    PluginName = "MoveUser32Mouse"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    Argument= "{{$ --OffsetX:20 --OffsetY:20}}",
                                    //    PluginName = "MoveUser32Mouse"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    Argument= "{{$ --OffsetX:5 --OffsetY:10 --Alignment:BottomRight}}",
                                    //    PluginName = "MoveUser32Mouse",
                                    //    OnElement = "//Document[@Name='Text editor']"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    Argument= "{{$ --Alignment:TopRight}}",
                                    //    PluginName = "MoveUser32Mouse",
                                    //    OnElement = "//Document"
                                    //},
                                    // //Window[@PartialName='Notepad']
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "SendUser32Keys",
                                    //    Argument = "{{$ --Keys:שלום --Delay:1000 --KeyboardLayout:he-IL}}"
                                    //},
                                    new ActionRuleModel
                                    {
                                        PluginName = "WaitFlow",
                                        Argument = "2000"
                                    },
                                    new ActionRuleModel
                                    {
                                        PluginName = "SendUser32Keys",
                                        Argument = "{{$ --Keys:שלום! --Delay:1000 --KeyboardLayout:he-IL}}"
                                    },
                                    new ActionRuleModel
                                    {
                                        PluginName = "SendUser32Keys",
                                        Argument = "{{$ --Keys:hello!?^* --Delay:1000 --KeyboardLayout:en-US}}"
                                    },
                                    new ActionRuleModel
                                    {
                                        PluginName = "SendUser32KeyboardKey",
                                        Argument = "{{$ --Key:Ctrl --Key:A --Sticky}}"
                                    },
                                    new ActionRuleModel
                                    {
                                        PluginName = "WaitFlow",
                                        Argument = "5000"
                                    },
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "SwitchKeyboardLayout",
                                    //    Argument = "{{$ --KeyboardLayout:he-IL}}"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "WaitFlow",
                                    //    Argument = "2000"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "SwitchKeyboardLayout",
                                    //    Argument = "en-US"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "WaitFlow",
                                    //    Argument = "2000"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "SwitchKeyboardLayout",
                                    //    Argument = "he-IL"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "WaitFlow",
                                    //    Argument = "2000"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "SwitchKeyboardLayout"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "CloseBrowser"
                                    //}
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "SendUser32KeyboardKey",
                                    //    OnElement = "//MenuItem[@Name='File']"
                                    //},
                                    //new ActionRuleModel
                                    //{
                                    //    PluginName = "InvokeUser32DoubleClick",
                                    //    OnElement = "//MenuItem[@Name='File']"
                                    //}
                                ]
                            }
                        ]
                    }
                ]
            };

            //var c = CacheManager.Instance;
            //var a = automation.Initialize(c);
            //var invoker = new AutomationInvoker(a);

            //var r = invoker.Invoke(a);

            var client = new G4Client().Automation;
            var mr = client.Invoke(automation);

            // Initialize a new driver instance using the DriverFactory with the specified parameters.
            var driver = new DriverFactory(driverParameters).NewDriver();

            // Dispose of the driver instance to clean up resources.
            driver.Dispose();

            // Assert that the driver is not null, ensuring that it was created successfully.
            Assert.IsNotNull(driver);
        }
    }
}
