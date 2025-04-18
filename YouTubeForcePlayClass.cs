namespace WindowsAutoClickerLibrary;
public class YouTubeForcePlayClass : IMediaForcePlay
{
    async Task IMediaForcePlay.ForcePlayAsync()
    {
        aa1.SetMousePosition(new(500, 500));
        await Task.Delay(3000); //try to wait longer so it can load.
        aa1.LeftClick();
    }
}