namespace WindowMover.Classes.Managers;

public class HotkeyManager
{
    private readonly KeysConverter keysConverter = new KeysConverter();
    private Keys toggleMuteHotkey = Settings.Instance.ToggleMuteHotkey;
    private int toggleMuteHotkeyId;
    private Keys toggleSoundHotkey = Settings.Instance.ToggleSoundHotkey;
    private int toggleSoundHotKeyId;
    private Keys toggleCameraHotkey = Settings.Instance.ToggleCameraHotkey;
    private int toggleCameraHotkeyId;

    public void RegisterHotKeys()
    {
        if (toggleMuteHotkey != Keys.None)
            toggleMuteHotkeyId = HotkeyHandler.RegisterHotKey((uint)Helpers.ConvertKeys(toggleMuteHotkey)[0], (uint)Helpers.ConvertKeys(toggleMuteHotkey)[1]);
        if (toggleSoundHotkey != Keys.None)
            toggleSoundHotKeyId = HotkeyHandler.RegisterHotKey((uint)Helpers.ConvertKeys(toggleSoundHotkey)[0], (uint)Helpers.ConvertKeys(toggleSoundHotkey)[1]);
        if (toggleCameraHotkey != Keys.None)
            toggleCameraHotkeyId = HotkeyHandler.RegisterHotKey((uint)Helpers.ConvertKeys(toggleCameraHotkey)[0], (uint)Helpers.ConvertKeys(toggleCameraHotkey)[1]);
    }

    public void UnregisterHotKeys()
    {
        HotkeyHandler.UnregisterHotKey(toggleMuteHotkeyId);
        HotkeyHandler.UnregisterHotKey(toggleSoundHotKeyId);
        HotkeyHandler.UnregisterHotKey(toggleCameraHotkeyId);
    }

    public void ReloadHotKeys()
    {
        UnregisterHotKeys();
        toggleMuteHotkey = Settings.Instance.ToggleMuteHotkey;
        toggleSoundHotkey = Settings.Instance.ToggleSoundHotkey;
        toggleCameraHotkey = Settings.Instance.ToggleCameraHotkey;
        toggleMuteHotkeyId = toggleSoundHotKeyId = toggleCameraHotkeyId = 0;
        RegisterHotKeys();
    }

    public int GetGlobalHotkeyId(HotkeyType hotkeyType)
    {
        switch (hotkeyType)
        {
            case HotkeyType.ToggleMute:
                return toggleMuteHotkeyId;
            case HotkeyType.ToggleSound:
                return toggleSoundHotKeyId;
            case HotkeyType.ToggleCamera:
                return toggleCameraHotkeyId;
            default:
                return 0;
        }
    }

    private void RegisterGlobalHotkey(KeyEventArgs e, Action<HotkeyType> setActiveHotKey, TextBox textBox, ref Keys hotkey, ref int id, bool simulate = false)
    {
        if (e != null)
        {
            if (e.KeyData.HasFlag(Keys.LWin) || e.KeyData.HasFlag(Keys.RWin))
            {
                // Windows keys aren't really supported
                setActiveHotKey(HotkeyType.None);
                // TODO: Recover previous value
                return;
            }

            if (e.KeyData == Keys.Escape)
            {
                setActiveHotKey(HotkeyType.None);
                // TODO: Recover previous value
                return;
            }

            if (e.KeyData == Keys.Back)
            {
                if (simulate == false) HotkeyHandler.UnregisterHotKey(id);
                setActiveHotKey(HotkeyType.None);
                textBox.Clear();
                return;
            }

            int modifiers = 0;
            if (e.Alt) // 262144
                modifiers |= 1;
            if (e.Control) // 131072
                modifiers |= 2;
            if (e.Shift) // 65536
                modifiers |= 4;

            if (simulate == false)
            {
                HotkeyHandler.UnregisterHotKey(id);
                id = HotkeyHandler.RegisterHotKey((uint)e.KeyCode, (uint)modifiers);
            }

            hotkey = e.KeyData;
            textBox.Text = keysConverter.ConvertToString(e.KeyData);
        }
    }

    private void SetSettingsValue(object settings, KeyEventArgs e, string propertyName)
    {
        if (e.KeyData == Keys.Back)
            Helpers.SetPropertyValue(settings, propertyName, new Keys());
        else if (!e.KeyData.HasFlag(Keys.LWin) && !e.KeyData.HasFlag(Keys.RWin) && e.KeyData != Keys.Escape)
            Helpers.SetPropertyValue(settings, propertyName, e.KeyData);
    }

    public void RegisterGlobalToggleHotkey(HotkeyType hotkey, Action<HotkeyType> setActiveHotKey, TextBox textBox, KeyEventArgs e, object settings, string propertyName)
    {
        this.HandleGlobalToggleHotkeyRegistration(hotkey, setActiveHotKey, textBox, e, settings, propertyName);
    }

    public void SimulateGlobalToggleHotkeyRegistration(HotkeyType hotkey, Action<HotkeyType> setActiveHotKey, TextBox textBox, KeyEventArgs e, object settings, string propertyName)
    {
        this.HandleGlobalToggleHotkeyRegistration(hotkey, setActiveHotKey, textBox, e, settings, propertyName, true);
    }

    private void HandleGlobalToggleHotkeyRegistration(HotkeyType hotkey, Action<HotkeyType> setActiveHotKey, TextBox textBox, KeyEventArgs e, object settings, string propertyName, bool simulate = false)
    {
        switch (hotkey)
        {
            case HotkeyType.ToggleMute:
                this.RegisterGlobalHotkey(e, setActiveHotKey, textBox, ref toggleMuteHotkey, ref toggleMuteHotkeyId, simulate);
                break;
            case HotkeyType.ToggleSound:
                this.RegisterGlobalHotkey(e, setActiveHotKey, textBox, ref toggleSoundHotkey, ref toggleSoundHotKeyId, simulate);
                break;
            case HotkeyType.ToggleCamera:
                this.RegisterGlobalHotkey(e, setActiveHotKey, textBox, ref toggleCameraHotkey, ref toggleCameraHotkeyId, simulate);
                break;
            default:
                break;
        }
        SetSettingsValue(settings, e, propertyName);
    }

    public string GetToggleHotKeyText(HotkeyType hotkey)
    {
        string result = "";

        switch (hotkey)
        {
            case HotkeyType.ToggleMute:
                result = keysConverter.ConvertToString(toggleMuteHotkey) ?? "";
                break;
            case HotkeyType.ToggleSound:
                result = keysConverter.ConvertToString(toggleSoundHotkey) ?? "";
                break;
            case HotkeyType.ToggleCamera:
                result = keysConverter.ConvertToString(toggleCameraHotkey) ?? "";
                break;
            default:
                break;
        }

        return result;
    }
}

public enum HotkeyType
{
    None = 0,
    ToggleMute = 1,
    ToggleSound = 2,
    ToggleCamera = 3,
    GoogleMeetMute = 4,
    GoogleMeetCamera = 5
}
