using G4.Extensions;
using G4.Models;
using G4.Plugins;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("StartUdpListener")]
    [TestCategory("Udp")]
    [TestCategory("UnitTest")]
    public class StartUdpListenerTests : UdpTestBase
    {
        [TestMethod(DisplayName = "Verify that the StartUdpListener plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin manifest matches the expected schema and required metadata.
            AssertManifest<StartUdpListener>();
        }

        [TestMethod(DisplayName = "Verify that the StartUdpListener plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin type can be discovered and instantiated by the plugin framework.
            AssertPlugin<StartUdpListener>();
        }

        [TestMethod(DisplayName = "Verify that StartUdpListener keeps a datagram that arrives while no step is " +
            "reading, and a later ReceiveUdpMessage step reads it.")]
        public void StartUdpListenerBufferTest()
        {
            // Arrange: a start plugin whose automation will hold the listener.
            var plugin = NewPlugin<StartUdpListener>(Automation);

            try
            {
                // Arrange: start a listener on a free port; no receive step is waiting yet.
                var entity = SendRule(plugin, argument: "{{$ --Name:Buffer}}").Entity;
                var port = int.Parse($"{entity["Port"]}", CultureInfo.InvariantCulture);

                // Act: send a datagram first, then read it through a receive step of the same automation.
                UdpTestServer.SendDatagram(port, data: Encoding.UTF8.GetBytes("buffered"));
                var receive = NewSharedPlugin<ReceiveUdpMessage>(source: plugin);
                var response = SendRule(plugin: receive, argument: "{{$ --Listener:Buffer --Timeout:5000}}");

                // Assert: the datagram that arrived before the read is the one the step returns.
                Assert.AreEqual(expected: "buffered", actual: $"{response.Entity["Message"]}");
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin, name: "Buffer");
            }
        }

        [TestMethod(DisplayName = "Verify that StartUdpListener without an argument starts the Default listener " +
            "on a system-assigned port.")]
        public void StartUdpListenerDefaultTest()
        {
            // Arrange: a plugin whose rule carries no argument.
            var plugin = NewPlugin<StartUdpListener>(Automation);

            try
            {
                // Act: start the listener with every argument at its default.
                var response = SendRule(plugin, argument: string.Empty);

                // Assert: the entity names the Default listener and reports the port the system assigned.
                var port = int.Parse($"{response.Entity["Port"]}", CultureInfo.InvariantCulture);
                Assert.AreEqual(expected: "Default", actual: $"{response.Entity["Name"]}");
                Assert.IsGreaterThan(lowerBound: 0, value: port);

                // Assert: the session carries the same values as Base64 under the plugin namespace.
                var parameters = plugin.Invoker.Context.SessionParameters;
                var sessionName = $"{parameters["StartUdpListener:Name"]}".ConvertFromBase64();
                var sessionPort = $"{parameters["StartUdpListener:Port"]}".ConvertFromBase64();
                Assert.AreEqual(expected: "Default", actual: sessionName);
                Assert.AreEqual(expected: $"{port}", actual: sessionPort);
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin, name: "Default");
            }
        }

        [TestMethod(DisplayName = "Verify that StartUdpListener fails when a listener with the same name is " +
            "already started, whatever the letter case of the name, and keeps the first listener.")]
        public void StartUdpListenerDuplicateNameTest()
        {
            // Arrange: a start plugin whose automation will hold the first listener.
            var plugin = NewPlugin<StartUdpListener>(Automation);

            try
            {
                // Arrange: start a listener named Telemetry.
                SendRule(plugin, argument: "{{$ --Name:Telemetry}}");

                // Act: start the same name again, in another letter case.
                var exception = Assert.Throws<InvalidOperationException>(
                    () => SendRule(plugin, argument: "{{$ --Name:telemetry}}"));

                // Assert: the failure names the listener, and the first listener is still open.
                Assert.Contains(substring: "'telemetry' is already started", value: exception.Message);
                Assert.AreEqual(expected: "true", actual: StopListener(source: plugin, name: "Telemetry"));
            }
            finally
            {
                // Close the first listener when an assertion failed before the stop; a second stop is harmless.
                StopListener(source: plugin, name: "Telemetry");
            }
        }

        [TestMethod(DisplayName = "Verify that StartUdpListener binds the port named by the Port argument.")]
        public void StartUdpListenerFixedPortTest()
        {
            // Arrange: pick a port that is free right now.
            var port = UdpTestServer.GetFreePort();
            var plugin = NewPlugin<StartUdpListener>(Automation);
            var argument = $"{{{{$ --Name:Fixed --Port:{port}}}}}";

            try
            {
                // Act: start the listener on that port.
                var response = SendRule(plugin, argument);

                // Assert: the entity reports the requested port.
                Assert.AreEqual(expected: $"{port}", actual: $"{response.Entity["Port"]}");

                // Assert: the port is held, so a second socket cannot bind it.
                var endPoint = new IPEndPoint(address: IPAddress.Any, port);
                Assert.Throws<SocketException>(() => new UdpClient(localEP: endPoint).Dispose());
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin, name: "Fixed");
            }
        }

        [TestMethod(DisplayName = "Verify that a listener a flow leaves open is closed when the automation ends, " +
            "and its port is free again.")]
        public void StartUdpListenerFlowCleanupTest()
        {
            // Arrange: a flow that starts a listener on a known port and never stops it.
            var port = UdpTestServer.GetFreePort();
            var rule = new ActionRuleModel
            {
                Argument = $"{{{{$ --Name:Forgotten --Port:{port}}}}}",
                PluginName = "StartUdpListener"
            };

            // Act: run the flow through the full automation pipeline.
            var responseModel = Invoke([rule]);

            // Assert: the step passed and published the bound port to the session.
            var actual = responseModel
                .GetEnvironment()
                .SessionParameters
                .Get(key: "StartUdpListener:Port", defaultValue: string.Empty)
                .ConvertFromBase64();
            Assert.IsEmpty(responseModel.GetExceptions());
            Assert.AreEqual(expected: $"{port}", actual);

            // Assert: the end of the automation closed the listener, because binding its port no longer throws.
            using var client = new UdpClient(localEP: new IPEndPoint(address: IPAddress.Any, port));
        }

        [TestMethod(DisplayName = "Verify that StartUdpListener fails on a malformed argument and opens no socket.")]
        #region *** Data Set ***
        [DataRow("{{$ --Name:Invalid --Port:70000}}", "'Port'")]
        [DataRow("{{$ --Name:Invalid --Port:abc}}", "'Port'")]
        [DataRow("{{$ --Name:Invalid --Port:-1}}", "'Port'")]
        [DataRow("{{$ --Name:Invalid --LocalAddress:not-an-address}}", "'LocalAddress'")]
        [DataRow("{{$ --Name:Invalid --MulticastGroup:group}}", "'MulticastGroup'")]
        [DataRow("{{$ --Name:Invalid --BufferSize:many}}", "'BufferSize'")]
        #endregion
        public void StartUdpListenerInvalidArgumentTest(string argument, string argumentName)
        {
            // Arrange: a plugin that receives one malformed argument.
            var plugin = NewPlugin<StartUdpListener>(Automation);

            // Act: start the listener with the malformed argument.
            var exception = Assert.Throws<InvalidOperationException>(() => SendRule(plugin, argument));

            // Assert: the failure names the argument, and no listener was registered.
            Assert.Contains(substring: argumentName, value: exception.Message);
            Assert.AreEqual(expected: "false", actual: StopListener(source: plugin, name: "Invalid"));
        }

        [TestMethod(DisplayName = "Verify that a listener that joined a multicast group receives a datagram " +
            "sent to the group; a machine without multicast delivery is reported as a warning.")]
        public void StartUdpListenerMulticastTest()
        {
            // Arrange: a group address from the administratively scoped range and a free port.
            const string group = "239.255.42.99";
            var port = UdpTestServer.GetFreePort();
            var plugin = NewPlugin<StartUdpListener>(Automation);
            var startArgument = $"{{{{$ --Name:Group --Port:{port} --MulticastGroup:{group}}}}}";
            var sendArgument = $"{{{{$ --Host:{group} --Port:{port} --Message:to-group}}}}";

            try
            {
                // Arrange: join the group; a failure here is a defect and fails the test.
                SendRule(plugin, argument: startArgument);

                // Act: send one datagram to the group and read it from the listener.
                var response = ReceiveFromGroup(plugin, sendArgument);

                // Assert: the datagram sent to the group reached the listener.
                Assert.AreEqual(expected: "to-group", actual: $"{response.Entity["Message"]}");
            }
            finally
            {
                // Close the listener so it leaves the group and frees its port.
                StopListener(source: plugin, name: "Group");
            }
        }

        [TestMethod(DisplayName = "Verify that StartUdpListener fails when another socket holds the port and " +
            "registers no listener.")]
        public void StartUdpListenerPortInUseTest()
        {
            // Arrange: hold a port on every interface with a socket the test owns.
            using var client = new UdpClient(localEP: new IPEndPoint(address: IPAddress.Any, port: 0));
            var port = ((IPEndPoint)client.Client.LocalEndPoint).Port;
            var plugin = NewPlugin<StartUdpListener>(Automation);
            var argument = $"{{{{$ --Name:Busy --Port:{port}}}}}";

            try
            {
                // Act and Assert: binding the held port fails the step.
                Assert.Throws<SocketException>(() => SendRule(plugin, argument));

                // Assert: the failed start left no listener behind.
                Assert.AreEqual(expected: "false", actual: StopListener(source: plugin, name: "Busy"));
            }
            finally
            {
                // Close the listener when the start unexpectedly succeeded; stopping a closed name is harmless.
                StopListener(source: plugin, name: "Busy");
            }
        }

        // Sends one datagram to the multicast group and reads it from the Group listener. Only this delivery stage
        // reports a machine that does not deliver multicast traffic as Inconclusive, so a broken start still fails.
        private PluginResponseModel ReceiveFromGroup(PluginBase source, string sendArgument)
        {
            try
            {
                // Send through the real plugin, then read through the real plugin of the same automation.
                SendRule(plugin: NewSharedPlugin<SendUdpMessage>(source), argument: sendArgument);
                var receive = NewSharedPlugin<ReceiveUdpMessage>(source);

                return SendRule(plugin: receive, argument: "{{$ --Listener:Group --Timeout:3000}}");
            }
            catch (Exception exception) when (exception is TimeoutException or SocketException)
            {
                // Warn without failing, because multicast delivery depends on the network setup of the machine.
                var message = $"Warning: multicast traffic is not delivered on this machine. {exception.Message}";
                Assert.Inconclusive(message);

                return null;
            }
        }

        // Stops a named listener of the automation a plugin belongs to and returns the Stopped output, which is
        // "true" when a listener was open. Tests call it in cleanup so no socket outlives a test.
        private string StopListener(PluginBase source, string name)
        {
            // Stop through the real plugin, which is the only public way to reach the listeners.
            var plugin = NewSharedPlugin<StopUdpListener>(source);
            var response = SendRule(plugin, argument: $"{{{{$ --Name:{name}}}}}");

            return $"{response.Entity["Stopped"]}";
        }
    }
}
