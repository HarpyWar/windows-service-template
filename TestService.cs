using System;
using System.Threading;
using NLog;

namespace WindowsServiceTemplate
{
    /// <summary>
    /// Example service, rename and modify it to suit your needs
    /// </summary>
    public class TestService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly Thread _thread;
        public TestService()
        {
            _thread = new Thread(DoWork);
        }

        public void Start()
        {
            _thread.Start();
        }
        public void Stop()
        {
            _thread.Abort();
        }


        private void DoWork()
        {
            var i = AppSettings.StartFrom;
            while (true)
            {
                Logger.Debug("Ping " + i);
                i++;

                Thread.Sleep(1000);
            }
// ReSharper disable once FunctionNeverReturns
        }


    }
}