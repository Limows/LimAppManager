using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using Microsoft.WindowsMobile.Configuration;

namespace LimAppManager
{
    class SystemHelper
    {
        /// <summary>
        /// Get list of installed apps
        /// </summary>
        /// <returns>List of installed apps</returns> 
        static public List<string> GetInstalledApps()
        {
            string SoftwareKey = "Software\\Apps";
            List<string> AppsList = new List<string>();

            using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {

                foreach (string appname in RegKey.GetSubKeyNames())
                {
                    if (appname != "Shared" && appname != "Microsoft Application Installer" && appname != "Customization Tools")
                    {
                        AppsList.Add(appname);
                    }
                }
            }

            return AppsList;
        }

        static public string GetInstallDir(string AppName)
        {
            string SoftwareKey = "Software\\Apps\\" + AppName;
            string InstallDir;

            using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                InstallDir = Convert.ToString(RegKey.GetValue("InstallDir", ""));   
            }

            return InstallDir;
        }

        static public void GetDebugInfo(out Parameters.DebugInfo Info)
        {
            Info = new Parameters.DebugInfo();

            Info.ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            Info.ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            Info.OSVersion = Parameters.OSVersion;
            Info.Cpu = "";
            Info.DeviceName = "";

        }

        static public bool AppInstall(string AppPath, string InstallPath, Parameters.InstallableApp App, bool Overwrite)
        {   
            bool IsInstalled = false;
            string[] Cabs;

            InstallPath = InstallPath + "\\" + App.Name;

            if (Directory.Exists(AppPath))
            {
                Cabs = Directory.GetFiles(AppPath, "*.cab");
            }
            else
            {
                Cabs = new string[1];

                Cabs[0] = AppPath;
            }

            if (Cabs.Length == 0)
            {
                IsInstalled = DirInstall(AppPath, InstallPath, App.Name, Overwrite);    
            }
            else
            {
                foreach (string cab in Cabs)
                {
                    IsInstalled = CabInstall(cab, InstallPath, Overwrite);
                }
            }

            if (IsInstalled)
            {
                WriteAppInfo(App, InstallPath);

                if (Parameters.IsRmPackage)
                {
                    try
                    {
                        if (Directory.Exists(AppPath))
                        {
                            Directory.Delete(AppPath, true);
                        }
                        else
                        {
                            File.Delete(AppPath);
                        }
                    }
                    catch
                    { }
                }
            }

            return IsInstalled;
        }

        static public void WriteAppInfo(Parameters.InstallableApp App, string InstallDir)
        {
            Parameters.InstalledApp InstalledApp = new Parameters.InstalledApp();

            InstalledApp.Author = App.Author;
            InstalledApp.InstallDate = DateTime.Now.Date.ToString("dd.MM.yy");
            InstalledApp.InstallDir = InstallDir;
            InstalledApp.Name = App.Name;
            InstalledApp.Version = App.Version;
        }

        static public bool CabInstall(string CabPath, string InstallPath, bool Overwrite)
        {   
            string ConsoleArguments = "/delete 0 /noaskdest";

            string SoftwareKey = "Software\\Apps\\Microsoft Application Installer";

            using (RegistryKey AppInstallerKey = Registry.LocalMachine.OpenSubKey(SoftwareKey, true))
            {   
                using (RegistryKey InstallKey = AppInstallerKey.CreateSubKey("Install"))
                {
                    if (InstallKey.ValueCount != 0)
                    {
                        InstallKey.Close();
                        AppInstallerKey.DeleteSubKey("Install");
                    }
                }

                using (RegistryKey InstallKey = AppInstallerKey.CreateSubKey("Install"))
                {
                    InstallKey.SetValue(CabPath, InstallPath);

                    Process InstallProc = new Process();
                    InstallProc.StartInfo.FileName = "\\windows\\wceload.exe";

                    InstallProc.StartInfo.Arguments = ConsoleArguments;// +"\"" + CabPath + "\"";

                    InstallProc.Start();

                    InstallProc.WaitForExit();

                    InstallKey.DeleteValue(CabPath);
                }
            }

            return true;
        }

        static public bool DirInstall(string DirPath, string InstallPath, string AppName, bool Overwrite)
        {
            string ShortcutName = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + "\\" + AppName + ".lnk";

            if (Directory.Exists(InstallPath))
            {
                if (Overwrite)
                {
                    Directory.Delete(InstallPath, true);
                    Directory.Move(DirPath, InstallPath);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Directory.Move(DirPath, InstallPath);   
            }

            string[] Execs = Directory.GetFiles(InstallPath, "*.exe");

            if (Execs.Length == 1)
            {
                CreateShortcut(ShortcutName, Execs[0], Overwrite);   
            }

            AddToRegistry(AppName, InstallPath, Execs);

            return true;

        }

        static private void CreateShortcut(string ShortcutName, string TargetName, bool Overwrite)
        {   
            FileInfo Shortcut = new FileInfo(ShortcutName);

            TextWriter Writer;

            if (!File.Exists(ShortcutName))
            {
                Writer = new StreamWriter(Shortcut.Open(FileMode.Create));
            }
            else
            {
                if (Overwrite)
                {
                    File.Delete(ShortcutName);
                    Writer = new StreamWriter(Shortcut.Open(FileMode.Create));
                }
                else
                {
                    return;
                }
            }

            Writer.Write(TargetName.Length + "#");
            Writer.WriteLine("\"" + TargetName + "\"");

            Writer.Close();
        }

        static private void DeleteShortcut(string ShortcutName)
        {
            File.Delete(ShortcutName);
        }

        static private void AddToRegistry(string AppName, string InstallPath, string[] ExecFiles)
        {
            string SoftwareKey = "Software\\Apps\\";

            using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey, true))
            {
                using (RegistryKey AppKey = RegKey.CreateSubKey(AppName))
                {
                    AppKey.SetValue("InstallDir", InstallPath);
                    AppKey.SetValue("Instl", 1);
                    AppKey.SetValue("InstlDir", InstallPath);
                }
            }

            if (Parameters.OSVersion == Parameters.OSVersions.WM5 || Parameters.OSVersion == Parameters.OSVersions.WM6)
            {

                SoftwareKey = "Security\\AppInstall\\";

                using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey, true))
                {
                    using (RegistryKey AppKey = RegKey.CreateSubKey(AppName))
                    {
                        AppKey.SetValue("InstallDir", InstallPath);
                        AppKey.SetValue("Role", 24);
                        //AppKey.SetValue("InstlDir", InstallPath);
                        using (RegistryKey ExecKey = AppKey.CreateSubKey("ExecutableFiles"))
                        {
                            foreach (string exec in ExecFiles)
                            {
                                ExecKey.SetValue(exec, "", 0);
                            }
                        }
                    }
                }
            }
        }

        static private void RemoveFromRegistry(string AppName)
        {
            string SoftwareKey = "Software\\Apps\\";

            using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey, true))
            {
                try
                {
                    RegKey.DeleteSubKey(AppName);
                }
                catch
                { }
            }

            if (Parameters.OSVersion == Parameters.OSVersions.WM5 || Parameters.OSVersion == Parameters.OSVersions.WM6)
            {

                SoftwareKey = "Security\\AppInstall\\";

                using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey, true))
                {
                    using (RegistryKey AppKey = RegKey.CreateSubKey(AppName))
                    {
                        AppKey.DeleteSubKey("ExecutableFiles");
                    }

                    RegKey.DeleteSubKey(AppName);
                }
            }
        }

        static private bool IsCabInstalled(string AppName)
        {
            if (Parameters.OSVersion == Parameters.OSVersions.WM5 || Parameters.OSVersion == Parameters.OSVersions.WM6)
            {
                string SoftwareKey = "Security\\AppInstall\\";

                using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey, true))
                {
                    using (RegistryKey AppKey = RegKey.CreateSubKey(AppName))
                    {
                        string UninstallPath = (string)AppKey.GetValue("Uninstall", String.Empty);

                        if (String.IsNullOrEmpty(UninstallPath)) return false;
                        else return true;
                    }
                }
            }
            else
            {
                string SoftwareKey = "Software\\Apps\\";

                using (RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(SoftwareKey, true))
                {
                    using (RegistryKey AppKey = RegKey.CreateSubKey(AppName))
                    {
                        string CabPath = (string)AppKey.GetValue("CabFile", String.Empty);

                        if (String.IsNullOrEmpty(CabPath)) return false;
                        else return true;
                    }
                }
            }
        }

        static public bool AppUninstall(string AppName)
        {
            if (IsCabInstalled(AppName))
            {
                try
                {
                    if (Parameters.OSVersion == Parameters.OSVersions.WM2003)
                    {
                        Process InstallProc = new Process();
                        Parameters.IsUninstalling = true;

                        InstallProc.StartInfo.FileName = "\\windows\\unload.exe";

                        InstallProc.StartInfo.Arguments = AppName;

                        InstallProc.Start();

                        InstallProc.WaitForExit();

                        RemoveFromRegistry(AppName);
                    }
                    else
                    {
                        XmlDocument UninstallData = new XmlDocument();

                        UninstallData.LoadXml("<wap-provisioningdoc>" +
                                        "<characteristic type=\"UnInstall\">" +
                                            "<characteristic type=\"" + AppName + "\">" +
                                                "<parm name=\"uninstall\" value=\"1\"/>" +
                                            "</characteristic>" +
                                        "</characteristic>" +
                                    "</wap-provisioningdoc>");

                        Microsoft.WindowsMobile.Configuration.ConfigurationManager.ProcessConfiguration(UninstallData, false);
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    string InstallDir = GetInstallDir(AppName);

                    Directory.Delete(InstallDir, true);

                    RemoveFromRegistry(AppName);

                    string ShortcutName = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + "\\" + AppName + ".lnk";

                    DeleteShortcut(ShortcutName);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
