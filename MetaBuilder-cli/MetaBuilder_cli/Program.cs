using System;
using System.Linq;
using MetaBuilderLib;

namespace LimAppGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] PackageList;

            Console.WriteLine("Hello! This is a package processing program for Limowski App Manager\n");

            Console.WriteLine("Searching for packages");

            PackageList = FileSystem.GetPackageList();

            if (PackageList.Length > 0)
            {
                foreach (string package in PackageList)
                {
                    Parameters.Package Package = new Parameters.Package();
                    string Meta;


                    Console.WriteLine("\nFound package " + package.Split("\\").Last() + "\n");

                    Package.PackageName = FileSystem.GetPackageName(package, "zip");

                    if (String.IsNullOrEmpty(Package.PackageName))
                    {
                        Console.WriteLine("Wrong package, skip...\n");
                    }
                    else
                    {
                        Package.Name = package.Split("\\").Last();

                        Package.IconName = FileSystem.GetIconName(package);

                        Package.ShotName = FileSystem.GetShotName(package);

                        Package.System = FileSystem.GetPackageSystem();

                        Package.Size = FileSystem.GetPackageSize(package, "zip");

                        Console.Write("Enter package version: ");
                        Package.Version = Console.ReadLine();

                        Console.Write("Enter package origin: ");
                        Package.Origin = Console.ReadLine();

                        Console.Write("Enter your name or nickname: ");
                        Package.Maintainer = Console.ReadLine();

                        Meta = MetaInfo.GenerateMetaFile(Package);
                        FileSystem.WriteMetaFile(package, Meta);
                    }
                }
            }
            else Console.WriteLine("\nNo packages found\n");
        }
    }
}
