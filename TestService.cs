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
            while (true)
            {
                Console.WriteLine("ping");
                // do some work

                Thread.Sleep(1000);
            }
        }


    }
}