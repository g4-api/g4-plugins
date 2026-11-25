using G4.Api;
using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.Actions.User32;
using G4.UnitTests.Framework;
using G4.WebDriver.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace G4.UnitTests.Plugins.Ui
{
    [TestClass]
    [TestCategory("LocalOnly")]
    [TestCategory("UiaDriver")]
    [TestCategory("User32ClickLive")]
    [DoNotParallelize]
    public class User32ClickLiveTests : TestBase
    {
        // The UIA name of the click target in the click lab application.
        private const string ClickTarget = "//Button[@Name='Click Target']";

        [TestMethod(DisplayName = "Verify on a live UIA driver that InvokeUser32MiddleClick and " +
            "InvokeUser32ContextClick press the middle and the right button on an element.")]
        public void InvokeUser32ElementClicksLiveTest()
        {
            // Arrange: middle-click the target and wait for the status text of a middle press, then right-click it
            // and wait for the status text of a right press. Each focus rule fails the flow when another button,
            // or none, was pressed. Both clicks run in one flow, because a second session that mounts the
            // application by name can attach to the instance an earlier test closed.
            var rules = new[]
            {
                NewLiveRule(pluginName: nameof(InvokeUser32MiddleClick), onElement: ClickTarget),
                NewLiveRule(pluginName: "SetUser32Focus", onElement: "//Text[@Name='Last button: Middle']"),
                NewLiveRule(pluginName: nameof(InvokeUser32ContextClick), onElement: ClickTarget),
                NewLiveRule(pluginName: "SetUser32Focus", onElement: "//Text[@Name='Last button: Right']")
            };

            // Act and Assert: the flow runs on the live application without an error.
            AssertLiveFlow(rules);
        }

        [TestMethod(DisplayName = "Verify that the live click tests have a plugin to run.")]
        public override void NewPluginTest()
        {
            // Assert: both plugins the live tests drive are registered and created by the factory.
            AssertPlugin<InvokeUser32MiddleClick>();
            AssertPlugin<InvokeUser32ContextClick>();
        }

        [TestMethod(DisplayName = "Verify that the manifests of the live-tested plugins comply with the " +
            "expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Assert: both embedded manifests resolve and satisfy G4 validation.
            AssertManifest<InvokeUser32MiddleClick>();
            AssertManifest<InvokeUser32ContextClick>();
        }

        // Runs rules on the live UIA driver against the click lab application and asserts that no rule failed. The
        // driver server address and the application path come from the run settings (Uia.DriverServer and
        // Uia.ClickApplication), so the test states what it needs and reports Inconclusive without them. The test
        // starts the application, waits for its window and lets the driver mount the running process.
        private void AssertLiveFlow(G4RuleModelBase[] rules)
        {
            // Arrange: read the live environment; without it the test cannot run and says so.
            var server = $"{TestContext.Properties["Uia.DriverServer"]}";
            var application = $"{TestContext.Properties["Uia.ClickApplication"]}";

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(application))
            {
                Assert.Inconclusive("Set Uia.DriverServer and Uia.ClickApplication in the run settings.");
            }

            // Arrange: start the application and wait until its main window exists.
            using var process = Process.Start(fileName: application);

            try
            {
                WaitForMainWindow(process);

                // Arrange: mount the running process by its name; the driver matches a process whose name the value
                // contains, so the bare name is passed and not the full path.
                var capabilities = new Dictionary<string, object>
                {
                    ["browserName"] = "Uia",
                    ["uia:options"] = new Dictionary<string, object>
                    {
                        ["app"] = process.ProcessName,
                        ["mount"] = true
                    }
                };

                // Arrange: wrap the rules in a one-stage, one-job automation that targets the live UIA driver server.
                var automation = new G4AutomationModel
                {
                    Authentication = new AuthenticationModel
                    {
                        Username = $"{TestContext.Properties["G4.Username"]}"
                    },
                    DriverParameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["Capabilities"] = new CapabilitiesModel
                        {
                            AlwaysMatch = capabilities
                        },
                        ["Driver"] = "UiaDriver",
                        ["DriverBinaries"] = server
                    },
                    Stages = [new G4StageModel { Jobs = [new G4JobModel { Rules = rules }] }]
                }.Initialize();

                // Act: run the flow on the live desktop.
                var response = new G4Client().Automation.Invoke(automation);
                var exceptions = response
                    .SelectMany(automationResponse => automationResponse.Value.Sessions.Values)
                    .SelectMany(session => session.ResponseData.Exceptions ?? [])
                    .Select(exception => $"{exception.PluginName}: {exception.Exception?.Message}")
                    .ToArray();

                // Assert: no rule failed; the messages name the rule that did.
                Assert.IsEmpty(exceptions, string.Join(Environment.NewLine, exceptions));
            }
            finally
            {
                // Cleanup: close the application and wait until it is gone, because the next live test mounts the
                // application by process name and would otherwise attach to this dying instance.
                if (!process.HasExited)
                {
                    process.Kill();
                    process.WaitForExit(milliseconds: 10000);
                }
            }
        }

        // Creates one rule of a live flow.
        private static ActionRuleModel NewLiveRule(string pluginName, string onElement)
        {
            return new ActionRuleModel
            {
                OnElement = onElement,
                PluginName = pluginName
            };
        }

        // Waits up to thirty seconds for the main window of a started process, because the window handle stays zero
        // until the window is created.
        private static void WaitForMainWindow(Process process)
        {
            // Poll the process until the window exists or the deadline passes.
            var deadline = DateTime.UtcNow.AddSeconds(30);

            while (process.MainWindowHandle == IntPtr.Zero && DateTime.UtcNow < deadline)
            {
                Thread.Sleep(millisecondsTimeout: 100);
                process.Refresh();
            }

            // Fail with a clear message rather than letting the driver report a missing root element.
            if (process.MainWindowHandle == IntPtr.Zero)
            {
                Assert.Fail("The click lab application did not show its main window within thirty seconds.");
            }
        }
    }
}
