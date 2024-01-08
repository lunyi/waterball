
namespace YoutobeSubscribe
{
    internal class YoutubeChannel
    {
        public string Name { get; set; }
    }

    internal class Video
    {
        public Video(string title, int seconds)
        {
            Title = title;
            Length = seconds;
        }
        public string Title { get; set; }
        public int Length { get; set; }
    }
}
