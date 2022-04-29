namespace Controllers.Interfaces
{
    public interface IVideoPlayerController
    {
        void PlayVideo();
        string SourceUrl { set; }
    }
}