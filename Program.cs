using System.Diagnostics;

namespace YouTube
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting video download...");

                var watch = new Stopwatch();
                watch.Start();

                var link = args[0];
                var youTube = VideoLibrary.YouTube.Default;
                var video = youTube.GetVideo(link);
                File.WriteAllBytes(Directory.GetCurrentDirectory() + video.FullName, video.GetBytes());

                watch.Stop();

                var elapsedTimeInMins = (int)watch.ElapsedMilliseconds / 1000m / 60m;
                Console.WriteLine($"Video downloaded to current directory. Time to complete: {elapsedTimeInMins:#.##} minutes.");
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error occurred downloading YouTube video. Exception: {e}.");
            }
        }
    }
}