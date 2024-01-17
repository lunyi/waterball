namespace YoutobeSubscribe
{
    internal class WaterballSubscriber : ChannelSubscriber
    {
        public WaterballSubscriber(string name) : base(name)
        {
        }

        public override void Notify(Video video, ChannelObservable channel)
        {
            if (video.Length >= 180)
            {
                Like(video);
            }
        }
    }
}
