namespace YoutobeSubscribe
{
    internal class SubscriberWaterball : Subscriber
    {
        public SubscriberWaterball(string name) : base(name)
        {
        }

        public override void Notify(Video video, Youtube youtube)
        {
            if (video.Length >= 180)
            {
                youtube.Like(video, this);
            }
        }
    }
}
