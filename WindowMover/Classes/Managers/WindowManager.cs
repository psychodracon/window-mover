using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowMover.Classes.Wrappers.Enums;
using WinApiEnums = WindowMover.Classes.Wrappers.Enums;

namespace WindowMover.Classes.Managers;

public class WindowManager
{
    private List<Window> openedWindows = new List<Window>();
    private Process[] processes = [];

    public WindowManager()
    {
        GetAllProcesses();
    }

    public Process[] GetAllProcesses()
    {
        return processes = Process.GetProcesses();
    }

    public List<Window> GetAllOpenedWindows(bool useCachedValues = false)
    {
        if (useCachedValues)
            return openedWindows;

        openedWindows = GetOpenedWindows();

        return openedWindows;
    }

    private unsafe List<Window> GetOpenedWindows()
    {
        nint shellWindow = WinApiWrapper.GetShellWindow();
        List<nint> handles = new List<nint>();

        GCHandle<List<nint>> handlesHandle = new GCHandle<List<nint>>(handles);
        try
        {
            WinApiWrapper.EnumWindows(&CollectWindowHandle, GCHandle<List<nint>>.ToIntPtr(handlesHandle));
        }
        finally
        {
            handlesHandle.Dispose();
        }

        List<Window> windows = new List<Window>();
        foreach (nint hWnd in handles)
        {
            // TODO: Consider child detection
            if (hWnd == shellWindow) continue;
            if (!WinApiWrapper.IsWindowVisible(hWnd)) continue;

            try
            {
                windows.Add(GetWindowInfo(hWnd));
            }
            // Window was closed during enumeration.
            catch (Exception) { }
        }

        return windows;
    }

    [UnmanagedCallersOnly]
    private static int CollectWindowHandle(nint hWnd, nint lParam)
    {
        GCHandle<List<nint>>.FromIntPtr(lParam).Target.Add(hWnd);
        return 1;
    }

    public Window GetWindowInfo(nint hWnd)
    {
        Window window = new Window();

        window.windowHandle = hWnd;
        window.firstChildHandle = WinApiWrapper.GetWindow(hWnd, (uint)Cmd.GW_CHILD);
        window.windowCaption = GetCaptionOfWindow(hWnd);
        window.windowClass = GetClassNameOfWindow(hWnd);
        window.processName = GetProcessPathOfWindow(hWnd);

        Rectangle rectangle = GetWindowRect(hWnd);

        window.positionX = rectangle.X;
        window.positionY = rectangle.Y;
        window.sizeX = rectangle.Width;
        window.sizeY = rectangle.Height;

        nint hWndParent = WinApiWrapper.GetParent(hWnd);
        if (hWndParent != nint.Zero)
        {
            Window parentWindow = new Window();

            parentWindow.windowHandle = hWndParent;
            parentWindow.windowCaption = GetCaptionOfWindow(hWndParent);
            parentWindow.windowClass = GetClassNameOfWindow(hWndParent);
            parentWindow.processName = GetProcessPathOfWindow(hWndParent);

            Rectangle parentRectangle = GetWindowRect(hWndParent);

            parentWindow.positionX = parentRectangle.X;
            parentWindow.positionY = parentRectangle.Y;
            parentWindow.sizeX = parentRectangle.Width;
            parentWindow.sizeY = parentRectangle.Height;

            window.windowParent = parentWindow;
        }

        return window;
    }

    public string GetCaptionOfWindow(nint hWnd)
    {
        int length = WinApiWrapper.GetWindowTextLength(hWnd);
        char[] buffer = new char[length + 1];
        int copied = WinApiWrapper.GetWindowText(hWnd, buffer, buffer.Length);
        string caption = new string(buffer, 0, copied);

        return String.IsNullOrWhiteSpace(caption) ? "" : caption;
    }

    public string GetClassNameOfWindow(nint hWnd)
    {
        // Window class names are limited to 256 characters.
        char[] buffer = new char[257];
        int copied = WinApiWrapper.GetClassName(hWnd, buffer, buffer.Length);
        string className = new string(buffer, 0, copied);

        return String.IsNullOrWhiteSpace(className) ? "" : className;
    }

    public string GetProcessPathOfWindow(nint hWnd)
    {
        String processFileName = String.Empty;

        try
        {
            WinApiWrapper.GetWindowThreadProcessId(hWnd, out uint pid);
            Process proc = processes.Where(x => x.Id == pid).First();
            processFileName = proc.MainModule?.FileName ?? String.Empty;
        }
        catch (Exception) { }

        return processFileName;
    }

    public Rectangle GetWindowRect(nint hWnd)
    {
        Debug.Assert(hWnd != nint.Zero);
        if (!WinApiWrapper.GetWindowRect(hWnd, out WinApiWrapper.RECT rect))
            throw new Exception("GetWindowRect failed");
        return rect.ToRectangle();
    }

    public bool MoveWindowByHandle(nint hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint)
    {
        return WinApiWrapper.MoveWindow(hWnd, X, Y, nWidth, nHeight, bRepaint);
    }

    public bool MoveWindowByWindowClass(Window window, int X, int Y, int nWidth, int nHeight, bool bRepaint)
    {
        return MoveWindowByHandle(window.windowHandle, X, Y, nWidth, nHeight, bRepaint);
    }

    public long SetWindowLongPtr(Window window, int index, long replacementValue)
    {
        return WinApiWrapper.SetWindowLongPtr(window.windowHandle, index, (nint)replacementValue);
    }

    public long GetWindowLongPtr(Window window, int index)
    {
        return WinApiWrapper.GetWindowLongPtr(window.windowHandle, index);
    }

    public bool SetWindowPos(Window window, int zOrder, uint flags)
    {
        return WinApiWrapper.SetWindowPos(window.windowHandle, zOrder, window.positionX, window.positionY, window.sizeX, window.sizeY, flags);
    }

    public bool IsWindowTopMost(Window window)
    {
        long windowExtStyle = GetWindowLongPtr(window, (int)WinApiEnums.Index.GWL_EXSTYLE);
        return (windowExtStyle & (int)WinApiEnums.WindowExtStyle.WS_EX_TOPMOST) == (int)WinApiEnums.WindowExtStyle.WS_EX_TOPMOST;
    }

    public nint GetForegroundWindow()
    {
        return WinApiWrapper.GetForegroundWindow();
    }

    public bool SetForegroundWindow(nint hWnd)
    {
        return WinApiWrapper.SetForegroundWindow(hWnd);
    }

    public nint SetActiveWindow(nint hWnd)
    {
        return WinApiWrapper.SetActiveWindow(hWnd);
    }

    public bool UnhookWinEvent(nint hWinEventHook)
    {
        return WinApiWrapper.UnhookWinEvent(hWinEventHook);
    }

    public int GetLastError()
    {
        return Marshal.GetLastPInvokeError();
    }

    public nint SetWindowsHookEx(WinApiEnums.Hooks idHook, WinApiWrapper.HookProc lpfn, nint hMod, uint dwThreadId)
    {
        return WinApiWrapper.SetWindowsHookEx((int)idHook, lpfn, hMod, dwThreadId);
    }

    public nint CallNextHookEx(nint hhk, int nCode, nint wParam, nint lParam)
    {
        return WinApiWrapper.CallNextHookEx(hhk, nCode, wParam, lParam);
    }
}
