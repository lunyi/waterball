namespace YoutobeSubscribe
{
    internal class SubscriberFireball : Subscriber
    {
        public SubscriberFireball(string name) : base(name)
        {
        }

        public override void Notify(Video video, Youtube youtube)
        {
            if (video.Length <= 60) 
            {
                youtube.Unsubscribe(this);
            }
        }
    }
}
