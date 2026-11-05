using WindowMover.Classes;

namespace WindowMover;

using Classes.Managers;
using System.Threading.Tasks;
using Velopack;
using Velopack.Sources;

using WindowMover.Localization;
using WindowMover.TaskDialogs;

class ContextMenus
{
    private WindowManager windowManager;
    private WindowHandlerManager windowHandlerManager;
    private TimerManager timerManager;
    private HotkeyManager hotkeyManager;

    private JsonStringLocalizer localizer = JsonStringLocalizer.Instance;

    bool isAboutLoaded = false;
    Forms.SettingsForm? settingsForm;

    bool isPositioningChecked = true;

    public ContextMenus(WindowManager windowManager, WindowHandlerManager windowHandlerManager, TimerManager timerManager, HotkeyManager hotkeyManager)
    {
        this.windowManager = windowManager;
        this.windowHandlerManager = windowHandlerManager;
        this.timerManager = timerManager;
        this.hotkeyManager = hotkeyManager;

        Task.Run(CheckForUpdates);
    }

    private ToolStripMenuItem? positioningItem;
    private ToolStripMenuItem? settingsItem;
    private ToolStripMenuItem? exitItem;

    public ContextMenuStrip Create()
    {
        ContextMenuStrip menu = new ContextMenuStrip();
        ToolStripSeparator sep;

        positioningItem = new ToolStripMenuItem();
        positioningItem.CheckOnClick = true;
        positioningItem.Checked = Settings.Instance.Positioning;
        positioningItem.Text = localizer.GetString("checkboxes.setPositions", "Set positions");
        positioningItem.Click += new EventHandler(Positioning_Click);
        menu.Items.Add(positioningItem);

        sep = new ToolStripSeparator();
        menu.Items.Add(sep);

        settingsItem = new ToolStripMenuItem();
        settingsItem.Text = localizer.GetString("menus.settings", "Settings");
        settingsItem.Click += new EventHandler(Settings_Click);
        menu.Items.Add(settingsItem);

        //item = new ToolStripMenuItem();
        //item.Text = "O programie";
        //item.Click += new EventHandler(About_Click);
        //menu.Items.Add(item);

        sep = new ToolStripSeparator();
        menu.Items.Add(sep);

        exitItem = new ToolStripMenuItem();
        exitItem.Text = localizer.GetString("menus.exit", "Exit");
        exitItem.Click += new System.EventHandler(Exit_Click);
        menu.Items.Add(exitItem);

        return menu;
    }

    void CheckForUpdates()
    {
        Velopack.UpdateManager updateManager = new Velopack.UpdateManager(new GithubSource("https://github.com/psychodracon/window-mover", null, false));
        try
        {
            UpdateInfo? updateInfo = updateManager.CheckForUpdates();
            if (updateInfo != null)
            {
                QuestionDialog.Create(localizer.GetString("dialogs.updateAvailable.title", "WindowMover"), localizer.GetString("dialogs.updateAvailable.message", "New application version is available, do you want to update?"),
                    localizer.GetString("dialogs.updateAvailable.yesText", "Yes"),
                    localizer.GetString("dialogs.updateAvailable.noText", "No"),
                    () =>
                    {
                        Task.Run(() =>
                        {
                            updateManager.DownloadUpdates(updateInfo);
                            updateManager.ApplyUpdatesAndRestart(updateInfo);
                        });
                    }, () => { });
            }

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    void Positioning_Click(object? sender, EventArgs e)
    {
        if (sender is not ToolStripMenuItem menuItem)
            return;

        isPositioningChecked = menuItem.Checked;

        if (isPositioningChecked)
        {
            timerManager.EnableSetWindowPositionTimer();
        }
        if (!isPositioningChecked)
        {
            timerManager.DisableSetWindowPositionTimer();

        }

        Settings.Instance.Positioning = menuItem.Checked;
        Settings.Instance.Save();
    }

    void Settings_Click(object? sender, EventArgs e)
    {
        ShowSettings();
    }

    public void ShowSettings()
    {
        if (settingsForm != null)
        {
            if (settingsForm.WindowState == FormWindowState.Minimized)
                settingsForm.WindowState = FormWindowState.Normal;
            settingsForm.Activate();
            return;
        }

        Settings.Instance.SetSettingsChanged(false);
        // Both save all settings, which would persist unconfirmed changes from the open form.
        SetMenuItemsEnabled(false);
        try
        {
            using (settingsForm = new Forms.SettingsForm(windowManager, windowHandlerManager, hotkeyManager))
            {
                settingsForm.ShowDialog();
            }
        }
        finally
        {
            settingsForm = null;
            SetMenuItemsEnabled(true);
        }

        if (Settings.Instance.Positioning)
            timerManager.RestartSetWindowPositionTimer();
    }

    private void SetMenuItemsEnabled(bool enabled)
    {
        if (positioningItem != null)
            positioningItem.Enabled = enabled;
        if (exitItem != null)
            exitItem.Enabled = enabled;
    }

    void About_Click(object? sender, EventArgs e)
    {
        if (!isAboutLoaded)
        {
            isAboutLoaded = true;

            new AboutForm().ShowDialog();

            isAboutLoaded = false;
        }
    }

    void Exit_Click(object? sender, EventArgs e)
    {
        Settings.Instance.Save();

        hotkeyManager.UnregisterHotKeys();

        Application.Exit();
    }
}