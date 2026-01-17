using G4.Attributes;
using G4.Extensions;
using G4.Models;

namespace G4.Plugins.Common.Operators
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Operators.Manifests.{nameof(GreaterOperator)}.json")]
    public class GreaterOperator(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Define a static method for performing greater-than checks for doubles.
            static bool AssertGreaterThan(string leftHand, string rightHand)
            {
                // Check if the left-hand and right-hand values are valid doubles.
                var isLeftHandValid = double.TryParse(leftHand, out double actualOut);
                var isRightHandValid = double.TryParse(rightHand, out double expectedOut);

                // If either the left-hand or right-hand values are invalid, return false.
                if (!isLeftHandValid || !isRightHandValid)
                {
                    return false;
                }

                // Return true if the actual value is greater then the expected value.
                return actualOut > expectedOut;
            }

            // Get the operator response using the defined factory method.
            return this.NewOperatorResponse(pluginData, factory: AssertGreaterThan);
        }
    }
}
