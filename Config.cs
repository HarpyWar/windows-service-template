using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;

namespace WindowsServiceTemplate
{
    /// <summary>
    /// Config all-sufficient static class
    ///  - if config file doesn't exist then default values are used
    ///  - feel free to add new configuration fields
    ///  - uncomment GetConfigurationValue() if you want to use app.config instead of {ProgramName}.xml
    /// </summary>
    internal class Config
    {
        private static XmlDocument xmlDoc;

        static Config()
        {
            try
            {
                // get program filename and load config file "{ProgramName}.xml"
                string exeName = Assembly.GetEntryAssembly().Location;
                string configName = Path.GetFileNameWithoutExtension(exeName) + ".xml";

                xmlDoc = new XmlDocument();
                xmlDoc.Load(configName);
            }
            catch
            {
                xmlDoc = null;
            }
        }

        /// <summary>
        /// Service name
        /// </summary>
        public static string ServiceName
        {
            get
            {
                if (_serviceName != null)
                    return _serviceName;

                var value = GetConfigurationValue("ServiceName");
                _serviceName = value ?? "TestService";

                return _serviceName;
            }
        }
        private static string _serviceName;

        /// <summary>
        /// Service display name
        /// </summary>
        public static string DisplayName
        {
            get
            {
                if (_displayName != null)
                    return _displayName;

                var value = GetConfigurationValue("DisplayName");
                _displayName = value ?? "Test Service Title";

                return _displayName;
            }
        }
        private static string _displayName;

        /// <summary>
        /// Service description
        /// </summary>
        public static string Description
        {
            get
            {
                if (_description != null)
                    return _description;

                var value = GetConfigurationValue("Description");
                _description = value ?? "Default service description";

                return _description;
            }
        }
        private static string _description;

        /// <summary>
        /// Log file
        /// </summary>
        public static string LogFile
        {
            get
            {
                if (_logFile != null)
                    return _logFile;

                var value = GetConfigurationValue("LogFile");
                _logFile = value ?? @"event.log";

                return _logFile;
            }
        }
        private static string _logFile;





        /// <summary>
        /// Return config value by key from {ProgramName}.xml
        /// </summary>
        /// <param name="key"></param>
        /// <returns>return null if value doesn't exist</returns>
        private static string GetConfigurationValue(string key)
        {
            if (xmlDoc != null)
                try
                {
                    if (xmlDoc.DocumentElement != null)
                        foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                            if (node.Name == key)
                                return node.InnerText;
                }
                catch { }

            return null;
        }

        /*
        /// <summary>
        /// Return value by key from app.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns>return null if value doesn't exist</returns>
        private static string GetConfigurationValue(string key)
        {
            Assembly service = Assembly.GetAssembly(typeof(Program));
            Configuration config = ConfigurationManager.OpenExeConfiguration(service.Location);
            if (config.AppSettings.Settings[key] != null)
            {
                return config.AppSettings.Settings[key].Value;
            }
            else
            {
                return null;
                //throw new IndexOutOfRangeException("Settings collection does not contain the requested key: " + key);
            }
        }
        */
    }
}
