namespace WindowsAutoClickerLibrary;
public static class AutoClickerHelpers
{
    [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
    private static extern int SetCursorPos(int x, int y); //later can have custom stuff.
    [DllImport("user32.dll")]
    static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    //private const int MOUSEEVENTF_MOVE = 0x0001;
    private const int _mOUSEEVENTF_LEFTDOWN = 0x02;
    private const int _mOUSEEVENTF_LEFTUP = 0x04;
    //private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    //private const int MOUSEEVENTF_RIGHTUP = 0x0010;
    //private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    //private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
    //private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
    public static Point GetMousePosition => ww.MousePosition;
    public static void SetMousePosition(int x, int y)
    {
        SetCursorPos(x, y);
    }
    public static void SetMousePosition(Point point)
    {
        SetMousePosition(point.X, point.Y);
    }
    //i think setting mouseposition should be forced to be done first.
    public static void LeftClick()
    {
        mouse_event(_mOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        mouse_event(_mOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
    }
    //for now, only leftclick is supported (most common anyways).
    //can later allow for other clicking if necessary and i see the purpose of it.
}