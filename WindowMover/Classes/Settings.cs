using System.Text.Json.Serialization;

namespace WindowMover.Classes;

[Serializable]
public partial class Settings
{
    private static Settings? _instance;
    public static Settings Instance
    {
        get
        {
            if (_instance == null) { _instance = new Settings(); }
            return _instance;
        }
    }

    private bool settingsChanged { get; set; }

    private System.Drawing.Point windowSettingsLocation = new System.Drawing.Point();
    public System.Drawing.Point WindowSettingsLocation
    {
        get { return windowSettingsLocation; }
        set
        {
            if (value != windowSettingsLocation)
            {
                windowSettingsLocation = value; settingsChanged = true;
            }
        }
    }

    private System.Drawing.Size windowSettingsSize = new System.Drawing.Size();
    public System.Drawing.Size WindowSettingsSize
    {
        get { return windowSettingsSize; }
        set
        {
            if (value != windowSettingsSize) { windowSettingsSize = value; settingsChanged = true; }
        }
    }

    private int timerFullscreenDetectionTimeout;
    public int TimerFullscreenDetectionTimeout
    {
        get { return timerFullscreenDetectionTimeout; }
        set
        {
            if (value != timerFullscreenDetectionTimeout)
            {
                timerFullscreenDetectionTimeout = value; settingsChanged = true;
            }
        }
    }

    private int timerSetPositionTimeout;
    public int TimerSetPositionTimeout
    {
        get { return timerSetPositionTimeout; }
        set
        {
            if (value != timerSetPositionTimeout) { timerSetPositionTimeout = value; settingsChanged = true; }
        }
    }

    private bool positioning;
    public bool Positioning
    {
        get { return positioning; }
        set
        {
            if (value != positioning) { positioning = value; settingsChanged = true; }
        }
    }

    private Keys toggleMuteHotkey;
    public Keys ToggleMuteHotkey
    {
        get { return toggleMuteHotkey; }
        set
        {
            if (value != toggleMuteHotkey) { toggleMuteHotkey = value; settingsChanged = true; }
        }
    }

    private Keys toggleSoundHotkey;
    public Keys ToggleSoundHotkey
    {
        get { return toggleSoundHotkey; }
        set
        {
            if (value != toggleSoundHotkey) { toggleSoundHotkey = value; settingsChanged = true; }
        }
    }

    private Keys toggleCameraHotkey;
    public Keys ToggleCameraHotkey
    {
        get { return toggleCameraHotkey; }
        set
        {
            if (value != toggleCameraHotkey) { toggleCameraHotkey = value; settingsChanged = true; }
        }
    }

    private bool supportMSTeams;
    public bool SupportMSTeams
    {
        get { return supportMSTeams; }
        set
        {
            if (value != supportMSTeams) { supportMSTeams = value; settingsChanged = true; }
        }
    }

    private string language;
    public string Language
    {
        get { return language; }
        set
        {
            if (value != language) { language = value; settingsChanged = true; }
        }
    }

    [JsonConstructorAttribute]
    private Settings()
    {
        this.language = "en-US";
        this.windowSettingsLocation = new System.Drawing.Point(0, 0);
        this.windowSettingsSize = new System.Drawing.Size(500, 500);
        this.timerFullscreenDetectionTimeout = 1500;
        this.timerSetPositionTimeout = 2500;
        this.positioning = true;
        this.settingsChanged = false;
    }

    public bool Save()
    {
        System.IO.Directory.CreateDirectory(Helpers.GetSettingsPath());
        byte[] arrayToSave = Helpers.ObjectToByteArray(Instance);
        bool done = Helpers.ByteArrayToFile(String.Format("{0}\\settings.dat", Helpers.GetSettingsPath()), arrayToSave);

        return done;
    }

    public bool Load()
    {
        if (System.IO.Directory.Exists(Helpers.GetSettingsPath()))
        {
            byte[]? arrayToSave = Helpers.FileToByteArray(String.Format("{0}\\settings.dat", Helpers.GetSettingsPath()));
            if (arrayToSave != null)
                _instance = Helpers.ByteArrayToObject<Settings>(arrayToSave);
            else
                return false;
        }
        return true;
    }

    public void SetSettingsChanged(bool settingsChanged)
    {
        this.settingsChanged = settingsChanged;
    }

    public bool GetSettingsChanged()
    {
        return this.settingsChanged;
    }
}
