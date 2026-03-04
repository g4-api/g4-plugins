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
    [TestCategory("GmailTasksList")]
    [TestCategory("UnitTest")]
    public class GmailTasksListsTests : TestBase
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            // Ensure a clean Data directory for repeatable tests.
            var directoryPath = Path.Combine(Environment.CurrentDirectory, "Data");
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, recursive: true);
            }

            // Build OAuth credential model from test configuration.
            var oauth = new OAuthCredentialModel
            {
                ClientId = $"{context.Properties["Google.App.ClientId"]}",
                ClientSecret = $"{context.Properties["Google.App.ClientSecret"]}",
                Domains = $"{context.Properties["Google.App.Domains"]}",
                Name = $"{context.Properties["Google.App.Name"]}",
                RedirectUrl = $"{context.Properties["Google.App.RedirectUrl"]}",
                RefreshToken = $"{context.Properties["Google.App.RefreshToken"]}",
                Scope = $"{context.Properties["Google.App.Scope"]}"
            };

            // Cache key convention: "<name>;<id>" (lowercase for normalization).
            var key = $"{oauth.Name};{oauth.Id}".ToLowerInvariant();

            // Seed the credentials cache with secured secrets.
            CacheManager.Instance.CredentialsCache[key] = new()
            {
                AccessToken = string.Empty,
                ClientId = oauth.ClientId,
                CreatedAt = oauth.CreatedAt,
                ExpiresAt = oauth.ExpiresAt,
                ClientSecret = oauth.ClientSecret.Protect(),
                Domains = oauth.Domains,
                Id = oauth.Id,
                Name = oauth.Name,
                Provider = "google",
                RedirectUrl = oauth.RedirectUrl,
                RefreshToken = oauth.RefreshToken.Protect(),
                Scope = oauth.Scope
            };
        }

        [TestMethod(DisplayName = "Verify that the GmailTasksList plugins comply with the " +
            "manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<NewGmailTasksList>();
            AssertManifest<RemoveGmailTasksList>();
            AssertManifest<UpdateGmailTasksList>();
            AssertManifest<G4.Plugins.Google.Actions.ExportGmailTasksLists>();
        }

        [TestMethod(DisplayName = "Verify that the GmailTasksList plugins are correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<NewGmailTasksList>();
            AssertPlugin<RemoveGmailTasksList>();
            AssertPlugin<UpdateGmailTasksList>();
            AssertPlugin<G4.Plugins.Google.Actions.ExportGmailTasksLists>();
        }

        [TestMethod(DisplayName = "Verify the lifecycle of a Gmail tasks list (Add, Update and Delete).")]
        public void GmailTasksListLifecycleTest()
        {
            NewTasksListTest();
            UpdateTasksListTest();
            RemoveTasksListTest();
        }

        [Ignore(message: "Runs as part of the GmailTasksListLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the NewGmailTasksList plugin creates a " +
            "new tasks list correctly.")]
        public void NewTasksListTest()
        {
            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "NewGmailTasksList",
                "argument": "{{$ --Title:TestsList --Credentials:$(name)}}"
            }
            """.Replace("$(name)", name);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;
            var id = session["GmailTasksListId"]?.ToString();
            var title = session["GmailTasksListTitle"]?.ToString();
            var link = session["GmailTasksListLink"]?.ToString();

            // Store the created task list id in the test context
            // for potential use in cleanup or other tests.
            DataBag["GmailTasksListId"] = id?.ConvertFromBase64() ?? string.Empty;

            // Assert required outputs exist.
            Assert.IsFalse(condition: string.IsNullOrEmpty(id));
            Assert.IsFalse(condition: string.IsNullOrEmpty(title));
            Assert.IsFalse(condition: string.IsNullOrEmpty(link));

            // Assert title round-trips correctly (stored as Base64).
            Assert.AreEqual(
                expected: "TestsList",
                actual: title.ConvertFromBase64() ?? string.Empty);
        }

        [Ignore(message: "Runs as part of the GmailTasksListLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the RemoveGmailTasksList plugin removes a " +
            "tasks list correctly.")]
        public void RemoveTasksListTest()
        {
            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";
            var id = $"{DataBag["GmailTasksListId"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "RemoveGmailTasksList",
                "argument": "{{$ --Credentials:$(name) --Id:$(id)}}"
            }
            """.Replace("$(name)", name).Replace("$(id)", id);

            // Invoke the action and read the session outputs produced by the plugin.
            var exceptions = Invoke(ruleJson).GetExceptions();

            // Assert required outputs exist.
            Assert.IsEmpty(exceptions);
        }

        [Ignore(message: "Runs as part of the GmailTasksListLifecycleTest.")]
        [TestMethod(DisplayName = "Verify that the UpdateGmailTasksList plugin updates a " +
            "tasks list correctly.")]
        public void UpdateTasksListTest()
        {
            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";
            var id = $"{DataBag["GmailTasksListId"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "UpdateGmailTasksList",
                "argument": "{{$ --Title:TestsListUpdated --Credentials:$(name) --Id:$(id)}}"
            }
            """.Replace("$(name)", name).Replace("$(id)", id);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;
            id = session["GmailTasksListId"]?.ToString();
            var title = session["GmailTasksListTitle"]?.ToString();
            var link = session["GmailTasksListLink"]?.ToString();

            // Assert required outputs exist.
            Assert.IsFalse(condition: string.IsNullOrEmpty(id));
            Assert.IsFalse(condition: string.IsNullOrEmpty(title));
            Assert.IsFalse(condition: string.IsNullOrEmpty(link));

            // Assert title round-trips correctly (stored as Base64).
            Assert.AreEqual(
                expected: "TestsListUpdated",
                actual: title.ConvertFromBase64() ?? string.Empty);
        }

        [TestMethod(DisplayName = "Verify that the ExportGmailTasksLists plugin exports all " +
            "tasks lists correctly.")]
        public void ExportTasksListsTest()
        {
            // Resolve the credential record name/id from test settings.
            var name = $"{TestContext.Properties["Google.App.Name"]}";

            // Build the action rule JSON and inject the credential reference.
            var ruleJson =
            """
            {
                "$type": "Action",
                "pluginName": "ExportGmailTasksLists",
                "argument": "{{$ --Credentials:$(name)}}"
            }
            """.Replace("$(name)", name);

            // Invoke the action and read the session outputs produced by the plugin.
            var session = Invoke(ruleJson).GetEnvironment().SessionParameters;

            var result = session["GmailTasksListsResult"]?.ToString().ConvertFromBase64();
            var list = JsonSerializer.Deserialize<object[]>(result) ?? [];

            // Assert required outputs exist.
            Assert.IsGreaterThan(lowerBound: 0, list.Length);
        }

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
                "argument": "{{$ --Title:New Task --Notes:Foo Bar --Due:09/20/2026 --Credentials:$(name) --TasksList:My Tasks}}"
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
    }
}
