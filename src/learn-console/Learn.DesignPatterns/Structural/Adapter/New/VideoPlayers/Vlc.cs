using Learn.DesignPatterns.Structural.Adapter.New.Interface;

namespace Learn.DesignPatterns.Structural.Adapter.New.VideoPlayers
{
    public class Vlc : IVideoPlayer
    {
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
