namespace DerombaB.AspNetCore.FlashExtensions
{
    /// <summary>
    /// A class that represents a flash message.
    /// </summary>
    public class FlashMessage
    {
        public string Type { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public override bool Equals(object obj)
        {
            return obj is FlashMessage message &&
                   Type == message.Type &&
                   Title == message.Title &&
                   Body == message.Body;
        }
    }
}