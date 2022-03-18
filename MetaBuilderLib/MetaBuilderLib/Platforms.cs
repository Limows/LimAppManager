using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaBuilderLib
{
    public class Platforms
    {
        public Dictionary<string, List<string>> SystemExtensions;

        public Platforms()
        {
            List<string> Extensions = new List<string>();
            SystemExtensions = new Dictionary<string, List<string>>();

            Extensions.Add("apk");
            SystemExtensions.Add("Android_API1", Extensions);

            Extensions = new List<string>();
            Extensions.Add("apk");
            SystemExtensions.Add("Android_API3", Extensions);

            Extensions = new List<string>();
            Extensions.Add("apk");
            SystemExtensions.Add("Android_API9", Extensions);

            Extensions = new List<string>();
            Extensions.Add("apk");
            SystemExtensions.Add("Android_API12", Extensions);

            Extensions = new List<string>();
            Extensions.Add("sis");
            SystemExtensions.Add("S60v2", Extensions);

            Extensions = new List<string>();
            Extensions.Add("sis");
            Extensions.Add("sisx");
            SystemExtensions.Add("S60v3", Extensions);

            Extensions = new List<string>();
            Extensions.Add("sis");
            SystemExtensions.Add("S80", Extensions);

            Extensions = new List<string>();
            Extensions.Add("sis");
            SystemExtensions.Add("S90", Extensions);

            Extensions = new List<string>();
            Extensions.Add("sis");
            SystemExtensions.Add("UIQ2", Extensions);

            Extensions = new List<string>();
            Extensions.Add("sis");
            SystemExtensions.Add("UIQ3", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinMobile_2002", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinMobile_2003", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinMobile_5", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinMobile_Smartphone", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinCE_2", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinCE_3", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinCE_4", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinCE_5", Extensions);

            Extensions = new List<string>();
            Extensions.Add("cab");
            SystemExtensions.Add("WinCE_6", Extensions);
        }
    }
}
