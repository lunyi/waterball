namespace YoutobeSubscribe
{
    internal abstract class ChannelSubscriber : IObserver<YoutubeChannel>
    {
        private IDisposable? unsubscriber;
        private YoutubeChannel? last;
        private List<ChannelObservable> _channelObservables;
        private bool _like;

        public string Name { get; set; }

        public abstract void Notify(Video video, ChannelObservable channel);

        public ChannelSubscriber(string name)
        {
            Name = name;
            _channelObservables = new List<ChannelObservable>();
        }

        public void Subscribe(IObservable<YoutubeChannel> provider)
        {
            unsubscriber = provider.Subscribe(this);
            var channelObservable = provider as ChannelObservable;
            _channelObservables.Add(channelObservable);
            Console.WriteLine($"{Name} 訂閱了 {channelObservable.Name}。");
        }
        public void Unsubscribe(ChannelObservable channelObservable)
        {
            Console.WriteLine($"{Name} 解除訂閱了 {channelObservable.Name}。");
            unsubscriber.Dispose();
            for (int i = 0; i < _channelObservables.Count; i++)
            {
                if (_channelObservables.Contains(channelObservable))
                {
                    _channelObservables.Remove(channelObservable);
                }
            }
        }

        public void Like(Video video) 
        {
            _like = true;
            Console.WriteLine($"{Name} 對影片 \"{video.Title}\" 按讚。");            
        }

        public bool IsLike()
        {
            return _like;
        }
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(YoutubeChannel value)
        {
            throw new NotImplementedException();
        }
    }
}
