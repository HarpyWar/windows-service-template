using System;
using Formo;

namespace WindowsServiceTemplate
{
    /// <summary>
    /// Configuration properties
    /// </summary>
    internal class AppSettings
    {
        public static void Init()
        {
            _config = new Configuration();
            // bind to this static class
            _config.Bind<AppSettings>();
        }

        /// <summary>
        /// Formo instance https://github.com/ChrisMissal/Formo
        /// </summary>
        public static Configuration Config
        {
            get
            {
                return _config;
            }
        }
        private static Configuration _config;


        #region User Defined Options in <appSettings>

        public static int StartFrom { get; set; }

        #endregion
    }
}
