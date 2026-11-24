using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;

using System;

namespace G4.Plugins.Ui.InputActions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.InputActions.Manifests.{nameof(AddPointerMove)}.json")]
    public class AddPointerMove(G4PluginSetupModel pluginSetup) : InputActionBase(pluginSetup)
    {
        // The time, in milliseconds, a move takes when the rule sets none. It matches the move of the ready-made
        // mouse actions. Whether a longer time adds move events depends on the driver: ChromeDriver sends one move
        // at the end, so a path that a page follows is built from several moves.
        private const int DefaultDurationMilliseconds = 250;

        protected override void AddAction(ActionSequence sequence, PluginDataModel pluginData)
        {
            // Find the element the move is measured from, when the rule names one or inherited one. A named
            // element that is missing fails the rule here, before anything is added to the sequence.
            var element = GetOriginElement(plugin: this, pluginData);

            // Read the coordinates: offsets from the element center, or a position measured from the origin.
            var x = GetInteger(pluginData, name: "X");
            var y = GetInteger(pluginData, name: "Y");

            // Read how long the move takes. Only the named parameter is read, because the plain argument of this
            // rule carries no value.
            var durationValue = pluginData.Parameters.Get(key: "Duration", defaultValue: string.Empty);
            var duration = GetDuration(value: durationValue, defaultValue: DefaultDurationMilliseconds);

            // Measure from the element when there is one; otherwise from the origin the rule names.
            var origin = element != null
                ? element.ConvertToDictionary()
                : (object)GetOrigin(pluginData);

            // Describe the move as one pointer action; the driver moves the pointer over the given duration.
            var action = new MouseActionModel
            {
                Duration = duration,
                Origin = origin,
                Type = MouseActionModel.ActionTypes.PointerMove,
                X = x,
                Y = y
            };

            // Add the move as the next tick of the sequence.
            sequence.AddAction(action);
        }

        // Resolves the Origin parameter of the rule to the origin name the driver expects. A rule without the
        // parameter moves relative to the current pointer position, as the MoveMouseCursor action does.
        private static string GetOrigin(PluginDataModel pluginData)
        {
            // Read the origin as written in the rule, with the pointer as the default.
            var name = pluginData.Parameters.Get(key: "Origin", defaultValue: ActionOrigins.Pointer);
            var comparison = StringComparison.OrdinalIgnoreCase;

            // Return the exact lower-case name of the protocol, whatever letter case the rule used.
            if (ActionOrigins.Pointer.Equals(value: name, comparisonType: comparison))
            {
                return ActionOrigins.Pointer;
            }

            if (ActionOrigins.Viewport.Equals(value: name, comparisonType: comparison))
            {
                return ActionOrigins.Viewport;
            }

            // Report the unknown origin with the two names the rule may use.
            var message = $"Origin '{name}' is not supported. Use Pointer or Viewport, " +
                "or set OnElement to measure from an element.";
            throw new InvalidOperationException(message);
        }
    }
}
