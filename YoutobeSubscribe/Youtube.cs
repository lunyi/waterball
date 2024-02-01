namespace YoutobeSubscribe
{
    
    internal class Youtube
    {
        public string Name { get; private set; }
        private List<Subscriber> subscribers;
        private List<Subscriber> subscribersToDelete;
        public Youtube(string name) 
        {
            subscribers = new List<Subscriber>();
            Name = name;
        }
        
        public void Subscribe(Subscriber subscriber)
        {
            subscribers.Add(subscriber);
            Console.WriteLine($"{subscriber.Name} 訂閱了 {Name}。");
        }

        public void Unsubscribe(Subscriber subscriber)
        {
            subscribersToDelete.Add(subscriber);
            Console.WriteLine($"{subscriber.Name} 解除訂閱了 {Name}。");
        }

        public void UploadVideo(Video video) 
        {
            subscribersToDelete = new List<Subscriber>();
            Console.WriteLine($"頻道 {Name} 上架了一則新影片 \"{video.Title}\"。");
            foreach (var subscriber in subscribers)
            {
                subscriber.Notify(video, this);
            }

            foreach (var subscriber in subscribersToDelete)
            {
                subscribers.Remove(subscriber);
            }
        }

        public void Like(Video video, Subscriber subscribe)
        {
            Console.WriteLine($"{subscribe.Name} 對影片 \"{video.Title}\" 按讚。");
        }
    }
}
