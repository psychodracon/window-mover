using System.Text.Json.Serialization;

namespace WindowMover.Classes;

[Serializable]
public partial class WindowHandler : ICloneable
{
    public string? handlerName { get; set; }

    public bool handlerActive { get; set; }

    public string? windowTitle { get; set; }
    public WindowCompareTemplate windowTitleModifier { get; set; }
    public string? windowClass { get; set; }
    public bool useWindowClass { get; set; }
    public string? windowText { get; set; }
    public string? windowHiddenText { get; set; }

    public string? processName { get; set; }
    public bool useProcessName { get; set; }

    public bool useParent { get; set; }

    public string? parentWindowTitle { get; set; }
    public WindowCompareTemplate parentWindowTitleModifier { get; set; }
    public string? parentWindowClass { get; set; }
    public bool useParentWindowClass { get; set; }

    public string? parentProcessName { get; set; }
    public bool useParentProcessName { get; set; }

    public bool changePosition { get; set; }
    public int positionX { get; set; }
    public int positionY { get; set; }
    public bool changeSize { get; set; }
    public int sizeX { get; set; }
    public int sizeY { get; set; }
    public bool alwaysOnTop { get; set; }
    public bool borderless { get; set; }

    public long lastHandle { get; set; }

    public bool toggleMute { get; set; }
    public bool toggleSound { get; set; }
    public bool toggleCamera { get; set; }

    public bool toggleMuteIsGlobal { get; set; }
    public bool toggleSoundIsGlobal { get; set; }
    public bool toggleCameraIsGlobal { get; set; }

    public Keys toggleMuteHotkey { get; set; }
    public Keys toggleSoundHotkey { get; set; }
    public Keys toggleCameraHotkey { get; set; }

    public Guid guid { get; set; }

    [JsonConstructorAttribute]
    public WindowHandler()
    {
        this.guid = Guid.NewGuid();
        this.handlerActive = true;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

[Serializable]
class WindowHandlerExists : Exception
{
    public WindowHandlerExists() { }

    public WindowHandlerExists(string? handlerName)
        : base(String.Format("Handle with name: {0}, already exists!", handlerName))
    {

    }
}
