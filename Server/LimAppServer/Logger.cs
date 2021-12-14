using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using System.IO;

namespace LimAppServer
{
    class Logger
    {
        public enum MessageLevel
        {
            Info,
            Warning,
            Error,
            Debug,
            Fatal
        }

        static public void Init(string LogPath)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug().WriteTo.File(Path.Combine(LogPath,
            @"server.log"), rollingInterval: RollingInterval.Day)
            .WriteTo.Console()
            .CreateLogger();
        }

        public static void LogMessage(string SystemMessage, MessageLevel Level)
        {
            if (!String.IsNullOrEmpty(SystemMessage))
            {
                switch (Level)
                {
                    case MessageLevel.Info:
                        Parameters.Logger.Information(SystemMessage);
                        break;
                    case MessageLevel.Warning:
                        Parameters.Logger.Warning(SystemMessage);
                        break;
                    case MessageLevel.Error:
                        Parameters.Logger.Error(SystemMessage);
                        break;
                    case MessageLevel.Debug:
                        Parameters.Logger.Debug(SystemMessage);
                        break;
                    case MessageLevel.Fatal:
                        Parameters.Logger.Fatal(SystemMessage);
                        break;
                }
            }
        }
    }
}
