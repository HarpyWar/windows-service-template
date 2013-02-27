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
        static void Main(string[] args)
        {
            // self service installer/uninstaller
            if (args != null && args.Length == 1
                && (args[0][0] == '-' || args[0][0] == '/'))
            {
                switch (args[0].Substring(1).ToLower())
                {
                    case "install":
                    case "i":
                        if (!ServiceInstallerUtility.InstallMe())
                            Console.WriteLine("Failed to install service");
                        break;
                    case "uninstall":
                    case "u":
                        if (!ServiceInstallerUtility.UninstallMe())
                            Console.WriteLine("Failed to uninstall service");
                        break;
                    default:
                        Console.WriteLine("Unrecognized parameters.");
                        break;
                }
                Environment.Exit(0);
            }


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
