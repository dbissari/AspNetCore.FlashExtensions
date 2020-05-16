using System.Linq;
using DerombaB.AspNetCore.FlashExtensions.Mvc;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DerombaB.AspNetCore.FlashExtensions.Tests.Mvc
{
    public class ActionResultFlashExtensionsTests
    {
        [Fact]
        public void WithSuccessFlash_AddsAFlashMessageOfSuccessType()
        {
            var viewResult = new ViewResult();

            var flashedResult = Assert.IsType<FlashedActionResult>(viewResult.WithSuccessFlash("title1", "body1"));

            Assert.True(flashedResult.FlashMessages.Count.Equals(1));
            Assert.Equal("success", flashedResult.FlashMessages.FirstOrDefault().Type);
            Assert.Equal("title1", flashedResult.FlashMessages.FirstOrDefault().Title);
            Assert.Equal("body1", flashedResult.FlashMessages.FirstOrDefault().Body);
        }

        [Fact]
        public void WithInfoFlash_AddsAFlashMessageOfInfoType()
        {
            var viewResult = new ViewResult();

            var flashedResult = Assert.IsType<FlashedActionResult>(viewResult.WithInfoFlash("title2", "body2"));

            Assert.True(flashedResult.FlashMessages.Count.Equals(1));
            Assert.Equal("info", flashedResult.FlashMessages.FirstOrDefault().Type);
            Assert.Equal("title2", flashedResult.FlashMessages.FirstOrDefault().Title);
            Assert.Equal("body2", flashedResult.FlashMessages.FirstOrDefault().Body);
        }

        [Fact]
        public void WithWarningFlash_AddsAFlashMessageOfWarningType()
        {
            var viewResult = new ViewResult();

            var flashedResult = Assert.IsType<FlashedActionResult>(viewResult.WithWarningFlash("title3", "body3"));

            Assert.True(flashedResult.FlashMessages.Count.Equals(1));
            Assert.Equal("warning", flashedResult.FlashMessages.FirstOrDefault().Type);
            Assert.Equal("title3", flashedResult.FlashMessages.FirstOrDefault().Title);
            Assert.Equal("body3", flashedResult.FlashMessages.FirstOrDefault().Body);
        }

        [Fact]
        public void WithDangerFlash_AddsAFlashMessageOfDangerType()
        {
            var viewResult = new ViewResult();

            var flashedResult = Assert.IsType<FlashedActionResult>(viewResult.WithDangerFlash("title4", "body4"));

            Assert.True(flashedResult.FlashMessages.Count.Equals(1));
            Assert.Equal("danger", flashedResult.FlashMessages.FirstOrDefault().Type);
            Assert.Equal("title4", flashedResult.FlashMessages.FirstOrDefault().Title);
            Assert.Equal("body4", flashedResult.FlashMessages.FirstOrDefault().Body);
        }

        [Theory]
        [InlineData("custom1")]
        [InlineData("custom2")]
        public void WithFlash_AddsAFlashMessageOfCustomType(string type)
        {
            var viewResult = new ViewResult();

            var flashedResult = Assert.IsType<FlashedActionResult>(viewResult.WithFlash(type, "title5", "body5"));

            Assert.True(flashedResult.FlashMessages.Count.Equals(1));
            Assert.Equal(type, flashedResult.FlashMessages.FirstOrDefault().Type);
            Assert.Equal("title5", flashedResult.FlashMessages.FirstOrDefault().Title);
            Assert.Equal("body5", flashedResult.FlashMessages.FirstOrDefault().Body);
        }

        [Fact]
        public void WithFlashFunctions_CanBeChained()
        {
            var viewResult = new ViewResult();

            var flashedResult = viewResult
                .WithSuccessFlash("title", "body")
                .WithInfoFlash("title", "body")
                .WithWarningFlash("title", "body")
                .WithDangerFlash("title", "body")
                .WithFlash("custom", "title", "body");

            Assert.IsType<FlashedActionResult>(flashedResult);

            Assert.True(flashedResult.FlashMessages.Count.Equals(5));
        }
    }
}
