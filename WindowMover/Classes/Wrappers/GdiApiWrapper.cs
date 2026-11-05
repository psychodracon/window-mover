using System.Runtime.InteropServices;

namespace WindowMover.Classes.Wrappers;

public static partial class GdiApiWrapper
{
    public enum RopMode : int
    {
        R2_NOT = 6
    }
    [LibraryImport("gdi32.dll")]
    public static partial int SetROP2(nint hdc, int fnDrawMode);

    public enum PenStyles : int
    {
        PS_INSIDEFRAME = 6
    }
    [LibraryImport("gdi32.dll")]
    public static partial nint CreatePen(int fnPenStyle, int nWidth, uint crColor);

    [LibraryImport("gdi32.dll")]
    public static partial nint SelectObject(nint hdc, nint hgdiobj);

    public enum StockObjects : int
    {
        NULL_BRUSH = 5
    }
    [LibraryImport("gdi32.dll")]
    public static partial nint GetStockObject(int fnObject);

    [LibraryImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool Rectangle(nint hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [LibraryImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool DeleteObject(nint hObject);
}
