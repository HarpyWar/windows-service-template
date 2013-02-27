using System.Configuration.Install;
using System.Reflection;

namespace WindowsServiceTemplate
{
    class ServiceInstallerUtility
    {
        private static readonly string exePath =
          Assembly.GetExecutingAssembly().Location;
        public static bool InstallMe()
        {
            try { ManagedInstallerClass.InstallHelper(new[] { "/LogFile=", exePath }); }
            catch { return false; }
            return true;
        }
        public static bool UninstallMe()
        {
            try { ManagedInstallerClass.InstallHelper(new[] { "/LogFile=", "/u", exePath }); }
            catch { return false; }
            return true;
        }
    }
}
