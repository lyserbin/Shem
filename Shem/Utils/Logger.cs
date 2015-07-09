using System;
using System.IO;

namespace Shem.Utils
{
    /// <summary>
    /// Enum to present the various LogLevel types.
    /// </summary>
    public enum LogTypes
    {
        /// <summary>
        /// Don't log shit.
        /// </summary>
        NONE,

        /// <summary>
        /// Log errors only.
        /// </summary>
        ERROR,

        /// <summary>
        /// Warning and errors will be logged (RECCOMENDED CHOOSE! =D).
        /// </summary>
        WARNING,

        /// <summary>
        /// Notices, warnings and errors will be logged.
        /// </summary>
        INFO,

        /// <summary>
        /// Log everything loggable.
        /// </summary>
        DEBUG
    }

    /// <summary>
    /// Class used to log things to files.
    /// It is static, if you want to change the log-level,
    /// change the 'LogLevel' property.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Represent the level of logging to the console.
        /// </summary>
        public static LogTypes ConsoleLogLevel = LogTypes.INFO;

        /// <summary>
        /// Represent the level of logging to the file.
        /// </summary>
        public static LogTypes FileLogLevel = LogTypes.WARNING;

        // the file where to log to.
        private static string _logfile = "shem.log";
        
        /// <summary>
        /// Log a message.
        /// </summary>
        /// <param name="type">The type of the log (DEBUG, INFO, WARNING, ERROR).</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="logtoconsole">Force the message be logged to the console</param>
        /// <param name="logtofile">Force the message be logged to file</param>
        private static void Log(string message, LogTypes type = LogTypes.INFO, bool logtoconsole = false, bool logtofile = false)
        {
            if (type <= LogTypes.NONE) // Goat boy is a bad boy.
                return;

            if ((ConsoleLogLevel >= type) || logtoconsole)
                Console.WriteLine(String.Format("[{0} {1}] {2}", DateTime.Now.ToString("HH:mm:ss"), type.ToString(), message));

            if ((FileLogLevel >= type) || logtofile)
                File.AppendAllText(_logfile, String.Format("[{0} {1}] {2}\r\n", DateTime.Now.ToString("dd MMM yyyy-HH:mm:ss:fff"), type.ToString(), message));
        }

        public static void LogError(string message, bool logtoconsole = false, bool logtofile = false)
        {
            Log(message, LogTypes.ERROR, logtoconsole, logtofile);
        }

        public static void LogWarn(string message, bool logtoconsole = false, bool logtofile = false)
        {
            Log(message, LogTypes.WARNING, logtoconsole, logtofile);
        }

        public static void LogInfo(string message, bool logtoconsole = false, bool logtofile = false)
        {
            Log(message, LogTypes.INFO, logtoconsole, logtofile);
        }

        public static void LogDebug(string message, bool logtoconsole = false, bool logtofile = false)
        {
            Log(message, LogTypes.DEBUG, logtoconsole, logtofile);
        }
    }
}
