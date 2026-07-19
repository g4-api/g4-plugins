using G4.Attributes;
using G4.Exceptions;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Models;
using G4.WebDriver.Remote.Interactions;
using G4.WebDriver.Remote.Uia;

namespace G4.Plugins.Ui.Actions.User32
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.User32.Manifests.{nameof(InvokeUser32ContextClick)}.json")]
    public class InvokeUser32ContextClick(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Preserve compatibility with non-native automation sessions by leaving them unchanged.
            if (WebDriver is not IUser32Driver)
            {
                return this.NewPluginResponse();
            }

            // Resolve the optional positioning parameters once so mode selection and pointer movement share one contract.
            var offsetX = int.Parse(pluginData.Parameters.Get("OffsetX", defaultValue: "0"));
            var offsetY = int.Parse(pluginData.Parameters.Get("OffsetY", defaultValue: "0"));
            var x = int.Parse(pluginData.Parameters.Get("X", defaultValue: "0"));
            var y = int.Parse(pluginData.Parameters.Get("Y", defaultValue: "0"));
            var alignment = pluginData.Parameters.Get("Alignment", defaultValue: "MiddleCenter");

            // Select coordinate mode only when a coordinate is supplied without an element target.
            var hasCoordinates = x != 0 || y != 0;
            var hasNoElement = pluginData.AssertHasNoElement();

            if (hasCoordinates && hasNoElement)
            {
                InvokeContextClickByCoordinates(plugin: this, x, y);
                return this.NewPluginResponse();
            }

            // Reject an empty target before resolving a native element so failures remain explicit and actionable.
            if (hasNoElement)
            {
                const string message = "Either an element target or a non-zero X or Y coordinate is required.";
                throw new MissingMandatoryParameterException(message);
            }

            // Resolve the native element and compute its aligned pointer location through the UIA client contract.
            var element = this.GetUser32Element(pluginData);
            var positionData = new MousePositionInputModel
            {
                Alignment = alignment,
                OffsetX = offsetX,
                OffsetY = offsetY
            };

            // Move the system pointer before dispatching the right-button sequence at the resolved location.
            element.MoveToElement(positionData);
            new ActionSequence(WebDriver).AddContextClick().Invoke();

            // Return an empty successful response because the action exposes no entity or session outputs.
            return this.NewPluginResponse();
        }

        // Moves the system pointer to viewport coordinates and dispatches one native right-button sequence.
        private static void InvokeContextClickByCoordinates(PluginBase plugin, int x, int y)
        {
            // Keep movement and context-click actions in one request so the click uses the resulting pointer position.
            var actions = new ActionSequence(plugin.WebDriver);
            actions
                .AddMoveMouseCursor(x, y, origin: "viewport")
                .AddPauseAction(20)
                .AddContextClick()
                .Invoke();
        }
    }
}
