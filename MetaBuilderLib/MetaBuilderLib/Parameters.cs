using System;
using System.Collections.Generic;
using System.Text;

namespace MetaBuilderLib
{
    public class Parameters
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
    }
}
