using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LimAppManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ImageLogoList_SetSize();
            Parameters.OSVersion = Environment.OSVersion.Version.Major;

            IOHelper.ReadSettings();
        }

        private void ImageLogoList_SetSize()
        {
            int NewSize = (int)(Parameters.IconSize * System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 1000);

            AppsLogoList.ImageSize = new Size(NewSize, NewSize);
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox About = new AboutBox();

            About.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Rocker Up
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Rocker Down
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void DonateMenuItem_Click(object sender, EventArgs e)
        {
            DonateBox Donate = new DonateBox();

            Donate.ShowDialog();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            ParamsForm Params = new ParamsForm();

            Params.ShowDialog();
        }

        private void UpdateMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox NewAboutBox = new AboutBox();
            string CurrentVersion = NewAboutBox.AssemblyVersion;
            string Version;

            try
            {
                Version = NetHelper.CheckUpdates();
            }
            catch
            {
                MessageBox.Show("Failed to check for updates", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            if (CurrentVersion != Version)
            {
                DialogResult Result = MessageBox.Show("Version: " + Version, "Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Result == DialogResult.Yes)
                {
                    Version = Version.Remove(Version.LastIndexOf('.'), 2);

                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        NetHelper.GetUpdates(Version);
                        Cursor.Current = Cursors.Default;
                    }
                    catch
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Failed to download update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }

                    //SystemHelper.CabInstall(ParamsHelper.DownloadPath + "\\Update.bat", ParamsHelper.InstallPath + "\\LimFTPClient", true);
                }
            }
            else
            {
                MessageBox.Show("Nothing to update", "Info");
            }
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            IOHelper.WriteSettings();
        }
    }
}