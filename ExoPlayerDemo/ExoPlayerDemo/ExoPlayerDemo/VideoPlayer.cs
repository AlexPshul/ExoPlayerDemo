using Xamarin.Forms;

namespace ExoPlayerDemo
{
    public class VideoPlayer : View
    {
        public static readonly BindableProperty SourceUrlProperty = 
            BindableProperty.Create("SourceUrl", typeof(string), typeof(VideoPlayer));

        public string SourceUrl
        {
            get => (string)GetValue(SourceUrlProperty);
            set => SetValue(SourceUrlProperty, value);
        }
    }
}