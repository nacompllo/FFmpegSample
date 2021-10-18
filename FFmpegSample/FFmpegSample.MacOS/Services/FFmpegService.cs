using FFmpegSample.MacOS.Services;
using FFmpegSample.Services;
using Foundation;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(FFmpegService))]
namespace FFmpegSample.MacOS.Services
{
    public class FFmpegService : IFFmpegService
    {
        public void ExecuteFFmpeg()
        {
            try
            {
                var launchPath = NSBundle.MainBundle.PathForResource("ffmpeg", ofType: "");
                var compressTask = new NSTask();
                compressTask.LaunchPath = launchPath;
                compressTask.Arguments = new string[] { "ffmpeg -i downloads/tyson.mp4 -c copy -an onlyaudio.mp4" };
                compressTask.StandardInput = NSFileHandle.FromNullDevice();
                compressTask.Launch();
                compressTask.WaitUntilExit();
            }
            catch (Exception ex)
            {

            }
        }
    }
}