using G4.Attributes;
using G4.Models;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.InputActions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.InputActions.Manifests.{nameof(AddPointerUp)}.json")]
    public class AddPointerUp(G4PluginSetupModel pluginSetup) : InputActionBase(pluginSetup)
    {
        protected override void AddAction(ActionSequence sequence, PluginDataModel pluginData)
        {
            // Resolve the button of the rule to its number; a rule without one releases the left button, and an
            // unknown name fails the rule here, before anything is added to the sequence.
            var button = GetButton(pluginData);

            // Add the release as the next tick of the sequence, at the place the pointer was last moved to. It
            // ends a press added earlier in this container or sent by a previous one.
            sequence.AddPointerUp(button);
        }
    }
}
