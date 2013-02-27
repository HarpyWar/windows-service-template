using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace WindowsServiceTemplate
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
        }


        protected override void OnBeforeInstall(System.Collections.IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);

            // set service name
            this.serviceInstaller1.DisplayName = Config.DisplayName;
            this.serviceInstaller1.ServiceName = Config.ServiceName;
            this.serviceInstaller1.Description = Config.Description;
        }

        protected override void OnBeforeUninstall(System.Collections.IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);

            // set service name
            this.serviceInstaller1.DisplayName = Config.DisplayName;
            this.serviceInstaller1.ServiceName = Config.ServiceName;
            this.serviceInstaller1.Description = Config.Description;
        }
    }
}