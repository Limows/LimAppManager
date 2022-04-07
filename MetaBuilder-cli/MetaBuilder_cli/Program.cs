using System;
using System.IO;
using System.Linq;
using MetaBuilderLib;

namespace MetaBuilder_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Platforms Systems = new Platforms();
            string[] PackageList;
            string DirPath = "";
            bool IsRecursive = false;
            bool IsSetPath = false;
            bool IsInteractive = false;

            Console.WriteLine("Hello! This is a package processing program for Limowski App Manager\n");

            foreach (string argument in args)
            {   
                switch(argument)
                {
                    case "-r":
                        IsRecursive = true;
                        break;
                    case "-i":
                        IsInteractive = true;
                        break;
                    case "-d":
                        IsSetPath = true;
                        break;
                    default:
                        if (IsSetPath)
                        {
                            DirPath = argument;
                            IsSetPath = false;
                        }
                        break;
                }
            }

            if (!String.IsNullOrEmpty(DirPath))
            {
                if (IsRecursive)
                {
                    Console.WriteLine("Searching for packages\n");

                    PackageList = FileSystem.GetPackageList(DirPath);

                    if (PackageList != null)
                    {
                        if (PackageList.Length > 0)
                        {
                            foreach (string package in PackageList)
                            {
                                MetaInfo.Package Package = new MetaInfo.Package();
                                string Meta;


                                Console.WriteLine("Found package " + package.Split(Path.DirectorySeparatorChar).Last() + "\n");

                                Package.System = FileSystem.GetPackageSystem(DirPath);

                                Package.PackageName = FileSystem.GetPackageName(package, "zip");
                                foreach (string extension in Systems.SystemExtensions[Package.System])
                                {   
                                    if (String.IsNullOrEmpty(Package.PackageName))
                                        Package.PackageName = FileSystem.GetPackageName(package, extension);
                                }

                                if (String.IsNullOrEmpty(Package.PackageName))
                                {
                                    Console.WriteLine("Wrong package, skip...\n");
                                }
                                else
                                {
                                    Package.IsCompressed = FileSystem.CheckCompression(package);

                                    Package.Name = package.Split(Path.DirectorySeparatorChar).Last().Replace("_", " ");

                                    Package.IconName = FileSystem.GetIconName(package);

                                    Package.ShotName = FileSystem.GetShotName(package);

                                    if (Package.IsCompressed) 
                                        Package.Size = FileSystem.GetPackageSize(package, "zip");
                                    else
                                        foreach (string extension in Systems.SystemExtensions[Package.System])
                                        {
                                            Package.Size = FileSystem.GetPackageSize(package, extension);
                                        }

                                    using (FileStream File = new FileStream(package + Path.DirectorySeparatorChar + Package.PackageName, FileMode.Open))
                                    {
                                        byte[] bytes = new byte[File.Length];
                                        int length = (int)File.Length;
                                        int offset = 0;

                                        while (length > 0)
                                        {
                                            int n = File.Read(bytes, offset, length);

                                            if (n == 0)
                                                break;

                                            offset += n;
                                            length -= n;
                                        }

                                        Package.Hash = Hash.GetMD5Hash(bytes);
                                    }

                                    Console.Write("Enter package version: ");
                                    Package.Version = Console.ReadLine();

                                    Console.Write("Enter package description: ");
                                    Package.Description = Console.ReadLine();

                                    Console.Write("Enter package origin: ");
                                    Package.Origin = Console.ReadLine();

                                    Console.Write("Enter your name or nickname: ");
                                    Package.Maintainer = Console.ReadLine();

                                    Meta = MetaInfo.GenerateMetaFile(Package);
                                    FileSystem.WriteMetaFile(package, Meta);
                                    Console.Write("\nMeta-info created!\n");
                                }
                            }
                        }
                        else Console.WriteLine("No packages found\n");
                    }
                    else Console.WriteLine("Path not found\n");
                }
                else
                {
                    if (IsInteractive)
                    {
                        MetaInfo.Package Package = new MetaInfo.Package();
                        string Meta;

                        Console.Write("Enter package platform: ");
                        Package.System = Console.ReadLine();

                        Package.PackageName = FileSystem.GetPackageName(DirPath, "zip");
                        foreach (string extension in Systems.SystemExtensions[Package.System])
                        {
                            if (String.IsNullOrEmpty(Package.PackageName))
                                Package.PackageName = FileSystem.GetPackageName(DirPath, extension);
                        }

                        if (String.IsNullOrEmpty(Package.PackageName))
                        {
                            Console.WriteLine("Wrong package, skip...\n");
                        }
                        else
                        {
                            Package.IsCompressed = FileSystem.CheckCompression(DirPath);

                            Package.Name = DirPath.Split(Path.DirectorySeparatorChar).Last().Replace("_", " ");

                            Package.IconName = FileSystem.GetIconName(DirPath);

                            Package.ShotName = FileSystem.GetShotName(DirPath);

                            if (Package.IsCompressed)
                                Package.Size = FileSystem.GetPackageSize(DirPath, "zip");
                            else
                                foreach (string extension in Systems.SystemExtensions[Package.System])
                                {
                                    if (Package.Size != 0)
                                        Package.Size = FileSystem.GetPackageSize(DirPath, extension);
                                }

                            using (FileStream File = new FileStream(DirPath + Path.DirectorySeparatorChar + Package.PackageName, FileMode.Open))
                            {
                                byte[] bytes = new byte[File.Length];
                                int length = (int)File.Length;
                                int offset = 0;

                                while (length > 0)
                                {
                                    int n = File.Read(bytes, offset, length);

                                    if (n == 0)
                                        break;

                                    offset += n;
                                    length -= n;
                                }

                                Package.Hash = Hash.GetMD5Hash(bytes);
                            }

                            Console.Write("Enter package version: ");
                            Package.Version = Console.ReadLine();

                            Console.Write("Enter package description: ");
                            Package.Description = Console.ReadLine();

                            Console.Write("Enter package origin: ");
                            Package.Origin = Console.ReadLine();

                            Console.Write("Enter your name or nickname: ");
                            Package.Maintainer = Console.ReadLine();

                            Meta = MetaInfo.GenerateMetaFile(Package);
                            FileSystem.WriteMetaFile(DirPath, Meta);
                            Console.Write("\nMeta-info created!\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Only interactive mode now implemented\n");
                        PrintManual();
                    }
                }
            }
            else
            {
                Console.WriteLine("Missing path!\n");
                PrintManual();
            }
        }

        static void PrintManual()
        {
            Console.WriteLine("Help:\n");
            Console.WriteLine("-r - Recursive, if you want to process all your packages\n");
            Console.WriteLine("-d - Use this parameter to set path\n");
            Console.WriteLine("-i - Runs interactive mode\n");
        }
    }
}
