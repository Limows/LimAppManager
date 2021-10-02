using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinMobileNetCFExt;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace LimAppManager
{
    class NetHelper
    {
        static public Dictionary<string, Uri> GetAvailableApps(Uri ServerUri)
        {
            Dictionary<string, Uri> AppsList = new Dictionary<string, Uri>();
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(ServerUri);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            string ResponseMessage;

            using (StreamReader stream = new StreamReader(Response.GetResponseStream(), Encoding.UTF8))
            {
                ResponseMessage = stream.ReadToEnd();
            }

            string[] Lines = ResponseMessage.Split('\n');

            foreach (string line in Lines)
            {
                string[] AppLine = line.Split('=');

                AppsList.Add(AppLine[0], new Uri(AppLine[1]));
            }

            return AppsList;
        }

        static public string CheckUpdates()
        {
            Uri URI = new Uri("http://limowski.xyz:80/downloads/LimFTPClient/WinMobile/LimFTPClientVersion.txt");
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URI);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            string ResponseMessage;

            using (StreamReader stream = new StreamReader(Response.GetResponseStream(), Encoding.UTF8))
            {
                ResponseMessage = stream.ReadToEnd();
                ResponseMessage = ResponseMessage.Replace("\n", "");
            }

            return ResponseMessage;
        }

        static public void GetUpdates(string Version)
        {
            Uri URI = new Uri("http://limowski.xyz:80/downloads/LimFTPClient/WinMobile/LimFTPClient.cab");
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URI);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();

            using (FileStream UpdateFile = new FileStream(Parameters.DownloadPath + "\\Update.cab", FileMode.Create, FileAccess.Write))
            {
                using (BinaryReader Reader = new BinaryReader(Response.GetResponseStream()))
                {
                    int BufSize = 2048;
                    byte[] Buffer = new byte[BufSize];
                    int Count = 0;

                    while ((Count = Reader.Read(Buffer, 0, BufSize)) > 0)
                    {
                        UpdateFile.Write(Buffer, 0, Count);
                    }
                }
            }
        }
    }
}
