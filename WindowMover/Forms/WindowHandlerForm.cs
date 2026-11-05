using System.ComponentModel;
using WindowMover.Classes;
using WinApiEnums = WindowMover.Classes.Wrappers.Enums;

namespace WindowMover.Forms;

using Classes.Managers;
using Classes.Wrappers;
using System.Runtime.InteropServices;
using WindowMover.Localization;

public partial class WindowHandlerForm : LocalizedForm
{
    public EditorMode editorMode;
    private WindowManager windowManager;
    private HotkeyRegistrator hotkeyRegistrator;
    private HotkeyManager hotkeyManager;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DialogResult result { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public WindowHandler item { get; set; }

    private JsonStringLocalizer localizer = JsonStringLocalizer.Instance;

    public enum GetSystem_Metrics : int
    {
        SM_CXBORDER = 5,
        SM_CXFULLSCREEN = 16,
        SM_CYFULLSCREEN = 17
    }
    [LibraryImport("user32.dll")]
    public static partial int GetSystemMetrics(int smIndex);

    private nint LastWindow = nint.Zero;

    public WindowHandlerForm(WindowManager windowManager, HotkeyManager hotkeyManager, EditorMode editorMode, WindowHandler? item = null)
    {
        this.windowManager = windowManager;
        this.hotkeyManager = hotkeyManager;

        this.editorMode = editorMode;

        InitializeComponent();
        LocalizeControls();

        if (editorMode == EditorMode.Edit && item != null)
        {
            this.Text = localizer.GetString("views.editHandle", "Edit handle");
            this.item = Helpers.DeepCopy(item);
        }
        else
        {
            this.Text = localizer.GetString("views.addHandle", "Add new handle");
            this.item = new WindowHandler();
        }

        hotkeyRegistrator = new HotkeyRegistrator();
        hotkeyRegistrator.PropertyChanged += HotkeyRegistrator_PropertyChanged;

        //DataSource    
        cbWindowTitle.DropDownStyle = ComboBoxStyle.DropDownList;
        cbWindowTitle.DisplayMember = "Key";
        cbWindowTitle.ValueMember = "Value";
        cbWindowTitle.DataSource = new BindingSource(Dictionaries.windowCompareTemplateDictionary, "");

        cbParentWindowTitle.DropDownStyle = ComboBoxStyle.DropDownList;
        cbParentWindowTitle.DisplayMember = "Key";
        cbParentWindowTitle.ValueMember = "Value";
        cbParentWindowTitle.DataSource = new BindingSource(Dictionaries.windowCompareTemplateDictionary, "");

        //Binding
        tbHandlerName.DataBindings.Add(new Binding("Text", this.item, "handlerName"));

        tbWindowTitle.DataBindings.Add(new Binding("Text", this.item, "windowTitle"));
        cbWindowTitle.DataBindings.Add(new Binding("SelectedValue", this.item, "windowTitleModifier"));
        tbWindowClass.DataBindings.Add(new Binding("Text", this.item, "windowClass"));
        chkWindowClass.DataBindings.Add(new Binding("Checked", this.item, "useWindowClass"));

        tbProcessName.DataBindings.Add(new Binding("Text", this.item, "processName"));
        chkProcessName.DataBindings.Add(new Binding("Checked", this.item, "useProcessName"));

        chkParent.DataBindings.Add(new Binding("Checked", this.item, "useParent"));

        tbParentWindowTitle.DataBindings.Add(new Binding("Text", this.item, "parentWindowTitle"));
        cbParentWindowTitle.DataBindings.Add(new Binding("SelectedValue", this.item, "parentWindowTitleModifier"));
        tbParentWindowClass.DataBindings.Add(new Binding("Text", this.item, "parentWindowClass"));
        chkParentWindowClass.DataBindings.Add(new Binding("Checked", this.item, "useParentWindowClass"));

        tbParentProcessName.DataBindings.Add(new Binding("Text", this.item, "parentProcessName"));
        chkParentProcessName.DataBindings.Add(new Binding("Checked", this.item, "useParentProcessName"));

        chkSetPosition.DataBindings.Add(new Binding("Checked", this.item, "changePosition"));
        tbPositionX.DataBindings.Add(new Binding("Text", this.item, "positionX"));
        tbPositionY.DataBindings.Add(new Binding("Text", this.item, "positionY"));

        chkSetSize.DataBindings.Add(new Binding("Checked", this.item, "changeSize"));
        tbSizeX.DataBindings.Add(new Binding("Text", this.item, "sizeX"));
        tbSizeY.DataBindings.Add(new Binding("Text", this.item, "sizeY"));

        chkAlwaysOnTop.DataBindings.Add(new Binding("Checked", this.item, "alwaysOnTop"));
        chkBorderless.DataBindings.Add(new Binding("Checked", this.item, "borderless"));

        chkToggleMute.DataBindings.Add(new Binding("Checked", this.item, "toggleMute"));
        chkToggleSound.DataBindings.Add(new Binding("Checked", this.item, "toggleSound"));
        chkToggleCamera.DataBindings.Add(new Binding("Checked", this.item, "toggleCamera"));

        chkToggleMuteGlobal.DataBindings.Add(new Binding("Checked", this.item, "toggleMuteIsGlobal"));
        chkToggleSoundGlobal.DataBindings.Add(new Binding("Checked", this.item, "toggleSoundIsGlobal"));
        chkToggleCameraGlobal.DataBindings.Add(new Binding("Checked", this.item, "toggleCameraIsGlobal"));

        tbToggleMuteHotkey.DataBindings.Add(new Binding("Text", this.item, "toggleMuteHotkey"));
        tbToggleSoundHotkey.DataBindings.Add(new Binding("Text", this.item, "toggleSoundHotkey"));
        tbToggleCameraHotkey.DataBindings.Add(new Binding("Text", this.item, "toggleCameraHotkey"));

        pictureBox.MouseDown += pictureBox_MouseDown;
        pictureBox.MouseUp += pictureBox_MouseUp;
        pictureBox.MouseMove += pictureBox_MouseMove;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        item.handlerName = item.handlerName == null ? item.handlerName = "Handle" : item.handlerName;
        item.windowClass = item.windowClass == null ? item.windowClass = "" : item.windowClass;

        DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void ShowInvertRectTracker(nint window)
    {
        if (window != nint.Zero)
        {
            Rectangle WindowRect = windowManager.GetWindowRect(window);
            nint dc = WinApiWrapper.GetWindowDC(window);

            GdiApiWrapper.SetROP2(dc, (int)GdiApiWrapper.RopMode.R2_NOT);

            Color color = Color.FromArgb(0, 255, 0);
            nint Pen = GdiApiWrapper.CreatePen((int)GdiApiWrapper.PenStyles.PS_INSIDEFRAME, 3 * GetSystemMetrics((int)GetSystem_Metrics.SM_CXBORDER), (uint)color.ToArgb());

            nint OldPen = GdiApiWrapper.SelectObject(dc, Pen);
            nint OldBrush = GdiApiWrapper.SelectObject(dc, GdiApiWrapper.GetStockObject((int)GdiApiWrapper.StockObjects.NULL_BRUSH));
            GdiApiWrapper.Rectangle(dc, 0, 0, WindowRect.Width, WindowRect.Height);

            GdiApiWrapper.SelectObject(dc, OldBrush);
            GdiApiWrapper.SelectObject(dc, OldPen);

            WinApiWrapper.ReleaseDC(window, dc);
            GdiApiWrapper.DeleteObject(Pen);
        }
    }

    private nint WindowFromPoint(Point point)
    {
        nint Window = WinApiWrapper.WindowFromPoint(point);
        if (Window == nint.Zero)
            return nint.Zero;
        return Window;
    }

    private nint ChildWindowFromPoint(WinApiWrapper.POINT point)
    {
        nint WindowParent = WinApiWrapper.WindowFromPoint(point);
        if (WindowParent == nint.Zero)
            return nint.Zero;

        if (WinApiWrapper.ScreenToClient(WindowParent, ref point) == false)
            throw new Exception("ScreenToClient failed");

        nint WindowChild = WinApiWrapper.ChildWindowFromPointEx(WindowParent, point, 0);
        if (WindowChild == nint.Zero)
            return WindowParent;

        if (WinApiWrapper.ClientToScreen(WindowParent, ref point) == false)
            throw new Exception("ClientToScreen failed");

        if (WinApiWrapper.IsChild(WinApiWrapper.GetParent(WindowChild), WindowChild) == false)
            return WindowChild;

        List<nint> WindowList = new List<nint>();
        while (WindowChild != nint.Zero)
        {
            Rectangle rect = windowManager.GetWindowRect(WindowChild);
            if (rect.Contains(point))
                WindowList.Add(WindowChild);
            WindowChild = WinApiWrapper.GetWindow(WindowChild, (uint)WinApiEnums.Cmd.GW_nintNEXT);
        }

        int MinPixel = GetSystemMetrics((int)GetSystem_Metrics.SM_CXFULLSCREEN) * GetSystemMetrics((int)GetSystem_Metrics.SM_CYFULLSCREEN);
        for (int i = 0; i < WindowList.Count; ++i)
        {
            Rectangle rect = windowManager.GetWindowRect(WindowList[i]);
            int ChildPixel = rect.Width * rect.Height;
            if (ChildPixel < MinPixel)
            {
                MinPixel = ChildPixel;
                WindowChild = WindowList[i];
            }
        }
        return WindowChild;
    }

    private void DisplayWindowInfo(nint window)
    {
        if (window != nint.Zero)
        {
            tbWindowTitle.Text = windowManager.GetCaptionOfWindow(window);
            tbWindowClass.Text = windowManager.GetClassNameOfWindow(window);
            tbProcessName.Text = windowManager.GetProcessPathOfWindow(window);

            item.windowTitle = windowManager.GetCaptionOfWindow(window);
            item.windowClass = windowManager.GetClassNameOfWindow(window);
            item.processName = windowManager.GetProcessPathOfWindow(window);

            Rectangle rectangle = windowManager.GetWindowRect(window);

            tbPositionX.Text = rectangle.X.ToString();
            tbPositionY.Text = rectangle.Y.ToString();
            tbSizeX.Text = rectangle.Width.ToString();
            tbSizeY.Text = rectangle.Height.ToString();

            item.positionX = rectangle.X;
            item.positionY = rectangle.Y;
            item.sizeX = rectangle.Width;
            item.sizeY = rectangle.Height;

            nint nintParent = WinApiWrapper.GetParent(window);
            if (nintParent.ToInt64() > 0)
            {
                tbParentWindowTitle.Text = windowManager.GetCaptionOfWindow(nintParent);
                tbParentWindowClass.Text = windowManager.GetClassNameOfWindow(nintParent);
                tbParentProcessName.Text = windowManager.GetProcessPathOfWindow(nintParent);

                item.parentWindowTitle = windowManager.GetCaptionOfWindow(nintParent);
                item.parentWindowClass = windowManager.GetClassNameOfWindow(nintParent);
                item.parentProcessName = windowManager.GetProcessPathOfWindow(nintParent);
            }
            else
            {
                tbParentWindowTitle.Text = "";
                tbParentWindowClass.Text = "";
                tbParentProcessName.Text = "";

                item.parentWindowTitle = "";
                item.parentWindowClass = "";
                item.parentProcessName = "";
            }
        }
    }

    private void pictureBox_MouseDown(object? sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Cursor = Cursors.Cross;
        }
    }

    private void pictureBox_MouseMove(object? sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (Cursor != Cursors.Default)
        {
            nint FoundWindow = nint.Zero;
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                FoundWindow = ChildWindowFromPoint(Cursor.Position);
            }
            else
            {
                FoundWindow = WindowFromPoint(Cursor.Position);
            }

            if (Control.FromHandle(FoundWindow) == null)
            {
                if (FoundWindow != LastWindow)
                {
                    ShowInvertRectTracker(LastWindow);
                    LastWindow = FoundWindow;
                    ShowInvertRectTracker(LastWindow);
                }
                DisplayWindowInfo(LastWindow);
            }
        }
    }

    private void pictureBox_MouseUp(object? sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (Cursor != Cursors.Default)
        {
            ShowInvertRectTracker(LastWindow);
            LastWindow = nint.Zero;

            Cursor = Cursors.Default;
        }
    }

    private void btnRegisterToggleMute_Click(object sender, EventArgs e)
    {
        this.ToggleHotKeyButton_Clicked(sender, HotkeyType.ToggleMute, tbToggleMuteHotkey);
    }

    private void btnRegisterToggleMute_KeyDown(object sender, KeyEventArgs e)
    {
        this.ToggleHotKeyButton_KeyDown(sender, e, item, "toggleMuteHotkey");
    }

    private void btnRegisterToggleSound_Click(object sender, EventArgs e)
    {
        this.ToggleHotKeyButton_Clicked(sender, HotkeyType.ToggleSound, tbToggleSoundHotkey);
    }

    private void btnRegisterToggleSound_KeyDown(object sender, KeyEventArgs e)
    {
        this.ToggleHotKeyButton_KeyDown(sender, e, item, "toggleSoundHotkey");
    }

    private void btnRegisterToggleCamera_Click(object sender, EventArgs e)
    {
        this.ToggleHotKeyButton_Clicked(sender, HotkeyType.ToggleCamera, tbToggleCameraHotkey);
    }

    private void btnRegisterToggleCamera_KeyDown(object sender, KeyEventArgs e)
    {
        this.ToggleHotKeyButton_KeyDown(sender, e, item, "toggleCameraHotkey");
    }

    private void SetActiveHotkeyType(HotkeyType hotkey)
    {
        hotkeyRegistrator.ActiveHotkeyType = hotkey;
    }

    private void HotkeyRegistrator_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(hotkeyRegistrator.ActiveHotkeyType))
        {
            string record = localizer.GetString("buttons.record", "Register");
            string finish = localizer.GetString("buttons.finish", "Finish");

            this.btnRegisterToggleMute.Text = record;
            this.btnRegisterToggleSound.Text = record;
            this.btnRegisterToggleCamera.Text = record;
            switch (hotkeyRegistrator.ActiveHotkeyType)
            {
                case HotkeyType.None:
                    break;
                case HotkeyType.ToggleMute:
                    btnRegisterToggleMute.Text = finish;
                    break;
                case HotkeyType.ToggleSound:
                    btnRegisterToggleSound.Text = finish;
                    break;
                case HotkeyType.ToggleCamera:
                    btnRegisterToggleCamera.Text = finish;
                    break;
                default:
                    break;
            }
        }
    }

    private TextBox? activeHotkeyTextBox;

    public void ToggleHotKeyButton_Clicked(object sender, HotkeyType hotkey, TextBox textBox)
    {
        hotkeyRegistrator.ActiveHotkeyType = hotkeyRegistrator.ActiveHotkeyType == hotkey ? HotkeyType.None : hotkey;
        activeHotkeyTextBox = textBox;
    }

    public void ToggleHotKeyButton_KeyDown(object sender, KeyEventArgs e, object settings, string propertyName)
    {
        if (hotkeyRegistrator.ActiveHotkeyType != HotkeyType.None && activeHotkeyTextBox != null)
            hotkeyManager.SimulateGlobalToggleHotkeyRegistration(hotkeyRegistrator.ActiveHotkeyType, SetActiveHotkeyType, activeHotkeyTextBox, e, settings, propertyName);
    }
}
