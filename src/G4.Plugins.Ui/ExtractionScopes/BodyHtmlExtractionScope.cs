using G4.Attributes;
using G4.Extensions;
using G4.Models;
using G4.WebDriver.Extensions;
using G4.WebDriver.Models;

namespace G4.Plugins.Ui.ExtractionScopes
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.ExtractionScopes.Manifests.{nameof(BodyHtmlExtractionScope)}.json")]
    public class BodyHtmlExtractionScope(G4PluginSetupModel pluginSetup) : HtmlExtractionScopeBase(pluginSetup)
    {
        protected override string GetHtml(PluginDataModel pluginData)
        {
            // Determine the source of HTML content to scrape.
            return pluginData.Element != null
                ? pluginData.Element.GetOuterHtml()                        // If an element is provided, use its source.
                : WebDriver.GetElement(By.Xpath("//body")).GetOuterHtml(); // Otherwise, use the web driver to fetch the <body> HTML source.
        }
    }
}
