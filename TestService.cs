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
    public partial class TestService : ServiceBase
    {
        public TestService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            throw new NotImplementedException();
        }

        protected override void OnStop()
        {
            throw new NotImplementedException();
        }

        protected override void OnShutdown()
        {
            Stop();
        }


        public void Start()
        {
            OnStart(null);
        }
    }
}
