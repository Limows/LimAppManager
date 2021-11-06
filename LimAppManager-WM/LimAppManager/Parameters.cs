using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;

namespace LimAppManager
{
    public class Parameters
    {
        public static int IconSize = 100;
        public static Dictionary<string, Uri> AppsList;
        public static Dictionary<string, Uri> ServersList;
        public static List<string> InstalledList;
        public static string Server;
        public static string DownloadPath;
        public static string InstallPath;
        public static string ConfigPath;
        public static string TempPath;
        public static string ServersPath;
        public static OSVersions OSVersion;
        public static bool IsAutoInstall;
        public static bool IsRmPackage;
        public static bool IsOverwrite;
        public static bool IsUninstalling;
        public static bool IsSendDebug;
        public static ulong TempSize;
        public static bool IsSaveParams;
        public static string ResponseMessage;
        public static AutoResetEvent EndResponseEvent;
        public static DebugInfo SysInfo;

        public struct InstalledApp
        {
            public string Name;
            public string Author;
            public string FullName;
            public string Version;
            public string InstallDir;
            public string InstallDate;
        }

        public struct InstallableApp
        {

            public string Name;
            public string Author;
            public string Version;
            public double Size;
            public bool IsCompressed;
            public string PackageName;
            public string IconName;
        }

        public struct DebugInfo
        {
            public int ScreenWidth;
            public int ScreenHeight;
            public string Cpu;
            public string DeviceName;
            public double RamSize;
            public double DriveSpace;
            public OSVersions OSVersion;
        }

        public enum OSVersions
        {
            WM2003 = 42,
            WM5 = 51,
            WM6 = 52,
            CE4 = 4,
            CE5 = 5,
            CE6 = 6
        }

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
