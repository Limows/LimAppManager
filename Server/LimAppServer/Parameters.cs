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
        static public int Requests;
        static public int Views;
        static public int Logins;
        static public int Downloads;
        static public int Uploads;
        static public string ConfigPath;
        public static readonly ILogger Logger = Log.ForContext<Program>();
    }
}