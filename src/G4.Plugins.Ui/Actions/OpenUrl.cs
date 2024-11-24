using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;

using System.Text.RegularExpressions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(OpenUrl)}.json")]
    public class OpenUrl(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the web element based on the rule and element in the plugin data.
            var element = this.GetElement(pluginData.Rule, pluginData.Element);

            // Get the URL to navigate to.
            var url = GetUrl(pluginData.Rule, element);

            // Navigate to the given URL.
            WebDriver.OpenUrl(url);

            // Return new plugin response.
            return this.NewPluginResponse();
        }

        // Gets the URL based on the provided action rule and web element.
        private static string GetUrl(G4RuleModelBase rule, IWebElement element)
        {
            // If the element is not found, return the URL from the rule argument.
            if (element == default)
            {
                return rule.Argument;
            }

            // If OnAttribute is not specified, use the element's text content as the URL.
            // Otherwise, get the URL from the specified attribute.
            var url = string.IsNullOrEmpty(rule.OnAttribute)
                ? element.Text
                : element.GetAttribute(rule.OnAttribute);

            // Use regular expression to match and extract the desired part of the URL.
            var match = Regex.Match(
                input: url,
                pattern: rule.RegularExpression);

            // Return the desired part of the URL.
            return match.Value;
        }
    }
}
