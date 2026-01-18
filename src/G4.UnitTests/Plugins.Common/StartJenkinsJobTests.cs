using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("WriteLog")]
    [TestCategory("UnitTest")]
    public class StartJenkinsJobTests : TestBase
    {
        private const string _ignoreMessage = "Test is intended for execution only in a local demo environment. " +
            "Not suitable for production or CI/CD pipelines due to external dependencies.";

        [TestMethod(DisplayName = "Verify that the StartJenkinsJob plugin manifest complies with " +
            "the expected structure and content.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<StartJenkinsJob>();
        }

        [TestMethod(DisplayName = "Verify that the StartJenkinsJob plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            AssertPlugin<StartJenkinsJob>();
        }

        [Ignore(message: _ignoreMessage)]
        [TestMethod(DisplayName = "Verify that the StartJenkinsJob plugin starts a Jenkins job with issue and " +
            "project fields, waits for completion, and finishes without any exceptions.")]
        public void StartJenkinsJobTest()
        {
            // Define a single Action rule that invokes the StartJenkinsJob plugin
            // with URL, job path, credentials, wait flag, and JIRA-related fields.
            var rule = new Dictionary<string, object>
            {
                ["$type"] = "Action",
                ["pluginName"] = "StartJenkinsJob",
                ["argument"] = "{{$ " +
                    "--Url:http://localhost:8009 " +
                    "--JobPath:labels-collector " +
                    "--Username:sa " +
                    "--Wait " +
                    "--Token:11f111047c1f2227fd9ca75d78333a9917 " +
                    "--Field:ISSUE_KEY=QDP-2 " +
                    "--Field:PROJECT_KEY:QDP}}"
            };

            // Serialize the rule dictionary into a JSON payload that can be
            // consumed by the rule engine / plugin runtime.
            var ruleJson = JsonSerializer.Serialize(rule);

            // Invoke the rule and collect any exceptions that occurred during execution.
            var exceptions = Invoke(ruleJson).GetExceptions();

            // Assert that the plugin completed successfully without throwing any exceptions.
            Assert.IsFalse(exceptions.Any());
        }

        [Ignore(message: _ignoreMessage)]
        [TestMethod(DisplayName = "Verify that the StartJenkinsJob plugin starts a Jenkins job without waiting " +
            "for completion and finishes without any exceptions.")]
        public void StartJenkinsJobNoWaitTest()
        {
            // Define a StartJenkinsJob rule that triggers the job but does not wait
            // for completion (no --Wait flag), still passing the issue and project fields.
            var rule = new Dictionary<string, object>
            {
                ["$type"] = "Action",
                ["pluginName"] = "StartJenkinsJob",
                ["argument"] = "{{$ " +
                    "--Url:http://localhost:8009 " +
                    "--JobPath:labels-collector " +
                    "--Username:sa " +
                    "--Token:11f111047c1f2227fd9ca75d78333a9917 " +
                    "--Field:ISSUE_KEY=QDP-2 " +
                    "--Field:PROJECT_KEY:QDP}}"
            };

            // Serialize the rule into JSON for the rule engine / plugin runtime.
            var ruleJson = JsonSerializer.Serialize(rule);

            // Execute the rule and gather any exceptions thrown during plugin execution.
            var exceptions = Invoke(ruleJson).GetExceptions();

            // Ensure that starting the job without waiting does not produce any exceptions.
            Assert.IsFalse(exceptions.Any());
        }

        [Ignore(message: _ignoreMessage)]
        [TestMethod(DisplayName = "Verify that the StartJenkinsJob plugin fails when mandatory job parameters " +
            "are not provided.")]
        public void StartJenkinsJobNoParametersTest()
        {
            // Define a StartJenkinsJob rule that only provides the core connection
            // details and wait flag, without any additional field parameters.
            var rule = new Dictionary<string, object>
            {
                ["$type"] = "Action",
                ["pluginName"] = "StartJenkinsJob",
                ["argument"] = "{{$ " +
                    "--Url:http://localhost:8009 " +
                    "--JobPath:labels-collector " +
                    "--Username:sa " +
                    "--Token:11f111047c1f2227fd9ca75d78333a9917 " +
                    "--Wait}}"
            };

            // Convert the rule definition into JSON for the engine to consume.
            var ruleJson = JsonSerializer.Serialize(rule);

            // Invoke the rule and capture any exceptions raised during execution.
            var exceptions = Invoke(ruleJson).GetExceptions();

            // Verify that running the job without the required parameters results in a failure.
            Assert.IsTrue(exceptions.Any());
        }
    }
}
