using System;

namespace YoutobeSubscribe
{
    internal class ChannelObservable : IObservable<YoutubeChannel>
    {
        public string Name { get; set; }

        List<IObserver<YoutubeChannel>> observers;

        public ChannelObservable(string name) 
        {
            observers = new List<IObserver<YoutubeChannel>>();
            Name = name;
        }

        public void UploadVideo(Video video)
        {
            Console.WriteLine($"頻道 {Name} 上架了一則新影片 \"{video.Title}\"。");

            for (int i = 0; i < observers.Count; i++)
            {
                var observer = observers[i] as ChannelSubscriber;
                observer.Notify(video, this);
            }   
        }

        public IDisposable Subscribe(IObserver<YoutubeChannel> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
               
            return new Unsubscriber(observers, observer, this);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<YoutubeChannel>> _observers;
            private IObserver<YoutubeChannel> _observer;
            private ChannelObservable _channelObservable;

            public Unsubscriber(List<IObserver<YoutubeChannel>> observers, IObserver<YoutubeChannel> observer, ChannelObservable channelObservable)
            {
                this._observers = observers;
                this._observer = observer;
                this._channelObservable = channelObservable;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                    //var channel = _observer as ChannelSubscriber;
                    //var obserable = _channelObservable as ChannelObservable;
                    //Console.WriteLine($"22.{channel.Name} 解除訂閱了 {obserable.Name}。");
                }
            }
        }
    }
}
