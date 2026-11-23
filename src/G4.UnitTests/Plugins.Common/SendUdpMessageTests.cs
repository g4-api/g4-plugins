using G4.Extensions;
using G4.Models;
using G4.Plugins;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("SendUdpMessage")]
    [TestCategory("Udp")]
    [TestCategory("UnitTest")]
    public class SendUdpMessageTests : UdpTestBase
    {
        // Longest wait for a datagram to cross the loopback interface before a test reports it missing.
        private static readonly TimeSpan ArrivalTimeout = TimeSpan.FromSeconds(5);

        // Short wait that proves a datagram did not arrive, used where the test expects silence.
        private static readonly TimeSpan SilenceTimeout = TimeSpan.FromMilliseconds(300);

        [TestMethod(DisplayName = "Verify that the SendUdpMessage plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin manifest matches the expected schema and required metadata.
            AssertManifest<SendUdpMessage>();
        }

        [TestMethod(DisplayName = "Verify that the SendUdpMessage plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin type can be discovered and instantiated by the plugin framework.
            AssertPlugin<SendUdpMessage>();
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage with AnySender takes a datagram from another " +
            "address as the reply, for a device that answers from a different address.")]
        public void SendUdpMessageAnySenderTest()
        {
            // Arrange: skip with a warning on a host without the second loopback address, such as stock macOS.
            AssertStrangerAddress();

            // Arrange: a send plugin whose automation will hold a listener, and a server that answers only from
            // the second loopback address, never from the destination address.
            var plugin = NewPlugin<SendUdpMessage>(Automation);
            var start = NewSharedPlugin<StartUdpListener>(source: plugin);
            var listenerPort = 0;
            using var server = new UdpTestServer(handler: (_, _) =>
            {
                SendFromStranger(port: listenerPort, data: Encoding.UTF8.GetBytes("other-address"));

                return [];
            });

            try
            {
                // Arrange: start the listener the request leaves from.
                var entity = SendRule(plugin: start, argument: "{{$ --Name:Loose}}").Entity;
                listenerPort = int.Parse($"{entity["Port"]}", CultureInfo.InvariantCulture);

                // Act: send through the listener and accept a reply from any sender.
                var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:Q --Listener:Loose " +
                    "--WaitForResponse --AnySender --Timeout:5000}}";
                var response = SendRule(plugin, argument);

                // Assert: the datagram from the other address counts as the reply, with its real sender.
                Assert.AreEqual(expected: "other-address", actual: $"{response.Entity["Response"]}");
                Assert.AreEqual(expected: "127.0.0.2", actual: $"{response.Entity["RemoteAddress"]}");
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                SendRule(plugin: NewSharedPlugin<StopUdpListener>(source: plugin), argument: "{{$ --Name:Loose}}");
            }
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage with the Broadcast switch delivers a datagram " +
            "sent to the broadcast address; a machine without broadcast delivery is reported as a warning.")]
        public void SendUdpMessageBroadcastTest()
        {
            // Arrange: a send plugin whose automation will hold a listener on every interface.
            var plugin = NewPlugin<SendUdpMessage>(Automation);
            var start = NewSharedPlugin<StartUdpListener>(source: plugin);

            try
            {
                // Arrange: start the listener; a failure here is a defect and fails the test.
                var port = $"{SendRule(plugin: start, argument: "{{$ --Name:Everyone}}").Entity["Port"]}";
                var argument = $"{{{{$ --Host:255.255.255.255 --Port:{port} --Message:to-all --Broadcast}}}}";

                // Act: send the broadcast and read it from the listener.
                var response = ReceiveBroadcast(plugin, argument);

                // Assert: the broadcast reached the listener on this machine.
                Assert.AreEqual(expected: "to-all", actual: $"{response.Entity["Message"]}");
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                SendRule(plugin: NewSharedPlugin<StopUdpListener>(source: plugin), argument: "{{$ --Name:Everyone}}");
            }
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage encodes a text message with a code-page encoding " +
            "such as windows-1252.")]
        public void SendUdpMessageCodePageTest()
        {
            // Arrange: a silent server records what arrives.
            using var server = new UdpTestServer();
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:café --Encoding:windows-1252}}}}";

            // Act: send a text with an accented letter in the legacy Windows encoding.
            SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the accented letter travels as the single byte E9 of windows-1252.
            Assert.AreEqual(expected: "636166E9", actual: Convert.ToHexString(ReadFirstRequest(server).Data));
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage encodes a text message with the encoding named by " +
            "the Encoding argument.")]
        #region *** Data Set ***
        [DataRow("UTF8", "utf-8")]
        [DataRow("utf-8", "utf-8")]
        [DataRow("ASCII", "us-ascii")]
        [DataRow("Unicode", "utf-16")]
        [DataRow("utf-16", "utf-16")]
        [DataRow("UTF32", "utf-32")]
        [DataRow("Latin1", "iso-8859-1")]
        [DataRow("iso-8859-1", "iso-8859-1")]
        #endregion
        public void SendUdpMessageEncodingTest(string encodingName, string expectedEncodingName)
        {
            // Arrange: a silent server records what arrives.
            using var server = new UdpTestServer();
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:café --Encoding:{encodingName}}}}}";

            // Act: send a text with a non-ASCII character.
            SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the bytes on the wire are the text in the expected encoding.
            var expected = Encoding.GetEncoding(expectedEncodingName).GetBytes("café");
            var actual = ReadFirstRequest(server).Data;
            Assert.AreEqual(expected: Convert.ToHexString(expected), actual: Convert.ToHexString(actual));
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage sends the bytes of the file named by MessageFile " +
            "unchanged.")]
        public void SendUdpMessageFileTest()
        {
            // Arrange: a silent server and the path of a binary file with a zero byte.
            using var server = new UdpTestServer();
            byte[] content = [0x00, 0xFF, 0x10, 0x80, 0x7F];
            var path = Path.Combine(Path.GetTempPath(), $"g4-udp-{Guid.NewGuid()}.bin");

            try
            {
                // Arrange: write the payload file inside the try, so cleanup always removes it.
                File.WriteAllBytes(path, bytes: content);

                // Act: send the file as the payload.
                var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --MessageFile:{path}}}}}";
                var response = SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

                // Assert: the exact bytes arrived, and the step reports their count.
                Assert.AreSequenceEqual(expected: content, actual: ReadFirstRequest(server).Data);
                Assert.AreEqual(expected: "5", actual: $"{response.Entity["BytesSent"]}");
            }
            finally
            {
                // Remove the payload file the test created.
                File.Delete(path);
            }
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage reads the message as text, hexadecimal bytes, or " +
            "Base64 bytes according to the Format argument.")]
        #region *** Data Set ***
        [DataRow("PING", "", "50494E47")]
        [DataRow("PING", "--Format:Text", "50494E47")]
        [DataRow("AA 55 01 00", "--Format:Hex", "AA550100")]
        [DataRow("0xAA,0x55:01-00", "--Format:hex", "AA550100")]
        [DataRow("aa550100", "--Format:Hex", "AA550100")]
        [DataRow("qlUBAA==", "--Format:Base64", "AA550100")]
        #endregion
        public void SendUdpMessageFormatTest(string message, string format, string expectedHex)
        {
            // Arrange: a silent server records what arrives.
            using var server = new UdpTestServer();
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:{message} {format}}}}}";

            // Act: send the message in the given format.
            SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the bytes on the wire are the ones the message describes.
            Assert.AreEqual(expected: expectedHex, actual: Convert.ToHexString(ReadFirstRequest(server).Data));
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage fails on a malformed or missing argument, with a " +
            "message that names it, before it sends anything.")]
        #region *** Data Set ***
        [DataRow("", "'Message'")]
        [DataRow("--Message:PING --Format:Xml", "'Format'")]
        [DataRow("--Message:ABC --Format:Hex", "'Message'")]
        [DataRow("--Message:not base64! --Format:Base64", "'Message'")]
        [DataRow("--Message:PING --Encoding:no-such-encoding", "'Encoding'")]
        [DataRow("--Message:PING --Listener:Missing", "'Missing'")]
        [DataRow("--Message:PING --LocalPort:70000", "'LocalPort'")]
        [DataRow("--Message:PING --LocalAddress:localhost", "'LocalAddress'")]
        [DataRow("--Message:PING --WaitForResponse --Retries:x", "'Retries'")]
        [DataRow("--Message:PING --WaitForResponse --MaxResponses:-2", "'MaxResponses'")]
        [DataRow("--Message:PING --ResponseFormat:Json", "'ResponseFormat'")]
        #endregion
        public void SendUdpMessageInvalidArgumentTest(string arguments, string argumentName)
        {
            // Arrange: a silent server proves that nothing reaches the wire.
            using var server = new UdpTestServer();
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} {arguments}}}}}";

            // Act: run the step with the malformed argument.
            var exception = Assert.Throws<InvalidOperationException>(
                () => SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument));

            // Assert: the failure names the argument, and no datagram was sent.
            Assert.Contains(substring: argumentName, value: exception.Message);
            Assert.IsFalse(server.WaitForRequests(count: 1, timeout: SilenceTimeout));
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage rejects a destination port that is not a number " +
            "from 1 to 65535.")]
        #region *** Data Set ***
        [DataRow("0")]
        [DataRow("65536")]
        [DataRow("port")]
        #endregion
        public void SendUdpMessageInvalidPortTest(string port)
        {
            // Arrange: a destination with a port no datagram can be sent to.
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{port} --Message:PING}}}}";

            // Act: run the step with the invalid port.
            var exception = Assert.Throws<InvalidOperationException>(
                () => SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument));

            // Assert: the failure names the Port argument.
            Assert.Contains(substring: "'Port'", value: exception.Message);
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage sends through a named listener, so the reply lands " +
            "in the listener buffer for a later ReceiveUdpMessage step.")]
        public void SendUdpMessageListenerTest()
        {
            // Arrange: a server that answers every request, and a send plugin whose automation will hold a listener.
            using var server = new UdpTestServer(handler: (_, data) => [[.. Encoding.UTF8.GetBytes("ack:"), .. data]]);
            var plugin = NewPlugin<SendUdpMessage>(Automation);
            var start = NewSharedPlugin<StartUdpListener>(source: plugin);

            try
            {
                // Arrange: start the listener and keep its port.
                var entity = SendRule(plugin: start, argument: "{{$ --Name:Device}}").Entity;
                var listenerPort = int.Parse($"{entity["Port"]}", CultureInfo.InvariantCulture);

                // Act: send through the listener without waiting, then read the reply from its buffer.
                var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:START --Listener:Device}}}}";
                var sendResponse = SendRule(plugin, argument);
                var receive = NewSharedPlugin<ReceiveUdpMessage>(source: plugin);
                var receiveResponse = SendRule(plugin: receive, argument: "{{$ --Listener:Device --Timeout:5000}}");

                // Assert: the request left from the listener port, so the server replied to it.
                Assert.AreEqual(expected: listenerPort, actual: ReadFirstRequest(server).RemoteEndPoint.Port);

                // Assert: the send did not wait, and the reply was buffered for the receive step.
                Assert.AreEqual(expected: "0", actual: $"{sendResponse.Entity["ResponseCount"]}");
                Assert.AreEqual(expected: "ack:START", actual: $"{receiveResponse.Entity["Message"]}");
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                SendRule(plugin: NewSharedPlugin<StopUdpListener>(source: plugin), argument: "{{$ --Name:Device}}");
            }
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage ignores datagrams a listener buffered before the " +
            "send and takes only the reply to its own request.")]
        public void SendUdpMessageListenerReplyOnlyTest()
        {
            // Arrange: a server that answers requests, and a send plugin whose automation will hold a listener.
            using var server = new UdpTestServer(handler: (_, _) => [Encoding.UTF8.GetBytes("reply")]);
            var plugin = NewPlugin<SendUdpMessage>(Automation);
            var start = NewSharedPlugin<StartUdpListener>(source: plugin);
            var receive = NewSharedPlugin<ReceiveUdpMessage>(source: plugin);

            try
            {
                // Arrange: start the listener and keep its port.
                var entity = SendRule(plugin: start, argument: "{{$ --Name:Mixed}}").Entity;
                var listenerPort = int.Parse($"{entity["Port"]}", CultureInfo.InvariantCulture);

                // Arrange: buffer an unrelated datagram, and prove it is buffered without taking it: asking for two
                // matches times out with one, and a short read leaves the datagram in the buffer.
                UdpTestServer.SendDatagram(port: listenerPort, data: Encoding.UTF8.GetBytes("older"));
                var probe = "{{$ --Listener:Mixed --Pattern:^older$ --Count:2 --Timeout:1000}}";
                var probeException = Assert.Throws<TimeoutException>(() => SendRule(plugin: receive, argument: probe));
                Assert.Contains(substring: "1 of 2", value: probeException.Message);

                // Act: send through the listener and wait for the reply.
                var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:Q --Listener:Mixed " +
                    "--WaitForResponse --Timeout:5000}}";
                var response = SendRule(plugin, argument);

                // Assert: the reply is the answer of the server, not the datagram that was buffered earlier.
                Assert.AreEqual(expected: "reply", actual: $"{response.Entity["Response"]}");

                // Assert: the earlier datagram is still buffered for a receive step.
                var receiveResponse = SendRule(plugin: receive, argument: "{{$ --Listener:Mixed --Timeout:5000}}");
                Assert.AreEqual(expected: "older", actual: $"{receiveResponse.Entity["Message"]}");
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                SendRule(plugin: NewSharedPlugin<StopUdpListener>(source: plugin), argument: "{{$ --Name:Mixed}}");
            }
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage binds the source port named by LocalPort.")]
        public void SendUdpMessageLocalPortTest()
        {
            // Arrange: a silent server and a source port that is free right now.
            using var server = new UdpTestServer();
            var localPort = UdpTestServer.GetFreePort();
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:PING --LocalPort:{localPort}}}}}";

            // Act: send from the fixed source port.
            SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the server saw the datagram arrive from that port.
            Assert.AreEqual(expected: localPort, actual: ReadFirstRequest(server).RemoteEndPoint.Port);
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage collects several replies up to MaxResponses and " +
            "publishes them in arrival order.")]
        public void SendUdpMessageMaxResponsesTest()
        {
            // Arrange: a server that answers one request with three replies.
            using var server = new UdpTestServer(handler: (_, _) =>
            [
                Encoding.UTF8.GetBytes("device-1"),
                Encoding.UTF8.GetBytes("device-2"),
                Encoding.UTF8.GetBytes("device-3")
            ]);
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:DISCOVER --WaitForResponse " +
                "--MaxResponses:3 --Timeout:5000}}";

            // Act: send the request and wait for up to three replies.
            var response = SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the first reply and the count are published.
            Assert.AreEqual(expected: "device-1", actual: $"{response.Entity["Response"]}");
            Assert.AreEqual(expected: "3", actual: $"{response.Entity["ResponseCount"]}");

            // Assert: the list holds every reply with its payload, length, and sender.
            using var document = JsonDocument.Parse($"{response.Entity["Responses"]}");
            var items = document.RootElement.EnumerateArray().ToArray();
            var data = string.Join(separator: ',', values: items.Select(i => i.GetProperty("Data").GetString()));
            Assert.AreEqual(expected: "device-1,device-2,device-3", actual: data);
            Assert.AreEqual(expected: 8, actual: items[0].GetProperty("Length").GetInt32());
            Assert.AreEqual(expected: server.Port, actual: items[0].GetProperty("RemotePort").GetInt32());
            Assert.AreEqual(expected: "127.0.0.1", actual: items[0].GetProperty("RemoteAddress").GetString());
        }

        [TestMethod(DisplayName = "Verify that the engine rejects a SendUdpMessage rule without the mandatory " +
            "Host or Port parameter.")]
        #region *** Data Set ***
        [DataRow("{{$ --Port:5005 --Message:PING}}")]
        [DataRow("{{$ --Host:127.0.0.1 --Message:PING}}")]
        #endregion
        public void SendUdpMessageMissingMandatoryTest(string argument)
        {
            // Arrange: a rule that omits one mandatory parameter.
            var plugin = NewPlugin<SendUdpMessage>(Automation);

            // Act: the engine validates the manifest parameters before the plugin runs.
            var response = SendRule(plugin, argument);

            // Assert: the response reports the missing parameter and carries no outputs.
            const string exceptionType = "MissingMandatoryParameterException";
            Assert.Contains(predicate: i => i.Type == exceptionType, collection: response.Exceptions);
            Assert.IsFalse(response.Entity.ContainsKey("BytesSent"));
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage with NoEntity publishes its outputs to the session " +
            "and leaves the response entity empty.")]
        public void SendUdpMessageNoEntityTest()
        {
            // Arrange: a silent server and a rule that suppresses the entity.
            using var server = new UdpTestServer();
            var plugin = NewPlugin<SendUdpMessage>(Automation);
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:PING --NoEntity}}}}";

            // Act: send the datagram.
            var response = SendRule(plugin, argument);

            // Assert: the entity carries no output, while the session still holds the byte count as Base64.
            var parameters = plugin.Invoker.Context.SessionParameters;
            Assert.IsFalse(response.Entity.ContainsKey("BytesSent"));
            Assert.AreEqual(expected: "4", actual: $"{parameters["SendUdpMessage:BytesSent"]}".ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage with WaitForResponse fails with a timeout when no " +
            "reply arrives, after sending once per attempt.")]
        public void SendUdpMessageNoResponseTest()
        {
            // Arrange: a server that records requests and never replies.
            using var server = new UdpTestServer();
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:PING --WaitForResponse " +
                "--Timeout:300 --Retries:2}}";

            // Act: send and wait on the silent server.
            var exception = Assert.Throws<TimeoutException>(
                () => SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument));

            // Assert: the message names the attempts, and the server saw one datagram per attempt.
            Assert.Contains(substring: "3 attempt(s)", value: exception.Message);
            Assert.IsTrue(server.WaitForRequests(count: 3, timeout: ArrivalTimeout));
            Assert.HasCount(3, server.Requests);
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage rejects a payload larger than one datagram carries " +
            "and sends nothing.")]
        public void SendUdpMessagePayloadTooLargeTest()
        {
            // Arrange: a silent server and the path of a file one byte larger than the largest UDP payload.
            using var server = new UdpTestServer();
            var path = Path.Combine(Path.GetTempPath(), $"g4-udp-{Guid.NewGuid()}.bin");

            try
            {
                // Arrange: write the payload file inside the try, so cleanup always removes it.
                File.WriteAllBytes(path, bytes: new byte[65508]);
                var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --MessageFile:{path}}}}}";

                // Act: run the step with the oversized payload.
                var exception = Assert.Throws<InvalidOperationException>(
                    () => SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument));

                // Assert: the failure reports the size, and no datagram reached the server.
                Assert.Contains(substring: "65508 bytes", value: exception.Message);
                Assert.IsFalse(server.WaitForRequests(count: 1, timeout: SilenceTimeout));
            }
            finally
            {
                // Remove the payload file the test created.
                File.Delete(path);
            }
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage refines the first reply through OnElement, " +
            "OnAttribute, and RegularExpression.")]
        #region *** Data Set ***
        [DataRow("{\"temperature\":\"21 C\",\"unit\":\"C\"}", "$.temperature", "", "\\d+", "21")]
        [DataRow("{\"reading\":{\"value\":42}}", "$.reading.value", "", "", "42")]
        [DataRow("{\"reading\":{\"value\":42}}", "$.missing", "", "", "")]
        [DataRow("{\"items\":[1,2,3]}", "$.items[*]", "", "", "1")]
        [DataRow("<r><status code=\"7\">ok</status></r>", "//status", "code", "", "7")]
        [DataRow("<r><status code=\"7\">ok</status></r>", "//status", "", "(?<=>)\\w+(?=<)", "ok")]
        [DataRow("<r><status code=\"7\">ok</status></r>", "//status/@code", "", "", "7")]
        [DataRow("<r><status code=\"7\">ok</status></r>", "//status/text()", "", "", "ok")]
        [DataRow("<r><status code=\"7\">ok</status></r>", "//missing", "", "", "")]
        [DataRow("STATUS=READY;LEVEL=3", "", "", "(?<=LEVEL=)\\d+", "3")]
        [DataRow("STATUS=READY", "", "", "\\d+", "")]
        #endregion
        public void SendUdpMessageRefineTest(
            string reply,
            string onElement,
            string onAttribute,
            string regularExpression,
            string expected)
        {
            // Arrange: a server that answers with the given reply, and a rule that refines it.
            using var server = new UdpTestServer(handler: (_, _) => [Encoding.UTF8.GetBytes(reply)]);
            var rule = new ActionRuleModel
            {
                Argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:READ --WaitForResponse}}}}",
                OnAttribute = onAttribute,
                OnElement = onElement,
                PluginName = "SendUdpMessage",
                Reference = new G4PluginReferenceModel { Id = $"{Guid.NewGuid()}" },
                RegularExpression = regularExpression
            };

            // Act: send the request and wait for the reply.
            var response = NewPlugin<SendUdpMessage>(Automation).Send(new PluginDataModel { Rule = rule });

            // Assert: the published reply is the refined value.
            Assert.AreEqual(expected, actual: $"{response.Entity["Response"]}");

            // Assert: the list keeps the reply as it arrived.
            using var document = JsonDocument.Parse($"{response.Entity["Responses"]}");
            Assert.AreEqual(expected: reply, actual: document.RootElement[0].GetProperty("Data").GetString());
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage with WaitForResponse takes only a reply from the " +
            "destination address and leaves a datagram from another sender in the listener buffer.")]
        public void SendUdpMessageReplyAddressTest()
        {
            // Arrange: skip with a warning on a host without the second loopback address, such as stock macOS.
            AssertStrangerAddress();

            // Arrange: a send plugin whose automation will hold a listener, and a server that answers each request.
            var plugin = NewPlugin<SendUdpMessage>(Automation);
            var start = NewSharedPlugin<StartUdpListener>(source: plugin);
            var listenerPort = 0;
            using var server = new UdpTestServer(handler: (_, _) =>
            {
                // Make another loopback address speak first, then reply from the destination address.
                SendFromStranger(port: listenerPort, data: Encoding.UTF8.GetBytes("stranger"));

                return [Encoding.UTF8.GetBytes("reply")];
            });

            try
            {
                // Arrange: start the listener the request leaves from.
                var entity = SendRule(plugin: start, argument: "{{$ --Name:Strict}}").Entity;
                listenerPort = int.Parse($"{entity["Port"]}", CultureInfo.InvariantCulture);

                // Act: send through the listener and wait for the reply.
                var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:Q --Listener:Strict " +
                    "--WaitForResponse --MaxResponses:2 --Timeout:1000}}";
                var response = SendRule(plugin, argument);

                // Assert: the reply came from the destination, and the stranger datagram was not counted, although
                // the step accepted up to two replies.
                Assert.AreEqual(expected: "reply", actual: $"{response.Entity["Response"]}");
                Assert.AreEqual(expected: "1", actual: $"{response.Entity["ResponseCount"]}");

                // Assert: the stranger datagram is still buffered for a receive step.
                var receive = NewSharedPlugin<ReceiveUdpMessage>(source: plugin);
                var stranger = "{{$ --Listener:Strict --RemoteHost:127.0.0.2 --Timeout:5000}}";
                var strangerResponse = SendRule(plugin: receive, argument: stranger);
                Assert.AreEqual(expected: "stranger", actual: $"{strangerResponse.Entity["Message"]}");
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                SendRule(plugin: NewSharedPlugin<StopUdpListener>(source: plugin), argument: "{{$ --Name:Strict}}");
            }
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage publishes replies as hexadecimal or Base64 text " +
            "according to the ResponseFormat argument.")]
        #region *** Data Set ***
        [DataRow("Hex", "00FF10")]
        [DataRow("Base64", "AP8Q")]
        #endregion
        public void SendUdpMessageResponseFormatTest(string responseFormat, string expected)
        {
            // Arrange: a server that answers with three bytes that are not valid text.
            using var server = new UdpTestServer(handler: (_, _) => [[0x00, 0xFF, 0x10]]);
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:READ --WaitForResponse " +
                $"--ResponseFormat:{responseFormat}}}}}";

            // Act: send the request and wait for the reply.
            var response = SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the reply keeps every byte in the requested text form.
            Assert.AreEqual(expected, actual: $"{response.Entity["Response"]}");
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage sends the datagram again when no reply arrives and " +
            "passes on the reply to a later attempt.")]
        public void SendUdpMessageRetryTest()
        {
            // Arrange: a server that ignores the first request and answers the second.
            var reply = Encoding.UTF8.GetBytes("late");
            using var server = new UdpTestServer(handler: (number, _) => number < 2 ? [] : [reply]);
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:PING --WaitForResponse " +
                "--Timeout:2000 --Retries:3}}";

            // Act: send with retries.
            var response = SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the step passed on the second attempt and stopped sending.
            Assert.AreEqual(expected: "late", actual: $"{response.Entity["Response"]}");
            Assert.HasCount(2, server.Requests);
        }

        [TestMethod(DisplayName = "Verify that a flow sends a datagram to its own listener and publishes the " +
            "outputs of every UDP step to the session.")]
        public void SendUdpMessageSessionOutputsTest()
        {
            // Arrange: a flow that starts a listener, sends to it, reads the datagram, and stops the listener.
            var port = UdpTestServer.GetFreePort();
            var sendArgument = $"{{{{$ --Host:127.0.0.1 --Port:{port} --Message:hello}}}}";
            var rules = new[]
            {
                NewRule(pluginName: "StartUdpListener", argument: $"{{{{$ --Name:Loop --Port:{port}}}}}"),
                NewRule(pluginName: "SendUdpMessage", argument: sendArgument),
                NewRule(pluginName: "ReceiveUdpMessage", argument: "{{$ --Listener:Loop --Timeout:5000}}"),
                NewRule(pluginName: "StopUdpListener", argument: "{{$ --Name:Loop}}")
            };

            // Act: run the flow through the full automation pipeline.
            var responseModel = Invoke(rules);
            var parameters = responseModel.GetEnvironment().SessionParameters;

            // Assert: every step passed.
            Assert.IsEmpty(responseModel.GetExceptions());

            // Assert: the start published its port, the send its byte count, the receive the same text, and the
            // stop the closed listener.
            var startPort = parameters.Get(key: "StartUdpListener:Port", defaultValue: string.Empty);
            var bytesSent = parameters.Get(key: "SendUdpMessage:BytesSent", defaultValue: string.Empty);
            var message = parameters.Get(key: "ReceiveUdpMessage:Message", defaultValue: string.Empty);
            var stopped = parameters.Get(key: "StopUdpListener:Stopped", defaultValue: string.Empty);
            Assert.AreEqual(expected: $"{port}", actual: startPort.ConvertFromBase64());
            Assert.AreEqual(expected: "5", actual: bytesSent.ConvertFromBase64());
            Assert.AreEqual(expected: "hello", actual: message.ConvertFromBase64());
            Assert.AreEqual(expected: "true", actual: stopped.ConvertFromBase64());
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage sends a text datagram without waiting and reports " +
            "the byte count and the resolved destination.")]
        public void SendUdpMessageTextTest()
        {
            // Arrange: a silent server records what arrives.
            using var server = new UdpTestServer();
            var argument = $"{{{{$ --Host:localhost --Port:{server.Port} --Message:hello world}}}}";

            // Act: send the text to a host name.
            var response = SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the text arrived as UTF-8, spaces included.
            Assert.AreEqual(expected: "hello world", actual: Encoding.UTF8.GetString(ReadFirstRequest(server).Data));

            // Assert: the step did not wait, and reports the byte count and the resolved destination.
            Assert.AreEqual(expected: "11", actual: $"{response.Entity["BytesSent"]}");
            Assert.AreEqual(expected: "0", actual: $"{response.Entity["ResponseCount"]}");
            Assert.AreEqual(expected: string.Empty, actual: $"{response.Entity["Response"]}");
            Assert.AreEqual(expected: "[]", actual: $"{response.Entity["Responses"]}");
            Assert.AreEqual(expected: "127.0.0.1", actual: $"{response.Entity["RemoteAddress"]}");
            Assert.AreEqual(expected: $"{server.Port}", actual: $"{response.Entity["RemotePort"]}");
        }

        [TestMethod(DisplayName = "Verify that SendUdpMessage with WaitForResponse publishes the reply and its " +
            "sender.")]
        public void SendUdpMessageWaitForResponseTest()
        {
            // Arrange: a server that echoes each request with a prefix.
            using var server = new UdpTestServer(handler: (_, data) => [[.. Encoding.UTF8.GetBytes("pong:"), .. data]]);
            var argument = $"{{{{$ --Host:127.0.0.1 --Port:{server.Port} --Message:ping --WaitForResponse " +
                "--Timeout:00:00:05}}";

            // Act: send the request and wait for the reply, with the timeout written as a time span.
            var response = SendRule(plugin: NewPlugin<SendUdpMessage>(Automation), argument);

            // Assert: the reply text, the count, and the sender are published.
            Assert.AreEqual(expected: "pong:ping", actual: $"{response.Entity["Response"]}");
            Assert.AreEqual(expected: "1", actual: $"{response.Entity["ResponseCount"]}");
            Assert.AreEqual(expected: "127.0.0.1", actual: $"{response.Entity["RemoteAddress"]}");
            Assert.AreEqual(expected: $"{server.Port}", actual: $"{response.Entity["RemotePort"]}");
        }

        // Reports the test as Inconclusive when the second loopback address cannot be bound. Windows and Linux route
        // the whole 127.0.0.0/8 range to the loopback interface; stock macOS has only 127.0.0.1, and a bind failure
        // inside the server handler then surfaces as a misleading timeout.
        private static void AssertStrangerAddress()
        {
            // Collect the reason the address cannot be bound; null means the bind worked.
            string message = null;

            try
            {
                // Bind and release the address once, so the handler bind later in the test is known to work.
                var endPoint = new IPEndPoint(address: IPAddress.Parse("127.0.0.2"), port: 0);
                new UdpClient(localEP: endPoint).Dispose();
            }
            catch (SocketException exception)
            {
                // Keep the reason; the assertion runs outside the catch block, where MSTest reports it reliably.
                message = $"Warning: 127.0.0.2 cannot be bound on this machine. {exception.Message}";
            }

            // Warn without failing, because the address depends on the network setup of the machine.
            if (message is not null)
            {
                Assert.Inconclusive(message);
            }
        }

        // Creates a rule for a flow that runs through the full automation pipeline.
        private static ActionRuleModel NewRule(string pluginName, string argument)
        {
            // The pipeline assigns the references, so the rule carries only what a flow file holds.
            return new ActionRuleModel
            {
                Argument = argument,
                PluginName = pluginName
            };
        }

        // Waits for the first request of a server and returns it, failing the test with a clear message when none
        // arrived in time.
        private static (byte[] Data, IPEndPoint RemoteEndPoint) ReadFirstRequest(UdpTestServer server)
        {
            // Wait for the datagram to cross the loopback interface, then read it without removing it.
            Assert.IsTrue(server.WaitForRequests(count: 1, timeout: ArrivalTimeout), "No datagram reached the server.");
            Assert.IsTrue(server.Requests.TryPeek(out var request), "The server queue was empty.");

            return request;
        }

        // Sends the broadcast and reads it from the Everyone listener. Only this delivery stage reports a machine
        // that does not deliver broadcast traffic as Inconclusive, so a broken listener start still fails the test.
        private PluginResponseModel ReceiveBroadcast(PluginBase plugin, string argument)
        {
            try
            {
                // Send through the real plugin, then read through the real plugin of the same automation.
                SendRule(plugin, argument);
                var receive = NewSharedPlugin<ReceiveUdpMessage>(source: plugin);

                return SendRule(plugin: receive, argument: "{{$ --Listener:Everyone --Timeout:3000}}");
            }
            catch (Exception exception) when (exception is TimeoutException or SocketException)
            {
                // Warn without failing, because broadcast delivery depends on the network setup of the machine.
                var message = $"Warning: broadcast traffic is not delivered on this machine. {exception.Message}";
                Assert.Inconclusive(message);

                return null;
            }
        }

        // Sends one datagram to a loopback port from the second loopback address, 127.0.0.2, so the receiver sees a
        // sender other than 127.0.0.1. Windows and Linux route the whole 127.0.0.0/8 range to the loopback interface.
        private static void SendFromStranger(int port, byte[] data)
        {
            // Bind the second loopback address, then send to the listener on the first one.
            using var client = new UdpClient(localEP: new IPEndPoint(address: IPAddress.Parse("127.0.0.2"), port: 0));
            client.Send(dgram: data, bytes: data.Length, endPoint: new IPEndPoint(address: IPAddress.Loopback, port));
        }
    }
}
