using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;


namespace AdliSicilDogrulama
{
    public static class DogrulamaService
    {
        private static ChromeOptions _options;
        private static Regex _dateRegex;
        private static CultureInfo _cultureInfo;
        private static Random _random;
        private static string _downloadPath = string.Format("{0}\\files\\", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        private static byte _belgeTipi = 1; //adli sicil belgesi

        public static void Initialize(bool showBrowser = false)
        {
            _dateRegex = new Regex(@"(\d{2}[\./]\d{2}[\./]\d{4})");
            _cultureInfo = new CultureInfo("tr-TR");
            _random = new Random();
            _options = new ChromeOptions();
            _options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            _options.AddUserProfilePreference("download.default_directory", _downloadPath);
            _options.AddArgument("log-level=3");
            _options.AddArgument("--disable-dev-shm-usage");
            _options.AddArgument("--test-type");
            _options.AddArgument("--disable-gpu");
            _options.AddArgument("--no-sandbox");
            _options.AddArgument("--disable-software-rasterizer");
            _options.AddArgument("--disable-popup-blocking");
            _options.AddArgument("--disable-extensions");
            _options.AddArgument("--window-size=1920,1080");
            _options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            _options.AddUserProfilePreference("download.prompt_for_download", false);
            _options.AddUserProfilePreference("plugins.plugins_disabled", "Chrome PDF Viewer");
            if (!showBrowser) _options.AddArgument("--headless=new");

            if (!Directory.Exists(_downloadPath))
                Directory.CreateDirectory(_downloadPath);
        }

        private static void Dogrula(ChromeDriver driver, GBAK.bb.SP.service_belgedogrulama_get_rtn value)
        {
            Console.Clear();
            Console.WriteLine("Adli Sicil Kaydı Doğrulama Servisi\nDoğrulama Yapılıyor..");

            byte belgeDurum = 2; //Onaysız belge
            DateTime belgeTarih = DateTime.Now;
            string pdfPath = _downloadPath + value.barkodno + ".pdf";
            string pdfText = "";

            try
            {
                #region e-devlet request
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                driver.Url = "https://www.turkiye.gov.tr/belge-dogrulama"; //sayfaya git
                var barkodInput = driver.FindElement(By.Id("sorgulananBarkod"));
                barkodInput.Clear();
                barkodInput.SendKeys(value.barkodno + Keys.Return); //barkod no doldur

                TimeSpan now = DateTime.Now.AddSeconds(5).TimeOfDay;
                while (driver.FindElements(By.Id("ikinciAlan")).Count == 0)
                {
                    if (DateTime.Now.TimeOfDay > now)
                        throw new Exception("BarkodNoHatali");
                }

                var tcInput = driver.FindElement(By.Id("ikinciAlan"));
                tcInput.Clear();
                tcInput.SendKeys(value.tckimlikno + Keys.Return); // tc no doldur

                if (driver.FindElements(By.ClassName("errorContainer")).Count > 0)
                    throw new Exception("TcNoHatali");

                wait.Until(drv => drv.PageSource.Contains("chkOnay")); //check alanının gelmesini bekle

                var checkInput = driver.FindElement(By.Id("chkOnay"));
                if (!checkInput.Selected)
                    checkInput.Click(); //onay checkbox'u doldur

                driver.FindElement(By.Name("mainForm")).Submit(); //formu submit et     
                driver.FindElement(By.ClassName("download")).Click(); //pdf'i indir
                wait.Timeout = TimeSpan.FromSeconds(60);
                wait.Until(drv => File.Exists(pdfPath)); //pdf dosyası inene kadar bekle


                using (PdfReader reader = new PdfReader(pdfPath))
                {
                    StringWriter text = new StringWriter(_cultureInfo);
                    text.WriteLine(PdfTextExtractor.GetTextFromPage(reader, 1));
                    pdfText = text.ToString();
                }
                #endregion

                #region belge onaylama
                belgeTarih = Convert.ToDateTime(_dateRegex.Match(pdfText).Value, _cultureInfo);

                if (belgeTarih.Date >= DateTime.Now.AddDays(-1).Date)
                {
                    if (pdfText.Contains("ADLİ SİCİL KAYDI YOKTUR"))
                        belgeDurum = 1; //Onaylı
                    else
                        belgeDurum = 2; //Onaysız
                }
                else
                    belgeDurum = 3; //Belge Tarihi Geçmiş
                #endregion

            }
            catch (Exception ex)
            {
                belgeDurum = 4; //Onaylanırken Hata Oluştu

                //barkod no ya da TC no hatalı değilse, başka bir sıkıntı vardır. Log ve SMS at.
                if (ex.Message != "BarkodNoHatali" && ex.Message != "TcNoHatali")
                {
                    DateTime errorTime = DateTime.Now;
                    TxtLogger.Write(ex.Message, errorTime);

                    if (!SmsLogger._smsGonderildi)
                        SmsLogger.SendSms(errorTime);
                }
            }

            finally
            {
                using (var bb = new GBAK.bb())
                {
                    bb.Exec.service_belgedogrulama_set(value.id, value.pid, belgeDurum, belgeTarih, _belgeTipi);
                }

                if (File.Exists(pdfPath)) File.Delete(pdfPath);
            }
        }

        private static void TumunuDogrula()
        {
            using (var bb = new GBAK.bb())
            {
                var result = bb.Exec.service_belgedogrulama_get(_belgeTipi);
                if (result.rtn.Count > 0)
                {
                    using (var driver = new ChromeDriver(_options)) //toplu gelen istekleri tek chromeDriver üzerinden yap.
                    {
                        for (var i = 0; i < result.rtn.Count; i++)
                        {
                            Dogrula(driver, result.rtn[i]);
                            Thread.Sleep(_random.Next(3000, 6000));
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Adli Sicil Kaydı Doğrulama Servisi\nRequest Bekleniyor..");
            }
        }

        public static void RequestBekle()
        {
            while (true)
            {
                if (HttpServer._dogrulaRequest > 0)
                {
                    HttpServer._dogrulaRequest = -1;
                    TumunuDogrula();
                }
                else
                    Thread.Sleep(5000);
            }
        }
    }
}
