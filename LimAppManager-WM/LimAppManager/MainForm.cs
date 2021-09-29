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
            Parameters.OSVersion = Environment.OSVersion.Version.Major;

            try
            {
                IOHelper.ReadSettings();
            }
            catch
            {
                MessageBox.Show("Config file not found or corrupted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                Parameters.IconSize = 100;
                Parameters.TempPath = @"\Temp\AppManager";
            }

            try
            {
                Parameters.ServersList = GetServersList(Parameters.ServersPath);
            }
            catch
            {
                MessageBox.Show("No servers found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                Parameters.ServersList = new Dictionary<string, Uri>();
            }

            ImageLogoList_SetSize();
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

            ImageLogoList_SetSize();

            try
            {
                IOHelper.WriteSettings();
            }
            catch
            {
                MessageBox.Show("Config file not found or corrupted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
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
        }

        private Dictionary<string, Uri> GetServersList(string FileName)
        {   
            string Text = IOHelper.ReadTextFile(IOHelper.GetCurrentDirectory() + FileName);
            string[] Lines = Text.Split('\n');
            Dictionary<string, Uri> ServersList = new Dictionary<string, Uri>();

            foreach (string line in Lines)
            {
                string[] ServerLine = line.Split('=');

                ServersList.Add(ServerLine[0], new Uri(ServerLine[1]));
            }

            return ServersList;
        }

        private void InstalledMenuItem_Click(object sender, EventArgs e)
        {
            InstalledForm Installed = new InstalledForm();

            Installed.ShowDialog();
        }

        private void AppsListBox_ItemActivate(object sender, EventArgs e)
        {
            AppForm App = new AppForm("Test");

            App.ShowDialog();
        }
    }
}