using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

[assembly: InternalsVisibleTo("DerombaB.AspNetCore.FlashExtensions.Tests")]
namespace DerombaB.AspNetCore.FlashExtensions.Mvc.ViewFeatures
{
    /// <summary>
    /// An extension class that adds functions to manage class objects in TempDataDictionary.
    /// </summary>
    internal static class TempDataDictionaryClassExtensions
    {
        /// <summary>
        /// Adds a class object to TempDataDictionary.
        /// </summary>
        /// <typeparam name="T">The type of the object added.</typeparam>
        /// <param name="tempData">The TempDataDictionary on which we add the object.</param>
        /// <param name="key">The key associated to the class object to add.</param>
        /// <param name="value">The class object to add.</param>
        internal static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonSerializer.Serialize(value);
        }

        /// <summary>
        /// Gets a class object and removes it from TempDataDictionary.
        /// </summary>
        /// <typeparam name="T">The type of the object fetched.</typeparam>
        /// <param name="tempData">The TempDataDictionary from which we get the object.</param>
        /// <param name="key">The key associated to the class object to get.</param>
        /// <returns>The class object fetched. <c>null</c> if no object is associated to the given key.</returns>
        internal static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonSerializer.Deserialize<T>(o as string);
        }

        /// <summary>
        /// Gets a class object and without removing it from TempDataDictionary.
        /// </summary>
        /// <typeparam name="T">The type of the object fetched.</typeparam>
        /// <param name="tempData">The TempDataDictionary from which we get the object.</param>
        /// <param name="key">The key associated to the class object to get.</param>
        /// <returns>The class object fetched. <c>null</c> if no object is associated to the given key.</returns>
        internal static T Peek<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            var o = tempData.Peek(key) as string;
            return o == null ? null : JsonSerializer.Deserialize<T>(o);
        }
    }
}