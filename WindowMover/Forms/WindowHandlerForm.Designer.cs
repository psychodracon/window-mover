namespace WindowMover.Forms;

partial class WindowHandlerForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowHandlerForm));
        lblWindowTitle = new System.Windows.Forms.Label();
        tbParentWindowClass = new System.Windows.Forms.TextBox();
        tbHandlerName = new System.Windows.Forms.TextBox();
        tbParentWindowTitle = new System.Windows.Forms.TextBox();
        tbPositionX = new System.Windows.Forms.TextBox();
        tbSizeX = new System.Windows.Forms.TextBox();
        tbPositionY = new System.Windows.Forms.TextBox();
        tbSizeY = new System.Windows.Forms.TextBox();
        chkSetPosition = new System.Windows.Forms.CheckBox();
        chkSetSize = new System.Windows.Forms.CheckBox();
        btnOk = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        gbHandler = new System.Windows.Forms.GroupBox();
        gbAttributes = new System.Windows.Forms.GroupBox();
        chkProcessName = new System.Windows.Forms.CheckBox();
        gbParent = new System.Windows.Forms.GroupBox();
        chkParentProcessName = new System.Windows.Forms.CheckBox();
        tbParentProcessName = new System.Windows.Forms.TextBox();
        chkParent = new System.Windows.Forms.CheckBox();
        lblParentProcessName = new System.Windows.Forms.Label();
        lblParentWindowTitle = new System.Windows.Forms.Label();
        chkParentWindowClass = new System.Windows.Forms.CheckBox();
        cbParentWindowTitle = new System.Windows.Forms.ComboBox();
        lblParentWindowClass = new System.Windows.Forms.Label();
        chkWindowClass = new System.Windows.Forms.CheckBox();
        lblProcessName = new System.Windows.Forms.Label();
        cbWindowTitle = new System.Windows.Forms.ComboBox();
        tbProcessName = new System.Windows.Forms.TextBox();
        tbWindowClass = new System.Windows.Forms.TextBox();
        tbWindowTitle = new System.Windows.Forms.TextBox();
        lblWindowClass = new System.Windows.Forms.Label();
        gbValues = new System.Windows.Forms.GroupBox();
        chkBorderless = new System.Windows.Forms.CheckBox();
        chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
        lblSizeSpacer = new System.Windows.Forms.Label();
        lblPositionSpacer = new System.Windows.Forms.Label();
        pictureBox = new System.Windows.Forms.PictureBox();
        imageList = new System.Windows.Forms.ImageList(components);
        gbHotkeys = new System.Windows.Forms.GroupBox();
        chkToggleCameraGlobal = new System.Windows.Forms.CheckBox();
        chkToggleSoundGlobal = new System.Windows.Forms.CheckBox();
        chkToggleMuteGlobal = new System.Windows.Forms.CheckBox();
        tbToggleMuteHotkey = new System.Windows.Forms.TextBox();
        chkToggleCamera = new System.Windows.Forms.CheckBox();
        chkToggleSound = new System.Windows.Forms.CheckBox();
        chkToggleMute = new System.Windows.Forms.CheckBox();
        tbToggleCameraHotkey = new System.Windows.Forms.TextBox();
        btnRegisterToggleCamera = new System.Windows.Forms.Button();
        tbToggleSoundHotkey = new System.Windows.Forms.TextBox();
        btnRegisterToggleSound = new System.Windows.Forms.Button();
        btnRegisterToggleMute = new System.Windows.Forms.Button();
        tlpOthers = new System.Windows.Forms.TableLayoutPanel();
        lblToggleCamera = new System.Windows.Forms.Label();
        lblToggleSound = new System.Windows.Forms.Label();
        lblToggleMute = new System.Windows.Forms.Label();
        gbHandler.SuspendLayout();
        gbAttributes.SuspendLayout();
        gbParent.SuspendLayout();
        gbValues.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
        gbHotkeys.SuspendLayout();
        SuspendLayout();
        // 
        // lblWindowTitle
        // 
        lblWindowTitle.AutoSize = true;
        lblWindowTitle.Location = new System.Drawing.Point(7, 25);
        lblWindowTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblWindowTitle.Name = "lblWindowTitle";
        lblWindowTitle.Size = new System.Drawing.Size(84, 15);
        lblWindowTitle.TabIndex = 0;
        lblWindowTitle.Tag = "l10n:labels.windowName";
        lblWindowTitle.Text = "Window name";
        // 
        // tbParentWindowClass
        // 
        tbParentWindowClass.Location = new System.Drawing.Point(127, 72);
        tbParentWindowClass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbParentWindowClass.Name = "tbParentWindowClass";
        tbParentWindowClass.Size = new System.Drawing.Size(308, 23);
        tbParentWindowClass.TabIndex = 1;
        // 
        // tbHandlerName
        // 
        tbHandlerName.Location = new System.Drawing.Point(7, 22);
        tbHandlerName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbHandlerName.Name = "tbHandlerName";
        tbHandlerName.Size = new System.Drawing.Size(549, 23);
        tbHandlerName.TabIndex = 2;
        // 
        // tbParentWindowTitle
        // 
        tbParentWindowTitle.Location = new System.Drawing.Point(127, 42);
        tbParentWindowTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbParentWindowTitle.Name = "tbParentWindowTitle";
        tbParentWindowTitle.Size = new System.Drawing.Size(308, 23);
        tbParentWindowTitle.TabIndex = 3;
        // 
        // tbPositionX
        // 
        tbPositionX.Location = new System.Drawing.Point(127, 22);
        tbPositionX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbPositionX.Name = "tbPositionX";
        tbPositionX.Size = new System.Drawing.Size(116, 23);
        tbPositionX.TabIndex = 4;
        // 
        // tbSizeX
        // 
        tbSizeX.Location = new System.Drawing.Point(127, 52);
        tbSizeX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbSizeX.Name = "tbSizeX";
        tbSizeX.Size = new System.Drawing.Size(116, 23);
        tbSizeX.TabIndex = 5;
        // 
        // tbPositionY
        // 
        tbPositionY.Location = new System.Drawing.Point(270, 22);
        tbPositionY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbPositionY.Name = "tbPositionY";
        tbPositionY.Size = new System.Drawing.Size(116, 23);
        tbPositionY.TabIndex = 6;
        // 
        // tbSizeY
        // 
        tbSizeY.Location = new System.Drawing.Point(270, 52);
        tbSizeY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbSizeY.Name = "tbSizeY";
        tbSizeY.Size = new System.Drawing.Size(116, 23);
        tbSizeY.TabIndex = 7;
        // 
        // chkSetPosition
        // 
        chkSetPosition.AutoSize = true;
        chkSetPosition.Location = new System.Drawing.Point(10, 24);
        chkSetPosition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkSetPosition.Name = "chkSetPosition";
        chkSetPosition.Size = new System.Drawing.Size(113, 19);
        chkSetPosition.TabIndex = 8;
        chkSetPosition.Tag = "l10n:checkboxes.changePosition";
        chkSetPosition.Text = "Change position";
        chkSetPosition.UseVisualStyleBackColor = true;
        // 
        // chkSetSize
        // 
        chkSetSize.AutoSize = true;
        chkSetSize.Location = new System.Drawing.Point(10, 54);
        chkSetSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkSetSize.Name = "chkSetSize";
        chkSetSize.Size = new System.Drawing.Size(89, 19);
        chkSetSize.TabIndex = 9;
        chkSetSize.Tag = "l10n:checkboxes.changeSize";
        chkSetSize.Text = "Change size";
        chkSetSize.UseVisualStyleBackColor = true;
        // 
        // btnOk
        // 
        btnOk.Location = new System.Drawing.Point(584, 14);
        btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnOk.Name = "btnOk";
        btnOk.Size = new System.Drawing.Size(88, 27);
        btnOk.TabIndex = 10;
        btnOk.Tag = "l10n:buttons.ok";
        btnOk.Text = "OK";
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new System.Drawing.Point(584, 47);
        btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(88, 27);
        btnCancel.TabIndex = 11;
        btnCancel.Tag = "l10n:buttons.cancel";
        btnCancel.Text = "Cancel";
        btnCancel.Click += btnCancel_Click;
        // 
        // gbHandler
        // 
        gbHandler.AutoSize = true;
        gbHandler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        gbHandler.Controls.Add(tbHandlerName);
        gbHandler.Location = new System.Drawing.Point(14, 14);
        gbHandler.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbHandler.Name = "gbHandler";
        gbHandler.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbHandler.Size = new System.Drawing.Size(564, 67);
        gbHandler.TabIndex = 12;
        gbHandler.TabStop = false;
        gbHandler.Tag = "l10n:labels.handleName";
        gbHandler.Text = "Handle name";
        // 
        // gbAttributes
        // 
        gbAttributes.Controls.Add(chkProcessName);
        gbAttributes.Controls.Add(gbParent);
        gbAttributes.Controls.Add(chkWindowClass);
        gbAttributes.Controls.Add(lblProcessName);
        gbAttributes.Controls.Add(cbWindowTitle);
        gbAttributes.Controls.Add(tbProcessName);
        gbAttributes.Controls.Add(tbWindowClass);
        gbAttributes.Controls.Add(tbWindowTitle);
        gbAttributes.Controls.Add(lblWindowClass);
        gbAttributes.Controls.Add(lblWindowTitle);
        gbAttributes.Location = new System.Drawing.Point(14, 87);
        gbAttributes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbAttributes.Name = "gbAttributes";
        gbAttributes.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbAttributes.Size = new System.Drawing.Size(564, 281);
        gbAttributes.TabIndex = 13;
        gbAttributes.TabStop = false;
        gbAttributes.Tag = "l10n:labels.searchUsingAttributes";
        gbAttributes.Text = "Search using following attributes";
        // 
        // chkProcessName
        // 
        chkProcessName.AutoSize = true;
        chkProcessName.Location = new System.Drawing.Point(460, 96);
        chkProcessName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkProcessName.Name = "chkProcessName";
        chkProcessName.Size = new System.Drawing.Size(59, 19);
        chkProcessName.TabIndex = 18;
        chkProcessName.Tag = "l10n:checkboxes.check";
        chkProcessName.Text = "Check";
        chkProcessName.UseVisualStyleBackColor = true;
        // 
        // gbParent
        // 
        gbParent.AutoSize = true;
        gbParent.Controls.Add(chkParentProcessName);
        gbParent.Controls.Add(tbParentProcessName);
        gbParent.Controls.Add(chkParent);
        gbParent.Controls.Add(lblParentProcessName);
        gbParent.Controls.Add(lblParentWindowTitle);
        gbParent.Controls.Add(chkParentWindowClass);
        gbParent.Controls.Add(tbParentWindowClass);
        gbParent.Controls.Add(cbParentWindowTitle);
        gbParent.Controls.Add(tbParentWindowTitle);
        gbParent.Controls.Add(lblParentWindowClass);
        gbParent.Location = new System.Drawing.Point(8, 125);
        gbParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbParent.Name = "gbParent";
        gbParent.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbParent.Size = new System.Drawing.Size(546, 147);
        gbParent.TabIndex = 15;
        gbParent.TabStop = false;
        gbParent.Tag = "l10n:labels.parent";
        gbParent.Text = "Parent";
        // 
        // chkParentProcessName
        // 
        chkParentProcessName.AutoSize = true;
        chkParentProcessName.Location = new System.Drawing.Point(443, 104);
        chkParentProcessName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkParentProcessName.Name = "chkParentProcessName";
        chkParentProcessName.Size = new System.Drawing.Size(59, 19);
        chkParentProcessName.TabIndex = 20;
        chkParentProcessName.Tag = "l10n:checkboxes.check";
        chkParentProcessName.Text = "Check";
        chkParentProcessName.UseVisualStyleBackColor = true;
        // 
        // tbParentProcessName
        // 
        tbParentProcessName.Location = new System.Drawing.Point(127, 102);
        tbParentProcessName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbParentProcessName.Name = "tbParentProcessName";
        tbParentProcessName.Size = new System.Drawing.Size(308, 23);
        tbParentProcessName.TabIndex = 19;
        // 
        // chkParent
        // 
        chkParent.AutoSize = true;
        chkParent.Location = new System.Drawing.Point(7, 22);
        chkParent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkParent.Name = "chkParent";
        chkParent.Size = new System.Drawing.Size(96, 19);
        chkParent.TabIndex = 10;
        chkParent.Tag = "l10n:checkboxes.checkParent";
        chkParent.Text = "Check parent";
        chkParent.UseVisualStyleBackColor = true;
        // 
        // lblParentProcessName
        // 
        lblParentProcessName.AutoSize = true;
        lblParentProcessName.Location = new System.Drawing.Point(7, 105);
        lblParentProcessName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblParentProcessName.Name = "lblParentProcessName";
        lblParentProcessName.Size = new System.Drawing.Size(80, 15);
        lblParentProcessName.TabIndex = 18;
        lblParentProcessName.Tag = "l10n:labels.processName";
        lblParentProcessName.Text = "Process name";
        // 
        // lblParentWindowTitle
        // 
        lblParentWindowTitle.AutoSize = true;
        lblParentWindowTitle.Location = new System.Drawing.Point(7, 45);
        lblParentWindowTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblParentWindowTitle.Name = "lblParentWindowTitle";
        lblParentWindowTitle.Size = new System.Drawing.Size(84, 15);
        lblParentWindowTitle.TabIndex = 2;
        lblParentWindowTitle.Tag = "l10n:labels.windowName";
        lblParentWindowTitle.Text = "Window name";
        // 
        // chkParentWindowClass
        // 
        chkParentWindowClass.AutoSize = true;
        chkParentWindowClass.Location = new System.Drawing.Point(443, 74);
        chkParentWindowClass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkParentWindowClass.Name = "chkParentWindowClass";
        chkParentWindowClass.Size = new System.Drawing.Size(59, 19);
        chkParentWindowClass.TabIndex = 9;
        chkParentWindowClass.Tag = "l10n:checkboxes.check";
        chkParentWindowClass.Text = "Check";
        chkParentWindowClass.UseVisualStyleBackColor = true;
        // 
        // cbParentWindowTitle
        // 
        cbParentWindowTitle.FormattingEnabled = true;
        cbParentWindowTitle.ItemHeight = 15;
        cbParentWindowTitle.Location = new System.Drawing.Point(443, 42);
        cbParentWindowTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        cbParentWindowTitle.Name = "cbParentWindowTitle";
        cbParentWindowTitle.Size = new System.Drawing.Size(95, 23);
        cbParentWindowTitle.TabIndex = 8;
        // 
        // lblParentWindowClass
        // 
        lblParentWindowClass.AutoSize = true;
        lblParentWindowClass.Location = new System.Drawing.Point(7, 75);
        lblParentWindowClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblParentWindowClass.Name = "lblParentWindowClass";
        lblParentWindowClass.Size = new System.Drawing.Size(79, 15);
        lblParentWindowClass.TabIndex = 3;
        lblParentWindowClass.Tag = "l10n:labels.windowClass";
        lblParentWindowClass.Text = "Window class";
        // 
        // chkWindowClass
        // 
        chkWindowClass.AutoSize = true;
        chkWindowClass.Location = new System.Drawing.Point(460, 59);
        chkWindowClass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkWindowClass.Name = "chkWindowClass";
        chkWindowClass.Size = new System.Drawing.Size(59, 19);
        chkWindowClass.TabIndex = 7;
        chkWindowClass.Tag = "l10n:checkboxes.check";
        chkWindowClass.Text = "Check";
        chkWindowClass.UseVisualStyleBackColor = true;
        // 
        // lblProcessName
        // 
        lblProcessName.AutoSize = true;
        lblProcessName.Location = new System.Drawing.Point(7, 97);
        lblProcessName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblProcessName.Name = "lblProcessName";
        lblProcessName.Size = new System.Drawing.Size(80, 15);
        lblProcessName.TabIndex = 17;
        lblProcessName.Tag = "l10n:labels.processName";
        lblProcessName.Text = "Process name";
        // 
        // cbWindowTitle
        // 
        cbWindowTitle.FormattingEnabled = true;
        cbWindowTitle.ItemHeight = 15;
        cbWindowTitle.Location = new System.Drawing.Point(460, 22);
        cbWindowTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        cbWindowTitle.Name = "cbWindowTitle";
        cbWindowTitle.Size = new System.Drawing.Size(96, 23);
        cbWindowTitle.TabIndex = 6;
        // 
        // tbProcessName
        // 
        tbProcessName.Location = new System.Drawing.Point(127, 93);
        tbProcessName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbProcessName.Name = "tbProcessName";
        tbProcessName.Size = new System.Drawing.Size(325, 23);
        tbProcessName.TabIndex = 16;
        // 
        // tbWindowClass
        // 
        tbWindowClass.Location = new System.Drawing.Point(127, 58);
        tbWindowClass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbWindowClass.Name = "tbWindowClass";
        tbWindowClass.Size = new System.Drawing.Size(325, 23);
        tbWindowClass.TabIndex = 5;
        // 
        // tbWindowTitle
        // 
        tbWindowTitle.Location = new System.Drawing.Point(127, 22);
        tbWindowTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbWindowTitle.Name = "tbWindowTitle";
        tbWindowTitle.Size = new System.Drawing.Size(325, 23);
        tbWindowTitle.TabIndex = 4;
        // 
        // lblWindowClass
        // 
        lblWindowClass.AutoSize = true;
        lblWindowClass.Location = new System.Drawing.Point(7, 60);
        lblWindowClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblWindowClass.Name = "lblWindowClass";
        lblWindowClass.Size = new System.Drawing.Size(79, 15);
        lblWindowClass.TabIndex = 1;
        lblWindowClass.Tag = "l10n:labels.windowClass";
        lblWindowClass.Text = "Window class";
        // 
        // gbValues
        // 
        gbValues.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        gbValues.Controls.Add(chkBorderless);
        gbValues.Controls.Add(chkAlwaysOnTop);
        gbValues.Controls.Add(lblSizeSpacer);
        gbValues.Controls.Add(lblPositionSpacer);
        gbValues.Controls.Add(tbPositionX);
        gbValues.Controls.Add(tbSizeX);
        gbValues.Controls.Add(tbPositionY);
        gbValues.Controls.Add(tbSizeY);
        gbValues.Controls.Add(chkSetPosition);
        gbValues.Controls.Add(chkSetSize);
        gbValues.Location = new System.Drawing.Point(14, 374);
        gbValues.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbValues.Name = "gbValues";
        gbValues.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbValues.Size = new System.Drawing.Size(564, 89);
        gbValues.TabIndex = 14;
        gbValues.TabStop = false;
        gbValues.Tag = "l10n:labels.modifyWindowParams";
        gbValues.Text = "Modify window parameters";
        // 
        // chkBorderless
        // 
        chkBorderless.AutoSize = true;
        chkBorderless.Location = new System.Drawing.Point(393, 55);
        chkBorderless.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkBorderless.Name = "chkBorderless";
        chkBorderless.Size = new System.Drawing.Size(112, 19);
        chkBorderless.TabIndex = 13;
        chkBorderless.Tag = "l10n.checkboxes.removeBorders";
        chkBorderless.Text = "Remove borders";
        chkBorderless.UseVisualStyleBackColor = true;
        chkBorderless.Visible = false;
        // 
        // chkAlwaysOnTop
        // 
        chkAlwaysOnTop.AutoSize = true;
        chkAlwaysOnTop.Location = new System.Drawing.Point(393, 25);
        chkAlwaysOnTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkAlwaysOnTop.Name = "chkAlwaysOnTop";
        chkAlwaysOnTop.Size = new System.Drawing.Size(101, 19);
        chkAlwaysOnTop.TabIndex = 12;
        chkAlwaysOnTop.Tag = "l10n:checkboxes.alwaysOnTop";
        chkAlwaysOnTop.Text = "Always on top";
        chkAlwaysOnTop.UseVisualStyleBackColor = true;
        // 
        // lblSizeSpacer
        // 
        lblSizeSpacer.AutoSize = true;
        lblSizeSpacer.Location = new System.Drawing.Point(248, 55);
        lblSizeSpacer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblSizeSpacer.Name = "lblSizeSpacer";
        lblSizeSpacer.Size = new System.Drawing.Size(13, 15);
        lblSizeSpacer.TabIndex = 11;
        lblSizeSpacer.Text = "x";
        // 
        // lblPositionSpacer
        // 
        lblPositionSpacer.AutoSize = true;
        lblPositionSpacer.Location = new System.Drawing.Point(251, 25);
        lblPositionSpacer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblPositionSpacer.Name = "lblPositionSpacer";
        lblPositionSpacer.Size = new System.Drawing.Size(10, 15);
        lblPositionSpacer.TabIndex = 10;
        lblPositionSpacer.Text = ",";
        // 
        // pictureBox
        // 
        pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
        pictureBox.Image = Properties.Resources.Target;
        pictureBox.Location = new System.Drawing.Point(608, 81);
        pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        pictureBox.Name = "pictureBox";
        pictureBox.Size = new System.Drawing.Size(37, 37);
        pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        pictureBox.TabIndex = 16;
        pictureBox.TabStop = false;
        pictureBox.MouseDown += pictureBox_MouseDown;
        pictureBox.MouseMove += pictureBox_MouseMove;
        // 
        // imageList
        // 
        imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
        imageList.ImageSize = new System.Drawing.Size(16, 16);
        imageList.TransparentColor = System.Drawing.Color.Transparent;
        // 
        // gbHotkeys
        // 
        gbHotkeys.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        gbHotkeys.Controls.Add(chkToggleCameraGlobal);
        gbHotkeys.Controls.Add(chkToggleSoundGlobal);
        gbHotkeys.Controls.Add(chkToggleMuteGlobal);
        gbHotkeys.Controls.Add(tbToggleMuteHotkey);
        gbHotkeys.Controls.Add(chkToggleCamera);
        gbHotkeys.Controls.Add(chkToggleSound);
        gbHotkeys.Controls.Add(chkToggleMute);
        gbHotkeys.Controls.Add(tbToggleCameraHotkey);
        gbHotkeys.Controls.Add(btnRegisterToggleCamera);
        gbHotkeys.Controls.Add(tbToggleSoundHotkey);
        gbHotkeys.Controls.Add(btnRegisterToggleSound);
        gbHotkeys.Controls.Add(btnRegisterToggleMute);
        gbHotkeys.Location = new System.Drawing.Point(14, 469);
        gbHotkeys.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbHotkeys.Name = "gbHotkeys";
        gbHotkeys.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gbHotkeys.Size = new System.Drawing.Size(564, 117);
        gbHotkeys.TabIndex = 17;
        gbHotkeys.TabStop = false;
        gbHotkeys.Tag = "l10n:labels.hotkeySettings";
        gbHotkeys.Text = "Hotkey settings";
        // 
        // chkToggleCameraGlobal
        // 
        chkToggleCameraGlobal.AutoSize = true;
        chkToggleCameraGlobal.Location = new System.Drawing.Point(363, 80);
        chkToggleCameraGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkToggleCameraGlobal.Name = "chkToggleCameraGlobal";
        chkToggleCameraGlobal.Size = new System.Drawing.Size(99, 19);
        chkToggleCameraGlobal.TabIndex = 15;
        chkToggleCameraGlobal.Tag = "l10n:checkboxes.globalHotkey";
        chkToggleCameraGlobal.Text = "Global hotkey";
        chkToggleCameraGlobal.UseVisualStyleBackColor = true;
        // 
        // chkToggleSoundGlobal
        // 
        chkToggleSoundGlobal.AutoSize = true;
        chkToggleSoundGlobal.Location = new System.Drawing.Point(363, 51);
        chkToggleSoundGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkToggleSoundGlobal.Name = "chkToggleSoundGlobal";
        chkToggleSoundGlobal.Size = new System.Drawing.Size(99, 19);
        chkToggleSoundGlobal.TabIndex = 14;
        chkToggleSoundGlobal.Tag = "l10n:checkboxes.globalHotkey";
        chkToggleSoundGlobal.Text = "Global hotkey";
        chkToggleSoundGlobal.UseVisualStyleBackColor = true;
        // 
        // chkToggleMuteGlobal
        // 
        chkToggleMuteGlobal.AutoSize = true;
        chkToggleMuteGlobal.Location = new System.Drawing.Point(363, 22);
        chkToggleMuteGlobal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkToggleMuteGlobal.Name = "chkToggleMuteGlobal";
        chkToggleMuteGlobal.Size = new System.Drawing.Size(99, 19);
        chkToggleMuteGlobal.TabIndex = 13;
        chkToggleMuteGlobal.Tag = "l10n:checkboxes.globalHotkey";
        chkToggleMuteGlobal.Text = "Global hotkey";
        chkToggleMuteGlobal.UseVisualStyleBackColor = true;
        // 
        // tbToggleMuteHotkey
        // 
        tbToggleMuteHotkey.BackColor = System.Drawing.SystemColors.Control;
        tbToggleMuteHotkey.Location = new System.Drawing.Point(136, 20);
        tbToggleMuteHotkey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbToggleMuteHotkey.Name = "tbToggleMuteHotkey";
        tbToggleMuteHotkey.ReadOnly = true;
        tbToggleMuteHotkey.Size = new System.Drawing.Size(116, 23);
        tbToggleMuteHotkey.TabIndex = 2;
        // 
        // chkToggleCamera
        // 
        chkToggleCamera.AutoSize = true;
        chkToggleCamera.Location = new System.Drawing.Point(11, 80);
        chkToggleCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkToggleCamera.Name = "chkToggleCamera";
        chkToggleCamera.Size = new System.Drawing.Size(103, 19);
        chkToggleCamera.TabIndex = 12;
        chkToggleCamera.Tag = "l10n:labels.toggleCamera";
        chkToggleCamera.Text = "Toggle camera";
        chkToggleCamera.UseVisualStyleBackColor = true;
        // 
        // chkToggleSound
        // 
        chkToggleSound.AutoSize = true;
        chkToggleSound.Location = new System.Drawing.Point(11, 51);
        chkToggleSound.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkToggleSound.Name = "chkToggleSound";
        chkToggleSound.Size = new System.Drawing.Size(97, 19);
        chkToggleSound.TabIndex = 11;
        chkToggleSound.Tag = "l10n:labels.toggleSound";
        chkToggleSound.Text = "Toggle sound";
        chkToggleSound.UseVisualStyleBackColor = true;
        // 
        // chkToggleMute
        // 
        chkToggleMute.AutoSize = true;
        chkToggleMute.Location = new System.Drawing.Point(11, 22);
        chkToggleMute.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        chkToggleMute.Name = "chkToggleMute";
        chkToggleMute.Size = new System.Drawing.Size(92, 19);
        chkToggleMute.TabIndex = 10;
        chkToggleMute.Tag = "l10n:labels.toggleMute";
        chkToggleMute.Text = "Toggle mute";
        chkToggleMute.UseVisualStyleBackColor = true;
        // 
        // tbToggleCameraHotkey
        // 
        tbToggleCameraHotkey.BackColor = System.Drawing.SystemColors.Control;
        tbToggleCameraHotkey.Location = new System.Drawing.Point(136, 78);
        tbToggleCameraHotkey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbToggleCameraHotkey.Name = "tbToggleCameraHotkey";
        tbToggleCameraHotkey.ReadOnly = true;
        tbToggleCameraHotkey.Size = new System.Drawing.Size(116, 23);
        tbToggleCameraHotkey.TabIndex = 8;
        // 
        // btnRegisterToggleCamera
        // 
        btnRegisterToggleCamera.Location = new System.Drawing.Point(260, 76);
        btnRegisterToggleCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnRegisterToggleCamera.Name = "btnRegisterToggleCamera";
        btnRegisterToggleCamera.Size = new System.Drawing.Size(95, 27);
        btnRegisterToggleCamera.TabIndex = 7;
        btnRegisterToggleCamera.Tag = "l10n:buttons.record";
        btnRegisterToggleCamera.Text = "Register";
        btnRegisterToggleCamera.UseVisualStyleBackColor = true;
        btnRegisterToggleCamera.Click += btnRegisterToggleCamera_Click;
        btnRegisterToggleCamera.KeyDown += btnRegisterToggleCamera_KeyDown;
        // 
        // tbToggleSoundHotkey
        // 
        tbToggleSoundHotkey.BackColor = System.Drawing.SystemColors.Control;
        tbToggleSoundHotkey.Location = new System.Drawing.Point(136, 49);
        tbToggleSoundHotkey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tbToggleSoundHotkey.Name = "tbToggleSoundHotkey";
        tbToggleSoundHotkey.ReadOnly = true;
        tbToggleSoundHotkey.Size = new System.Drawing.Size(116, 23);
        tbToggleSoundHotkey.TabIndex = 5;
        // 
        // btnRegisterToggleSound
        // 
        btnRegisterToggleSound.Location = new System.Drawing.Point(260, 47);
        btnRegisterToggleSound.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnRegisterToggleSound.Name = "btnRegisterToggleSound";
        btnRegisterToggleSound.Size = new System.Drawing.Size(95, 27);
        btnRegisterToggleSound.TabIndex = 4;
        btnRegisterToggleSound.Tag = "l10n:buttons.record";
        btnRegisterToggleSound.Text = "Register";
        btnRegisterToggleSound.UseVisualStyleBackColor = true;
        btnRegisterToggleSound.Click += btnRegisterToggleSound_Click;
        btnRegisterToggleSound.KeyDown += btnRegisterToggleSound_KeyDown;
        // 
        // btnRegisterToggleMute
        // 
        btnRegisterToggleMute.Location = new System.Drawing.Point(260, 18);
        btnRegisterToggleMute.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnRegisterToggleMute.Name = "btnRegisterToggleMute";
        btnRegisterToggleMute.Size = new System.Drawing.Size(95, 27);
        btnRegisterToggleMute.TabIndex = 3;
        btnRegisterToggleMute.Tag = "l10n:buttons.record";
        btnRegisterToggleMute.Text = "Register";
        btnRegisterToggleMute.UseVisualStyleBackColor = true;
        btnRegisterToggleMute.Click += btnRegisterToggleMute_Click;
        btnRegisterToggleMute.KeyDown += btnRegisterToggleMute_KeyDown;
        // 
        // tlpOthers
        // 
        tlpOthers.AutoSize = true;
        tlpOthers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tlpOthers.ColumnCount = 1;
        tlpOthers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tlpOthers.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpOthers.Location = new System.Drawing.Point(0, 0);
        tlpOthers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tlpOthers.Name = "tlpOthers";
        tlpOthers.Padding = new System.Windows.Forms.Padding(0, 0, 107, 0);
        tlpOthers.RowCount = 4;
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tlpOthers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tlpOthers.Size = new System.Drawing.Size(200, 100);
        tlpOthers.TabIndex = 0;
        // 
        // lblToggleCamera
        // 
        lblToggleCamera.AutoSize = true;
        lblToggleCamera.Location = new System.Drawing.Point(8, 82);
        lblToggleCamera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblToggleCamera.Name = "lblToggleCamera";
        lblToggleCamera.Size = new System.Drawing.Size(91, 15);
        lblToggleCamera.TabIndex = 9;
        lblToggleCamera.Text = "Toggle camera";
        // 
        // lblToggleSound
        // 
        lblToggleSound.AutoSize = true;
        lblToggleSound.Location = new System.Drawing.Point(8, 53);
        lblToggleSound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblToggleSound.Name = "lblToggleSound";
        lblToggleSound.Size = new System.Drawing.Size(88, 15);
        lblToggleSound.TabIndex = 6;
        lblToggleSound.Text = "Toggle sound";
        // 
        // lblToggleMute
        // 
        lblToggleMute.AutoSize = true;
        lblToggleMute.Location = new System.Drawing.Point(8, 24);
        lblToggleMute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblToggleMute.Name = "lblToggleMute";
        lblToggleMute.Size = new System.Drawing.Size(101, 15);
        lblToggleMute.TabIndex = 1;
        lblToggleMute.Text = "Toggle mute";
        // 
        // WindowHandlerForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(685, 598);
        Controls.Add(gbHotkeys);
        Controls.Add(pictureBox);
        Controls.Add(gbValues);
        Controls.Add(gbAttributes);
        Controls.Add(gbHandler);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        MinimumSize = new System.Drawing.Size(701, 615);
        Name = "WindowHandlerForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Add new handle";
        gbHandler.ResumeLayout(false);
        gbHandler.PerformLayout();
        gbAttributes.ResumeLayout(false);
        gbAttributes.PerformLayout();
        gbParent.ResumeLayout(false);
        gbParent.PerformLayout();
        gbValues.ResumeLayout(false);
        gbValues.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
        gbHotkeys.ResumeLayout(false);
        gbHotkeys.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblWindowTitle;
    private System.Windows.Forms.TextBox tbParentWindowClass;
    private System.Windows.Forms.TextBox tbHandlerName;
    private System.Windows.Forms.TextBox tbParentWindowTitle;
    private System.Windows.Forms.TextBox tbPositionX;
    private System.Windows.Forms.TextBox tbSizeX;
    private System.Windows.Forms.TextBox tbPositionY;
    private System.Windows.Forms.TextBox tbSizeY;
    private System.Windows.Forms.CheckBox chkSetPosition;
    private System.Windows.Forms.CheckBox chkSetSize;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.GroupBox gbHandler;
    private System.Windows.Forms.GroupBox gbAttributes;
    private System.Windows.Forms.GroupBox gbParent;
    private System.Windows.Forms.CheckBox chkParent;
    private System.Windows.Forms.Label lblParentWindowTitle;
    private System.Windows.Forms.CheckBox chkParentWindowClass;
    private System.Windows.Forms.ComboBox cbParentWindowTitle;
    private System.Windows.Forms.Label lblParentWindowClass;
    private System.Windows.Forms.CheckBox chkWindowClass;
    private System.Windows.Forms.ComboBox cbWindowTitle;
    private System.Windows.Forms.TextBox tbWindowClass;
    private System.Windows.Forms.TextBox tbWindowTitle;
    private System.Windows.Forms.Label lblWindowClass;
    private System.Windows.Forms.GroupBox gbValues;
    private System.Windows.Forms.Label lblSizeSpacer;
    private System.Windows.Forms.Label lblPositionSpacer;
    private System.Windows.Forms.CheckBox chkProcessName;
    private System.Windows.Forms.CheckBox chkParentProcessName;
    private System.Windows.Forms.TextBox tbParentProcessName;
    private System.Windows.Forms.Label lblParentProcessName;
    private System.Windows.Forms.Label lblProcessName;
    private System.Windows.Forms.TextBox tbProcessName;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.CheckBox chkBorderless;
    private System.Windows.Forms.CheckBox chkAlwaysOnTop;
    private System.Windows.Forms.GroupBox gbHotkeys;
    private System.Windows.Forms.CheckBox chkToggleCamera;
    private System.Windows.Forms.CheckBox chkToggleSound;
    private System.Windows.Forms.CheckBox chkToggleMute;
    private System.Windows.Forms.TextBox tbToggleCameraHotkey;
    private System.Windows.Forms.Button btnRegisterToggleCamera;
    private System.Windows.Forms.TextBox tbToggleSoundHotkey;
    private System.Windows.Forms.Button btnRegisterToggleSound;
    private System.Windows.Forms.Button btnRegisterToggleMute;
    private System.Windows.Forms.TextBox tbToggleMuteHotkey;
    private System.Windows.Forms.CheckBox chkToggleCameraGlobal;
    private System.Windows.Forms.CheckBox chkToggleSoundGlobal;
    private System.Windows.Forms.CheckBox chkToggleMuteGlobal;
    private System.Windows.Forms.TableLayoutPanel tlpOthers;
    private System.Windows.Forms.Label lblToggleCamera;
    private System.Windows.Forms.Label lblToggleSound;
    private System.Windows.Forms.Label lblToggleMute;
}
