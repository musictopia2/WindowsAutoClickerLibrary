namespace WindowsAutoClickerLibrary;
public class YouTubeForcePlayClass : IMediaForcePlay
{
    async Task IMediaForcePlay.ForcePlayAsync()
    {
        aa1.SetMousePosition(new(500, 500));
        await Task.Delay(1000);
        aa1.LeftClick();
    }
}