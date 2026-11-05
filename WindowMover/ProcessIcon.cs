using WindowMover.Classes.Managers;
using WindowMover.Properties;

namespace WindowMover;

class ProcessIcon : IDisposable
{
    NotifyIcon notifyIcon;
    TimerManager timerManager;
    WindowManager windowManager;
    WindowHandlerManager windowHandlerManager;
    HotkeyManager hotkeyManager;

    public ProcessIcon(WindowManager windowManager, WindowHandlerManager windowHandlerManager, TimerManager timerManager, HotkeyManager hotkeyManager)
    {
        this.windowManager = windowManager;
        this.windowHandlerManager = windowHandlerManager;
        this.timerManager = timerManager;
        this.hotkeyManager = hotkeyManager;

        notifyIcon = new NotifyIcon();
    }

    public void Display()
    {
        string productVersion = Application.ProductVersion;
        productVersion = productVersion.Split('+')[0];

        notifyIcon.Icon = Resources.Tray;
        notifyIcon.Text = String.Format("Window Mover {0}", productVersion);
        notifyIcon.Visible = true;

        ContextMenus contextMenus = new ContextMenus(windowManager, windowHandlerManager, timerManager, hotkeyManager);
        notifyIcon.ContextMenuStrip = contextMenus.Create();
        notifyIcon.DoubleClick += (_, _) => contextMenus.ShowSettings();
    }

    public void Dispose()
    {
        notifyIcon.Dispose();
    }
}