namespace YoutobeSubscribe
{
    internal abstract class Subscriber
    {
        public string Name { get; private set; }
        public Subscriber(string name) 
        {
            Name = name;
        }

        public abstract void Notify(Video video, Youtube youtube);

        public void Subscribe(Youtube youtube) 
        {
            youtube.Subscribe(this);
        }

        public void Unsubscribe(Youtube youtube)
        {
            youtube.Unsubscribe(this);
        }
    }
}
