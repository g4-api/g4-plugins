using G4.Models;
using G4.WebDriver.Remote;

namespace G4.Extensions
{
    /// <summary>
    /// Provides a collection of extension methods for working with rules and rule-related functionality.
    /// This internal static class is intended for internal use within the application.
    /// </summary>
    internal static class LocalExtensions
    {
        /// <summary>
        /// Asserts whether a RuleModel has an associated IWebElement element or is tied to an action.
        /// </summary>
        /// <param name="rule">The RuleModel to check.</param>
        /// <param name="element">The IWebElement element to be checked for association.</param>
        /// <returns>
        ///   <c>true</c> if the RuleModel has no associated IWebElement element and is not tied to an action;
        ///   <c>false</c> if the RuleModel has an associated IWebElement element or is tied to an action.
        /// </returns>
        public static bool AssertHasNoElement(this G4RuleModelBase rule, IWebElement element)
        {
            // Check if the 'element' is not null (default).
            var isElement = element != default;

            // Check if 'OnElement' property of 'rule' is not empty.
            var isFromAction = !string.IsNullOrEmpty(rule.OnElement);

            // Return 'true' if neither an element is associated nor it's tied to an action, 'false' otherwise.
            return !(isElement || isFromAction);
        }
    }
}
