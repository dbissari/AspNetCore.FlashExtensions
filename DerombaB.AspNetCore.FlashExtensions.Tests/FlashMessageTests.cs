using Xunit;

namespace DerombaB.AspNetCore.FlashExtensions.Tests
{
    public class FlashMessageTests
    {
        [Theory]
        [InlineData("success", "title1", "body1")]
        [InlineData("info", "title2", "body2")]
        [InlineData("warning", "title3", "body3")]
        [InlineData("error", "title4", "body4")]
        [InlineData("custom", "title5", "body5")]
        public void Equals_ReturnsTrue_IfAllPropertiesAreEqual(string type, string title, string body)
        {
            var flashMessage1 = new FlashMessage()
            {
                Type = type,
                Title = title,
                Body = body
            };

            var flashMessage2 = new FlashMessage()
            {
                Type = type,
                Title = title,
                Body = body
            };

            Assert.True(flashMessage1.Equals(flashMessage2));
        }

        [Theory]
        [InlineData("success", "title1", "body1", "info", "title1", "body1")]
        [InlineData("info", "title2", "body2", "info", "title1", "body2")]
        [InlineData("warning", "title3", "body3", "warning", "title3", "body1")]
        [InlineData("error", "title4", "body4", "warning", "title3", "body4")]
        [InlineData("custom", "title5", "body5", "custom", "title3", "body1")]
        [InlineData("success", "title5", "body5", "custom", "title3", "body1")]
        public void Equals_ReturnsFalse_IfNotAllPropertiesAreEqual(string type1, string title1, string body1, string type2, string title2, string body2)
        {
            var flashMessage1 = new FlashMessage()
            {
                Type = type1,
                Title = title1,
                Body = body1
            };

            var flashMessage2 = new FlashMessage()
            {
                Type = type2,
                Title = title2,
                Body = body2
            };

            Assert.False(flashMessage1.Equals(flashMessage2));
        }
    }
}