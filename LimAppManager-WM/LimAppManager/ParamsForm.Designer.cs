namespace LimAppManager
{
    partial class ParamsForm
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
            this.AppSetTabPage = new System.Windows.Forms.TabPage();
            this.TempLabel = new System.Windows.Forms.Label();
            this.AppColorLAbel = new System.Windows.Forms.Label();
            this.DebugBox = new System.Windows.Forms.CheckBox();
            this.IconSizeBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.AppLookLabel = new System.Windows.Forms.Label();
            this.SpacerLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AutorizationLabel = new System.Windows.Forms.Label();
            this.UsedTempSizeLabel = new System.Windows.Forms.Label();
            this.MBLabel = new System.Windows.Forms.Label();
            this.TempSizeBox = new System.Windows.Forms.TextBox();
            this.TempSizeLabel = new System.Windows.Forms.Label();
            this.CleanBufferButton = new System.Windows.Forms.Button();
            this.InstallTabPage = new System.Windows.Forms.TabPage();
            this.OverwriteDirsBox = new System.Windows.Forms.CheckBox();
            this.RmPackageBox = new System.Windows.Forms.CheckBox();
            this.AutoInstallBox = new System.Windows.Forms.CheckBox();
            this.InstallPathLabel = new System.Windows.Forms.Label();
            this.DeviceInstallButton = new System.Windows.Forms.RadioButton();
            this.DownloadTabPage = new System.Windows.Forms.TabPage();
            this.ServersBox = new System.Windows.Forms.ComboBox();
            this.ServerTypeLabel = new System.Windows.Forms.Label();
            this.DownloadPathBox = new System.Windows.Forms.TextBox();
            this.DownloadPathLabel = new System.Windows.Forms.Label();
            this.OpenDirButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ParamsFormPanel = new System.Windows.Forms.Panel();
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.OkMenuItem = new System.Windows.Forms.MenuItem();
            this.CancelMenuItem = new System.Windows.Forms.MenuItem();
            this.AppSetTabPage.SuspendLayout();
            this.InstallTabPage.SuspendLayout();
            this.DownloadTabPage.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.ParamsFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppSetTabPage
            // 
            this.AppSetTabPage.AutoScroll = true;
            this.AppSetTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.AppSetTabPage.Controls.Add(this.TempLabel);
            this.AppSetTabPage.Controls.Add(this.AppColorLAbel);
            this.AppSetTabPage.Controls.Add(this.DebugBox);
            this.AppSetTabPage.Controls.Add(this.IconSizeBar);
            this.AppSetTabPage.Controls.Add(this.label1);
            this.AppSetTabPage.Controls.Add(this.AppLookLabel);
            this.AppSetTabPage.Controls.Add(this.SpacerLabel);
            this.AppSetTabPage.Controls.Add(this.LoginButton);
            this.AppSetTabPage.Controls.Add(this.PasswordBox);
            this.AppSetTabPage.Controls.Add(this.NameBox);
            this.AppSetTabPage.Controls.Add(this.PasswordLabel);
            this.AppSetTabPage.Controls.Add(this.NameLabel);
            this.AppSetTabPage.Controls.Add(this.AutorizationLabel);
            this.AppSetTabPage.Controls.Add(this.UsedTempSizeLabel);
            this.AppSetTabPage.Controls.Add(this.MBLabel);
            this.AppSetTabPage.Controls.Add(this.TempSizeBox);
            this.AppSetTabPage.Controls.Add(this.TempSizeLabel);
            this.AppSetTabPage.Controls.Add(this.CleanBufferButton);
            this.AppSetTabPage.Location = new System.Drawing.Point(0, 0);
            this.AppSetTabPage.Name = "AppSetTabPage";
            this.AppSetTabPage.Size = new System.Drawing.Size(240, 271);
            this.AppSetTabPage.Text = "App Settings";
            // 
            // TempLabel
            // 
            this.TempLabel.Location = new System.Drawing.Point(7, 228);
            this.TempLabel.Name = "TempLabel";
            this.TempLabel.Size = new System.Drawing.Size(100, 20);
            this.TempLabel.Text = "Temp Settings";
            // 
            // AppColorLAbel
            // 
            this.AppColorLAbel.Location = new System.Drawing.Point(7, 195);
            this.AppColorLAbel.Name = "AppColorLAbel";
            this.AppColorLAbel.Size = new System.Drawing.Size(100, 20);
            this.AppColorLAbel.Text = "App Color:";
            // 
            // DebugBox
            // 
            this.DebugBox.Location = new System.Drawing.Point(7, 172);
            this.DebugBox.Name = "DebugBox";
            this.DebugBox.Size = new System.Drawing.Size(169, 20);
            this.DebugBox.TabIndex = 24;
            this.DebugBox.Text = "Send debug information";
            // 
            // IconSizeBar
            // 
            this.IconSizeBar.LargeChange = 1;
            this.IconSizeBar.Location = new System.Drawing.Point(61, 147);
            this.IconSizeBar.Maximum = 200;
            this.IconSizeBar.Minimum = 100;
            this.IconSizeBar.Name = "IconSizeBar";
            this.IconSizeBar.Size = new System.Drawing.Size(163, 20);
            this.IconSizeBar.TabIndex = 22;
            this.IconSizeBar.TickFrequency = 10;
            this.IconSizeBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.IconSizeBar.Value = 100;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.Text = "Icon size";
            // 
            // AppLookLabel
            // 
            this.AppLookLabel.Location = new System.Drawing.Point(7, 126);
            this.AppLookLabel.Name = "AppLookLabel";
            this.AppLookLabel.Size = new System.Drawing.Size(100, 20);
            this.AppLookLabel.Text = "App Settings";
            // 
            // SpacerLabel
            // 
            this.SpacerLabel.Location = new System.Drawing.Point(39, 320);
            this.SpacerLabel.Name = "SpacerLabel";
            this.SpacerLabel.Size = new System.Drawing.Size(100, 20);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(7, 89);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(72, 20);
            this.LoginButton.TabIndex = 18;
            this.LoginButton.Text = "Log-In";
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(77, 62);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(100, 21);
            this.PasswordBox.TabIndex = 17;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(77, 35);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 21);
            this.NameBox.TabIndex = 16;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(7, 63);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(64, 20);
            this.PasswordLabel.Text = "Password";
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(7, 36);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(79, 20);
            this.NameLabel.Text = "User Name";
            // 
            // AutorizationLabel
            // 
            this.AutorizationLabel.Location = new System.Drawing.Point(7, 16);
            this.AutorizationLabel.Name = "AutorizationLabel";
            this.AutorizationLabel.Size = new System.Drawing.Size(100, 20);
            this.AutorizationLabel.Text = "Autorization";
            // 
            // UsedTempSizeLabel
            // 
            this.UsedTempSizeLabel.Location = new System.Drawing.Point(7, 271);
            this.UsedTempSizeLabel.Name = "UsedTempSizeLabel";
            this.UsedTempSizeLabel.Size = new System.Drawing.Size(198, 21);
            this.UsedTempSizeLabel.Text = "Used: 0 MB";
            // 
            // MBLabel
            // 
            this.MBLabel.Location = new System.Drawing.Point(168, 249);
            this.MBLabel.Name = "MBLabel";
            this.MBLabel.Size = new System.Drawing.Size(25, 20);
            this.MBLabel.Text = "MB";
            // 
            // TempSizeBox
            // 
            this.TempSizeBox.Location = new System.Drawing.Point(122, 246);
            this.TempSizeBox.Name = "TempSizeBox";
            this.TempSizeBox.Size = new System.Drawing.Size(45, 21);
            this.TempSizeBox.TabIndex = 10;
            // 
            // TempSizeLabel
            // 
            this.TempSizeLabel.Location = new System.Drawing.Point(7, 248);
            this.TempSizeLabel.Name = "TempSizeLabel";
            this.TempSizeLabel.Size = new System.Drawing.Size(116, 21);
            this.TempSizeLabel.Text = "Temp storage size:";
            // 
            // CleanBufferButton
            // 
            this.CleanBufferButton.Location = new System.Drawing.Point(7, 295);
            this.CleanBufferButton.Name = "CleanBufferButton";
            this.CleanBufferButton.Size = new System.Drawing.Size(79, 21);
            this.CleanBufferButton.TabIndex = 8;
            this.CleanBufferButton.Text = "Clean";
            this.CleanBufferButton.Click += new System.EventHandler(this.CleanBufferButton_Click);
            // 
            // InstallTabPage
            // 
            this.InstallTabPage.AutoScroll = true;
            this.InstallTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.InstallTabPage.Controls.Add(this.OverwriteDirsBox);
            this.InstallTabPage.Controls.Add(this.RmPackageBox);
            this.InstallTabPage.Controls.Add(this.AutoInstallBox);
            this.InstallTabPage.Controls.Add(this.InstallPathLabel);
            this.InstallTabPage.Controls.Add(this.DeviceInstallButton);
            this.InstallTabPage.Location = new System.Drawing.Point(0, 0);
            this.InstallTabPage.Name = "InstallTabPage";
            this.InstallTabPage.Size = new System.Drawing.Size(232, 268);
            this.InstallTabPage.Text = "Install";
            // 
            // OverwriteDirsBox
            // 
            this.OverwriteDirsBox.Location = new System.Drawing.Point(7, 14);
            this.OverwriteDirsBox.Name = "OverwriteDirsBox";
            this.OverwriteDirsBox.Size = new System.Drawing.Size(217, 20);
            this.OverwriteDirsBox.TabIndex = 6;
            this.OverwriteDirsBox.Text = "Overwrite files";
            // 
            // RmPackageBox
            // 
            this.RmPackageBox.Location = new System.Drawing.Point(7, 40);
            this.RmPackageBox.Name = "RmPackageBox";
            this.RmPackageBox.Size = new System.Drawing.Size(217, 20);
            this.RmPackageBox.TabIndex = 7;
            this.RmPackageBox.Text = "Autoremoving package";
            // 
            // AutoInstallBox
            // 
            this.AutoInstallBox.Location = new System.Drawing.Point(7, 66);
            this.AutoInstallBox.Name = "AutoInstallBox";
            this.AutoInstallBox.Size = new System.Drawing.Size(217, 20);
            this.AutoInstallBox.TabIndex = 8;
            this.AutoInstallBox.Text = "Automatic install";
            // 
            // InstallPathLabel
            // 
            this.InstallPathLabel.Location = new System.Drawing.Point(7, 94);
            this.InstallPathLabel.Name = "InstallPathLabel";
            this.InstallPathLabel.Size = new System.Drawing.Size(100, 20);
            this.InstallPathLabel.Text = "Install storage";
            // 
            // DeviceInstallButton
            // 
            this.DeviceInstallButton.Location = new System.Drawing.Point(7, 117);
            this.DeviceInstallButton.Name = "DeviceInstallButton";
            this.DeviceInstallButton.Size = new System.Drawing.Size(150, 20);
            this.DeviceInstallButton.TabIndex = 4;
            this.DeviceInstallButton.TabStop = false;
            this.DeviceInstallButton.Text = "Device";
            this.DeviceInstallButton.CheckedChanged += new System.EventHandler(this.DeviceInstallButton_CheckedChanged);
            // 
            // DownloadTabPage
            // 
            this.DownloadTabPage.AutoScroll = true;
            this.DownloadTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.DownloadTabPage.Controls.Add(this.ServersBox);
            this.DownloadTabPage.Controls.Add(this.ServerTypeLabel);
            this.DownloadTabPage.Controls.Add(this.DownloadPathBox);
            this.DownloadTabPage.Controls.Add(this.DownloadPathLabel);
            this.DownloadTabPage.Controls.Add(this.OpenDirButton);
            this.DownloadTabPage.Location = new System.Drawing.Point(0, 0);
            this.DownloadTabPage.Name = "DownloadTabPage";
            this.DownloadTabPage.Size = new System.Drawing.Size(240, 271);
            this.DownloadTabPage.Text = "Download";
            // 
            // ServersBox
            // 
            this.ServersBox.Location = new System.Drawing.Point(7, 37);
            this.ServersBox.Name = "ServersBox";
            this.ServersBox.Size = new System.Drawing.Size(100, 22);
            this.ServersBox.TabIndex = 14;
            // 
            // ServerTypeLabel
            // 
            this.ServerTypeLabel.Location = new System.Drawing.Point(7, 16);
            this.ServerTypeLabel.Name = "ServerTypeLabel";
            this.ServerTypeLabel.Size = new System.Drawing.Size(217, 20);
            this.ServerTypeLabel.Text = "Servers List";
            // 
            // DownloadPathBox
            // 
            this.DownloadPathBox.Location = new System.Drawing.Point(7, 93);
            this.DownloadPathBox.Name = "DownloadPathBox";
            this.DownloadPathBox.Size = new System.Drawing.Size(154, 21);
            this.DownloadPathBox.TabIndex = 6;
            // 
            // DownloadPathLabel
            // 
            this.DownloadPathLabel.Location = new System.Drawing.Point(7, 73);
            this.DownloadPathLabel.Name = "DownloadPathLabel";
            this.DownloadPathLabel.Size = new System.Drawing.Size(100, 20);
            this.DownloadPathLabel.Text = "Download Path";
            // 
            // OpenDirButton
            // 
            this.OpenDirButton.Location = new System.Drawing.Point(167, 93);
            this.OpenDirButton.Name = "OpenDirButton";
            this.OpenDirButton.Size = new System.Drawing.Size(57, 21);
            this.OpenDirButton.TabIndex = 7;
            this.OpenDirButton.Text = "Обзор";
            this.OpenDirButton.Click += new System.EventHandler(this.OpenDirButton_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.DownloadTabPage);
            this.TabControl.Controls.Add(this.InstallTabPage);
            this.TabControl.Controls.Add(this.AppSetTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(240, 294);
            this.TabControl.TabIndex = 11;
            // 
            // ParamsFormPanel
            // 
            this.ParamsFormPanel.Controls.Add(this.TabControl);
            this.ParamsFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParamsFormPanel.Location = new System.Drawing.Point(0, 0);
            this.ParamsFormPanel.Name = "ParamsFormPanel";
            this.ParamsFormPanel.Size = new System.Drawing.Size(240, 294);
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.OkMenuItem);
            this.MainMenu.MenuItems.Add(this.CancelMenuItem);
            // 
            // OkMenuItem
            // 
            this.OkMenuItem.Text = "OK";
            this.OkMenuItem.Click += new System.EventHandler(this.OkMenuItem_Click);
            // 
            // CancelMenuItem
            // 
            this.CancelMenuItem.Text = "Cancel";
            this.CancelMenuItem.Click += new System.EventHandler(this.CanselMenuItem_Click);
            // 
            // ParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.ParamsFormPanel);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.MainMenu;
            this.Name = "ParamsForm";
            this.Text = "Параметры";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ParamsBox_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ParamsForm_Closing);
            this.AppSetTabPage.ResumeLayout(false);
            this.InstallTabPage.ResumeLayout(false);
            this.DownloadTabPage.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.ParamsFormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage AppSetTabPage;
        private System.Windows.Forms.TabPage InstallTabPage;
        private System.Windows.Forms.CheckBox OverwriteDirsBox;
        private System.Windows.Forms.CheckBox RmPackageBox;
        private System.Windows.Forms.CheckBox AutoInstallBox;
        private System.Windows.Forms.Label InstallPathLabel;
        private System.Windows.Forms.RadioButton DeviceInstallButton;
        private System.Windows.Forms.TabPage DownloadTabPage;
        private System.Windows.Forms.TextBox DownloadPathBox;
        private System.Windows.Forms.Label DownloadPathLabel;
        private System.Windows.Forms.Button OpenDirButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.Label ServerTypeLabel;
        private System.Windows.Forms.TextBox TempSizeBox;
        private System.Windows.Forms.Label TempSizeLabel;
        private System.Windows.Forms.Label MBLabel;
        private System.Windows.Forms.Button CleanBufferButton;
        private System.Windows.Forms.Label UsedTempSizeLabel;
        private System.Windows.Forms.Panel ParamsFormPanel;
        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem OkMenuItem;
        private System.Windows.Forms.MenuItem CancelMenuItem;
        private System.Windows.Forms.ComboBox ServersBox;
        private System.Windows.Forms.Label AutorizationLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label AppLookLabel;
        private System.Windows.Forms.Label SpacerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar IconSizeBar;
        private System.Windows.Forms.CheckBox DebugBox;
        private System.Windows.Forms.Label AppColorLAbel;
        private System.Windows.Forms.Label TempLabel;
    }
}