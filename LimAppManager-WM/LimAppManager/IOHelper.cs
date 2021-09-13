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

        }

        static private string GetConfigPath()
        {
            string[] ConfigFiles = Directory.GetFiles(GetCurrentDirectory(), "*.ini");

            return ConfigFiles[0];
        }

        /// <summary>
        /// Get current directory
        /// </summary>
        /// <returns>Current directory path</returns> 
        static public string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        public static void ReadSettings()
        {
            if (String.IsNullOrEmpty(Parameters.ConfigPath))
            {
                Parameters.ConfigPath = IOHelper.GetConfigPath();
            }

            var Parser = new FileIniDataParser();
            var Config = Parser.ReadFile(Parameters.ConfigPath);
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
            DirectoryInfo Directory = new DirectoryInfo(Path);

            if (Directory.Exists)
            {
                // Add file sizes.
                FileInfo[] Files = Directory.GetFiles();

                foreach (FileInfo file in Files)
                {
                    Size += (ulong)file.Length;
                }

                // Add subdirectory sizes.
                DirectoryInfo[] Directories = Directory.GetDirectories();

                foreach (DirectoryInfo directory in Directories)
                {
                    Size += GetDirectorySize(directory.FullName);
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
