using G4.Extensions;
using G4.Models;
using G4.Plugins;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Extensions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("ReceiveUdpMessage")]
    [TestCategory("Udp")]
    [TestCategory("UnitTest")]
    public class ReceiveUdpMessageTests : UdpTestBase
    {
        // Name of the listener every test of this class starts in its own automation.
        private const string ListenerName = "Capture";

        [TestMethod(DisplayName = "Verify that the ReceiveUdpMessage plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin manifest matches the expected schema and required metadata.
            AssertManifest<ReceiveUdpMessage>();
        }

        [TestMethod(DisplayName = "Verify that the ReceiveUdpMessage plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin type can be discovered and instantiated by the plugin framework.
            AssertPlugin<ReceiveUdpMessage>();
        }

        [TestMethod(DisplayName = "Verify that a listener with a small buffer drops its oldest datagram when one " +
            "more arrives.")]
        public void ReceiveUdpMessageBufferSizeTest()
        {
            // Arrange: a receive plugin whose automation will hold a listener that keeps two datagrams.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener receives three datagrams, one more than it keeps.
                var port = StartListener(source: plugin, arguments: "--BufferSize:2");
                SendText(port, "a", "b", "c");

                // Act: take the last datagram first, which proves all three reached the listener.
                var last = ReceiveMessages(plugin, arguments: "--Pattern:^c$ --Timeout:5000");
                var remaining = ReceiveMessages(plugin, arguments: "--Timeout:1000");

                // Assert: the oldest datagram was dropped, so the only one left is the second.
                Assert.AreEqual(expected: "c", actual: $"{last.Entity["Message"]}");
                Assert.AreEqual(expected: "b", actual: $"{remaining.Entity["Message"]}");
                Assert.Throws<TimeoutException>(() => ReceiveMessages(plugin, arguments: "--Timeout:200"));
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage waits for the number of datagrams named by " +
            "Count and publishes them in arrival order.")]
        public void ReceiveUdpMessageCountTest()
        {
            // Arrange: a receive plugin whose automation will hold the listener.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener receives three datagrams before the read.
                var port = StartListener(source: plugin, arguments: string.Empty);
                SendText(port, "one", "two", "three");

                // Act: wait for all three.
                var response = ReceiveMessages(plugin, arguments: "--Count:3 --Timeout:5000");

                // Assert: the first datagram and the count are published.
                Assert.AreEqual(expected: "one", actual: $"{response.Entity["Message"]}");
                Assert.AreEqual(expected: "3", actual: $"{response.Entity["MessageCount"]}");

                // Assert: the list holds every datagram in arrival order.
                Assert.AreEqual(expected: "one,two,three", actual: ReadData(response));
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage counts only datagrams that match Pattern and " +
            "leaves the others buffered in arrival order.")]
        public void ReceiveUdpMessageFilterTest()
        {
            // Arrange: a receive plugin whose automation will hold the listener.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener receives two informational datagrams and one alarm.
                var port = StartListener(source: plugin, arguments: string.Empty);
                SendText(port, "INFO 1", "ALARM 2", "INFO 3");

                // Act: read the alarm first, then everything that is left.
                var alarm = ReceiveMessages(plugin, arguments: "--Pattern:^ALARM --Timeout:5000");
                var others = ReceiveMessages(plugin, arguments: "--Count:2 --Timeout:5000");

                // Assert: the filter took the alarm only, and the other datagrams kept their order.
                Assert.AreEqual(expected: "ALARM 2", actual: $"{alarm.Entity["Message"]}");
                Assert.AreEqual(expected: "1", actual: $"{alarm.Entity["MessageCount"]}");
                Assert.AreEqual(expected: "INFO 1,INFO 3", actual: ReadData(others));
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that a flow records a timeout exception when ReceiveUdpMessage gets no " +
            "datagram, and still closes the listener at the end.")]
        public void ReceiveUdpMessageFlowTimeoutTest()
        {
            // Arrange: a flow that starts a listener and waits for a datagram nobody sends.
            var port = UdpTestServer.GetFreePort();
            var rules = new[]
            {
                new ActionRuleModel
                {
                    Argument = $"{{{{$ --Name:{ListenerName} --Port:{port}}}}}",
                    PluginName = "StartUdpListener"
                },
                new ActionRuleModel
                {
                    Argument = $"{{{{$ --Listener:{ListenerName} --Timeout:300}}}}",
                    PluginName = "ReceiveUdpMessage"
                }
            };

            // Act: run the flow through the full automation pipeline.
            var responseModel = Invoke(rules);

            // Assert: the receive step is reported as a timeout of the flow.
            var exceptions = responseModel.GetExceptions();
            Assert.Contains(predicate: i => i.Type == nameof(TimeoutException), collection: exceptions);

            // Arrange: a plugin of a new automation for the port check.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Assert: the listener was closed with the automation, so a new listener can bind the same port.
                Assert.AreEqual(expected: port, actual: StartListener(source: plugin, port));
            }
            finally
            {
                // Close the listener this check opened so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage fails on a malformed or missing argument, with a " +
            "message that names it, before it waits.")]
        #region *** Data Set ***
        [DataRow("{{$ --Timeout:5000}}", "'Listener'")]
        [DataRow("{{$ --Listener:Missing --Timeout:5000}}", "'Missing'")]
        [DataRow("{{$ --Port:0 --Timeout:5000}}", "'Port'")]
        [DataRow("{{$ --Port:70000 --Timeout:5000}}", "'Port'")]
        [DataRow("{{$ --Port:abc --Timeout:5000}}", "'Port'")]
        [DataRow("{{$ --Port:1 --Timeout:5000 --Count:x}}", "'Count'")]
        [DataRow("{{$ --Port:1 --Timeout:5000 --RemotePort:99999}}", "'RemotePort'")]
        [DataRow("{{$ --Port:1 --Timeout:5000 --ResponseFormat:Json}}", "'ResponseFormat'")]
        [DataRow("{{$ --Port:1 --Timeout:5000 --Encoding:no-such-encoding}}", "'Encoding'")]
        [DataRow("{{$ --Port:1 --Timeout:5000 --Pattern:(unclosed}}", "'Pattern'")]
        [DataRow("{{$ --Port:1 --Timeout:5000 --LocalAddress:localhost}}", "'LocalAddress'")]
        [DataRow("{{$ --Port:1 --Timeout:5000 --MulticastGroup:group}}", "'MulticastGroup'")]
        #endregion
        public void ReceiveUdpMessageInvalidArgumentTest(string argument, string argumentName)
        {
            // Arrange: a plugin that receives one malformed argument and a clock for the wait it must not start.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);
            var stopwatch = Stopwatch.StartNew();

            // Act: run the step with the malformed argument.
            var exception = Assert.Throws<InvalidOperationException>(() => SendRule(plugin, argument));

            // Assert: the failure names the argument and came well before the five-second wait.
            Assert.Contains(substring: argumentName, value: exception.Message);
            Assert.IsLessThan(upperBound: 4000, value: stopwatch.ElapsedMilliseconds);
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage reads a datagram that a listener buffered before " +
            "the step started, with its sender.")]
        public void ReceiveUdpMessageListenerTest()
        {
            // Arrange: a receive plugin whose automation will hold the listener.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener receives a datagram while no step is reading.
                var port = StartListener(source: plugin, arguments: string.Empty);
                var sourcePort = UdpTestServer.SendDatagram(port, data: Encoding.UTF8.GetBytes("reading=42"));

                // Act: read from the listener.
                var response = ReceiveMessages(plugin, arguments: "--Timeout:5000");

                // Assert: the entity carries the text, the count, and the sender.
                Assert.AreEqual(expected: "reading=42", actual: $"{response.Entity["Message"]}");
                Assert.AreEqual(expected: "1", actual: $"{response.Entity["MessageCount"]}");
                Assert.AreEqual(expected: "127.0.0.1", actual: $"{response.Entity["RemoteAddress"]}");
                Assert.AreEqual(expected: $"{sourcePort}", actual: $"{response.Entity["RemotePort"]}");

                // Assert: the session carries the same text as Base64 under the plugin namespace.
                var parameters = plugin.Invoker.Context.SessionParameters;
                var message = $"{parameters["ReceiveUdpMessage:Message"]}".ConvertFromBase64();
                Assert.AreEqual(expected: "reading=42", actual: message);
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage with NoEntity publishes its outputs to the " +
            "session and leaves the response entity empty.")]
        public void ReceiveUdpMessageNoEntityTest()
        {
            // Arrange: a receive plugin whose automation will hold the listener.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener already holds one datagram.
                var port = StartListener(source: plugin, arguments: string.Empty);
                SendText(port, "private");

                // Act: read the datagram with the entity suppressed.
                var response = ReceiveMessages(plugin, arguments: "--Timeout:5000 --NoEntity");

                // Assert: the entity carries no output, while the session still holds the text as Base64.
                var parameters = plugin.Invoker.Context.SessionParameters;
                var message = $"{parameters["ReceiveUdpMessage:Message"]}".ConvertFromBase64();
                Assert.IsFalse(response.Entity.ContainsKey("Message"));
                Assert.AreEqual(expected: "private", actual: message);
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage fails when fewer datagrams than Count arrive, " +
            "and leaves the ones that arrived buffered for a later read.")]
        public void ReceiveUdpMessagePartialCountTest()
        {
            // Arrange: a receive plugin whose automation will hold the listener.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener receives two datagrams.
                var port = StartListener(source: plugin, arguments: string.Empty);
                SendText(port, "first", "second");

                // Act: ask for three datagrams, one more than arrive.
                var exception = Assert.Throws<TimeoutException>(
                    () => ReceiveMessages(plugin, arguments: "--Count:3 --Timeout:1000"));

                // Assert: the failure says how many of the requested datagrams arrived.
                Assert.Contains(substring: "2 of 3", value: exception.Message);

                // Assert: the two datagrams are still buffered and a later read returns them in order.
                var response = ReceiveMessages(plugin, arguments: "--Count:2 --Timeout:5000");
                Assert.AreEqual(expected: "first,second", actual: ReadData(response));
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage binds the port named by Port, receives a " +
            "datagram sent during its wait, and frees the port when it returns.")]
        public void ReceiveUdpMessagePortTest()
        {
            // Arrange: a sender that repeats a datagram until the test stops it, like a device heartbeat.
            var port = UdpTestServer.GetFreePort();
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);
            using var cancellation = new CancellationTokenSource();
            var sender = Task.Run(
                action: () => SendHeartbeats(port, cancellationToken: cancellation.Token),
                cancellationToken: TestContext.CancellationToken);

            try
            {
                // Act: bind the port for the length of the step and wait for one datagram.
                var argument = $"{{{{$ --Port:{port} --Timeout:5000}}}}";
                var response = SendRule(plugin, argument);

                // Assert: the step received the heartbeat.
                Assert.AreEqual(expected: "heartbeat", actual: $"{response.Entity["Message"]}");

                // Assert: the step closed its socket, so a listener can bind the same port right away.
                Assert.AreEqual(expected: port, actual: StartListener(source: plugin, port));
            }
            finally
            {
                // Stop the sender and wait for it, so no datagram is sent after the test ends.
                cancellation.Cancel();
                sender.Wait(cancellationToken: TestContext.CancellationToken);

                // Close the listener the port check opened; stopping a closed name is harmless.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage refines the first datagram through OnElement " +
            "and RegularExpression and keeps the full text in the list.")]
        public void ReceiveUdpMessageRefineTest()
        {
            // Arrange: the JSON payload and a receive plugin whose automation will hold the listener.
            const string json = "{\"reading\":{\"value\":\"42 kg\"}}";
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener holds one JSON datagram.
                var port = StartListener(source: plugin, arguments: string.Empty);
                SendText(port, json);

                // Act: read the datagram through a rule that selects one field and keeps its digits.
                var rule = new ActionRuleModel
                {
                    Argument = $"{{{{$ --Listener:{ListenerName} --Timeout:5000}}}}",
                    OnElement = "$.reading.value",
                    PluginName = "ReceiveUdpMessage",
                    Reference = new G4PluginReferenceModel { Id = $"{Guid.NewGuid()}" },
                    RegularExpression = "\\d+"
                };
                var response = plugin.Send(new PluginDataModel { Rule = rule });

                // Assert: the message is the refined value, and the list keeps the datagram as it arrived.
                Assert.AreEqual(expected: "42", actual: $"{response.Entity["Message"]}");
                Assert.AreEqual(expected: json, actual: ReadData(response));
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage counts only datagrams from the sender named by " +
            "RemoteHost and RemotePort.")]
        public void ReceiveUdpMessageRemoteFilterTest()
        {
            // Arrange: a receive plugin whose automation will hold the listener.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener receives one datagram from each of two senders.
                var port = StartListener(source: plugin, arguments: string.Empty);
                UdpTestServer.SendDatagram(port, data: Encoding.UTF8.GetBytes("from-first"));
                var secondPort = UdpTestServer.SendDatagram(port, data: Encoding.UTF8.GetBytes("from-second"));

                // Act: read only what the second sender sent, naming the host by name and the port by number.
                var arguments = $"--RemoteHost:localhost --RemotePort:{secondPort} --Timeout:5000";
                var response = ReceiveMessages(plugin, arguments);

                // Assert: the filter skipped the datagram of the first sender.
                Assert.AreEqual(expected: "from-second", actual: $"{response.Entity["Message"]}");

                // Assert: a host that sent nothing matches no datagram, although one is still buffered.
                Assert.Throws<TimeoutException>(
                    () => ReceiveMessages(plugin, arguments: "--RemoteHost:192.0.2.1 --Timeout:200"));
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage publishes datagrams as hexadecimal or Base64 " +
            "text according to the ResponseFormat argument.")]
        #region *** Data Set ***
        [DataRow("Hex", "00FF10")]
        [DataRow("hex", "00FF10")]
        [DataRow("Base64", "AP8Q")]
        #endregion
        public void ReceiveUdpMessageResponseFormatTest(string responseFormat, string expected)
        {
            // Arrange: a receive plugin whose automation will hold the listener.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);

            try
            {
                // Arrange: the listener holds three bytes that are not valid text.
                var port = StartListener(source: plugin, arguments: string.Empty);
                UdpTestServer.SendDatagram(port, data: [0x00, 0xFF, 0x10]);

                // Act: read the datagram in the requested text form.
                var response = ReceiveMessages(plugin, arguments: $"--ResponseFormat:{responseFormat} --Timeout:5000");

                // Assert: the message and the list keep every byte.
                Assert.AreEqual(expected, actual: $"{response.Entity["Message"]}");
                Assert.AreEqual(expected, actual: ReadData(response));
            }
            finally
            {
                // Close the listener so its port is free for the next test.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage reports a listener another step stops during the " +
            "wait as stopped, not as a timeout, and returns before its timeout.")]
        public void ReceiveUdpMessageStoppedTest()
        {
            // Arrange: a receive plugin whose automation will hold the listener, and a clock for the wait.
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Arrange: start the listener and wait on it from a dedicated thread, like a parallel lane, so the
                // wait never queues behind a busy thread pool.
                StartListener(source: plugin, arguments: string.Empty);
                var waiting = Task.Factory.StartNew(
                    function: () => ReceiveMessages(plugin, arguments: "--Timeout:10000"),
                    cancellationToken: TestContext.CancellationToken,
                    creationOptions: TaskCreationOptions.LongRunning,
                    scheduler: TaskScheduler.Default);

                // Act: give the receive step time to reach its wait, then stop the listener.
                Thread.Sleep(millisecondsTimeout: 1000);
                StopListener(source: plugin);

                // Assert: the step fails with an InvalidOperationException.
                var exception = Assert.ThrowsExactly<AggregateException>(
                    () => waiting.Wait(cancellationToken: TestContext.CancellationToken));
                var failure = exception.InnerException;
                Assert.IsInstanceOfType<InvalidOperationException>(failure);

                // Assert: skip with a warning when the stop reached the listener before the step looked it up.
                AssertWaitStarted(failure);

                // Assert: the failure names the stop, and it came well before the ten-second timeout.
                Assert.Contains(substring: "was stopped while the step was waiting", value: failure.Message);
                Assert.IsLessThan(upperBound: 5000, value: stopwatch.ElapsedMilliseconds);
            }
            finally
            {
                // Close the listener when the stop under test did not run; stopping a closed name is harmless.
                StopListener(source: plugin);
            }
        }

        [TestMethod(DisplayName = "Verify that ReceiveUdpMessage fails with a timeout after the wait named by " +
            "Timeout, written as milliseconds or as a time span.")]
        #region *** Data Set ***
        [DataRow("400", 400)]
        [DataRow("00:00:01", 1000)]
        #endregion
        public void ReceiveUdpMessageTimeoutTest(string timeout, int expectedMilliseconds)
        {
            // Arrange: a free port nobody sends to, and a clock for the wait.
            var port = UdpTestServer.GetFreePort();
            var plugin = NewPlugin<ReceiveUdpMessage>(Automation);
            var argument = $"{{{{$ --Port:{port} --Timeout:{timeout}}}}}";
            var stopwatch = Stopwatch.StartNew();

            // Act: wait on the silent port.
            var exception = Assert.Throws<TimeoutException>(() => SendRule(plugin, argument));
            stopwatch.Stop();

            // Assert: the failure reports the count and the port.
            Assert.Contains(substring: "0 of 1", value: exception.Message);
            Assert.Contains(substring: $"{port}", value: exception.Message);

            // Assert: the step waited for the requested time, not for the five-second default.
            var elapsed = (int)stopwatch.ElapsedMilliseconds;
            Assert.IsGreaterThanOrEqualTo(lowerBound: expectedMilliseconds - 100, value: elapsed);
            Assert.IsLessThan(upperBound: 4000, value: elapsed);
        }

        // Reports the stopped-listener test as Inconclusive when the stop reached the listener before the receive
        // step looked it up. The test has no signal for "the step is waiting", so a starved machine can stop the
        // listener first; the step then reports the listener as not started, which is correct but not under test.
        private static void AssertWaitStarted(Exception failure)
        {
            // Warn without failing, because the order then depends on the scheduling of the machine.
            if (failure.Message.Contains("is not started", StringComparison.Ordinal))
            {
                var message = $"Warning: the listener was stopped before the receive step started. {failure.Message}";
                Assert.Inconclusive(message);
            }
        }

        // Reads the Data values of the published datagram list as one comma-separated text, in list order.
        private static string ReadData(PluginResponseModel response)
        {
            // Parse the JSON array the plugin publishes and keep the payload of every item.
            using var document = JsonDocument.Parse($"{response.Entity["Messages"]}");
            var data = document.RootElement.EnumerateArray().Select(i => i.GetProperty("Data").GetString());

            return string.Join(separator: ',', values: data);
        }

        // Reads from the test listener through a receive plugin, with extra ReceiveUdpMessage arguments, and
        // returns the response. Failures reach the test as the exception the plugin threw.
        private static PluginResponseModel ReceiveMessages(PluginBase plugin, string arguments)
        {
            // Name the test listener once, so each test states only the arguments it is about.
            return SendRule(plugin, argument: $"{{{{$ --Listener:{ListenerName} {arguments}}}}}");
        }

        // Sends a heartbeat datagram to a loopback port every 50 milliseconds until the token is cancelled. A send
        // failure ends the loop quietly, so the test reports its own assertion instead of the sender error.
        private static void SendHeartbeats(int port, CancellationToken cancellationToken)
        {
            try
            {
                // Repeat until the test cancels, like a device that announces itself.
                while (!cancellationToken.WaitHandle.WaitOne(millisecondsTimeout: 50))
                {
                    UdpTestServer.SendDatagram(port, data: Encoding.UTF8.GetBytes("heartbeat"));
                }
            }
            catch (SocketException)
            {
                // The loopback send failed; the receive step then times out and the test reports it.
            }
        }

        // Sends each text as one UTF-8 datagram to a loopback port, in the given order.
        private static void SendText(int port, params string[] messages)
        {
            // Send one datagram per text; the loopback interface keeps the order.
            foreach (var message in messages)
            {
                UdpTestServer.SendDatagram(port, data: Encoding.UTF8.GetBytes(message));
            }
        }

        // Starts the test listener on a fixed port in the automation of a plugin and returns the bound port.
        private int StartListener(PluginBase source, int port)
        {
            // Route through the complete overload with the port as the only extra argument.
            return StartListener(source, arguments: $"--Port:{port}");
        }

        // Starts the test listener in the automation of a plugin, with extra StartUdpListener arguments, and
        // returns the bound port. Without a Port argument the system assigns a free one.
        private int StartListener(PluginBase source, string arguments)
        {
            // Start through the real plugin, which is the only public way to open a listener.
            var plugin = NewSharedPlugin<StartUdpListener>(source);
            var response = SendRule(plugin, argument: $"{{{{$ --Name:{ListenerName} {arguments}}}}}");

            return int.Parse($"{response.Entity["Port"]}", CultureInfo.InvariantCulture);
        }

        // Stops the test listener of the automation a plugin belongs to. Tests call it in cleanup so no socket
        // outlives a test.
        private void StopListener(PluginBase source)
        {
            // Stop through the real plugin; a listener that is already closed is not an error.
            var plugin = NewSharedPlugin<StopUdpListener>(source);
            SendRule(plugin, argument: $"{{{{$ --Name:{ListenerName}}}}}");
        }
    }
}
