using System.Runtime.InteropServices;
using System.Text;
using Velopack;
using WindowMover.Classes;
using WindowMover.Classes.Managers;
using WindowMover.Classes.Wrappers.Enums;
using WindowMover.Localization;
using WindowMover.UIAutomation.Library;


namespace WindowMover;

static partial class Program
{
    private static bool restartRequested;

    internal static void Restart()
    {
        restartRequested = true;
        Application.Exit();
    }

    [STAThread]
    static void Main(string[] args)
    {
        VelopackApp.Build().Run();

        string GUID = "b01ef497-5e3e-4d5b-9d43-5115992ff61e";
        bool createdNew;
        using Mutex mutex = new Mutex(true, GUID, out createdNew);

        if (!createdNew)
        {
            Console.WriteLine("Application is already running!");
            return;
        }

        ApplicationConfiguration.Initialize();

        Settings.Instance.Load();
        JsonStringLocalizer.Instance.LoadTranslations(Settings.Instance.Language);

        HotkeyManager hotkeyManager = new HotkeyManager();
        WindowManager windowManager = new WindowManager();
        WindowHandlerManager windowHandlerManager = new WindowHandlerManager();
        AutomationManager automationManager = new AutomationManager(windowManager, windowHandlerManager);
        AutomationClient automationClient = new AutomationClient();
        TimerManager timerManager = new TimerManager(windowManager, windowHandlerManager);

        int hotkeyBusy = 0;

        // INFO: Disabled keyboard hook
        //automationManager.SubscribeToEvents();
        hotkeyManager.RegisterHotKeys();
        HotkeyHandler.HotkeyPressed += HotkeyHandler_HotkeyPressed;

        using (ProcessIcon processIcon = new ProcessIcon(windowManager, windowHandlerManager, timerManager, hotkeyManager))
        {
            if (args.Length > 0 && args[0] != null && args[0] == "debug")
                AllocConsole();

            processIcon.Display();
            Application.Run();
        }

        // Release before restarting, otherwise the new instance sees this one as still running.
        mutex.ReleaseMutex();
        if (restartRequested)
            System.Diagnostics.Process.Start(Application.ExecutablePath, args);

        string GetKeyStroke(WindowHandler handler, HotkeyType hotkeyType)
        {
            StringBuilder sb = new StringBuilder();
            Keys keys = Keys.None;
            switch (hotkeyType)
            {
                case HotkeyType.ToggleMute:
                    keys = handler.toggleMuteHotkey;
                    break;
                case HotkeyType.ToggleSound:
                    keys = handler.toggleSoundHotkey;
                    break;
                case HotkeyType.ToggleCamera:
                    keys = handler.toggleCameraHotkey;
                    break;
            }
            if (keys != Keys.None)
            {
                if (keys.HasFlag(Keys.Control))
                    sb.Append("^");
                if (keys.HasFlag(Keys.Alt))
                    sb.Append("%");
                if (keys.HasFlag(Keys.Shift))
                    sb.Append("+");
                sb.Append((char)(keys & Keys.KeyCode));
            }

            return sb.ToString().ToLower();
        }

        void HotkeyHandler_HotkeyPressed(object? sender, HotkeyEventArgs e)
        {
            Console.WriteLine("HotKey Pressed! Key: {0}, Modifiers: {1}", e.Key, e.Modifiers);

            HotkeyType hotkey = HotkeyType.None;

            if (e.Message.WParam.ToInt32() == hotkeyManager.GetGlobalHotkeyId(HotkeyType.ToggleMute))
                hotkey = HotkeyType.ToggleMute;
            else if (e.Message.WParam.ToInt32() == hotkeyManager.GetGlobalHotkeyId(HotkeyType.ToggleSound))
                hotkey = HotkeyType.ToggleSound;
            else if (e.Message.WParam.ToInt32() == hotkeyManager.GetGlobalHotkeyId(HotkeyType.ToggleCamera))
                hotkey = HotkeyType.ToggleCamera;

            if (Interlocked.Exchange(ref hotkeyBusy, 1) == 0)
            {
                Task.Run(() =>
                {
                    try { HandleHotKey(e, hotkey); }
                    finally { Volatile.Write(ref hotkeyBusy, 0); }
                });
            }
        }

        void HandleHotKey(HotkeyEventArgs hotkeyEvent, HotkeyType hotkeyType)
        {
            Keys keyCode = hotkeyEvent.Key & Keys.KeyCode;
            List<VKeys> modifiers = new List<VKeys>();
            if (hotkeyEvent.Modifiers.HasFlag(KeyModifiers.Shift))
                modifiers.Add(VKeys.SHIFT);
            if (hotkeyEvent.Modifiers.HasFlag(KeyModifiers.Control))
                modifiers.Add(VKeys.CONTROL);
            if (hotkeyEvent.Modifiers.HasFlag(KeyModifiers.Alt))
                modifiers.Add(VKeys.MENU);

            int retries = 0;
            bool hotkeyReleased = false;
            while (retries < 4)
            {
                bool modifiersReleased = true;

                foreach (VKeys modifier in modifiers)
                {
                    if (IsKeyDown((int)modifier))
                        modifiersReleased = false;
                }

                if (!IsKeyDown((int)keyCode) && modifiersReleased == true)
                {
                    hotkeyReleased = true;
                    break;
                }

                Console.WriteLine("Not all hotkey keys release, retry {0}", retries);
                retries++;
                Thread.Sleep(100);
            }

            if (hotkeyReleased)
            {
                nint foregroundWindow = WinApiWrapper.GetForegroundWindow();

                List<Window> windows = windowManager.GetAllOpenedWindows();

                if (Settings.Instance.SupportMSTeams)
                {
                    List<Window> msTeamsWindows = windows.Where(x => x.processName.Contains("ms-teams.exe")).ToList();

                    bool actionInvoked = false;
                    foreach (Window window in msTeamsWindows)
                    {

                        switch (hotkeyType)
                        {
                            case HotkeyType.ToggleMute:
                                actionInvoked = automationClient.Invoke(window.windowHandle, "microphone-button");
                                break;
                            case HotkeyType.ToggleCamera:
                                actionInvoked = automationClient.Invoke(window.windowHandle, "video-button");
                                break;
                            default:
                                break;
                        }

                        if (actionInvoked)
                        {
                            WinApiWrapper.SetForegroundWindow(foregroundWindow);
                            break;
                        }
                    }
                }

                foreach (WindowHandler handler in windowHandlerManager.GetWindowHandlers().Where(x => x.handlerActive && (x.toggleMute || x.toggleSound || x.toggleCamera)))
                {
                    List<Window> matchingWindows = windowHandlerManager.GetWindowByWindowHandler(handler, windows);
                    if (matchingWindows.Count > 0)
                    {
                        //Window window = matchingWindows.Where(x => !x.windowText.Contains("Native Error")).FirstOrDefault();
                        Window window = matchingWindows.First();
                        Console.WriteLine("Found window: {0}", window.windowCaption);

                        bool hotkeyIsGlobal = false;
                        if (hotkeyType == HotkeyType.ToggleMute && handler.toggleMuteIsGlobal
                            || hotkeyType == HotkeyType.ToggleSound && handler.toggleSoundIsGlobal
                            || hotkeyType == HotkeyType.ToggleCamera && handler.toggleCameraIsGlobal)
                        {
                            hotkeyIsGlobal = true;
                        }

                        string keyStroke = GetKeyStroke(handler, hotkeyType);
                        if (keyStroke != String.Empty)
                        {
                            if (!hotkeyIsGlobal)
                                WinApiWrapper.SetForegroundWindow(window.windowHandle);

                            SendKeys.SendWait(keyStroke);
                            SendKeys.Flush();

                            if (!hotkeyIsGlobal)
                                WinApiWrapper.SetForegroundWindow(foregroundWindow);
                        }
                    }
                }
            }
        }

        static bool IsKeyDown(int vKey) => (WinApiWrapper.GetAsyncKeyState(vKey) & 0x8000) != 0;
    }

    [LibraryImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool AllocConsole();
}