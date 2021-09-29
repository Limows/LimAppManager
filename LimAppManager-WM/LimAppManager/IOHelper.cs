using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using IniParser;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;

namespace LimAppManager
{
    class IOHelper
    {
        public static void WriteSettings()
        {
            if (String.IsNullOrEmpty(Parameters.ConfigPath))
            {
                Parameters.ConfigPath = IOHelper.GetConfigPath();
            }

            var Parser = new FileIniDataParser();
            var Config = new IniParser.Model.IniData();

            Config["System"]["IconSize"] = Convert.ToString(Parameters.IconSize);
            Config["System"]["TempPath"] = Parameters.TempPath;
            Config["System"]["TempSize"] = Convert.ToString(Parameters.TempSize);
            Config["System"]["IsSendDebug"] = Parameters.IsSendDebug ? "true" : "false";

            Config["Install"]["IsAutoInstall"] = Parameters.IsAutoInstall ? "true" : "false";
            Config["Install"]["IsOverwrite"] = Parameters.IsOverwrite ? "true" : "false";
            Config["Install"]["IsRmPackage"] = Parameters.IsRmPackage ? "true" : "false";
            Config["Install"]["InstallPath"] = Parameters.InstallPath;

            Config["Download"]["DownloadPath"] = Parameters.DownloadPath;
            Config["Download"]["ServersPath"] = Parameters.ServersPath;
            Config["Download"]["Server"] = Parameters.Server;

            Parser.WriteFile(Parameters.ConfigPath, Config, Encoding.Default);
        }

        static private string GetConfigPath()
        {
            string[] ConfigFiles = Directory.GetFiles(GetCurrentDirectory(), "*.ini");

            if (ConfigFiles.Length == 0) 
            {
                FileStream Stream = File.Create(GetCurrentDirectory() + "\\Config.ini");
                Stream.Close();
                return GetCurrentDirectory() + "\\Config.ini";
            }

            return ConfigFiles[0];
        }

        /// <summary>
        /// Get current directory
        /// </summary>
        /// <returns>Current directory path</returns> 
        static public string GetCurrentDirectory()
        {
            string CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            return CurrentDirectory;
        }

        public static void ReadSettings()
        {   
            if (String.IsNullOrEmpty(Parameters.ConfigPath))
            {
                Parameters.ConfigPath = IOHelper.GetConfigPath();
            }

            var Parser = new FileIniDataParser();
            var Config = Parser.ReadFile(Parameters.ConfigPath);

            Parameters.IconSize = Convert.ToInt32(Config["System"]["IconSize"]);
            Parameters.TempPath = Config["System"]["TempPath"];
            Parameters.TempSize = Convert.ToUInt64(Config["System"]["TempSize"]);
            Parameters.IsSendDebug = (Config["System"]["IsSendDebug"] == "true");

            Parameters.IsAutoInstall = (Config["Install"]["IsAutoInstall"] == "true");
            Parameters.IsOverwrite = (Config["Install"]["IsOverwrite"] == "true");
            Parameters.IsRmPackage = (Config["Install"]["IsRmPackage"] == "true");
            Parameters.InstallPath = Config["Install"]["InstallPath"];

            Parameters.DownloadPath = Config["Download"]["DownloadPath"];
            Parameters.ServersPath = Config["Download"]["ServersPath"];
            Parameters.Server = Config["Download"]["Server"];

            if (!Directory.Exists(Parameters.TempPath)) Directory.CreateDirectory(Parameters.TempPath);
        }

        /// <summary>
        /// Extract zip archive to directory
        /// </summary>
        /// <param name="CompressedFilePath"></param>
        /// <param name="ExtractedFilePath"></param>
        /// <returns>Path to extracted archive</returns> 
        public static string ExtractToDirectory(string CompressedFilePath, string ExtractedFilePath)
        {
            bool IsDirectory = false;

            ZipFile Archive = new ZipFile(CompressedFilePath);

            foreach (ZipEntry entry in Archive)
            {
                if (entry.IsDirectory)
                {
                    IsDirectory = true;
                    break;
                }
            }

            FastZip ZipArc = new FastZip();
            ZipArc.CreateEmptyDirectories = true;

            ZipArc.ExtractZip(CompressedFilePath, ExtractedFilePath, null);

            Archive.Close();

            if (IsDirectory)
            {
                string[] Dirs = Directory.GetDirectories(ExtractedFilePath);
                return Dirs[0];
            }

            return ExtractedFilePath;
        }

        static public string ReadTextFile(string Path)
        {
            FileInfo File = new FileInfo(Path);

            using (TextReader Reader = new StreamReader(File.OpenRead()))
            {
                return Reader.ReadToEnd();
            }
        }

        static public void CleanBuffer()
        {
            Directory.Delete(Parameters.TempPath, true);
        }

        static public ulong GetDirectorySize(string Path)
        {
            ulong Size = 0;

            if (Directory.Exists(Path))
            {
                // Add file sizes.
                DirectoryInfo Dir = new DirectoryInfo(Path);
                FileInfo[] Files = Dir.GetFiles();

                foreach (FileInfo file in Files)
                {
                    Size += (ulong)file.Length;
                }

                // Add subdirectory sizes.
                DirectoryInfo[] Dirs = Dir.GetDirectories();

                foreach (DirectoryInfo dir in Dirs)
                {
                    Size += GetDirectorySize(dir.FullName);
                }

                return Size;
            }
            else
            {
                return 0;
            }
        }
    }
}
