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
        // The manifest plugin type whose examples carry a CLI argument, which the argument assertions read.
        private const string ActionPluginType = "Action";

        // The suffix of every switch parameter that marks an inline payload as UTF-8 Base64.
        private const string Base64Suffix = "Base64";

        // The resource-name segment that marks a manifest folder (for example Actions.Manifests).
        private const string ManifestsSegment = ".Manifests.";

        // The plugin assemblies whose embedded manifests are published to the engine cache. Each manifest's namespace
        // is the qualifier of its plugin references (Namespace:Key), so it must equal the owning assembly name.
        private static readonly string[] s_assemblyNames =
        [
            "G4.Plugins.Common",
            "G4.Plugins.Google",
            "G4.Plugins.MongoDb",
            "G4.Plugins.SqlServer",
            "G4.Plugins.Ui"
        ];

        // The plugin assemblies whose actions address a database deployment. Every one of their actions accepts both
        // a stored credentials record and a raw connection input, so both ways must appear in its examples.
        private static readonly string[] s_databaseAssemblyNames = ["G4.Plugins.MongoDb", "G4.Plugins.SqlServer"];

        // The connection parameters a database action manifest must write in at least one of its examples.
        private static readonly string[] s_connectionParameters = ["ConnectionString", "Credentials"];

        // Manifests deserialize case-insensitively, as the engine reads the camel-case manifest files.
        private static readonly JsonSerializerOptions s_jsonOptions = new() { PropertyNameCaseInsensitive = true };

        [TestMethod(DisplayName = "Verify that every embedded manifest declares its owning assembly name as its " +
            "namespace.")]
        #region *** Data Set ***
        [DataRow("G4.Plugins.Common")]
        [DataRow("G4.Plugins.Google")]
        [DataRow("G4.Plugins.MongoDb")]
        [DataRow("G4.Plugins.SqlServer")]
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

        [TestMethod(DisplayName = "Verify that every action manifest that declares a Base64 switch sets it in at " +
            "least one example.")]
        public void ManifestExamplesCoverBase64SwitchesTest()
        {
            // Arrange: read the action manifests of every plugin assembly.
            var manifests = ReadActionManifests(s_assemblyNames);

            // Act: list every Base64 switch that no example of its own manifest sets.
            var undocumented = manifests.SelectMany(selector: FindUndocumentedSwitches);

            // Assert: a flow author sees how each encoded payload is written, so a switch is never offered untold.
            Assert.AreEqual(expected: string.Empty, actual: string.Join(separator: ", ", values: undocumented));
        }

        [TestMethod(DisplayName = "Verify that every database action manifest writes both a credentials record and " +
            "a raw connection input in its examples.")]
        public void ManifestExamplesCoverConnectionInputsTest()
        {
            // Arrange: read the action manifests of the plugin assemblies that address a database deployment.
            var manifests = ReadActionManifests(s_databaseAssemblyNames);

            // Act: list every connection parameter that its manifest declares but writes in no example.
            var undocumented = manifests.SelectMany(selector: FindUndocumentedConnectionInputs);

            // Assert: the manifests document both ways to name a deployment, so neither way is left to be guessed.
            Assert.IsNotEmpty(collection: manifests);
            Assert.AreEqual(expected: string.Empty, actual: string.Join(separator: ", ", values: undocumented));
        }

        // Lists the connection parameters of one manifest that no example writes, each as Key/Parameter. A value
        // parameter is written as --Name:, which also separates it from a switch whose name starts the same way.
        private static IEnumerable<string> FindUndocumentedConnectionInputs(G4PluginAttribute manifest)
        {
            // Arrange: keep the declared parameters that name a deployment.
            var names = GetParameterNames(manifest).Where(predicate: s_connectionParameters.Contains);

            // Act: report each one that no example of the manifest writes.
            return names
                .Where(predicate: name => !TestExample(manifest, token: $"--{name}:"))
                .Select(selector: name => $"{manifest.Key}/{name}");
        }

        // Lists the Base64 switches of one manifest that no example sets, each as Key/Parameter. A switch carries no
        // value, so it is written as --Name without a separator.
        private static IEnumerable<string> FindUndocumentedSwitches(G4PluginAttribute manifest)
        {
            // Arrange: keep the declared parameters whose name marks an inline payload as UTF-8 Base64.
            var names = GetParameterNames(manifest)
                .Where(predicate: name => name.EndsWith(value: Base64Suffix, comparisonType: StringComparison.Ordinal));

            // Act: report each one that no example of the manifest sets.
            return names
                .Where(predicate: name => !TestExample(manifest, token: $"--{name}"))
                .Select(selector: name => $"{manifest.Key}/{name}");
        }

        // Lists the lookup names of one manifest, its key and every alias, each prefixed with the plugin type.
        // Repeated names are kept, so an alias that repeats the key is reported as a duplicate.
        private static IEnumerable<string> GetIdentities(G4PluginAttribute manifest)
        {
            // Arrange: combine the canonical key with the optional aliases.
            var names = (manifest.Aliases ?? []).Prepend(element: manifest.Key);

            return names.Select(selector: name => $"{manifest.PluginType}/{name}");
        }

        // Lists the declared parameter names of one manifest, which a manifest without parameters reports as empty.
        private static IEnumerable<string> GetParameterNames(G4PluginAttribute manifest)
        {
            // Act: read the name of every declared parameter.
            return (manifest.Parameters ?? []).Select(selector: parameter => parameter.Name);
        }

        // Reads the action manifests of the given plugin assemblies, which are the manifests whose examples carry a
        // CLI argument. Every other plugin type is addressed through its rule instead of an argument.
        private static List<G4PluginAttribute> ReadActionManifests(IEnumerable<string> assemblyNames)
        {
            // Act: read every manifest of every assembly and keep the action manifests.
            return [.. assemblyNames
                .SelectMany(selector: ReadManifests)
                .Select(selector: item => item.Manifest)
                .Where(predicate: manifest => manifest.PluginType == ActionPluginType)];
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

        // Determines whether any example of the manifest writes the token in its rule argument.
        private static bool TestExample(G4PluginAttribute manifest, string token)
        {
            // Arrange: read the CLI argument of every example, treating a missing argument as empty.
            var arguments = (manifest.Examples ?? [])
                .Select(selector: example => example.Rule?.Argument ?? string.Empty);

            // Act: look for the token in any of them.
            return arguments.Any(
                predicate: argument => argument.Contains(value: token, comparisonType: StringComparison.Ordinal));
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
