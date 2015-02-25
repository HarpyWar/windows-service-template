using System;
using System.Collections;
using System.ComponentModel;

namespace WindowsServiceTemplate
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
        }

        private string GetName()
        {
            var friendlyName = AppDomain.CurrentDomain.FriendlyName;
            return friendlyName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ?
                                friendlyName.Substring(0, friendlyName.Length - 4) :
                                friendlyName;
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);

            // set service name
            var name = GetName();
            serviceInstaller1.DisplayName = name;
            serviceInstaller1.ServiceName = name;
            serviceInstaller1.Description = name;
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);

            // set service name
            var name = GetName();
            serviceInstaller1.DisplayName = name;
            serviceInstaller1.ServiceName = name;
            serviceInstaller1.Description = name;
        }
    }
}