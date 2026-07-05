using G4.Extensions;
using G4.Models;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("InvokeDataForEachLoop")]
    [TestCategory("UnitTest")]
    public class InvokeDataForEachLoopTests : TestBase
    {
        [TestMethod(DisplayName = "Verify that the InvokeDataForEachLoop plugin is correctly " +
            "registered and functioning.")]
        public override void NewPluginTest()
        {
            AssertPlugin<InvokeDataForEachLoop>();
        }

        [TestMethod(DisplayName = "Verify that the InvokeDataForEachLoop plugin complies with " +
            "the manifest specifications.")]
        public override void ManifestComplianceTest()
        {
            AssertManifest<InvokeDataForEachLoop>();
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop iterates a JSON array and " +
            "injects a field of each record into the child rules.")]
        public void InvokeDataForEachLoopJsonFieldTest()
        {
            // Arrange: a two-object JSON array; each record's name is stored under a key
            // built from that record's id so both iterations can be verified.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "[{\"id\":\"1\",\"name\":\"Alice\"},{\"id\":\"2\",\"name\":\"Bob\"}]",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:JsonUser{{$ --Field:id}} --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: each record ran once and injected its own field values.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Alice", result.GetParameterValue("JsonUser1", "Session").ConvertFromBase64());
            Assert.AreEqual("Bob", result.GetParameterValue("JsonUser2", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop resolves a JSONPath " +
            "expression against each record via the Path token.")]
        public void InvokeDataForEachLoopJsonPathTest()
        {
            // Arrange: records with a nested object; the child rule reads the nested name
            // through a JSONPath Path token while the id drives the parameter key.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "[{\"id\":\"1\",\"user\":{\"name\":\"Alice\"}},{\"id\":\"2\",\"user\":{\"name\":\"Bob\"}}]",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:PathUser{{$ --Field:id}} --Value:{{$ --Path:$.user.name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the nested value was resolved via JSONPath for each record.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Alice", result.GetParameterValue("PathUser1", "Session").ConvertFromBase64());
            Assert.AreEqual("Bob", result.GetParameterValue("PathUser2", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop injects a simple-array " +
            "value through the Item token.")]
        public void InvokeDataForEachLoopJsonItemTest()
        {
            // Arrange: a simple string array; the Item token supplies both the parameter
            // key suffix and the value so each item is individually observable.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "[\"apple\",\"banana\"]",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:Fruit{{$ --Item}} --Value:{{$ --Item}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: each simple-array item was injected as its scalar text.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("apple", result.GetParameterValue("Fruitapple", "Session").ConvertFromBase64());
            Assert.AreEqual("banana", result.GetParameterValue("Fruitbanana", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop treats repeated same-named " +
            "XML elements as records and injects a child element.")]
        public void InvokeDataForEachLoopXmlFieldTest()
        {
            // Arrange: an XML document whose repeated <user> elements form the record set;
            // each record's name is stored under a key built from its id.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "<users><user><id>1</id><name>Alice</name></user><user><id>2</id><name>Bob</name></user></users>",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:XmlUser{{$ --Field:id}} --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the XML child elements were resolved for each repeated record.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Alice", result.GetParameterValue("XmlUser1", "Session").ConvertFromBase64());
            Assert.AreEqual("Bob", result.GetParameterValue("XmlUser2", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop wraps a single object into " +
            "a one-item collection and iterates it exactly once.")]
        public void InvokeDataForEachLoopSingleObjectTest()
        {
            // Arrange: a lone JSON object rather than an array, which must be wrapped and
            // iterated a single time.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "{\"name\":\"Solo\"}",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:SoloResult --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the single object was iterated once with its field injected. Counting
            // the child rule's performance points confirms exactly one iteration ran.
            var iterations = result
                .GetPerformancePoints()
                .OfType<G4PluginPerformancePointModel>()
                .Count(i => i.Reference.Name == "RegisterParameter");

            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Solo", result.GetParameterValue("SoloResult", "Session").ConvertFromBase64());
            Assert.AreEqual(1, iterations);
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop keeps an unresolved token " +
            "so a nested data loop can resolve it against its own records.")]
        public void InvokeDataForEachLoopNestedKeepsTokenTest()
        {
            // Arrange: an outer loop with a single record exposing 'outer', wrapping an
            // inner data loop whose records expose 'inner'. The grandchild references both
            // fields; the outer must inject 'outer' while keeping the inner-owned token.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "[{\"outer\":\"OuterValue\"}]",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "InvokeDataForEachLoop",
                            "argument": "[{\"inner\":\"1\"},{\"inner\":\"2\"}]",
                            "rules": [
                                {
                                    "$type": "Action",
                                    "pluginName": "RegisterParameter",
                                    "argument": "{{$ --Name:Combo{{$ --Field:inner}} --Value:{{$ --Field:outer}}}}"
                                }
                            ]
                        }
                    ]
                }
                """;

            // Act: run the nested data loops through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the outer value reached the grandchild for each inner record, proving
            // the inner-owned token survived the outer pass and resolved on its own records.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("OuterValue", result.GetParameterValue("Combo1", "Session").ConvertFromBase64());
            Assert.AreEqual("OuterValue", result.GetParameterValue("Combo2", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop decodes a Base64 DataSource " +
            "and iterates the decoded records.")]
        public void InvokeDataForEachLoopBase64DataSourceTest()
        {
            // Arrange: the Base64 switch selects DataSource, which decodes to
            // [{"id":"1","name":"Alice"},{"id":"2","name":"Bob"}] before iteration.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "{{$ --DataSource:W3siaWQiOiIxIiwibmFtZSI6IkFsaWNlIn0seyJpZCI6IjIiLCJuYW1lIjoiQm9iIn1d --Base64}}",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:B64User{{$ --Field:id}} --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the Base64-sourced data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the decoded records were iterated with their fields injected.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Alice", result.GetParameterValue("B64User1", "Session").ConvertFromBase64());
            Assert.AreEqual("Bob", result.GetParameterValue("B64User2", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop reports an exception when " +
            "the Base64 DataSource value is not valid Base64.")]
        public void InvokeDataForEachLoopInvalidBase64Test()
        {
            // Arrange: the Base64 switch is present but the DataSource value cannot be
            // decoded, which must fail the action.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "{{$ --DataSource:not-valid-base64!! --Base64}}",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:ShouldNotSet --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the invalid Base64 value is reported and no child parameter is set.
            Assert.IsNotEmpty(result.GetExceptions());
            Assert.IsEmpty(result.GetParameterValue("ShouldNotSet", "Session"));
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop reports an exception when " +
            "the payload is neither valid JSON nor valid XML.")]
        public void InvokeDataForEachLoopInvalidFormatTest()
        {
            // Arrange: an argument that cannot be parsed as JSON or XML must fail the action.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "this is neither json nor xml",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:ShouldNotSet --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the unsupported format is reported and no child parameter is set.
            Assert.IsNotEmpty(result.GetExceptions());
            Assert.IsEmpty(result.GetParameterValue("ShouldNotSet", "Session"));
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop reads a JSON payload from a " +
            "file path supplied through the Argument.")]
        public void InvokeDataForEachLoopJsonFileTest()
        {
            // Arrange: the Argument is a deployed resource file path rather than inline JSON,
            // so the plugin must read the file before parsing and iterating its records.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "Resources/InvokeDataForEachLoop.json",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:JsonFileUser{{$ --Field:id}} --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the file was read and each record's fields were injected.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Alice", result.GetParameterValue("JsonFileUser1", "Session").ConvertFromBase64());
            Assert.AreEqual("Bob", result.GetParameterValue("JsonFileUser2", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop reads an XML payload from a " +
            "file path supplied through the Argument.")]
        public void InvokeDataForEachLoopXmlFileTest()
        {
            // Arrange: the Argument is a deployed XML resource file path, so the plugin must
            // read the file before treating its repeated elements as records.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "Resources/InvokeDataForEachLoop.xml",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:XmlFileUser{{$ --Field:id}} --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the file was read and each XML record's fields were injected.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Alice", result.GetParameterValue("XmlFileUser1", "Session").ConvertFromBase64());
            Assert.AreEqual("Bob", result.GetParameterValue("XmlFileUser2", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop reads a Base64 payload from a " +
            "DataSource file path and decodes it before iterating.")]
        public void InvokeDataForEachLoopBase64FileTest()
        {
            // Arrange: the Base64 switch selects a DataSource that is a file path whose contents
            // are Base64, so the plugin must read the file and decode it before iterating.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "{{$ --DataSource:Resources/InvokeDataForEachLoop.b64 --Base64}}",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "RegisterParameter",
                            "argument": "{{$ --Name:B64FileUser{{$ --Field:id}} --Value:{{$ --Field:name}}}}"
                        }
                    ]
                }
                """;

            // Act: run the Base64-sourced data loop through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the file contents were decoded and each record's fields were injected.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Alice", result.GetParameterValue("B64FileUser1", "Session").ConvertFromBase64());
            Assert.AreEqual("Bob", result.GetParameterValue("B64FileUser2", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop injects a record's sub-array " +
            "as the argument of a nested data loop that iterates it.")]
        public void InvokeDataForEachLoopNestedDataDerivedTest()
        {
            // Arrange: each outer record carries a 'members' sub-array. The outer loop injects
            // that sub-array as minified JSON into the inner loop's argument and injects 'team'
            // into the grandchild, while keeping the inner-owned 'name' token for the inner loop.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "[{\"team\":\"Red\",\"members\":[{\"name\":\"Al\"},{\"name\":\"Bo\"}]},{\"team\":\"Blue\",\"members\":[{\"name\":\"Cy\"}]}]",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "InvokeDataForEachLoop",
                            "argument": "{{$ --Field:members}}",
                            "rules": [
                                {
                                    "$type": "Action",
                                    "pluginName": "RegisterParameter",
                                    "argument": "{{$ --Name:Member{{$ --Field:name}} --Value:{{$ --Field:team}}}}"
                                }
                            ]
                        }
                    ]
                }
                """;

            // Act: run the nested data loops through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: each member of each team was iterated with the outer team injected and the
            // inner name resolved by the inner loop.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("Red", result.GetParameterValue("MemberAl", "Session").ConvertFromBase64());
            Assert.AreEqual("Red", result.GetParameterValue("MemberBo", "Session").ConvertFromBase64());
            Assert.AreEqual("Blue", result.GetParameterValue("MemberCy", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that three nested InvokeDataForEachLoop levels each " +
            "resolve their own token and keep the deeper ones.")]
        public void InvokeDataForEachLoopTripleNestedTest()
        {
            // Arrange: three nested loops each expose a distinct field (a, b, c). The innermost
            // rule references all three; each level resolves its own field and passes the deeper
            // tokens through untouched until the innermost loop resolves them.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "[{\"a\":\"A1\"}]",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "InvokeDataForEachLoop",
                            "argument": "[{\"b\":\"B1\"}]",
                            "rules": [
                                {
                                    "$type": "Action",
                                    "pluginName": "InvokeDataForEachLoop",
                                    "argument": "[{\"c\":\"C1\"}]",
                                    "rules": [
                                        {
                                            "$type": "Action",
                                            "pluginName": "RegisterParameter",
                                            "argument": "{{$ --Name:Triple --Value:{{$ --Field:a}}{{$ --Field:b}}{{$ --Field:c}}}}"
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                }
                """;

            // Act: run the triple-nested data loops through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: the value was assembled progressively across the three nested levels.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("A1B1C1", result.GetParameterValue("Triple", "Session").ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that InvokeDataForEachLoop injects a record's XML subtree " +
            "as the argument of a nested XML data loop that iterates it.")]
        public void InvokeDataForEachLoopXmlNestedTest()
        {
            // Arrange: each outer <group> carries a <label> and an <items> subtree. The outer
            // loop injects the <items> element as minified XML into the inner loop's argument and
            // injects 'label' into the grandchild, keeping the inner-owned 'name' token.
            const string ruleJson =
                """
                {
                    "$type": "Action",
                    "pluginName": "InvokeDataForEachLoop",
                    "argument": "<groups><group><label>G1</label><items><item><name>X</name></item></items></group><group><label>G2</label><items><item><name>Y</name></item></items></group></groups>",
                    "rules": [
                        {
                            "$type": "Action",
                            "pluginName": "InvokeDataForEachLoop",
                            "argument": "{{$ --Field:items}}",
                            "rules": [
                                {
                                    "$type": "Action",
                                    "pluginName": "RegisterParameter",
                                    "argument": "{{$ --Name:Xml{{$ --Field:name}} --Value:{{$ --Field:label}}}}"
                                }
                            ]
                        }
                    ]
                }
                """;

            // Act: run the nested XML data loops through the full automation pipeline.
            var result = Invoke([Deserialize(ruleJson)]);

            // Assert: each item's name became a key and carried its group's label as the value.
            Assert.IsEmpty(result.GetExceptions());
            Assert.AreEqual("G1", result.GetParameterValue("XmlX", "Session").ConvertFromBase64());
            Assert.AreEqual("G2", result.GetParameterValue("XmlY", "Session").ConvertFromBase64());
        }

        // Deserializes a rule JSON string into a rule model using the shared test options.
        private static ActionRuleModel Deserialize(string ruleJson)
        {
            return JsonSerializer.Deserialize<ActionRuleModel>(ruleJson, JsonOptions);
        }
    }
}
