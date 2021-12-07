using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MetaBuilderLib
{
    class MetaInfo
    {
        public static string GenerateMetaFile(Parameters.Package Package)
        {
            string Meta;

            if (String.IsNullOrEmpty(Package.Version)) Package.Version = "1.0";
            if (String.IsNullOrEmpty(Package.Origin)) Package.Origin = "None";
            if (String.IsNullOrEmpty(Package.Maintainer)) Package.Maintainer = "None";

            Meta = JsonConvert.SerializeObject(Package);

            return Meta;
        }
    }
}
