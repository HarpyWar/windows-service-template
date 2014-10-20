using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;

namespace WindowsServiceTemplate
{
    static class Program
    {
        private static Service service;

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
                        Console.WriteLine("Unrecognized parameters (allowed: /install or /uninstall)");
                        break;
                }
                Environment.Exit(0);
            }

            service = new Service();
            ServiceBase[] servicesToRun = new ServiceBase[] { service };

            // console mode
            if (Environment.UserInteractive)
            {
                // register console close event
                _consoleHandler = new ConsoleCtrlHandlerDelegate(ConsoleEventHandler);
                SetConsoleCtrlHandler(_consoleHandler, true);

                Console.Title = Config.DisplayName;

                Log.Debug("Running in a console mode");
                service.Start();

                Console.WriteLine("Press any key to stop the service...");
                Console.Read();

                service.Stop();
            }
            // service mode
            else
            {
                Log.Debug("Running in a service mode");
                ServiceBase.Run(servicesToRun);
            }
        }




        #region Page Event Setup
        enum ConsoleCtrlHandlerCode : uint
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
        delegate bool ConsoleCtrlHandlerDelegate(ConsoleCtrlHandlerCode eventCode);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerDelegate handlerProc, bool add);
        static ConsoleCtrlHandlerDelegate _consoleHandler;
        #endregion

        #region Page Events
        static bool ConsoleEventHandler(ConsoleCtrlHandlerCode eventCode)
        {
            // Handle close event here...
            switch (eventCode)
            {
                case ConsoleCtrlHandlerCode.CTRL_C_EVENT:
                case ConsoleCtrlHandlerCode.CTRL_CLOSE_EVENT:
                case ConsoleCtrlHandlerCode.CTRL_BREAK_EVENT:
                case ConsoleCtrlHandlerCode.CTRL_LOGOFF_EVENT:
                case ConsoleCtrlHandlerCode.CTRL_SHUTDOWN_EVENT:

                    service.Stop();

                    Environment.Exit(0);
                    break;
            }

            return (false);
        }
        #endregion
    }
}
