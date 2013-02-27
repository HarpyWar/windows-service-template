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
            Log.Debug("Start event");
            s.Start();
        }

        protected override void OnStop()
        {
            Log.Debug("Stop event");
            s.Stop();
        }

        protected override void OnShutdown()
        {
            Log.Debug("Windows is going shutdown");
            this.Stop();
        }


        public void Start()
        {
            this.OnStart(null);
        }
    }
}
