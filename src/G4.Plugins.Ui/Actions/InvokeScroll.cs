/*
 * RESOURCES
 * https://developer.mozilla.org/en-US/docs/Web/API/Element/scroll
 * https://developer.mozilla.org/en-US/docs/Web/API/Element/scrollBy
 * https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll
 * https://developer.mozilla.org/en-US/docs/Web/API/Window/scrollBy
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Text;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeScroll)}.json")]
    public class InvokeScroll(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the scroll animation style; "auto" defers the animation choice to the CSS scroll-behavior property.
            var behavior = pluginData.Parameters.Get(key: "Behavior", defaultValue: "auto");

            // Track which axes were supplied, because an absent axis is omitted from the script and keeps its position.
            var isLeft = pluginData.Parameters.ContainsKey("Left");
            var isTop = pluginData.Parameters.ContainsKey("Top");
            var left = int.Parse(s: pluginData.Parameters.Get(key: "Left", defaultValue: "0"));
            var top = int.Parse(s: pluginData.Parameters.Get(key: "Top", defaultValue: "0"));

            // Scroll by the offsets from the current position when the Relative switch is present;
            // otherwise scroll to the offsets as absolute positions.
            var isRelative = pluginData.Parameters.ContainsKey("Relative");

            // Skip the step entirely when no axis was supplied, so an empty rule never resets the scroll position.
            var hasNoOffset = !isLeft && !isTop;

            if (hasNoOffset)
            {
                return this.NewPluginResponse();
            }

            // Carry only the supplied axes into the script options; a null axis is left out of the options object.
            var options = new Options(behavior, left: isLeft ? left : null, top: isTop ? top : null, relative: isRelative);

            // Scroll the located overflow element when the rule names one; otherwise scroll the whole page.
            if (!string.IsNullOrEmpty(pluginData.Rule.OnElement))
            {
                ScrollElement(pluginBase: this, pluginData, options);
            }
            else
            {
                ScrollPage(pluginBase: this, options);
            }

            // Return an empty successful response because the action exposes no entity or session outputs.
            return this.NewPluginResponse();
        }

        // Scrolls the element resolved from the rule (inside the parent element when one exists) with the given options.
        private static void ScrollElement(PluginBase pluginBase, PluginDataModel pluginData, Options options)
        {
            // Resolve the target element first, so a missing or stale element fails the step before any script runs.
            var element = pluginBase.GetElement(rule: pluginData.Rule, element: pluginData.Element);

            // Build element.scroll() or element.scrollBy() with the shared options object for the selected mode.
            var scriptOptions = GetScriptOptions(options);
            var script = "arguments[0]." + GetScrollMethod(options) + "({" + scriptOptions + "});";

            // Run the script with the element as its first argument through the WebDriver execute-script endpoint.
            pluginBase.WebDriver.InvokeScript(script, element);
        }

        // Scrolls the whole page with the given options.
        private static void ScrollPage(PluginBase pluginBase, Options options)
        {
            // Build window.scroll() or window.scrollBy() with the shared options object for the selected mode.
            var scriptOptions = GetScriptOptions(options);
            var script = "window." + GetScrollMethod(options) + "({" + scriptOptions + "});";

            // Run the script in the current browsing context through the WebDriver execute-script endpoint.
            pluginBase.WebDriver.InvokeScript(script);
        }

        // Builds the JavaScript ScrollToOptions body: behavior always, top and left only for the supplied axes.
        private static string GetScriptOptions(Options options)
        {
            // Start with the animation style, which every scroll call carries.
            var scriptBuilder = new StringBuilder();
            scriptBuilder.Append("behavior: \"" + options.Behavior + "\"");

            // Add the vertical offset only when it was supplied, so the vertical position is otherwise kept.
            if (options.Top != null)
            {
                scriptBuilder.Append(",top: " + $"{options.Top}");
            }

            // Add the horizontal offset only when it was supplied, so the horizontal position is otherwise kept.
            if (options.Left != null)
            {
                scriptBuilder.Append(",left: " + $"{options.Left}");
            }

            // Return the options body that the scroll script wraps in braces.
            return scriptBuilder.ToString();
        }

        // Selects scrollBy for a relative scroll and scroll for an absolute one; both accept the same options object.
        private static string GetScrollMethod(Options options) => options.Relative
            ? "scrollBy"
            : "scroll";

        /// <summary>
        /// Represents options for scrolling.
        /// </summary>
        /// <param name="behavior">The behavior of scrolling.</param>
        /// <param name="left">The left offset for scrolling.</param>
        /// <param name="top">The top offset for scrolling.</param>
        /// <param name="relative">A value indicating whether the offsets are added to the current scroll position.</param>
        private sealed class Options(string behavior, int? left, int? top, bool relative)
        {
            /// <summary>
            /// Gets or sets the behavior of scrolling.
            /// </summary>
            public string Behavior { get; set; } = behavior;

            /// <summary>
            /// Gets or sets the left offset for scrolling.
            /// </summary>
            public int? Left { get; set; } = left;

            /// <summary>
            /// Gets or sets the top offset for scrolling.
            /// </summary>
            public int? Top { get; set; } = top;

            /// <summary>
            /// Gets or sets a value indicating whether the offsets are added to the current scroll position
            /// instead of being used as the absolute scroll position.
            /// </summary>
            public bool Relative { get; set; } = relative;
        }
    }
}
