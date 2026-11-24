using G4.Attributes;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.InputActions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.InputActions.Manifests.{nameof(AddScroll)}.json")]
    public class AddScroll(G4PluginSetupModel pluginSetup) : InputActionBase(pluginSetup)
    {
        protected override void AddAction(ActionSequence sequence, PluginDataModel pluginData)
        {
            // Find the element the scroll starts from, when the rule names one or inherited one. A named
            // element that is missing fails the rule here, before anything is added to the sequence.
            var element = GetOriginElement(plugin: this, pluginData);

            // Read how far the wheel turns on each axis; a positive DeltaY scrolls down, a positive DeltaX right.
            var deltaX = GetInteger(pluginData, name: "DeltaX");
            var deltaY = GetInteger(pluginData, name: "DeltaY");

            // Read where the wheel turns: offsets from the element center, or a position in the viewport.
            var x = GetInteger(pluginData, name: "X");
            var y = GetInteger(pluginData, name: "Y");

            // Start from the element when there is one; otherwise from the top-left corner of the viewport.
            var origin = element != null
                ? element.ConvertToDictionary()
                : (object)ActionOrigins.Viewport;

            // Describe the scroll as one wheel action.
            var action = new WheelActionModel
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                Origin = origin,
                X = x,
                Y = y
            };

            // Add the scroll as the next tick of the sequence; the sequence gives the wheel its own input source.
            sequence.AddAction(action);
        }
    }
}
