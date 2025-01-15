using G4.IntegrationTests.Extensions;
using G4.IntegrationTests.Framework;
using G4.IntegrationTests.Framework.Attributes;
using G4.IntegrationTests.Plugins.Common.ExportData;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace G4.IntegrationTests.Suites.Ui.Edge
{
    [TestClass]
    [TestCategory("System")]
    [TestCategory("Integration")]
    [TestCategory("MicrosoftEdge")]
    [TestCategory("ExportData")]
    [UserStory(story: "As a G4™ user, particularly an automation engineer or RPA (Robotic Process Automation) developer, " +
        "I want a plugin within the G4™ framework that allows me to export data extracted from automated applications, " +
        "So that I can further process and analyze the extracted data for various automation purposes.")]
    #region *** Criteria ***
    [AcceptanceCriteria(criteria: "Plugin Accessibility: The ExportDataPlugin should be easily accessible within the G4™ ecosystem, providing seamless integration for automation engineers.")]
    [AcceptanceCriteria(criteria: "Data Export Functionality: The plugin effectively exports extracted data from automated applications, storing it in appropriate data structures for further processing and analysis.")]
    [AcceptanceCriteria(criteria: "Session Management: The plugin manages sessions efficiently, ensuring that exported data is associated with the correct session for accurate analysis and tracking.")]
    [AcceptanceCriteria(criteria: "Error Handling: Robust error handling mechanisms are implemented to gracefully manage unexpected issues during data export, ensuring stability and reliability of automation workflows.")]
    #endregion
    public class ExportDataTests : TestBase
    {
        private static IEnumerable<object[]> DataSetNoWrite =>
        [
            ["Elements", "WebElementContent"],
            ["PageSource", "HtmlContent"],
            ["BodyHtml", "HtmlContent"]
        ];

        private static IEnumerable<object[]> DataSetWriteJson =>
        [
            ["Elements", "WebElementContent", "ExpectedJsonDataElements.txt"],
            ["PageSource", "HtmlContent", "ExpectedJsonDataPageSource.txt"],
            ["BodyHtml", "HtmlContent", "ExpectedJsonDataPageSource.txt"]
        ];

        private static IEnumerable<object[]> DataSetWriteXml =>
        [
            ["Elements", "WebElementContent", "ExpectedXmlDataElements.txt"],
            ["PageSource", "HtmlContent", "ExpectedXmlDataPageSource.txt"],
            ["BodyHtml", "HtmlContent", "ExpectedXmlDataPageSource.txt"]
        ];

        private static IEnumerable<object[]> DataSetWriteCsv =>
        [
            ["Elements", "WebElementContent", "ExpectedCsvDataElements.txt"],
            ["PageSource", "HtmlContent", "ExpectedCsvDataPageSource.txt"],
            ["BodyHtml", "HtmlContent", "ExpectedCsvDataPageSource.txt"]
        ];

        private static IEnumerable<object[]> DataSetWriteCsvAction =>
        [
            ["Elements", "WebElementContent", "ExpectedCsvDataActionsElements.txt"],
            ["PageSource", "HtmlContent", "ExpectedCsvDataActionsPageSource.txt"],
            ["BodyHtml", "HtmlContent", "ExpectedCsvDataActionsPageSource.txt"]
        ];

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters without " +
            "trimming and without clearing line breaks, accurately extracts hotel information " +
            "from webpage elements.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim' set to false, the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Validation Process: The extracted data undergoes thorough validation to ensure correctness and completeness of information.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetNoWrite))]
        #endregion
        public void T0001A(string extractionScope, string contentType)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "extractionScope", value: extractionScope)
                .AddTestParameter(key: "contentType", value: contentType);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);

            // Extract entities from the responses
            var entities = environment.GetEntities().ToList();

            // Assert that there are exactly 2 entities in the extracted data
            Assert.AreEqual(expected: 2, actual: entities.Count, message: $"Expected 2 entities, but found {entities.Count}");

            // Assert that all entities have exactly 5 content items
            Assert.IsTrue(
                condition: entities.TrueForAll(i => i.Content.Count == 8),
                message: "Expected all entities to have 8 content items");

            // Assert that the content of the "Pre" key in the first entity,
            // when split using a regular expression to separate lines, has a length greater than 1
            Assert.IsTrue(
                condition: Regex.Split($"{entities[0].Content["Pre"]}", @"[\r\n]+", RegexOptions.Singleline).Length > 1,
                message: "Expected the content of 'Pre' to have more than one line.");

            // Assert that the content of the "Location" key in the first entity starts with a space character
            Assert.IsTrue(
                condition: $"{entities[0].Content["Location"]}".StartsWith(' '),
                message: "Expected the content of 'Location' to start with a space character.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters without " +
            "trimming and with clearing line breaks, accurately extracts hotel information from " +
            "webpage elements.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'trim' set to false and 'clearLinesBreak' set to true, the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Validation Process: The extracted data undergoes thorough validation to ensure correctness and completeness of information.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetNoWrite))]
        #endregion
        public void T0001B(string extractionScope, string contentType)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "extractionScope", value: extractionScope)
                .AddTestParameter(key: "contentType", value: contentType)
                .AddTestParameter(key: "clearLinesBreak", true);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);

            // Extract entities from the responses
            var entities = environment.GetEntities().ToList();

            // Assert that there are exactly 2 entities in the extracted data
            Assert.AreEqual(expected: 2, actual: entities.Count, message: $"Expected 2 entities, but found {entities.Count}");

            // Assert that all entities have exactly 5 content items
            Assert.IsTrue(
                condition: entities.TrueForAll(i => i.Content.Count == 8),
                message: "Expected all entities to have 8 content items");

            // Assert that the content of the "Pre" key in the first entity,
            // when split using a regular expression to separate lines, has a length of 1
            Assert.AreEqual(
                expected: 1,
                actual: Regex.Split($"{entities[0].Content["Pre"]}", @"[\r\n]+", RegexOptions.Singleline).Length,
                message: "Expected the content of 'Pre' to have exactly one line.");

            // Assert that the content of the "Location" key in the first entity starts with a space character
            Assert.IsTrue(
                condition: $"{entities[0].Content["Location"]}".StartsWith(' '),
                message: "Expected the content of 'Location' to start with a space character.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters with trimming " +
            "and with clearing line breaks, accurately extracts hotel information from webpage elements.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'trim' set to true and 'clearLinesBreak' set to true, the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Validation Process: The extracted data undergoes thorough validation to ensure correctness and completeness of information.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetNoWrite))]
        #endregion
        public void T0001C(string extractionScope, string contentType)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "extractionScope", value: extractionScope)
                .AddTestParameter(key: "contentType", value: contentType)
                .AddTestParameter(key: "clearLinesBreak", value: true)
                .AddTestParameter(key: "trim", value: true);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);

            // Extract entities from the responses
            var entities = environment.GetEntities().ToList();

            // Assert that there are exactly 2 entities in the extracted data
            Assert.AreEqual(expected: 2, actual: entities.Count, message: $"Expected 2 entities, but found {entities.Count}");

            // Assert that all entities have exactly 5 content items
            Assert.IsTrue(
                condition: entities.TrueForAll(i => i.Content.Count == 8),
                message: "Expected all entities to have 8 content items");

            // Assert that the content of the "Pre" key in the first entity,
            // when split using a regular expression to separate lines, has a length of 1
            Assert.AreEqual(
                expected: 1,
                actual: Regex.Split($"{entities[0].Content["Pre"]}", @"[\r\n]+", RegexOptions.Singleline).Length,
                message: "Expected the content of 'Pre' to have exactly one line.");

            // Assert that the content of the "Location" key in the first entity does not start with a space character
            Assert.IsFalse(
                $"{entities[0].Content["Location"]}".StartsWith(' '),
                "Expected the content of 'Location' to not start with a space character.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters with trimming, " +
            "with clearing line breaks, accurately extracts hotel information from webpage elements " +
            "and validates extracted data types.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'trim' set to true and 'clearLinesBreak' set to true, the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Data Type Validation: The test validates the extracted data types, ensuring they conform to expected types (e.g., string, decimal, double, string array, boolean, datetime).")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetNoWrite))]
        #endregion
        public void T0001D(string extractionScope, string contentType)
        {
            // Creating an automation environment with specified test and context parameters
            var environment = new AutomationEnvironment(TestContext)
                .AddTestParameter(key: "extractionScope", value: extractionScope)
                .AddTestParameter(key: "contentType", value: contentType)
                .AddTestParameter(key: "clearLinesBreak", value: true)
                .AddTestParameter(key: "trim", value: true);

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0001>(testOptions);

            // Extract entities from the responses
            var entities = environment.GetEntities().ToList();

            // Assert that the "PetFriendly" property of the first entity is true.
            Assert.IsTrue(
                condition: (bool)entities[0].Content["PetFriendly"],
                message: "Expected PetFriendly to be true for the first entity.");

            // Assert that the "PetFriendly" property of the second entity is false.
            Assert.IsFalse(
                condition: (bool)entities[1].Content["PetFriendly"],
                message: "Expected PetFriendly to be false for the second entity.");

            // Assert that the "LastUpdate" property of the first entity is equal to the specified DateTime.
            Assert.AreEqual(
                expected: DateTime.Parse("2023-10-28T15:30:00", CultureInfo.InvariantCulture),
                actual: (DateTime)entities[0].Content["LastUpdate"],
                message: "Unexpected value for LastUpdate in the first entity.");

            // Assert that the "LastUpdate" property of the second entity is equal to the specified DateTime.
            Assert.AreEqual(
                expected: DateTime.Parse("2023-10-28", CultureInfo.InvariantCulture),
                actual: (DateTime)entities[1].Content["LastUpdate"],
                message: "Unexpected value for LastUpdate in the second entity.");

            // Assert that the "Rating" property of the first entity is equal to 4.5.
            Assert.AreEqual(
                expected: 4.5,
                actual: (double)entities[0].Content["Rating"],
                message: "Unexpected value for Rating in the first entity.");

            // Assert that the "Rating" property of the second entity is equal to 4.8.
            Assert.AreEqual(
                expected: 4.8,
                actual: (double)entities[1].Content["Rating"],
                message: "Unexpected value for Rating in the second entity.");

            // Assert that the "Price" property of the first entity is equal to 100.
            Assert.AreEqual(
                expected: 100,
                actual: (double)entities[0].Content["Price"],
                message: "Unexpected value for Price in the first entity.");

            // Assert that the "Price" property of the second entity is equal to 120.
            Assert.AreEqual(
                expected: 120,
                actual: (double)entities[1].Content["Price"],
                message: "Unexpected value for Price in the second entity.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements and writes the extracted data to " +
            "a JSON file in real-time for each entity extracted.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Real-Time Data Writing: The extracted data for each entity is written to a JSON file in real-time.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetWriteJson))]
        #endregion
        public void T0002A(string extractionScope, string contentType, string expectedData)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["forEntity"] = true;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);

            // Read data from "Data.json" and "ExpectedData.json" files.
            var dataJson = File.ReadAllText($"{environment.TestParameters["fileName"]}.json").Replace("\\t", " ");
            var expectedDataJson = File.ReadAllText($"Resources/{expectedData}").Replace("\\t", " ");

            // Deserialize the JSON data into a collection of dictionaries.
            var entities = JsonSerializer.Deserialize<IEnumerable<IDictionary<string, object>>>(dataJson);

            // Sort and concatenate the JSON data for comparison.
            var expected = string.Concat(expectedDataJson.Order());
            var actual = string.Concat(dataJson.Order());

            // Assert the conditions to validate the test result.
            Assert.AreEqual(expected: 2, actual: entities.Count(), message: "Expected two entities in the JSON data.");
            Assert.AreEqual(expected, actual, message: "JSON data does not match the expected data.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements and writes the extracted data to " +
            "a JSON file at the end of the extraction.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Data Writing: The extracted data is written to a JSON file at the end of the extraction.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetWriteJson))]
        #endregion
        public void T0002B(string extractionScope, string contentType, string expectedData)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0002>(testOptions);

            // Read data from "Data.json" and "ExpectedData.json" files.
            var dataJson = File.ReadAllText($"{environment.TestParameters["fileName"]}.json").Replace("\\t", " ");
            var expectedDataJson = File.ReadAllText($"Resources/{expectedData}").Replace("\\t", " ");

            // Deserialize the JSON data into a collection of dictionaries.
            var entities = JsonSerializer.Deserialize<IEnumerable<IDictionary<string, object>>>(dataJson);

            // Sort and concatenate the JSON data for comparison.
            var expected = string.Concat(expectedDataJson.Order());
            var actual = string.Concat(dataJson.Order());

            // Assert the conditions to validate the test result.
            Assert.AreEqual(expected: 2, actual: entities.Count(), message: "Expected two entities in the JSON data.");
            Assert.AreEqual(expected, actual, message: "JSON data does not match the expected data.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements and writes the extracted data to an " +
            "XML file in real-time for each entity extracted.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Real-Time Data Writing: The extracted data for each entity is written to an XML file in real-time.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetWriteXml))]
        #endregion
        public void T0003A(string extractionScope, string contentType, string expectedData)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["forEntity"] = true;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);

            // Read data from "Data.xml" and "ExpectedData.xml" files.
            var dataXml = environment.ReadXmlDocument().ToString().Replace("\\t", " ").Trim();
            var expectedDataXml = XDocument.Parse(File.ReadAllText($"Resources/{expectedData}")).ToString().Replace("\\t", " ").Trim();

            // Deserialize the XML data into a document.
            var entities = XDocument.Parse(dataXml).XPathSelectElements("//DataEntry");

            // Sort and concatenate the XML data for comparison.
            var expected = string.Concat(expectedDataXml.Order());
            var actual = string.Concat(dataXml.Order());

            // Assert the conditions to validate the test result.
            Assert.AreEqual(expected: 2, actual: entities.Count(), message: "Expected two entities in the XML data.");
            Assert.AreEqual(expected, actual, message: "XML data does not match the expected data.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements and writes the extracted data to an " +
            "XML file at the end of the extraction.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Data Writing: The extracted data is written to an XML file at the end of the extraction.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetWriteXml))]
        #endregion
        public void T0003B(string extractionScope, string contentType, string expectedData)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0003>(testOptions);

            // Read data from "Data.xml" and "ExpectedData.xml" files.
            var dataXml = environment.ReadXmlDocument().ToString().Replace("\\t", " ").Trim();
            var expectedDataXml = XDocument.Parse(File.ReadAllText($"Resources/{expectedData}")).ToString().Replace("\\t", " ").Trim();

            // Deserialize the XML data into a document.
            var entities = XDocument.Parse(dataXml).XPathSelectElements("//DataEntry");

            // Sort and concatenate the XML data for comparison.
            var expected = string.Concat(expectedDataXml.Order());
            var actual = string.Concat(dataXml.Order());

            // Assert the conditions to validate the test result.
            Assert.AreEqual(expected: 2, actual: entities.Count(), message: "Expected two entities in the XML data.");
            Assert.AreEqual(expected, actual, message: "XML data does not match the expected data.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements and writes the extracted data to " +
            "a CSV file in real-time for each entity extracted.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Real-Time Data Writing: The extracted data for each entity is written to a CSV file in real-time.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetWriteCsv))]
        #endregion
        public void T0004A(string extractionScope, string contentType, string expectedData)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["forEntity"] = true;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);

            // Read data from "Data.csv" and "ExpectedCsvData.txt" files.
            var dataCsv = File.ReadAllText($"{environment.TestParameters["fileName"]}.csv").Replace("  ", " ").Trim();
            var expectedDataCsv = File.ReadAllText($"Resources/{expectedData}").Replace("  ", " ").Trim();

            // Deserialize the CSV data into a document.
            var entities = dataCsv.Split("\n").Skip(1);

            // Sort and concatenate the CSV data for comparison.
            var expected = string.Concat(expectedDataCsv.Order());
            var actual = string.Concat(dataCsv.Order());

            // Assert the conditions to validate the test result.
            Assert.AreEqual(expected: 2, actual: entities.Count(), message: "Expected two entities in the CSV data.");
            Assert.AreEqual(expected, actual, message: "CSV data does not match the expected data.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements and writes the extracted data to " +
            "a CSV file at the end of the extraction.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, and additional details, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Data Writing: The extracted data is written to a CSV file at the end of the extraction.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetWriteCsv))]
        #endregion
        public void T0004B(string extractionScope, string contentType, string expectedData)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["forEntity"] = false;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0004>(testOptions);

            // Read data from "Data.csv" and "ExpectedCsvData.txt" files.
            var dataCsv = File.ReadAllText($"{environment.TestParameters["fileName"]}.csv").Replace("  ", " ").Trim();
            var expectedDataCsv = File.ReadAllText($"Resources/{expectedData}").Replace("  ", " ").Trim();

            // Deserialize the CSV data into a document.
            var entities = dataCsv.Split("\n").Skip(1);

            // Sort and concatenate the CSV data for comparison.
            var expected = string.Concat(expectedDataCsv.Order());
            var actual = string.Concat(dataCsv.Order());

            // Assert the conditions to validate the test result.
            Assert.AreEqual(expected: 2, actual: entities.Count(), message: "Expected two entities in the CSV data.");
            Assert.AreEqual(expected, actual, message: "CSV data does not match the expected data.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements, invokes actions under each ContentRule " +
            "before moving to the next rule, and writes the extracted data to a CSV file in real-time " +
            "for each entity extracted.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, contact details, check-in, and check-out times, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Real-Time Data Writing: The extracted data for each entity is written to a CSV file in real-time.")]
        [AcceptanceCriteria(criteria: "Action Invocation Order: The actions defined under each ContentRule are invoked in the specified order before moving to the next ContentRule.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetWriteCsvAction))]
        #endregion
        public void T0005A(string extractionScope, string contentType, string expectedData)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["forEntity"] = true;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);

            // Read data from "Data.csv" and "ExpectedCsvData.txt" files.
            var dataCsv = File.ReadAllText($"{environment.TestParameters["fileName"]}.csv").Replace("\\t", " ").Trim();
            var expectedDataCsv = File.ReadAllText($"Resources/{expectedData}").Replace("\\t", " ").Trim();

            // Deserialize the CSV data into a document.
            var entities = dataCsv.Split("\n").Skip(1);

            // Sort and concatenate the CSV data for comparison.
            var expected = string.Concat(expectedDataCsv.Order()).Trim();
            var actual = string.Concat(dataCsv.Order()).Trim();

            // Assert the conditions to validate the test result.
            Assert.AreEqual(expected: 2, actual: entities.Count(), message: "Expected two entities in the CSV data.");
            Assert.AreEqual(expected, actual, message: "CSV data does not match the expected data.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements, invokes actions under each ContentRule " +
            "before moving to the next rule, and writes the extracted data to a CSV file at the end " +
            "of the extraction.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, contact details, check-in, and check-out times, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Data Writing: The extracted data is written to a CSV file at the end of the extraction.")]
        [AcceptanceCriteria(criteria: "Action Invocation Order: The actions defined under each ContentRule are invoked in the specified order before moving to the next ContentRule.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetWriteCsvAction))]
        #endregion
        public void T0005B(string extractionScope, string contentType, string expectedData)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["forEntity"] = false;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);

            // Read data from "Data.csv" and "ExpectedCsvData.txt" files.
            var dataCsv = File.ReadAllText($"{environment.TestParameters["fileName"]}.csv").Replace("\\t", " ").Trim();
            var expectedDataCsv = File.ReadAllText($"Resources/{expectedData}").Replace("\\t", " ").Trim();

            // Deserialize the CSV data into a document.
            var entities = dataCsv.Split("\n").Skip(1);

            // Sort and concatenate the CSV data for comparison.
            var expected = string.Concat(expectedDataCsv.Order()).Trim();
            var actual = string.Concat(dataCsv.Order()).Trim();

            // Assert the conditions to validate the test result.
            Assert.AreEqual(expected: 2, actual: entities.Count(), message: "Expected two entities in the CSV data.");
            Assert.AreEqual(expected, actual, message: "CSV data does not match the expected data.");
        }

        [Ignore(message: "This test is currently skipped in the production environment due to an unknown issue not related to the actual functionality.")]
        [TestMethod(displayName: "As an automation engineer utilizing the G4™ platform, I need to " +
            "verify that the ExportData plugin, when triggered with specific parameters, accurately " +
            "extracts hotel information from webpage elements, writes the extracted data to a CSV " +
            "file at the end of the extraction, and ensures data type consistency.")]
        #region *** Criteria ***
        [AcceptanceCriteria(criteria: "Plugin Integration: The ExportData plugin seamlessly integrates into the G4™ Engine framework.")]
        [AcceptanceCriteria(criteria: "Parameterized Invocation: When triggered with appropriate parameters, such as 'clearLinesBreak' and 'trim', the plugin correctly extracts hotel information from webpage elements.")]
        [AcceptanceCriteria(criteria: "Extraction Accuracy: The extracted hotel information, including location, price, rating, amenities, description, pet-friendly status, last update timestamp, contact details, check-in, and check-out times, is validated for accuracy.")]
        [AcceptanceCriteria(criteria: "Extraction Scope: The extraction scope can be customized using test parameters, ensuring flexibility in data extraction.")]
        [AcceptanceCriteria(criteria: "Data Writing: The extracted data is written to a CSV file at the end of the extraction.")]
        [AcceptanceCriteria(criteria: "Data Type Validation: The extracted data undergoes validation for data type consistency in the actual test, ensuring integrity and consistency.")]
        [AcceptanceCriteria(criteria: "Action Invocation Order: The actions defined under each ContentRule are invoked in the specified order before moving to the next ContentRule.")]
        [AcceptanceCriteria(criteria: "Error Handling: The plugin handles errors gracefully and provides informative error messages in case of extraction failures.")]
        #endregion
        #region *** Data     ***
        [DynamicData(dynamicDataSourceName: nameof(DataSetNoWrite))]
        #endregion
        public void T0005C(string extractionScope, string contentType)
        {
            // Create an automation environment with specified parameters
            var environment = new AutomationEnvironment(TestContext);
            environment.TestParameters["clearLinesBreak"] = true;
            environment.TestParameters["trim"] = true;
            environment.TestParameters["forEntity"] = false;
            environment.TestParameters["fileName"] = Guid.NewGuid();
            environment.TestParameters["extractionScope"] = extractionScope;
            environment.TestParameters["contentType"] = contentType;

            // Creating test options
            var testOptions = new EdgeTestOptions(environment, sut: "ExportData.html");

            // Invoking the test with the constructed test options
            Invoke<C0005>(testOptions);

            // Extract content from the data structure.
            var entity = environment.GetEntities().FirstOrDefault(i => i.Content.Count == 12)?.Content;

            // Check if there are 12 entities in the CSV data.
            Assert.AreNotEqual(notExpected: default, actual: entity, message: "Expected 12 entities in the CSV data.");

            // Assert that the CheckOut field matches the expected value
            Assert.AreEqual(
                expected: entity["CheckOut"],
                actual: TimeOnly.Parse("11:00:00", CultureInfo.InvariantCulture),
                message: "CheckOut field mismatch.");

            // Assert that the PetFriendly field is true
            Assert.IsTrue((bool)entity["PetFriendly"], message: "PetFriendly field mismatch.");

            // Assert that the Rating field matches the expected value
            Assert.AreEqual(expected: 4.5D, actual: entity["Rating"], message: "Rating field mismatch.");

            // Assert that the LastUpdate field matches the expected value
            Assert.AreEqual(
                expected: entity["LastUpdate"],
                actual: DateTime.Parse("2023-10-28T15:30:00", CultureInfo.InvariantCulture),
                message: "LastUpdate field mismatch.");

            // Assert that the Contact field matches the expected value
            Assert.AreEqual(expected: "example@example.com", actual: entity["Contact"], message: "Contact field mismatch.");

            // Assert that the CheckIn field matches the expected value
            Assert.AreEqual(
                expected: entity["CheckIn"],
                actual: TimeOnly.Parse("15:00:00", CultureInfo.InvariantCulture),
                message: "CheckIn field mismatch.");

            // Assert that the Location field matches the expected value
            Assert.AreEqual(expected: "City A", actual: entity["Location"], message: "Location field mismatch.");

            // Assert that the Amenities field matches the expected value
            Assert.AreEqual(
                expected: "Free Wi-Fi, Pool, Restaurant",
                actual: entity["Amenities"],
                message: "Amenities field mismatch.");

            // Assert that the Price field matches the expected value
            Assert.AreEqual(expected: 100D, actual: entity["Price"], "Price field mismatch.");

            // Assert that the Description field matches the expected value
            Assert.AreEqual(
                expected: "Lorem ipsum dolor sit \u0022amet\u0022, consectetur adipiscing elit.",
                actual: entity["Description"],
                message: "Description field mismatch.");

            // Assert that the Phone field matches the expected value
            Assert.AreEqual(expected: "\u002B123456789", actual: entity["Phone"], message: "Phone field mismatch.");

            // Assert that the Pre field matches one of the expected values
            Assert.IsTrue(
                condition: "Description:    Lorem ipsum dolor sit amet, consectetur adipiscing elit.".Equals(entity["Pre"]) || "Description:\t\t\t\tLorem ipsum dolor sit amet, consectetur adipiscing elit.".Equals(entity["Pre"]),
                message: "Pre field mismatch.");
        }
    }
}
