using G4.Attributes;
using G4.Models;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.InputActions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.InputActions.Manifests.{nameof(AddPause)}.json")]
    public class AddPause(G4PluginSetupModel pluginSetup) : InputActionBase(pluginSetup)
    {
        // The pause, in milliseconds, of a rule that sets no duration: a tick that only keeps the order.
        private const int DefaultDurationMilliseconds = 0;

        protected override void AddAction(ActionSequence sequence, PluginDataModel pluginData)
        {
            // Read the duration from the Duration parameter or from the plain argument; text that is not a
            // duration fails the rule here, before anything is added to the sequence.
            var value = GetArgument(pluginData, name: "Duration");
            var duration = GetDuration(value, defaultValue: DefaultDurationMilliseconds);

            // Add the pause as the next tick of the sequence. The driver waits that long between the action
            // before it and the action after it, with every key and button kept as it is.
            sequence.AddPauseAction(duration);
        }
    }
}
