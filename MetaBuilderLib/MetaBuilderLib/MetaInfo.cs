using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MetaBuilderLib
{
    public class MetaInfo
    {
        public struct Package
        {
            public string System;
            public string Name;
            public string PackageName;
            public string Description;
            public bool IsCompressed;
            public string Hash;
            public string IconName;
            public string ShotName;
            public float Size;
            public string Maintainer;
            public string Origin;
            public string Version;
        }

        public static string GenerateMetaFile(Package Package)
        {
            string Meta;

            if (String.IsNullOrEmpty(Package.Version)) Package.Version = "1.0";
            if (String.IsNullOrEmpty(Package.Origin)) Package.Origin = "None";
            if (String.IsNullOrEmpty(Package.Maintainer)) Package.Maintainer = "None";
            if (String.IsNullOrEmpty(Package.Description)) Package.Description = "";
            if (String.IsNullOrEmpty(Package.Hash)) Package.Hash = "";

            Meta = JsonConvert.SerializeObject(Package);

            return Meta;
        }
    }
}
