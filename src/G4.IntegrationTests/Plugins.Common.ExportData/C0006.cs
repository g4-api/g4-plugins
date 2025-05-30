using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.ExportData
{
    internal class C0006(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<G4RuleModelBase> OnActions(AutomationEnvironment environment)
        {
            // Return a collection of action rule models
            return
            [
                // No-action action: Export Data Container
                new ActionRuleModel()
                {
                    PluginName = "NoAction",
                    Argument = "Export Data Container",
                    Rules = OnExtractions(environment)
                }
            ];
        }

        protected override IEnumerable<ExtractionRuleModel> OnExtractions(AutomationEnvironment environment)
        {
            // Get the file name from the test parameters
            var fileName = environment.TestParameters["fileName"];

            // Check if trimming is requested in the test parameters.
            var trim = environment.TestParameters.Get(key: "trim", defaultValue: false);

            // Check if clearing line breaks is requested in the test parameters.
            var clearLinesBreak = environment.TestParameters.Get(key: "clearLinesBreak", defaultValue: false);

            // Check if the test parameters contain a flag to export for entity
            var forEntity = environment.TestParameters.Get(key: "forEntity", defaultValue: false);

            // Check if the extraction scope is specified in the test parameters.
            // If specified, use the provided extraction scope.
            // If not specified, use the default "Elements" scope.
            var extractionScope = environment.TestParameters.Get(key: "extractionScope", defaultValue: "Elements");

            // Check if the content type is specified in the test parameters.
            var contentType = environment.TestParameters.Get(key: "contentType", defaultValue: "WebElementContent");

            // Create a G4DataProviderModel for collecting SQLight data.
            var dataCollector = new G4DataProviderModel
            {
                Type = "SqLiteDataCollector", // Specify the type of data collector.
                ForEntity = forEntity,         // Indicate that it's for an entity.
                Source = $"{fileName}.db",     // Specify the data source (SQLight file).
                Repository = "TestData"        // The table name in the database to store the extracted data.
            };

            // Define an extraction rule for hotel information
            var extractionRule = new ExtractionRuleModel
            {
                Argument = "{{$ --Scope:" + extractionScope + "}}", // Argument to specify the extraction scope
                OnElement = "//div[@class='hotel']",                // XPath expression to find hotel elements
                DataCollector = dataCollector,                      // Data collector for saving the extracted data
                Rules =
                [
                    // Content rule for extracting 'Location' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Location:')]",                   // XPath for 'Location' element
                        Key = "Location",                                                 // Key to identify this extraction
                        PluginName = contentType,                                         // Plugin to use for extraction
                        RegularExpression = @"(?<=\w+:).*",                               // Regular expression to extract text
                        Transformers = NewTransformers("Location", trim, clearLinesBreak) // Transformers to apply to the extracted text
                    },
                    // Content rule for extracting 'Price' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Price:')]",
                        Key = "Price",
                        PluginName = contentType,
                        RegularExpression = @"-?\d*\.?\d+",
                        DataType = "number",
                        Transformers = NewTransformers("Price", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Rating' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Rating:')]",
                        Key = "Rating",
                        PluginName = contentType,
                        RegularExpression = @"-?\d*\.?\d+",
                        DataType = "number",
                        Transformers = NewTransformers("Rating", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Amenities' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Amenities:')]",
                        Key = "Amenities",
                        PluginName = contentType,
                        RegularExpression = @"(?<=\w+:\s+).*",
                        Transformers = NewTransformers("Amenities", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Description' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Description:')]",
                        Key = "Description",
                        PluginName = contentType,
                        RegularExpression = @"(?<=\w+:\s+).*",
                        Transformers = NewTransformers("Description", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Pet Friendly' information
                    //new ContentRuleModel
                    //{
                    //    OnElement = ".",
                    //    OnAttribute = "data-pet-friendly",
                    //    Key = "PetFriendly",
                    //    PluginName = contentType,
                    //    DataType = "bool",
                    //    Transformers = NewTransformers("PetFriendly", trim, clearLinesBreak)
                    //},
                    // Content rule for extracting 'Last Update' information
                    new ContentRuleModel
                    {
                        OnElement = ".",
                        OnAttribute = "data-last-updated",
                        Key = "LastUpdate",
                        PluginName = contentType,
                        DataType = "datetime",
                        Transformers = NewTransformers("LastUpdate", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Pre' information
                    new ContentRuleModel
                    {
                        OnElement = ".//pre",
                        Key = "Pre",
                        PluginName = contentType,
                        Transformers = NewTransformers("Pre", trim, clearLinesBreak)
                    }
                ]
            };

            // Return the extraction rule as an array
            return [extractionRule];
        }

        // Creates an array of TransformerRuleModel instances based on the specified parameters.
        private static TransformerRuleModel[] NewTransformers(string field, bool trim, bool clearLinesBreak)
        {
            // Initialize a list to hold the transformer rule models.
            var transformers = new List<TransformerRuleModel>();

            // If trimming is requested, add a Trim transformer for the specified field.
            if (trim)
            {
                transformers.Add(new TransformerRuleModel
                {
                    PluginName = "Trim",
                    OnElement = field
                });
            }

            // If clearing line breaks is requested, add a ClearLines transformer for the specified field.
            if (clearLinesBreak)
            {
                transformers.Add(new TransformerRuleModel
                {
                    PluginName = "ClearLines",
                    OnElement = field
                });
            }

            // Convert the list of transformers to an array and return it.
            return [.. transformers];
        }
    }
}
