using FFmpegSample.MacOS.Services;
using FFmpegSample.Services;
using CliWrap;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(FFmpegService))]
namespace FFmpegSample.MacOS.Services
{
    public class FFmpegService : IFFmpegService
    {
        //private const string macosFfmpegBinarySource = @"../../../../GithubActionsHelloWorld/ffmpebBins/macos64/";

        public async Task ExecuteFFmpeg(string inputFilePath, string outputFilePath)
        {
            await FfmpegRemoveAudio(await CalcOsSpecificFfmpegPathAsync(), inputFilePath, outputFilePath);
        }

        private static async Task<string> CalcOsSpecificFfmpegPathAsync()
        {
            var macosFfmpegBinarySource = App.ResourcePath + "/ffmpegBins/macos64/";
            macosFfmpegBinarySource = macosFfmpegBinarySource.Replace("file://", "");
            var ffmpegExecutable = Path.Combine(macosFfmpegBinarySource, "ffmpeg");

            await SetPermissionsAsync(ffmpegExecutable, "+x");

            return ffmpegExecutable;
        }

        public static async ValueTask SetPermissionsAsync(string filePath, string permissions)
        {
            await Cli.Wrap("/bin/bash").WithArguments(new[] { "-c", $"chmod {permissions} {filePath}" }).ExecuteAsync();
        }

        public static async ValueTask FfmpegRemoveAudio(string ffmpegPath, string inputFilePath, string outputFilePath)
        {
            await Cli.Wrap(ffmpegPath).WithArguments(new[] { "-i", inputFilePath, "-c", "copy", "-an", outputFilePath }).ExecuteAsync();
        }
    }
}