using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;

using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SelectOption)}.json")]
    public class SelectOption(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get the select element
            var selectElement = this.GetElement(pluginData.Rule, pluginData.Element);
            var tagName = selectElement.TagName;

            // Check if the element is a select element
            if (!tagName.Equals("SELECT", StringComparison.OrdinalIgnoreCase))
            {
                // If not, throw an exception with a friendly error message
                var errorMessage = $"Cannot perform select option on element with tag name '{tagName}'. " +
                    "Select option can only be performed on '<select>' elements.";
                throw new InvalidOperationException(errorMessage);
            }

            // Find all option elements within the select element
            var options = selectElement.FindElements(By.Xpath("./option"));

            // Determine the action based on the OnAttribute rule
            switch (pluginData.Rule.OnAttribute.ToUpper())
            {
                case "INDEX":
                    {
                        // Select an option by index
                        SelectByIndex(plugin: this, pluginData, options, pluginData.Rule.Argument);
                        break;
                    }
                case "VALUE":
                    {
                        // Select an option by value
                        selectElement
                            .FindElement(By.Xpath($"./option[@value='{pluginData.Rule.Argument}']"))
                            .Click();
                        break;
                    }
                case "PARTIALTEXT":
                    {
                        // Select an option by partial text
                        selectElement
                            .FindElement(By.Xpath($"./option[contains(.,'{pluginData.Rule.Argument}')]"))
                            .Click();
                        break;
                    }
                default:
                    {
                        // Select an option by exact text
                        selectElement
                            .FindElement(By.Xpath($"./option[.='{pluginData.Rule.Argument}']"))
                            .Click();
                        break;
                    }
            }

            // Return a new plugin response
            return this.NewPluginResponse();
        }

        // Selects an option from a list of options by index.
        private static void SelectByIndex(
            PluginBase plugin, PluginDataModel pluginData, IEnumerable<IWebElement> options, string argument)
        {
            try
            {
                // Parse the index argument to an integer
                var index = int.Parse(argument);

                // Click on the option at the specified index
                options.ElementAt(index).Click();
            }
            catch (Exception e)
            {
                // If an exception occurs, create a G4ExceptionModel and add it to the plugin's exceptions
                var exception = new G4ExceptionModel(rule: pluginData.Rule, exception: e);
                plugin.AddExceptions(exception);
            }
        }
    }
}
