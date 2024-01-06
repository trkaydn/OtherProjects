using System;
using System.IO;
using System.Linq;

namespace AdliSicilDogrulama
{
    static class TxtLogger
    {
        private static DirectoryInfo _directoryInfo;

        static TxtLogger()
        {
            _directoryInfo = new DirectoryInfo(string.Format("{0}\\files\\", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
        }

        public static void Write(string logMessage, DateTime errorDate)
        {
            try
            {
                string fileFolder = "";
                var file = _directoryInfo.GetFiles("log_*.txt").OrderByDescending(x => x.CreationTime).FirstOrDefault();

                if (file != null && file.Length <= 20000000)
                    fileFolder = file.FullName;
                else
                    fileFolder = _directoryInfo.FullName + "\\log_" + errorDate.ToString("yyyy-MM-dd HH-mm-ss") + ".txt";

                using (StreamWriter w = File.AppendText(fileFolder))
                {
                    w.WriteLine("{0} : {1}", errorDate.ToString("yyyy-MM-dd HH:mm:ss"), logMessage);
                    w.WriteLine("-------------------------------");
                }

                DeleteOldFiles();
            }
            catch { }
        }

        private static void DeleteOldFiles()
        {
            try
            {
                var files = _directoryInfo.GetFiles("log_*.txt").Where(x => x.CreationTime.Date <= DateTime.Now.AddDays(-10).Date);
                files.ToList().ForEach(x => x.Delete());
            }
            catch { }
        }
    }
}
