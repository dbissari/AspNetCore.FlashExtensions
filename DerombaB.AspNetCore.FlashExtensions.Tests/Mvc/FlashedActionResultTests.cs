using DerombaB.AspNetCore.FlashExtensions.Mvc;
using Xunit;

namespace DerombaB.AspNetCore.FlashExtensions.Tests.Mvc
{
    public class FlashedActionResultTests
    {
        [Fact]
        public void NewFlashedActionResult_InitializesAnEmptyFlashMessagesCollection()
        {
            var flashedActionResult = new FlashedActionResult(null);

            Assert.Empty(flashedActionResult.FlashMessages);
        }

        [Theory]
        [InlineData("success", "title1", "body1")]
        [InlineData("info", "title2", "body2")]
        [InlineData("warning", "title3", "body3")]
        [InlineData("error", "title4", "body4")]
        [InlineData("custom", "title5", "body5")]
        public void AddFlash_AddsFlashMessageToCollection(string type, string title, string body)
        {
            var flashedActionResult = new FlashedActionResult(null);

            var flashMessage = new FlashMessage()
            {
                Type = type,
                Title = title,
                Body = body
            };

            flashedActionResult.AddFlash(type, title, body);

            Assert.Equal(1, flashedActionResult.FlashMessages.Count);
            Assert.Contains(flashedActionResult.FlashMessages, (fM) => flashMessage.Equals(fM));
        }

        // [Fact]
        // public async Task ExecuteResultAsync_AddsFlashMessagesToTempData_AndCallsInnerActionResultExecuteAsyncMethod()
        // {
        //     TODO: Find a wy to do it
        // }
    }
}