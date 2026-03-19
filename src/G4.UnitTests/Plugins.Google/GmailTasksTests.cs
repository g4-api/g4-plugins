using G4.Cache;
using G4.Credentials.Models;
using G4.Extensions;
using G4.Plugins.Google.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Google
{
    [TestClass]
    [TestCategory("GmailTaskList")]
    [TestCategory("UnitTest")]
    public class GmailTasksTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the GmailTask plugins comply with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<NewGmailTaskList>();
            AssertManifest<RemoveGmailTaskList>();
            AssertManifest<UpdateGmailTaskList>();
            AssertManifest<ExportGmailTaskLists>();

            AssertManifest<NewGmailTask>();
            AssertManifest<UpdateGmailTask>();
            AssertManifest<ExportGmailTasks>();
            AssertManifest<RemoveGmailTask>();
            AssertManifest<MoveGmailTask>();
        }

        [TestMethod(DisplayName = "Verify that the GmailTask plugins are correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<NewGmailTaskList>();
            AssertPlugin<RemoveGmailTaskList>();
            AssertPlugin<UpdateGmailTaskList>();
            AssertPlugin<ExportGmailTaskLists>();

            AssertPlugin<NewGmailTask>();
            AssertPlugin<UpdateGmailTask>();
            AssertPlugin<ExportGmailTasks>();
            AssertPlugin<RemoveGmailTask>();
            AssertPlugin<MoveGmailTask>();
        }

        [Ignore(message: "Runs as part of the GmailTaskListLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the NewGmailTaskList plugin creates a " +
            "new tasks list correctly.")]
        public void NewTaskListTest()
        {
            // Plugin name for session output keys.
            const string pluginName = nameof(NewGmailTaskList);

            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "NewGmailTaskList",
                "argument": "{{$ --Title:TestsList --Credentials:$(name)}}"
            }
            """.Replace("$(name)", name);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;
            var id = session[$"{pluginName}:Id"]?.ToString();
            var title = session[$"{pluginName}:Title"]?.ToString();
            var link = session[$"{pluginName}:SelfLink"]?.ToString();

            // Store the created task list id in the test context
            // for potential use in cleanup or other tests.
            DataBag["NewGmailTaskList:Id"] = id?.ConvertFromBase64() ?? string.Empty;

            // Assert required outputs exist.
            Assert.IsFalse(condition: string.IsNullOrEmpty(id));
            Assert.IsFalse(condition: string.IsNullOrEmpty(title));
            Assert.IsFalse(condition: string.IsNullOrEmpty(link));

            // Assert title round-trips correctly (stored as Base64).
            Assert.AreEqual(
                expected: "TestsList",
                actual: title.ConvertFromBase64() ?? string.Empty);
        }

        [Ignore(message: "Runs as part of the GmailTaskListLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the RemoveGmailTaskList plugin removes a " +
            "tasks list correctly.")]
        public void RemoveTaskListTest()
        {
            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";
            var id = $"{DataBag["NewGmailTaskList:Id"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "RemoveGmailTaskList",
                "argument": "{{$ --Credentials:$(name) --Id:$(id)}}"
            }
            """.Replace("$(name)", name).Replace("$(id)", id);

            // Invoke the action and read the session outputs produced by the plugin.
            var exceptions = Invoke(ruleJson).GetExceptions();

            // Assert required outputs exist.
            Assert.IsEmpty(exceptions);
        }

        [Ignore(message: "Runs as part of the GmailTaskListLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the UpdateGmailTaskList plugin updates a " +
            "tasks list correctly.")]
        public void UpdateTaskListTest()
        {
            // Plugin name for session output keys.
            const string pluginName = nameof(UpdateGmailTaskList);

            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";
            var id = $"{DataBag["NewGmailTaskList:Id"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "UpdateGmailTaskList",
                "argument": "{{$ --Title:TestsListUpdated --Credentials:$(name) --Id:$(id)}}"
            }
            """.Replace("$(name)", name).Replace("$(id)", id);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;
            id = session[$"{pluginName}:Id"]?.ToString();
            var title = session[$"{pluginName}:Title"]?.ToString();
            var link = session[$"{pluginName}:SelfLink"]?.ToString();

            // Assert required outputs exist.
            Assert.IsFalse(condition: string.IsNullOrEmpty(id));
            Assert.IsFalse(condition: string.IsNullOrEmpty(title));
            Assert.IsFalse(condition: string.IsNullOrEmpty(link));

            // Assert title round-trips correctly (stored as Base64).
            Assert.AreEqual(
                expected: "TestsListUpdated",
                actual: title.ConvertFromBase64() ?? string.Empty);
        }

        [TestMethod(DisplayName = "Verify that the ExportGmailTaskLists plugin exports all " +
            "tasks lists correctly.")]
        public void ExportTaskListsTest()
        {
            // Plugin name for session output keys.
            const string pluginName = nameof(ExportGmailTaskLists);

            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "ExportGmailTaskLists",
                "argument": "{{$ --Credentials:$(name)}}"
            }
            """.Replace("$(name)", name);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;

            var result = session[$"{pluginName}:Result"]?.ToString().ConvertFromBase64();
            var list = JsonSerializer.Deserialize<JsonElement>(result);

            // Assert required outputs exist.
            Assert.IsGreaterThan(lowerBound: 0, list.GetProperty("items").GetArrayLength());
        }

        [Ignore(message: "Runs as part of the GmailTasktLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the ExportGmailTasks plugin exports " +
            "all tasks correctly.")]
        public void ExportTasksTest()
        {
            // Plugin name for session output keys.
            const string pluginName = nameof(ExportGmailTasks);

            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference and task list name.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "ExportGmailTasks",
                "argument": "{{$ --Credentials:$(name) --TaskList:My Tasks}}"
            }
            """.Replace("$(name)", name);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;
            var result = session[$"{pluginName}:Result"]?.ToString().ConvertFromBase64();
            var tasks = JsonSerializer.Deserialize<JsonElement>(result);

            // Assert required outputs exist.
            Assert.IsGreaterThan(lowerBound: 0, tasks.GetArrayLength());
        }

        [Ignore(message: "Runs as part of the GmailTasktLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the NewGmailTask plugin creates a " +
            "new task correctly.")]
        public void NewTaskTest()
        {
            // Plugin name for session output keys.
            const string pluginName = nameof(NewGmailTask);

            // Resolve the credential record name/id from the test configuration.
            // This value is injected into the rule so the plugin can obtain
            // an OAuth access token at runtime.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference.
            // The rule invokes the NewGmailTask plugin with a title, notes,
            // due date, target task list, and credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "NewGmailTask",
                "argument": "{{$ --Title:New Task --Notes:Foo Bar --Due:09/20/2026 --Credentials:$(name) --TaskList:My Tasks}}"
            }
            """.Replace("$(name)", name);

            // Execute the rule and obtain the session parameters produced by the plugin.
            // Plugins store their outputs in the session using the pattern:
            // <PluginName>:<Property>.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;

            var id = session[$"{pluginName}:Id"]?.ToString();
            var title = session[$"{pluginName}:Title"]?.ToString();
            var link = session[$"{pluginName}:SelfLink"]?.ToString();
            var position = session[$"{pluginName}:Position"]?.ToString();
            var status = session[$"{pluginName}:Status"]?.ToString();

            // Persist the created task id in the shared test data bag so it can be
            // reused by cleanup steps or other related tests.
            DataBag["GmailTaskId"] = id?.ConvertFromBase64() ?? string.Empty;

            // Verify that the plugin returned all required outputs.
            Assert.IsFalse(condition: string.IsNullOrEmpty(id));
            Assert.IsFalse(condition: string.IsNullOrEmpty(title));
            Assert.IsFalse(condition: string.IsNullOrEmpty(link));
            Assert.IsFalse(condition: string.IsNullOrEmpty(position));
            Assert.IsFalse(condition: string.IsNullOrEmpty(status));

            // Verify that the title value matches the input.
            // Plugin outputs are stored as Base64-encoded strings in session parameters.
            Assert.AreEqual(
                expected: "New Task",
                actual: title.ConvertFromBase64() ?? string.Empty);
        }

        [Ignore(message: "Runs as part of the GmailTasktLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the RemoveGmailTask plugin deletes an " +
            "existing task correctly.")]
        public void RemoveTaskTest()
        {
            // Resolve the credential record name/id from the test configuration.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Read the task id produced by the create test (stored in the shared data bag).
            var id = DataBag["GmailTaskId"]?.ToString() ?? string.Empty;

            // Ensure we have a task id to delete; otherwise the test is not valid.
            Assert.IsFalse(condition: string.IsNullOrWhiteSpace(id));

            // Build the action rule JSON and inject the credential reference and task id.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "RemoveGmailTask",
                "argument": "{{$ --Task:$(id) --Credentials:$(name) --TaskList:My Tasks}}"
            }
            """.Replace("$(name)", name).Replace("$(id)", id);

            // Invoke the action and ensure no exceptions were produced by the workflow.
            var exceptions = Invoke(ruleJson).GetExceptions();

            // Assert that the plugin executed without errors.
            Assert.IsEmpty(exceptions);
        }

        [Ignore(message: "Runs as part of the GmailTaskLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the UpdateGmailTask plugin updates an " +
            "existing task correctly.")]
        public void UpdateTaskTest()
        {
            // Plugin name used for resolving session output keys.
            const string pluginName = nameof(UpdateGmailTask);

            // Resolve the credential record name/id from the test configuration.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Read the task id created by a previous test from the shared data bag.
            var id = $"{DataBag["GmailTaskId"]}";

            // Ensure a task id is available before attempting the update.
            Assert.IsFalse(condition: string.IsNullOrWhiteSpace(id));

            // Build the action rule JSON and inject the credential reference and task id.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "UpdateGmailTask",
                "argument": "{{$ --Title:New Task Updated --Credentials:$(name) --Task:$(id) --TaskList:My Tasks}}"
            }
            """.Replace("$(name)", name).Replace("$(id)", id);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;

            id = session[$"{pluginName}:Id"]?.ToString();
            var title = session[$"{pluginName}:Title"]?.ToString();
            var link = session[$"{pluginName}:SelfLink"]?.ToString();
            var position = session[$"{pluginName}:Position"]?.ToString();
            var status = session[$"{pluginName}:Status"]?.ToString();

            // Verify that the plugin returned all expected outputs.
            Assert.IsFalse(condition: string.IsNullOrEmpty(id));
            Assert.IsFalse(condition: string.IsNullOrEmpty(title));
            Assert.IsFalse(condition: string.IsNullOrEmpty(link));
            Assert.IsFalse(condition: string.IsNullOrEmpty(position));
            Assert.IsFalse(condition: string.IsNullOrEmpty(status));

            // Verify that the updated title matches the requested value.
            // Plugin outputs are stored as Base64-encoded strings in session parameters.
            Assert.AreEqual(
                expected: "New Task Updated",
                actual: title.ConvertFromBase64() ?? string.Empty);
        }

        [TestMethod(DisplayName = "Verify the lifecycle of a Gmail tasks list (Add, Update and Delete).")]
        public void GmailTaskListLifecycleTest()
        {
            NewTaskListTest();
            UpdateTaskListTest();
            RemoveTaskListTest();
        }

        [TestMethod(DisplayName = "Verify the lifecycle of a Gmail task (Add, Update and Delete).")]
        public void GmailTasktLifecycleTest()
        {
            NewTaskTest();
            ExportTasksTest();
            UpdateTaskTest();
            RemoveTaskTest();
        }

        [DoNotParallelize]
        [TestMethod(DisplayName = "Verify the lifecycle of moving a Gmail task.")]
        public void MoveTaskLifecycleTest()
        {
            try
            {
                // Create a source task and a destination task list used by this test.
                NewTaskTest();
                NewTaskListTest();

                // Resolve the credential record name/id from the test configuration.
                var name = $"{TestContext.Properties["Google.App.Name"]}";

                // Read the created task id and destination list id from the shared data bag.
                var id = $"{DataBag["GmailTaskId"]}";
                var destination = $"{DataBag["NewGmailTaskList:Id"]}";

                // Ensure a task id is available before attempting the move.
                Assert.IsFalse(condition: string.IsNullOrWhiteSpace(id));

                // Build the action rule JSON and inject the credential reference,
                // source task id, and destination task list id.
                var ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "MoveGmailTask",
                    "argument": "{{$ --TaskList:My Tasks --Task:$(id) --Destination:$(destination) --Credentials:$(name)}}"
                }
                """
                .Replace("$(name)", name)
                .Replace("$(id)", id)
                .Replace("$(destination)", destination);

                // Invoke the action and collect any workflow exceptions.
                var exceptions = Invoke(ruleJson).GetExceptions();

                // Assert that the plugin executed without errors.
                Assert.IsEmpty(exceptions);
            }
            finally
            {
                // Clean up the destination task list created for this test.
                RemoveTaskListTest();
            }
        }
    }
}
