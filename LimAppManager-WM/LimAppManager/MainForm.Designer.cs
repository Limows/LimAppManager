namespace LimAppManager
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.ActionsMenuItem = new System.Windows.Forms.MenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.MenuItem();
            this.RefreshMenuItem = new System.Windows.Forms.MenuItem();
            this.InstalledMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.SendBugMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.QuitMenuItem = new System.Windows.Forms.MenuItem();
            this.InfoMenuItem = new System.Windows.Forms.MenuItem();
            this.HelpMenuItem = new System.Windows.Forms.MenuItem();
            this.AboutMenuItem = new System.Windows.Forms.MenuItem();
            this.SysInfoMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.UpdateMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.DonateMenuItem = new System.Windows.Forms.MenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.AppsListBox = new System.Windows.Forms.ListView();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.AppsLogoList = new System.Windows.Forms.ImageList();
            this.InputPanel = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.timer1 = new System.Windows.Forms.Timer();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.ActionsMenuItem);
            this.MainMenu.MenuItems.Add(this.InfoMenuItem);
            // 
            // ActionsMenuItem
            // 
            this.ActionsMenuItem.MenuItems.Add(this.SettingsMenuItem);
            this.ActionsMenuItem.MenuItems.Add(this.RefreshMenuItem);
            this.ActionsMenuItem.MenuItems.Add(this.InstalledMenuItem);
            this.ActionsMenuItem.MenuItems.Add(this.menuItem4);
            this.ActionsMenuItem.MenuItems.Add(this.SendBugMenuItem);
            this.ActionsMenuItem.MenuItems.Add(this.menuItem2);
            this.ActionsMenuItem.MenuItems.Add(this.QuitMenuItem);
            this.ActionsMenuItem.Text = "Actions";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Text = "Settings";
            this.SettingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // RefreshMenuItem
            // 
            this.RefreshMenuItem.Text = "Refresh";
            this.RefreshMenuItem.Click += new System.EventHandler(this.RefreshMenuItem_Click);
            // 
            // InstalledMenuItem
            // 
            this.InstalledMenuItem.Text = "Installed";
            this.InstalledMenuItem.Click += new System.EventHandler(this.InstalledMenuItem_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "-";
            // 
            // SendBugMenuItem
            // 
            this.SendBugMenuItem.Text = "Send Bug";
            this.SendBugMenuItem.Click += new System.EventHandler(this.SendBugMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "-";
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.Text = "Quit";
            this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // InfoMenuItem
            // 
            this.InfoMenuItem.MenuItems.Add(this.HelpMenuItem);
            this.InfoMenuItem.MenuItems.Add(this.AboutMenuItem);
            this.InfoMenuItem.MenuItems.Add(this.SysInfoMenuItem);
            this.InfoMenuItem.MenuItems.Add(this.menuItem8);
            this.InfoMenuItem.MenuItems.Add(this.UpdateMenuItem);
            this.InfoMenuItem.MenuItems.Add(this.menuItem10);
            this.InfoMenuItem.MenuItems.Add(this.DonateMenuItem);
            this.InfoMenuItem.Text = "Info";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Text = "Help";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // SysInfoMenuItem
            // 
            this.SysInfoMenuItem.Text = "System Info";
            this.SysInfoMenuItem.Click += new System.EventHandler(this.SysInfoMenuItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Text = "-";
            // 
            // UpdateMenuItem
            // 
            this.UpdateMenuItem.Text = "Update";
            this.UpdateMenuItem.Click += new System.EventHandler(this.UpdateMenuItem_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Text = "-";
            // 
            // DonateMenuItem
            // 
            this.DonateMenuItem.Text = "Donate";
            this.DonateMenuItem.Click += new System.EventHandler(this.DonateMenuItem_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.AppsListBox);
            this.MainPanel.Controls.Add(this.SearchBox);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // AppsListBox
            // 
            this.AppsListBox.BackColor = System.Drawing.Color.White;
            this.AppsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppsListBox.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            listViewItem1.ImageIndex = 0;
            listViewItem1.Text = "App 1";
            listViewItem2.ImageIndex = 1;
            listViewItem2.Text = "App 2";
            listViewItem3.ImageIndex = 2;
            listViewItem3.Text = "App 3";
            this.AppsListBox.Items.Add(listViewItem1);
            this.AppsListBox.Items.Add(listViewItem2);
            this.AppsListBox.Items.Add(listViewItem3);
            this.AppsListBox.Location = new System.Drawing.Point(0, 21);
            this.AppsListBox.Name = "AppsListBox";
            this.AppsListBox.Size = new System.Drawing.Size(240, 247);
            this.AppsListBox.TabIndex = 1;
            this.AppsListBox.View = System.Windows.Forms.View.Details;
            this.AppsListBox.ItemActivate += new System.EventHandler(this.AppsListBox_ItemActivate);
            // 
            // SearchBox
            // 
            this.SearchBox.BackColor = System.Drawing.Color.White;
            this.SearchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchBox.Location = new System.Drawing.Point(0, 0);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(240, 21);
            this.SearchBox.TabIndex = 2;
            this.SearchBox.Text = "Search...";
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.GotFocus += new System.EventHandler(this.SearchBox_GotFocus);
            this.SearchBox.LostFocus += new System.EventHandler(this.SearchBox_LostFocus);
            // 
            // AppsLogoList
            // 
            this.AppsLogoList.ImageSize = new System.Drawing.Size(35, 35);
            this.AppsLogoList.Images.Clear();
            this.AppsLogoList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.AppsLogoList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.AppsLogoList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.MainPanel);
            this.KeyPreview = true;
            this.Menu = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "App Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem ActionsMenuItem;
        private System.Windows.Forms.MenuItem SettingsMenuItem;
        private System.Windows.Forms.MenuItem RefreshMenuItem;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem QuitMenuItem;
        private System.Windows.Forms.MenuItem InfoMenuItem;
        private System.Windows.Forms.MenuItem HelpMenuItem;
        private System.Windows.Forms.MenuItem AboutMenuItem;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem UpdateMenuItem;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem DonateMenuItem;
        private System.Windows.Forms.MenuItem InstalledMenuItem;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ListView AppsListBox;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.ImageList AppsLogoList;
        private Microsoft.WindowsCE.Forms.InputPanel InputPanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuItem SendBugMenuItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem SysInfoMenuItem;

    }
}

