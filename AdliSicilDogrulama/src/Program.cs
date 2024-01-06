using System.Linq;
using System.Threading;

namespace AdliSicilDogrulama
{
    //Auhor : Tarık Aydın
    //CreationDate : December, 2023
    //Description: Selenium ile E-Devlet Belge Doğrulama sayfasına bağlanarak adayların Adli Sicil Belgelerini Kontrol Eden Console App
    internal class Program
    {
        static void Main(string[] args)
        {
            DogrulamaService.Initialize(args.Contains("chrome=true"));
            Thread thread = new Thread(DogrulamaService.RequestBekle);
            thread.Start();
            HttpServer.Start();
            System.Console.WriteLine("Adli Sicil Kaydı Doğrulama Servisi\nRequest Bekleniyor..");

            if (args.Contains("sms=true"))
                SmsLogger.SendSmsTest();
        }
    }
}

