using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace MetaBuilderLib
{
    public class FileSystem
    {
        static public string[] GetPackageList(string Path)
        {
            string[] PackageList;

            try
            {
                DirectoryInfo Dir = new DirectoryInfo(Path);
                PackageList = Directory.GetDirectories(Dir.FullName);
                return PackageList;
            }
            catch
            {
                return null;
            }
        }

        static public float GetPackageSize(string PackageDir, string Extension)
        {
            float Size;
            string Package;

            Package = GetFileName(PackageDir, "*." + Extension, true);
            Size = (float)(new FileInfo(Package).Length) / 1024 / 1024;

            return Size;
        }

        static protected string GetFileName(string PackageDir, string Pattern, bool Verbose)
        {
            string PackageFile;

            try
            {
                if (Verbose) PackageFile = Directory.GetFiles(PackageDir, Pattern)[0];
                else PackageFile = Directory.GetFiles(PackageDir, Pattern)[0].Split('\\').Last();
            }
            catch
            {
                PackageFile = "";
            }

            return PackageFile;
        }

        static public string GetPackageName(string PackageDir, string Extension)
        {
            return GetFileName(PackageDir, "*." + Extension, false);
        }

        static public bool CheckCompression(string PackageDir)
        {
            if (String.IsNullOrEmpty(GetFileName(PackageDir, "*.zip", true))) return false;
            else return true;
        }

        static public string GetIconName(string PackageDir)
        {
            return GetFileName(PackageDir, "*.ico", false);
        }

        static public string GetShotName(string PackageDir)
        {
            return GetFileName(PackageDir, "*.png", false);
        }

        static public string GetPackageSystem(string Path)
        {
            DirectoryInfo Dir = new DirectoryInfo(Path);
            return Dir.FullName.Split('\\').Last();
        }

        static public void WriteMetaFile(string PackageDir, string MetaInfo)
        {
            string FileName = PackageDir + "\\Meta.json";

            using (StreamWriter Writer = new StreamWriter(FileName, false, System.Text.Encoding.Default))
            {
                Writer.WriteLine(MetaInfo);
            }
        }
    }
}
