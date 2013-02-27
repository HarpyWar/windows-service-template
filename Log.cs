using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsServiceTemplate
{
    /// <summary>
    /// Simple logger to file
    /// </summary>
    static class Log
    {
        public static void Error(string text)
        {
            Write(String.Format("[{0}] [ERROR] {1}\n", DateTime.Now, text));
        }

        public static void Info(string text)
        {
            Write(String.Format("[{0}] [INFO] {1}\n", DateTime.Now, text));
        }

        public static void Debug(string text)
        {
#if DEBUG
            Write(String.Format("[{0}] [DEBUG] {1}\n", DateTime.Now, text));
#endif
        }

        // write to log
        static void Write(string text)
        {
            try
            {
                using (StreamWriter w = File.AppendText(Config.LogFile))
                    w.Write(text);

                if (Environment.UserInteractive)
                    Console.Write(text);
            }
            catch (Exception)
            {
                Console.WriteLine("Can't write to log " + Config.LogFile);
            }
        }
    }
}
