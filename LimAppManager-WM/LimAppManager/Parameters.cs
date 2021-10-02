using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace LimAppManager
{
    class Parameters
    {
        public static int IconSize = 100;
        public static Dictionary<string, Uri> AppsList;
        public static Dictionary<string, Uri> ServersList;
        public static List<string> InstalledList;
        public static string Server;
        static public string DownloadPath;
        static public string InstallPath;
        static public string ConfigPath;
        static public string TempPath;
        static public string ServersPath;
        static public int OSVersion;
        static public bool IsAutoInstall;
        static public bool IsRmPackage;
        static public bool IsOverwrite;
        static public bool IsUninstalling;
        static public bool IsSendDebug;
        static public ulong TempSize;
        static public bool IsSaveParams;

        /// <summary>
        /// Convert bytes to megabytes
        /// </summary>
        /// <param name="Bytes">Bytes</param>
        /// <returns>Megabytes</returns> 
        static public double BytesToMegs(ulong Bytes)
        {
            return ((double)Bytes / 1024) / 1024;
        }

        /// <summary>
        /// Convert megabytes to bytes
        /// </summary>
        /// <param name="Megs">Megs</param>
        /// <returns>Bytes</returns> 
        static public ulong MegsToBytes(double Megs)
        {
            return (ulong)(Megs * 1024 * 1024);
        }
    }
}
