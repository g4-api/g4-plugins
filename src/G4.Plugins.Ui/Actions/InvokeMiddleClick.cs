using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeMiddleClick)}.json")]
    public class InvokeMiddleClick(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the action rule and the optional parent element from the provided data model.
            var action = pluginData.Rule;
            var element = pluginData.Element;

            // Create one action sequence so the pointer movement and the button gesture are sent together.
            var actionSequence = new ActionSequence(driver: WebDriver);

            // Click at the current pointer position when the rule names no element and no parent element exists.
            if (action.AssertHasNoElement(element))
            {
                actionSequence
                    .AddPointerDown(button: MouseActionModel.MouseButtons.Middle)
                    .AddPointerUp(button: MouseActionModel.MouseButtons.Middle)
                    .Invoke();

                return this.NewPluginResponse();
            }

            // Resolve the target element from the rule locator, inside the parent element when one exists.
            var onElement = this.GetElement(rule: action, element);

            // Bring the target element into view before the pointer is moved to its center.
            onElement.MoveToElement();

            // Move the pointer to the element center, then press and release the middle button there.
            actionSequence
                .AddMoveMouseCursor(element: onElement)
                .AddPointerDown(button: MouseActionModel.MouseButtons.Middle)
                .AddPointerUp(button: MouseActionModel.MouseButtons.Middle)
                .Invoke();

            // Return an empty successful response because the action exposes no entity or session outputs.
            return this.NewPluginResponse();
        }
    }
}
