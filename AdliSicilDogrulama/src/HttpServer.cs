using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace AdliSicilDogrulama
{
    public static class HttpServer
    {
        private static HttpListener _listener = new HttpListener();
        public static sbyte _dogrulaRequest = 0;

        public static void Start()
        {
            _listener.Prefixes.Add(ConfigurationManager.AppSettings.Get("serviceUrl"));
            _listener.Start();
            _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        }

        private static void ListenerCallback(IAsyncResult result)
        {
            try
            {
                HttpListener listener = (HttpListener)result.AsyncState;
                listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                if (request.Url.AbsolutePath != "/favicon.ico")
                    _dogrulaRequest = 1;

                byte[] page = Encoding.UTF8.GetBytes("OK");
                Stream output = response.OutputStream;
                output.Write(page, 0, page.Length);
                output.Close();
            }
            catch { }
        }
    }
}
