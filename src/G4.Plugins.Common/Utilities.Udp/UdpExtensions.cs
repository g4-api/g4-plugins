using G4.Extensions;
using G4.Models;

using Newtonsoft.Json.Linq;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace G4.Plugins.Common.Utilities.Udp
{
    /// <summary>
    /// Provides the argument resolution, payload conversion, and response shaping shared by the UDP plugins.
    /// </summary>
    /// <remarks>
    /// Every UDP plugin reads its arguments and publishes its outputs through these members, so one argument
    /// contract applies to the whole suite and each plugin stays focused on its own socket operation. A malformed
    /// argument fails the step with a message that names the argument, because a silent fallback sends a datagram
    /// to the wrong place.
    /// </remarks>
    internal static class UdpExtensions
    {
        #region *** Constants    ***
        /// <summary>
        /// Selects Base64 text as the form of a payload or of a received datagram.
        /// </summary>
        public const string Base64Format = "Base64";

        /// <summary>
        /// Specifies the wait for datagrams, in milliseconds, when the step names no timeout.
        /// </summary>
        public const int DefaultTimeoutMilliseconds = 5000;

        /// <summary>
        /// Selects hexadecimal text as the form of a payload or of a received datagram.
        /// </summary>
        public const string HexFormat = "Hex";

        /// <summary>
        /// Specifies the largest payload, in bytes, one UDP datagram carries over IPv4.
        /// </summary>
        public const int MaximumPayloadLength = 65507;

        /// <summary>
        /// Specifies the highest port number a socket accepts.
        /// </summary>
        public const int MaximumPort = 65535;

        /// <summary>
        /// Selects plain text, in the encoding of the step, as the form of a payload or of a received datagram.
        /// </summary>
        public const string TextFormat = "Text";

        // Bounds every regular expression a step supplies, so a pattern that backtracks cannot hang the flow.
        private const int PatternTimeoutSeconds = 30;
        #endregion

        #region *** Methods      ***
        extension(PluginDataModel pluginData)
        {
            /// <summary>
            /// Creates the outputs that describe a set of received datagrams.
            /// </summary>
            /// <remarks>
            /// The first datagram is published as text under <paramref name="name"/>, after the <c>OnElement</c> and
            /// <c>RegularExpression</c> properties of the rule refine it. Every datagram is published, unrefined, in
            /// a JSON array under the plural name. The <c>ResponseFormat</c> and <c>Encoding</c> arguments select how
            /// the bytes become text.
            /// </remarks>
            /// <param name="datagrams">The datagrams to publish, oldest first; may be empty.</param>
            /// <param name="name">The singular output name, such as <c>Response</c> or <c>Message</c>.</param>
            /// <returns>The output names and their text values.</returns>
            public IDictionary<string, string> NewDatagramOutputs(IList<UdpDatagramModel> datagrams, string name)
            {
                // Resolve how bytes become text once, so the first datagram and the list use the same form.
                var format = pluginData.ResolveFormat(name: "ResponseFormat");
                var encoding = pluginData.ResolveEncoding();
                var first = datagrams.FirstOrDefault();

                // Refine only the first datagram; the list keeps every datagram as it arrived.
                var content = first is null
                    ? string.Empty
                    : ResolveContent(content: ConvertToText(data: first.Data, format, encoding), rule: pluginData.Rule);

                // Publish the refined first datagram, the count, the full list, and the sender of the first
                // datagram, which a flow uses as the destination of a reply.
                return new Dictionary<string, string>
                {
                    [name] = content,
                    [$"{name}Count"] = datagrams.Count.ToString(CultureInfo.InvariantCulture),
                    [$"{name}s"] = ConvertToJson(datagrams, format, encoding),
                    ["RemoteAddress"] = first?.RemoteAddress ?? string.Empty,
                    ["RemotePort"] = first?.RemotePort.ToString(CultureInfo.InvariantCulture) ?? string.Empty
                };
            }

            /// <summary>
            /// Resolves an optional IP address argument, such as <c>LocalAddress</c> or <c>MulticastGroup</c>.
            /// </summary>
            /// <param name="name">The argument name.</param>
            /// <returns>The address, or null when the step does not set the argument.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the argument is set and is not an IP address.
            /// </exception>
            public IPAddress ResolveAddress(string name)
            {
                // Report a missing argument as null so each plugin applies its own default.
                var value = pluginData.Parameters.Get(key: name, defaultValue: string.Empty);

                if (string.IsNullOrWhiteSpace(value))
                {
                    return null;
                }

                // Reject text that is not an address, because a host name cannot be bound or joined.
                if (!IPAddress.TryParse(value.Trim(), out var address))
                {
                    var message = $"The '{name}' argument must be an IP address.";
                    throw new InvalidOperationException(message);
                }

                return address;
            }

            /// <summary>
            /// Resolves the text encoding from the <c>Encoding</c> argument.
            /// </summary>
            /// <remarks>
            /// The encoding turns a text payload into bytes and received bytes into text. The common names
            /// <c>UTF8</c>, <c>ASCII</c>, <c>Unicode</c>, <c>UTF16</c>, <c>UTF32</c>, and <c>Latin1</c> are accepted
            /// with or without a hyphen; any other value is passed to <see cref="Encoding.GetEncoding(string)"/>.
            /// </remarks>
            /// <returns>The encoding; UTF-8 when the step does not set the argument.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the argument names an encoding the runtime does not know.
            /// </exception>
            public Encoding ResolveEncoding()
            {
                // Compare without hyphens, underscores, and case, so "utf-8" and "UTF8" select the same encoding.
                var value = pluginData.Parameters.Get(key: "Encoding", defaultValue: "UTF8").Trim();
                var name = value
                    .Replace(oldValue: "-", newValue: string.Empty)
                    .Replace(oldValue: "_", newValue: string.Empty)
                    .ToUpperInvariant();

                // Select a built-in encoding by its common name before asking the runtime for a code page name.
                return name switch
                {
                    "" or "UTF8" => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false),
                    "ASCII" or "USASCII" => Encoding.ASCII,
                    "UNICODE" or "UTF16" or "UTF16LE" => Encoding.Unicode,
                    "UTF32" => Encoding.UTF32,
                    "LATIN1" or "ISO88591" => Encoding.Latin1,
                    _ => GetEncoding(name: value)
                };
            }

            /// <summary>
            /// Resolves a format argument, such as <c>Format</c> or <c>ResponseFormat</c>.
            /// </summary>
            /// <param name="name">The argument name.</param>
            /// <returns>
            /// <see cref="TextFormat"/>, <see cref="HexFormat"/>, or <see cref="Base64Format"/>; the text format when
            /// the step does not set the argument.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the argument holds any other value.
            /// </exception>
            public string ResolveFormat(string name)
            {
                // Match without case and return the canonical constant, so later comparisons are exact.
                var value = pluginData.Parameters.Get(key: name, defaultValue: TextFormat).Trim();
                string[] formats = [TextFormat, HexFormat, Base64Format];
                var format = Array.Find(formats, i => i.Equals(value, StringComparison.OrdinalIgnoreCase));

                if (format is null)
                {
                    var message = $"The '{name}' argument must be '{TextFormat}', '{HexFormat}', or '{Base64Format}'.";
                    throw new InvalidOperationException(message);
                }

                return format;
            }

            /// <summary>
            /// Resolves a whole-number argument that cannot be negative, such as <c>Count</c> or <c>Retries</c>.
            /// </summary>
            /// <param name="name">The argument name.</param>
            /// <param name="defaultValue">The value returned when the step does not set the argument.</param>
            /// <returns>The number.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the argument is set and is not a whole number of 0 or more.
            /// </exception>
            public int ResolveInteger(string name, int defaultValue)
            {
                // Report a missing argument as the default of the calling plugin.
                var value = pluginData.Parameters.Get(key: name, defaultValue: string.Empty);

                if (string.IsNullOrWhiteSpace(value))
                {
                    return defaultValue;
                }

                // Parse with the invariant culture, because step arguments arrive as text from any locale.
                var culture = CultureInfo.InvariantCulture;
                var isNumber = int.TryParse(value.Trim(), NumberStyles.None, culture, out var number);

                if (!isNumber)
                {
                    var message = $"The '{name}' argument must be a whole number of 0 or more.";
                    throw new InvalidOperationException(message);
                }

                return number;
            }

            /// <summary>
            /// Resolves the listener name of StartUdpListener and StopUdpListener from the <c>Name</c> argument.
            /// </summary>
            /// <remarks>
            /// A missing, empty, or white-space name selects <see cref="UdpListenerRegistry.DefaultName"/>, so a step
            /// can never start a listener under a name no other step is able to reach.
            /// </remarks>
            /// <returns>The trimmed listener name.</returns>
            public string ResolveListenerName()
            {
                // Trim the name first, because an argument of spaces names no listener.
                var name = pluginData.Parameters.Get(key: "Name", defaultValue: string.Empty).Trim();

                return string.IsNullOrEmpty(name)
                    ? UdpListenerRegistry.DefaultName
                    : name;
            }

            /// <summary>
            /// Resolves the payload of a datagram from the <c>Message</c> or <c>MessageFile</c> argument.
            /// </summary>
            /// <remarks>
            /// <c>Message</c> wins when both are set and is converted through the <c>Format</c> and <c>Encoding</c>
            /// arguments. <c>MessageFile</c> names a file whose bytes are sent unchanged. The sequences <c> --</c> and
            /// <c>}}</c> end an inline argument value, so a payload that contains them travels as Base64, as
            /// hexadecimal text, or in a file.
            /// </remarks>
            /// <returns>The bytes to send.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the step sets neither argument, when <c>Message</c> does not match its format, or when the
            /// payload is larger than <see cref="MaximumPayloadLength"/> bytes.
            /// </exception>
            /// <exception cref="FileNotFoundException">
            /// Thrown when <c>MessageFile</c> points to a missing file.
            /// </exception>
            public byte[] ResolvePayload()
            {
                // Read both sources before choosing, so the failure for a missing payload names both arguments.
                var inlineMessage = pluginData.Parameters.Get(key: "Message", defaultValue: string.Empty);
                var file = pluginData.Parameters.Get(key: "MessageFile", defaultValue: string.Empty);
                var isInlineMissing = string.IsNullOrEmpty(inlineMessage);
                var isFileMissing = string.IsNullOrWhiteSpace(file);

                if (isInlineMissing && isFileMissing)
                {
                    throw new InvalidOperationException("Set the 'Message' or the 'MessageFile' argument.");
                }

                // Prefer the inline text so a step can override a shared payload file; file bytes are sent as they are.
                var payload = isInlineMissing
                    ? File.ReadAllBytes(path: file.Trim())
                    : ConvertToBytes(
                        value: inlineMessage,
                        format: pluginData.ResolveFormat(name: "Format"),
                        encoding: pluginData.ResolveEncoding());

                // Reject a payload no single datagram carries, before the socket reports a less clear error.
                if (payload.Length > MaximumPayloadLength)
                {
                    var message = $"The payload is {payload.Length} bytes; one UDP datagram carries up to " +
                        $"{MaximumPayloadLength} bytes.";
                    throw new InvalidOperationException(message);
                }

                return payload;
            }

            /// <summary>
            /// Resolves a port argument, such as <c>Port</c>, <c>LocalPort</c>, or <c>RemotePort</c>.
            /// </summary>
            /// <param name="name">The argument name.</param>
            /// <param name="defaultValue">The value returned when the step does not set the argument.</param>
            /// <returns>The port, from 0 to <see cref="MaximumPort"/>.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the argument is set and is not a whole number in the port range.
            /// </exception>
            public int ResolvePort(string name, int defaultValue)
            {
                // Read the number first, then apply the upper bound that only ports have.
                var port = pluginData.ResolveInteger(name, defaultValue);

                if (port > MaximumPort)
                {
                    var message = $"The '{name}' argument must be a port from 0 to {MaximumPort}.";
                    throw new InvalidOperationException(message);
                }

                return port;
            }

            /// <summary>
            /// Resolves a mandatory text argument and trims it.
            /// </summary>
            /// <param name="name">The argument name.</param>
            /// <returns>The trimmed value.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown when the argument is missing or holds only white space.
            /// </exception>
            public string ResolveRequired(string name)
            {
                // Read the argument and reject an empty value so the failure names the missing argument.
                var value = pluginData.Parameters.Get(key: name, defaultValue: string.Empty);

                if (string.IsNullOrWhiteSpace(value))
                {
                    var message = $"The '{name}' argument is required.";
                    throw new InvalidOperationException(message);
                }

                return value.Trim();
            }

            /// <summary>
            /// Resolves the wait for datagrams from the <c>Timeout</c> argument.
            /// </summary>
            /// <remarks>
            /// The value is a number of milliseconds or a time span such as <c>00:00:05</c>. A missing or malformed
            /// value selects <see cref="DefaultTimeoutMilliseconds"/>.
            /// </remarks>
            /// <returns>The timeout.</returns>
            public TimeSpan ResolveTimeout()
            {
                // Accept both G4 time forms, so the argument reads like the timeout of every other G4 action.
                var defaultValue = TimeSpan.FromMilliseconds(DefaultTimeoutMilliseconds);
                var value = pluginData.Parameters.Get(key: "Timeout", defaultValue: string.Empty);

                return string.IsNullOrWhiteSpace(value)
                    ? defaultValue
                    : value.Trim().ConvertToTimeSpan(defaultValue);
            }

            /// <summary>
            /// Tests whether the step requests one of its switches, such as <c>WaitForResponse</c> or <c>NoEntity</c>.
            /// </summary>
            /// <param name="name">The switch name.</param>
            /// <returns><c>true</c> when the switch is present; otherwise <c>false</c>.</returns>
            public bool TestSwitch(string name)
            {
                // A switch carries no value; its presence alone turns it on.
                return pluginData.Parameters.ContainsKey(key: name);
            }
        }

        extension(PluginBase plugin)
        {
            /// <summary>
            /// Creates the plugin response and publishes the outputs as session parameters and, unless suppressed, as
            /// the response entity.
            /// </summary>
            /// <remarks>
            /// Each output is stored as the session parameter <c>{nameReference}:{name}</c>, Base64-encoded by
            /// <c>AddSessionParameter</c>. The entity carries the same names, unqualified and in plain text, for ETL
            /// and direct data transfer; <paramref name="noEntity"/> omits it.
            /// </remarks>
            /// <param name="nameReference">The plugin key used as the session parameter namespace.</param>
            /// <param name="outputs">The output names and their text values.</param>
            /// <param name="noEntity"><c>true</c> to omit the response entity.</param>
            /// <returns>The plugin response.</returns>
            public PluginResponseModel NewUdpResponse(
                string nameReference,
                IDictionary<string, string> outputs,
                bool noEntity)
            {
                // Publish every output to the session so later steps read it through the namespaced parameter.
                foreach (var output in outputs)
                {
                    plugin.AddSessionParameter(@namespace: nameReference, name: output.Key, value: output.Value);
                }

                // Create the response and attach the entity unless the step suppressed it.
                var response = plugin.NewPluginResponse();

                if (!noEntity)
                {
                    response.Entity = outputs.ToDictionary(i => i.Key, i => (object)i.Value);
                }

                return response;
            }
        }

        /// <summary>
        /// Converts the text of a <c>Message</c> argument into the bytes of a datagram.
        /// </summary>
        /// <remarks>
        /// Hexadecimal text may separate its bytes with spaces, commas, colons, or hyphens and may carry <c>0x</c>
        /// prefixes, so a packet can be pasted the way a protocol document prints it.
        /// </remarks>
        /// <param name="value">The argument text.</param>
        /// <param name="format">The form of the text: one of the format constants of this class.</param>
        /// <param name="encoding">The encoding of a text payload.</param>
        /// <returns>The payload bytes.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the text is not valid for its format.
        /// </exception>
        public static byte[] ConvertToBytes(string value, string format, Encoding encoding)
        {
            // Encode plain text directly; the other formats describe bytes and are decoded below.
            if (format == TextFormat)
            {
                return encoding.GetBytes(value);
            }

            try
            {
                // Decode the bytes the text describes, after removing the separators hexadecimal text may carry.
                return format == HexFormat
                    ? Convert.FromHexString(RemoveHexSeparators(value))
                    : Convert.FromBase64String(value.Trim());
            }
            catch (Exception exception)
            {
                // Name the argument and the expected form, because the runtime message names neither.
                var message = $"The 'Message' argument is not valid {format} text.";
                throw new InvalidOperationException(message, exception);
            }
        }

        /// <summary>
        /// Converts received datagrams into the JSON array a flow reads when it expects more than one datagram.
        /// </summary>
        /// <param name="datagrams">The datagrams, oldest first.</param>
        /// <param name="format">The form of each payload: one of the format constants of this class.</param>
        /// <param name="encoding">The encoding of a text payload.</param>
        /// <returns>
        /// A JSON array with one object per datagram, holding <c>Data</c>, <c>Length</c>, <c>ReceivedAt</c>,
        /// <c>RemoteAddress</c>, and <c>RemotePort</c>.
        /// </returns>
        public static string ConvertToJson(IEnumerable<UdpDatagramModel> datagrams, string format, Encoding encoding)
        {
            // Map each datagram to the fields a flow reports; the arrival time is ISO 8601 in UTC.
            var items = datagrams.Select(i => new Dictionary<string, object>
            {
                ["Data"] = ConvertToText(data: i.Data, format, encoding),
                ["Length"] = i.Data.Length,
                ["ReceivedAt"] = i.ReceivedAt.ToString(format: "O", CultureInfo.InvariantCulture),
                ["RemoteAddress"] = i.RemoteAddress,
                ["RemotePort"] = i.RemotePort
            });

            return JsonSerializer.Serialize(items);
        }

        /// <summary>
        /// Converts the bytes of a received datagram into the text a step publishes.
        /// </summary>
        /// <param name="data">The payload bytes.</param>
        /// <param name="format">The form of the text: one of the format constants of this class.</param>
        /// <param name="encoding">The encoding of a text payload.</param>
        /// <returns>The payload as plain, hexadecimal, or Base64 text.</returns>
        public static string ConvertToText(byte[] data, string format, Encoding encoding)
        {
            // Hexadecimal text is upper case without separators, the form Convert.FromHexString reads back.
            return format switch
            {
                HexFormat => Convert.ToHexString(data),
                Base64Format => Convert.ToBase64String(data),
                _ => encoding.GetString(data)
            };
        }

        /// <summary>
        /// Creates the regular expression of a <c>Pattern</c> argument and fails the step when it is not valid.
        /// </summary>
        /// <remarks>
        /// The expression is built once, before the step waits, so a malformed pattern fails at once instead of
        /// surfacing as a timeout. Every match is bounded by the same limit as the rule properties.
        /// </remarks>
        /// <param name="pattern">The regular expression text.</param>
        /// <returns>The regular expression.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the text is not a valid regular expression.
        /// </exception>
        public static Regex NewPattern(string pattern)
        {
            try
            {
                // Bound every match, so a backtracking pattern cannot hang the step that supplied it.
                return new Regex(
                    pattern,
                    options: RegexOptions.None,
                    matchTimeout: TimeSpan.FromSeconds(PatternTimeoutSeconds));
            }
            catch (Exception exception)
            {
                // Name the argument, because the runtime message names only the parse position.
                var message = $"The 'Pattern' argument is not a valid regular expression: {exception.Message}";
                throw new InvalidOperationException(message, exception);
            }
        }

        /// <summary>
        /// Resolves every IP address of a host name; an IP address resolves to itself without a lookup.
        /// </summary>
        /// <param name="host">The host name or IP address.</param>
        /// <returns>The addresses of the host.</returns>
        public static IPAddress[] ResolveAddresses(string host)
        {
            // Skip the name lookup for a literal address, so a flow on an isolated network never waits on DNS.
            return IPAddress.TryParse(host, out var address)
                ? [address]
                : Dns.GetHostAddresses(hostNameOrAddress: host);
        }

        /// <summary>
        /// Refines the text of a datagram through the <c>OnElement</c>, <c>OnAttribute</c>, and
        /// <c>RegularExpression</c> properties of a rule.
        /// </summary>
        /// <remarks>
        /// <c>OnElement</c> is a JSONPath for JSON text and an XPath for XML text, and the first result is kept. An
        /// XML element is published as its markup, or as one attribute when <c>OnAttribute</c> names it; an XPath that
        /// selects an attribute, a text node, or a value publishes that value. Text that is neither JSON nor XML skips
        /// this stage. The regular expression runs last and keeps its first match. A path or a pattern that finds
        /// nothing yields an empty string, and a malformed path fails the step.
        /// </remarks>
        /// <param name="content">The datagram text.</param>
        /// <param name="rule">The rule whose properties refine the text.</param>
        /// <returns>The refined text.</returns>
        public static string ResolveContent(string content, G4RuleModelBase rule)
        {
            // Select the part of a structured datagram the rule points at, when it points at one.
            var value = string.IsNullOrEmpty(rule.OnElement)
                ? content
                : SelectContent(content, rule);

            // Fall back to the engine default pattern so a rule without a regular expression keeps the whole text.
            var pattern = string.IsNullOrEmpty(rule.RegularExpression)
                ? RuleProperties.DefaultRegularExpression
                : rule.RegularExpression;

            // Keep the first match only, and report no match as an empty value instead of the unrefined text.
            var match = Regex.Match(
                input: value,
                pattern,
                options: RegexOptions.None,
                matchTimeout: TimeSpan.FromSeconds(PatternTimeoutSeconds));

            return match.Success
                ? match.Value
                : string.Empty;
        }

        /// <summary>
        /// Resolves the destination of a datagram from a host name or an IP address.
        /// </summary>
        /// <param name="host">The host name or IP address.</param>
        /// <param name="port">The destination port.</param>
        /// <param name="addressFamily">The address family of the sending socket.</param>
        /// <returns>The destination endpoint.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the host has no address of the family the socket sends on.
        /// </exception>
        public static IPEndPoint ResolveEndPoint(string host, int port, AddressFamily addressFamily)
        {
            // Pick the first address the socket can reach; an IPv4 socket cannot send to an IPv6-only host.
            var address = Array.Find(ResolveAddresses(host), i => i.AddressFamily == addressFamily);

            if (address is null)
            {
                var message = $"The host '{host}' has no {addressFamily} address the UDP socket can send to.";
                throw new InvalidOperationException(message);
            }

            return new IPEndPoint(address, port);
        }

        // Converts the first result of an XPath evaluation to text: an element as its markup, or one of its
        // attributes when the rule names one; an attribute or a text node as its value; a number, a string, or a
        // Boolean as itself. An empty result is an empty string.
        private static string ConvertXPathResult(object result, string attribute)
        {
            // Take the first node of a node set; a scalar result stands for itself.
            var first = result is IEnumerable nodes and not string
                ? nodes.Cast<object>().FirstOrDefault()
                : result;

            // Convert the node or value to the text a step publishes; an element honors the attribute of the rule.
            return first switch
            {
                null => string.Empty,
                XElement element when !string.IsNullOrEmpty(attribute) =>
                    element.Attribute(attribute)?.Value ?? string.Empty,
                XElement element => $"{element}",
                XAttribute value => value.Value,
                XText value => value.Value,
                IFormattable value => value.ToString(format: null, CultureInfo.InvariantCulture),
                _ => $"{first}"
            };
        }

        // Asks the runtime for an encoding by its registered name and names the argument when it is unknown. The
        // code-page provider is asked first, so legacy encodings such as windows-1252 work without registering the
        // provider for the whole process.
        private static Encoding GetEncoding(string name)
        {
            try
            {
                // Prefer a code page, then fall back to the encodings the runtime always carries.
                return CodePagesEncodingProvider.Instance.GetEncoding(name) ?? Encoding.GetEncoding(name);
            }
            catch (Exception exception)
            {
                // Name the argument and its value, because the runtime message names neither.
                var message = $"The 'Encoding' argument '{name}' is not a supported text encoding.";
                throw new InvalidOperationException(message, exception);
            }
        }

        // Removes the separators and prefixes hexadecimal text may carry, leaving only the digits to decode.
        private static string RemoveHexSeparators(string value)
        {
            // Drop "0x" prefixes first, then white space, commas, colons, and hyphens between bytes.
            const string SeparatorsPattern = @"0[xX]|[\s,:\-]";

            return Regex.Replace(
                input: value,
                pattern: SeparatorsPattern,
                replacement: string.Empty,
                options: RegexOptions.None,
                matchTimeout: TimeSpan.FromSeconds(PatternTimeoutSeconds));
        }

        // Selects one part of JSON or XML text through the OnElement path of the rule. Text of any other shape is
        // returned unchanged, a path that finds nothing returns an empty string, and a malformed path fails the step.
        private static string SelectContent(string content, G4RuleModelBase rule)
        {
            // Read JSON through a JSONPath and keep the first token; a string token is returned without its quotes.
            if (content.AssertJson())
            {
                var token = JToken
                    .Parse(content)
                    .SelectTokens(path: rule.OnElement)
                    .FirstOrDefault();

                return $"{token}";
            }

            // Leave text that is not XML untouched, so a plain datagram still reaches the regular expression.
            if (!content.AssertXml())
            {
                return content;
            }

            // Evaluate the XPath and convert its first result, so attribute and text paths work like element paths.
            var result = XDocument.Parse(content).XPathEvaluate(expression: rule.OnElement);

            return ConvertXPathResult(result, attribute: rule.OnAttribute);
        }
        #endregion
    }
}
