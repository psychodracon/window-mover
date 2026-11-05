namespace WindowMover.Forms;

partial class SettingsForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
        timer1 = new System.Windows.Forms.Timer(components);
        tlpHandlerList = new System.Windows.Forms.TableLayoutPanel();
        tlpList = new System.Windows.Forms.TableLayoutPanel();
        dgVHandlers = new System.Windows.Forms.DataGridView();
        clActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        tlpButtons = new System.Windows.Forms.TableLayoutPanel();
        btnAdd = new System.Windows.Forms.Button();
        btnEdit = new System.Windows.Forms.Button();
        btnRemove = new System.Windows.Forms.Button();
        btnSetPosition = new System.Windows.Forms.Button();
        settingsTabControl = new System.Windows.Forms.TabControl();
        tpHandlers = new System.Windows.Forms.TabPage();
        tpOthers = new System.Windows.Forms.TabPage();
        tlpOthersButtons = new System.Windows.Forms.TableLayoutPanel();
        btnSaveSettings = new System.Windows.Forms.Button();
        tlpOthers = new System.Windows.Forms.TableLayoutPanel();
        gbHotkeys = new System.Windows.Forms.GroupBox();
        lblToggleCamera = new System.Windows.Forms.Label();
        tbToggleCameraHotkey = new System.Windows.Forms.TextBox();
        btnRegisterToggleCamera = new System.Windows.Forms.Button();
        lblToggleSound = new System.Windows.Forms.Label();
        tbToggleSoundHotkey = new System.Windows.Forms.TextBox();
        btnRegisterToggleSound = new System.Windows.Forms.Button();
        btnRegisterToggleMute = new System.Windows.Forms.Button();
        tbToggleMuteHotkey = new System.Windows.Forms.TextBox();
        lblToggleMute = new System.Windows.Forms.Label();
        gbTimers = new System.Windows.Forms.GroupBox();
        lblSetPositionsMs = new System.Windows.Forms.Label();
        nudSetPositions = new System.Windows.Forms.NumericUpDown();
        lblSetPositions = new System.Windows.Forms.Label();
        gbOthers = new System.Windows.Forms.GroupBox();
        cbLanguages = new System.Windows.Forms.ComboBox();
        lblLanguage = new System.Windows.Forms.Label();
        chkSupportMSTeams = new System.Windows.Forms.CheckBox();
        tlpHandlerList.SuspendLayout();
        tlpList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgVHandlers).BeginInit();
        tlpButtons.SuspendLayout();
        settingsTabControl.SuspendLayout();
        tpHandlers.SuspendLayout();
        tpOthers.SuspendLayout();
        tlpOthersButtons.SuspendLayout();
        tlpOthers.SuspendLayout();
        gbHotkeys.SuspendLayout();
        gbTimers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSetPositions).BeginInit();
        gbOthers.SuspendLayout();
        SuspendLayout();
        // 
        // tlpHandlerList
        // 
        tlpHandlerList.BackColor = System.Drawing.Color.Transparent;
        tlpHandlerList.ColumnCount = 1;
        tlpHandlerList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tlpHandlerList.Controls.Add(tlpList, 0, 1);
        tlpHandlerList.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpHandlerList.Location = new System.Drawing.Point(4, 3);
        tlpHandlerList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tlpHandlerList.Name = "tlpHandlerList";
        tlpHandlerList.Padding = new System.Windows.Forms.Padding(0, 0, 103, 0);
        tlpHandlerList.RowCount = 2;
        tlpHandlerList.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpHandlerList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
        tlpHandlerList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
        tlpHandlerList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
        tlpHandlerList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
        tlpHandlerList.Size = new System.Drawing.Size(731, 462);
        tlpHandlerList.TabIndex = 8;
        // 
        // tlpList
        // 
        tlpList.ColumnCount = 1;
        tlpList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tlpList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
        tlpList.Controls.Add(dgVHandlers, 0, 0);
        tlpList.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpList.Location = new System.Drawing.Point(4, 3);
        tlpList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tlpList.Name = "tlpList";
        tlpList.RowCount = 1;
        tlpList.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 452F));
        tlpList.Size = new System.Drawing.Size(621, 456);
        tlpList.TabIndex = 7;
        // 
        // dgVHandlers
        // 
        dgVHandlers.BackgroundColor = System.Drawing.SystemColors.Window;
        dgVHandlers.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dgVHandlers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
        dgVHandlers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgVHandlers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { clActive, clName });
        dgVHandlers.Dock = System.Windows.Forms.DockStyle.Fill;
        dgVHandlers.GridColor = System.Drawing.SystemColors.Window;
        dgVHandlers.Location = new System.Drawing.Point(4, 3);
        dgVHandlers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        dgVHandlers.Name = "dgVHandlers";
        dgVHandlers.Size = new System.Drawing.Size(614, 450);
        dgVHandlers.TabIndex = 2;
        dgVHandlers.CellValueChanged += dgVHandlers_CellValueChanged;
        dgVHandlers.CurrentCellDirtyStateChanged += dgVHandlers_CurrentCellDirtyStateChanged;
        // 
        // clActive
        // 
        clActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        clActive.FillWeight = 31.47208F;
        clActive.HeaderText = "Active";
        clActive.Name = "clActive";
        clActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        // 
        // clName
        // 
        clName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        clName.FillWeight = 168.5279F;
        clName.HeaderText = "Name";
        clName.Name = "clName";
        // 
        // tlpButtons
        // 
        tlpButtons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        tlpButtons.AutoSize = true;
        tlpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tlpButtons.ColumnCount = 1;
        tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tlpButtons.Controls.Add(btnAdd, 0, 0);
        tlpButtons.Controls.Add(btnEdit, 0, 1);
        tlpButtons.Controls.Add(btnRemove, 0, 2);
        tlpButtons.Controls.Add(btnSetPosition, 0, 5);
        tlpButtons.Location = new System.Drawing.Point(632, 7);
        tlpButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tlpButtons.Name = "tlpButtons";
        tlpButtons.RowCount = 6;
        tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
        tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpButtons.Size = new System.Drawing.Size(96, 161);
        tlpButtons.TabIndex = 6;
        // 
        // btnAdd
        // 
        btnAdd.Location = new System.Drawing.Point(4, 3);
        btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(88, 27);
        btnAdd.TabIndex = 1;
        btnAdd.Tag = "l10n:buttons.add";
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;
        // 
        // btnEdit
        // 
        btnEdit.Location = new System.Drawing.Point(4, 36);
        btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new System.Drawing.Size(88, 27);
        btnEdit.TabIndex = 3;
        btnEdit.Tag = "l10n:buttons.edit";
        btnEdit.Text = "Edit";
        btnEdit.Click += btnEdit_Click;
        // 
        // btnRemove
        // 
        btnRemove.Location = new System.Drawing.Point(4, 69);
        btnRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new System.Drawing.Size(88, 27);
        btnRemove.TabIndex = 4;
        btnRemove.Tag = "l10n:buttons.delete";
        btnRemove.Text = "Remove";
        btnRemove.Click += btnRemove_Click;
        // 
        // btnSetPosition
        // 
        btnSetPosition.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnSetPosition.Location = new System.Drawing.Point(4, 131);
        btnSetPosition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnSetPosition.Name = "btnSetPosition";
        btnSetPosition.Size = new System.Drawing.Size(88, 27);
        btnSetPosition.TabIndex = 5;
        btnSetPosition.Tag = "l10n:buttons.setPositions";
        btnSetPosition.Text = "Set positions";
        btnSetPosition.Click += btnSetPosition_Click;
        // 
        // settingsTabControl
        // 
        settingsTabControl.Controls.Add(tpHandlers);
        settingsTabControl.Controls.Add(tpOthers);
        settingsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
        settingsTabControl.Location = new System.Drawing.Point(0, 0);
        settingsTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        settingsTabControl.Name = "settingsTabControl";
        settingsTabControl.SelectedIndex = 0;
        settingsTabControl.Size = new System.Drawing.Size(747, 496);
        settingsTabControl.TabIndex = 9;
        settingsTabControl.Tag = "";
        // 
        // tpHandlers
        // 
        tpHandlers.Controls.Add(tlpButtons);
        tpHandlers.Controls.Add(tlpHandlerList);
        tpHandlers.Location = new System.Drawing.Point(4, 24);
        tpHandlers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tpHandlers.Name = "tpHandlers";
        tpHandlers.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tpHandlers.Size = new System.Drawing.Size(739, 468);
        tpHandlers.TabIndex = 0;
        tpHandlers.Tag = "l10n:pages.handleList";
        tpHandlers.Text = "Handle list";
        // 
        // tpOthers
        // 
        tpOthers.Controls.Add(tlpOthersButtons);
        tpOthers.Controls.Add(tlpOthers);
        tpOthers.Location = new System.Drawing.Point(4, 24);
        tpOthers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tpOthers.Name = "tpOthers";
        tpOthers.Size = new System.Drawing.Size(739, 468);
        tpOthers.TabIndex = 1;
        tpOthers.Tag = "l10n:pages.others";
        tpOthers.Text = "Others";
        // 
        // tlpOthersButtons
        // 
        tlpOthersButtons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        tlpOthersButtons.AutoSize = true;
        tlpOthersButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tlpOthersButtons.ColumnCount = 1;
        tlpOthersButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tlpOthersButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
        tlpOthersButtons.Controls.Add(btnSaveSettings, 0, 0);
        tlpOthersButtons.Location = new System.Drawing.Point(632, 7);
        tlpOthersButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tlpOthersButtons.Name = "tlpOthersButtons";
        tlpOthersButtons.RowCount = 1;
        tlpOthersButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpOthersButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
        tlpOthersButtons.Size = new System.Drawing.Size(96, 33);
        tlpOthersButtons.TabIndex = 3;
        // 
        // btnSaveSettings
        // 
        btnSaveSettings.Anchor = System.Windows.Forms.AnchorStyles.Right;
        btnSaveSettings.Location = new System.Drawing.Point(4, 3);
        btnSaveSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnSaveSettings.Name = "btnSaveSettings";
        btnSaveSettings.Size = new System.Drawing.Size(88, 27);
        btnSaveSettings.TabIndex = 2;
        btnSaveSettings.Tag = "l10n:buttons.save";
        btnSaveSettings.Text = "Apply";
        btnSaveSettings.UseVisualStyleBackColor = true;
        btnSaveSettings.Click += btnSaveSettings_Click;
        // 
        // tlpOthers
        // 
        tlpOthers.AutoSize = true;
        tlpOthers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tlpOthers.ColumnCount = 1;
        tlpOthers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tlpOthers.Controls.Add(gbHotkeys, 0, 3);
        tlpOthers.Controls.Add(gbTimers, 0, 0);
        tlpOthers.Controls.Add(gbOthers, 0, 4);
        tlpOthers.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpOthers.Location = new System.Drawing.Point(0, 0);
        tlpOthers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tlpOthers.Name = "tlpOthers";
        tlpOthers.Padding = new System.Windows.Forms.Padding(0, 0, 107, 0);
        tlpOthers.RowCount = 5;
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tlpOthers.Size = new System.Drawing.Size(739, 468);
        tlpOthers.TabIndex = 0;
        // 
        // gbHotkeys
        // 
        gbHotkeys.AutoSize = true;
        gbHotkeys.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        gbHotkeys.Controls.Add(lblToggleCamera);
        gbHotkeys.Controls.Add(tbToggleCameraHotkey);
        gbHotkeys.Controls.Add(btnRegisterToggleCamera);
        gbHotkeys.Controls.Add(lblToggleSound);
        gbHotkeys.Controls.Add(tbToggleSoundHotkey);
        gbHotkeys.Controls.Add(btnRegisterToggleSound);
        gbHotkeys.Controls.Add(btnRegisterToggleMute);
        gbHotkeys.Controls.Add(tbToggleMuteHotkey);
        gbHotkeys.Controls.Add(lblToggleMute);
        gbHotkeys.Dock = System.Windows.Forms.DockStyle.Fill;
        gbHotkeys.Location = new System.Drawing.Point(4, 66);
        gbHotkeys.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbHotkeys.Name = "gbHotkeys";
        gbHotkeys.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbHotkeys.Size = new System.Drawing.Size(624, 125);
        gbHotkeys.TabIndex = 1;
        gbHotkeys.TabStop = false;
        gbHotkeys.Tag = "l10n:labels.hotkeySettings";
        gbHotkeys.Text = "Hotkey settings";
        // 
        // lblToggleCamera
        // 
        lblToggleCamera.AutoSize = true;
        lblToggleCamera.Location = new System.Drawing.Point(7, 82);
        lblToggleCamera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblToggleCamera.Name = "lblToggleCamera";
        lblToggleCamera.Size = new System.Drawing.Size(84, 15);
        lblToggleCamera.TabIndex = 9;
        lblToggleCamera.Tag = "l10n:labels.toggleCamera";
        lblToggleCamera.Text = "Toggle camera";
        // 
        // tbToggleCameraHotkey
        // 
        tbToggleCameraHotkey.BackColor = System.Drawing.SystemColors.Control;
        tbToggleCameraHotkey.Location = new System.Drawing.Point(316, 78);
        tbToggleCameraHotkey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbToggleCameraHotkey.Name = "tbToggleCameraHotkey";
        tbToggleCameraHotkey.ReadOnly = true;
        tbToggleCameraHotkey.Size = new System.Drawing.Size(139, 23);
        tbToggleCameraHotkey.TabIndex = 8;
        // 
        // btnRegisterToggleCamera
        // 
        btnRegisterToggleCamera.Location = new System.Drawing.Point(467, 76);
        btnRegisterToggleCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnRegisterToggleCamera.Name = "btnRegisterToggleCamera";
        btnRegisterToggleCamera.Size = new System.Drawing.Size(88, 27);
        btnRegisterToggleCamera.TabIndex = 7;
        btnRegisterToggleCamera.Tag = "l10n:buttons.record";
        btnRegisterToggleCamera.Text = "Register";
        btnRegisterToggleCamera.UseVisualStyleBackColor = true;
        btnRegisterToggleCamera.Click += btnRegisterToggleCamera_Click;
        btnRegisterToggleCamera.KeyDown += btnRegisterToggleCamera_KeyDown;
        // 
        // lblToggleSound
        // 
        lblToggleSound.AutoSize = true;
        lblToggleSound.Location = new System.Drawing.Point(7, 53);
        lblToggleSound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblToggleSound.Name = "lblToggleSound";
        lblToggleSound.Size = new System.Drawing.Size(78, 15);
        lblToggleSound.TabIndex = 6;
        lblToggleSound.Tag = "l10n:labels.toggleSound";
        lblToggleSound.Text = "Toggle sound";
        // 
        // tbToggleSoundHotkey
        // 
        tbToggleSoundHotkey.BackColor = System.Drawing.SystemColors.Control;
        tbToggleSoundHotkey.Location = new System.Drawing.Point(317, 49);
        tbToggleSoundHotkey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbToggleSoundHotkey.Name = "tbToggleSoundHotkey";
        tbToggleSoundHotkey.ReadOnly = true;
        tbToggleSoundHotkey.Size = new System.Drawing.Size(139, 23);
        tbToggleSoundHotkey.TabIndex = 5;
        // 
        // btnRegisterToggleSound
        // 
        btnRegisterToggleSound.Location = new System.Drawing.Point(467, 47);
        btnRegisterToggleSound.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnRegisterToggleSound.Name = "btnRegisterToggleSound";
        btnRegisterToggleSound.Size = new System.Drawing.Size(88, 27);
        btnRegisterToggleSound.TabIndex = 4;
        btnRegisterToggleSound.Tag = "l10n:buttons.record";
        btnRegisterToggleSound.Text = "Register";
        btnRegisterToggleSound.UseVisualStyleBackColor = true;
        btnRegisterToggleSound.Click += btnRegisterToggleSound_Click;
        btnRegisterToggleSound.KeyDown += btnRegisterToggleSound_KeyDown;
        // 
        // btnRegisterToggleMute
        // 
        btnRegisterToggleMute.Location = new System.Drawing.Point(467, 18);
        btnRegisterToggleMute.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnRegisterToggleMute.Name = "btnRegisterToggleMute";
        btnRegisterToggleMute.Size = new System.Drawing.Size(88, 27);
        btnRegisterToggleMute.TabIndex = 3;
        btnRegisterToggleMute.Tag = "l10n:buttons.record";
        btnRegisterToggleMute.Text = "Register";
        btnRegisterToggleMute.UseVisualStyleBackColor = true;
        btnRegisterToggleMute.Click += btnRegisterToggleMute_Click;
        btnRegisterToggleMute.KeyDown += btnRegisterToggleMute_KeyDown;
        // 
        // tbToggleMuteHotkey
        // 
        tbToggleMuteHotkey.BackColor = System.Drawing.SystemColors.Control;
        tbToggleMuteHotkey.Location = new System.Drawing.Point(316, 20);
        tbToggleMuteHotkey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbToggleMuteHotkey.Name = "tbToggleMuteHotkey";
        tbToggleMuteHotkey.ReadOnly = true;
        tbToggleMuteHotkey.Size = new System.Drawing.Size(139, 23);
        tbToggleMuteHotkey.TabIndex = 2;
        // 
        // lblToggleMute
        // 
        lblToggleMute.AutoSize = true;
        lblToggleMute.Location = new System.Drawing.Point(7, 24);
        lblToggleMute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblToggleMute.Name = "lblToggleMute";
        lblToggleMute.Size = new System.Drawing.Size(73, 15);
        lblToggleMute.TabIndex = 1;
        lblToggleMute.Tag = "l10n:labels.toggleMute";
        lblToggleMute.Text = "Toggle mute";
        // 
        // gbTimers
        // 
        gbTimers.AutoSize = true;
        gbTimers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        gbTimers.Controls.Add(lblSetPositionsMs);
        gbTimers.Controls.Add(nudSetPositions);
        gbTimers.Controls.Add(lblSetPositions);
        gbTimers.Dock = System.Windows.Forms.DockStyle.Top;
        gbTimers.Location = new System.Drawing.Point(4, 3);
        gbTimers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbTimers.Name = "gbTimers";
        gbTimers.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbTimers.Size = new System.Drawing.Size(624, 57);
        gbTimers.TabIndex = 0;
        gbTimers.TabStop = false;
        gbTimers.Tag = "l10n:labels.timerSettings";
        gbTimers.Text = "Timers settings";
        // 
        // lblSetPositionsMs
        // 
        lblSetPositionsMs.AutoSize = true;
        lblSetPositionsMs.Location = new System.Drawing.Point(463, 22);
        lblSetPositionsMs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblSetPositionsMs.Name = "lblSetPositionsMs";
        lblSetPositionsMs.Size = new System.Drawing.Size(23, 15);
        lblSetPositionsMs.TabIndex = 5;
        lblSetPositionsMs.Tag = "l10n:others.ms";
        lblSetPositionsMs.Text = "ms";
        // 
        // nudSetPositions
        // 
        nudSetPositions.Location = new System.Drawing.Point(316, 20);
        nudSetPositions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        nudSetPositions.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
        nudSetPositions.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
        nudSetPositions.Name = "nudSetPositions";
        nudSetPositions.Size = new System.Drawing.Size(140, 23);
        nudSetPositions.TabIndex = 3;
        nudSetPositions.Value = new decimal(new int[] { 100, 0, 0, 0 });
        // 
        // lblSetPositions
        // 
        lblSetPositions.AutoSize = true;
        lblSetPositions.Location = new System.Drawing.Point(7, 22);
        lblSetPositions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblSetPositions.Name = "lblSetPositions";
        lblSetPositions.Size = new System.Drawing.Size(201, 15);
        lblSetPositions.TabIndex = 1;
        lblSetPositions.Tag = "l10n:labels.windowPositionRecovery";
        lblSetPositions.Text = "Window position recovery frequency";
        // 
        // gbOthers
        // 
        gbOthers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        gbOthers.Controls.Add(cbLanguages);
        gbOthers.Controls.Add(lblLanguage);
        gbOthers.Controls.Add(chkSupportMSTeams);
        gbOthers.Dock = System.Windows.Forms.DockStyle.Fill;
        gbOthers.Location = new System.Drawing.Point(3, 197);
        gbOthers.Name = "gbOthers";
        gbOthers.Size = new System.Drawing.Size(626, 268);
        gbOthers.TabIndex = 2;
        gbOthers.TabStop = false;
        gbOthers.Tag = "l10n:labels.others";
        gbOthers.Text = "Others";
        // 
        // cbLanguages
        // 
        cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbLanguages.FormattingEnabled = true;
        cbLanguages.Location = new System.Drawing.Point(8, 72);
        cbLanguages.Name = "cbLanguages";
        cbLanguages.Size = new System.Drawing.Size(121, 23);
        cbLanguages.TabIndex = 2;
        // 
        // lblLanguage
        // 
        lblLanguage.AutoSize = true;
        lblLanguage.Location = new System.Drawing.Point(8, 54);
        lblLanguage.Name = "lblLanguage";
        lblLanguage.Size = new System.Drawing.Size(59, 15);
        lblLanguage.TabIndex = 1;
        lblLanguage.Tag = "l10n:labels.language";
        lblLanguage.Text = "Language";
        // 
        // chkSupportMSTeams
        // 
        chkSupportMSTeams.AutoSize = true;
        chkSupportMSTeams.Location = new System.Drawing.Point(8, 22);
        chkSupportMSTeams.Name = "chkSupportMSTeams";
        chkSupportMSTeams.Size = new System.Drawing.Size(297, 19);
        chkSupportMSTeams.TabIndex = 0;
        chkSupportMSTeams.Tag = "l10n:checkboxes.msTeamsSupport";
        chkSupportMSTeams.Text = "Enable Microsoft Teams support (New version only)";
        chkSupportMSTeams.UseVisualStyleBackColor = true;
        chkSupportMSTeams.CheckedChanged += chkSupportMSTeams_CheckedChanged;
        // 
        // SettingsForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(747, 496);
        Controls.Add(settingsTabControl);
        Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        MinimumSize = new System.Drawing.Size(763, 535);
        Name = "SettingsForm";
        StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        Tag = "l10n:views.settings";
        Text = "Settings";
        FormClosing += SettingsForm_FormClosing;
        Load += SettingsForm_Load;
        tlpHandlerList.ResumeLayout(false);
        tlpList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgVHandlers).EndInit();
        tlpButtons.ResumeLayout(false);
        settingsTabControl.ResumeLayout(false);
        tpHandlers.ResumeLayout(false);
        tpHandlers.PerformLayout();
        tpOthers.ResumeLayout(false);
        tpOthers.PerformLayout();
        tlpOthersButtons.ResumeLayout(false);
        tlpOthers.ResumeLayout(false);
        tlpOthers.PerformLayout();
        gbHotkeys.ResumeLayout(false);
        gbHotkeys.PerformLayout();
        gbTimers.ResumeLayout(false);
        gbTimers.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSetPositions).EndInit();
        gbOthers.ResumeLayout(false);
        gbOthers.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.TableLayoutPanel tlpHandlerList;
    private System.Windows.Forms.TableLayoutPanel tlpButtons;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnSetPosition;
    private System.Windows.Forms.TabControl settingsTabControl;
    private System.Windows.Forms.TabPage tpHandlers;
    private System.Windows.Forms.TabPage tpOthers;
    private System.Windows.Forms.TableLayoutPanel tlpOthers;
    private System.Windows.Forms.GroupBox gbTimers;
    private System.Windows.Forms.NumericUpDown nudSetPositions;
    private System.Windows.Forms.Label lblSetPositions;
    private System.Windows.Forms.Label lblSetPositionsMs;
    private System.Windows.Forms.Button btnSaveSettings;
    private System.Windows.Forms.TableLayoutPanel tlpList;
    private System.Windows.Forms.DataGridView dgVHandlers;
    private System.Windows.Forms.DataGridViewCheckBoxColumn clActive;
    private System.Windows.Forms.DataGridViewTextBoxColumn clName;
    private System.Windows.Forms.TableLayoutPanel tlpOthersButtons;
    private System.Windows.Forms.GroupBox gbHotkeys;
    private System.Windows.Forms.Button btnRegisterToggleMute;
    private System.Windows.Forms.TextBox tbToggleMuteHotkey;
    private System.Windows.Forms.Label lblToggleMute;
    private System.Windows.Forms.TextBox tbToggleSoundHotkey;
    private System.Windows.Forms.Button btnRegisterToggleSound;
    private System.Windows.Forms.Label lblToggleSound;
    private System.Windows.Forms.Label lblToggleCamera;
    private System.Windows.Forms.TextBox tbToggleCameraHotkey;
    private System.Windows.Forms.Button btnRegisterToggleCamera;
    private System.Windows.Forms.GroupBox gbOthers;
    private System.Windows.Forms.CheckBox chkSupportMSTeams;
    private System.Windows.Forms.ComboBox cbLanguages;
    private System.Windows.Forms.Label lblLanguage;
}
