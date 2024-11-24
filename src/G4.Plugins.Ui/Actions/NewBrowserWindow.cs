using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote;

using System.Text.RegularExpressions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(NewBrowserWindow)}.json")]
    public class NewBrowserWindow(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // The format string for the JavaScript window.open() script.
            const string ScriptFormat = "window.open('{0}', '{1}')";

            // Retrieve the action rule and web element from the provided data model.
            var action = pluginData.Rule;
            var element = pluginData.Element;

            // Get the arguments required for opening the new browser windows.
            var arguments = CliFactory.ConvertToDictionary(cli: action.Argument);
            var onElement = this.GetElement(rule: action, element);
            var url = GetUrl(action, onElement);
            var target = arguments.Get("Target", "_blank");

            // Convert the 'Amount' argument to an integer.
            _ = int.TryParse(arguments.Get("Amount", "1"), out int amount);

            // Generate the JavaScript script using the formatted URL and target.
            var script = string.Format(ScriptFormat, url, target);

            // Execute the script 'amount' times to open new browser windows.
            for (int i = 0; i < amount; i++)
            {
                WebDriver.InvokeScript(script);
            }

            // Return new plugin response.
            return this.NewPluginResponse();
        }

        // Gets the URL based on the provided action rule and web element.
        private static string GetUrl(G4RuleModelBase rule, IWebElement element)
        {
            // If the element is not provided, return "about:blank".
            if (element == default)
            {
                return "about:blank";
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
