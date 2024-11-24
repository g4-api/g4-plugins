using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Operators
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Operators.Manifests.{nameof(LowerEqualOperator)}.json")]
    public class LowerEqualOperator(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a factory method for performing lower than or equal to (<=) comparisons.
            static bool AssertLowerThanOrEqual(string leftHand, string rightHand)
            {
                // Check if the left-hand and right-hand values are valid doubles.
                var isLeftHandValid = double.TryParse(leftHand, out double actualOut);
                var isRightHandValid = double.TryParse(rightHand, out double expectedOut);

                // If either the left-hand or right-hand values are invalid, return false.
                if (!isLeftHandValid || !isRightHandValid)
                {
                    return false;
                }

                // Return true if the actual value is less than or equal to the expected value.
                return actualOut <= expectedOut;
            }

            // Get the operator response using the defined factory method.
            return this.NewOperatorResponse(pluginData, factory: AssertLowerThanOrEqual);
        }
    }
}
