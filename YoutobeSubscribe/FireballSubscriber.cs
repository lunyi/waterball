namespace YoutobeSubscribe
{
    internal class FireballSubscriber : ChannelSubscriber
    {
        public FireballSubscriber(string name) : base(name)
        {
        }

        public override void Notify(Video video, ChannelObservable channel)
        {
            if (video.Length <= 60) 
            { 
                Unsubscribe(channel);
            }
        }
    }
}
