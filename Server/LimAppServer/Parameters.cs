using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using Serilog;

namespace LimAppServer
{
    public class Parameters
    {
        static public string Uri;
        static public int Requests = 0;
        static public int Views = 0;
        static public int Logins = 0;
        static public int Downloads = 0;
        static public int Uploads = 0;
        static public string ConfigPath;
        public static readonly ILogger Logger = Log.ForContext<Program>();
    }
}