using System.ServiceProcess;
using NLog;

namespace WindowsServiceTemplate
{
    public partial class Service : ServiceBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly TestService s;
        public Service()
        {
            InitializeComponent();
            s = new TestService();
        }

        protected override void OnStart(string[] args)
        {
            Logger.Debug("Start event");
            s.Start();
        }

        protected override void OnStop()
        {
            Logger.Debug("Stop event");
            s.Stop();
        }

        protected override void OnShutdown()
        {
            Logger.Debug("Windows is going shutdown");
            Stop();
        }


        public void Start()
        {
            OnStart(null);
        }
    }
}
