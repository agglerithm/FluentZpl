namespace ZplLabels.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using log4net;
    using log4net.Config;

    public static class Logger
    {
        private static bool _logInitialized;
        public const string CONFIG_FILE_NAME = "Log4Net.config";
        private static readonly Dictionary<Type, ILog> _loggers = new Dictionary<Type, ILog>();

        private static void initialize()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(getConfigFilePath()));
        }

        private static string getConfigFilePath()
        {
            string basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string configPath = Path.Combine(basePath, CONFIG_FILE_NAME);

            if (!File.Exists(configPath))
            {
                configPath = Path.Combine(basePath, "bin");
                configPath = Path.Combine(configPath, CONFIG_FILE_NAME);

                if (!File.Exists(configPath))
                {
                    configPath = Path.Combine(basePath, @"..\" + CONFIG_FILE_NAME);
                }
            }

            return configPath;
        }

        public static void EnsureInitialized()
        {
            if (!_logInitialized)
            {
                initialize();
                _logInitialized = true;
            }
        }

        public static string SerializeException(Exception e)
        {
            return serializeException(e, string.Empty);
        }

        private static string serializeException(Exception e, string exceptionMessage)
        {
            if (e == null) return string.Empty;

            exceptionMessage = string.Format(
                    "{0}{1}{2}\n{3}",
                    exceptionMessage,
                    (exceptionMessage == string.Empty) ? string.Empty : "\n\n",
                    e.Message,
                    e.StackTrace);

            if (e.InnerException != null)
                exceptionMessage = serializeException(e.InnerException, exceptionMessage);

            return exceptionMessage;
        }

        private static ILog getLogger(Type source)
        {
            if (!_loggers.ContainsKey(source))
            {
                lock (_loggers)
                {
                    if (!_loggers.ContainsKey(source))
                    {
                        ILog logger = LogManager.GetLogger(source);
                        _loggers.Add(source, logger);
                    }
                }
            }


            return _loggers[source];
        }

        public static void Debug(object source, string message, params object[] parameters)
        {
            Debug(source.GetType(), message, parameters);
        }

        public static void Debug(Type source, string message, params object[] parameters)
        {
            if(parameters == null || parameters.Length == 0)
                getLogger(source).Debug(message);
            else
                getLogger(source).Debug(string.Format(message, parameters));
        }

        public static void Info(object source, string message, params object[] parameters)
        {
            Info(source.GetType(), message, parameters);
        }

        public static void Info(Type source, string message, params object[] parameters)
        {
            getLogger(source).Info(string.Format(message, parameters));
        }

        public static void Warn(object source, string message, params object[] parameters)
        {
            Warn(source.GetType(), message, parameters);
        }

        public static void Warn(Type source, string message, params object[] parameters)
        {
            getLogger(source).Warn(string.Format(message, parameters));
        }

        public static void Error(object source, string message, params object[] parameters)
        {
            Error(source.GetType(), message, parameters);
        }

        public static void Error(Type source, string message, params object[] parameters)
        {
            getLogger(source).Error(string.Format(message, parameters));
        }

        public static void Fatal(object source, string message, params object[] parameters)
        {
            Fatal(source.GetType(), message, parameters);
        }

        public static void Fatal(Type source, string message, params object[] parameters)
        {
            getLogger(source).Fatal(string.Format(message, parameters));
        }

        public static void Debug(object source, string message, Exception exception)
        {
            Debug(source.GetType(), message, exception);
        }

        public static void Debug(Type source, string message, Exception exception)
        {
            getLogger(source).Debug(message, exception);
        }

        public static void Info(object source, string message, Exception exception)
        {
            Info(source.GetType(), message, exception);
        }

        public static void Info(Type source, string message, Exception exception)
        {
            getLogger(source).Info(message, exception);
        }

        public static void Warn(object source, string message, Exception exception)
        {
            Warn(source.GetType(), message, exception);
        }

        public static void Warn(Type source, string message, Exception exception)
        {
            getLogger(source).Warn(message, exception);
        }

        public static void Error(object source, string message, Exception exception)
        {
            Error(source.GetType(), message, exception);
        }

        public static void Error(Type source, string message, Exception exception)
        {
            getLogger(source).Error(message, exception);
        }

        public static void Fatal(object source, string message, Exception exception)
        {
            Fatal(source.GetType(), message, exception);
        }

        public static void Fatal(Type source, string message, Exception exception)
        {
            getLogger(source).Fatal(message, exception);
        }
    }
}