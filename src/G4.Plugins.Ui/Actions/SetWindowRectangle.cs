using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Models;

namespace G4.Plugins.Ui.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Manifests.{nameof(SetWindowRectangle)}.json")]
    public class SetWindowRectangle(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Get CLI arguments
            var parameters = pluginData.Parameters;

            // Get CLI argument values for window rectangle properties (Height, Width, X, Y)
            // and set them to an empty string if not provided in CLI arguments
            var height = parameters.Get(key: "Height", string.Empty);
            var width = parameters.Get(key: "Width", string.Empty);
            var x = parameters.Get(key: "X", string.Empty);
            var y = parameters.Get(key: "Y", string.Empty);

            // Parse CLI arguments to double values
            var isHeight = double.TryParse(height, out double heightOut);
            var isWidth = double.TryParse(width, out double widthOut);
            var isX = double.TryParse(x, out double xOut);
            var isY = double.TryParse(y, out double yOut);

            // Get the current window rectangle from WebDriver
            var windowRect = WebDriver.Manage().Window.WindowRect;

            // Create a RectModel for the window rectangle
            var rect = new RectModel
            {
                Height = isHeight ? heightOut : windowRect.Height,
                Width = isWidth ? widthOut : windowRect.Width,
                X = isX ? xOut : windowRect.X,
                Y = isY ? yOut : windowRect.Y
            };

            // Set the window rectangle using WebDriver
            WebDriver.Manage().Window.SetWindowRect(rect);

            // Return a new plugin response
            return this.NewPluginResponse();
        }
    }
}
