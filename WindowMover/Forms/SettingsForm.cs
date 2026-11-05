using System.ComponentModel;
using WindowMover.Classes;
using WindowMover.Classes.Managers;
using WindowMover.Localization;
using WindowMover.TaskDialogs;

namespace WindowMover.Forms;

public partial class SettingsForm : LocalizedForm
{
    private WindowManager windowManager;
    private WindowHandlerManager windowHandlerManager;
    private HotkeyRegistrator hotkeyRegistrator;
    private HotkeyManager hotkeyManager;

    private JsonStringLocalizer localizer = JsonStringLocalizer.Instance;
    public SettingsForm(WindowManager windowManager, WindowHandlerManager windowHandlerManager, HotkeyManager hotkeyManager)
    {
        this.windowManager = windowManager;
        this.windowHandlerManager = windowHandlerManager;
        this.hotkeyManager = hotkeyManager;

        InitializeComponent();

        clActive.Tag = "l10n:columns.active";
        clName.Tag = "l10n:columns.name";
        LocalizeControls();

        hotkeyRegistrator = new HotkeyRegistrator();
        hotkeyRegistrator.PropertyChanged += HotkeyRegistrator_PropertyChanged;

        this.nudSetPositions.DataBindings.Add(new System.Windows.Forms.Binding("Value", Settings.Instance, "TimerSetPositionTimeout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
        this.Location = Settings.Instance.WindowSettingsLocation;
        this.Size = Settings.Instance.WindowSettingsSize;

        dgVHandlers.AllowDrop = false;
        dgVHandlers.MultiSelect = false;
        dgVHandlers.AutoGenerateColumns = false;
        dgVHandlers.AllowUserToAddRows = false;
        dgVHandlers.DataSource = windowHandlerManager.windowHandlers;

        dgVHandlers.AllowUserToResizeColumns = false;
        dgVHandlers.AllowUserToOrderColumns = false;

        clActive.DataPropertyName = "handlerActive";
        clName.DataPropertyName = "handlerName";

        tbToggleMuteHotkey.DataBindings.Add(new Binding("Text", Settings.Instance, "ToggleMuteHotkey"));
        tbToggleSoundHotkey.DataBindings.Add(new Binding("Text", Settings.Instance, "ToggleSoundHotkey"));
        tbToggleCameraHotkey.DataBindings.Add(new Binding("Text", Settings.Instance, "ToggleCameraHotkey"));

        chkSupportMSTeams.DataBindings.Add(new Binding("Checked", Settings.Instance, "SupportMSTeams"));

        cbLanguages.DataBindings.Add(new Binding("SelectedValue", Settings.Instance, "Language"));

        SetupLanguagePicker();
    }

    private void SetupLanguagePicker()
    {
        List<Language> languages = JsonStringLocalizer.Instance.GetAvailableLanguages();
        cbLanguages.DisplayMember = "Name";
        cbLanguages.ValueMember = "Value";
        cbLanguages.DataSource = languages;

        cbLanguages.SelectedValue = Settings.Instance.Language;

        cbLanguages.SelectedIndexChanged += cbLanguages_SelectedValueChanged;
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
        //Data Grid not showing at first time ugly fix; done before the form is visible to avoid flicker
        this.settingsTabControl.SelectedIndex = 1;
        this.settingsTabControl.SelectedIndex = 0;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        WindowHandlerForm form = new Forms.WindowHandlerForm(windowManager, hotkeyManager, EditorMode.New);
        DialogResult result = form.ShowDialog();
        if (result == DialogResult.OK)
        {
            if (windowHandlerManager.CheckIfElementExists(form.item))
            {
                InformationalDialog.Create(localizer.GetString("dialogs.handleExists.title", "Handle exists"), localizer.GetString("dialogs.handleExists.message", "Handle with given name already exists!"), localizer.GetString("dialogs.handleExists.okText", "OK"), this);
            }
            else
            {
                windowHandlerManager.Add(form.item);
                RefreshAndSave();
            }
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgVHandlers.CurrentRow?.DataBoundItem is WindowHandler handler)
        {
            WindowHandlerForm form = new Forms.WindowHandlerForm(windowManager, hotkeyManager, Classes.EditorMode.Edit, handler);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                windowHandlerManager.Update(form.item);
                RefreshAndSave();
            }
        }
        else
            return;
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (dgVHandlers.CurrentRow == null)
            return;

        QuestionDialog.Create(localizer.GetString("dialogs.handleDelete.title", "Handle deletion"), localizer.GetString("dialogs.handleDelete.message", "Are you sure you want to delete handle?"),
            localizer.GetString("dialogs.handleDelete.yesText", "Delete"),
            localizer.GetString("dialogs.handleDelete.noText", "Cancel"),
            () =>
            {
                if (dgVHandlers.CurrentRow?.DataBoundItem is WindowHandler handler)
                {
                    windowHandlerManager.Remove(handler);
                    RefreshAndSave();
                }
            },
            () => { },
            this
        );
    }

    private void RefreshAndSave()
    {
        dgVHandlers.Invalidate();
        windowHandlerManager.Save();
    }

    private void btnSetPosition_Click(object sender, EventArgs e)
    {
        windowHandlerManager.SetPositions(windowManager);
    }

    private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            if (Settings.Instance.GetSettingsChanged())
            {
                QuestionDialog.Create("WindowMover", localizer.GetString("dialogs.settingsChanged.message", "The settings has been changed, do you want to save them?"),
                    localizer.GetString("dialogs.settingsChanged.yesText", "Yes"),
                    localizer.GetString("dialogs.settingsChanged.noText", "No"),
                    () => { },
                    () =>
                    {
                        Settings.Instance.Load();
                        hotkeyManager.ReloadHotKeys();
                    },
                    this
                );
            }

            Settings.Instance.WindowSettingsLocation = this.Location;

            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Instance.WindowSettingsSize = this.Size;
            }
            else
            {
                Settings.Instance.WindowSettingsSize = this.RestoreBounds.Size;
            }

            Settings.Instance.Save();

            if (Settings.Instance.Language != JsonStringLocalizer.Instance.GetCurrentLanguage())
                Program.Restart();
        }
    }

    private void btnSaveSettings_Click(object sender, EventArgs e)
    {
        Settings.Instance.Save();
        Settings.Instance.SetSettingsChanged(false);
    }


    private void chkSupportMSTeams_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked != Settings.Instance.SupportMSTeams)
        {
            Settings.Instance.SetSettingsChanged(true);
        }
    }

    private void dgVHandlers_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        // Checkbox cells otherwise only commit when the cell loses focus.
        if (dgVHandlers.IsCurrentCellDirty && dgVHandlers.CurrentCell is DataGridViewCheckBoxCell)
            dgVHandlers.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgVHandlers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        windowHandlerManager.Save();
    }

    private void btnRegisterToggleMute_Click(object sender, EventArgs e)
    {
        this.ToggleHotKeyButton_Clicked(sender, HotkeyType.ToggleMute, tbToggleMuteHotkey);
    }

    private void btnRegisterToggleMute_KeyDown(object sender, KeyEventArgs e)
    {
        this.ToggleHotKeyButton_KeyDown(sender, e, Settings.Instance, "ToggleMuteHotkey");
    }

    private void btnRegisterToggleSound_Click(object sender, EventArgs e)
    {
        this.ToggleHotKeyButton_Clicked(sender, HotkeyType.ToggleSound, tbToggleSoundHotkey);
    }

    private void btnRegisterToggleSound_KeyDown(object sender, KeyEventArgs e)
    {
        this.ToggleHotKeyButton_KeyDown(sender, e, Settings.Instance, "ToggleSoundHotkey");
    }

    private void btnRegisterToggleCamera_Click(object sender, EventArgs e)
    {
        this.ToggleHotKeyButton_Clicked(sender, HotkeyType.ToggleCamera, tbToggleCameraHotkey);
    }

    private void btnRegisterToggleCamera_KeyDown(object sender, KeyEventArgs e)
    {
        this.ToggleHotKeyButton_KeyDown(sender, e, Settings.Instance, "ToggleCameraHotkey");
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
            hotkeyManager.RegisterGlobalToggleHotkey(hotkeyRegistrator.ActiveHotkeyType, SetActiveHotkeyType, activeHotkeyTextBox, e, settings, propertyName);
    }

    private void cbLanguages_SelectedValueChanged(object? sender, EventArgs e)
    {
        if (sender is ComboBox comboBox && comboBox.Items.Count > 0 && comboBox.SelectedValue?.ToString() is { } language)
            Settings.Instance.Language = language;
    }
}
