/*
 * RESOURCES
 * https://github.com/appium/appium-uiautomator2-driver#mobile-startactivity
 */
using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;

namespace G4.Plugins.Ui.Actions.Mobile
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Actions.Mobile.Manifests.{nameof(SwitchActivity)}.json")]
    public class SwitchActivity(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // The Appium UiAutomator2 extension command that starts an Android activity from an intent.
        private const string StartActivityCommand = "mobile: startActivity";

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Read the package and the activity the recorder captured; both name the screen to open.
            var package = pluginData.Parameters.Get(key: "Package", defaultValue: string.Empty);
            var activity = pluginData.Parameters.Get(key: "Activity", defaultValue: string.Empty);

            // Fail before any driver call when the activity is missing, because Android cannot resolve an empty intent.
            if (string.IsNullOrWhiteSpace(activity))
            {
                const string message = "SwitchActivity needs the Activity argument, for example " +
                    "{{$ --Package:com.example.app --Activity:com.example.app.MainActivity}}.";
                throw new ArgumentException(message, nameof(pluginData));
            }

            // Build the intent as package/activity, or pass a fully qualified intent through unchanged.
            var intent = activity.Contains('/') || string.IsNullOrWhiteSpace(package)
                ? activity
                : $"{package}/{activity}";

            // Ask the Appium driver to start the activity, which brings that screen to the foreground.
            var arguments = new Dictionary<string, object>(StringComparer.Ordinal)
            {
                ["intent"] = intent
            };
            WebDriver.InvokeScript(StartActivityCommand, arguments);

            // Return an empty successful response because the action exposes no entity or session outputs.
            return this.NewPluginResponse();
        }
    }
}
