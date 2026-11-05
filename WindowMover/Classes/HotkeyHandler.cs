using System.Runtime.InteropServices;

namespace WindowMover.Classes.Managers;

internal static partial class HotkeyHandler
{
    public static event EventHandler<HotkeyEventArgs>? HotkeyPressed;


    public static int RegisterHotKey(uint key, uint modifiers)
    {
        _windowReadyEvent.WaitOne();
        int id = Interlocked.Increment(ref _id);
        _wnd.Invoke(new RegisterHotkeyDelegate(RegisterHotkeyInternal), _nint, id, modifiers, key);
        return id;
    }

    public static void UnregisterHotKey(int id)
    {
        _wnd.Invoke(new UnRegisterHotKeyDelegate(UnRegisterHotKeyInternal), _nint, id);
    }

    delegate void RegisterHotkeyDelegate(nint nint, int id, uint modifiers, uint key);
    delegate void UnRegisterHotKeyDelegate(nint nint, int id);

    private static void RegisterHotkeyInternal(nint nint, int id, uint modifiers, uint key)
    {
        RegisterHotKey(nint, id, modifiers, key);
    }

    private static void UnRegisterHotKeyInternal(nint nint, int id)
    {
        UnregisterHotKey(_nint, id);
    }

    private static void OnHotkeyPressed(HotkeyEventArgs e)
    {
        if (HotkeyHandler.HotkeyPressed != null && HotkeyHandler.HotkeyPressed.GetInvocationList().Length <= 1)
        {
            Console.WriteLine("Hotkey Handler Invocations: {0}", HotkeyHandler.HotkeyPressed.GetInvocationList().Length);
            HotkeyHandler.HotkeyPressed(null, e);
        }
    }

    private static volatile MessageWindow _wnd = null!;
    private static volatile nint _nint;
    private static ManualResetEvent _windowReadyEvent = new ManualResetEvent(false);
    static HotkeyHandler()
    {
        Thread messageLoop = new Thread(delegate ()
        {
            Application.Run(new MessageWindow());
        });
        messageLoop.Name = "MessageLoopThread";
        messageLoop.IsBackground = true;
        messageLoop.Start();
    }

    private class MessageWindow : Form
    {
        private const int WM_HOTKEY = 0x312;

        public MessageWindow()
        {

            _wnd = this;
            _nint = this.Handle;
            _windowReadyEvent.Set();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                HotkeyEventArgs e = new HotkeyEventArgs(m.LParam, m);
                HotkeyHandler.OnHotkeyPressed(e);
            }

            base.WndProc(ref m);
        }

        protected override void SetVisibleCore(bool value)
        {
            // Ensure the window never becomes visible
            base.SetVisibleCore(false);
        }
    }

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool RegisterHotKey(nint hWnd, int id, uint fsModifiers, uint vk);

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool UnregisterHotKey(nint hWnd, int id);

    private static int _id = 0;
}


public class HotkeyEventArgs : EventArgs
{
    public readonly Message Message;
    public readonly Keys Key;
    public readonly KeyModifiers Modifiers;

    public HotkeyEventArgs(Keys key, KeyModifiers modifiers)
    {
        this.Key = key;
        this.Modifiers = modifiers;
    }

    public HotkeyEventArgs(nint hotkeyParam, Message message)
    {
        uint param = (uint)hotkeyParam.ToInt64();
        Key = (Keys)((param & 0xffff0000) >> 16);
        Modifiers = (KeyModifiers)(param & 0x0000ffff);
        Message = message;
    }
}

[Flags]
public enum KeyModifiers
{
    Alt = 1,
    Control = 2,
    Shift = 4,
    Windows = 8,
    NoRepeat = 0x4000
}
