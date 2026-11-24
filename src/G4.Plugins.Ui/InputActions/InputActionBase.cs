using G4.Extensions;
using G4.Models;
using G4.Plugins.Ui.Actions;
using G4.WebDriver.Models;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Interactions;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace G4.Plugins.Ui.InputActions
{
    /// <summary>
    /// Provides the shared flow of an input action: a plugin that adds one low-level input action (a key, pointer,
    /// wheel or pause action) to the sequence its container sends.
    /// </summary>
    /// <param name="pluginSetup">The setup model the engine passes to every plugin it creates.</param>
    /// <remarks>
    /// An input action never talks to the driver by itself. The <see cref="InvokeInputActions"/> container creates
    /// one <see cref="ActionSequence"/>, places it in the context of each child rule under
    /// <see cref="SequenceKey"/>, runs the child rules, and sends the sequence once. A child removes the entry from
    /// its rule context after it added its action, which is how the container learns that the child succeeded. A
    /// rule that runs without the entry is outside the container and fails, because nothing sends its action.
    /// </remarks>
    public abstract class InputActionBase(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        #region *** Constants    ***
        /// <summary>
        /// The rule context key under which the container hands the shared sequence to an input action.
        /// </summary>
        /// <remarks>
        /// The entry lives only while the container runs its child rules; the container removes any entry a failed
        /// child left behind.
        /// </remarks>
        public const string SequenceKey = "InputActions.Sequence";

        // Maps the button names a rule may use to the button numbers the driver expects, ignoring letter case.
        private static readonly Dictionary<string, int> Buttons = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Left"] = MouseActionModel.MouseButtons.Left,
            ["Middle"] = MouseActionModel.MouseButtons.Middle,
            ["Right"] = MouseActionModel.MouseButtons.Right,
            ["Back"] = MouseActionModel.MouseButtons.Back,
            ["Forward"] = MouseActionModel.MouseButtons.Forward
        };

        // Lists the button names in the order the error message shows them, because a dictionary promises no order.
        private const string ButtonNames = "Left, Middle, Right, Back, Forward";

        // Lists the time-span forms a duration may use: hh:mm:ss, or d.hh:mm:ss with whole days first.
        private static readonly string[] TimeSpanFormats = [@"hh\:mm\:ss", @"d\.hh\:mm\:ss"];
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Adds the action of the concrete plugin to the sequence the container sends.
        /// </summary>
        /// <param name="sequence">
        /// The sequence shared by every child rule of the container; the action is appended as its next tick.
        /// </param>
        /// <param name="pluginData">
        /// The plugin data of the rule, with its parsed parameters and the element it runs on.
        /// </param>
        /// <remarks>
        /// The implementation only appends to the sequence and must not send it. An exception thrown here fails the
        /// rule, leaves the handoff entry in the rule context, and makes the container send nothing.
        /// </remarks>
        protected abstract void AddAction(ActionSequence sequence, PluginDataModel pluginData);

        /// <summary>
        /// Gets the value of an argument that a rule may write as a named parameter or as its plain argument.
        /// </summary>
        /// <param name="pluginData">The plugin data of the rule, with its parsed parameters and raw argument.</param>
        /// <param name="name">The parameter name, for example <c>Key</c>.</param>
        /// <returns>
        /// The parameter value; the plain argument when the rule has no parameters at all; otherwise, an empty string.
        /// </returns>
        /// <remarks>
        /// A rule argument that holds parameters is never returned as the value, so <c>{{$ --Other:1}}</c> does not
        /// become the key or the duration of the action.
        /// </remarks>
        protected static string GetArgument(PluginDataModel pluginData, string name)
        {
            // Treat the argument as the value itself only when it is not a parameter expression.
            var isPlainArgument = pluginData.Parameters.Count == 0;
            var fallback = isPlainArgument ? pluginData.Rule.Argument : string.Empty;

            // Prefer the named parameter, which is the explicit form.
            return pluginData.Parameters.Get(key: name, defaultValue: fallback) ?? string.Empty;
        }

        /// <summary>
        /// Gets the pointer button number named by the <c>Button</c> parameter of a rule.
        /// </summary>
        /// <param name="pluginData">The plugin data of the rule, with its parsed parameters and raw argument.</param>
        /// <returns>The button number the driver expects; the left button when the rule names none.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the rule names a button that does not exist.
        /// </exception>
        protected static int GetButton(PluginDataModel pluginData)
        {
            // Read the button name; a rule without one presses the left button, as a plain click does.
            var name = GetArgument(pluginData, name: "Button");

            if (string.IsNullOrEmpty(name))
            {
                return MouseActionModel.MouseButtons.Left;
            }

            // Resolve the name to its number; the lookup ignores letter case.
            if (Buttons.TryGetValue(key: name, value: out var button))
            {
                return button;
            }

            // Report the unknown name with the names the rule may use.
            var message = $"Button '{name}' is not supported. Use one of: {ButtonNames}.";
            throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Converts the duration text of a rule to whole milliseconds.
        /// </summary>
        /// <param name="value">
        /// The duration as written in the rule: a whole number of milliseconds, or a time span written as
        /// <c>hh:mm:ss</c> or <c>d.hh:mm:ss</c>.
        /// </param>
        /// <param name="defaultValue">The duration, in milliseconds, of a rule that sets none.</param>
        /// <returns>The duration in milliseconds, never negative.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the text is neither a whole number of milliseconds nor a time span written as <c>hh:mm:ss</c>
        /// or <c>d.hh:mm:ss</c>, or when it is negative or longer than <see cref="int.MaxValue"/> milliseconds.
        /// </exception>
        protected static int GetDuration(string value, int defaultValue)
        {
            // Keep the default of the action for a rule that sets no duration.
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            // Read whole milliseconds with the invariant culture, so a flow gives the same duration on every machine.
            var isNumber = int.TryParse(
                s: value,
                style: NumberStyles.Integer,
                provider: CultureInfo.InvariantCulture,
                result: out var milliseconds);
            var isMilliseconds = isNumber && milliseconds >= 0;

            if (isMilliseconds)
            {
                return milliseconds;
            }

            // Read a time span when the text is not a number; a span too long for the driver field is refused.
            var isTimeSpan = TimeSpan.TryParseExact(
                input: value,
                formats: TimeSpanFormats,
                formatProvider: CultureInfo.InvariantCulture,
                result: out var duration);
            var isInRange = isTimeSpan && duration >= TimeSpan.Zero && duration.TotalMilliseconds <= int.MaxValue;

            if (isInRange)
            {
                return (int)duration.TotalMilliseconds;
            }

            // Report the text as written, because a silent zero hides a typing error in the flow.
            var message = $"Duration '{value}' is not valid. " +
                "Use a non-negative whole number of milliseconds or an hh:mm:ss or d.hh:mm:ss time span.";
            throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Gets a whole-number parameter of a rule, such as a coordinate or a scroll amount.
        /// </summary>
        /// <param name="pluginData">The plugin data of the rule, with its parsed parameters.</param>
        /// <param name="name">The parameter name, for example <c>X</c>.</param>
        /// <returns>The parameter value; zero when the rule does not set the parameter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the value is not a whole number.</exception>
        protected static int GetInteger(PluginDataModel pluginData, string name)
        {
            // Read the parameter text; a rule without it leaves the value at zero.
            var value = pluginData.Parameters.Get(key: name, defaultValue: string.Empty);

            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            // Parse with the invariant culture so a flow gives the same number on every machine.
            var isInteger = int.TryParse(
                s: value,
                style: NumberStyles.Integer,
                provider: CultureInfo.InvariantCulture,
                result: out var number);

            if (isInteger)
            {
                return number;
            }

            // Report the parameter by name, because a rule may set several numbers.
            var message = $"Parameter '{name}' with value '{value}' is not a whole number.";
            throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Gets the key value named by the <c>Key</c> parameter or the plain argument of a rule.
        /// </summary>
        /// <param name="pluginData">The plugin data of the rule, with its parsed parameters and raw argument.</param>
        /// <returns>
        /// The value the driver expects: the code of a named key such as <c>Control</c>, or the single character itself.
        /// </returns>
        /// <remarks>
        /// A name is resolved through <see cref="ResolveKey"/>, so the accepted names are the constants of
        /// <see cref="Keys"/>; the manifests of the key actions publish the same list.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the rule sets no key, or sets text that is neither a known key name nor a single character.
        /// </exception>
        protected static string GetKey(PluginDataModel pluginData)
        {
            // Read the key as written in the rule; a key action without a key has nothing to press or release.
            var name = GetArgument(pluginData, name: "Key");

            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("Set the key in the 'Key' parameter or as the plain argument.");
            }

            // Resolve a named key, such as Control or Enter, to the code the driver defines for it.
            var key = ResolveKey(name);

            if (!string.IsNullOrEmpty(key))
            {
                return key;
            }

            // Accept one character as is, which is how a letter, a digit or a symbol key is written.
            var isSingleCharacter = new StringInfo(value: name).LengthInTextElements == 1;

            if (isSingleCharacter)
            {
                return name;
            }

            // Report longer unknown text, because the driver accepts exactly one key value per action.
            var message = $"Key '{name}' is not valid. Use a key name such as Control, Shift or Enter, " +
                "or a single character.";
            throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Gets the element a pointer or wheel action of a rule is measured from, when the rule has one.
        /// </summary>
        /// <param name="plugin">The plugin that runs the rule; its driver finds the element.</param>
        /// <param name="pluginData">The plugin data of the rule, with its locator and the element it inherited.</param>
        /// <returns>The element; <see langword="null"/> when the rule names no element and inherited none.</returns>
        /// <remarks>
        /// A rule names an element through <c>OnElement</c>. A rule without one uses the element its container
        /// inherited, for example the current element of a for-each loop. A named element that cannot be found
        /// throws the driver exception, which fails the rule.
        /// </remarks>
        protected static IWebElement GetOriginElement(PluginBase plugin, PluginDataModel pluginData)
        {
            // Decide whether the rule has an element at all, named or inherited.
            var isNamedElement = !string.IsNullOrEmpty(pluginData.Rule.OnElement);
            var isInheritedElement = pluginData.Element != null;

            if (!isNamedElement && !isInheritedElement)
            {
                return null;
            }

            // Find the named element, or keep the inherited one; a missing element throws here.
            return plugin.GetElement(rule: pluginData.Rule, element: pluginData.Element);
        }

        /// <summary>
        /// Resolves a key name, such as <c>Enter</c> or <c>Control</c>, to the key value the driver expects.
        /// </summary>
        /// <param name="name">The key name as written in the rule; letter case is ignored.</param>
        /// <returns>
        /// The value of the <see cref="Keys"/> constant with that name; <see langword="null"/> when no constant has it.
        /// </returns>
        /// <remarks>
        /// The names are the constants of <see cref="Keys"/> in the WebDriver client, which is also the list the key
        /// action manifests publish. Two names of one key, such as <c>Shift</c> and <c>LeftShift</c>, resolve to the
        /// same value. A <see langword="null"/> name throws, so check for an empty name first, as <see cref="GetKey"/>
        /// does.
        /// </remarks>
        protected static string ResolveKey(string name)
        {
            // Look the name up in the client's own table of key constants, which ignores letter case.
            return Keys.Get(keyName: name);
        }

        /// <inheritdoc />
        protected sealed override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the sequence the container placed in the rule context; a rule that runs anywhere else has none.
            pluginData.Rule.Context.TryGetValue(key: SequenceKey, value: out var handoff);
            var sequence = handoff as ActionSequence;

            // Fail a rule outside the container, because an input action has nothing to send by itself.
            if (sequence == null)
            {
                var message = $"'{pluginData.Rule.PluginName}' is an input action and runs only as a child rule " +
                    $"of '{nameof(InvokeInputActions)}'.";
                throw new InvalidOperationException(message);
            }

            // Append the action of the concrete plugin; nothing reaches the driver at this point.
            AddAction(sequence, pluginData);

            // Give the handoff back so the container learns this rule added its action. An exception above skips
            // this line, and the entry left in the context is what tells the container to send nothing.
            pluginData.Rule.Context.Remove(key: SequenceKey);

            return this.NewPluginResponse();
        }
        #endregion
    }
}
