namespace LimAppManager
{
    partial class SysInfoBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysInfoBox));
            this.labelOSVersion = new System.Windows.Forms.Label();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.labelCPU = new System.Windows.Forms.Label();
            this.labelRAM = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.OKMenuItem = new System.Windows.Forms.MenuItem();
            this.AboutPanel = new System.Windows.Forms.Panel();
            this.labelDrive = new System.Windows.Forms.Label();
            this.labelScreenSize = new System.Windows.Forms.Label();
            this.AboutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOSVersion
            // 
            resources.ApplyResources(this.labelOSVersion, "labelOSVersion");
            this.labelOSVersion.Name = "labelOSVersion";
            // 
            // labelDeviceName
            // 
            resources.ApplyResources(this.labelDeviceName, "labelDeviceName");
            this.labelDeviceName.Name = "labelDeviceName";
            // 
            // labelCPU
            // 
            resources.ApplyResources(this.labelCPU, "labelCPU");
            this.labelCPU.Name = "labelCPU";
            // 
            // labelRAM
            // 
            resources.ApplyResources(this.labelRAM, "labelRAM");
            this.labelRAM.Name = "labelRAM";
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.OKMenuItem);
            // 
            // OKMenuItem
            // 
            resources.ApplyResources(this.OKMenuItem, "OKMenuItem");
            this.OKMenuItem.Click += new System.EventHandler(this.OKMenuItem_Click);
            // 
            // AboutPanel
            // 
            this.AboutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.AboutPanel.Controls.Add(this.labelScreenSize);
            this.AboutPanel.Controls.Add(this.labelDrive);
            this.AboutPanel.Controls.Add(this.labelOSVersion);
            this.AboutPanel.Controls.Add(this.labelRAM);
            this.AboutPanel.Controls.Add(this.labelDeviceName);
            this.AboutPanel.Controls.Add(this.labelCPU);
            resources.ApplyResources(this.AboutPanel, "AboutPanel");
            this.AboutPanel.Name = "AboutPanel";
            // 
            // labelDrive
            // 
            resources.ApplyResources(this.labelDrive, "labelDrive");
            this.labelDrive.Name = "labelDrive";
            // 
            // labelScreenSize
            // 
            resources.ApplyResources(this.labelScreenSize, "labelScreenSize");
            this.labelScreenSize.Name = "labelScreenSize";
            // 
            // SysInfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.Controls.Add(this.AboutPanel);
            this.Menu = this.MainMenu;
            this.Name = "SysInfoBox";
            this.AboutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelOSVersion;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.Label labelRAM;
        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem OKMenuItem;
        private System.Windows.Forms.Panel AboutPanel;
        private System.Windows.Forms.Label labelDrive;
        private System.Windows.Forms.Label labelScreenSize;
    }
}