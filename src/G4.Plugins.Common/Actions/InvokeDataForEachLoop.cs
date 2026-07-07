using G4.Attributes;
using G4.Extensions;
using G4.Models;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace G4.Plugins.Common.Actions
{
    [G4Plugin(
        assembly: "G4.Plugins.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null",
        manifest: $"G4.Plugins.Common.Actions.Manifests.{nameof(InvokeDataForEachLoop)}.json")]
    public class InvokeDataForEachLoop(G4PluginSetupModel pluginSetup) : PluginBase(pluginSetup)
    {
        // Matches an innermost G4 CLI token, one that contains neither a nested token
        // opener nor an early terminator. Matching the innermost token first lets an
        // outer envelope such as "{{$ --Name:Id --Value:{{$ --Field:Id}}}}" keep its own
        // switches while the embedded data token is resolved against the current record.
        private static readonly Regex s_dataToken = new(
            pattern: @"\{\{\$(?:(?!\{\{\$)(?!\}\}).)*\}\}",
            options: RegexOptions.Compiled);

        // Serialization options that mirror the engine's rule contract (camelCase
        // property names with case-insensitive binding) so a rule can be round-tripped
        // through JSON without losing its definition.
        private static readonly JsonSerializerOptions s_ruleOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        protected override PluginResponseModel OnSend(PluginDataModel pluginData)
        {
            // Disable the invocation of the nested rules initially so the engine does not
            // execute them before the loop injects the per-record data values.
            pluginData.Rule.SetInvokeRules(invoke: false);

            // Resolve the raw payload from either the Argument or the DataSource parameter,
            // decoding it from Base64 when the Base64 switch is present.
            var data = GetData(pluginData);

            // Normalize the payload into a uniform sequence of records, wrapping a single
            // object or value into a one-item collection for consistent iteration.
            var records = NewRecords(data);

            // Capture the nested rule templates once; every record produces a fresh clone
            // of these templates with its own resolved token values.
            var templates = pluginData.Rule.Rules?.ToArray() ?? [];
            var iteration = 0;

            // Execute the nested rules once per record in the normalized collection.
            foreach (var record in records)
            {
                // Invoke the cloned rules for the current record and advance the counter.
                InvokeIteration(plugin: this, pluginData, record, iteration, templates);
                iteration++;
            }

            // Create and return a new plugin response indicating successful execution.
            return this.NewPluginResponse();
        }

        // Resolves the raw data payload for the loop, honoring the Base64 switch and
        // supporting both inline content and file paths for either source.
        private static string GetData(PluginDataModel pluginData)
        {
            // The Base64 switch selects the DataSource parameter as the payload origin and
            // signals that the resolved content must be decoded before it is parsed.
            var isBase64 = pluginData.Parameters.ContainsKey(key: "Base64");

            // Use the DataSource parameter in Base64 mode; otherwise use the positional
            // Argument as the raw JSON or XML payload.
            var source = isBase64
                ? pluginData.Parameters.Get(key: "DataSource", defaultValue: string.Empty)
                : pluginData.Rule.Argument;

            // Treat an existing file path as a reference to its contents; otherwise the
            // source itself is the inline payload (or Base64 text) to process.
            var content = File.Exists(source)
                ? File.ReadAllText(source)
                : source;

            // Decode the Base64 content when requested; an invalid Base64 value throws and
            // surfaces the failure to the caller.
            return isBase64
                ? content.ConvertFromBase64()
                : content;
        }

        // Normalizes a raw JSON or XML payload into a uniform sequence of records,
        // throwing when the content matches neither supported format.
        private static IEnumerable<object> NewRecords(string data)
        {
            // A valid JSON document is projected into its element sequence, wrapping a single
            // object or value as a one-item array.
            if (data.AssertJson())
            {
                return NewJsonRecords(data);
            }

            // A valid XML document uses the same array-or-single normalization.
            if (data.AssertXml())
            {
                return NewXmlRecords(data);
            }

            // Neither JSON nor XML could be parsed from the payload.
            throw new ArgumentException(
                message: "The data source is neither valid JSON nor valid XML.",
                paramName: nameof(data));
        }

        // Parses a JSON payload into records, projecting an array into its items and wrapping
        // any single object or value into a one-item collection.
        private static IEnumerable<object> NewJsonRecords(string data)
        {
            // Parse the payload into a JSON node graph.
            var node = JsonNode.Parse(data);

            // An array iterates over its items; anything else is treated as a single record
            // so lone objects and values still run exactly one iteration.
            return node is JsonArray array
                ? array.Cast<object>().ToArray()
                : [node];
        }

        // Parses an XML payload into records, treating repeated same-named root children as an
        // array of objects and any other shape as a single wrapped object.
        private static IEnumerable<object> NewXmlRecords(string data)
        {
            // Parse the payload into an XML document and inspect its root element.
            var root = XDocument.Parse(data).Root;
            var children = root.Elements().ToArray();

            // Repeated same-named children represent an array of objects; otherwise the root
            // element itself is the single object to iterate exactly once.
            var isArray = children.Length > 0
                && children.All(i => i.Name == children[0].Name);

            return isArray
                ? children.Cast<object>().ToArray()
                : [root];
        }

        // Invokes the nested rule templates for a single record, cloning each template with
        // its tokens resolved against that record before invocation.
        private static void InvokeIteration(
            PluginBase plugin,
            PluginDataModel pluginData,
            object record,
            int iteration,
            G4RuleModelBase[] templates)
        {
            // Build the concrete rules for this iteration from token-resolved clones.
            var rules = new List<G4RuleModelBase>();

            foreach (var template in templates)
            {
                // Serialize the template, inject the record values into its tokens, then
                // deserialize the result back into an independent rule instance.
                var ruleJson = JsonSerializer.Serialize(template, template.GetType(), s_ruleOptions);
                var resolvedJson = ResolveTokens(plugin, ruleJson, record);
                var rule = (G4RuleModelBase)JsonSerializer.Deserialize(resolvedJson, template.GetType(), s_ruleOptions);

                // Assign the current iteration and element context to the cloned rule.
                rule.Iteration = iteration;
                rule.Reference.Iteration = iteration;
                rule.Context[RuleProperties.WebElement] = pluginData.Element;
                rule.Context[RuleProperties.HtmlNode] = pluginData.HtmlNode;

                // Re-link any child rules to the cloned rule's reference so nested
                // hierarchies resolve their parents correctly.
                foreach (var childRule in rule.Rules ?? [])
                {
                    childRule.Reference.ParentReference = rule.Reference;
                }

                // Enable the invocation of the cloned rule now that its context is set.
                rule.SetInvokeRules(invoke: true);
                rules.Add(rule);
            }

            // Invoke the configured rules for this record using the plugin's invoker.
            plugin.Invoker.Invoke([.. rules]);
        }

        // Replaces the innermost data tokens in the serialized rule with values drawn from
        // the current record, leaving unrelated tokens and unmatched fields intact.
        private static string ResolveTokens(PluginBase plugin, string ruleJson, object record)
        {
            return s_dataToken.Replace(ruleJson, match =>
            {
                // Parse the token switches; only Field, Path, and Item tokens belong to
                // this plugin, so any other CLI envelope is preserved untouched.
                var arguments = plugin.CliFactory.ConvertToDictionary(match.Value);

                // Resolve the token against the record. A resolved value is JSON-escaped for
                // safe insertion, while a null result keeps the original token so a nested
                // data loop can resolve it against its own record.
                var value = ResolveToken(arguments, record);

                return value is null
                    ? match.Value
                    : ConvertToJsonText(value);
            });
        }

        // Resolves a single data token against the current record, returning the resolved
        // value or null when the token is not owned or its member is absent (keep the token).
        private static string ResolveToken(IDictionary<string, string> arguments, object record)
        {
            // Select the resolver for the data switch this token carries; a token without a
            // Field, Path, or Item switch is not owned by this plugin and is left untouched.
            Func<(bool Found, string Value)> resolver = null;

            if (GetSwitch(arguments, key: "Field") is string field)
            {
                resolver = () => ResolveField(record, field);
            }
            else if (GetSwitch(arguments, key: "Path") is string path)
            {
                resolver = () => ResolvePath(record, path);
            }
            else if (GetSwitch(arguments, key: "Item") != null)
            {
                resolver = () => (Found: true, Value: ResolveItem(record));
            }

            // A token this plugin does not own is preserved for the caller to keep as-is.
            if (resolver is null)
            {
                return null;
            }

            try
            {
                // A missing member keeps the token (null); a resolved member injects its
                // value, substituting an empty string when that value is null.
                var (found, raw) = resolver();

                return found
                    ? raw ?? string.Empty
                    : null;
            }
            catch
            {
                // A member that exists but throws while resolving injects an empty string.
                return string.Empty;
            }
        }

        // Resolves a named field of the current record, matching a JSON member or an XML
        // child element (then attribute) by name.
        private static (bool Found, string Value) ResolveField(object record, string name)
        {
            // XML records resolve a field by child element first, then by attribute.
            if (record is XElement element)
            {
                var child = element.Elements().FirstOrDefault(i => i.Name.LocalName == name);

                if (child != null)
                {
                    return (Found: true, Value: ConvertElementToString(child));
                }

                var attribute = element.Attributes().FirstOrDefault(i => i.Name.LocalName == name);

                return attribute != null
                    ? (Found: true, Value: attribute.Value)
                    : (Found: false, Value: null);
            }

            // JSON records resolve a field by object member name.
            return record is JsonObject obj && obj.TryGetPropertyValue(name, out var member)
                ? (Found: true, Value: ConvertNodeToString(member))
                : (Found: false, Value: null);
        }

        // Resolves a path expression against the current record, using JSONPath for JSON
        // records and XPath for XML records.
        private static (bool Found, string Value) ResolvePath(object record, string expression)
        {
            // XML records evaluate the expression as XPath against the current element.
            if (record is XElement element)
            {
                return ResolveXmlPath(element, expression);
            }

            // JSON records evaluate the expression as JSONPath through Newtonsoft's JToken,
            // the only place this plugin relies on the Newtonsoft library.
            var token = Newtonsoft.Json.Linq.JToken.Parse((record as JsonNode)?.ToJsonString() ?? "null");
            var selected = token.SelectToken(expression);

            // No match keeps the token so a nested data loop can resolve it later.
            if (selected is null)
            {
                return (Found: false, Value: null);
            }

            // A scalar match injects its value; an object or array match injects minified JSON.
            return selected is Newtonsoft.Json.Linq.JValue value
                ? (Found: true, Value: value.Value?.ToString() ?? string.Empty)
                : (Found: true, Value: selected.ToString(Newtonsoft.Json.Formatting.None));
        }

        // Resolves an XPath expression against the current XML element.
        //
        // XPathEvaluate is used rather than XPathSelectElement because an XPath expression
        // may target more than a single element: it can select an attribute (@id), or invoke
        // an XPath function such as count() or string() that returns a scalar. XPathSelectElement
        // only ever returns the first matching XElement (or null) and cannot express those
        // cases, which would make XPath weaker than the JSONPath support on the JSON side.
        private static (bool Found, string Value) ResolveXmlPath(XElement element, string expression)
        {
            // Evaluate the expression; a node-set returns an enumerable, while XPath functions
            // such as count() or string() return a scalar directly.
            var evaluation = element.XPathEvaluate(expression);

            // A scalar result injects its invariant string form.
            if (evaluation is not IEnumerable<object> nodes)
            {
                return (Found: true, Value: Convert.ToString(evaluation, CultureInfo.InvariantCulture));
            }

            // A node-set yields the first matched node, or null when nothing matched.
            var node = nodes.FirstOrDefault();

            // No match keeps the token so a nested data loop can resolve it later.
            if (node is null)
            {
                return (Found: false, Value: null);
            }

            // An element injects its text or minified XML.
            if (node is XElement matchedElement)
            {
                return (Found: true, Value: ConvertElementToString(matchedElement));
            }

            // An attribute injects its value.
            if (node is XAttribute attribute)
            {
                return (Found: true, Value: attribute.Value);
            }

            // Any other node type (text, comment) injects its string form.
            return (Found: true, Value: $"{node}");
        }

        // Resolves the current record itself to its string value, minifying complex JSON
        // nodes or XML elements and returning the text of a simple-array value directly.
        private static string ResolveItem(object record)
        {
            // XML items return element text directly and complex elements as minified XML.
            if (record is XElement element)
            {
                return element.HasElements || element.HasAttributes
                    ? element.ToString(SaveOptions.DisableFormatting)
                    : element.Value;
            }

            // JSON items return scalar text directly and complex nodes as minified JSON.
            return record is JsonValue value
                ? value.ToString()
                : (record as JsonNode)?.ToJsonString() ?? string.Empty;
        }

        // Converts a JSON member to its injected string form: an empty string for null, the
        // scalar text for values, and minified JSON for objects and arrays.
        private static string ConvertNodeToString(JsonNode node)
        {
            // A JSON null member injects an empty string rather than a "null" literal.
            if (node is null)
            {
                return string.Empty;
            }

            // Scalars inject their text; objects and arrays inject their minified JSON.
            return node is JsonValue value
                ? value.ToString()
                : node.ToJsonString();
        }

        // Converts an XML element to its injected string form: its text for a leaf element
        // or minified XML for an element that has child elements.
        private static string ConvertElementToString(XElement element)
        {
            return element.HasElements
                ? element.ToString(SaveOptions.DisableFormatting)
                : element.Value;
        }

        // Converts a resolved value into text that is safe to insert inside the serialized
        // rule's existing string literals by serializing it as JSON and stripping the
        // surrounding quotes, leaving the escaped inner content.
        private static string ConvertToJsonText(string value)
        {
            var serialized = JsonSerializer.Serialize(value);
            return serialized[1..^1];
        }

        // Gets the value of a CLI switch by name using a case-insensitive comparison, or null
        // when the switch is absent (an empty string for a valueless switch such as --Item).
        private static string GetSwitch(IDictionary<string, string> arguments, string key)
        {
            var match = arguments.Keys.FirstOrDefault(i => i.Equals(key, StringComparison.OrdinalIgnoreCase));

            return match is null
                ? null
                : arguments[match];
        }
    }
}
