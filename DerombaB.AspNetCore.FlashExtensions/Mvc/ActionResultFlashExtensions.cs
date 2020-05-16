using Microsoft.AspNetCore.Mvc;

namespace DerombaB.AspNetCore.FlashExtensions.Mvc
{
    /// <summary>
    /// An extension class that adds functions to add flash messages to IActionResult objects.
    /// </summary>
    public static class ActionResultFlashExtensions
    {
        /// <summary>
        /// Adds a success flash message to the result returned.
        /// </summary>
        /// <param name="result">The result on which the flash message is added.</param>
        /// <param name="title">The title of the flash message to add.</param>
        /// <param name="body">The body/content of the flash message to add.</param>
        /// <returns>A result with a list of flash messages containing the added message.</returns>
        public static FlashedActionResult WithSuccessFlash(this IActionResult result, string title, string body)
        {
            return result.WithFlash("success", title, body);
        }

        /// <summary>
        /// Adds an info flash message to the result returned.
        /// </summary>
        /// <param name="result">The result on which the flash message is added.</param>
        /// <param name="title">The title of the flash message to add.</param>
        /// <param name="body">The body/content of the flash message to add.</param>
        /// <returns>A result with a list of flash messages containing the added message.</returns>
        public static FlashedActionResult WithInfoFlash(this IActionResult result, string title, string body)
        {
            return result.WithFlash("info", title, body);
        }

        /// <summary>
        /// Adds a warning flash message to the result returned.
        /// </summary>
        /// <param name="result">The result on which the flash message is added.</param>
        /// <param name="title">The title of the flash message to add.</param>
        /// <param name="body">The body/content of the flash message to add.</param>
        /// <returns>A result with a list of flash messages containing the added message.</returns>
        public static FlashedActionResult WithWarningFlash(this IActionResult result, string title, string body)
        {
            return result.WithFlash("warning", title, body);
        }

        /// <summary>
        /// Adds a danger flash message to the result returned.
        /// </summary>
        /// <param name="result">The result on which the flash message is added.</param>
        /// <param name="title">The title of the flash message to add.</param>
        /// <param name="body">The body/content of the flash message to add.</param>
        /// <returns>A result with a list of flash messages containing the added message.</returns>
        public static FlashedActionResult WithDangerFlash(this IActionResult result, string title, string body)
        {
            return result.WithFlash("danger", title, body);
        }

        /// <summary>
        /// Adds a flash message with a custom type to the result returned.
        /// </summary>
        /// <param name="result">The result on which the flash message is added.</param>
        /// <param name="type">The type of the flash message to add.</param>
        /// <param name="title">The title of the flash message to add.</param>
        /// <param name="body">The body/content of the flash message to add.</param>
        /// <returns>A result with a list of flash messages containing the added message.</returns>
        public static FlashedActionResult WithFlash(this IActionResult result, string type, string title, string body)
        {
            FlashedActionResult flashedResult;

            if (!result.GetType().Equals(typeof(FlashedActionResult)))
                flashedResult = new FlashedActionResult(result);
            else
                flashedResult = result as FlashedActionResult;

            flashedResult.AddFlash(type, title, body);

            return flashedResult;
        }
    }
}
