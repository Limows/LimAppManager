using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace LimAppServer
{
    class Program
    {     
        public static void Main(string[] args)
        {
            HttpServer Server;

            Console.WriteLine("Welcome to server program for LimAppManager");
            Console.WriteLine("Server is now starting up...");
            Console.WriteLine("Init logger...");

            Logger.Init(IOHelper.GetCurrentDirectory());

            Logger.LogMessage("Logger was initialized", Logger.MessageLevel.Info);

            try
            {
                IOHelper.ReadSettings();
            }
            catch
            {
                Logger.LogMessage("Error while reading settings", Logger.MessageLevel.Fatal);
                return;
            }
            
            if (!String.IsNullOrEmpty(Parameters.Uri))
            {
                try
                {
                    Server = new HttpServer(Parameters.Uri);

                    Logger.LogMessage("Running main handler", Logger.MessageLevel.Info);

                    Task ListenTask = Server.HandleIncomingConnections();
                    ListenTask.GetAwaiter().GetResult();
                }
                catch
                {
                    Logger.LogMessage("Insufficient access rights. Run as Admin, please", Logger.MessageLevel.Warning);
                }
            }
            else
            {
                Logger.LogMessage("Url not specified", Logger.MessageLevel.Fatal);
            }

            try
            {
                IOHelper.WriteSettings();
            }
            catch
            {
                Logger.LogMessage("Error while writing settings", Logger.MessageLevel.Fatal);
            }

            Console.WriteLine("Goodbye...");
        }
    }
}