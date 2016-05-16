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
            Logger.Info("Start event");
            s.Start();
        }

        protected override void OnStop()
        {
            Logger.Info("Stop event");
            s.Stop();
        }

        protected override void OnShutdown()
        {
            Logger.Info("Windows is going shutdown");
            Stop();
        }


        public void Start()
        {
            OnStart(null);
        }
    }
}
