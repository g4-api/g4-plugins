using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Exceptions;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;

using System;
using System.Collections.Concurrent;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(ElementStale)}.json")]
    public class ElementStale(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Define a concurrent dictionary to store elements locator with their session and ID as keys.
        private readonly static ConcurrentDictionary<string, (string Locator, IWebElement Element)> s_elements = [];

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Local function to check if the element is stale.
            bool ConfirmElementStaleness()
            {
                // Attempt to access the Text property of the element.
                try
                {
                    // Get the session key and element ID.
                    var session = WebDriver.GetSession().OpaqueKey;
                    var elementLocator = ByFactory.Get(pluginData.Rule.Locator, pluginData.Rule.OnElement);
                    var key = $"{session}-{elementLocator}";

                    // Check if the element exists in the dictionary of stale elements.
                    if (s_elements.TryGetValue(key, out (string Locator, IWebElement Element) staleElement))
                    {
                        // Accessing Text property to trigger potential StaleElementReferenceException.
                        _ = staleElement.Element.Text;
                    }
                    else
                    {
                        // Add the element to the dictionary if it's not already present.
                        var element = this.FindElement(pluginData.Rule, pluginData.Element);

                        // try accessing the Text property to trigger potential exceptions.
                        _ = element.Text;

                        // Add the element to the dictionary.
                        s_elements[key] = ($"{elementLocator}", element);
                    }
                }
                // Element is considered stale if a StaleElementReferenceException is caught.
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (Exception e) when(e is not StaleElementReferenceException)
                {
                    throw e.GetBaseException();
                }

                // Element is not stale.
                return false;
            }

            // Get the assertion response for ElementStale condition.
            return this.NewAssertResponse(pluginData, factory: ConfirmElementStaleness);
        }
    }
}
