using System;
using System.Threading;

namespace WindowsServiceTemplate
{
    /// <summary>
    /// Example service, rename and modify it to suit your needs
    /// </summary>
    public class TestService
    {
        private readonly Thread t;
        public TestService()
        {
            t = new Thread(doWork);
        }

        public void Start()
        {
            t.Start();
        }
        public void Stop()
        {
            t.Abort();
        }


        private void doWork()
        {
            int i = Config.StartFrom;
            while (true)
            {
                Log.Info("Ping " + i);
                i++;

                Thread.Sleep(1000);
            }
        }


    }
}