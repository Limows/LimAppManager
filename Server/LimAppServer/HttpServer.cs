using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using MetaBuilderLib;

namespace LimAppServer
{
    class HttpServer
    {
        HttpListener Listener;
        string Url;
        int RequestsCount;
        int ViewsCount;
        int LoginsCount;
        int DownloadsCount;
        int UploadsCount;
        string PageData = "Request completed, result: {0}, data: {1}";
        string RequestResult;
        string RequestData;
        string RequestInput = "";
        string[] RequestFields;
        string ResponseString;

        public HttpServer(string NewUrl)
        {
            Url = NewUrl;
            Listener = new HttpListener();
            Listener.Prefixes.Add(Url);
            Listener.Start();

            RequestsCount = 0;
            ViewsCount = 0;
            LoginsCount = 0;
            DownloadsCount = 0;
            UploadsCount = 0;
        }

        ~HttpServer()
        {
            Listener.Close();
        }

        public async Task HandleIncomingConnections()
        {
            bool IsRun = true;

            while (IsRun)
            {
                HttpListenerContext Context = await Listener.GetContextAsync();
                HttpListenerRequest HttpRequest = Context.Request;
                HttpListenerResponse HttpResponse = Context.Response;

                RequestsCount++;

                RequestData = "";

                using (Stream Input = HttpRequest.InputStream)
                {
                    using (StreamReader InputReader = new StreamReader(Input, Encoding.UTF8))
                    {
                        RequestInput = InputReader.ReadToEnd();
                    }
                }

                switch (HttpRequest.HttpMethod)
                {
                    case "OPTIONS":
                        {

                            HttpResponse.StatusCode = 204;
                            HttpResponse.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, X-Requested-With");
                            HttpResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                            HttpResponse.AddHeader("Access-Control-Max-Age", "1728000");

                            break;
                        }

                    case "POST":
                        {

                            RequestFields = RequestInput.Split('&', StringSplitOptions.RemoveEmptyEntries);

                            switch (HttpRequest.Url.AbsolutePath)
                            {
                                case "/shutdown":
                                    Logger.LogMessage("Shutdown requested", Logger.MessageLevel.Debug);

                                    RequestResult = "Shutdown completed";
                                    IsRun = false;
                                    break;

                                case "/registration":
                                    Logger.LogMessage("Registration requested", Logger.MessageLevel.Debug);

                                    if (RequestFields.Length == 3)
                                    {
                                        if (CredentialsHelper.CreateRecord(CredentialsHelper.GetMD5Hash(RequestFields[0]),
                                                                           CredentialsHelper.GetMD5Hash(RequestFields[1]),
                                                                           CredentialsHelper.GetMD5Hash(RequestFields[2])))

                                        {
                                            Logger.LogMessage("Registration was successful", Logger.MessageLevel.Info);
                                            RequestResult = "Registration was successful";
                                        }
                                        else
                                        {
                                            Logger.LogMessage("Registration failed", Logger.MessageLevel.Error);
                                            RequestResult = "Registration failed";
                                        }
                                    }
                                    else
                                    {
                                        Logger.LogMessage("Error in request body", Logger.MessageLevel.Error);
                                        RequestResult = "Error in request body";
                                    }

                                    break;

                                case "/login":
                                    Logger.LogMessage("Login requested", Logger.MessageLevel.Debug);

                                    if (RequestFields.Length == 2)
                                    {
                                        if (CredentialsHelper.FindRecord("", ""))
                                        {
                                            Logger.LogMessage("Login was successful", Logger.MessageLevel.Info);
                                            RequestResult = "Login was successful";
                                            RequestData = CredentialsHelper.FetchRecord("", "");
                                            LoginsCount++;
                                        }
                                        else
                                        {
                                            Logger.LogMessage("Login failed", Logger.MessageLevel.Error);
                                            RequestResult = "Login failed";
                                        }
                                    }
                                    else
                                    {
                                        Logger.LogMessage("Error in request body", Logger.MessageLevel.Error);
                                        RequestResult = "Error in request body";
                                    }

                                    break;

                                case "/message":
                                    Logger.LogMessage("Send error mail requested", Logger.MessageLevel.Debug);

                                    await MailHelper.SendEmailAsync();
                                    RequestResult = "Error message was sent";
                                    Logger.LogMessage("Error message was sent", Logger.MessageLevel.Info);
                                    break;

                                case "/download":
                                    Logger.LogMessage("Download requested", Logger.MessageLevel.Debug);

                                    DownloadsCount++;
                                    RequestResult = "Downloading app";
                                    RequestData = RequestInput;
                                    Logger.LogMessage("Downloading app", Logger.MessageLevel.Info);
                                    break;

                                case "/upload":
                                    Logger.LogMessage("Upload requested", Logger.MessageLevel.Debug);

                                    UploadsCount++;

                                    if (RequestFields.Length == 2)
                                    {
                                        try
                                        {
                                            MetaBuilderLib.Parameters.Package AppPackage = new MetaBuilderLib.Parameters.Package();

                                            AppPackage.System = RequestFields[0];
                                            AppPackage.Name = RequestFields[1];
                                            AppPackage.PackageName = FileSystem.GetPackageName("temp", ".cab");
                                            AppPackage.Description = RequestFields[2];
                                            AppPackage.IsCompressed = FileSystem.CheckCompression("temp");
                                            AppPackage.Hash = Hash.GetMD5Hash(AppPackage.PackageName);
                                            AppPackage.IconName = FileSystem.GetIconName("temp");
                                            AppPackage.ShotName = FileSystem.GetShotName("temp");
                                            AppPackage.Size = FileSystem.GetPackageSize("temp", ".cab");
                                            AppPackage.Maintainer = RequestFields[3];
                                            AppPackage.Origin = RequestFields[4];
                                            AppPackage.Version = RequestFields[5];

                                            string Json = MetaInfo.GenerateMetaFile(AppPackage);
                                            FileSystem.WriteMetaFile("Meta.json", Json);
                                            RequestResult = "Upload completed";
                                            RequestData = AppPackage.Name;
                                            Logger.LogMessage("Upload completed", Logger.MessageLevel.Info);
                                        }
                                        catch
                                        {
                                            RequestResult = "Upload failed";
                                            Logger.LogMessage("Upload failed", Logger.MessageLevel.Error);
                                        }
                                    }
                                    else
                                    {
                                        Logger.LogMessage("Error in request body", Logger.MessageLevel.Error);
                                        RequestResult = "Error in request body";
                                    }

                                    break;
                            }

                            ResponseString = String.Format(PageData, RequestResult, RequestData);

                            break;
                        }
                }

                HttpResponse.AppendHeader("Access-Control-Allow-Origin", "*");

                byte[] data;

                if (!String.IsNullOrEmpty(ResponseString))
                {
                    data = Encoding.UTF8.GetBytes(ResponseString);
                    HttpResponse.ContentEncoding = Encoding.UTF8;
                    HttpResponse.ContentLength64 = data.LongLength;
                    await HttpResponse.OutputStream.WriteAsync(data, 0, data.Length);
                }
                else
                {
                    data = null;
                }

                HttpResponse.Close();
            }
        }

        public int Views
        {
            get
            {
                return ViewsCount;
            }
        }

        public int Requests
        {
            get
            {
                return RequestsCount;
            }
        }

        public int Logins
        {
            get
            {
                return LoginsCount;
            }
        }

        public int Downloads
        {
            get
            {
                return DownloadsCount;
            }
        }

        public int Uploads
        {
            get
            {
                return UploadsCount;
            }
        }

        public string CurrentUrl
        {
            get
            {
                return Url;
            }
        }
    }
}