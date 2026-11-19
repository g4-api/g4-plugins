using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{NameReference}.json")]
    public class AddFile(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Namespaces the session output so every AddFile call appends to the same AddFile:Files list.
        private const string NameReference = nameof(AddFile);

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Reject a white-space argument before touching the file system, because the argument is the only file
            // source. The engine already rejects an empty argument as a missing mandatory property.
            if (string.IsNullOrWhiteSpace(pluginData.Rule.Argument))
            {
                const string message = "The AddFile rule requires a file path in the argument.";
                throw new ArgumentException(message, paramName: nameof(pluginData));
            }

            // Resolve a relative path against the working directory and read the raw bytes once. A missing file
            // throws FileNotFoundException, which the engine reports as the step failure.
            var path = Path.GetFullPath(pluginData.Rule.Argument);
            var bytes = File.ReadAllBytes(path);

            // Fall back to the engine default pattern so a rule without a regular expression returns the whole text.
            var pattern = string.IsNullOrEmpty(pluginData.Rule.RegularExpression)
                ? RuleProperties.DefaultRegularExpression
                : pluginData.Rule.RegularExpression;

            // Encode the regex match for text files and the raw bytes for binary files; binary content ignores the
            // pattern because a regular expression has no meaning over arbitrary bytes.
            var value = ConfirmTextContent(bytes)
                ? ConvertTextMatch(bytes, pattern)
                : Convert.ToBase64String(bytes);

            // Read the accumulated list from the session, append this call's value, and store it back so every
            // AddFile call in the session stays available to later steps.
            var files = Invoker.Context.SessionParameters.Get(key: $"{NameReference}:Files", defaultValue: "[]");
            var list = JsonSerializer.Deserialize<List<string>>(files.ConvertFromBase64()) ?? [];
            list.Add(value);

            this.AddSessionParameter(@namespace: NameReference, name: "Files", value: JsonSerializer.Serialize(list));

            // Expose the latest value on the response entity so a later step can read it without the session list.
            var response = this.NewPluginResponse();
            response.Entity = new Dictionary<string, object>
            {
                ["File"] = value
            };

            // Return the response; nothing is written to disk.
            return response;
        }

        // Decides whether the file holds text. A byte order mark always means text. Without one, the content is
        // text only when it has no zero byte and the whole file is valid UTF-8, so images, archives, and other
        // binary files keep their exact bytes. Text in a legacy code page, such as Windows-1252 with accented
        // characters, is not valid UTF-8 and is therefore treated as binary.
        private static bool ConfirmTextContent(byte[] bytes)
        {
            // Accept UTF-8 and UTF-16 byte order marks before any content check, because UTF-16 text contains zeros.
            var span = bytes.AsSpan();
            var isUtf8Bom = span.StartsWith(stackalloc byte[] { 0xEF, 0xBB, 0xBF });
            var isUtf16LittleEndianBom = span.StartsWith(stackalloc byte[] { 0xFF, 0xFE });
            var isUtf16BigEndianBom = span.StartsWith(stackalloc byte[] { 0xFE, 0xFF });

            if (isUtf8Bom || isUtf16LittleEndianBom || isUtf16BigEndianBom)
            {
                return true;
            }

            // Treat any zero byte or invalid UTF-8 sequence as binary content.
            return !span.Contains((byte)0) && Utf8.IsValid(span);
        }

        // Decodes text bytes, honoring a byte order mark and defaulting to UTF-8, applies the pattern, and returns
        // the matched text as UTF-8 Base64. A pattern that does not match returns an empty string.
        private static string ConvertTextMatch(byte[] bytes, string pattern)
        {
            // Decode through a reader so UTF-8 and UTF-16 byte order marks select the encoding and are not returned.
            using var stream = new MemoryStream(bytes);
            using var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
            var text = reader.ReadToEnd();

            // Return an empty value for no match so later steps can tell "nothing matched" from encoded content.
            var match = Regex.Match(input: text, pattern);

            return match.Success
                ? match.Value.ConvertToBase64()
                : string.Empty;
        }
    }
}
