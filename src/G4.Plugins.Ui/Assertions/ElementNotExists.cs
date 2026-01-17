using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Exceptions;

using System;
using System.Collections.Generic;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(ElementNotExists)}.json")]
    public class ElementNotExists(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a factory function to check if the element does not exist.
            bool ConfirmElementNonExistence()
            {
                // Define a list of exceptions that may indicate the element doesn't exist.
                var exceptions = new List<Type>
                {
                    typeof(NoSuchElementException),
                    typeof(NullReferenceException),
                    typeof(WebDriverTimeoutException),
                    typeof(TimeoutException)
                };

                // Attempt to find the element, and return true if it's not found.
                try
                {
                    return this.FindElement(pluginData.Rule, pluginData.Element) == null;
                }
                // If one of the expected exceptions occurs, consider the element not existing.
                catch (Exception e) when (exceptions.Exists(i => e.GetType() == i))
                {
                    return true;
                }
            }

            // Use the factory function to create an assertion response.
            return this.NewAssertResponse(pluginData, factory: ConfirmElementNonExistence);
        }
    }
}
