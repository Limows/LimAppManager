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

        public void GetAvailableApps(Uri ServerUri, string System)
        {
            Uri CurrentUri = new Uri(ServerUri.ToString() + @"files\" + System);

            StartTextResponse(CurrentUri, "GET", null, null);
        }

        public void GetAppMetaInfo(Uri AppUri)
        {
            Uri CurrentUri = new Uri(AppUri.ToString() + "Meta.json");

            StartTextResponse(CurrentUri, "GET", null, null);
        }

        private void StartTextResponse(Uri ServerUri, string Method, string ContentType, string Message)
        {
            Request = (HttpWebRequest)WebRequest.Create(ServerUri);
            Request.Method = Method;

            if (Method == "POST")
            {
                byte[] Data = System.Text.Encoding.UTF8.GetBytes(Message);
                Request.ContentType = ContentType;
                Request.ContentLength = Data.Length;

                using (Stream dataStream = Request.GetRequestStream())
                {
                    dataStream.Write(Data, 0, Data.Length);
                }
            }

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

        private void StartDataResponse(Uri ServerUri, string Method, string ContentType, byte[] Data)
        {
            Request = (HttpWebRequest)WebRequest.Create(ServerUri);
            Request.Method = Method;

            if (Method == "POST")
            {
                Request.ContentType = ContentType;
                Request.ContentLength = Data.Length;

                using (Stream dataStream = Request.GetRequestStream())
                {
                    dataStream.Write(Data, 0, Data.Length);
                }
            }

            Request.BeginGetResponse(EndDataResponse, null);
        }

        private void EndDataResponse(IAsyncResult result)
        {   
            int RecievedBytes = 0;
            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)Request.EndGetResponse(result);

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
            catch
            {
                Parameters.EndResponseEvent.Set();
                return;
            }

            Parameters.EndResponseEvent.Set();
            return;
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
