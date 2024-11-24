using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Text.RegularExpressions;

namespace G4.Plugins.Ui.Contents
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Contents.Manifests.{nameof(WebElementContent)}.json")]
    public class WebElementContent(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Verify that the rule is a ContentRuleModel; throw an exception if not supported.
            if (pluginData.Rule is not ContentRuleModel contentRule)
            {
                throw new NotSupportedException("Only ContentRuleModel is supported in WebElementContent plugin.");
            }

            // Retrieve the web element based on the content rule's "OnElement" XPath or CSS selector.
            var onElement = this.GetElement(contentRule, pluginData.Element);

            // Extract the value from the specified attribute or the inner text of the element.
            var value = !string.IsNullOrEmpty(contentRule.OnAttribute)
                ? onElement.GetAttribute(contentRule.OnAttribute)
                : onElement.Text;

            // Apply the regular expression defined in the content rule to extract the desired value.
            value = Regex.Match(value, contentRule.RegularExpression).Value;

            // Convert the extracted value to the specified data type and prepare it as a key-value pair.
            var (key, data) = (contentRule.Key, value.ConvertToPrimitive(contentRule.DataType));

            // Create and return a PluginResponseModel containing the extracted data.
            return this.NewContentResponse(key, data);
        }
    }
}
