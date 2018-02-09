using Android.Content;
using Android.Net;
using Android.OS;
using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Source.Dash;
using Com.Google.Android.Exoplayer2.Source.Dash.Manifest;
using Com.Google.Android.Exoplayer2.Source.Smoothstreaming;
using Com.Google.Android.Exoplayer2.Trackselection;
using Com.Google.Android.Exoplayer2.UI;
using Com.Google.Android.Exoplayer2.Upstream;
using ExoPlayerDemo;
using ExoPlayerDemo.Droid;
using Java.IO;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(VideoPlayer), typeof(VideoPlayerRenderer))]
namespace ExoPlayerDemo.Droid
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, SimpleExoPlayerView>, IAdaptiveMediaSourceEventListener
    {
        private SimpleExoPlayerView _playerView;
        private SimpleExoPlayer _player;

        public VideoPlayerRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> e)
        {
            base.OnElementChanged(e);

            if (_player == null)
                InitializePlayer();

            Play();
        }

        private void InitializePlayer()
        {
            _player = ExoPlayerFactory.NewSimpleInstance(Context, new DefaultTrackSelector());
            _player.PlayWhenReady = true;
            _playerView = new SimpleExoPlayerView(Context) { Player = _player };
            SetNativeControl(_playerView);
        }

        private void Play()
        {
            Handler emptyHandler = new Handler(message => { });
            DefaultHttpDataSourceFactory httpDataSourceFactory = new DefaultHttpDataSourceFactory("1");
            //DefaultDashChunkSource.Factory chunkFactory = new DefaultDashChunkSource.Factory(httpDataSourceFactory);
            DefaultSsChunkSource.Factory factory = new DefaultSsChunkSource.Factory(httpDataSourceFactory);
            //DashMediaSource dashMediaSource = new DashMediaSource(Uri.Parse(Element.SourceUrl), httpDataSourceFactory, chunkFactory, emptyHandler, this);
            SsMediaSource ssMediaSource = new SsMediaSource(Uri.Parse(Element.SourceUrl), httpDataSourceFactory, factory, emptyHandler, this);

            _player.Prepare(ssMediaSource);
        }

        public void OnDownstreamFormatChanged(int p0, Format p1, int p2, Object p3, long p4)
        {
        }

        public void OnLoadCanceled(DataSpec p0, int p1, int p2, Format p3, int p4, Object p5, long p6, long p7, long p8, long p9, long p10)
        {
        }

        public void OnLoadCompleted(DataSpec p0, int p1, int p2, Format p3, int p4, Object p5, long p6, long p7, long p8, long p9, long p10)
        {
        }

        public void OnLoadError(DataSpec p0, int p1, int p2, Format p3, int p4, Object p5, long p6, long p7, long p8, long p9, long p10, IOException p11, bool p12)
        {
        }

        public void OnLoadStarted(DataSpec p0, int p1, int p2, Format p3, int p4, Object p5, long p6, long p7, long p8)
        {
        }

        public void OnUpstreamDiscarded(int p0, long p1, long p2)
        {
        }
    }
}