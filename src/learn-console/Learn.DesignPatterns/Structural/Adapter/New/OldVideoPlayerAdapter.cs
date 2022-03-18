using Learn.DesignPatterns.Structural.Adapter.Existing;
using Learn.DesignPatterns.Structural.Adapter.New.Interface;

namespace Learn.DesignPatterns.Structural.Adapter.New
{
    public class OldVideoPlayerAdapter : IVideoPlayer
    {
        private VideoPlayer videoPlayer;
        public OldVideoPlayerAdapter(VideoPlayer videoPlayer)
        {
            this.videoPlayer = videoPlayer;
        }
        public string Backward()
        {
            return "-5sn";
        }

        public string Forward()
        {
            return "+5sn";
        }

        public string Pause()
        {
            return "pause";
        }

        public string Play()
        {
            return "play";
        }

        public string Stop()
        {
            return "stop";
        }
    }
}
