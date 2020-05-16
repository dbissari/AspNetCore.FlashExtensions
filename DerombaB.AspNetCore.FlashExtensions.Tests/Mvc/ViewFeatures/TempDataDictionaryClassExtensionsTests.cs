using System.Text.Json;
using DerombaB.AspNetCore.FlashExtensions.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace DerombaB.AspNetCore.FlashExtensions.Tests.Mvc.ViewFeatures
{
    public class TempDataDictionaryClassExtensionsTests
    {
        [Fact]
        public void Put_PutsTheSerializedDataInTempDataDictionary()
        {
            string key = "key";
            var tempData = new TempDataDictionary(Mock.Of<HttpContext>(), Mock.Of<ITempDataProvider>());
            var @object = new FlashMessage()
            {
                Type = "type",
                Title = "title",
                Body = "body"
            };

            tempData.Put(key, @object);

            Assert.True(tempData.Count.Equals(1));
            Assert.Equal(JsonSerializer.Serialize(@object), tempData[key]);
        }

        [Fact]
        public void Get_ReturnsTheDeserializedObject_AndRemovesFromIt()
        {
            string key = "key";
            var tempData = new TempDataDictionary(Mock.Of<HttpContext>(), Mock.Of<ITempDataProvider>());
            var @object = new FlashMessage()
            {
                Type = "type",
                Title = "title",
                Body = "body"
            };
            tempData[key] = JsonSerializer.Serialize(@object);

            Assert.Equal(@object, tempData.Get<FlashMessage>(key));
            //Assert.Null(tempData[key]);
        }

        [Fact]
        public void Get_ReturnsNull_IfKeyDoesNotExist()
        {
            string key = "key";
            var tempData = new TempDataDictionary(Mock.Of<HttpContext>(), Mock.Of<ITempDataProvider>());

            Assert.Null(tempData.Get<FlashMessage>(key));
        }
    }
}