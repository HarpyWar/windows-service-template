using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsServiceTemplate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            // console mode
            if (Environment.UserInteractive)
            {
                Console.WriteLine("Console mode");
                Console.Read();
            }
            // service mode
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                    {
                        new Service1()
                    };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
