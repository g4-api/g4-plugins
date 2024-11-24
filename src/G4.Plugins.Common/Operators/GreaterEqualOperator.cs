using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Operators
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Operators.Manifests.{nameof(GreaterEqualOperator)}.json")]
    public class GreaterEqualOperator(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a static method for performing greater-than-or-equal checks for doubles.
            static bool AssertGreaterThanOrEqual(string leftHand, string rightHand)
            {
                // Check if the left-hand and right-hand values are valid doubles.
                var isLeftHandValid = double.TryParse(leftHand, out double actualOut);
                var isRightHandValid = double.TryParse(rightHand, out double expectedOut);

                // If either the left-hand or right-hand values are invalid, return false.
                if (!isLeftHandValid || !isRightHandValid)
                {
                    return false;
                }

                // Perform the greater-than-or-equal check.
                return actualOut >= expectedOut;
            }

            // Get the operator response using the defined greater-than-or-equal check method.
            return this.NewOperatorResponse(pluginData, factory: AssertGreaterThanOrEqual);
        }
    }
}
