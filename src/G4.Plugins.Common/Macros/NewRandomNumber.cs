using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Common.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Macros.Manifests.{nameof(NewRandomNumber)}.json")]
    public class NewRandomNumber(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract number type and seed information from plugin data
            var numberType = pluginData.Parameters.Get("NumberType", "Integer");
            var isSeed = pluginData.Parameters.ContainsKey("Seed");

            // Create a new random number generator with or without seed
            var random = isSeed
                ? new Random(Seed: Guid.NewGuid().GetHashCode())
                : new Random();

            // Determine the type of random number requested and generate it
            var macroResult = numberType.ToUpper() switch
            {
                "BYTE" => NewByte(random, pluginData),
                "DOUBLE" => $"{random.NextDouble()}",
                "FLOAT" => $"{random.NextSingle()}",
                "INTEGER" => NewInteger(random, pluginData),
                "LONG" => NewLong(random, pluginData),
                _ => NewInteger(random, pluginData),
            };

            // Return the generated random number as a macro response
            return this.NewMacroResponse(macroResult);
        }

        // Generates a random byte value within the specified range.
        private static string NewByte(Random random, PluginDataModel pluginData)
        {
            // Get the minimum and maximum byte values from the plugin data arguments
            var minValue = pluginData.Parameters.Get("MinValue", $"{byte.MinValue}");
            var maxValue = pluginData.Parameters.Get("MaxValue", $"{byte.MaxValue}");

            // Generate a random byte value within the specified range
            return $"{random.Next(
                minValue: byte.Parse(minValue),
                maxValue: byte.Parse(maxValue))}";
        }

        // Generates a new random integer value within the specified range.
        private static string NewInteger(Random random, PluginDataModel pluginData)
        {
            // Get the minimum and maximum integer values from the plugin data arguments
            var minValue = pluginData.Parameters.Get("MinValue", $"{int.MinValue}");
            var maxValue = pluginData.Parameters.Get("MaxValue", $"{int.MaxValue}");

            // Generate a random integer value within the specified range
            return $"{random.Next(
                minValue: int.Parse(minValue),
                maxValue: int.Parse(maxValue))}";
        }

        // Generates a new random long value within the specified range.
        private static string NewLong(Random random, PluginDataModel pluginData)
        {
            // Get the minimum and maximum long values from the plugin data arguments
            var minValue = pluginData.Parameters.Get("MinValue", $"{long.MinValue}");
            var maxValue = pluginData.Parameters.Get("MaxValue", $"{long.MaxValue}");

            // Generate a random long value within the specified range
            return $"{random.NextInt64(
                minValue: long.Parse(minValue),
                maxValue: long.Parse(maxValue))}";
        }
    }
}
