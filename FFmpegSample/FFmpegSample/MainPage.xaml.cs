using FFmpegSample.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FFmpegSample
{
    public partial class MainPage : ContentPage
    {
        private readonly IFFmpegService _fFmpegService;

        public MainPage()
        {
            InitializeComponent();
            _fFmpegService = DependencyService.Get<IFFmpegService>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _fFmpegService.ExecuteFFmpeg();
        }
    }
}
