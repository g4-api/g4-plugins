using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeContextClick)}.json")]
    public class InvokeContextClick(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the action rule and web element from the provided data model.
            var action = pluginData.Rule;
            var element = pluginData.Element;

            // Create an ActionSequence to perform WebDriver actions.
            var actionSequence = new ActionSequence(WebDriver);

            // Check if an element is provided and assert its presence
            // If an element is provided, perform a context-click on it.
            // Perform context-click and exit
            if (action.AssertHasNoElement(element))
            {
                actionSequence.AddContextClick().Invoke();
                return this.NewPluginResponse();
            }

            // Get the target element using the action rule and provided element
            var onElement = this.GetElement(action, element);

            // Try to move the mouse cursor to the target element
            onElement.MoveToElement();

            // Perform context-click on the target element
            actionSequence.AddContextClick(onElement).Invoke();

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
