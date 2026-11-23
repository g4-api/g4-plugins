using G4.Extensions;
using G4.Plugins.Common.Actions;
using G4.UnitTests.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace G4.UnitTests.Plugins.Common
{
    [TestClass]
    [TestCategory("StopUdpListener")]
    [TestCategory("Udp")]
    [TestCategory("UnitTest")]
    public class StopUdpListenerTests : UdpTestBase
    {
        [TestMethod(DisplayName = "Verify that the StopUdpListener plugin manifest complies with the expected " +
            "structure and content.")]
        public override void ManifestComplianceTest()
        {
            // Ensure the plugin manifest matches the expected schema and required metadata.
            AssertManifest<StopUdpListener>();
        }

        [TestMethod(DisplayName = "Verify that the StopUdpListener plugin is correctly registered and operational.")]
        public override void NewPluginTest()
        {
            // Ensure the plugin type can be discovered and instantiated by the plugin framework.
            AssertPlugin<StopUdpListener>();
        }

        [TestMethod(DisplayName = "Verify that StopUdpListener without an argument stops the Default listener.")]
        public void StopUdpListenerDefaultTest()
        {
            // Arrange: a stop plugin whose automation will hold the Default listener.
            var plugin = NewPlugin<StopUdpListener>(Automation);

            try
            {
                // Arrange: start the Default listener in the automation of the stop plugin.
                SendRule(plugin: NewSharedPlugin<StartUdpListener>(source: plugin), argument: string.Empty);

                // Act: stop with a rule that carries no argument.
                var response = SendRule(plugin, argument: string.Empty);

                // Assert: the entity names the Default listener and reports that it was open.
                Assert.AreEqual(expected: "Default", actual: $"{response.Entity["Name"]}");
                Assert.AreEqual(expected: "true", actual: $"{response.Entity["Stopped"]}");
            }
            finally
            {
                // Close the listener when an assertion failed before the stop; a second stop is harmless.
                SendRule(plugin, argument: string.Empty);
            }
        }

        [TestMethod(DisplayName = "Verify that StopUdpListener stops only the named listener and frees its port, " +
            "while other listeners keep running.")]
        public void StopUdpListenerNamedTest()
        {
            // Arrange: a stop plugin whose automation will hold two listeners.
            var plugin = NewPlugin<StopUdpListener>(Automation);
            var start = NewSharedPlugin<StartUdpListener>(source: plugin);

            try
            {
                // Arrange: start two listeners in one automation and keep the port of the first.
                var entity = SendRule(plugin: start, argument: "{{$ --Name:First}}").Entity;
                var port = int.Parse($"{entity["Port"]}", CultureInfo.InvariantCulture);
                SendRule(plugin: start, argument: "{{$ --Name:Second}}");

                // Act: stop the first listener by name, in another letter case.
                var response = SendRule(plugin, argument: "{{$ --Name:FIRST}}");

                // Assert: the step reports the stop, and binding the freed port no longer throws.
                Assert.AreEqual(expected: "true", actual: $"{response.Entity["Stopped"]}");
                using var client = new UdpClient(localEP: new IPEndPoint(address: IPAddress.Any, port));

                // Assert: the second listener was still open, because stopping it now reports true.
                var second = SendRule(plugin, argument: "{{$ --Name:Second}}");
                Assert.AreEqual(expected: "true", actual: $"{second.Entity["Stopped"]}");
            }
            finally
            {
                // Close both listeners when an assertion failed early; stopping a closed name is harmless.
                SendRule(plugin, argument: "{{$ --Name:First}}");
                SendRule(plugin, argument: "{{$ --Name:Second}}");
            }
        }

        [TestMethod(DisplayName = "Verify that StopUdpListener passes and reports false when no listener has " +
            "the name.")]
        public void StopUdpListenerNotStartedTest()
        {
            // Arrange: an automation that never started a listener.
            var plugin = NewPlugin<StopUdpListener>(Automation);

            // Act: stop a name that does not exist.
            var response = SendRule(plugin, argument: "{{$ --Name:Missing}}");

            // Assert: the step passes and both channels report that nothing was stopped.
            var parameters = plugin.Invoker.Context.SessionParameters;
            var sessionStopped = $"{parameters["StopUdpListener:Stopped"]}".ConvertFromBase64();
            var sessionName = $"{parameters["StopUdpListener:Name"]}".ConvertFromBase64();
            Assert.AreEqual(expected: "false", actual: $"{response.Entity["Stopped"]}");
            Assert.AreEqual(expected: "false", actual: sessionStopped);
            Assert.AreEqual(expected: "Missing", actual: sessionName);
        }

        [TestMethod(DisplayName = "Verify that StopUdpListener is safe to repeat: the first stop reports true " +
            "and the second reports false.")]
        public void StopUdpListenerRepeatTest()
        {
            // Arrange: a stop plugin whose automation will hold one listener.
            var plugin = NewPlugin<StopUdpListener>(Automation);

            try
            {
                // Arrange: start one listener in the automation of the stop plugin.
                SendRule(plugin: NewSharedPlugin<StartUdpListener>(source: plugin), argument: "{{$ --Name:Once}}");

                // Act: stop the same name twice.
                var first = SendRule(plugin, argument: "{{$ --Name:Once}}");
                var second = SendRule(plugin, argument: "{{$ --Name:Once}}");

                // Assert: only the first call closed a listener, and neither call failed.
                Assert.AreEqual(expected: "true", actual: $"{first.Entity["Stopped"]}");
                Assert.AreEqual(expected: "false", actual: $"{second.Entity["Stopped"]}");
            }
            finally
            {
                // Close the listener when the first stop did not run; a repeated stop is harmless.
                SendRule(plugin, argument: "{{$ --Name:Once}}");
            }
        }

        [TestMethod(DisplayName = "Verify that a stopped listener is no longer available to a receive step.")]
        public void StopUdpListenerUnavailableTest()
        {
            // Arrange: a stop plugin whose automation will hold the listener.
            var plugin = NewPlugin<StopUdpListener>(Automation);

            try
            {
                // Arrange: start a listener and stop it again.
                SendRule(plugin: NewSharedPlugin<StartUdpListener>(source: plugin), argument: "{{$ --Name:Closed}}");
                SendRule(plugin, argument: "{{$ --Name:Closed}}");

                // Act: read from the stopped listener.
                var receive = NewSharedPlugin<ReceiveUdpMessage>(source: plugin);
                var exception = Assert.Throws<InvalidOperationException>(
                    () => SendRule(plugin: receive, argument: "{{$ --Listener:Closed --Timeout:100}}"));

                // Assert: the failure names the listener as not started.
                Assert.Contains(substring: "'Closed' is not started", value: exception.Message);
            }
            finally
            {
                // Close the listener when the arrange stop did not run; stopping a closed name is harmless.
                SendRule(plugin, argument: "{{$ --Name:Closed}}");
            }
        }
    }
}
