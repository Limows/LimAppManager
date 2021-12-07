namespace LimAppManager
{
    partial class SendBugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu MainMenu;

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
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.SendMenuItem = new System.Windows.Forms.MenuItem();
            this.CancelMenuItem = new System.Windows.Forms.MenuItem();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.SendBugPanel = new System.Windows.Forms.Panel();
            this.SendBugPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.SendMenuItem);
            this.MainMenu.MenuItems.Add(this.CancelMenuItem);
            // 
            // SendMenuItem
            // 
            this.SendMenuItem.Text = "Send";
            this.SendMenuItem.Click += new System.EventHandler(this.SendMenuItem_Click);
            // 
            // CancelMenuItem
            // 
            this.CancelMenuItem.Text = "Cancel";
            this.CancelMenuItem.Click += new System.EventHandler(this.CancelMenuItem_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.AcceptsReturn = true;
            this.MessageBox.AcceptsTab = true;
            this.MessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageBox.Location = new System.Drawing.Point(0, 0);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(240, 294);
            this.MessageBox.TabIndex = 0;
            // 
            // SendBugPanel
            // 
            this.SendBugPanel.Controls.Add(this.MessageBox);
            this.SendBugPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendBugPanel.Location = new System.Drawing.Point(0, 0);
            this.SendBugPanel.Name = "SendBugPanel";
            this.SendBugPanel.Size = new System.Drawing.Size(240, 294);
            // 
            // SendBugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.SendBugPanel);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.MainMenu;
            this.Name = "SendBugForm";
            this.Text = "SendBugForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SendBugPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem SendMenuItem;
        private System.Windows.Forms.MenuItem CancelMenuItem;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Panel SendBugPanel;
    }
}