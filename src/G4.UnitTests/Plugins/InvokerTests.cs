using G4.Api;
using G4.Extensions;
using G4.Models;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.UnitTests.Plugins
{
    [TestClass]
    [TestCategory("Invoker")]
    [TestCategory("UnitTest")]
    public class InvokerTests : TestBase
    {
        [TestMethod(displayName: "Verify that an action rule is correctly invoked and " +
            "that the response contains a session.")]
        public void InvokeActionTest()
        {
            // Define the action rule to be invoked.
            var ruleJson = new ActionRuleModel
            {
                PluginName = "InvokeClick",
                OnElement = "//positive"
            };

            // Define the driver parameters.
            var driverParameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["driver"] = "SimulatorDriver",
                ["driverBinaries"] = "."
            };

            // Set up the automation environment and configuration.
            Automation.NewStage([ruleJson]);
            Automation.DriverParameters = driverParameters;

            // Create an automation client to invoke the actions and get the response.
            var client = new G4Client();
            var response = client.Automation.Invoke(Automation);

            // Assert that the response contains a session.
            Assert.IsTrue(response.First().Value.Sessions.FirstOrDefault().Value != default);
        }

        [TestMethod(displayName:"Verify that an external action rule is correctly invoked and that " +
            "the response contains a session.")]
        public void InvokeExternalActionTest()
        {
            // Define the action rule to be invoked.
            var ruleJson = new ActionRuleModel
            {
                PluginName = "ExternalTestAction",
                OnElement = "//positive"
            };

            // Define the driver parameters.
            var driverParameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["driver"] = "SimulatorDriver",
                ["driverBinaries"] = "."
            };

            // Define the external repository.
            var repository = new G4ExternalRepositoryModel
            {
                Url = "http://localhost:9002",
                Version = 1,
                Capabilities = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            };

            // Set up the automation environment and configuration.
            Automation.NewStage([ruleJson]);
            Automation.DriverParameters = driverParameters;
            Automation.Settings.PluginsSettings.ExternalRepositories = [repository];

            // Create an automation client to invoke the actions and get the response.
            var client = new G4Client();
            var response = client.Automation.Invoke(Automation);

            // Assert that the response contains a session.
            Assert.IsTrue(response.First().Value.Sessions.FirstOrDefault().Value != default);
        }
    }
}
