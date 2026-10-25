using G4.Attributes;
using G4.Extensions;
using G4.Plugins.Common.DataCollectors;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Reflection;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("Plugins.Common")]
    [TestCategory("UnitTest")]
    public class DataCollectorManifestTests
    {
        [TestMethod(DisplayName = "Verify that every data collector manifest renders its documentation and examples.")]
        #region *** Data Set ***
        [DataRow(typeof(CsvDataCollector))]
        [DataRow(typeof(JsonDataCollector))]
        [DataRow(typeof(SqLiteDataCollector))]
        [DataRow(typeof(XmlDataCollector))]
        #endregion
        public void DataCollectorManifestRendersTest(Type collectorType)
        {
            // Arrange: read the embedded manifest the cache loads for the collector.
            var manifest = collectorType.GetCustomAttribute<G4PluginAttribute>();

            // Act: render the documentation the way the cache does before it accepts a plugin.
            var document = manifest.ConvertToMarkdown(includeNavigationLinks: false);

            // Assert: the manifest loads and renders, so the cache does not reject the collector.
            Assert.IsNotNull(value: manifest);
            Assert.IsFalse(condition: string.IsNullOrWhiteSpace(value: document));
        }

        [TestMethod(DisplayName = "Verify that the SQLite data collector key is spelled SqLite and keeps the old spelling as an alias.")]
        public void SqLiteDataCollectorKeyAndAliasTest()
        {
            // Arrange: read the embedded manifest of the SQLite collector.
            var manifest = typeof(SqLiteDataCollector).GetCustomAttribute<G4PluginAttribute>();

            // Assert: the key matches the class name, and bots that still name the old key resolve through the alias.
            Assert.AreEqual(expected: "SqLiteDataCollector", actual: manifest.Key);
            Assert.Contains(expected: "SqLightDataCollector", collection: manifest.Aliases);
        }
    }
}
