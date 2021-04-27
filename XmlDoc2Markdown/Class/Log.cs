using System;
using System.IO;

namespace Atk.Lib
{
    class Log
    {
        private string path = string.Empty;
        private string sNameLog;
        private string className = "Log";

        public Log()
        {
            sNameLog = "Log_" + Common.DoTimeStamp("YMDHMS");
        }
        public Log(string Path)
        {
            path = Path;
            sNameLog = "Log_" + Common.DoTimeStamp("YMDHMS");
        }
        public void SetPath(string Path)
        {
            path = Path;
        }
        public void Debug(string text)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(className + ".Debug: Debe especificar la ruta.", new Exception(className + ".Debug: Debe pasar la ruta en el constructor o con el método SetPath."));
            }
            Directory.CreateDirectory(path);
            string sFullNameLog = path + "\\" + sNameLog + ".log";
            Common.StreamWriter(sFullNameLog, getMessage("DEBUG", text), true);
        }
        private string getMessage(string type, string text)
        {
            string sMessage = Common.DoTimeStamp();

            sMessage += " " + type + " : ";
            sMessage += (sMessage.IndexOf('[') == -1 || sMessage.IndexOf('(') == -1 ? "" : " - ") + text;
            return sMessage;
        }
    }
}
