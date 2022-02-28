using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using IniParser;
using System.IO.Compression;
using System.Threading.Tasks;

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

            Config["Net"]["Uri"] = "http://192.168.1.73:8080/";
            Config["Stat"]["Requests"] = Convert.ToString(Parameters.Requests);
            Config["Stat"]["Views"] = Convert.ToString(Parameters.Views);
            Config["Stat"]["Logins"] = Convert.ToString(Parameters.Logins);
            Config["Stat"]["Uploads"] = Convert.ToString(Parameters.Uploads);
            Config["Stat"]["Downloads"] = Convert.ToString(Parameters.Downloads);

            Parser.WriteFile(Parameters.ConfigPath, Config, Encoding.Default);
        }

        static private string GetConfigPath()
        {
            string[] ConfigFiles = Directory.GetFiles(GetCurrentDirectory(), "*.ini");

            if (ConfigFiles.Length == 0) 
            {
                FileStream Stream = File.Create(GetCurrentDirectory() + "\\Config.ini");
                Stream.Close();
                throw new Exception();
            }

            return ConfigFiles[0];
        }

        /// <summary>
        /// Get current directory
        /// </summary>
        /// <returns>Current directory path</returns> 
        static public string GetCurrentDirectory()
        {
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string path = Directory.GetCurrentDirectory();
            return path;
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
            Parameters.Views = Convert.ToInt32(Config["Stat"]["Views"]);
            Parameters.Logins = Convert.ToInt32(Config["Stat"]["Logins"]);
            Parameters.Uploads = Convert.ToInt32(Config["Stat"]["Uploads"]);
            Parameters.Downloads = Convert.ToInt32(Config["Stat"]["Downloads"]);
        }

        public static async Task SaveStat()
        {
            while (true)
            {
                Thread.Sleep(1000 * 60);

                WriteSettings();
            }
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
