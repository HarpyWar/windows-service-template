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

        #region Service Properties (you can be freely change it)

        private string DisplayName
        {
            get
            {
                var friendlyName = AppDomain.CurrentDomain.FriendlyName;
                return friendlyName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ?
                                    friendlyName.Substring(0, friendlyName.Length - 4) :
                                    friendlyName;
            }
        }

        private string ServiceName
        {
            get
            {
                return DisplayName;
            }
        }

        private string Description
        {
            get
            {
                return DisplayName;
            }
        }

        #endregion


        protected override void OnBeforeInstall(IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);

            serviceInstaller1.DisplayName = DisplayName;
            serviceInstaller1.ServiceName = ServiceName;
            serviceInstaller1.Description = Description;
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);

            serviceInstaller1.DisplayName = DisplayName;
            serviceInstaller1.ServiceName = ServiceName;
            serviceInstaller1.Description = Description;
        }
    }
}