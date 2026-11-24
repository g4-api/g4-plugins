using G4.Attributes;
using G4.Models;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.InputActions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.InputActions.Manifests.{nameof(AddKeyUp)}.json")]
    public class AddKeyUp(G4PluginSetupModel pluginSetup) : InputActionBase(pluginSetup)
    {
        protected override void AddAction(ActionSequence sequence, PluginDataModel pluginData)
        {
            // Resolve the key of the rule to the value the driver expects; an unknown key fails the rule here,
            // before anything is added to the sequence.
            var key = GetKey(pluginData);

            // Add the release as the next tick of the sequence. It ends a press added earlier in this container
            // or sent by a previous one, because the driver keeps the keyboard state between requests.
            sequence.AddKeyUp(key);
        }
    }
}
