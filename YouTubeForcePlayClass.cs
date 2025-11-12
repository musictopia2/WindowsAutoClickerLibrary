namespace WindowsAutoClickerLibrary;
public class YouTubeForcePlayClass : IMediaForcePlay
{
    Task IMediaForcePlay.ForcePlayAsync()
    {
        aa1.SetMousePosition(new(500, 500));
        return Task.CompletedTask; //maybe not needed anymore (?)

        //await Task.Delay(10000); //try to wait longer so it can load.
        //aa1.LeftClick();
    }
}