using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Operators
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Operators.Manifests.{nameof(LowerOperator)}.json")]
    public class LowerOperator(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a factory method for performing lower than (<) comparisons.
            static bool ConfirmLowerThanComparison(string leftHand, string rightHand)
            {
                return
                    double.TryParse(leftHand, out double actualOut) &&
                    double.TryParse(rightHand, out double expectedOut) &&
                    (actualOut < expectedOut);
            }

            // Get the operator response using the defined factory method.
            return this.NewOperatorResponse(pluginData, factory: ConfirmLowerThanComparison);
        }
    }
}
