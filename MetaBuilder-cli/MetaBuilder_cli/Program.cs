using System;
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
            string Path = "";
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
                            Path = argument;
                            IsSetPath = false;
                        }
                        break;
                }
            }

            if (!String.IsNullOrEmpty(Path))
            {
                if (IsRecursive)
                {
                    Console.WriteLine("Searching for packages\n");

                    PackageList = FileSystem.GetPackageList(Path);

                    if (PackageList != null)
                    {
                        if (PackageList.Length > 0)
                        {
                            foreach (string package in PackageList)
                            {
                                MetaInfo.Package Package = new MetaInfo.Package();
                                string Meta;


                                Console.WriteLine("Found package " + package.Split("\\").Last() + "\n");

                                Package.System = FileSystem.GetPackageSystem(Path);

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

                                    Package.Name = Path.Split(@"/").Last().Replace("_", " ");

                                    Package.IconName = FileSystem.GetIconName(package);

                                    Package.ShotName = FileSystem.GetShotName(package);

                                    if (Package.IsCompressed) 
                                        Package.Size = FileSystem.GetPackageSize(package, "zip");
                                    else
                                        foreach (string extension in Systems.SystemExtensions[Package.System])
                                        {
                                            Package.Size = FileSystem.GetPackageSize(package, extension);
                                        }

                                    //Package.Hash = Hash.GetMD5Hash()

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

                        Package.PackageName = FileSystem.GetPackageName(Path, "zip");
                        foreach (string extension in Systems.SystemExtensions[Package.System])
                        {
                            if (String.IsNullOrEmpty(Package.PackageName))
                                Package.PackageName = FileSystem.GetPackageName(Path, extension);
                        }

                        if (String.IsNullOrEmpty(Package.PackageName))
                        {
                            Console.WriteLine("Wrong package, skip...\n");
                        }
                        else
                        {
                            Package.IsCompressed = FileSystem.CheckCompression(Path);

                            Package.Name = Path.Split(@"/").Last().Replace("_", " ");

                            Package.IconName = FileSystem.GetIconName(Path);

                            Package.ShotName = FileSystem.GetShotName(Path);

                            if (Package.IsCompressed)
                                Package.Size = FileSystem.GetPackageSize(Path, "zip");
                            else
                                foreach (string extension in Systems.SystemExtensions[Package.System])
                                {
                                    Package.Size = FileSystem.GetPackageSize(Path, extension);
                                }

                            //Package.Hash = Hash.GetMD5Hash()

                            Console.Write("Enter package version: ");
                            Package.Version = Console.ReadLine();

                            Console.Write("Enter package description: ");
                            Package.Description = Console.ReadLine();

                            Console.Write("Enter package origin: ");
                            Package.Origin = Console.ReadLine();

                            Console.Write("Enter your name or nickname: ");
                            Package.Maintainer = Console.ReadLine();

                            Meta = MetaInfo.GenerateMetaFile(Package);
                            FileSystem.WriteMetaFile(Path, Meta);
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
