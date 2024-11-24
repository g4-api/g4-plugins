using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeDoubleClick)}.json")]
    public class InvokeDoubleClick(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the action rule and web element from the provided data model.
            var action = pluginData.Rule;
            var element = pluginData.Element;

            // Create a new action sequence
            var actionSequence = new ActionSequence(WebDriver);

            // Check if the element exists
            if (action.AssertHasNoElement(element))
            {
                // Perform context click (right-click) if the element exists
                actionSequence.AddDoubleClick().Invoke();
                return this.NewPluginResponse();
            }

            // Get the target element using the action rule model and optional input element
            var onElement = this.GetElement(action, element);

            // Move the mouse cursor to the target element
            onElement.MoveToElement();

            // Perform double-click action on the target element
            actionSequence.AddDoubleClick(onElement).Invoke();

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
