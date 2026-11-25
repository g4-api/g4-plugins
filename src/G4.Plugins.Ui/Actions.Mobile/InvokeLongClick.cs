using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.Actions.Mobile
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Mobile.Manifests.{nameof(InvokeLongClick)}.json")]
    public class InvokeLongClick(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The hold time used when the rule names no Duration, long enough for Android to report a long click.
        private const int DefaultDurationMilliseconds = 1000;

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the action rule and the optional parent element from the provided data model.
            var action = pluginData.Rule;
            var element = pluginData.Element;

            // Read the hold time, falling back to the default when the argument is absent or not a positive number.
            var durationText = pluginData.Parameters.Get(key: "Duration", defaultValue: $"{DefaultDurationMilliseconds}");
            var isDuration = int.TryParse(durationText, out var duration) && duration > 0;
            duration = isDuration ? duration : DefaultDurationMilliseconds;

            // Create one touch sequence so the press, the hold and the release reach the device as one gesture.
            var actionSequence = new ActionSequence(driver: WebDriver, pointerType: PointerTypes.Touch);

            // Press and hold at the current pointer position when the rule names no element and no parent exists.
            if (action.AssertHasNoElement(element))
            {
                actionSequence
                    .AddPointerDown()
                    .AddPauseAction(duration)
                    .AddPointerUp()
                    .Invoke();

                return this.NewPluginResponse();
            }

            // Resolve the target element from the rule locator, inside the parent element when one exists.
            var onElement = this.GetElement(rule: action, element);

            // Move the touch pointer to the element center, then press, hold for the duration and release there.
            actionSequence
                .AddMoveMouseCursor(element: onElement)
                .AddPointerDown()
                .AddPauseAction(duration)
                .AddPointerUp()
                .Invoke();

            // Return an empty successful response because the action exposes no entity or session outputs.
            return this.NewPluginResponse();
        }
    }
}
