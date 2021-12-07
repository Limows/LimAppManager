
namespace MetaBuilder
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildButton = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.OriginBox = new System.Windows.Forms.TextBox();
            this.OsBox = new System.Windows.Forms.TextBox();
            this.MaintainerBox = new System.Windows.Forms.TextBox();
            this.OsLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.OriginLabel = new System.Windows.Forms.Label();
            this.MaintainerLabel = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.RichTextBox();
            this.VersionBox = new System.Windows.Forms.TextBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(624, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(12, 273);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(176, 41);
            this.BuildButton.TabIndex = 1;
            this.BuildButton.Text = "Build";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(12, 126);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(176, 20);
            this.NameBox.TabIndex = 2;
            // 
            // OriginBox
            // 
            this.OriginBox.Location = new System.Drawing.Point(12, 208);
            this.OriginBox.Name = "OriginBox";
            this.OriginBox.Size = new System.Drawing.Size(176, 20);
            this.OriginBox.TabIndex = 3;
            // 
            // OsBox
            // 
            this.OsBox.Location = new System.Drawing.Point(12, 87);
            this.OsBox.Name = "OsBox";
            this.OsBox.Size = new System.Drawing.Size(176, 20);
            this.OsBox.TabIndex = 4;
            // 
            // MaintainerBox
            // 
            this.MaintainerBox.Location = new System.Drawing.Point(12, 247);
            this.MaintainerBox.Name = "MaintainerBox";
            this.MaintainerBox.Size = new System.Drawing.Size(176, 20);
            this.MaintainerBox.TabIndex = 5;
            // 
            // OsLabel
            // 
            this.OsLabel.AutoSize = true;
            this.OsLabel.Location = new System.Drawing.Point(12, 71);
            this.OsLabel.Name = "OsLabel";
            this.OsLabel.Size = new System.Drawing.Size(22, 13);
            this.OsLabel.TabIndex = 6;
            this.OsLabel.Text = "OS";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 110);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "Name";
            // 
            // OriginLabel
            // 
            this.OriginLabel.AutoSize = true;
            this.OriginLabel.Location = new System.Drawing.Point(12, 192);
            this.OriginLabel.Name = "OriginLabel";
            this.OriginLabel.Size = new System.Drawing.Size(34, 13);
            this.OriginLabel.TabIndex = 8;
            this.OriginLabel.Text = "Origin";
            // 
            // MaintainerLabel
            // 
            this.MaintainerLabel.AutoSize = true;
            this.MaintainerLabel.Location = new System.Drawing.Point(12, 231);
            this.MaintainerLabel.Name = "MaintainerLabel";
            this.MaintainerLabel.Size = new System.Drawing.Size(56, 13);
            this.MaintainerLabel.TabIndex = 9;
            this.MaintainerLabel.Text = "Maintainer";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(213, 87);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(399, 180);
            this.DescriptionBox.TabIndex = 10;
            this.DescriptionBox.Text = "";
            // 
            // VersionBox
            // 
            this.VersionBox.Location = new System.Drawing.Point(12, 169);
            this.VersionBox.Name = "VersionBox";
            this.VersionBox.Size = new System.Drawing.Size(176, 20);
            this.VersionBox.TabIndex = 11;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(12, 153);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(42, 13);
            this.VersionLabel.TabIndex = 12;
            this.VersionLabel.Text = "Version";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(210, 71);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 13;
            this.DescriptionLabel.Text = "Description";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.VersionBox);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.MaintainerLabel);
            this.Controls.Add(this.OriginLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.OsLabel);
            this.Controls.Add(this.MaintainerBox);
            this.Controls.Add(this.OsBox);
            this.Controls.Add(this.OriginBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Meta Builder for LimAppManager";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox OriginBox;
        private System.Windows.Forms.TextBox OsBox;
        private System.Windows.Forms.TextBox MaintainerBox;
        private System.Windows.Forms.Label OsLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label OriginLabel;
        private System.Windows.Forms.Label MaintainerLabel;
        private System.Windows.Forms.RichTextBox DescriptionBox;
        private System.Windows.Forms.TextBox VersionBox;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label DescriptionLabel;
    }
}

