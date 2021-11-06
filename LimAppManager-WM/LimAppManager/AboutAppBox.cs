using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace LimAppManager
{
    public partial class AboutAppBox : Form
    {
        private Parameters.InstalledApp App;

        public AboutAppBox(string AppName)
        {
            InitializeComponent();

            App = SystemHelper.ReadAppInfo(AppName);

            this.Text = String.Format("About {0}", AppTitle);
            this.labelProductName.Text = AppTitle;
            this.labelVersion.Text = String.Format("Version: {0}", AppVersion);
            this.labelCompanyName.Text = String.Format("Author: {0}", AppCompany);
            this.labelInstallDate.Text = String.Format("Install date: {0}", AppInstallDate);
            this.textBoxInstallPath.Text = String.Format("Install path: {0}", AppInstallPath);
        }

        public string AppVersion
        {
            get
            {
                if (!String.IsNullOrEmpty(App.Version))
                {
                    return App.Version;
                }
                else
                {
                    return "1.0.0";
                }
            }
        }

        public string AppInstallPath
        {
            get
            {
                if (!String.IsNullOrEmpty(App.InstallDir))
                {
                    return App.InstallDir;
                }
                else
                {
                    return SystemHelper.GetInstallDir(App.FullName);
                }
            }
        }

        public string AppTitle
        {
            get
            {
                if (!String.IsNullOrEmpty(App.Name))
                {
                    return App.Name;
                }
                else
                {
                    string AppName = SystemHelper.GetInstallDir(App.FullName).Split('\\')[SystemHelper.GetInstallDir(App.FullName).Split('\\').Length - 1];

                    if (String.IsNullOrEmpty(AppTitle)) return "\\";
                    else return AppTitle;
                }
            }
        }

        public string AppCompany
        {
            get
            {
                if (!String.IsNullOrEmpty(App.Author))
                {
                    return App.Author;
                }
                else
                {
                    return App.FullName.Replace(AppTitle, String.Empty);
                }
            }
        }

        public string AppInstallDate
        {
            get
            {
                if (!String.IsNullOrEmpty(App.InstallDate))
                {
                    return App.InstallDate;
                }
                else
                {
                    return Directory.GetLastWriteTime(AppInstallPath).ToString("dd.MM.yy");
                }
            }
        }

        private void OkMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}