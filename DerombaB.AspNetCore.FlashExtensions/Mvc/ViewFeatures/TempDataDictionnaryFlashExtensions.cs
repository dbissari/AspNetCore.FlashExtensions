using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DerombaB.AspNetCore.FlashExtensions.Mvc.ViewFeatures
{
    /// <summary>
    /// An extension class that adds functions to manage flash messages in TempDataDictionary.
    /// </summary>
    public static class TempDataDictionnaryFlashExtensions
    {
        /// <summary>
        /// Gets the list of flash messages and removes it from the current TempDataDictionary.
        /// </summary>
        /// <param name="tempData">The TempDataDictionary from which we get the list of flash messages.</param>
        /// <returns>The list of flash messages.</returns>
        public static List<FlashMessage> GetAllFlashMessages(this ITempDataDictionary tempData)
        {
            return tempData.Peek<List<FlashMessage>>("FlashMessages") ?? new List<FlashMessage>();
        }
    }
}