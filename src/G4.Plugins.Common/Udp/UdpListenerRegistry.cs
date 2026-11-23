using G4.Plugins.Engine;

using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace G4.Plugins.Common.Udp
{
    /// <summary>
    /// Keeps the named UDP listeners of every running automation, so one step can start a listener and later steps
    /// can read from it, send through it, or stop it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Listeners are grouped by the automation invoker that runs the flow. Every step of one automation shares the
    /// invoker, including steps that run on parallel lanes, so a listener is visible to the whole flow and to no
    /// other flow. Session parameters are not used, because they hold text and each parallel lane gets its own copy.
    /// </para>
    /// <para>
    /// A listener ends when a step stops it or when its automation finishes: the registry subscribes to the
    /// <see cref="IAutomationInvoker.AutomationInvoked"/> event of the invoker and disposes what the flow left open.
    /// The table holds its invokers weakly, so a finished invoker is collected as usual.
    /// </para>
    /// </remarks>
    internal static class UdpListenerRegistry
    {
        #region *** Constants    ***
        /// <summary>
        /// Specifies the listener name a step gets when it names none.
        /// </summary>
        public const string DefaultName = "Default";

        // Maps each automation invoker to its named listeners. Names ignore case, like G4 parameter names.
        private static readonly ConditionalWeakTable<IAutomationInvoker, ConcurrentDictionary<string, UdpListener>>
            Listeners = new();
        #endregion

        #region *** Methods      ***
        /// <summary>
        /// Registers a started listener under its name for the automation of the invoker.
        /// </summary>
        /// <param name="invoker">The invoker that runs the automation.</param>
        /// <param name="listener">The listener to register; the registry owns it from here on.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the automation already has a listener with the same name. The caller still owns the new
        /// listener then and disposes it.
        /// </exception>
        public static void Add(IAutomationInvoker invoker, UdpListener listener)
        {
            // Keep the first listener of a name; a second start with the same name is a flow error.
            var listeners = GetListeners(invoker);
            var isAdded = listeners.TryAdd(key: listener.Name, value: listener);

            if (!isAdded)
            {
                var message = NewStartedMessage(name: listener.Name);
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Stops every listener the automation of the invoker still holds.
        /// </summary>
        /// <param name="invoker">The invoker that runs the automation.</param>
        public static void Clear(IAutomationInvoker invoker)
        {
            // Skip an invoker that never started a listener.
            if (!Listeners.TryGetValue(invoker, out var listeners))
            {
                return;
            }

            // Remove each listener before disposing it, so a step on another lane cannot pick up a closed one.
            foreach (var name in listeners.Keys)
            {
                if (listeners.TryRemove(name, out var listener))
                {
                    listener.Dispose();
                }
            }
        }

        /// <summary>
        /// Finds a started listener by name.
        /// </summary>
        /// <param name="invoker">The invoker that runs the automation.</param>
        /// <param name="name">The listener name.</param>
        /// <returns>The listener, or null when the automation has no listener with that name.</returns>
        public static UdpListener Find(IAutomationInvoker invoker, string name)
        {
            // Read without creating an entry, so a lookup alone never subscribes to the invoker.
            if (!Listeners.TryGetValue(invoker, out var listeners))
            {
                return null;
            }

            return listeners.TryGetValue(name, out var listener)
                ? listener
                : null;
        }

        /// <summary>
        /// Gets a started listener by name and fails when the automation has none.
        /// </summary>
        /// <param name="invoker">The invoker that runs the automation.</param>
        /// <param name="name">The listener name.</param>
        /// <returns>The listener.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no listener with that name is started.
        /// </exception>
        public static UdpListener Get(IAutomationInvoker invoker, string name)
        {
            // Resolve the listener and name the missing one, so the step failure points at the flow error.
            var listener = Find(invoker, name);

            if (listener is null)
            {
                var message = $"The UDP listener '{name}' is not started. Start it with StartUdpListener first.";
                throw new InvalidOperationException(message);
            }

            return listener;
        }

        /// <summary>
        /// Creates the failure message for a listener name that is already started in the automation.
        /// </summary>
        /// <remarks>
        /// StartUdpListener checks the name before it binds a socket and the registry checks it again when two
        /// lanes start the same name at once; both report the same text through this member.
        /// </remarks>
        /// <param name="name">The listener name.</param>
        /// <returns>The failure message.</returns>
        public static string NewStartedMessage(string name)
        {
            // Name the listener and the fix, so the step failure reads without the flow.
            return $"The UDP listener '{name}' is already started. Stop it before starting it again.";
        }

        /// <summary>
        /// Stops one listener and removes it from the automation of the invoker.
        /// </summary>
        /// <param name="invoker">The invoker that runs the automation.</param>
        /// <param name="name">The listener name.</param>
        /// <returns><c>true</c> when a listener was stopped; <c>false</c> when none had that name.</returns>
        public static bool Remove(IAutomationInvoker invoker, string name)
        {
            // Report a missing listener instead of failing, so a cleanup step can run more than once.
            if (!Listeners.TryGetValue(invoker, out var listeners))
            {
                return false;
            }

            // Take the listener out of the map first, so a step on another lane cannot pick up a closed one.
            var isRemoved = listeners.TryRemove(name, out var listener);

            if (!isRemoved)
            {
                return false;
            }

            // Close the socket so the port is free for the next listener.
            listener.Dispose();

            return true;
        }

        // Gets the listeners of an invoker and creates the entry on first use. Only the lane whose map the table
        // keeps subscribes to the end of the automation, so two lanes that start their first listener at the same
        // time leave exactly one subscription, and listeners a flow leaves open are closed with it.
        private static ConcurrentDictionary<string, UdpListener> GetListeners(IAutomationInvoker invoker)
        {
            // Return the map an earlier step created, which is the common case after the first listener.
            if (Listeners.TryGetValue(invoker, out var listeners))
            {
                return listeners;
            }

            // Offer a new map; the table keeps the first one offered, and a lane that loses the race reads it back.
            var created = new ConcurrentDictionary<string, UdpListener>(StringComparer.OrdinalIgnoreCase);
            var isCreated = Listeners.TryAdd(invoker, created);

            if (!isCreated)
            {
                // Read the winning map; the entry cannot vanish here, because the caller holds the invoker alive.
                Listeners.TryGetValue(invoker, out listeners);
                return listeners;
            }

            // Close every open listener when the automation ends, whatever its final status is.
            invoker.AutomationInvoked += (_, _) => Clear(invoker);

            return created;
        }
        #endregion
    }
}
