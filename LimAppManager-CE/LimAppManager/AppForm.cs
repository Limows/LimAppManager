using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;

namespace LimAppManager
{
    public partial class AppForm : Form
    {
        private Uri AppUri;
        private Parameters.InstallableApp App = new Parameters.InstallableApp();
        bool IsDownloaded = true;
        int LowerPanelHeight = 0;

        public AppForm(string AppName)
        {
            InitializeComponent();

            //Uri AppUri = Parameters.AppsList[AppName];
            Uri AppUri = Parameters.ServersList[Parameters.Server];
            this.Text = AppName;

            LowerPanelHeight = LowerPanel.Height;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadingTimer.Enabled = true;
            InstallButton.Visible = false;
            StatusBar.Visible = true;
            StatusBar.Value = StatusBar.Minimum;
            StatusLabel.Left = InstallButton.Left;
            StatusLabel.Height = InstallButton.Height;
            LowerPanel.Height = LowerPanelHeight;

            if (!IsDownloaded)
            {
                if (!String.IsNullOrEmpty(Parameters.DownloadPath))
                {
                    Mutex DownloadingMutex = new Mutex();
                    ThreadStart DownloadingStarter = delegate { DownloadingThreadWorker(AppUri, Parameters.DownloadPath, App.PackageName, DownloadingMutex); };
                    Thread DownloadingThread = new Thread(DownloadingStarter);

                    //DownloadingThread.Start();

                    StatusLabel.Text = "Now downloading";
                }
                else
                {
                    MessageBox.Show("Download path not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(Parameters.InstallPath))
                {
                    Mutex InstallingMutex = new Mutex();
                    ThreadStart InstallingStarter = delegate { InstallingThreadWorker(Parameters.DownloadPath, Parameters.InstallPath, App, InstallingMutex); };
                    Thread InstallingThread = new Thread(InstallingStarter);

                    InstallingThread.Start();

                    StatusLabel.Text = "Now installing";
                }
                else
                {
                    MessageBox.Show("Install path not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }

        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            //Uri AppUri = Parameters.AppsList[AppName];
            Uri AppUri = Parameters.ServersList[Parameters.Server];
            NetHelper Net = new NetHelper();

            Parameters.EndResponseEvent = new AutoResetEvent(false);

            DownloadingTimer.Enabled = false;
            DownloadingTimer.Interval = 100;

            LogoBox.Width = LogoBox.Height;
            StatusLabel.Text = "";
            DescriptionBox.Text = "";
            StatusBar.Visible = false;
            LowerPanel.Height = StatusBar.Top;

            Net.GetAppMetaInfo(AppUri);

            Parameters.EndResponseEvent.WaitOne();

            if (!String.IsNullOrEmpty(Parameters.ResponseMessage))
            {
                App = JsonConvert.DeserializeObject<Parameters.InstallableApp>(Parameters.ResponseMessage);

                if (IOHelper.FindFile(Parameters.DownloadPath, App.PackageName))
                {
                    IsDownloaded = true;
                    InstallButton.Text = "Install";
                    InstallMenuItem.Text = "Install";
                }

                Cursor.Current = Cursors.Default;
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Couldn't connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                App.Name = "Test";
                App.PackageName = "Test.cab";
                App.Author = "LimSoft";
                App.IconName = "";
                App.IsCompressed = false;
                App.Size = Parameters.MegsToBytes(0.01);
                App.Version = "1.0.0";
            }
        }

        private void AppForm_FormClosing(object sender, CancelEventArgs e)
        {

        }

        private void UpdateUI(string Message)
        {
            DownloadingTimer.Enabled = false;

            if (InvokeRequired)
            {
                InstallButton.Invoke((Action)(() => { InstallButton.Visible = true; }));
                StatusBar.Invoke((Action)(() => { StatusBar.Visible = false; }));
                StatusLabel.Invoke((Action)(() => { StatusLabel.Left = InstallButton.Right + 5; }));
                LowerPanel.Invoke((Action)(() => { LowerPanel.Height = StatusBar.Top; }));
                StatusLabel.Invoke((Action)(() => { StatusLabel.Text = Message; }));
            }
            else
            {
                InstallButton.Visible = true;
                StatusBar.Visible = false;
                StatusLabel.Left = InstallButton.Right + 5;
                LowerPanel.Height = StatusBar.Top;
                StatusLabel.Text = Message;
            }
        }

        private void DownloadingThreadWorker(Uri CurrentURI, string DownloadPath, string PackageName, Mutex DownloadingMutex)
        {
            NetHelper Net = new NetHelper();
            Net.GetFile(CurrentURI, DownloadPath, PackageName);

            Parameters.EndResponseEvent.WaitOne();

            UpdateUI("Download successfully");

            IsDownloaded = true;
            InstallButton.Text = "Install";
            InstallMenuItem.Text = "Install";
        }

        private void InstallingThreadWorker(string DownloadPath, string InstallPath, Parameters.InstallableApp App, Mutex InstallingMutex)
        {   
            bool IsInstalled = false;
            string ExtractedPath = "";

            if (App.IsCompressed)
            {
                try
                {
                    ExtractedPath = IOHelper.ExtractToDirectory(DownloadPath + "\\" + App.PackageName, DownloadPath + "\\" + App.Name);
                }
                catch (Exception NewEx)
                {
                    UpdateUI("Error while uncompressing");

                    return;
                }
            }
            else
            {
                ExtractedPath = DownloadPath + "\\" + App.PackageName;
            }

            try
            {
                IsInstalled = SystemHelper.AppInstall(ExtractedPath, InstallPath, App, Parameters.IsOverwrite);
            }
            catch (Exception NewEx)
            {
                UpdateUI("Error while installation");

                return;
            }

            if (!IsInstalled) UpdateUI("Error while installation");
            else UpdateUI("Installed successfully");
        }

        private void DownloadingTimer_Tick(object sender, EventArgs e)
        {
            if (StatusBar.Value + 2 < StatusBar.Maximum) StatusBar.Value += 2;
            else StatusBar.Value = StatusBar.Minimum;

            /*
                if (ParamsHelper.IsThreadError)
                {
                    try
                    {
                        throw ParamsHelper.ThreadException;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Невозможно сохранить в " + ParamsHelper.DownloadPath + "\nВозможно программа должна быть\nзапущена от имени администратора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                    catch (NetCFLibFTP.FTPException NewEx)
                    {
                        if (NewEx.Message == "Method only valid with an open connection")
                        {
                            MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Невозможно сохранить в " + ParamsHelper.DownloadPath + "\nВыберите другую директорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                    catch (System.Net.Sockets.SocketException)
                    {
                        MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                    catch (Exception NewEx)
                    {
                        if (NewEx.Message == "InstallPath Empty")
                        {
                            MessageBox.Show("Отсутствует путь для установки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при установке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        }
                    }
            */
        }

        private void InstallMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BackMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}