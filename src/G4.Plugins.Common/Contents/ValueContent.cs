using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Contents
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Contents.Manifests.{nameof(ValueContent)}.json")]
    public class ValueContent(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Verify that the rule is a ContentRuleModel; throw an exception if not supported.
            if (pluginData.Rule is not ContentRuleModel contentRule)
            {
                throw new NotSupportedException("Only ContentRuleModel is supported in ValueContent plugin.");
            }

            // Take the value from the rule's argument, which the engine resolves before the plugin runs.
            // A missing argument is stored as an empty string so every entity keeps the same fields.
            var argument = contentRule.Argument ?? string.Empty;

            // Apply the regular expression defined in the content rule to extract the desired value.
            var value = Regex.Match(
                input: argument,
                pattern: contentRule.RegularExpression,
                options: RegexOptions.None,
                matchTimeout: TimeSpan.FromSeconds(30)).Value;

            // Convert the extracted value to the specified data type and prepare it as a key-value pair.
            var (key, data) = (contentRule.Key, value.ConvertToPrimitive(contentRule.DataType));

            // Create and return a PluginResponseModel containing the extracted data.
            return this.NewContentResponse(key, data);
        }
    }
}
