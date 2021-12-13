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

                if (HttpRequest.HttpMethod == "POST")
                {
                    RequestData = "";

                    using (Stream Input = HttpRequest.InputStream)
                    {
                        using (StreamReader InputReader = new StreamReader(Input, Encoding.UTF8))
                        {
                            RequestInput = InputReader.ReadToEnd();
                        }
                    }

                    RequestFields = RequestInput.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                    switch (HttpRequest.Url.AbsolutePath)
                    {
                        case "/shutdown":
                            Console.WriteLine("Shutdown requested");

                            RequestResult = "Shutdown completed";
                            IsRun = false;
                            break;

                        case "/registration":
                            Console.WriteLine("Registration requested");

                            if (RequestFields.Length == 3)
                            {
                                if (CredentialsHelper.CreateRecord(RequestFields[0], RequestFields[1], RequestFields[2]))
                                {
                                    Console.WriteLine("Registration was successful");
                                    RequestResult = "Registration was successful";
                                }
                                else
                                {
                                    Console.WriteLine("Registration failed");
                                    RequestResult = "Registration failed";
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error in request body");
                                RequestResult = "Error in request body";
                            }

                            break;

                        case "/login":
                            Console.WriteLine("Login requested");

                            if (RequestFields.Length == 2)
                            {
                                if (CredentialsHelper.FindRecord("", ""))
                                {
                                    Console.WriteLine("Login was successful");
                                    RequestResult = "Login was successful";
                                    RequestData = CredentialsHelper.FetchRecord("", "");
                                    LoginsCount++;
                                }
                                else
                                {
                                    Console.WriteLine("Login failed");
                                    RequestResult = "Login failed";
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error in request body");
                                RequestResult = "Error in request body";
                            }

                            break;

                        case "/message":
                            Console.WriteLine("Send error mail requested");

                            await MailHelper.SendEmailAsync();
                            RequestResult = "Error message was sent";
                            Console.WriteLine("Error message was sent");
                            break;

                        case "/download":
                            Console.WriteLine("Download requested");

                            DownloadsCount++;
                            RequestResult = "Downloading app";
                            RequestData = RequestInput;
                            Console.WriteLine("Downloading app");
                            break;

                        case "/upload":
                            Console.WriteLine("Upload requested");

                            UploadsCount++;
                            MetaBuilderLib.Parameters.Package AppPackage = new MetaBuilderLib.Parameters.Package();
                            string Json = MetaInfo.GenerateMetaFile(AppPackage);
                            FileSystem.WriteMetaFile("Meta.json", Json);
                            RequestResult = "Upload completed";
                            Console.WriteLine("Upload completed");
                            break;
                    }
                }

                byte[] data = Encoding.UTF8.GetBytes(String.Format(PageData, RequestResult, RequestData));
                HttpResponse.ContentType = "text/html";
                HttpResponse.ContentEncoding = Encoding.UTF8;
                HttpResponse.ContentLength64 = data.LongLength;

                await HttpResponse.OutputStream.WriteAsync(data, 0, data.Length);
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