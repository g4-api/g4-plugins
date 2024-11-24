using G4.Extensions;
using G4.IntegrationTests.Framework;
using G4.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace G4.IntegrationTests.Plugins.Common.ExportData
{
    internal class C0005(TestContext context) : TestCaseBase(context)
    {
        protected override IEnumerable<ActionRuleModel> OnActions(AutomationEnvironment environment)
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
                },
                // Assertion action: Asserts that the text of the element retrieved
                // from a dynamic parameter equals "Foo Bar"
                new ActionRuleModel()
                {
                    PluginName = "Assert",
                    Argument = "{{$ --Condition:Text --Operator:Eq --Expected:Foo Bar}}",
                    OnElement = "{{$Get-Parameter --Name:TestParameter}}"
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

            // Create a G4DataProviderModel for collecting CSV data.
            var dataCollector = new G4DataProviderModel
            {
                Type = "CsvDataCollector",  // Specify the type of data collector.
                ForEntity = forEntity,      // Indicate that it's for an entity.
                Source = $"{fileName}.csv"  // Specify the data source (CSV file).
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
                        RegularExpression = @"(?<=\w+:).*",                               // Regular expression to extract text
                        PluginName = contentType,                                         // Plugin to extract HTML content
                        Transformers = NewTransformers("Location", trim, clearLinesBreak) // Transformers to clean the extracted text
                    },
                    // Content rule for extracting 'Price' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Price:')]",
                        Key = "Price",
                        RegularExpression = @"-?\d*\.?\d+",
                        DataType = "number",
                        PluginName = contentType,
                        Transformers = NewTransformers("Price", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Rating' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Rating:')]",
                        Key = "Rating",
                        RegularExpression = @"-?\d*\.?\d+",
                        DataType = "number",
                        PluginName = contentType,
                        Transformers = NewTransformers("Rating", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Amenities' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Amenities:')]",
                        Key = "Amenities",
                        RegularExpression = @"(?<=\w+:\s+).*",
                        PluginName = contentType,
                        Transformers = NewTransformers("Amenities", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Description' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Description:')]",
                        Key = "Description",
                        RegularExpression = @"(?<=\w+:\s+).*",
                        PluginName = contentType,
                        Transformers = NewTransformers("Description", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Pet Friendly' information
                    new ContentRuleModel
                    {
                        OnElement = ".",
                        OnAttribute = "data-pet-friendly",
                        Key = "PetFriendly",
                        DataType = "bool",
                        PluginName = contentType,
                        Transformers = NewTransformers("PetFriendly", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Last Update' information
                    new ContentRuleModel
                    {
                        OnElement = ".",
                        OnAttribute = "data-last-updated",
                        Key = "LastUpdate",
                        DataType = "datetime",
                        PluginName = contentType,
                        Transformers = NewTransformers("LastUpdate", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Pre' information
                    new ContentRuleModel
                    {
                        OnElement = ".//pre",
                        Key = "Pre",
                        UpdateElements = true,
                        PluginName = contentType,
                        Transformers = NewTransformers("Pre", trim, clearLinesBreak),
                        Rules =
                        [
                            new ActionRuleModel
                            {
                                PluginName = "RegisterParameter",
                                Argument = "{{$ --Name:TestParameter --Value:Foo Bar}}",
                                Rules =
                                [
                                    new ActionRuleModel
                                    {
                                        PluginName = "InvokeClick",
                                        OnElement = ".//button[.='Show More']"
                                    }
                                ]
                            }
                        ]
                    },
                    // Content rule for extracting 'Contact' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Contact:')]",
                        Key = "Contact",
                        RegularExpression = @"(?<=\w+:\s+).*",
                        PluginName = contentType,
                        Transformers = NewTransformers("Contact", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Phone' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Phone:')]",
                        Key = "Phone",
                        RegularExpression = @"(?<=\w+:\s+).*",
                        PluginName = contentType,
                        Transformers = NewTransformers("Phone", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Check-in' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Check-in:')]",
                        Key = "CheckIn",
                        RegularExpression = @"(?<=\w+:\s+).*",
                        DataType = "time",
                        PluginName = contentType,
                        Transformers = NewTransformers("CheckIn", trim, clearLinesBreak)
                    },
                    // Content rule for extracting 'Check-out' information
                    new ContentRuleModel
                    {
                        OnElement = ".//p[starts-with(.,'Check-out:')]",
                        Key = "CheckOut",
                        RegularExpression = @"(?<=\w+:\s+).*",
                        DataType = "time",
                        PluginName = contentType,
                        Transformers = NewTransformers("CheckOut", trim, clearLinesBreak)
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
