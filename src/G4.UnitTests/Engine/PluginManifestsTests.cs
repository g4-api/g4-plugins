using G4.Attributes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace G4.UnitTests.Engine
{
    [TestClass]
    [TestCategory("Engine")]
    [TestCategory("PluginManifests")]
    [TestCategory("UnitTest")]
    public class PluginManifestsTests
    {
        // The resource-name segment that marks a manifest folder (for example Actions.Manifests).
        private const string ManifestsSegment = ".Manifests.";

        // The plugin assemblies whose embedded manifests are published to the engine cache. Each manifest's namespace
        // is the qualifier of its plugin references (Namespace:Key), so it must equal the owning assembly name.
        private static readonly string[] s_assemblyNames = ["G4.Plugins.Common", "G4.Plugins.Google", "G4.Plugins.Ui"];

        // Manifests deserialize case-insensitively, as the engine reads the camel-case manifest files.
        private static readonly JsonSerializerOptions s_jsonOptions = new() { PropertyNameCaseInsensitive = true };

        [TestMethod(DisplayName = "Verify that every embedded manifest declares its owning assembly name as its " +
            "namespace.")]
        #region *** Data Set ***
        [DataRow("G4.Plugins.Common")]
        [DataRow("G4.Plugins.Google")]
        [DataRow("G4.Plugins.Ui")]
        #endregion
        public void ManifestNamespaceMatchesAssemblyTest(string assemblyName)
        {
            // Arrange: read every manifest the plugin assembly embeds.
            var manifests = ReadManifests(assemblyName);

            // Act: describe each manifest whose namespace differs from the assembly name.
            var mismatches = manifests
                .Where(predicate: item => item.Manifest.Namespace != assemblyName)
                .Select(selector: item => $"{item.Resource}: {item.Manifest.Namespace}");

            // Assert: the assembly embeds manifests, and every one of them is qualified by the assembly name.
            Assert.IsNotEmpty(collection: manifests);
            Assert.AreEqual(expected: string.Empty, actual: string.Join(separator: ", ", values: mismatches));
        }

        [TestMethod(DisplayName = "Verify that no key or alias is declared twice within one plugin type across the " +
            "plugin assemblies.")]
        public void ManifestIdentityIsUniqueWithinPluginTypeTest()
        {
            // Arrange: read every manifest of every plugin assembly.
            var manifests = s_assemblyNames.SelectMany(selector: ReadManifests);

            // Act: list each key and alias under its plugin type, and keep the names declared more than once.
            var duplicates = manifests
                .SelectMany(selector: item => GetIdentities(item.Manifest))
                .GroupBy(keySelector: identity => identity, comparer: StringComparer.OrdinalIgnoreCase)
                .Where(predicate: group => group.Count() > 1)
                .Select(selector: group => group.Key);

            // Assert: every lookup name resolves to exactly one plugin of its type, and no alias repeats its key.
            Assert.AreEqual(expected: string.Empty, actual: string.Join(separator: ", ", values: duplicates));
        }

        // Lists the lookup names of one manifest, its key and every alias, each prefixed with the plugin type.
        // Repeated names are kept, so an alias that repeats the key is reported as a duplicate.
        private static IEnumerable<string> GetIdentities(G4PluginAttribute manifest)
        {
            // Arrange: combine the canonical key with the optional aliases.
            var names = (manifest.Aliases ?? []).Prepend(element: manifest.Key);

            return names.Select(selector: name => $"{manifest.PluginType}/{name}");
        }

        // Reads every embedded JSON manifest of one plugin assembly together with its resource name.
        private static List<(string Resource, G4PluginAttribute Manifest)> ReadManifests(string assemblyName)
        {
            // Arrange: select the JSON resources stored under a manifests folder.
            var assembly = Assembly.Load(assemblyString: assemblyName);
            var resources = assembly
                .GetManifestResourceNames()
                .Where(predicate: TestManifestResource);

            // Act: deserialize each resource as the plugin manifest the engine caches.
            var manifests = new List<(string Resource, G4PluginAttribute Manifest)>();
            foreach (var resource in resources)
            {
                using var stream = assembly.GetManifestResourceStream(name: resource);
                using var reader = new StreamReader(stream: stream);
                var json = reader.ReadToEnd();
                var manifest = JsonSerializer.Deserialize<G4PluginAttribute>(json: json, options: s_jsonOptions);
                manifests.Add(item: (resource, manifest));
            }

            return manifests;
        }

        // Determines whether an embedded resource is a plugin manifest: a JSON file stored under a manifests folder.
        private static bool TestManifestResource(string resourceName)
        {
            // Act: require both the manifests folder segment and the JSON extension.
            var isManifestFolder = resourceName.Contains(
                value: ManifestsSegment,
                comparisonType: StringComparison.Ordinal);
            var isJson = resourceName.EndsWith(value: ".json", comparisonType: StringComparison.OrdinalIgnoreCase);

            return isManifestFolder && isJson;
        }
    }
}
