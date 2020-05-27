
using DotNet_Automation.Helper;
using System;
using System.IO;
using System.Text;

namespace DotNet_Automation.Helper
{
    public sealed class Logger : ILog

    {

        string logFilePath;

        private Logger()
        {
            string subdir = AppDomain.CurrentDomain.BaseDirectory+"\\Logs";
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            logFilePath = string.Format(@"{0}\{1}", subdir, string.Format("AutomationTestLogs_" + DateTime.Now.ToString("HHmmss") + ".log"));

        }

        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

        public static Logger GetInstance

        {
            get
            {
                return instance.Value;
            }
        }

        public void LogException(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {

                writer.WriteLine("Exception : " + DateTime.Now.ToString() + " : " + message);
                writer.Flush();
            }
        }

        public void LogInfo(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {

                writer.WriteLine("Info : " + DateTime.Now.ToString() + " : " + message);
                writer.Flush();
            }
        }
    }
}