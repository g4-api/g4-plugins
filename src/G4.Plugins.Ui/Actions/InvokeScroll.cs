/*
 * RESOURCES
 * https://developer.mozilla.org/en-US/docs/Web/API/Element/scroll
 * https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Text;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(InvokeScroll)}.json")]
    public class InvokeScroll(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Retrieve behavior argument, defaulting to "auto" if not provided
            var behavior = pluginData.Parameters.Get("Behavior", "auto");

            // Try to parse "Left" argument to integer, defaulting to 0 if parsing fails
            var isLeft = pluginData.Parameters.ContainsKey("Left");
            var left = int.Parse(pluginData.Parameters.Get("Left", "0"));

            // Try to parse "Top" argument to integer, defaulting to 0 if parsing fails
            var top = int.Parse(pluginData.Parameters.Get("Top", "0"));
            var isTop = pluginData.Parameters.ContainsKey("Top");

            // Create options object with parsed arguments
            var options = new Options(behavior, isLeft ? left : null, isTop ? top : null);

            // Check if both "Left" and "Top" arguments failed to parse
            var invalid = !isLeft && !isTop;

            // Check if there's a rule defined for the element and arguments are valid
            if (!string.IsNullOrEmpty(pluginData.Rule.OnElement) && !invalid)
            {
                // Scroll to specific element
                ScrollElement(pluginBase: this, pluginData, options);
            }
            else if (!invalid)
            {
                // Scroll the whole page
                ScrollPage(pluginBase: this, options);
            }

            // Return a new plugin response
            return this.NewPluginResponse();
        }

        #region *** Methods: Private ***
        // Scrolls to a specific element based on provided options.
        private static void ScrollElement(PluginBase pluginBase, PluginDataModel pluginData, Options options)
        {
            // Get the element to scroll to
            var element = pluginBase.GetElement(pluginData.Rule, pluginData.Element);

            // Construct the script options string
            var scriptOptions = GetScriptOptions(options);

            // Construct the full script to scroll the element
            var script = "arguments[0].scroll({" + scriptOptions + "});";

            // Invoke the JavaScript code to scroll the element
            pluginBase.WebDriver.InvokeScript(script, element);
        }

        // Scrolls the entire page based on provided options.
        private static void ScrollPage(PluginBase pluginBase, Options options)
        {
            // Construct the script options string
            var scriptOptions = GetScriptOptions(options);

            // Construct the full script to scroll the page
            var script = "window.scroll({" + scriptOptions + "});";

            // Invoke the JavaScript code to scroll the page
            pluginBase.WebDriver.InvokeScript(script);
        }

        // Constructs the script options string based on the provided Options object.
        private static string GetScriptOptions(Options options)
        {
            // Initialize a StringBuilder to build the script options string
            var scriptBuilder = new StringBuilder();

            // Append behavior option
            scriptBuilder.Append("behavior: \"" + options.Behavior + "\"");

            // Append top option if it's not null
            if (options.Top != null)
            {
                scriptBuilder.Append(",top: " + $"{options.Top}");
            }

            // Append left option if it's not null
            if (options.Left != null)
            {
                scriptBuilder.Append(",left: " + $"{options.Left}");
            }

            // Return the constructed script options string
            return scriptBuilder.ToString();
        }
        #endregion

        #region *** Nested Types     ***
        /// <summary>
        /// Represents options for scrolling.
        /// </summary>
        /// <param name="behavior">The behavior of scrolling.</param>
        /// <param name="left">The left offset for scrolling.</param>
        /// <param name="top">The top offset for scrolling.</param>
        private sealed class Options(string behavior, int? left, int? top)
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
        }
        #endregion
    }
}
