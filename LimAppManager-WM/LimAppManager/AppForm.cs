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
        private string AppName;

        public AppForm(string CurrentAppName)
        {
            InitializeComponent();

            AppName = CurrentAppName;
            this.Text = AppName;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            //Parameters.CurrentURI = Parameters.AppURI;

            if (!String.IsNullOrEmpty(Parameters.DownloadPath))
            {
                //ThreadStart DownloadingStarter = delegate { DownloadingThreadWorker(Parameters.CurrentURI, Parameters.DownloadPath, ParamsHelper.InstallPath, AppName); };
                //Thread DownloadingThread = new Thread(DownloadingStarter);
                //Parameters.IsThreadAlive = true;
                //Parameters.IsThreadError = false;
                //ParamsHelper.ThreadMessage = "";

                //DownloadingThread.Start();

                //StatusLabel.Text = Parameters.ThreadMessage;

                DownloadingTimer.Enabled = true;
                InstallButton.Visible = false;
                StatusBar.Visible = true;
                StatusBar.Value = StatusBar.Minimum;
                StatusLabel.Left = InstallButton.Left;
                LowerPanel.Height = StatusBar.Bottom;
            }
            else
            {
                MessageBox.Show("Отсутствует путь для сохранения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            DownloadingTimer.Enabled = false;
            DownloadingTimer.Interval = 100;

            LogoBox.Width = LogoBox.Height;
            StatusLabel.Text = "";
            DescriptionBox.Text = "";
            StatusBar.Visible = false;
            LowerPanel.Height = StatusBar.Top;

            Cursor.Current = Cursors.Default;
        }

        private void AppForm_FormClosing(object sender, CancelEventArgs e)
        {

        }

        private void DownloadingThreadWorker(Uri CurrentURI, string DownloadPath, string InstallPath, string AppName)
        {
            /*
             string FileName = AppName + ".zip";
             bool IsInstalled = false;

             ParamsHelper.ThreadMessage = "Идёт загрузка";

             try
             {
                 NetHelper.DownloadFile(CurrentURI, DownloadPath, FileName);
             }
             catch(Exception NewEx)
             {
                 ParamsHelper.ThreadException = NewEx;
                 ParamsHelper.IsThreadAlive = false;
                 ParamsHelper.IsThreadError = true;
                 ParamsHelper.ThreadMessage = "Ошибка при загрузке";
                 return;
             }

             ParamsHelper.IsThreadWaiting = true;
             ParamsHelper.ThreadMessage = "Успешно загружено";

             while (ParamsHelper.IsThreadWaiting)
             {

             }

             if (ParamsHelper.ThreadMessage == "Yes")
             {   
                 ParamsHelper.ThreadMessage = "Идёт распаковка";

                 string ExtractedPath;

                 try
                 {
                     ExtractedPath = IOHelper.ExtractToDirectory(DownloadPath + "\\" + FileName, DownloadPath + "\\" + AppName);
                 }
                 catch(Exception NewEx)
                 {
                     ParamsHelper.ThreadException = NewEx;
                     ParamsHelper.IsThreadAlive = false;
                     ParamsHelper.IsThreadError = true;
                     ParamsHelper.ThreadMessage = "Ошибка при распаковке";
                     return;
                 }

                 ParamsHelper.ThreadMessage = "Успешно распаковано";

                 if (!String.IsNullOrEmpty(InstallPath))
                 {   
                     ParamsHelper.ThreadMessage = "Идёт установка";

                     try
                     {
                         IsInstalled = SystemHelper.AppInstall(ExtractedPath, InstallPath, AppName, ParamsHelper.IsOverwrite);
                     }
                     catch(Exception NewEx)
                     {
                         ParamsHelper.ThreadException = NewEx;
                         ParamsHelper.IsThreadAlive = false;
                         ParamsHelper.IsThreadError = true;
                         ParamsHelper.ThreadMessage = "Ошибка при установке";
                         return;  
                     }

                     if (IsInstalled) ParamsHelper.ThreadMessage = "Успешно установлено";
                     else ParamsHelper.ThreadMessage = "Ошибка при установке";
                 }
                 else
                 {
                     ParamsHelper.ThreadException = new Exception("InstallPath Empty");
                     ParamsHelper.IsThreadAlive = false;
                     ParamsHelper.IsThreadError = true;
                     ParamsHelper.ThreadMessage = "Ошибка при установке";
                     return;  
                 }

             }

             ParamsHelper.CurrentURI = ParamsHelper.AppURI;
             ParamsHelper.IsThreadAlive = false;
             */
        }

        private void DownloadingTimer_Tick(object sender, EventArgs e)
        {
            /*
            if (!ParamsHelper.IsThreadAlive)
            {
                try
                {
                    DownloadingTimer.Enabled = false;
                    DownloadButton.Visible = true;
                    StatusBar.Visible = false;
                    StatusLabel.Width = 142;
                    StatusLabel.Left = 90;
                    DescriptionBox.Top = 100;
                    StatusLabel.Text = ParamsHelper.ThreadMessage;

                    if (this.Width == 480)
                    {
                        StatusLabel.Left = 180;
                        DescriptionBox.Top = 200;
                    }
                    else
                    {
                        StatusLabel.Left = 90;
                        DescriptionBox.Top = 100;
                    }
                }
                catch
                { }

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

                }

            }
            else
            {
                StatusLabel.Text = ParamsHelper.ThreadMessage;

                if (StatusBar.Value + 2 < StatusBar.Maximum) StatusBar.Value += 2;
                else StatusBar.Value = StatusBar.Minimum;

                if (ParamsHelper.IsThreadWaiting)
                {
                    DownloadingTimer.Enabled = false;
                    if (!ParamsHelper.IsAutoInstall)
                    {
                        DialogResult Result = MessageBox.Show("Установить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (Result == DialogResult.Yes)
                        {
                            ParamsHelper.ThreadMessage = "Yes";
                        }
                    }
                    else
                    {
                        ParamsHelper.ThreadMessage = "Yes";
                    }

                    DownloadingTimer.Enabled = true;
                    //Parameters.IsThreadWaiting = false;
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