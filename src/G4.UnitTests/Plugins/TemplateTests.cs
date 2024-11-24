using G4.Api;
using G4.Attributes;
using G4.Models;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;
using System.Text.Json;

namespace G4.UnitTests.Plugins
{
    [TestClass]
    [TestCategory("Template")]
    [TestCategory("UnitTest")]
    public class TemplateTests : TestBase
    {
        [TestMethod]
        public void Test()
        {
            var json = File.ReadAllText($"Resources/LoginTemplate.txt").Trim();
            var manifest = JsonSerializer.Deserialize<G4PluginAttribute>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var client = new G4Client();
            var templates = client.Templates.GetTemplates();
            client.Templates.AddTemplate(manifest);
            templates = client.Templates.GetTemplates();

            var rule = new ActionRuleModel
            {
                PluginName = manifest.Key,
                Argument = "{{$ --Username:Foo --Password:Bar}}"
            };

            var ruleJson = JsonSerializer.Serialize(rule);

            var a = Invoke(ruleJson);
        }
    }
}
