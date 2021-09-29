﻿namespace LimAppManager
{
    partial class InstalledForm
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
            this.ActionsMenuItem = new System.Windows.Forms.MenuItem();
            this.PropMenuItem = new System.Windows.Forms.MenuItem();
            this.RemoveMenuItem = new System.Windows.Forms.MenuItem();
            this.BackMenuItem = new System.Windows.Forms.MenuItem();
            this.InstalledPanel = new System.Windows.Forms.Panel();
            this.InstalledBox = new System.Windows.Forms.ListBox();
            this.MemLabel = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.InstalledPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.ActionsMenuItem);
            this.MainMenu.MenuItems.Add(this.BackMenuItem);
            // 
            // ActionsMenuItem
            // 
            this.ActionsMenuItem.MenuItems.Add(this.PropMenuItem);
            this.ActionsMenuItem.MenuItems.Add(this.RemoveMenuItem);
            this.ActionsMenuItem.Text = "Actions";
            // 
            // PropMenuItem
            // 
            this.PropMenuItem.Text = "Properties";
            this.PropMenuItem.Click += new System.EventHandler(this.PropMenuItem_Click);
            // 
            // RemoveMenuItem
            // 
            this.RemoveMenuItem.Text = "Remove";
            this.RemoveMenuItem.Click += new System.EventHandler(this.RemoveMenuItem_Click);
            // 
            // BackMenuItem
            // 
            this.BackMenuItem.Text = "Back";
            this.BackMenuItem.Click += new System.EventHandler(this.BackMenuItem_Click);
            // 
            // InstalledPanel
            // 
            this.InstalledPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.InstalledPanel.Controls.Add(this.InstalledBox);
            this.InstalledPanel.Controls.Add(this.MemLabel);
            this.InstalledPanel.Controls.Add(this.SearchBox);
            this.InstalledPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstalledPanel.Location = new System.Drawing.Point(0, 0);
            this.InstalledPanel.Name = "InstalledPanel";
            this.InstalledPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // InstalledBox
            // 
            this.InstalledBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstalledBox.Location = new System.Drawing.Point(0, 21);
            this.InstalledBox.Name = "InstalledBox";
            this.InstalledBox.Size = new System.Drawing.Size(240, 226);
            this.InstalledBox.TabIndex = 2;
            // 
            // MemLabel
            // 
            this.MemLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MemLabel.Location = new System.Drawing.Point(0, 248);
            this.MemLabel.Name = "MemLabel";
            this.MemLabel.Size = new System.Drawing.Size(240, 20);
            this.MemLabel.Text = "Free memory amount:";
            // 
            // SearchBox
            // 
            this.SearchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchBox.Location = new System.Drawing.Point(0, 0);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(240, 21);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.Text = "Search...";
            // 
            // InstalledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.InstalledPanel);
            this.Menu = this.MainMenu;
            this.Name = "InstalledForm";
            this.Text = "Installed Apps";
            this.Load += new System.EventHandler(this.InstalledForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.InstalledForm_Closing);
            this.InstalledPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel InstalledPanel;
        private System.Windows.Forms.MenuItem ActionsMenuItem;
        private System.Windows.Forms.MenuItem PropMenuItem;
        private System.Windows.Forms.MenuItem RemoveMenuItem;
        private System.Windows.Forms.ListBox InstalledBox;
        private System.Windows.Forms.Label MemLabel;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.MenuItem BackMenuItem;
    }
}