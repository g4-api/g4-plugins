using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Remote.Interactions;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(MoveMouseCursor)}.json")]
    public class MoveMouseCursor(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve the action rule and web element from the provided data model.
            var action = pluginData.Rule;
            var element = pluginData.Element;

            // Create an ActionSequence to perform mouse actions
            var actions = new ActionSequence(WebDriver);

            // Format the action's argument as a dictionary
            var arguments = CliFactory.ConvertToDictionary(cli: action.Argument);

            // Determine if an element is specified in the action
            var isElement = !string.IsNullOrEmpty(action.OnElement);

            // Determine if an IWebElement is provided
            var isWebElement = element != null;

            // If either an element or IWebElement is available, get the target element
            var onElement = isElement || isWebElement
                ? this.GetElement(action, element)
                : default;

            // If an element is specified, move the mouse cursor to that element and exit
            if (onElement != default)
            {
                actions.AddMoveMouseCursor(onElement).Invoke();
                return this.NewPluginResponse();
            }

            // Parse X and Y coordinates from arguments
            _ = int.TryParse(s: arguments.Get(key: "X", defaultValue: "0"), result: out int x);
            _ = int.TryParse(s: arguments.Get(key: "Y", defaultValue: "0"), result: out int y);
            var origin = arguments.Get(key: "Origin", defaultValue: "pointer");

            // Move the mouse cursor to the specified X and Y coordinates
            actions.AddMoveMouseCursor(x, y, origin).Invoke();

            // Return new plugin response.
            return this.NewPluginResponse();
        }
    }
}
