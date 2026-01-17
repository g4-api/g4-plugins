using G4.Attributes;
using G4.Models;
using G4.WebDriver.Extensions;

namespace G4.Plugins.Ui.ExtractionScopes
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.ExtractionScopes.Manifests.{nameof(PageSourceExtractionScope)}.json")]
    public class PageSourceExtractionScope(G4PluginSetupModel pluginSetup) : HtmlExtractionScopeBase(pluginSetup)
    {
        protected override string GetHtml(PluginDataModel pluginData)
        {
            // Determine the source of HTML content to scrape.
            return pluginData.Element != null
                ? pluginData.Element.GetOuterHtml()  // If an element is provided, use its source.
                : WebDriver.PageSource;              // Otherwise, use the entire page source.
        }
    }
}
