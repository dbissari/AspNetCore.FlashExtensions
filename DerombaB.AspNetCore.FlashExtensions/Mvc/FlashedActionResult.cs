using System.Collections.Generic;
using System.Threading.Tasks;
using DerombaB.AspNetCore.FlashExtensions.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace DerombaB.AspNetCore.FlashExtensions.Mvc
{
    /// <summary>
    /// A custom action result with a list of flash messages that are added to context on execution.
    /// </summary>
    public class FlashedActionResult : IActionResult
    {
        private IActionResult Result { get; }

        public List<FlashMessage> FlashMessages { get; } = new List<FlashMessage>();

        public FlashedActionResult(IActionResult result)
        {
            Result = result;
        }

        /// <summary>
        /// Adds a flash message to the list.
        /// </summary>
        /// <param name="type">The type of the flash message to add.</param>
        /// <param name="title">The title of the flash message to add.</param>
        /// <param name="body">The body/content of the flash message to add.</param>
        public void AddFlash(string type, string title, string body)
        {
            FlashMessages.Add(new FlashMessage()
            {
                Type = type,
                Title = title,
                Body = body
            });
        }

        /// <inheritdoc/>
        /// <remarks>Adds the flash messages list to temp data in the context.</remarks>
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var factory = context.HttpContext.RequestServices.GetService<ITempDataDictionaryFactory>();

            var tempData = factory.GetTempData(context.HttpContext);
            tempData.Put("FlashMessages", FlashMessages);

            await Result.ExecuteResultAsync(context);
        }
    }
}