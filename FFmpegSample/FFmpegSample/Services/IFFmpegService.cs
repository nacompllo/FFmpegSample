﻿using System.Threading.Tasks;

namespace FFmpegSample.Services
{
    public interface IFFmpegService
    {
        Task ExecuteFFmpeg(string parameter);
    }
}