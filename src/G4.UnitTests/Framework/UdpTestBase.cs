using G4.Models;
using G4.Plugins;

using System;

namespace G4.UnitTests.Framework
{
    /// <summary>
    /// Provides the plugin helpers shared by the UDP plugin test classes.
    /// </summary>
    /// <remarks>
    /// The UDP tests send rules straight to a plugin instead of running a whole automation, and they chain several
    /// plugins of one automation, such as a start, a send, and a stop. Named listeners belong to the automation
    /// invoker, so every plugin of a test shares the invoker of the first one. This base class holds those two
    /// helpers once, so the four test classes cannot drift apart.
    /// </remarks>
    public abstract class UdpTestBase : TestBase
    {
        #region *** Methods      ***
        /// <summary>
        /// Creates a plugin that shares the automation invoker of an earlier plugin.
        /// </summary>
        /// <remarks>
        /// <c>NewPlugin</c> creates a new invoker for every plugin. Named listeners belong to the invoker, so the new
        /// plugin reaches the listeners the earlier one started only through the same invoker, like two steps of one
        /// automation.
        /// </remarks>
        /// <typeparam name="T">The plugin type to create.</typeparam>
        /// <param name="source">The plugin whose invoker the new plugin uses.</param>
        /// <returns>The new plugin.</returns>
        protected T NewSharedPlugin<T>(PluginBase source)
            where T : PluginBase
        {
            // Replace the invoker the factory created with the one that already owns the listeners.
            var plugin = NewPlugin<T>(Automation);
            plugin.Invoker = source.Invoker;

            return plugin;
        }

        /// <summary>
        /// Sends one argument straight to a plugin and returns its response.
        /// </summary>
        /// <remarks>
        /// The rule gets a unique reference, which the plugin pipeline requires when the rule is not initialized
        /// through an automation run. The engine rejects a missing mandatory parameter in the response; any other
        /// failure reaches the test as the exception the plugin threw.
        /// </remarks>
        /// <param name="plugin">The plugin that receives the rule.</param>
        /// <param name="argument">The rule argument, such as <c>{{$ --Name:Telemetry}}</c>.</param>
        /// <returns>The plugin response.</returns>
        protected static PluginResponseModel SendRule(PluginBase plugin, string argument)
        {
            // Build the rule the way a flow sends it and give it a unique reference.
            var rule = new ActionRuleModel
            {
                Argument = argument,
                PluginName = plugin.GetType().Name,
                Reference = new G4PluginReferenceModel { Id = $"{Guid.NewGuid()}" }
            };

            return plugin.Send(new PluginDataModel { Rule = rule });
        }
        #endregion
    }
}
