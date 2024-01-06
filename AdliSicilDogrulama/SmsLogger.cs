using System;
using System.Configuration;
using System.Net;

namespace AdliSicilDogrulama
{
    public static class SmsLogger
    {
        public static bool _smsGonderildi;
        private static string _smsApiUrl;
        private static string _smsApiKey;

        static SmsLogger()
        {
            _smsGonderildi = false;
            _smsApiUrl = ConfigurationManager.AppSettings.Get("SmsApiUrl");
            _smsApiKey = ConfigurationManager.AppSettings.Get("SmsApiKey");
        }

        public static void SendSms(DateTime tarih)
        {
            try
            {
                if (!_smsGonderildi)
                {
                    string phoneNumbers = ConfigurationManager.AppSettings.Get("SmsNotification_NumberList");
                    string message = string.Format("{0} tarihinde Adli Sicil Doğrulama servisinde hata oluştu.", tarih.ToString("yyyy-MM-dd HH:mm:ss"));

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/api/SmsNotification/SmsGonder?numara={1}&mesaj={2}", _smsApiUrl, phoneNumbers, message));
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.ContentLength = 0;
                    httpWebRequest.Method = "GET";
                    httpWebRequest.Headers.Add("apikey", _smsApiKey);
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpResponse.Close();
                    httpResponse.Dispose();

                    _smsGonderildi = true;
                }
            }
            catch { }
        }

        public static void SendSmsTest()
        {
            try
            {
                string phoneNumbers = ConfigurationManager.AppSettings.Get("SmsNotification_NumberList");
                string message = string.Format("{0} Adli Sicil Doğrulama SMS Testi", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/api/SmsNotification/SmsGonder?numara={1}&mesaj={2}", _smsApiUrl, phoneNumbers, message));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = 0;
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("apikey", _smsApiKey);
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                httpResponse.Close();
                httpResponse.Dispose();
            }
            catch { }
        }

    }
}
