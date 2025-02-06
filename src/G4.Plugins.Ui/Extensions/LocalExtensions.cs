using G4.Models;
using G4.Plugins;
using G4.WebDriver.Extensions;
using G4.WebDriver.Remote;
using G4.WebDriver.Remote.Uia;

using System;
using System.Collections.Generic;

namespace G4.Extensions
{
    /// <summary>
    /// Provides a collection of extension methods for working with rules and rule-related functionality.
    /// This internal static class is intended for internal use within the application.
    /// </summary>
    internal static class LocalExtensions
    {
        /// <summary>
        /// Determines whether the specified <see cref="PluginDataModel"/> has no associated element or action.
        /// </summary>
        /// <param name="rule">The RuleModel to check.</param>
        /// <param name="element">The IWebElement element to be checked for association.</param>
        /// <returns><c>true</c> if neither an element is associated with the plugin data nor an action is tied to it; otherwise, <c>false</c>.</returns>
        public static bool AssertHasNoElement(this G4RuleModelBase rule, IWebElement element)
        {
            // Check if the 'element' is not null (default).
            var isElement = element != default;

            // Check if 'OnElement' property of 'rule' is not empty.
            var isFromAction = !string.IsNullOrEmpty(rule.OnElement);

            // Return 'true' if neither an element is associated nor it's tied to an action, 'false' otherwise.
            return !(isElement || isFromAction);
        }

        /// <summary>
        /// Determines whether the specified <see cref="PluginDataModel"/> has no associated element or action.
        /// </summary>
        /// <param name="pluginData">The <see cref="PluginDataModel"/> to check.</param>
        /// <returns><c>true</c> if neither an element is associated with the plugin data nor an action is tied to it; otherwise, <c>false</c>.</returns>
        public static bool AssertHasNoElement(this PluginDataModel pluginData)
        {
            // Determine if the 'Element' property is not the default value,
            // indicating that an element is associated with the plugin data.
            var isElement = pluginData.Element != default;

            // Check if the 'OnElement' property of the associated 'Rule' is not empty,
            // which would imply an action is tied to an element.
            var isFromAction = !string.IsNullOrEmpty(pluginData.Rule.OnElement);

            // Return true if neither an element is associated nor an action is defined
            // otherwise, return false.
            return !(isElement || isFromAction);
        }

        /// <summary>
        /// Creates a new instance of the element's type using its driver and id.
        /// </summary>
        /// <typeparam name="T">The type of the element. This type must implement <see cref="IWebElement"/>.</typeparam>
        /// <param name="element">The element to convert into a new instance.</param>
        /// <returns>A new instance of <typeparamref name="T"/> created with the same driver and id as the provided element. If the provided element is <c>null</c> or its default value, <c>null</c> is returned.</returns>
        /// <remarks>
        /// This method uses <see cref="Activator.CreateInstance(Type, object[])"/> to create a new instance of the specified type.
        /// It is assumed that the type's constructor accepts two parameters: the driver and the id.
        /// </remarks>
        public static IWebElement ConvertToElement<T>(this T element) where T : IWebElement
        {
            // Check if the element is null or equal to its default value.
            if (EqualityComparer<T>.Default.Equals(element, default))
            {
                // Return the default value (typically null) if element is not provided.
                return default;
            }

            // Retrieve the runtime type of the element.
            var type = typeof(T);

            // Get the driver and the identifier from the element.
            var driver = element.Driver;
            var id = element.Id;

            // Create a new instance of the element using its type, passing in the driver and id.
            // It is expected that the type T has a constructor that accepts these two parameters.
            return (T)Activator.CreateInstance(type, driver, id);
        }

        /// <summary>
        /// Retrieves a <see cref="IUser32Element"/> from the provided <see cref="PluginDataModel"/>.
        /// </summary>
        /// <param name="plugin">The plugin instance from which to retrieve the element.</param>
        /// <param name="pluginData">The data model containing information about the target element and rule.</param>
        /// <returns>
        /// A <see cref="IUser32Element"/> corresponding to the element specified in <paramref name="pluginData"/>,
        /// or <c>null</c> if no valid element is found.
        /// </returns>
        public static IUser32Element GetUser32Element(this PluginBase plugin, PluginDataModel pluginData)
        {
            // Initialize the IWebElement to null.
            IWebElement element = null;

            // Create a locator using the rule's locator type and value.
            var by = ByFactory.Get(locator: pluginData.Rule.Locator, locatorValue: pluginData.Rule.OnElement);

            // If the plugin's WebDriver is a UiaDriver, attempt to retrieve the element using the driver.
            if (plugin.WebDriver is UiaDriver driver)
            {
                // If PluginDataModel contains an element, use the driver to locate it.
                // Otherwise, search within the provided PluginDataModel's element.
                element = pluginData.Element == null
                    ? driver.GetElement(by)
                    : pluginData.Element.FindElement(by);
            }
            else
            {
                // For non-UiaDriver WebDrivers, attempt to retrieve the element using the plugin's GetElement method.
                plugin.GetElement(pluginData.Rule, element: pluginData.Element);
            }

            // If no valid element is found, return null.
            if (element == null)
            {
                return null;
            }

            // Ensure the element is compatible with IUser32Element.
            // If it's not, wrap it in a UiaElement, which implements IUser32Element.
            element = element is IUser32Element
                ? element
                : new UiaElement(driver: plugin.WebDriver, id: element.Id);

            // Return the element cast as IUser32Element.
            return element as IUser32Element;
        }
    }
}
