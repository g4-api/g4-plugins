/*
 * RESOURCES
 * https://appium.readthedocs.io/en/latest/en/commands/session/geolocation/set-geolocation/#set-geolocation
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Models;
using G4.WebDriver.Remote.Appium;

using System;

namespace G4.Plugins.Ui.Actions.Mobile
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Mobile.Manifests.{nameof(SetGeolocation)}.json")]
    public class SetGeolocation(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Check if the WebDriver supports geolocation
            if (WebDriver is not IGeolocation)
            {
                throw new NotImplementedException("Geolocation is not supported by the current WebDriver.");
            }

            // Parse geolocation values from the plugin data
            _ = double.TryParse(pluginData.Parameters.Get("Altitude", "0"), out double altitude);
            _ = double.TryParse(pluginData.Parameters.Get("Latitude", "0"), out double latitude);
            _ = double.TryParse(pluginData.Parameters.Get("Longitude", "0"), out double longitude);

            // Create a GeolocationModel with the parsed values
            var geolocation = new GeolocationModel
            {
                Altitude = altitude,
                Latitude = latitude,
                Longitude = longitude
            };

            // Set the geolocation on the WebDriver
            ((IGeolocation)WebDriver).SetGeolocation(geolocation);

            // Return a new PluginResponseModel
            return this.NewPluginResponse();
        }
    }
}
