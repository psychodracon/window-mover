using System.ComponentModel;
using WinApiEnums = WindowMover.Classes.Wrappers.Enums;

namespace WindowMover.Classes.Managers;

public class WindowHandlerManager
{
    public BindingList<WindowHandler> windowHandlers = new BindingList<WindowHandler>();
    private List<Window> topMostWindows = new List<Window>();

    public WindowHandlerManager()
    {
        Load();
    }

    public void Add(WindowHandler handler)
    {
        if (CheckIfElementExists(handler))
            throw new WindowHandlerExists(handler.handlerName);
        else
            windowHandlers.Add(handler);
    }

    public void Update(WindowHandler handler)
    {
        WindowHandler? found = windowHandlers.Where(x => x.guid == handler.guid).FirstOrDefault();
        found?.CopyProperties(handler);
    }

    public bool CheckIfElementExists(WindowHandler handler)
    {
        WindowHandler? existing = windowHandlers.Where(x => x.handlerName == handler.handlerName).FirstOrDefault();
        return existing != null ? true : false;
    }

    public void Remove(WindowHandler handler)
    {
        WindowHandler? existing = windowHandlers.Where(x => x.handlerName == handler.handlerName).FirstOrDefault();
        if (existing != null)
            windowHandlers.Remove(handler);
    }


    public bool Save()
    {
        System.IO.Directory.CreateDirectory(Helpers.GetSettingsPath());
        byte[] arrayToSave = Helpers.ObjectToByteArray(windowHandlers);
        bool done = Helpers.ByteArrayToFile(String.Format("{0}\\data.dat", Helpers.GetSettingsPath()), arrayToSave);

        return done;
    }

    public bool Load()
    {
        if (System.IO.Directory.Exists(Helpers.GetSettingsPath()))
        {
            byte[]? arrayToSave = Helpers.FileToByteArray(String.Format("{0}\\data.dat", Helpers.GetSettingsPath()));
            if (arrayToSave != null)
                windowHandlers = Helpers.ByteArrayToObject<BindingList<WindowHandler>>(arrayToSave) ?? new BindingList<WindowHandler>();
            else
                return false;
        }
        return true;
    }

    public List<WindowHandler> GetWindowHandlers()
    {
        return windowHandlers.ToList();
    }

    public List<WindowHandler> ByteArrayToWindowHandler(byte[] data)
    {
        List<WindowHandler> windowHandlers = new List<WindowHandler>();

        windowHandlers = Helpers.ByteArrayToObject<List<WindowHandler>>(data) ?? new List<WindowHandler>();

        return windowHandlers;
    }

    public byte[] WindowHandlersToByteArray(List<WindowHandler> windowhandlers)
    {
        byte[] data = Helpers.ObjectToByteArray(windowhandlers);

        return data;
    }

    public List<Window> GetWindowByWindowHandler(WindowHandler windowHandler, List<Window> openedWindows)
    {
        List<Window> windows = new List<Window>();

        // A missing title/class/process name never matches.
        string? title = windowHandler.windowTitle?.ToLower();
        string? windowClass = windowHandler.windowClass?.ToLower();
        if (title == null)
            return windows;

        switch (windowHandler.windowTitleModifier)
        {
            case WindowCompareTemplate.Match:
                if (!windowHandler.useWindowClass)
                    windows = openedWindows.Where(x => x.windowCaption.ToLower().Equals(title)).ToList();
                else
                    windows = openedWindows.Where(x => x.windowCaption.ToLower().Equals(title) && x.windowClass.ToLower().Equals(windowClass)).ToList();
                break;
            case WindowCompareTemplate.BeginsWith:
                if (!windowHandler.useWindowClass)
                    windows = openedWindows.Where(x => x.windowCaption.ToLower().StartsWith(title)).ToList();
                else
                    windows = openedWindows.Where(x => x.windowCaption.ToLower().StartsWith(title) && x.windowClass.ToLower().Equals(windowClass)).ToList();
                break;
            case WindowCompareTemplate.EndsWith:
                if (!windowHandler.useWindowClass)
                    windows = openedWindows.Where(x => x.windowCaption.ToLower().EndsWith(title)).ToList();
                else
                    windows = openedWindows.Where(x => x.windowCaption.ToLower().EndsWith(title) && x.windowClass.ToLower().Equals(windowClass)).ToList();
                break;
            case WindowCompareTemplate.Contains:
                if (!windowHandler.useWindowClass)
                    windows = openedWindows.Where(x => x.windowCaption.ToLower().Contains(title)).ToList();
                else
                    windows = openedWindows.Where(x => x.windowCaption.ToLower().Contains(title) && x.windowClass.ToLower().Equals(windowClass)).ToList();
                break;
            default:
                break;
        }

        if (windowHandler.useProcessName)
        {
            string? processName = windowHandler.processName?.ToLower();
            windows = processName == null ? new List<Window>() : windows.Where(x => x.processName.ToLower().Contains(processName)).ToList();
        }

        if (windowHandler.useParent)
        {
            if (windows.Count > 0 && windows[0].windowParent != null)
            {
                string? parentTitle = windowHandler.parentWindowTitle?.ToLower();
                string? parentClass = windowHandler.parentWindowClass?.ToLower();
                if (parentTitle == null)
                    return new List<Window>();

                switch (windowHandler.parentWindowTitleModifier)
                {
                    case WindowCompareTemplate.Match:
                        if (!windowHandler.useParentWindowClass)
                            windows = windows.Where(x => x.windowParent is { } parent && parent.windowCaption.ToLower().Equals(parentTitle)).ToList();
                        else
                            windows = windows.Where(x => x.windowParent is { } parent && parent.windowCaption.ToLower().Equals(parentTitle) && parent.windowClass.ToLower().Equals(parentClass)).ToList();
                        break;
                    case WindowCompareTemplate.BeginsWith:
                        if (!windowHandler.useParentWindowClass)
                            windows = windows.Where(x => x.windowParent is { } parent && parent.windowCaption.ToLower().StartsWith(parentTitle)).ToList();
                        else
                            windows = windows.Where(x => x.windowParent is { } parent && parent.windowCaption.ToLower().StartsWith(parentTitle) && parent.windowClass.ToLower().Equals(parentClass)).ToList();
                        break;
                    case WindowCompareTemplate.EndsWith:
                        if (!windowHandler.useParentWindowClass)
                            windows = windows.Where(x => x.windowCaption.ToLower().EndsWith(parentTitle)).ToList();
                        else
                            windows = windows.Where(x => x.windowCaption.ToLower().EndsWith(parentTitle) && x.windowParent is { } parent && parent.windowClass.ToLower().Equals(parentClass)).ToList();
                        break;
                    case WindowCompareTemplate.Contains:
                        if (!windowHandler.useParentWindowClass)
                            windows = windows.Where(x => x.windowParent is { } parent && parent.windowCaption.ToLower().Contains(parentTitle)).ToList();
                        else
                            windows = windows.Where(x => x.windowParent is { } parent && parent.windowCaption.ToLower().Contains(parentTitle) && parent.windowClass.ToLower().Equals(parentClass)).ToList();
                        break;
                    default:
                        break;
                }

                if (windowHandler.useParentProcessName)
                {
                    string? parentProcessName = windowHandler.parentProcessName?.ToLower();
                    windows = parentProcessName == null ? new List<Window>() : windows.Where(x => x.windowParent is { } parent && parent.processName.ToLower().Contains(parentProcessName)).ToList();
                }
            }
        }

        return windows;
    }

    private void SetWindowZOrder(WindowManager windowManager, Window window, WinApiEnums.InsertAfter insertAfter)
    {
        windowManager.SetWindowPos(window, (int)insertAfter, (uint)WinApiEnums.WindowSPFlags.SWP_FRAMECHANGED |
                        (uint)WinApiEnums.WindowSPFlags.SWP_NOMOVE |
                        (uint)WinApiEnums.WindowSPFlags.SWP_NOSIZE |
                        (uint)WinApiEnums.WindowSPFlags.SWP_NOACTIVATE
                        );
        if (!topMostWindows.Any(x => x.windowHandle.Equals(window.windowHandle)))
        {
            topMostWindows.Add(window);
        }
    }
    public void SetPositions(WindowManager windowManager)
    {
        foreach (var handler in windowHandlers.Where(x => x.handlerActive == true).ToList())
        {
            List<Window> windows = new List<Window>();

            windows = GetWindowByWindowHandler(handler, windowManager.GetAllOpenedWindows());

            foreach (var window in windows)
            {
                nint foregroundWindow = windowManager.GetForegroundWindow();
                if (foregroundWindow == window.windowHandle && handler.alwaysOnTop && !windowManager.IsWindowTopMost(window))
                {
                    SetWindowZOrder(windowManager, window, WinApiEnums.InsertAfter.nint_TOPMOST);
                }
                if (handler.borderless)
                {
                    long currentStyle = windowManager.GetWindowLongPtr(window, (int)WinApiEnums.Index.GWL_STYLE);
                    currentStyle &= ~((long)WinApiEnums.WindowStyle.WS_CAPTION |
                        (long)WinApiEnums.WindowStyle.WS_THICKFRAME |
                        (long)WinApiEnums.WindowStyle.WS_MINIMIZE |
                        (long)WinApiEnums.WindowStyle.WS_MAXIMIZE |
                        (long)WinApiEnums.WindowStyle.WS_SYSMENU
                    );
                    windowManager.SetWindowLongPtr(window, (int)WinApiEnums.Index.GWL_STYLE, currentStyle);

                    long currentExtStyle = windowManager.GetWindowLongPtr(window, (int)WinApiEnums.Index.GWL_EXSTYLE);
                    currentExtStyle &= ~((long)WinApiEnums.WindowExtStyle.WS_EX_DLGMODALFRAME |
                        (long)WinApiEnums.WindowExtStyle.WS_EX_CLIENTEDGE |
                        (long)WinApiEnums.WindowExtStyle.WS_EX_STATICEDGE);
                    windowManager.SetWindowLongPtr(window, (int)WinApiEnums.Index.GWL_EXSTYLE, currentExtStyle);

                    windowManager.SetWindowPos(window, 0, (uint)WinApiEnums.WindowSPFlags.SWP_FRAMECHANGED |
                        (uint)WinApiEnums.WindowSPFlags.SWP_NOMOVE |
                        (uint)WinApiEnums.WindowSPFlags.SWP_NOSIZE |
                        (uint)WinApiEnums.WindowSPFlags.SWP_NOZORDER |
                        (uint)WinApiEnums.WindowSPFlags.SWP_NOOWNERZORDER |
                        (uint)WinApiEnums.WindowSPFlags.SWP_NOACTIVATE
                        );
                }

                if (!handler.changePosition && !handler.changeSize)
                {
                    return;
                }
                else if (handler.changePosition && !handler.changeSize)
                {
                    windowManager.MoveWindowByWindowClass(window, handler.positionX, handler.positionY, window.sizeX, window.sizeY, true);
                }
                else if (!handler.changePosition && handler.changeSize)
                {
                    windowManager.MoveWindowByWindowClass(window, window.positionX, window.positionY, handler.sizeX, handler.sizeY, true);
                }
                else if (handler.changePosition && handler.changeSize)
                {
                    windowManager.MoveWindowByWindowClass(window, handler.positionX, handler.positionY, handler.sizeX, handler.sizeY, true);
                }
            }
        }
    }

    public void RemoveTopMostStyleFromWindows(WindowManager windowManager)
    {
        foreach (Window window in topMostWindows)
        {
            SetWindowZOrder(windowManager, window, WinApiEnums.InsertAfter.nint_NOTOPMOST);
        }
    }
}
