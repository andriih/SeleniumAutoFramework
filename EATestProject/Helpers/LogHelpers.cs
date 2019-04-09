using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    public class LogHelpers
    {
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}",DateTime.Now );
        public static StreamWriter _streamw = null;

        public static void CreateLogFile()
        {
            string dir = @"C:\Users\andrii.hnatyshyn\Desktop\SeleniumAutoFramework";

            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        public static void Write(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongDateString());
            _streamw.Write(" {0}",logMessage);
            _streamw.Flush();
        }

    }
}
