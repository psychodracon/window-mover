namespace WindowMover.Classes;

public class Window
{
    public nint windowHandle;
    public nint firstChildHandle;
    public string windowCaption = "";
    public string windowClass = "";
    public string windowText = "";
    public string processName = "";

    public int positionX;
    public int positionY;
    public int sizeX;
    public int sizeY;

    public Window? windowParent;

    public Window()
    { }

    public Window(nint windowHandle, string windowCaption, string windowClass, string processName, int positionX, int positionY, int sizeX, int sizeY)
    {
        this.windowHandle = windowHandle;
        this.windowCaption = windowCaption;
        this.windowClass = windowClass;
        this.processName = processName;
        this.positionX = positionX;
        this.positionY = positionY;
        this.sizeX = sizeX;
        this.sizeY = sizeY;
    }
}
