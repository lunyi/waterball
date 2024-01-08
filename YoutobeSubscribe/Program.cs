using YoutobeSubscribe;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pewdiepieChannel = new ChannelObservable("PewDiePie");
            var waterballChannel = new ChannelObservable("水球軟體學院");
            var waterballClient = new WaterballSubscriber("水球");
            var fireballClient = new FireballSubscriber("火球");

            waterballClient.Subscribe(waterballChannel);
            waterballClient.Subscribe(pewdiepieChannel);
            fireballClient.Subscribe(waterballChannel);
            fireballClient.Subscribe(pewdiepieChannel);

            var video1 = new Video("C1M1S2", 240);
            var video2 = new Video("Hello guys", 30);
            var video3 = new Video("C1M1S3", 60);
            var video4 = new Video("Minecraft", 1800);

            waterballChannel.UploadVideo(video1);
            pewdiepieChannel.UploadVideo(video2);
            waterballChannel.UploadVideo(video3);
            pewdiepieChannel.UploadVideo(video4);

            Console.ReadLine();
        }
    }
}