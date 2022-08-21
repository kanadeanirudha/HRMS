using System;
using log4net;

namespace AERP.ExceptionManager
{
    public class ExceptionManager : ILogger
    {

        #region Property and data member

        private static ILog _logger;

        // Get logger information from config file
        private static ILog Logger
        {
            get
            {
                return _logger ??
                       (_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Logged the debug error with appropriate user message in log file
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Debug, message, null);
            }

        }

        /// <summary>
        /// Logged the debug error in log file with user message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Debug, message, exception);
            }

        }

        /// <summary>
        /// Logged the error with appropriate user message in log file
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            if (Logger.IsErrorEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Error, message, null);
            }

        }


        /// <summary>
        /// Logged the error with appropriate user message in log file
        /// </summary>
        /// <param name="exception"></param>
        public void Error(Exception exception)
        {
            if (Logger.IsErrorEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Error, null, exception);
            }

        }

        /// <summary>
        /// Logged the error in log file with user message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception)
        {
            if (Logger.IsErrorEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Error, message, exception);
            }

        }

        /// <summary>
        /// Logged the fatal error with appropriate user message in log file
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            if (Logger.IsFatalEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Fatal, message, null);
            }
        }

        /// <summary>
        /// Logged the fatal error in log file with user message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception)
        {
            if (Logger.IsFatalEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Fatal, message, exception);
            }

        }

        /// <summary>
        /// Loged the info with appropriate user message
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            if (Logger.IsInfoEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Info, message, null);

            }

        }

        /// <summary>
        /// Loged the info message with user message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception)
        {
            if (Logger.IsInfoEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Info, message, exception);
            }

        }

        /// <summary>
        /// Loged the warning with user message
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            if (Logger.IsWarnEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Warn, message, null);
            }

        }

        /// <summary>
        /// Logged the warning with user messege and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception)
        {
            if (Logger.IsWarnEnabled)
            {
                Logger.Logger.Log(typeof(ExceptionManager), log4net.Core.Level.Warn, message, exception);
            }

        }

        /// <summary>
        /// Set the hierarchy lavel for log4net repository.
        /// </summary>
        /// <param name="loggerName"></param>
        /// <param name="levelName"></param>
        public void SetLevel(string loggerName, string levelName)
        {
            var log = LogManager.GetLogger(loggerName);
            log4net.Repository.Hierarchy.Logger l = (log4net.Repository.Hierarchy.Logger)log.Logger;
            l.Level = l.Hierarchy.LevelMap[levelName];
        }

        /// <summary>
        /// To shut down the logger repository
        /// </summary>
        public void ShutdownLog()
        {
            if (_logger != null)
                Logger.Logger.Repository.Shutdown();
        }

        #endregion

    }
}

