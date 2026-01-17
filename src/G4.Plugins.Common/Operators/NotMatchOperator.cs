using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Operators
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Operators.Manifests.{nameof(NotMatchOperator)}.json")]
    public class NotMatchOperator(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            return this.NewOperatorResponse(
                pluginData,
                factory: (leftHand, rightHand) => !Regex.IsMatch(leftHand, rightHand, RegexOptions.Singleline));
        }
    }
}
