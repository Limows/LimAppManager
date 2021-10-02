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
        HttpWebRequest Request;

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

        public void StartTextResponse(Uri ServerUri)
        {
            Request = (HttpWebRequest)WebRequest.Create(ServerUri);
            Request.BeginGetResponse(EndTextResponse, null);
        }

        private void EndTextResponse(IAsyncResult result)
        {
            HttpWebResponse Response; 
            string ResponseMessage;

            try
            {
                Response = (HttpWebResponse)Request.EndGetResponse(result);
            }
            catch
            {
                Parameters.EndResponseEvent.Set();
                return;
            }

            using (StreamReader stream = new StreamReader(Response.GetResponseStream(), Encoding.UTF8))
            {
                ResponseMessage = stream.ReadToEnd();
            }

            Parameters.ResponseMessage = ResponseMessage;
            Parameters.EndResponseEvent.Set();
            return;
        }

        private void EndDataResponse(IAsyncResult state)
        {   
            /*
            int recievedBytes = 0;
            Socket socket = (Socket)state.AsyncState;
            BinaryWriter Writer = new BinaryWriter(m_data);

            try
            {
                recievedBytes = socket.EndReceive(state);
                Writer.Write(m_buffer, 0, recievedBytes);
                Writer.Flush();
                //m_data.Write(m_buffer, 0, recievedBytes);
                //dirInfo.Append(Encoding.ASCII.GetString(m_buffer, 0, recievedBytes));
            }
            catch
            {
                FTPParameters.EndResponseEvent.Set();
                Writer.Flush();
                return;
            }

            if (recievedBytes > 0)
            {
                socket.BeginReceive(m_buffer, 0, m_buffer.Length, 0, EndDataResponse, socket);
            }
            else
            {
                FTPParameters.EndResponseEvent.Set();
                Writer.Flush();
            }
            */
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
