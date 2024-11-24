using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System.Text.RegularExpressions;

namespace G4.Plugins.Common.Operators
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Operators.Manifests.{nameof(MatchOperator)}.json")]
    public class MatchOperator(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            return this.NewOperatorResponse(pluginData, factory: Regex.IsMatch);
        }
    }
}
