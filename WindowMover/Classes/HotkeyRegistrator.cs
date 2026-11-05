using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WindowMover.Classes.Managers;

public class HotkeyRegistrator : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private HotkeyType activeHotkeyType = HotkeyType.None;
    public HotkeyType ActiveHotkeyType
    {
        get { return this.activeHotkeyType; }
        set
        {
            this.activeHotkeyType = value;
            NotifyPropertyChanged();
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
