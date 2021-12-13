using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using IniParser;
using System.IO.Compression;

namespace LimAppServer
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

            Config["Net"]["Uri"] = "limowski.xyz";
            Config["Stat"]["Requests"] = Convert.ToString(0);

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

        static public bool FindFile(string Directory, string FileName)
        {
            return File.Exists(Directory + FileName);
        }

        static public void ReadSettings()
        {   
            if (String.IsNullOrEmpty(Parameters.ConfigPath))
            {
                Parameters.ConfigPath = IOHelper.GetConfigPath();
            }

            var Parser = new FileIniDataParser();
            var Config = Parser.ReadFile(Parameters.ConfigPath);

            Parameters.Uri = Config["Net"]["Uri"];
            Parameters.Requests = Convert.ToInt32(Config["Stat"]["Requests"]);
        }

        static public string ReadTextFile(string Path)
        {
            FileInfo File = new FileInfo(Path);

            using (TextReader Reader = new StreamReader(File.OpenRead()))
            {
                return Reader.ReadToEnd();
            }
        }
    }
}
