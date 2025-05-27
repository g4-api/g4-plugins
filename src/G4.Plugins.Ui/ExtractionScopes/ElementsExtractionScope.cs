using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.Ui.ExtractionScopes
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.ExtractionScopes.Manifests.{nameof(ElementsExtractionScope)}.json")]
    public class ElementsExtractionScope(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Cast the rule to an ExtractionRuleModel.
            var extraction = pluginData.Rule;

            // Update the root elements and associated elements based on the provided PluginDataModel.
            var rootElements = this.GetElements(extraction, pluginData.Element).ToArray();

            // Retrieve session information.
            var session = WebDriver.GetSession().OpaqueKey;

            // Initialize an extraction model with default session information.
            pluginData.Extraction = new G4ExtractionModel().SetDefault(session, pluginData.Rule.Reference);
            pluginData.Extraction.Key = pluginData.Parameters.Get(key: "Key", defaultValue: string.Empty);

            // Create a list to store G4EntityModel instances for extraction.
            var entities = new List<G4EntityModel>();

            // Process and extract data for each element.
            for (int i = 0; i < rootElements.Length; i++)
            {
                // Invoke the scope iteration to process the element and extract data.
                var entity = InvokeScopeIteration(
                    pluginData,
                    element: rootElements[i],
                    iteration: i);

                // If no content was extracted, log a warning and skip to the next element.
                if (entity == null || entity.Content?.Any() != true)
                {
                    Logger.LogWarning("No content was extracted for the current element. Skipping to the next element.");
                    continue;
                }

                // Add the extracted entity to the list of entities.
                entities.Add(entity);
            }

            // If entities were extracted, add them to the extraction model and write content data as needed.
            if (entities.Count > 0)
            {
                // Set the list of extracted entities in the pluginData's extraction model.
                pluginData.Extraction.Entities = entities;

                // Add the configured extraction model to the list of extractions.
                Extractions.Add(pluginData.Extraction);

                // If data collection is not set for individual entities, write content data for all entities.
                if (extraction.DataCollector?.ForEntity == false)
                {
                    WriteContent(
                        plugin: this,
                        pluginData,
                        dataCollector: extraction.DataCollector);
                }
            }

            // Warning: Skipping this step will cause the content rules to be executed again
            // Set the context key 'InvokeRules' to false, preventing rule invocation.
            pluginData.Rule.Context[RuleProperties.InvokeRules] = false;

            // Return a PluginResponseModel with the extraction results and other parameters.
            return new PluginResponseModel
            {
                ApplicationParameters = G4Environment.ApplicationParameters,
                SessionParameters = Invoker.Context.SessionParameters,
                Exceptions = Exceptions,
                Extractions = Extractions,
                Entity = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            };
        }

        // Invokes an iteration within the specified scope based on the plugin data and index.
        private G4EntityModel InvokeScopeIteration(PluginDataModel pluginData, IWebElement element, int iteration)
        {
            // Initializes a new rule model based on the provided plugin data and index.
            static G4RuleModelBase Initialize(PluginDataModel pluginData, int iteration)
            {
                // Create a copy of the rule from plugin data.
                var iterationRule = pluginData.Rule.Copy();

                // Set the iteration number in the copied rule.
                iterationRule.Iteration = iteration;

                // Clear any existing reference in the copied rule.
                iterationRule.Reference = null;

                // Create a new context for the copied rule, case-insensitive.
                iterationRule.Context = new ConcurrentDictionary<string, object>(StringComparer.OrdinalIgnoreCase);

                // Disable invoking rules for the copied rule.
                iterationRule.SetInvokeRules(false);

                // Create a new reference for the copied rule based on the original job reference.
                iterationRule.Reference = iterationRule.NewReference(pluginData.Rule.Reference.JobReference);

                // Set the parent reference of the copied rule to the original rule's reference.
                iterationRule.Reference.ParentReference = pluginData.Rule.Reference;

                // Return the fully initialized rule model.
                return iterationRule;
            }

            // Writes content data for the plugin based on the provided plugin data.
            static void Write(PluginBase plugin, PluginDataModel pluginData)
            {
                // If the rule's data collector is set for individual entities, write content data.
                if (pluginData.Rule.DataCollector?.ForEntity == true)
                {
                    WriteContent(plugin, pluginData, dataCollector: pluginData.Rule.DataCollector);
                }
            }

            // Declare and initialize the iteration rule using the Initialize method.
            G4RuleModelBase iterationRule = Initialize(pluginData, iteration);

            // Convert the initialized rule model to a data model for further processing.
            var iterationPluginData = iterationRule.ConvertToDataModel();

            // Set up a new entity model for the current element, based on the index.
            var entityModel = NewEntityModel(iterationPluginData, element, iteration);

            // Assign the entity model to the Extraction's entities collection.
            iterationPluginData.Extraction.Entities = [entityModel];

            // Write content data for this iteration, if required.
            Write(plugin: this, iterationPluginData);

            // Return the created entity model.
            return entityModel;
        }

        // Sets the entity model based on the specified plugin, extraction rule, and web element.
        private G4EntityModel NewEntityModel(PluginDataModel pluginData, IWebElement element, int iteration)
        {
            // Create a new instance of G4EntityModel.
            var entityModel = new G4EntityModel();

            // Concurrent dictionary to hold extracted content.
            var content = new ConcurrentDictionary<string, object>();

            // Iterate through content rules and extract content.
            foreach (var contentRule in pluginData.Rule.Rules)
            {
                // Set the iteration number for the content rule.
                contentRule.SetIteration(iteration);

                // Ensure content rule reference is initialized.
                contentRule.Reference = contentRule.NewReference(pluginData.Rule.Reference.JobReference);

                // Set the parent reference for the content rule.
                contentRule.Reference.ParentReference = pluginData.Rule.Reference;

                // Convert the content rule to ContentRuleModel for further processing.
                var onContentRule = (ContentRuleModel)contentRule;

                // Extract content based on the content rule.
                var (key, value) = ReadContent(this, onContentRule, element);

                // Add the extracted content to the concurrent dictionary.
                if (!string.IsNullOrEmpty(key))
                {
                    content[key] = value;
                }
            }

            // Set the extracted content in the entity model.
            entityModel.Content = !content.IsEmpty ? content : entityModel.Content;

            // Set the rule iteration for this entity model.
            entityModel.Iteration = iteration;

            // Return the entity model containing extracted content.
            return entityModel;
        }

        // Reads content based on the specified plugin, content rule, and web element.
        private static (string Key, object Value) ReadContent(
            PluginBase plugin, ContentRuleModel contentRule, IWebElement element)
        {
            // Set the WebElement and HtmlNode in the context based on the current iteration.
            contentRule.Context[RuleProperties.WebElement] = element;
            contentRule.Context[RuleProperties.HtmlNode] = default;

            // Prevent redundant invocation of rules.
            contentRule.SetInvokeRules(false);

            // Invoke the content rule and retrieve the first entity's data, if any.
            var entity = plugin.Invoker.Invoke(contentRule).FirstOrDefault()?.Entity;

            // If no entity is found or the entity is empty, return an empty key and null value.
            if (entity == null || entity.Count == 0)
            {
                return (Key: "", Value: null);
            }

            // If the content rule has child rules, process them as needed.
            if (contentRule.Rules?.Any() == true)
            {
                // Filter out content rules, leaving other rule types for further processing.
                var rules = contentRule.Rules.Where(i => i is not ContentRuleModel).ToArray();

                // Set context for each rule and update references based on the content rule's reference.
                foreach (var rule in rules)
                {
                    rule.Reference = rule.NewReference(contentRule.Reference.JobReference);
                    rule.Reference.ParentReference = contentRule.Reference;
                    rule.Context[RuleProperties.WebElement] = element;
                }

                // Invoke the filtered rules.
                plugin.Invoker.Invoke(rules);
            }

            // Return the first key-value pair from the entity.
            return (entity.Keys.First(), entity.Values.First());
        }

        // Method to write content using a plugin and data collector
        private static void WriteContent(
            PluginBase plugin,
            PluginDataModel pluginData,
            G4DataProviderModel dataCollector)
        {
            // Argument for the collector rule.
            var argument = "{{$ " +
                "--Source:" + dataCollector.Source + " " +
                "--Repository:" + dataCollector.Repository + " " +
                "--Filter:" + dataCollector.Filter + "}}";

            // Create a collector rule for the plugin.
            var collectorRule = new ActionRuleModel
            {
                PluginName = dataCollector.Type,
                Argument = argument
            };

            // Generate a unique reference for the collector rule based on the job reference
            collectorRule.Reference = collectorRule.NewReference(pluginData.Rule.Reference.JobReference);
            collectorRule.Reference.ParentReference = pluginData.Rule.Reference;

            // Set the extraction model in the context of the collector rule.
            collectorRule.Context["ExtractionModel"] = pluginData.Extraction;

            // Invoke the plugin's automation using the provided plugin data.
            plugin.Invoker.Invoke(collectorRule);
        }
    }
}
