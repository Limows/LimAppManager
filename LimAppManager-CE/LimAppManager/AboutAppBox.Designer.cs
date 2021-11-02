namespace LimAppManager
{
    partial class AboutAppBox
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
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxInstallPath = new System.Windows.Forms.TextBox();
            this.labelInstallDate = new System.Windows.Forms.Label();
            this.AboutAppPanel = new System.Windows.Forms.Panel();
            this.AboutAppPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelProductName.Location = new System.Drawing.Point(0, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(238, 20);
            this.labelProductName.Text = "Имя программы";
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVersion.Location = new System.Drawing.Point(0, 20);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(238, 20);
            this.labelVersion.Text = "Версия";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCompanyName.Location = new System.Drawing.Point(0, 40);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(238, 20);
            this.labelCompanyName.Text = "Имя компании";
            // 
            // textBoxInstallPath
            // 
            this.textBoxInstallPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.textBoxInstallPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInstallPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInstallPath.Location = new System.Drawing.Point(0, 89);
            this.textBoxInstallPath.Multiline = true;
            this.textBoxInstallPath.Name = "textBoxInstallPath";
            this.textBoxInstallPath.ReadOnly = true;
            this.textBoxInstallPath.Size = new System.Drawing.Size(238, 126);
            this.textBoxInstallPath.TabIndex = 7;
            this.textBoxInstallPath.Text = "Путь установки ";
            // 
            // labelInstallDate
            // 
            this.labelInstallDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelInstallDate.Location = new System.Drawing.Point(0, 60);
            this.labelInstallDate.Name = "labelInstallDate";
            this.labelInstallDate.Size = new System.Drawing.Size(238, 20);
            this.labelInstallDate.Text = "Дата установки";
            // 
            // AboutAppPanel
            // 
            this.AboutAppPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.AboutAppPanel.Controls.Add(this.labelInstallDate);
            this.AboutAppPanel.Controls.Add(this.labelCompanyName);
            this.AboutAppPanel.Controls.Add(this.labelVersion);
            this.AboutAppPanel.Controls.Add(this.labelProductName);
            this.AboutAppPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AboutAppPanel.Location = new System.Drawing.Point(0, 0);
            this.AboutAppPanel.Name = "AboutAppPanel";
            this.AboutAppPanel.Size = new System.Drawing.Size(238, 89);
            // 
            // AboutAppBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(238, 215);
            this.Controls.Add(this.textBoxInstallPath);
            this.Controls.Add(this.AboutAppPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutAppBox";
            this.Text = "О программе";
            this.AboutAppPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxInstallPath;
        private System.Windows.Forms.Label labelInstallDate;
        private System.Windows.Forms.Panel AboutAppPanel;
    }
}