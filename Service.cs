using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsServiceTemplate
{
    public partial class Service : ServiceBase
    {
        private readonly TestService s;
        public Service()
        {
            InitializeComponent();
            s = new TestService();
        }

        protected override void OnStart(string[] args)
        {
            s.Start();
        }

        protected override void OnStop()
        {
            s.Stop();
        }

        protected override void OnShutdown()
        {
            this.Stop();
        }


        public void Start()
        {
            this.OnStart(null);
        }
    }
}
