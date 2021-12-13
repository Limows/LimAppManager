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

            try
            {
                IOHelper.ReadSettings();
            }
            catch
            {
                Console.WriteLine("Error while reading settings");
                return;
            }
            
            if (String.IsNullOrEmpty(Parameters.Uri))
            {
                Server = new HttpServer(Parameters.Uri);

                Task ListenTask = Server.HandleIncomingConnections();
                ListenTask.GetAwaiter().GetResult();
            }
            else
            {
                Console.WriteLine("Url not specified");
            }
        }
    }
}