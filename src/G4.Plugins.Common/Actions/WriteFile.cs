using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.IO;
using System.Text;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(WriteFile)}.json")]
    public class WriteFile(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Extract the target path, content, and optional processing parameters.
            var path = pluginData.Parameters.Get(key: "Path", defaultValue: string.Empty);
            var content = pluginData.Parameters.Get(key: "Content", defaultValue: string.Empty);
            var encryptionKey = pluginData.Parameters.Get(key: "EncryptionKey", defaultValue: default(string));
            var isBase64 = pluginData.Parameters.ContainsKey(key: "Base64");
            var isRelative = pluginData.Parameters.ContainsKey(key: "Relative");

            // A path without the Relative switch must be fully qualified.
            if (string.IsNullOrWhiteSpace(path) || (!isRelative && !Path.IsPathFullyQualified(path)))
            {
                throw new ArgumentException(
                    message: "The Path parameter must be a full file path unless Relative is specified.",
                    paramName: nameof(pluginData));
            }

            // Resolve relative paths from the process working directory and normalize full paths.
            var filePath = isRelative
                ? Path.GetFullPath(path, Directory.GetCurrentDirectory())
                : Path.GetFullPath(path);

            // Decode Base64 content before applying optional encryption.
            var value = isBase64
                ? content.ConvertFromBase64()
                : content;

            if (!string.IsNullOrEmpty(encryptionKey))
            {
                value = value.Encrypt(key: encryptionKey);
            }

            // Create the parent directory when necessary, then overwrite the target file as UTF-8 text.
            var directoryPath = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(
                path: filePath,
                contents: value,
                encoding: new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

            return this.NewPluginResponse();
        }
    }
}
