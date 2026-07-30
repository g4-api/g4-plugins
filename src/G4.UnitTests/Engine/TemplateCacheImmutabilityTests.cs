using G4.Api;
using G4.Attributes;
using G4.Cache;
using G4.Extensions;
using G4.Models;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace G4.UnitTests.Engine
{
    [Retry(maxRetryAttempts: 3)]
    [TestClass]
    [TestCategory("Engine")]
    [TestCategory("Template")]
    [TestCategory("Regression")]
    [TestCategory("UnitTest")]
    public class TemplateCacheImmutabilityTests : TestBase
    {
        private static readonly JsonSerializerOptions LocalJsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultBufferSize = 1
        };

        [TestMethod(DisplayName = "Verify that initializing a template does not mutate the " +
            "cached manifest rules (single-threaded).")]
        public void TemplateInitializeDoesNotMutateCachedManifestRulesTest()
        {
            // Register the Login template (source=Template, 3 child rules, no references).
            var client = new G4Client();
            var key = RegisterLoginTemplate(client);

            try
            {
                // Resolve the live cached manifest instance the metadata API would serialize.
                var cachedBefore = client.Integration.GetManifest<G4PluginAttribute>(key);
                Assert.IsNotNull(
                    value: cachedBefore,
                    message: "The registered template manifest was not found in the cache.");

                // Capture the cached rules and assert the pristine baseline: template rules
                // are authored without references, so every rule reference must start null.
                var rulesBefore = cachedBefore.Rules.ToArray();
                Assert.HasCount(
                    expected: 3,
                    collection: rulesBefore,
                    message: "The Login template is expected to expose exactly three rules.");
                Assert.IsTrue(
                    condition: rulesBefore.All(i => i.Reference == null),
                    message: "Baseline invalid: cached template rules must have no reference before initialization.");

                // Initialize an automation that expands the template; this runs InitializeRule,
                // which (before the fix) mutated the shared cached rules in place.
                InitializeTemplate(key);

                // The metadata API must still resolve the same cached instance (no resync),
                // and its rules must remain pristine - the fix cloned them before mutation.
                var cachedAfter = client.Integration.GetManifest<G4PluginAttribute>(key);
                Assert.IsTrue(
                    condition: ReferenceEquals(cachedBefore, cachedAfter),
                    message: "The cached manifest instance changed during initialization; the assertion no longer observes the shared instance.");

                var rulesAfter = cachedAfter.Rules.ToArray();
                Assert.IsTrue(
                    condition: rulesAfter.All(i => i.Reference == null),
                    message: "Cached template rules were mutated during initialization (Reference populated); the cache-immutability fix regressed.");
            }
            finally
            {
                // Remove the template so the shared engine database stays clean for other tests.
                client.Templates.RemoveTemplate(key);
            }
        }

        [TestMethod(DisplayName = "Verify that concurrent template initialization and manifest " +
            "serialization keep the cached manifest immutable and exception-free.")]
        public void ConcurrentTemplateInitializeAndSerializeKeepsCacheImmutableTest()
        {
            // Register the Login template once for the whole concurrent run.
            var client = new G4Client();
            var key = RegisterLoginTemplate(client);

            try
            {
                // Resolve the live cached manifest instance and capture the pristine baseline.
                var cached = client.Integration.GetManifest<G4PluginAttribute>(key);
                Assert.IsNotNull(
                    value: cached,
                    message: "The registered template manifest was not found in the cache.");
                Assert.IsTrue(
                    condition: cached.Rules.All(i => i.Reference == null),
                    message: "Baseline invalid: cached template rules must have no reference before initialization.");

                // Collect any failure observed on a background task.
                var failures = new ConcurrentBag<Exception>();
                using var cancellation = new CancellationTokenSource();

                // Serializer loop: stream the cached manifest with a one-byte buffer so
                // System.Text.Json suspends and resumes mid-graph (as ASP.NET Core does when
                // writing the metadata response), while asserting the rules stay pristine.
                var serializer = Task.Run(async () =>
                {
                    while (!cancellation.IsCancellationRequested)
                    {
                        try
                        {
                            using var stream = new MemoryStream();
                            await JsonSerializer.SerializeAsync(stream, cached, LocalJsonOptions, cancellation.Token);

                            if (cached.Rules.Any(i => i.Reference != null))
                            {
                                throw new InvalidOperationException(
                                    "Cached template rules were mutated during concurrent initialization (Reference populated).");
                            }
                        }
                        catch (Exception e)
                        {
                            failures.Add(e);
                            cancellation.Cancel();
                        }
                    }
                }, cancellation.Token);

                // Initializer loop: several tasks drive the template initialization path in parallel.
                var initializers = Enumerable.Range(0, 4).Select(_ => Task.Run(() =>
                {
                    for (var i = 0; i < 5 && !cancellation.IsCancellationRequested; i++)
                    {
                        try
                        {
                            InitializeTemplate(key);
                        }
                        catch (Exception e)
                        {
                            failures.Add(e);
                            cancellation.Cancel();
                        }
                    }
                }, cancellation.Token)).ToArray();

                // Wait for the initializers to finish, then stop and drain the serializer loop.
                Task.WaitAll(initializers, cancellation.Token);
                cancellation.Cancel();
                serializer.Wait(cancellation.Token);

                // No background task may have failed, and the cache must remain pristine.
                Assert.IsTrue(
                    condition: failures.IsEmpty,
                    message: $"Concurrent initialization/serialization failed: {failures.FirstOrDefault()}");
                Assert.IsTrue(
                    condition: cached.Rules.All(i => i.Reference == null),
                    message: "Cached template rules were mutated during concurrent initialization; the cache-immutability fix regressed.");
            }
            finally
            {
                // Remove the template so the shared engine database stays clean for other tests.
                client.Templates.RemoveTemplate(key);
            }
        }

        // Registers the Login template resource and returns its key.
        private static string RegisterLoginTemplate(G4Client client)
        {
            // Load the template manifest resource copied to the test output directory.
            var json = File.ReadAllText("Resources/LoginTemplate.txt").Trim();
            var manifest = JsonSerializer.Deserialize<G4PluginAttribute>(json, LocalJsonOptions);

            // Add (or overwrite) the template so it is available in the plugins cache.
            client.Templates.AddTemplate(manifest);

            // Return the template key used to resolve and remove it.
            return manifest.Key;
        }

        // Builds a minimal automation that expands the given template rule and runs the
        // initialization pipeline (InitializeRule) - where the cache-immutability fix lives.
        // This path performs no engine login, so it needs no credentials.
        private static void InitializeTemplate(string key)
        {
            // Create the top-level action rule that references the template by its key.
            var rule = new ActionRuleModel
            {
                PluginName = key,
                Argument = "{{$ --Username:Foo --Password:Bar}}"
            };

            // Wrap the rule in a minimal single-stage, single-job automation.
            var automation = new G4AutomationModel
            {
                Settings = new G4SettingsModel { PluginsSettings = new PluginsSettingsModel() },
                Stages =
                [
                    new G4StageModel
                    {
                        Jobs = [new G4JobModel { Rules = [rule] }]
                    }
                ]
            };

            // Run the initialization pipeline against the shared cache singleton.
            automation.Initialize(CacheManager.Instance);
        }
    }
}
