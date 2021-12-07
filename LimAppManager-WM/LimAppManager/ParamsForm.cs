using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinMobileNetCFExt.Forms;
using WinMobileNetCFExt;

namespace LimAppManager
{
    public partial class ParamsForm : Form
    {
        private bool IsSaveParams = false;
 
        public ParamsForm()
        {
            InitializeComponent();
        }

        private string CheckDirectory(string Path)
        {
            if (Directory.Exists(Path))
            {
                return Path;
            }
            else
            {
                DialogResult Result = MessageBox.Show("Such a directory does not exist. \nCreate?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                if (Result == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(Path);
                        return Path;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to create directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        return "";
                    }
                }
                else return "";
            }
        }

        private void OpenDirButton_Click(object sender, EventArgs e)
        {
            DownloadPathBox.Text = OpenDirDialog();
        }

        private string OpenDirDialog()
        {
            FolderBrowserDialog OpenDir = new FolderBrowserDialog();

            if (OpenDir.ShowDialog() == DialogResult.OK)
            {
                return OpenDir.SelectedPath;
            }
            else return "";
        }

        private void ParamsBox_Load(object sender, EventArgs e)
        {
            IconSizeBar.Value = Parameters.IconSize;
            DownloadPathBox.Text = Parameters.DownloadPath;
            OverwriteDirsBox.Checked = Parameters.IsOverwrite;
            AutoInstallBox.Checked = Parameters.IsAutoInstall;
            RmPackageBox.Checked = Parameters.IsRmPackage;
            DebugBox.Checked = Parameters.IsSendDebug;
            TempSizeBox.Text = Parameters.BytesToMegs(Parameters.TempSize).ToString("0.##");
            UsedTempSizeLabel.Text = "Used: " + Parameters.BytesToMegs(IOHelper.GetDirectorySize(Parameters.TempPath)).ToString("0.###") + " MB";    

            foreach (string server in Parameters.ServersList.Keys)
            {
                ServersBox.Items.Add(server);
            }

            ServersBox.SelectedItem = Parameters.Server;

            bool IsDevInstall = true;
            List<string> StoragesNames = IO.GetAllRemovableStorages();

            if (!(StoragesNames.Count == 0))
            {
                int Spacer = AutoInstallBox.Top - RmPackageBox.Bottom;
                int ButtonTop = DeviceInstallButton.Bottom + Spacer;
                int ButtonLeft = DeviceInstallButton.Left;
                int ButtonWidth = DeviceInstallButton.Width;
                int ButtonHeight = DeviceInstallButton.Height;

                int i = 1;

                foreach (string storage in StoragesNames)
                {
                    RadioButton StorageButton = new RadioButton();

                    StorageButton.Left = ButtonLeft;
                    StorageButton.Top = ButtonTop;
                    StorageButton.Width = ButtonWidth;
                    StorageButton.Height = ButtonHeight;
                    StorageButton.Text = storage;
                    StorageButton.Name = "StorageButton" + i;
                    StorageButton.CheckedChanged += StorageButton_CheckedChanged;

                    if (!String.IsNullOrEmpty(Parameters.InstallPath))
                    {
                        if (storage == Parameters.InstallPath.Split('\\')[1])
                        {
                            StorageButton.Checked = true;
                            IsDevInstall = false;
                        }
                    }

                    InstallTabPage.Controls.Add(StorageButton);

                    ButtonTop += DeviceInstallButton.Height + Spacer;

                    i++;
                }
            }

            if (IsDevInstall)
            {
                DeviceInstallButton.Checked = true;
            }
        }

        private void StorageButton_CheckedChanged(object sender, EventArgs e)
        {
            string DriveName;

            try
            {
                if (((RadioButton)sender).Checked)
                {
                    DriveName = ((RadioButton)sender).Text;
                    Parameters.InstallPath = @"\" + DriveName + @"\Program Files";
                    DeviceInstallButton.Checked = false;
                }
            }
            catch
            {
                Parameters.InstallPath = null;
            }
        }

        private void CleanBufferButton_Click(object sender, EventArgs e)
        {
            try
            {
                IOHelper.CleanBuffer();
                UsedTempSizeLabel.Text = "Used: " + Parameters.BytesToMegs(IOHelper.GetDirectorySize(Parameters.TempPath)).ToString("0.###") + " MB";
            }
            catch
            {

            }
        }

        private void ParamsForm_Closing(object sender, CancelEventArgs e)
        {
            if (IsSaveParams)
            {
                Parameters.DownloadPath = CheckDirectory(DownloadPathBox.Text);
                Parameters.IsAutoInstall = AutoInstallBox.Checked;
                Parameters.IsRmPackage = RmPackageBox.Checked;
                Parameters.IsOverwrite = OverwriteDirsBox.Checked;
                Parameters.IsSendDebug = DebugBox.Checked;
                Parameters.IconSize = IconSizeBar.Value;
                Parameters.Server = (string)ServersBox.SelectedItem;

                if (String.IsNullOrEmpty(Parameters.InstallPath))
                {
                    MessageBox.Show("Choose an install storage", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    e.Cancel = true;
                    return;
                }
                else
                {

                    try
                    {
                        if (!Directory.Exists(Parameters.InstallPath))
                        {
                            Directory.CreateDirectory(Parameters.InstallPath);
                        }

                        Parameters.SysInfo.DriveSpace = Parameters.BytesToMegs(IO.GetStorageSpace(Parameters.InstallPath));
                    }
                    catch
                    {
                        MessageBox.Show("The selected device is not ready", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        
                        Parameters.SysInfo.DriveSpace = 0;
                        e.Cancel = true;
                        return;
                    }
                }

                if (String.IsNullOrEmpty(Parameters.DownloadPath))
                {
                    MessageBox.Show("The path cannot be empty", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    e.Cancel = true;
                    return;
                }

                if (String.IsNullOrEmpty(TempSizeBox.Text) || Convert.ToDouble(TempSizeBox.Text) == 0)
                {
                    MessageBox.Show("Temp size not set", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Parameters.TempSize = Parameters.MegsToBytes(Convert.ToDouble(TempSizeBox.Text));
                }

                e.Cancel = false;
            }
        }

        private void DeviceInstallButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (((RadioButton)sender).Checked)
                {
                    Parameters.InstallPath = @"\Program Files";
                }
            }
            catch
            {
                Parameters.InstallPath = null;
            }
        }

        private void OkMenuItem_Click(object sender, EventArgs e)
        {
            IsSaveParams = true;
            Close();
        }

        private void CanselMenuItem_Click(object sender, EventArgs e)
        {
            IsSaveParams = false;
            Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string NameHash = HashHelper.GetMD5Hash(NameBox.Text);
            string PasswordHash = HashHelper.GetMD5Hash(NameBox.Text);
            NetHelper Net = new NetHelper();
            Uri ServerUri = new Uri("http://limowski.xyz");

            Net.SendAutorizationInfo(ServerUri, NameHash, PasswordHash);
        }
    }
}