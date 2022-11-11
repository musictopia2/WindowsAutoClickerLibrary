namespace WindowsAutoClickerLibrary;
public static partial class AutoClickerHelpers
{
    [LibraryImport("user32.dll", EntryPoint = "SetCursorPos")]
    private static partial int SetCursorPos(int x, int y); //later can have custom stuff.
    [LibraryImport("user32.dll")]
    private static partial void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    //private const int MOUSEEVENTF_MOVE = 0x0001;
    private const int _mOUSEEVENTF_LEFTDOWN = 0x02;
    private const int _mOUSEEVENTF_LEFTUP = 0x04;
    //private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    //private const int MOUSEEVENTF_RIGHTUP = 0x0010;
    //private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    //private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
    //private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
    public static Point GetMousePosition => ww1.MousePosition;
    public static void SetMousePosition(int x, int y)
    {
        _ = SetCursorPos(x, y);
    }
    public static void SetMousePosition(Point point)
    {
        SetMousePosition(point.X, point.Y);
    }
    //i think setting mouseposition should be forced to be done first.
    public static void LeftClick()
    {
        mouse_event(_mOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        mouse_event(_mOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
    }
    public static async Task ClickSeveralLocationsAsync(BasicList<Point> locations, int millisecondsToPauseForEachStage)
    {
        foreach (var item in locations)
        {
            SetMousePosition(item);
            await Task.Delay(50);
            LeftClick();
            await Task.Delay(millisecondsToPauseForEachStage);
        }
    }
    public static async Task ClickSeveralLocationsAsync(BasicList<ClickInfo> clicks)
    {
        foreach (var item in clicks)
        {
            SetMousePosition(item.Location);
            await Task.Delay(50);
            LeftClick();
            await Task.Delay(item.WaitTime);
        }
    }
    public static async Task ClickSeveralLocationsAsync(BasicList<Point> locations, Func<Point, int, Task> action)
    {
        int x = 0;
        foreach (var item in locations)
        {
            SetMousePosition(item);
            await Task.Delay(50);
            LeftClick();
            await action.Invoke(item, x); //this means somebody else can decide what to do about each step.
            //this means that whoever does it has to wait at each step.
            //they can even decide at a certain phase to even use keystrokes to enter something (its an option).
            //however the one who calls it has to decide to send keystrokes to a certain spot, etc.
            //on the other hand, if a user action is required, then probably can't do the bulk (or requires rethinking).
            x++;
        }
    }
    //for now, only leftclick is supported (most common anyways).
    //can later allow for other clicking if necessary and i see the purpose of it.
    //did decide to allow for bulk.
    //which means if i have a reason which would be very common, then has several different ways of clicking several places.
}