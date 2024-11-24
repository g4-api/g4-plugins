using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Text.RegularExpressions;

namespace G4.Plugins.Ui.Assertions
{
    [G4Plugin(
        assembly: "G4.Plugins.Ui, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Ui.Assertions.Manifests.{nameof(ElementTextLength)}.json")]
    public class ElementTextLength(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a factory method to calculate the length of text in the element.
            int ConfirmTextLength()
            {
                // Get the action rule and element from the provided data.
                var action = pluginData.Rule;
                var element = pluginData.Element;

                // Find the element under test based on the action and element description.
                var elementUnderTest = this.FindElement(action, element);

                // Determine the input text based on the action's OnAttribute property.
                var input = string.IsNullOrEmpty(action.OnAttribute)
                    ? elementUnderTest.Text
                    : elementUnderTest.GetAttribute(action.OnAttribute);

                // Use regular expression to match and calculate the length of the text.
                return Regex
                    .Match(input, pattern: action.RegularExpression, RegexOptions.Singleline)
                    .Value
                    .Length;
            }

            // Get the assertion response for ElementTextLength condition.
            return this.NewAssertResponse(
                pluginData,
                factory: ConfirmTextLength);
        }
    }
}
