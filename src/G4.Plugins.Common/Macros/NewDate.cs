using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;

namespace G4.Plugins.Common.Macros
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Macros.Manifests.{nameof(NewDate)}.json")]
    public class NewDate(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extracting arguments
            var add = pluginData.Parameters.Get(key: "AddTime", defaultValue: default(string));
            var subtruct = pluginData.Parameters.Get(key: "SubtructTime", defaultValue: default(string));
            var format = pluginData.Parameters.Get(key: "Format", defaultValue: "yyyy-MM-ddTHH:mm:ss.ffffffK");
            var datePart = pluginData.Parameters.Get(key: "DatePart", defaultValue: default(string));
            var isUtc = pluginData.Parameters.ContainsKey("Utc");
            var isUnixEpoch = pluginData.Parameters.ContainsKey("UnixEpoch");
            var isOleAutomationDate = pluginData.Parameters.ContainsKey("OaDate");
            var isDayOfYear = pluginData.Parameters.ContainsKey("DayOfYear");
            var isDayOfWeek = pluginData.Parameters.ContainsKey("DayOfWeek");

            // Getting current date and time
            var dateTime = isUtc ? DateTime.UtcNow : DateTime.Now;
            object dateOutput = "-1";

            // Adding time if requested
            if (!string.IsNullOrEmpty(add))
            {
                var timeToAdd = pluginData.Parameters["AddTime"].ConvertToTimeSpan();
                dateTime = dateTime.Add(timeToAdd);
            }

            // Subtracting time if requested
            if (!string.IsNullOrEmpty(subtruct))
            {
                var timeToSubtruct = pluginData.Parameters["SubtructTime"].ConvertToTimeSpan();
                dateTime = dateTime.Subtract(timeToSubtruct);
            }

            // Converting to Unix epoch if requested
            if (isUnixEpoch)
            {
                dateOutput = new DateTimeOffset(dateTime).ToUnixTimeSeconds();
            }

            // Converting to OLE Automation Date if requested
            if (isOleAutomationDate)
            {
                dateOutput = dateTime.ToOADate();
            }

            // Extracting specific date part if requested
            if (!string.IsNullOrEmpty(datePart))
            {
                dateOutput = GetDatePart(dateTime, datePart);
            }

            // Extracting day of year if requested
            if (isDayOfYear)
            {
                dateOutput = dateTime.DayOfYear;
            }

            // Extracting day of week if requested
            if (isDayOfWeek)
            {
                dateOutput = dateTime.DayOfWeek;
            }

            // Formatting the output
            var macroResult = dateOutput.ToString() == "-1"
                ? dateTime.ToString(format)
                : $"{dateOutput}";

            // Returning the response using the NewMacroResponse method
            return this.NewMacroResponse(macroResult);
        }

        // Gets the specific part of the date and time.
        private static string GetDatePart(DateTime dateTime, string datePart)
        {
            // Return default value if datePart is null or empty
            if (string.IsNullOrEmpty(datePart))
            {
                return default;
            }

            // Switch on datePart to extract the corresponding part of the date and time
            return datePart.ToUpper() switch
            {
                "YEAR" => $"{dateTime.Year}",
                "MONTH" => $"{dateTime.Month}",
                "DAY" => $"{dateTime.Day}",
                "HOUR" => $"{dateTime.Hour}",
                "MINUTE" => $"{dateTime.Minute}",
                "SECOND" => $"{dateTime.Second}",
                "MILLISECOND" => $"{dateTime.Millisecond}",
                "NANOSECOND" => $"{dateTime.Nanosecond}",
                "MICROSECOND" => $"{dateTime.Microsecond}",
                "TICKS" => $"{dateTime.Ticks}",
                // Return default if datePart does not match any case
                _ => default
            };
        }
    }
}
