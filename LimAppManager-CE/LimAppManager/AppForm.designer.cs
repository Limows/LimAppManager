namespace LimAppManager
{
    partial class AppForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.DownloadingTimer = new System.Windows.Forms.Timer();
            this.DescriptionBox = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.UpperPanel = new System.Windows.Forms.Panel();
            this.LowerPanel = new System.Windows.Forms.Panel();
            this.InstallButton = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.ActionsMenuItem = new System.Windows.Forms.MenuItem();
            this.InstallMenuItem = new System.Windows.Forms.MenuItem();
            this.BackMenuItem = new System.Windows.Forms.MenuItem();
            this.UpperPanel.SuspendLayout();
            this.LowerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogoBox
            // 
            this.LogoBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.LogoBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoBox.Image")));
            this.LogoBox.Location = new System.Drawing.Point(0, 0);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(61, 61);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLabel.Location = new System.Drawing.Point(61, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(577, 20);
            this.NameLabel.Text = "Name";
            // 
            // VersionLabel
            // 
            this.VersionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.VersionLabel.Location = new System.Drawing.Point(61, 20);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(577, 20);
            this.VersionLabel.Text = "Version";
            // 
            // SizeLabel
            // 
            this.SizeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SizeLabel.Location = new System.Drawing.Point(61, 40);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(577, 20);
            this.SizeLabel.Text = "Size";
            // 
            // DownloadingTimer
            // 
            this.DownloadingTimer.Tick += new System.EventHandler(this.DownloadingTimer_Tick);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionBox.Location = new System.Drawing.Point(0, 110);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(638, 345);
            this.DescriptionBox.Text = "Description";
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.Location = new System.Drawing.Point(0, 34);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(638, 15);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(81, 9);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(139, 19);
            this.StatusLabel.Text = "Status";
            // 
            // UpperPanel
            // 
            this.UpperPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.UpperPanel.Controls.Add(this.SizeLabel);
            this.UpperPanel.Controls.Add(this.VersionLabel);
            this.UpperPanel.Controls.Add(this.NameLabel);
            this.UpperPanel.Controls.Add(this.LogoBox);
            this.UpperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpperPanel.Location = new System.Drawing.Point(0, 0);
            this.UpperPanel.Name = "UpperPanel";
            this.UpperPanel.Size = new System.Drawing.Size(638, 61);
            // 
            // LowerPanel
            // 
            this.LowerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.LowerPanel.Controls.Add(this.StatusLabel);
            this.LowerPanel.Controls.Add(this.StatusBar);
            this.LowerPanel.Controls.Add(this.InstallButton);
            this.LowerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LowerPanel.Location = new System.Drawing.Point(0, 61);
            this.LowerPanel.Name = "LowerPanel";
            this.LowerPanel.Size = new System.Drawing.Size(638, 49);
            // 
            // InstallButton
            // 
            this.InstallButton.Location = new System.Drawing.Point(3, 8);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(72, 20);
            this.InstallButton.TabIndex = 6;
            this.InstallButton.Text = "Download";
            this.InstallButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.ActionsMenuItem);
            this.MainMenu.MenuItems.Add(this.BackMenuItem);
            // 
            // ActionsMenuItem
            // 
            this.ActionsMenuItem.MenuItems.Add(this.InstallMenuItem);
            this.ActionsMenuItem.Text = "Actions";
            // 
            // InstallMenuItem
            // 
            this.InstallMenuItem.Text = "Download";
            this.InstallMenuItem.Click += new System.EventHandler(this.InstallMenuItem_Click);
            // 
            // BackMenuItem
            // 
            this.BackMenuItem.Text = "Back";
            this.BackMenuItem.Click += new System.EventHandler(this.BackMenuItem_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.LowerPanel);
            this.Controls.Add(this.UpperPanel);
            this.Menu = this.MainMenu;
            this.Name = "AppForm";
            this.Text = "AppForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AppForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AppForm_FormClosing);
            this.UpperPanel.ResumeLayout(false);
            this.LowerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Timer DownloadingTimer;
        private System.Windows.Forms.Label DescriptionBox;
        private System.Windows.Forms.ProgressBar StatusBar;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Panel UpperPanel;
        private System.Windows.Forms.Panel LowerPanel;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem ActionsMenuItem;
        private System.Windows.Forms.MenuItem BackMenuItem;
        private System.Windows.Forms.MenuItem InstallMenuItem;
    }
}